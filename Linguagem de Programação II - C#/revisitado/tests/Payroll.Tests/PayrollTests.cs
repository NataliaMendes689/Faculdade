using Payroll;

namespace PayrollTests;

public class EmployeeTests
{
    private static readonly DateOnly Hired = new(2024, 3, 1);

    [Fact]
    public void Tenure_is_measured_against_a_supplied_date()
    {
        var e = new SalariedEmployee(1, "Ana", Hired, 5_000m);

        Assert.Equal(0, e.TenureDays(Hired));
        Assert.Equal(365, e.TenureDays(new DateOnly(2025, 3, 1)));
    }

    [Fact]
    public void Tenure_before_the_hiring_date_is_zero_not_negative()
    {
        var e = new SalariedEmployee(1, "Ana", Hired, 5_000m);

        Assert.Equal(0, e.TenureDays(new DateOnly(2023, 1, 1)));
    }

    [Fact]
    public void Name_is_trimmed()
    {
        var e = new SalariedEmployee(1, "  Ana  ", Hired, 1m);

        Assert.Equal("Ana", e.Name);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Id_must_be_positive(int id) =>
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new SalariedEmployee(id, "Ana", Hired, 1m));

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    public void Name_is_required(string? name) =>
        Assert.ThrowsAny<ArgumentException>(
            () => new SalariedEmployee(1, name!, Hired, 1m));
}

public class SalariedEmployeeTests
{
    private static readonly DateOnly Hired = new(2024, 3, 1);

    [Fact]
    public void Gross_pay_is_the_monthly_salary()
    {
        var e = new SalariedEmployee(1, "Ana", Hired, 7_250.55m);

        Assert.Equal(7_250.55m, e.GrossPay());
    }

    [Fact]
    public void Salary_cannot_be_negative() =>
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new SalariedEmployee(1, "Ana", Hired, -1m));
}

public class HourlyEmployeeTests
{
    private static readonly DateOnly Hired = new(2024, 3, 1);

    [Fact]
    public void Gross_pay_is_rate_times_hours_worked()
    {
        var e = new HourlyEmployee(2, "Bia", Hired, hourlyRate: 32.50m, hoursWorked: 168m);

        Assert.Equal(5_460.00m, e.GrossPay());
    }

    [Fact]
    public void Absences_do_not_reduce_tenure()
    {
        // The original subtracted absence days from length of service, which conflates
        // attendance with seniority.
        var e = new HourlyEmployee(2, "Bia", Hired, 30m, 160m, absenceDays: 10);

        Assert.Equal(365, e.TenureDays(new DateOnly(2025, 3, 1)));
    }

    [Fact]
    public void Absences_are_not_deducted_twice()
    {
        // Hours worked already excludes the days missed, so pay must not drop again.
        var present = new HourlyEmployee(2, "Bia", Hired, 30m, 160m, absenceDays: 0);
        var absent = new HourlyEmployee(3, "Caio", Hired, 30m, 160m, absenceDays: 5);

        Assert.Equal(present.GrossPay(), absent.GrossPay());
        Assert.Equal(5, absent.AbsenceDays);
    }

    [Fact]
    public void Money_is_rounded_to_two_places_half_to_even()
    {
        var e = new HourlyEmployee(2, "Bia", Hired, hourlyRate: 10.005m, hoursWorked: 1m);

        Assert.Equal(10.00m, e.GrossPay());
    }

    [Fact]
    public void Decimal_avoids_the_binary_rounding_error_double_produces()
    {
        // 0.1 + 0.2 != 0.3 in binary floating point. Payroll cannot afford that.
        var e = new HourlyEmployee(2, "Bia", Hired, hourlyRate: 0.1m, hoursWorked: 3m);

        Assert.Equal(0.30m, e.GrossPay());
        Assert.NotEqual(0.3, 0.1 + 0.1 + 0.1);
    }

    [Theory]
    [InlineData(-1, 10, 0)]
    [InlineData(10, -1, 0)]
    [InlineData(10, 10, -1)]
    public void Negative_inputs_are_rejected(decimal rate, decimal hours, int absences) =>
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new HourlyEmployee(1, "Ana", Hired, rate, hours, absences));

    [Fact]
    public void Zero_hours_pays_nothing_rather_than_failing()
    {
        var e = new HourlyEmployee(2, "Bia", Hired, 30m, 0m);

        Assert.Equal(0m, e.GrossPay());
    }
}

public class PayrollRunTests
{
    private static readonly DateOnly Hired = new(2024, 3, 1);
    private static readonly DateOnly AsOf = new(2025, 3, 1);

    private static Employee[] Staff() =>
    [
        new SalariedEmployee(1, "Ana", Hired, 5_000m),
        new HourlyEmployee(2, "Bia", Hired, 30m, 160m),
        new SalariedEmployee(3, "Caio", Hired, 9_000m),
    ];

    [Fact]
    public void Payslips_come_back_highest_paid_first()
    {
        var slips = PayrollRun.For(Staff(), AsOf);

        Assert.Equal(["Caio", "Ana", "Bia"], slips.Select(s => s.Name));
        Assert.Equal(9_000m, slips[0].Gross);
    }

    [Fact]
    public void Each_payslip_carries_the_tenure_at_the_reference_date()
    {
        var slips = PayrollRun.For(Staff(), AsOf);

        Assert.All(slips, s => Assert.Equal(365, s.TenureDays));
    }

    [Fact]
    public void Total_sums_the_mixed_contract_types()
    {
        Assert.Equal(18_800m, PayrollRun.Total(Staff()));
    }

    [Fact]
    public void An_empty_payroll_totals_zero()
    {
        Assert.Empty(PayrollRun.For([], AsOf));
        Assert.Equal(0m, PayrollRun.Total([]));
    }

    [Fact]
    public void Null_input_is_rejected()
    {
        Assert.Throws<ArgumentNullException>(() => PayrollRun.Total(null!));
        Assert.Throws<ArgumentNullException>(() => PayrollRun.For(null!, AsOf));
    }
}

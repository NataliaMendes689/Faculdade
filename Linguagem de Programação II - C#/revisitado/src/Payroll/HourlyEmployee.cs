namespace Payroll;

public sealed class HourlyEmployee : Employee
{
    public HourlyEmployee(
        int id,
        string name,
        DateOnly hiredOn,
        decimal hourlyRate,
        decimal hoursWorked,
        int absenceDays = 0)
        : base(id, name, hiredOn)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(hourlyRate);
        ArgumentOutOfRangeException.ThrowIfNegative(hoursWorked);
        ArgumentOutOfRangeException.ThrowIfNegative(absenceDays);

        HourlyRate = hourlyRate;
        HoursWorked = hoursWorked;
        AbsenceDays = absenceDays;
    }

    public decimal HourlyRate { get; }

    /// <summary>Hours actually worked in the period. Absences are already excluded from it.</summary>
    public decimal HoursWorked { get; }

    /// <summary>Attendance figure. Does not reduce tenure and is not deducted twice from pay.</summary>
    public int AbsenceDays { get; }

    public override decimal GrossPay() =>
        decimal.Round(HourlyRate * HoursWorked, 2, MidpointRounding.ToEven);
}

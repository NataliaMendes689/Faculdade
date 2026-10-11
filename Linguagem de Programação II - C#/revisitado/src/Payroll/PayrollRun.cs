namespace Payroll;

public sealed record Payslip(int EmployeeId, string Name, decimal Gross, int TenureDays);

public static class PayrollRun
{
    public static IReadOnlyList<Payslip> For(IEnumerable<Employee> employees, DateOnly asOf)
    {
        ArgumentNullException.ThrowIfNull(employees);

        return employees
            .Select(e => new Payslip(e.Id, e.Name, e.GrossPay(), e.TenureDays(asOf)))
            .OrderByDescending(p => p.Gross)
            .ThenBy(p => p.Name, StringComparer.Ordinal)
            .ToList();
    }

    public static decimal Total(IEnumerable<Employee> employees)
    {
        ArgumentNullException.ThrowIfNull(employees);
        return employees.Sum(e => e.GrossPay());
    }
}

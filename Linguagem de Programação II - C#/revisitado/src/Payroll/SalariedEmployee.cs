namespace Payroll;

public sealed class SalariedEmployee : Employee
{
    public SalariedEmployee(int id, string name, DateOnly hiredOn, decimal monthlySalary)
        : base(id, name, hiredOn)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(monthlySalary);
        MonthlySalary = monthlySalary;
    }

    public decimal MonthlySalary { get; }

    public override decimal GrossPay() => MonthlySalary;
}

namespace Payroll;

public abstract class Employee
{
    protected Employee(int id, string name, DateOnly hiredOn)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);

        Id = id;
        Name = name.Trim();
        HiredOn = hiredOn;
    }

    public int Id { get; }

    public string Name { get; }

    public DateOnly HiredOn { get; }

    /// <summary>Days since hiring. The reference date is a parameter so the result is reproducible.</summary>
    public int TenureDays(DateOnly asOf) =>
        asOf < HiredOn ? 0 : asOf.DayNumber - HiredOn.DayNumber;

    public abstract decimal GrossPay();
}

# Payroll — revisited

The same exercise as `../Atividade 6/PClasses`: an employee hierarchy where gross pay
is calculated polymorphically — salaried staff get a fixed amount, hourly staff get
rate times hours.

Written again from scratch, as I would solve it today.

```bash
dotnet test     # 24 tests
```

.NET 10, nullable enabled, nullability warnings escalated to errors.

## What changed, and why

### Money is `decimal`, not `double`

The original types every monetary value as `double`. Binary floating point cannot
represent `0.1` exactly, so `0.1 + 0.1 + 0.1 != 0.3`, and the error compounds across a
payroll run. `decimal` is base-10 and exists for this. There is a test pinning it.

Rounding is explicit — two places, half to even — instead of being left to whatever
the formatter decides at print time.

### The domain class no longer opens a dialog

```csharp
public Mensalista()
{
    System.Windows.Forms.MessageBox.Show("passei por aqui");
}
```

A debug message box inside a business class. It ties the domain to Windows Forms,
blocks any automated test, and would pop up on a server. Alongside it,
`Mensalista(double x)` takes a parameter and does nothing at all.

Both are gone. The library has no UI reference and runs anywhere.

### Tenure takes the date as a parameter

`TempoTrabalho()` read `DateTime.Today` inside itself, so its result changed every
day and could not be asserted. It now takes the reference date:

```csharp
public int TenureDays(DateOnly asOf)
```

The test suite checks exactly 365 days against a fixed pair of dates.

### Absences were applied to the wrong thing

This is the real defect in the original, and it is inverted twice over:

| | Original | Now |
| --- | --- | --- |
| `Horista.TempoTrabalho()` | subtracts absence days from **length of service** | tenure is unaffected |
| `Horista.SalarioBruto()` | **ignores** absences entirely | pay follows hours actually worked |

Missing work does not undo seniority, and hours not worked are already absent from
the hours figure — deducting them again would charge the employee twice.
`AbsenceDays` is kept as an attendance figure, which is what it is.

### Invariants are enforced at construction

The original exposes public setters on everything, so an employee can exist with an
empty name, a negative salary or negative hours. Values are now validated in the
constructor and the properties are read-only. An invalid employee cannot be built.

### There is a payroll run

`PayrollRun.For(...)` walks a mixed collection of contract types and produces
payslips ordered by gross pay. That is the point of the polymorphism the exercise was
teaching — the original only ever instantiated one employee at a time from a form.

## Layout

```
src/Payroll/
  Employee.cs           abstract base, validated, clock-free
  SalariedEmployee.cs
  HourlyEmployee.cs
  PayrollRun.cs         payslips and totals over a mixed collection
tests/Payroll.Tests/
```

# Enrolment — revisited

The same exercise as `../Trabalho 2`: a course enrolment domain — people, students,
instructors, courses, classes and enrolments, with pass or fail at the end.

Written again from scratch, as I would solve it today.

```bash
mvn test     # 19 tests
```

Java 21, compiled with `-Xlint:all -Werror`.

## What changed, and why

### Pass or fail is computed, not stored

The original keeps the result in a field:

```java
private String passaNaoPassa;
public void setPassaNaoPassa(String passaNaoPassa) { ... }
```

Two problems. It is free text, so `"sim"`, `"S"`, `"Aprovado"` and a typo are all
equally valid. And it is a snapshot: correct a grade afterwards and the stored verdict
keeps the old answer, with nothing to flag the contradiction.

`Enrollment.outcome(policy)` derives it on every call from the grade and the
attendance it actually depends on. There is a test that changes a grade from 3.0 to
8.0 and asserts the outcome follows.

The rule itself moved into a `PassingPolicy` record — minimum grade and minimum
attendance — so it is named, validated and swappable instead of being implied by
whoever called the setter.

### `Outcome` says *why* it failed

An enum with `FAILED_ON_GRADE`, `FAILED_ON_ATTENDANCE` and `FAILED_ON_BOTH` rather
than one undifferentiated failure. Failing for absence and failing for marks lead to
different conversations.

### Dates are dates

`private String dtMatricula` became `LocalDate`. A string date cannot be compared,
cannot be ordered, and accepts `"32/13/2024"`.

### Money and grades are `BigDecimal`

`double valor` and `double media` were binary floating point. Prices and marks are
decimal quantities that get compared against thresholds; `0.1 + 0.2 != 0.3` has no
place in either.

### The bidirectional association has one owner

```java
public void addTurmas(Turma turma){
    turmas.add(turma);
    turma.setCurso(this);
}
```

Two sides kept in step by hand. Call `turma.setCurso` directly and they diverge; call
`addTurmas` twice and the list holds the same class twice.

A class is now created only by its course:

```java
CourseClass turma = course.openClass("2026-1", instructor);
```

One place creates the link, so there is no second path that can set one side. The
same applies to enrolment through `courseClass.enrol(student, date)`, which rejects a
duplicate registration instead of silently adding it.

### Collections are not handed out

`getClasses()` and `getEnrollments()` return unmodifiable views. The original exposed
the live `ArrayList` through the object itself, so any caller could clear it.

### Invariants hold from construction

Blank names, non-positive course loads, negative prices, grades outside 0–10 and
absences beyond the course load are all rejected where they are set. The original had
setters for everything and validated none of it.

### `Person` is sealed

`sealed class Person permits Student, Instructor` tells the compiler the hierarchy is
closed, which is true here and makes any future `switch` over it exhaustive.

## Layout

```
src/main/java/fatec/poo/enrollment/
  Person.java          sealed base
  Student.java  Instructor.java
  Course.java          owns its classes
  CourseClass.java     owns its enrolments
  Enrollment.java      grade, attendance, derived outcome
  PassingPolicy.java   the rule, as data
  Outcome.java  EducationLevel.java
src/test/java/...      19 tests
```

package fatec.poo.enrollment;

import java.math.BigDecimal;
import java.math.RoundingMode;
import java.time.LocalDate;
import java.util.Objects;
import java.util.Optional;

public final class Enrollment {

    public static final BigDecimal MAX_GRADE = new BigDecimal("10.0");

    private final Student student;
    private final CourseClass courseClass;
    private final LocalDate enrolledOn;

    private BigDecimal grade;
    private int absenceHours;

    Enrollment(Student student, CourseClass courseClass, LocalDate enrolledOn) {
        this.student = Objects.requireNonNull(student, "student is required");
        this.courseClass = Objects.requireNonNull(courseClass, "courseClass is required");
        this.enrolledOn = Objects.requireNonNull(enrolledOn, "enrolledOn is required");
    }

    public Student getStudent() {
        return student;
    }

    public CourseClass getCourseClass() {
        return courseClass;
    }

    public LocalDate getEnrolledOn() {
        return enrolledOn;
    }

    public Optional<BigDecimal> getGrade() {
        return Optional.ofNullable(grade);
    }

    public int getAbsenceHours() {
        return absenceHours;
    }

    public void recordGrade(BigDecimal value) {
        Objects.requireNonNull(value, "grade is required");
        if (value.signum() < 0 || value.compareTo(MAX_GRADE) > 0) {
            throw new IllegalArgumentException("grade must be between 0 and " + MAX_GRADE + ", got " + value);
        }
        this.grade = value;
    }

    public void recordAbsenceHours(int hours) {
        if (hours < 0) {
            throw new IllegalArgumentException("absence hours cannot be negative, got " + hours);
        }
        if (hours > courseClass.getCourse().getHours()) {
            throw new IllegalArgumentException(
                    "absence hours cannot exceed the course load of " + courseClass.getCourse().getHours());
        }
        this.absenceHours = hours;
    }

    public BigDecimal attendance() {
        int total = courseClass.getCourse().getHours();
        return BigDecimal.valueOf(total - absenceHours)
                .divide(BigDecimal.valueOf(total), 4, RoundingMode.HALF_EVEN);
    }

    /** Derived on every call, so it cannot drift from the grade and attendance it depends on. */
    public Outcome outcome(PassingPolicy policy) {
        Objects.requireNonNull(policy, "policy is required");

        if (grade == null) {
            return Outcome.IN_PROGRESS;
        }

        boolean failedGrade = grade.compareTo(policy.minimumGrade()) < 0;
        boolean failedAttendance = attendance().compareTo(policy.minimumAttendance()) < 0;

        if (failedGrade && failedAttendance) {
            return Outcome.FAILED_ON_BOTH;
        }
        if (failedGrade) {
            return Outcome.FAILED_ON_GRADE;
        }
        if (failedAttendance) {
            return Outcome.FAILED_ON_ATTENDANCE;
        }
        return Outcome.PASSED;
    }

    public Outcome outcome() {
        return outcome(PassingPolicy.DEFAULT);
    }
}

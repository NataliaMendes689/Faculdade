package fatec.poo.enrollment;

import java.math.BigDecimal;
import java.util.Objects;

public record PassingPolicy(BigDecimal minimumGrade, BigDecimal minimumAttendance) {

    public static final PassingPolicy DEFAULT =
            new PassingPolicy(new BigDecimal("6.0"), new BigDecimal("0.75"));

    public PassingPolicy {
        Objects.requireNonNull(minimumGrade, "minimumGrade is required");
        Objects.requireNonNull(minimumAttendance, "minimumAttendance is required");

        if (minimumGrade.signum() < 0 || minimumGrade.compareTo(Enrollment.MAX_GRADE) > 0) {
            throw new IllegalArgumentException("minimumGrade must be between 0 and " + Enrollment.MAX_GRADE);
        }
        if (minimumAttendance.signum() < 0 || minimumAttendance.compareTo(BigDecimal.ONE) > 0) {
            throw new IllegalArgumentException("minimumAttendance must be between 0 and 1");
        }
    }
}

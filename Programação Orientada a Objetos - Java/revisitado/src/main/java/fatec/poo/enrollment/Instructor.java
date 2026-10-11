package fatec.poo.enrollment;

import java.math.BigDecimal;
import java.util.Objects;

public final class Instructor extends Person {

    private final int code;
    private final String fieldOfWork;
    private final BigDecimal hourlyRate;

    public Instructor(int code, String name, String fieldOfWork, BigDecimal hourlyRate) {
        super(name);
        if (code <= 0) {
            throw new IllegalArgumentException("code must be positive, got " + code);
        }
        Objects.requireNonNull(hourlyRate, "hourlyRate is required");
        if (hourlyRate.signum() < 0) {
            throw new IllegalArgumentException("hourlyRate cannot be negative");
        }

        this.code = code;
        this.fieldOfWork = requireText(fieldOfWork, "fieldOfWork");
        this.hourlyRate = hourlyRate;
    }

    public int getCode() {
        return code;
    }

    public String getFieldOfWork() {
        return fieldOfWork;
    }

    public BigDecimal getHourlyRate() {
        return hourlyRate;
    }

    @Override
    public String toString() {
        return code + " " + getName();
    }
}

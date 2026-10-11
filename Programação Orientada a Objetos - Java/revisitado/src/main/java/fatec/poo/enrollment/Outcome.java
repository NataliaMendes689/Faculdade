package fatec.poo.enrollment;

public enum Outcome {
    IN_PROGRESS,
    PASSED,
    FAILED_ON_GRADE,
    FAILED_ON_ATTENDANCE,
    FAILED_ON_BOTH;

    public boolean isFailure() {
        return this == FAILED_ON_GRADE || this == FAILED_ON_ATTENDANCE || this == FAILED_ON_BOTH;
    }
}

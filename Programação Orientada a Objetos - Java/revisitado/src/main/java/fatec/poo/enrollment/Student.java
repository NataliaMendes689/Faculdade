package fatec.poo.enrollment;

public final class Student extends Person {

    private final String registration;
    private final EducationLevel educationLevel;

    public Student(String registration, String name, EducationLevel educationLevel) {
        super(name);
        this.registration = requireText(registration, "registration");
        this.educationLevel = educationLevel == null ? EducationLevel.UNSPECIFIED : educationLevel;
    }

    public Student(String registration, String name) {
        this(registration, name, EducationLevel.UNSPECIFIED);
    }

    public String getRegistration() {
        return registration;
    }

    public EducationLevel getEducationLevel() {
        return educationLevel;
    }

    @Override
    public String toString() {
        return registration + " " + getName();
    }
}

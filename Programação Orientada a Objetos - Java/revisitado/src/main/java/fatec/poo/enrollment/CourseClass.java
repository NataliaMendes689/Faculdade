package fatec.poo.enrollment;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Objects;

public final class CourseClass {

    private final String identifier;
    private final Course course;
    private final Instructor instructor;
    private final List<Enrollment> enrollments = new ArrayList<>();

    CourseClass(String identifier, Course course, Instructor instructor) {
        this.identifier = Person.requireText(identifier, "identifier");
        this.course = Objects.requireNonNull(course, "course is required");
        this.instructor = Objects.requireNonNull(instructor, "instructor is required");
    }

    public String getIdentifier() {
        return identifier;
    }

    public Course getCourse() {
        return course;
    }

    public Instructor getInstructor() {
        return instructor;
    }

    public Enrollment enrol(Student student, LocalDate enrolledOn) {
        Objects.requireNonNull(student, "student is required");

        boolean alreadyEnrolled = enrollments.stream()
                .anyMatch(e -> e.getStudent().getRegistration().equals(student.getRegistration()));
        if (alreadyEnrolled) {
            throw new IllegalStateException(
                    "student " + student.getRegistration() + " is already enrolled in " + identifier);
        }

        Enrollment enrollment = new Enrollment(student, this, enrolledOn);
        enrollments.add(enrollment);
        return enrollment;
    }

    public List<Enrollment> getEnrollments() {
        return Collections.unmodifiableList(enrollments);
    }

    public List<Enrollment> passed(PassingPolicy policy) {
        return enrollments.stream().filter(e -> e.outcome(policy) == Outcome.PASSED).toList();
    }

    @Override
    public String toString() {
        return course.getCode() + "/" + identifier;
    }
}

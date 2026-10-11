package fatec.poo.enrollment;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Nested;
import org.junit.jupiter.api.Test;

import java.math.BigDecimal;
import java.time.LocalDate;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.junit.jupiter.api.Assertions.assertTrue;

class EnrollmentTest {

    private static final LocalDate TODAY = LocalDate.of(2026, 3, 2);

    private Course course;
    private CourseClass turma;
    private Student ana;

    @BeforeEach
    void setUp() {
        course = new Course("POO", "Object oriented programming", 80, new BigDecimal("1200.00"));
        Instructor instructor =
                new Instructor(1, "Marcos", "Software engineering", new BigDecimal("150.00"));
        turma = course.openClass("2026-1", instructor);
        ana = new Student("0030482123017", "Ana", EducationLevel.UNDERGRADUATE);
    }

    @Nested
    @DisplayName("association")
    class Association {

        @Test
        void opening_a_class_links_both_sides_at_once() {
            assertEquals(1, course.getClasses().size());
            assertEquals(course, turma.getCourse());
        }

        @Test
        void the_class_list_cannot_be_modified_from_outside() {
            assertThrows(UnsupportedOperationException.class,
                    () -> course.getClasses().clear());
        }

        @Test
        void the_same_student_cannot_enrol_twice_in_one_class() {
            turma.enrol(ana, TODAY);

            assertThrows(IllegalStateException.class, () -> turma.enrol(ana, TODAY));
            assertEquals(1, turma.getEnrollments().size());
        }
    }

    @Nested
    @DisplayName("outcome")
    class OutcomeRules {

        @Test
        void is_in_progress_until_a_grade_is_recorded() {
            Enrollment e = turma.enrol(ana, TODAY);

            assertEquals(Outcome.IN_PROGRESS, e.outcome());
            assertTrue(e.getGrade().isEmpty());
        }

        @Test
        void passes_with_a_sufficient_grade_and_attendance() {
            Enrollment e = turma.enrol(ana, TODAY);
            e.recordGrade(new BigDecimal("7.5"));
            e.recordAbsenceHours(8);

            assertEquals(Outcome.PASSED, e.outcome());
        }

        @Test
        void fails_on_grade_alone() {
            Enrollment e = turma.enrol(ana, TODAY);
            e.recordGrade(new BigDecimal("5.9"));

            assertEquals(Outcome.FAILED_ON_GRADE, e.outcome());
        }

        @Test
        void fails_on_attendance_alone() {
            Enrollment e = turma.enrol(ana, TODAY);
            e.recordGrade(new BigDecimal("9.0"));
            e.recordAbsenceHours(21);

            assertEquals(Outcome.FAILED_ON_ATTENDANCE, e.outcome());
        }

        @Test
        void distinguishes_failing_on_both() {
            Enrollment e = turma.enrol(ana, TODAY);
            e.recordGrade(new BigDecimal("2.0"));
            e.recordAbsenceHours(60);

            assertEquals(Outcome.FAILED_ON_BOTH, e.outcome());
            assertTrue(e.outcome().isFailure());
        }

        @Test
        void exactly_at_the_threshold_passes() {
            Enrollment e = turma.enrol(ana, TODAY);
            e.recordGrade(new BigDecimal("6.0"));
            e.recordAbsenceHours(20);

            assertEquals(new BigDecimal("0.7500"), e.attendance());
            assertEquals(Outcome.PASSED, e.outcome());
        }

        @Test
        void recomputes_after_the_grade_changes() {
            // The original stored pass/fail as a free-text field, so it kept the old
            // answer when the grade was corrected.
            Enrollment e = turma.enrol(ana, TODAY);
            e.recordGrade(new BigDecimal("3.0"));
            assertEquals(Outcome.FAILED_ON_GRADE, e.outcome());

            e.recordGrade(new BigDecimal("8.0"));
            assertEquals(Outcome.PASSED, e.outcome());
        }

        @Test
        void honours_a_stricter_policy() {
            Enrollment e = turma.enrol(ana, TODAY);
            e.recordGrade(new BigDecimal("6.5"));

            PassingPolicy strict = new PassingPolicy(new BigDecimal("7.0"), new BigDecimal("0.90"));

            assertEquals(Outcome.PASSED, e.outcome());
            assertEquals(Outcome.FAILED_ON_GRADE, e.outcome(strict));
        }
    }

    @Nested
    @DisplayName("validation")
    class Validation {

        @Test
        void grade_outside_the_scale_is_rejected() {
            Enrollment e = turma.enrol(ana, TODAY);

            assertThrows(IllegalArgumentException.class, () -> e.recordGrade(new BigDecimal("-1")));
            assertThrows(IllegalArgumentException.class, () -> e.recordGrade(new BigDecimal("10.1")));
        }

        @Test
        void absences_beyond_the_course_load_are_rejected() {
            Enrollment e = turma.enrol(ana, TODAY);

            assertThrows(IllegalArgumentException.class, () -> e.recordAbsenceHours(-1));
            assertThrows(IllegalArgumentException.class, () -> e.recordAbsenceHours(81));
        }

        @Test
        void blank_names_and_codes_are_rejected() {
            assertThrows(IllegalArgumentException.class, () -> new Student("123", "   "));
            assertThrows(IllegalArgumentException.class, () -> new Student("  ", "Ana"));
            assertThrows(IllegalArgumentException.class,
                    () -> new Course("", "x", 10, BigDecimal.ONE));
        }

        @Test
        void non_positive_course_load_is_rejected() {
            assertThrows(IllegalArgumentException.class,
                    () -> new Course("X", "x", 0, BigDecimal.ONE));
        }

        @Test
        void negative_money_is_rejected() {
            assertThrows(IllegalArgumentException.class,
                    () -> new Course("X", "x", 10, new BigDecimal("-0.01")));
            assertThrows(IllegalArgumentException.class,
                    () -> new Instructor(1, "M", "area", new BigDecimal("-1")));
        }

        @Test
        void a_policy_outside_its_range_is_rejected() {
            assertThrows(IllegalArgumentException.class,
                    () -> new PassingPolicy(new BigDecimal("11"), new BigDecimal("0.5")));
            assertThrows(IllegalArgumentException.class,
                    () -> new PassingPolicy(new BigDecimal("6"), new BigDecimal("1.5")));
        }

        @Test
        void names_are_trimmed() {
            assertEquals("Ana", new Student("1", "  Ana  ").getName());
        }
    }

    @Nested
    @DisplayName("reporting")
    class Reporting {

        @Test
        void lists_only_the_students_who_passed() {
            Student bia = new Student("2", "Bia");
            Student caio = new Student("3", "Caio");

            Enrollment a = turma.enrol(ana, TODAY);
            Enrollment b = turma.enrol(bia, TODAY);
            Enrollment c = turma.enrol(caio, TODAY);

            a.recordGrade(new BigDecimal("8.0"));
            b.recordGrade(new BigDecimal("4.0"));
            c.recordGrade(new BigDecimal("9.0"));
            c.recordAbsenceHours(40);

            var passed = turma.passed(PassingPolicy.DEFAULT);

            assertEquals(1, passed.size());
            assertEquals("Ana", passed.get(0).getStudent().getName());
            assertFalse(passed.contains(c));
        }
    }
}

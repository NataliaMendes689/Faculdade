package fatec.poo.enrollment;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Objects;

public final class Course {

    private final String code;
    private final String description;
    private final int hours;
    private final BigDecimal price;
    private final List<CourseClass> classes = new ArrayList<>();

    public Course(String code, String description, int hours, BigDecimal price) {
        Objects.requireNonNull(price, "price is required");
        if (hours <= 0) {
            throw new IllegalArgumentException("hours must be positive, got " + hours);
        }
        if (price.signum() < 0) {
            throw new IllegalArgumentException("price cannot be negative");
        }

        this.code = Person.requireText(code, "code");
        this.description = Person.requireText(description, "description");
        this.hours = hours;
        this.price = price;
    }

    public String getCode() {
        return code;
    }

    public String getDescription() {
        return description;
    }

    public int getHours() {
        return hours;
    }

    public BigDecimal getPrice() {
        return price;
    }

    /**
     * The only way a class comes into existence, so the link between the two can never
     * be set on one side and missed on the other.
     */
    public CourseClass openClass(String identifier, Instructor instructor) {
        CourseClass opened = new CourseClass(identifier, this, instructor);
        classes.add(opened);
        return opened;
    }

    public List<CourseClass> getClasses() {
        return Collections.unmodifiableList(classes);
    }
}

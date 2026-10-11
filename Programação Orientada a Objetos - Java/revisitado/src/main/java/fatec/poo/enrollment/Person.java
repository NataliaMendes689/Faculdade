package fatec.poo.enrollment;

import java.util.Objects;

public abstract sealed class Person permits Student, Instructor {

    private final String name;

    protected Person(String name) {
        this.name = requireText(name, "name");
    }

    public String getName() {
        return name;
    }

    static String requireText(String value, String field) {
        Objects.requireNonNull(value, field + " is required");
        String trimmed = value.trim();
        if (trimmed.isEmpty()) {
            throw new IllegalArgumentException(field + " cannot be blank");
        }
        return trimmed;
    }
}

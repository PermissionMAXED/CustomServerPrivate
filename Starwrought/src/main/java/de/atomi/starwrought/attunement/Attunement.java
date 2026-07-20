package de.atomi.starwrought.attunement;

import java.util.Locale;

public enum Attunement {
    NONE,
    WOLF,
    LYRA,
    ANVIL;

    public String id() {
        return name().toLowerCase(Locale.ROOT);
    }

    public static Attunement fromId(String value) {
        return parse(value);
    }

    public static Attunement parse(String value) {
        if (value == null || value.isBlank()) {
            return NONE;
        }
        try {
            return valueOf(value.toUpperCase(Locale.ROOT));
        } catch (IllegalArgumentException ignored) {
            return NONE;
        }
    }
}

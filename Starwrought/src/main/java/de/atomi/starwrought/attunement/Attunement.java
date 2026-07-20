package de.atomi.starwrought.attunement;

import java.util.Locale;

public enum Attunement {
    NONE,
    WOLF,
    LYRA,
    ANVIL;

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

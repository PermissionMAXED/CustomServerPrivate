package de.atomi.starwrought.logic;

/**
 * Pure scheduling logic for the two mutually-exclusive celestial events.
 * Minecraft's persistent state stores the returned next-night values.
 */
public final class SkyEventSchedule {
    public enum Event {
        NONE,
        AURORA,
        UMBRAL
    }

    private SkyEventSchedule() {
    }

    public static Event eventForNight(long night, long nextAurora, long nextUmbral) {
        if (night < 0) {
            return Event.NONE;
        }
        if (night >= nextUmbral) {
            return Event.UMBRAL;
        }
        if (night >= nextAurora) {
            return Event.AURORA;
        }
        return Event.NONE;
    }

    public static long nextAurora(long completedNight, long worldSeed) {
        return completedNight + 4 + jitter(worldSeed, completedNight, 2);
    }

    public static long nextUmbral(long completedNight, long worldSeed) {
        return completedNight + 12 + jitter(worldSeed ^ 0x5DEECE66DL, completedNight, 4);
    }

    public static long avoidCollision(long proposedNight, long otherNight) {
        return proposedNight == otherNight ? proposedNight + 1 : proposedNight;
    }

    private static int jitter(long seed, long night, int bound) {
        long value = seed ^ (night * 0x9E3779B97F4A7C15L);
        value ^= value >>> 30;
        value *= 0xBF58476D1CE4E5B9L;
        value ^= value >>> 27;
        value *= 0x94D049BB133111EBL;
        value ^= value >>> 31;
        return (int) Math.floorMod(value, bound);
    }
}

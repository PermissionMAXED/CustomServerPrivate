package de.atomi.starwrought.attunement;

/**
 * Immutable, codec-friendly player progression. Counter thresholds are shared
 * by all constellations while each constellation advances from its own action.
 */
public record AttunementProgress(Attunement attunement, int counter) {
    private static final int[] THRESHOLDS = {0, 8, 24, 48, 80};

    public AttunementProgress {
        attunement = attunement == null ? Attunement.NONE : attunement;
        counter = Math.max(0, counter);
    }

    public static AttunementProgress unattuned() {
        return new AttunementProgress(Attunement.NONE, 0);
    }

    public int level() {
        if (attunement == Attunement.NONE) {
            return 0;
        }
        int level = 1;
        for (int i = 1; i < THRESHOLDS.length; i++) {
            if (counter >= THRESHOLDS[i]) {
                level = i + 1;
            }
        }
        return level;
    }

    public int pointsToNextLevel() {
        int level = level();
        if (level == 0) {
            return 0;
        }
        if (level >= 5) {
            return 0;
        }
        return THRESHOLDS[level] - counter;
    }

    public AttunementProgress addProgress(int amount) {
        if (amount <= 0 || attunement == Attunement.NONE) {
            return this;
        }
        return new AttunementProgress(attunement, Math.min(THRESHOLDS[4], counter + amount));
    }

    public AttunementProgress attune(Attunement next) {
        return next == null || next == Attunement.NONE ? unattuned() : new AttunementProgress(next, 0);
    }
}

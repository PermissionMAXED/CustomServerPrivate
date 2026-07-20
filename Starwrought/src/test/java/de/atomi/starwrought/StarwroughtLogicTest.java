package de.atomi.starwrought;

import de.atomi.starwrought.attunement.Attunement;
import de.atomi.starwrought.attunement.AttunementProgress;
import de.atomi.starwrought.handbook.UnlockCondition;
import de.atomi.starwrought.logic.PrismPalette;
import de.atomi.starwrought.logic.SkyEventSchedule;
import org.junit.jupiter.api.Test;

import java.util.Set;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertFalse;
import static org.junit.jupiter.api.Assertions.assertNotEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

class StarwroughtLogicTest {
    @Test
    void attunementLevelsUseSharedThresholdsAndCap() {
        assertEquals(0, AttunementProgress.unattuned().level());
        assertEquals(1, new AttunementProgress(Attunement.WOLF, 0).level());
        assertEquals(2, new AttunementProgress(Attunement.WOLF, 8).level());
        assertEquals(4, new AttunementProgress(Attunement.LYRA, 48).level());
        assertEquals(5, new AttunementProgress(Attunement.ANVIL, 80).level());
        assertEquals(80, new AttunementProgress(Attunement.ANVIL, 70).addProgress(50).counter());
    }

    @Test
    void schedulePrioritizesUmbralAndAvoidsCollisions() {
        assertEquals(SkyEventSchedule.Event.NONE, SkyEventSchedule.eventForNight(3, 4, 12));
        assertEquals(SkyEventSchedule.Event.AURORA, SkyEventSchedule.eventForNight(4, 4, 12));
        assertEquals(SkyEventSchedule.Event.UMBRAL, SkyEventSchedule.eventForNight(12, 12, 12));
        assertEquals(13, SkyEventSchedule.avoidCollision(12, 12));
        assertTrue(SkyEventSchedule.nextAurora(10, 1) >= 14);
        assertTrue(SkyEventSchedule.nextAurora(10, 1) <= 15);
        assertTrue(SkyEventSchedule.nextUmbral(10, 1) >= 22);
        assertTrue(SkyEventSchedule.nextUmbral(10, 1) <= 25);
    }

    @Test
    void unlockConditionsReadOnlyTheirOwnContext() {
        var context = new UnlockCondition.UnlockContext(
                Set.of("starwrought:star_shard"),
                Set.of("starwrought:first_shard"),
                Set.of("starwrought:secrets"));
        assertTrue(new UnlockCondition.Always().isUnlocked(context));
        assertTrue(new UnlockCondition.HasItem("starwrought:star_shard").isUnlocked(context));
        assertFalse(new UnlockCondition.HasItem("minecraft:diamond").isUnlocked(context));
        assertTrue(new UnlockCondition.Advancement("starwrought:first_shard").isUnlocked(context));
        assertTrue(new UnlockCondition.Manual("starwrought:secrets").isUnlocked(context));
    }

    @Test
    void paletteMixClampsAndInterpolates() {
        assertEquals(PrismPalette.INDIGO, PrismPalette.mix(PrismPalette.INDIGO, PrismPalette.CYAN, -1));
        assertEquals(PrismPalette.CYAN, PrismPalette.mix(PrismPalette.INDIGO, PrismPalette.CYAN, 2));
        assertNotEquals(PrismPalette.INDIGO, PrismPalette.mix(PrismPalette.INDIGO, PrismPalette.CYAN, .5F));
        assertEquals("#FFE9A8", PrismPalette.hex(PrismPalette.GOLD));
    }
}

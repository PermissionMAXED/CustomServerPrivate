package de.atomi.starwrought.handbook;

import java.util.Set;

/**
 * Pure handbook gating model. The server adapts a player's inventory,
 * advancements and manual unlock attachment into an {@link UnlockContext}.
 */
public sealed interface UnlockCondition permits UnlockCondition.Always,
        UnlockCondition.HasItem, UnlockCondition.Advancement, UnlockCondition.Manual {

    boolean isUnlocked(UnlockContext context);

    record UnlockContext(Set<String> items, Set<String> advancements, Set<String> manualUnlocks) {
        public UnlockContext {
            items = Set.copyOf(items);
            advancements = Set.copyOf(advancements);
            manualUnlocks = Set.copyOf(manualUnlocks);
        }
    }

    record Always() implements UnlockCondition {
        @Override
        public boolean isUnlocked(UnlockContext context) {
            return true;
        }
    }

    record HasItem(String itemId) implements UnlockCondition {
        @Override
        public boolean isUnlocked(UnlockContext context) {
            return context.items().contains(itemId);
        }
    }

    record Advancement(String advancementId) implements UnlockCondition {
        @Override
        public boolean isUnlocked(UnlockContext context) {
            return context.advancements().contains(advancementId);
        }
    }

    record Manual(String entryId) implements UnlockCondition {
        @Override
        public boolean isUnlocked(UnlockContext context) {
            return context.manualUnlocks().contains(entryId);
        }
    }
}

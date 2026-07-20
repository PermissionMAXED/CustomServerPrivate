package de.atomi.starwrought.entity;

import de.atomi.starwrought.Starwrought;
import net.fabricmc.fabric.api.object.builder.v1.entity.FabricDefaultAttributeRegistry;
import net.minecraft.entity.EntityType;
import net.minecraft.entity.SpawnGroup;
import net.minecraft.entity.attribute.EntityAttributes;
import net.minecraft.entity.mob.ZombieEntity;
import net.minecraft.registry.Registries;
import net.minecraft.registry.Registry;
import net.minecraft.registry.RegistryKey;
import net.minecraft.registry.RegistryKeys;

public final class ModEntities {
    public static final EntityType<HollowStalkerEntity> HOLLOW_STALKER =
            register("hollow_stalker", EntityType.Builder
                    .create(HollowStalkerEntity::new, SpawnGroup.MONSTER)
                    .dimensions(0.65F, 1.95F)
                    .maxTrackingRange(8));

    public static final EntityType<HeraldEntity> HERALD =
            register("herald", EntityType.Builder
                    .create(HeraldEntity::new, SpawnGroup.MONSTER)
                    .dimensions(0.9F, 2.8F)
                    .maxTrackingRange(12)
                    .makeFireImmune());

    private ModEntities() {
    }

    private static <T extends net.minecraft.entity.Entity> EntityType<T> register(
            String name, EntityType.Builder<T> builder) {
        RegistryKey<EntityType<?>> key = RegistryKey.of(RegistryKeys.ENTITY_TYPE, Starwrought.id(name));
        return Registry.register(Registries.ENTITY_TYPE, key, builder.build(key));
    }

    public static void initialize() {
        FabricDefaultAttributeRegistry.register(HOLLOW_STALKER,
                ZombieEntity.createZombieAttributes()
                        .add(EntityAttributes.MAX_HEALTH, 28.0)
                        .add(EntityAttributes.MOVEMENT_SPEED, 0.27)
                        .add(EntityAttributes.ATTACK_DAMAGE, 5.0)
                        .add(EntityAttributes.FOLLOW_RANGE, 36.0));
        FabricDefaultAttributeRegistry.register(HERALD,
                ZombieEntity.createZombieAttributes()
                        .add(EntityAttributes.MAX_HEALTH, 240.0)
                        .add(EntityAttributes.MOVEMENT_SPEED, 0.25)
                        .add(EntityAttributes.ATTACK_DAMAGE, 11.0)
                        .add(EntityAttributes.FOLLOW_RANGE, 48.0)
                        .add(EntityAttributes.KNOCKBACK_RESISTANCE, 0.65));
    }
}

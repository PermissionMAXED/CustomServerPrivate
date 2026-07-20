package de.atomi.starwrought.content;

import de.atomi.starwrought.Starwrought;
import net.fabricmc.fabric.api.object.builder.v1.block.entity.FabricBlockEntityTypeBuilder;
import net.minecraft.block.entity.BlockEntityType;
import net.minecraft.registry.Registries;
import net.minecraft.registry.Registry;

public final class ModBlockEntities {
    public static final BlockEntityType<StarForgeBlockEntity> STAR_FORGE = Registry.register(
            Registries.BLOCK_ENTITY_TYPE,
            Starwrought.id("star_forge"),
            FabricBlockEntityTypeBuilder.create(StarForgeBlockEntity::new, ModBlocks.STAR_FORGE).build());

    private ModBlockEntities() {
    }

    public static void initialize() {
        // Static initialization performs registration.
    }
}

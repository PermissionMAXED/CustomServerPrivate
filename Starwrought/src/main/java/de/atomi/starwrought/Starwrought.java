package de.atomi.starwrought;

import de.atomi.starwrought.content.ModBlockEntities;
import de.atomi.starwrought.content.ModBlocks;
import de.atomi.starwrought.content.ModItems;
import de.atomi.starwrought.entity.ModEntities;
import de.atomi.starwrought.handbook.HandbookLoader;
import de.atomi.starwrought.network.ModNetworking;
import de.atomi.starwrought.player.PlayerAttachments;
import de.atomi.starwrought.registry.ModParticles;
import de.atomi.starwrought.system.PlayerProgression;
import de.atomi.starwrought.system.SkyEvents;
import net.fabricmc.api.ModInitializer;
import net.minecraft.util.Identifier;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

public final class Starwrought implements ModInitializer {
    public static final String MOD_ID = "starwrought";
    public static final Logger LOGGER = LoggerFactory.getLogger(MOD_ID);

    public static Identifier id(String path) {
        return Identifier.of(MOD_ID, path);
    }

    @Override
    public void onInitialize() {
        PlayerAttachments.initialize();
        ModParticles.initialize();
        ModItems.initialize();
        ModBlocks.initialize();
        ModBlockEntities.initialize();
        ModEntities.initialize();
        HandbookLoader.initialize();
        ModNetworking.initialize();
        SkyEvents.initialize();
        PlayerProgression.initialize();
        LOGGER.info("Starwrought common systems initialized");
    }
}

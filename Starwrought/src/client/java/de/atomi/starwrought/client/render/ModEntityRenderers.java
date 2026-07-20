package de.atomi.starwrought.client.render;

import de.atomi.starwrought.entity.ModEntities;
import net.fabricmc.fabric.api.client.rendering.v1.EntityRendererRegistry;
import net.minecraft.client.render.entity.ZombieEntityRenderer;

public final class ModEntityRenderers {
	private ModEntityRenderers() {
	}

	public static void initialize() {
		// Zombie models give Hollow Stalkers / the Herald an immediate readable silhouette;
		// PRISMBREAK particles and boss-bar spectacle carry the fantasy identity.
		EntityRendererRegistry.register(ModEntities.HOLLOW_STALKER, ZombieEntityRenderer::new);
		EntityRendererRegistry.register(ModEntities.HERALD, ZombieEntityRenderer::new);
	}
}

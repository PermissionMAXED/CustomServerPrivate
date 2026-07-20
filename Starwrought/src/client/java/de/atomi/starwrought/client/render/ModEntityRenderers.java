package de.atomi.starwrought.client.render;

import de.atomi.starwrought.Starwrought;
import de.atomi.starwrought.entity.ModEntities;
import net.fabricmc.fabric.api.client.rendering.v1.EntityRendererRegistry;
import net.minecraft.client.render.entity.EntityRendererFactory;
import net.minecraft.client.render.entity.ZombieEntityRenderer;
import net.minecraft.client.render.entity.state.ZombieEntityRenderState;
import net.minecraft.client.util.math.MatrixStack;
import net.minecraft.util.Identifier;

public final class ModEntityRenderers {
	private ModEntityRenderers() {
	}

	public static void initialize() {
		EntityRendererRegistry.register(ModEntities.HOLLOW_STALKER, HollowStalkerRenderer::new);
		EntityRendererRegistry.register(ModEntities.HERALD, HeraldRenderer::new);
	}

	private static final class HollowStalkerRenderer extends ZombieEntityRenderer {
		private static final Identifier TEXTURE =
				Starwrought.id("textures/entity/hollow_stalker.png");

		private HollowStalkerRenderer(EntityRendererFactory.Context context) {
			super(context);
		}

		@Override
		public Identifier getTexture(ZombieEntityRenderState state) {
			return TEXTURE;
		}
	}

	private static final class HeraldRenderer extends ZombieEntityRenderer {
		private static final Identifier TEXTURE =
				Starwrought.id("textures/entity/herald.png");

		private HeraldRenderer(EntityRendererFactory.Context context) {
			super(context);
		}

		@Override
		public Identifier getTexture(ZombieEntityRenderState state) {
			return TEXTURE;
		}

		@Override
		protected void scale(ZombieEntityRenderState state, MatrixStack matrices) {
			super.scale(state, matrices);
			matrices.scale(1.35F, 1.35F, 1.35F);
		}
	}
}

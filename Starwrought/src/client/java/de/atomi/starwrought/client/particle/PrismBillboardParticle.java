package de.atomi.starwrought.client.particle;

import net.minecraft.client.particle.BillboardParticle;
import net.minecraft.client.particle.SpriteProvider;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.util.math.MathHelper;
import net.minecraft.util.math.random.Random;

/**
 * 1.21.9 replaced SpriteBillboardParticle with sprite-backed BillboardParticle.
 * This base preserves the animated sprite and full-bright behavior expected by
 * Starwrought's emissive-looking particles.
 */
abstract class PrismBillboardParticle extends BillboardParticle {
	protected final SpriteProvider sprites;
	protected final float initialScale;

	protected PrismBillboardParticle(
			ClientWorld world,
			double x,
			double y,
			double z,
			double velocityX,
			double velocityY,
			double velocityZ,
			SpriteProvider sprites,
			Random random,
			float scale
	) {
		super(world, x, y, z, velocityX, velocityY, velocityZ, sprites.getSprite(random));
		this.sprites = sprites;
		this.initialScale = scale;
		this.scale = scale;
		this.velocityX = velocityX;
		this.velocityY = velocityY;
		this.velocityZ = velocityZ;
		this.collidesWithWorld = false;
	}

	protected float progress() {
		return MathHelper.clamp((float) age / Math.max(1, maxAge), 0.0F, 1.0F);
	}

	protected float softFade(float progress) {
		float fadeIn = MathHelper.clamp(progress * 7.0F, 0.0F, 1.0F);
		float fadeOut = MathHelper.clamp((1.0F - progress) * 4.0F, 0.0F, 1.0F);
		return fadeIn * fadeOut;
	}

	@Override
	public int getBrightness(float tint) {
		return 0xF000F0;
	}

	@Override
	public RenderType getRenderType() {
		return RenderType.PARTICLE_ATLAS_TRANSLUCENT;
	}
}

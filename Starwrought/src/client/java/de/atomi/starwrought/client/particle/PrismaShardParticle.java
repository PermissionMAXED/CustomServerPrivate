package de.atomi.starwrought.client.particle;

import de.atomi.starwrought.client.fx.Easings;
import de.atomi.starwrought.client.fx.PrismPalette;
import net.minecraft.client.particle.Particle;
import net.minecraft.client.particle.ParticleFactory;
import net.minecraft.client.particle.SpriteProvider;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.particle.SimpleParticleType;
import net.minecraft.util.math.random.Random;

public final class PrismaShardParticle extends PrismBillboardParticle {
	private final float spin;

	private PrismaShardParticle(
			ClientWorld world,
			double x,
			double y,
			double z,
			double velocityX,
			double velocityY,
			double velocityZ,
			SpriteProvider sprites,
			Random random
	) {
		super(world, x, y, z, velocityX, velocityY, velocityZ, sprites, random, 0.15F + random.nextFloat() * 0.13F);
		this.maxAge = 22 + random.nextInt(17);
		this.velocityMultiplier = 0.97F;
		this.gravityStrength = 0.45F;
		this.collidesWithWorld = true;
		this.zRotation = random.nextFloat() * (float) (Math.PI * 2.0);
		this.spin = (random.nextBoolean() ? 1.0F : -1.0F) * (0.13F + random.nextFloat() * 0.17F);
		setColor(PrismPalette.red(PrismPalette.CYAN), PrismPalette.green(PrismPalette.CYAN), PrismPalette.blue(PrismPalette.CYAN));
		setAlpha(0.92F);
	}

	@Override
	public void tick() {
		super.tick();
		float progress = progress();
		updateSprite(sprites);
		zRotation += spin * (onGround ? 0.2F : 1.0F);
		scale = initialScale * (1.0F - 0.7F * Easings.outCubic(progress));
		setAlpha(softFade(progress));

		int color = PrismPalette.lerp(PrismPalette.CYAN, PrismPalette.WHITE_GOLD, progress);
		setColor(PrismPalette.red(color), PrismPalette.green(color), PrismPalette.blue(color));
	}

	public static final class Factory implements ParticleFactory<SimpleParticleType> {
		private final SpriteProvider sprites;

		public Factory(SpriteProvider sprites) {
			this.sprites = sprites;
		}

		@Override
		public Particle createParticle(
				SimpleParticleType effect,
				ClientWorld world,
				double x,
				double y,
				double z,
				double velocityX,
				double velocityY,
				double velocityZ,
				Random random
		) {
			return new PrismaShardParticle(
					world, x, y, z, velocityX, velocityY, velocityZ, sprites, random
			);
		}
	}
}

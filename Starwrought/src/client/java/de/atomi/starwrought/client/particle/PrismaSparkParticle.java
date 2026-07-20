package de.atomi.starwrought.client.particle;

import de.atomi.starwrought.client.fx.Easings;
import de.atomi.starwrought.client.fx.PrismPalette;
import net.minecraft.client.particle.Particle;
import net.minecraft.client.particle.ParticleFactory;
import net.minecraft.client.particle.SpriteProvider;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.particle.SimpleParticleType;
import net.minecraft.util.math.random.Random;

public final class PrismaSparkParticle extends PrismBillboardParticle {
	private PrismaSparkParticle(
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
		super(world, x, y, z, velocityX, velocityY, velocityZ, sprites, random, 0.09F + random.nextFloat() * 0.08F);
		this.maxAge = 10 + random.nextInt(9);
		this.velocityMultiplier = 0.91F;
		this.gravityStrength = -0.015F;
		this.zRotation = random.nextFloat() * (float) (Math.PI * 2.0);

		int color = switch (random.nextInt(4)) {
			case 0 -> PrismPalette.WHITE_GOLD;
			case 1 -> PrismPalette.WHITE;
			default -> PrismPalette.CYAN;
		};
		setColor(PrismPalette.red(color), PrismPalette.green(color), PrismPalette.blue(color));
		setAlpha(0.95F);
	}

	@Override
	public void tick() {
		super.tick();
		float progress = progress();
		updateSprite(sprites);
		scale = initialScale * (0.35F + 1.4F * Easings.pulse(progress));
		setAlpha(softFade(progress));
		zRotation += 0.18F;
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
			return new PrismaSparkParticle(
					world, x, y, z, velocityX, velocityY, velocityZ, sprites, random
			);
		}
	}
}

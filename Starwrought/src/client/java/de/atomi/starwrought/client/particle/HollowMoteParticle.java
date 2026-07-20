package de.atomi.starwrought.client.particle;

import de.atomi.starwrought.client.fx.PrismPalette;
import net.minecraft.client.particle.Particle;
import net.minecraft.client.particle.ParticleFactory;
import net.minecraft.client.particle.SpriteProvider;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.particle.SimpleParticleType;
import net.minecraft.util.math.random.Random;

public final class HollowMoteParticle extends PrismBillboardParticle {
	private final float phase;

	private HollowMoteParticle(
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
		super(world, x, y, z, velocityX, velocityY, velocityZ, sprites, random, 0.12F + random.nextFloat() * 0.12F);
		this.maxAge = 42 + random.nextInt(38);
		this.velocityMultiplier = 0.96F;
		this.gravityStrength = -0.02F;
		this.phase = random.nextFloat() * (float) (Math.PI * 2.0);
		this.zRotation = phase;
		setColor(PrismPalette.red(PrismPalette.INDIGO), PrismPalette.green(PrismPalette.INDIGO), PrismPalette.blue(PrismPalette.INDIGO));
		setAlpha(0.7F);
	}

	@Override
	public void tick() {
		super.tick();
		float progress = progress();
		updateSprite(sprites);
		double curl = age * 0.18 + phase;
		velocityX += Math.cos(curl) * 0.0018;
		velocityZ += Math.sin(curl) * 0.0018;
		scale = initialScale * (0.78F + (float) Math.sin(curl * 0.72) * 0.22F);
		setAlpha(softFade(progress) * 0.72F);

		int color = PrismPalette.lerp(PrismPalette.INDIGO, PrismPalette.CYAN, 0.35F + progress * 0.35F);
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
			return new HollowMoteParticle(
					world, x, y, z, velocityX, velocityY, velocityZ, sprites, random
			);
		}
	}
}

package de.atomi.starwrought.client.fx;

import de.atomi.starwrought.client.hud.ClientHudState;
import de.atomi.starwrought.registry.ModParticles;
import java.util.concurrent.ThreadLocalRandom;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.util.math.Vec3d;

/**
 * Composes the visual beats for one authoritative ability/impact event.
 */
public final class SpectacleDirector {
	private SpectacleDirector() {
	}

	public static void abilityUse() {
		MinecraftClient client = MinecraftClient.getInstance();
		if (client.player == null) {
			return;
		}
		Vec3d eye = client.player.getEyePos();
		Vec3d impact = eye.add(client.player.getRotationVec(1.0F).multiply(2.4));
		impact(impact, 0.72F);
	}

	public static void impact(Vec3d center, float requestedIntensity) {
		MinecraftClient client = MinecraftClient.getInstance();
		ClientWorld world = client.world;
		if (world == null) {
			return;
		}

		float intensity = Math.max(0.2F, Math.min(1.5F, requestedIntensity));
		TraumaCamera.addTrauma(0.32F * intensity);
		TraumaCamera.addFovKick(0.045F * intensity);
		ClientHudState.flash(0.38F * intensity);
		ShockwaveRenderer.spawn(center, intensity);

		ThreadLocalRandom random = ThreadLocalRandom.current();
		for (int i = 0; i < 22 + (int) (intensity * 12.0F); i++) {
			double angle = random.nextDouble(Math.PI * 2.0);
			double speed = random.nextDouble(0.035, 0.13) * intensity;
			world.addParticleClient(
					i % 3 == 0 ? ModParticles.PRISMA_SHARD : ModParticles.PRISMA_SPARK,
					center.x, center.y + 0.08, center.z,
					Math.cos(angle) * speed,
					random.nextDouble(0.025, 0.16) * intensity,
					Math.sin(angle) * speed
			);
		}

		for (int i = 0; i < 3; i++) {
			double angle = Math.PI * 2.0 * i / 3.0 + random.nextDouble(-0.3, 0.3);
			Vec3d end = center.add(
					Math.cos(angle) * (1.8 + intensity),
					0.5 + random.nextDouble() * 1.2,
					Math.sin(angle) * (1.8 + intensity)
			);
			LightningArcRenderer.arc(center.add(0.0, 0.15, 0.0), end, random.nextLong(), intensity);
		}
	}
}

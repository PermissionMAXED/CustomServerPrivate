package de.atomi.starwrought.client.fx;

import de.atomi.starwrought.registry.ModParticles;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.util.math.Vec3d;

public final class ShockwaveRenderer {
	private static final List<Ring> RINGS = new ArrayList<>();

	private ShockwaveRenderer() {
	}

	public static void spawn(Vec3d center, float intensity) {
		RINGS.add(new Ring(center, Math.max(0.25F, intensity)));
	}

	public static void tick(MinecraftClient client) {
		if (client.world == null) {
			RINGS.clear();
			return;
		}

		Iterator<Ring> iterator = RINGS.iterator();
		while (iterator.hasNext()) {
			Ring ring = iterator.next();
			ring.age++;
			if (ring.age >= ring.duration) {
				iterator.remove();
				continue;
			}
			spawnFrame(client.world, ring);
		}
	}

	public static void reset() {
		RINGS.clear();
	}

	private static void spawnFrame(ClientWorld world, Ring ring) {
		float progress = ring.age / (float) ring.duration;
		double radius = 0.25 + Easings.outExpo(progress) * 5.2 * ring.intensity;
		int samples = 18 + (int) (ring.intensity * 8.0F);
		double phase = ring.age * 0.09;

		for (int i = 0; i < samples; i++) {
			double angle = Math.PI * 2.0 * i / samples + phase;
			double x = ring.center.x + Math.cos(angle) * radius;
			double z = ring.center.z + Math.sin(angle) * radius;
			double y = ring.center.y + 0.04 + Math.sin(angle * 3.0 + phase) * 0.05;
			world.addParticleClient(
					i % 4 == 0 ? ModParticles.PRISMA_SHARD : ModParticles.PRISMA_SPARK,
					x, y, z,
					Math.cos(angle) * 0.012,
					0.006 + (1.0 - progress) * 0.015,
					Math.sin(angle) * 0.012
			);
		}
	}

	private static final class Ring {
		private final Vec3d center;
		private final float intensity;
		private final int duration;
		private int age;

		private Ring(Vec3d center, float intensity) {
			this.center = center;
			this.intensity = intensity;
			this.duration = 14 + (int) (intensity * 6.0F);
		}
	}
}

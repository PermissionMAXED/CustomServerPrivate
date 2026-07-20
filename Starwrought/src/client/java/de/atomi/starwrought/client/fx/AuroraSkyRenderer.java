package de.atomi.starwrought.client.fx;

import de.atomi.starwrought.registry.ModParticles;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.util.math.Vec3d;
import net.minecraft.world.World;

/**
 * Particle-ribbon aurora compatible with the 1.21.9 extracted world renderer.
 */
public final class AuroraSkyRenderer {
	private static boolean hasSyncedState;
	private static boolean syncedActive;
	private static int remainingTicks;
	private static long ticks;

	private AuroraSkyRenderer() {
	}

	public static void setSyncedState(boolean active, int ticksRemaining) {
		hasSyncedState = true;
		syncedActive = active;
		remainingTicks = Math.max(0, ticksRemaining);
	}

	public static void tick(MinecraftClient client) {
		ticks++;
		if (client.world == null || client.player == null) {
			return;
		}
		if (remainingTicks > 0) {
			remainingTicks--;
		}
		if (hasSyncedState && remainingTicks == 0) {
			syncedActive = false;
		}
		if (!isActive(client.world) || ticks % 2L != 0L) {
			return;
		}

		spawnRibbons(client.world, client.player.getEntityPos(), ticks);
	}

	public static boolean isActive(ClientWorld world) {
		if (world.getRegistryKey() != World.OVERWORLD) {
			return false;
		}
		if (hasSyncedState) {
			return syncedActive;
		}
		long dayTime = Math.floorMod(world.getTimeOfDay(), 24_000L);
		return dayTime >= 13_000L && dayTime <= 23_000L && !world.isRaining();
	}

	public static void reset() {
		hasSyncedState = false;
		syncedActive = false;
		remainingTicks = 0;
		ticks = 0L;
	}

	private static void spawnRibbons(ClientWorld world, Vec3d origin, long time) {
		for (int ribbon = 0; ribbon < 3; ribbon++) {
			double phase = time * (0.025 + ribbon * 0.004) + ribbon * 2.1;
			for (int sample = 0; sample < 7; sample++) {
				double along = (sample - 3) * 4.0;
				double x = origin.x + along;
				double z = origin.z + Math.sin(phase + sample * 0.52) * (7.0 + ribbon * 2.0);
				double y = origin.y + 16.0 + ribbon * 2.7
						+ Math.sin(phase * 0.73 + sample * 0.65) * 2.2;
				world.addParticleClient(
						sample % 3 == 0 ? ModParticles.PRISMA_SPARK : ModParticles.HOLLOW_MOTE,
						x, y, z,
						0.0, 0.008, 0.0
				);
			}
		}
	}
}

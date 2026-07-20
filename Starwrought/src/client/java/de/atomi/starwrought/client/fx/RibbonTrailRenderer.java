package de.atomi.starwrought.client.fx;

import de.atomi.starwrought.registry.ModParticles;
import java.util.ArrayDeque;
import java.util.Deque;
import java.util.HashMap;
import java.util.Map;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.entity.Entity;
import net.minecraft.entity.projectile.ProjectileEntity;
import net.minecraft.util.math.Vec3d;

/**
 * Particle-strip fallback for 1.21.9, whose render-state extraction removed
 * Fabric's legacy WorldRenderEvents triangle-strip hook.
 */
public final class RibbonTrailRenderer {
	private static final int MAX_POINTS = 10;
	private static final Map<Integer, Trail> TRAILS = new HashMap<>();
	private static long tick;

	private RibbonTrailRenderer() {
	}

	public static void tick(MinecraftClient client) {
		tick++;
		if (client.world == null || client.player == null) {
			TRAILS.clear();
			return;
		}

		track(client.world, client.player, true);
		int projectiles = 0;
		for (Entity entity : client.world.getEntities()) {
			if (entity instanceof ProjectileEntity && projectiles++ < 24) {
				track(client.world, entity, false);
			}
		}
		TRAILS.values().removeIf(trail -> tick - trail.lastSeen > 3);
	}

	public static void reset() {
		TRAILS.clear();
		tick = 0L;
	}

	private static void track(ClientWorld world, Entity entity, boolean player) {
		Vec3d current = entity.getEntityPos().add(0.0, entity.getHeight() * (player ? 0.52 : 0.35), 0.0);
		Trail trail = TRAILS.computeIfAbsent(entity.getId(), ignored -> new Trail());
		trail.lastSeen = tick;
		Vec3d previous = trail.points.peekLast();
		if (previous == null) {
			trail.points.add(current);
			return;
		}

		double minimumDistance = player ? 0.035 : 0.018;
		if (previous.squaredDistanceTo(current) < minimumDistance * minimumDistance) {
			return;
		}

		trail.points.add(current);
		while (trail.points.size() > MAX_POINTS) {
			trail.points.removeFirst();
		}

		Vec3d delta = current.subtract(previous);
		int samples = Math.min(6, Math.max(2, (int) (delta.length() * 7.0)));
		for (int i = 1; i <= samples; i++) {
			double amount = i / (double) samples;
			Vec3d point = previous.lerp(current, amount);
			double wave = Math.sin((tick + i) * 1.7) * (player ? 0.018 : 0.009);
			world.addParticleClient(
					ModParticles.PRISMA_SPARK,
					point.x, point.y + wave, point.z,
					-delta.x * 0.018, 0.002, -delta.z * 0.018
			);
		}
	}

	private static final class Trail {
		private final Deque<Vec3d> points = new ArrayDeque<>();
		private long lastSeen;
	}
}

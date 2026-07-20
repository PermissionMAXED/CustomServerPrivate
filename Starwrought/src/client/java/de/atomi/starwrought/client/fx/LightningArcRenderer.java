package de.atomi.starwrought.client.fx;

import de.atomi.starwrought.registry.ModParticles;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.world.ClientWorld;
import net.minecraft.util.math.Vec3d;

/**
 * Generates jagged arcs through iterative midpoint displacement.
 */
public final class LightningArcRenderer {
	private LightningArcRenderer() {
	}

	public static void arc(Vec3d start, Vec3d end, long seed, float intensity) {
		ClientWorld world = MinecraftClient.getInstance().world;
		if (world == null) {
			return;
		}

		Random random = new Random(seed);
		List<Vec3d> points = new ArrayList<>();
		points.add(start);
		points.add(end);
		double displacement = Math.max(0.08, start.distanceTo(end) * 0.2 * intensity);

		for (int level = 0; level < 4; level++) {
			List<Vec3d> next = new ArrayList<>(points.size() * 2 - 1);
			for (int i = 0; i < points.size() - 1; i++) {
				Vec3d from = points.get(i);
				Vec3d to = points.get(i + 1);
				Vec3d direction = to.subtract(from).normalize();
				Vec3d perpendicular = direction.crossProduct(new Vec3d(0.0, 1.0, 0.0));
				if (perpendicular.lengthSquared() < 0.001) {
					perpendicular = direction.crossProduct(new Vec3d(1.0, 0.0, 0.0));
				}
				perpendicular = perpendicular.normalize();
				Vec3d midpoint = from.lerp(to, 0.5).add(
						perpendicular.multiply((random.nextDouble() * 2.0 - 1.0) * displacement)
				);
				midpoint = midpoint.add(0.0, (random.nextDouble() - 0.5) * displacement * 0.55, 0.0);
				next.add(from);
				next.add(midpoint);
			}
			next.add(points.getLast());
			points = next;
			displacement *= 0.53;
		}

		for (int i = 0; i < points.size() - 1; i++) {
			spawnSegment(world, points.get(i), points.get(i + 1), random);
		}
	}

	private static void spawnSegment(ClientWorld world, Vec3d start, Vec3d end, Random random) {
		double length = start.distanceTo(end);
		int samples = Math.max(2, (int) Math.ceil(length * 7.0));
		for (int i = 0; i <= samples; i++) {
			Vec3d point = start.lerp(end, i / (double) samples);
			world.addParticleClient(
					i % 3 == 0 ? ModParticles.PRISMA_SHARD : ModParticles.PRISMA_SPARK,
					point.x, point.y, point.z,
					(random.nextDouble() - 0.5) * 0.008,
					(random.nextDouble() - 0.5) * 0.008,
					(random.nextDouble() - 0.5) * 0.008
			);
		}
	}
}

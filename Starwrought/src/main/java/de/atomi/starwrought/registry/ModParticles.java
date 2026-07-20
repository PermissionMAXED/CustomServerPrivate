package de.atomi.starwrought.registry;

import net.fabricmc.fabric.api.particle.v1.FabricParticleTypes;
import net.minecraft.particle.SimpleParticleType;
import net.minecraft.registry.Registries;
import net.minecraft.registry.Registry;
import net.minecraft.util.Identifier;

/**
 * Particle types shared by the logical server and client.
 */
public final class ModParticles {
	public static final SimpleParticleType PRISMA_SPARK = register("prisma_spark");
	public static final SimpleParticleType PRISMA_SHARD = register("prisma_shard");
	public static final SimpleParticleType HOLLOW_MOTE = register("hollow_mote");

	private ModParticles() {
	}

	private static SimpleParticleType register(String path) {
		return Registry.register(
				Registries.PARTICLE_TYPE,
				Identifier.of("starwrought", path),
				FabricParticleTypes.simple()
		);
	}

	/**
	 * Forces static registration without exposing implementation details.
	 */
	public static void initialize() {
		// Static fields do the registration.
	}
}

package de.atomi.starwrought.client.fx;

import net.minecraft.util.math.MathHelper;

/**
 * Shared camera impulse accumulator read by the camera and FOV mixins.
 */
public final class TraumaCamera {
	private static float trauma;
	private static float fovKick;
	private static long sample;

	private TraumaCamera() {
	}

	public static void addTrauma(float amount) {
		trauma = MathHelper.clamp(trauma + amount, 0.0F, 1.0F);
	}

	public static void addFovKick(float amount) {
		fovKick = MathHelper.clamp(fovKick + amount, 0.0F, 0.22F);
	}

	public static void tick() {
		trauma = Math.max(0.0F, trauma - 0.035F);
		fovKick *= 0.82F;
		if (fovKick < 0.0005F) {
			fovKick = 0.0F;
		}
		sample++;
	}

	public static float yawOffset() {
		float strength = trauma * trauma;
		return noise(sample * 0.71F + 11.3F) * 2.8F * strength;
	}

	public static float pitchOffset() {
		float strength = trauma * trauma;
		return noise(sample * 0.93F + 47.1F) * 2.1F * strength;
	}

	public static float fovMultiplier() {
		return 1.0F + fovKick;
	}

	public static void reset() {
		trauma = 0.0F;
		fovKick = 0.0F;
		sample = 0L;
	}

	private static float noise(float value) {
		double wave = Math.sin(value) + Math.sin(value * 2.173F + 0.73F) * 0.5;
		return (float) (wave / 1.5);
	}
}

package de.atomi.starwrought.client.fx;

import net.minecraft.util.math.MathHelper;

public final class Easings {
	private Easings() {
	}

	public static float outCubic(float value) {
		float t = MathHelper.clamp(value, 0.0F, 1.0F) - 1.0F;
		return 1.0F + t * t * t;
	}

	public static float outExpo(float value) {
		float t = MathHelper.clamp(value, 0.0F, 1.0F);
		return t >= 1.0F ? 1.0F : 1.0F - (float) Math.pow(2.0, -10.0F * t);
	}

	public static float pulse(float value) {
		float t = MathHelper.clamp(value, 0.0F, 1.0F);
		return (float) Math.sin(t * Math.PI);
	}
}

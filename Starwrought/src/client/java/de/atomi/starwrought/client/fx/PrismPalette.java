package de.atomi.starwrought.client.fx;

import net.minecraft.util.math.MathHelper;

/**
 * PRISMBREAK color language: void-indigo, energized cyan, and white-gold.
 */
public final class PrismPalette {
	public static final int INDIGO = 0xFF2A1B5E;
	public static final int DEEP_INDIGO = 0xFF120B2D;
	public static final int CYAN = 0xFF4DE3FF;
	public static final int WHITE_GOLD = 0xFFFFE9A8;
	public static final int WHITE = 0xFFF8FCFF;

	private PrismPalette() {
	}

	public static float red(int argb) {
		return ((argb >> 16) & 0xFF) / 255.0F;
	}

	public static float green(int argb) {
		return ((argb >> 8) & 0xFF) / 255.0F;
	}

	public static float blue(int argb) {
		return (argb & 0xFF) / 255.0F;
	}

	public static int withAlpha(int rgb, float alpha) {
		return (MathHelper.clamp((int) (alpha * 255.0F), 0, 255) << 24) | (rgb & 0x00FFFFFF);
	}

	public static int lerp(int from, int to, float amount) {
		float t = MathHelper.clamp(amount, 0.0F, 1.0F);
		int red = MathHelper.lerp(t, (from >> 16) & 0xFF, (to >> 16) & 0xFF);
		int green = MathHelper.lerp(t, (from >> 8) & 0xFF, (to >> 8) & 0xFF);
		int blue = MathHelper.lerp(t, from & 0xFF, to & 0xFF);
		return 0xFF000000 | red << 16 | green << 8 | blue;
	}
}

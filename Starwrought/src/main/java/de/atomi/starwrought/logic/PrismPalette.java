package de.atomi.starwrought.logic;

public final class PrismPalette {
    public static final int INDIGO = 0x2A1B5E;
    public static final int CYAN = 0x4DE3FF;
    public static final int GOLD = 0xFFE9A8;
    public static final int VOID = 0x0C081C;

    private PrismPalette() {
    }

    public static int mix(int first, int second, float amount) {
        float t = Math.clamp(amount, 0.0F, 1.0F);
        int red = Math.round(channel(first, 16) + (channel(second, 16) - channel(first, 16)) * t);
        int green = Math.round(channel(first, 8) + (channel(second, 8) - channel(first, 8)) * t);
        int blue = Math.round(channel(first, 0) + (channel(second, 0) - channel(first, 0)) * t);
        return red << 16 | green << 8 | blue;
    }

    public static String hex(int color) {
        return "#%06X".formatted(color & 0xFFFFFF);
    }

    private static int channel(int color, int shift) {
        return color >> shift & 0xFF;
    }
}

package de.atomi.starwrought.client.hud;

import de.atomi.starwrought.client.fx.PrismPalette;
import java.util.Locale;
import net.fabricmc.fabric.api.client.rendering.v1.hud.HudElement;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.gui.DrawContext;
import net.minecraft.client.render.RenderTickCounter;
import net.minecraft.text.Text;
import net.minecraft.util.math.MathHelper;

public final class StarwroughtHud implements HudElement {
	private static final int BAR_WIDTH = 154;

	@Override
	public void render(DrawContext context, RenderTickCounter tickCounter) {
		MinecraftClient client = MinecraftClient.getInstance();
		if (client.player == null || client.options.hudHidden) {
			return;
		}

		int screenWidth = context.getScaledWindowWidth();
		int screenHeight = context.getScaledWindowHeight();
		int left = screenWidth / 2 - BAR_WIDTH / 2;
		int top = screenHeight - 62;

		if (ClientHudState.isAttuned()) {
			renderAbilityPanel(context, client, left, top);
		}
		renderVignette(context, client, screenWidth, screenHeight);
	}

	private static void renderAbilityPanel(DrawContext context, MinecraftClient client, int left, int top) {
		context.fill(left - 5, top - 5, left + BAR_WIDTH + 5, top + 25, 0xA8120B2D);
		context.fill(left - 3, top - 3, left + BAR_WIDTH + 3, top - 2, PrismPalette.CYAN);
		context.fill(left - 3, top + 23, left + BAR_WIDTH + 3, top + 24, 0xAA4DE3FF);

		String key = "hud.starwrought.attunement."
				+ ClientHudState.attunement().toLowerCase(Locale.ROOT);
		Text attunement = Text.translatable(key);
		context.drawTextWithShadow(client.textRenderer, attunement, left, top - 1, PrismPalette.WHITE_GOLD);

		float charge = ClientHudState.charge();
		drawBar(context, left, top + 10, BAR_WIDTH, 5, charge, PrismPalette.CYAN, 0xCC2A1B5E);

		float cooldown = ClientHudState.cooldownProgress();
		int readyColor = cooldown <= 0.0F ? PrismPalette.WHITE_GOLD : PrismPalette.INDIGO;
		drawBar(context, left, top + 17, BAR_WIDTH, 3, 1.0F - cooldown, readyColor, 0xAA0B071B);
		if (cooldown > 0.0F) {
			Text cooldownText = Text.translatable("hud.starwrought.cooldown", ClientHudState.cooldownTicks() / 20.0F);
			int textWidth = client.textRenderer.getWidth(cooldownText);
			context.drawTextWithShadow(
					client.textRenderer,
					cooldownText,
					left + BAR_WIDTH - textWidth,
					top - 1,
					0xFFD6D0F4
			);
		}
	}

	private static void drawBar(
			DrawContext context,
			int x,
			int y,
			int width,
			int height,
			float progress,
			int color,
			int background
	) {
		context.fill(x - 1, y - 1, x + width + 1, y + height + 1, 0xCC080512);
		context.fill(x, y, x + width, y + height, background);
		int filled = MathHelper.clamp((int) (width * progress), 0, width);
		if (filled > 0) {
			context.fill(x, y, x + filled, y + height, color);
			context.fill(x + Math.max(0, filled - 2), y, x + filled, y + height, 0xEEFFFFFF);
		}
	}

	private static void renderVignette(
			DrawContext context,
			MinecraftClient client,
			int screenWidth,
			int screenHeight
	) {
		float healthRatio = client.player.getHealth() / Math.max(1.0F, client.player.getMaxHealth());
		float lowHealth = MathHelper.clamp((0.38F - healthRatio) / 0.38F, 0.0F, 1.0F);
		float damage = ClientHudState.damageFlash();
		float strength = Math.max(lowHealth * (0.58F + 0.16F * (float) Math.sin(System.nanoTime() * 0.000000008)), damage);
		if (strength > 0.01F) {
			int edge = PrismPalette.withAlpha(0xFF2A1B5E, strength * 0.72F);
			int inner = PrismPalette.withAlpha(0xFF4DE3FF, strength * 0.13F);
			int thickness = 22;
			context.fillGradient(0, 0, screenWidth, thickness, edge, inner);
			context.fillGradient(0, screenHeight - thickness, screenWidth, screenHeight, inner, edge);
			context.fill(0, thickness, 9, screenHeight - thickness, edge);
			context.fill(screenWidth - 9, thickness, screenWidth, screenHeight - thickness, edge);
		}

		float flash = ClientHudState.spectacleFlash();
		if (flash > 0.01F) {
			context.fill(
					0, 0, screenWidth, screenHeight,
					PrismPalette.withAlpha(PrismPalette.WHITE_GOLD, flash * 0.42F)
			);
		}
	}
}

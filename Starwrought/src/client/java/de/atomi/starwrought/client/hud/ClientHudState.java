package de.atomi.starwrought.client.hud;

import de.atomi.starwrought.attunement.Attunement;
import de.atomi.starwrought.player.PlayerAttachments;
import net.minecraft.client.MinecraftClient;
import net.minecraft.util.math.MathHelper;

public final class ClientHudState {
	private static final float MAX_ATTUNEMENT_PROGRESS = 80.0F;

	private static String attunement = Attunement.NONE.name();
	private static float charge;
	private static int cooldownTicks;
	private static int maxCooldownTicks = 1;
	private static float damageFlash;
	private static float spectacleFlash;
	private static float lastHealth = -1.0F;

	private ClientHudState() {
	}

	public static void setAbility(String name, float newCharge, int cooldown, int maximum) {
		attunement = name == null || name.isBlank() ? Attunement.NONE.name() : name;
		charge = MathHelper.clamp(newCharge, 0.0F, 1.0F);
		cooldownTicks = Math.max(0, cooldown);
		maxCooldownTicks = Math.max(1, maximum);
	}

	public static void flash(float intensity) {
		spectacleFlash = MathHelper.clamp(spectacleFlash + intensity, 0.0F, 1.0F);
	}

	public static void tick(MinecraftClient client) {
		if (cooldownTicks > 0) {
			cooldownTicks--;
		}
		damageFlash *= 0.78F;
		spectacleFlash *= 0.76F;

		if (client.player == null) {
			attunement = Attunement.NONE.name();
			charge = 0.0F;
			lastHealth = -1.0F;
			return;
		}
		var progress = client.player.getAttached(PlayerAttachments.ATTUNEMENT);
		if (progress == null || progress.attunement() == Attunement.NONE) {
			attunement = Attunement.NONE.name();
			charge = 0.0F;
		} else {
			attunement = progress.attunement().name();
			charge = MathHelper.clamp(progress.counter() / MAX_ATTUNEMENT_PROGRESS, 0.0F, 1.0F);
		}
		float health = client.player.getHealth();
		if (lastHealth >= 0.0F && health + 0.01F < lastHealth) {
			damageFlash = MathHelper.clamp(damageFlash + (lastHealth - health) * 0.16F, 0.25F, 0.9F);
		}
		lastHealth = health;
	}

	public static String attunement() {
		return attunement;
	}

	public static float charge() {
		return charge;
	}

	public static boolean isAttuned() {
		return !Attunement.NONE.name().equalsIgnoreCase(attunement);
	}

	public static float cooldownProgress() {
		return MathHelper.clamp(cooldownTicks / (float) maxCooldownTicks, 0.0F, 1.0F);
	}

	public static int cooldownTicks() {
		return cooldownTicks;
	}

	public static float damageFlash() {
		return damageFlash;
	}

	public static float spectacleFlash() {
		return spectacleFlash;
	}

	public static void reset() {
		attunement = Attunement.NONE.name();
		charge = 0.0F;
		cooldownTicks = 0;
		maxCooldownTicks = 1;
		damageFlash = 0.0F;
		spectacleFlash = 0.0F;
		lastHealth = -1.0F;
	}
}

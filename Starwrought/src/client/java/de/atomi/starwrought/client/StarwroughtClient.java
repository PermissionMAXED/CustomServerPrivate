package de.atomi.starwrought.client;

import de.atomi.starwrought.client.fx.AuroraSkyRenderer;
import de.atomi.starwrought.client.fx.RibbonTrailRenderer;
import de.atomi.starwrought.client.fx.ShockwaveRenderer;
import de.atomi.starwrought.client.fx.SpectacleDirector;
import de.atomi.starwrought.client.fx.TraumaCamera;
import de.atomi.starwrought.client.handbook.HandbookScreen;
import de.atomi.starwrought.client.handbook.HandbookState;
import de.atomi.starwrought.client.hud.ClientHudState;
import de.atomi.starwrought.client.hud.StarwroughtHud;
import de.atomi.starwrought.client.particle.HollowMoteParticle;
import de.atomi.starwrought.client.particle.PrismaShardParticle;
import de.atomi.starwrought.client.particle.PrismaSparkParticle;
import de.atomi.starwrought.client.render.ModEntityRenderers;
import de.atomi.starwrought.network.ClientboundPayloads;
import de.atomi.starwrought.network.ModNetworking;
import de.atomi.starwrought.registry.ModParticles;
import net.fabricmc.api.ClientModInitializer;
import net.fabricmc.fabric.api.client.event.lifecycle.v1.ClientTickEvents;
import net.fabricmc.fabric.api.client.keybinding.v1.KeyBindingHelper;
import net.fabricmc.fabric.api.client.networking.v1.ClientPlayConnectionEvents;
import net.fabricmc.fabric.api.client.networking.v1.ClientPlayNetworking;
import net.fabricmc.fabric.api.client.particle.v1.ParticleFactoryRegistry;
import net.fabricmc.fabric.api.client.rendering.v1.hud.HudElementRegistry;
import net.fabricmc.fabric.api.client.rendering.v1.hud.VanillaHudElements;
import net.minecraft.client.MinecraftClient;
import net.minecraft.client.option.KeyBinding;
import net.minecraft.client.sound.PositionedSoundInstance;
import net.minecraft.client.util.InputUtil;
import net.minecraft.sound.SoundEvents;
import net.minecraft.util.Identifier;
import net.minecraft.util.math.Vec3d;
import org.lwjgl.glfw.GLFW;

public final class StarwroughtClient implements ClientModInitializer {
	private static final Identifier HUD_ID = id("prismbreak_hud");
	private static KeyBinding handbookKey;
	private static KeyBinding abilityKey;

	@Override
	public void onInitializeClient() {
		ModParticles.initialize();
		ClientboundPayloads.register();
		ModEntityRenderers.initialize();
		registerParticleFactories();
		registerKeyBindings();
		registerNetworkingReceivers();
		registerHud();
		registerClientEvents();
	}

	public static void openHandbook() {
		MinecraftClient client = MinecraftClient.getInstance();
		client.execute(() -> client.setScreen(new HandbookScreen(HandbookState.INSTANCE)));
	}

	private static void registerParticleFactories() {
		ParticleFactoryRegistry registry = ParticleFactoryRegistry.getInstance();
		registry.register(ModParticles.PRISMA_SPARK, PrismaSparkParticle.Factory::new);
		registry.register(ModParticles.PRISMA_SHARD, PrismaShardParticle.Factory::new);
		registry.register(ModParticles.HOLLOW_MOTE, HollowMoteParticle.Factory::new);
	}

	private static void registerKeyBindings() {
		KeyBinding.Category category = KeyBinding.Category.create(id("starwrought"));
		handbookKey = KeyBindingHelper.registerKeyBinding(new KeyBinding(
				"key.starwrought.handbook",
				InputUtil.Type.KEYSYM,
				GLFW.GLFW_KEY_H,
				category
		));
		abilityKey = KeyBindingHelper.registerKeyBinding(new KeyBinding(
				"key.starwrought.ability",
				InputUtil.Type.KEYSYM,
				GLFW.GLFW_KEY_R,
				category
		));
	}

	private static void registerNetworkingReceivers() {
		ClientPlayNetworking.registerGlobalReceiver(ClientboundPayloads.OpenHandbook.TYPE, (payload, context) ->
				context.client().execute(StarwroughtClient::openHandbook));

		ClientPlayNetworking.registerGlobalReceiver(ClientboundPayloads.HandbookSync.TYPE, (payload, context) ->
				context.client().execute(() -> HandbookState.INSTANCE.applyWire(payload.encodedEntries())));

		ClientPlayNetworking.registerGlobalReceiver(ClientboundPayloads.SkyEvent.TYPE, (payload, context) ->
				context.client().execute(() -> AuroraSkyRenderer.setSyncedState(
						payload.auroraActive(),
						payload.remainingTicks()
				)));

		ClientPlayNetworking.registerGlobalReceiver(ClientboundPayloads.AbilityState.TYPE, (payload, context) ->
				context.client().execute(() -> {
					ClientHudState.setAbility(
							payload.attunement(),
							payload.charge(),
							payload.cooldownTicks(),
							payload.maxCooldownTicks()
					);
					if (payload.activated()) {
						SpectacleDirector.abilityUse();
					}
				}));

		ClientPlayNetworking.registerGlobalReceiver(ClientboundPayloads.ImpactFx.TYPE, (payload, context) ->
				context.client().execute(() -> SpectacleDirector.impact(
						new Vec3d(payload.x(), payload.y(), payload.z()),
						payload.intensity()
				)));

		ClientPlayNetworking.registerGlobalReceiver(ModNetworking.UnlockToastS2C.ID, (payload, context) ->
				context.client().execute(() -> {
					HandbookState.INSTANCE.unlock(payload.entryId());
					ClientHudState.flash(0.2F);
					context.client().getSoundManager().play(
							PositionedSoundInstance.master(SoundEvents.BLOCK_AMETHYST_BLOCK_RESONATE, 1.12F)
					);
				}));
	}

	private static void registerHud() {
		HudElementRegistry.attachElementBefore(
				VanillaHudElements.CHAT,
				HUD_ID,
				new StarwroughtHud()
		);
	}

	private static void registerClientEvents() {
		ClientTickEvents.END_CLIENT_TICK.register(client -> {
			while (handbookKey.wasPressed()) {
				if (client.getNetworkHandler() != null
						&& ClientPlayNetworking.canSend(ModNetworking.RequestHandbookC2S.ID)) {
					ClientPlayNetworking.send(new ModNetworking.RequestHandbookC2S());
				} else {
					client.setScreen(new HandbookScreen(HandbookState.INSTANCE));
				}
			}
			while (abilityKey.wasPressed()) {
				if (client.getNetworkHandler() != null
						&& ClientPlayNetworking.canSend(ModNetworking.AbilityC2S.ID)) {
					ClientPlayNetworking.send(new ModNetworking.AbilityC2S(
							ClientHudState.attunement().toLowerCase()
					));
				} else {
					SpectacleDirector.abilityUse();
				}
			}
			TraumaCamera.tick();
			ClientHudState.tick(client);
			RibbonTrailRenderer.tick(client);
			ShockwaveRenderer.tick(client);
			AuroraSkyRenderer.tick(client);
		});

		ClientPlayConnectionEvents.DISCONNECT.register((handler, client) -> {
			TraumaCamera.reset();
			ClientHudState.reset();
			RibbonTrailRenderer.reset();
			ShockwaveRenderer.reset();
			AuroraSkyRenderer.reset();
		});
	}

	private static Identifier id(String path) {
		return Identifier.of("starwrought", path);
	}
}

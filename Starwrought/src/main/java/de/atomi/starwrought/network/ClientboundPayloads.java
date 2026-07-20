package de.atomi.starwrought.network;

import net.fabricmc.fabric.api.networking.v1.PayloadTypeRegistry;
import net.minecraft.network.RegistryByteBuf;
import net.minecraft.network.codec.PacketCodec;
import net.minecraft.network.codec.PacketCodecs;
import net.minecraft.network.packet.CustomPayload;
import net.minecraft.util.Identifier;

/**
 * Small, stable wire contract for optional client presentation state.
 *
 * <p>The handbook remains usable without these packets; servers can send them
 * when their gameplay systems are ready.</p>
 */
public final class ClientboundPayloads {
	private static boolean registered;

	private ClientboundPayloads() {
	}

	public static synchronized void register() {
		if (registered) {
			return;
		}

		PayloadTypeRegistry.playS2C().register(OpenHandbook.TYPE, OpenHandbook.CODEC);
		PayloadTypeRegistry.playS2C().register(HandbookSync.TYPE, HandbookSync.CODEC);
		PayloadTypeRegistry.playS2C().register(SkyEvent.TYPE, SkyEvent.CODEC);
		PayloadTypeRegistry.playS2C().register(AbilityState.TYPE, AbilityState.CODEC);
		PayloadTypeRegistry.playS2C().register(ImpactFx.TYPE, ImpactFx.CODEC);
		registered = true;
	}

	private static Identifier id(String path) {
		return Identifier.of("starwrought", path);
	}

	public record OpenHandbook() implements CustomPayload {
		public static final Id<OpenHandbook> TYPE = new Id<>(id("open_handbook"));
		public static final PacketCodec<RegistryByteBuf, OpenHandbook> CODEC =
				PacketCodec.unit(new OpenHandbook());

		@Override
		public Id<OpenHandbook> getId() {
			return TYPE;
		}
	}

	/**
	 * Newline-separated rows: id|category|title translation key|body translation key|unlocked.
	 */
	public record HandbookSync(String encodedEntries) implements CustomPayload {
		public static final Id<HandbookSync> TYPE = new Id<>(id("handbook_sync"));
		public static final PacketCodec<RegistryByteBuf, HandbookSync> CODEC =
				PacketCodecs.string(262_144).xmap(HandbookSync::new, HandbookSync::encodedEntries).cast();

		@Override
		public Id<HandbookSync> getId() {
			return TYPE;
		}
	}

	public record SkyEvent(boolean auroraActive, int remainingTicks) implements CustomPayload {
		public static final Id<SkyEvent> TYPE = new Id<>(id("sky_event"));
		public static final PacketCodec<RegistryByteBuf, SkyEvent> CODEC = PacketCodec.tuple(
				PacketCodecs.BOOLEAN, SkyEvent::auroraActive,
				PacketCodecs.VAR_INT, SkyEvent::remainingTicks,
				SkyEvent::new
		);

		@Override
		public Id<SkyEvent> getId() {
			return TYPE;
		}
	}

	public record AbilityState(
			String attunement,
			float charge,
			int cooldownTicks,
			int maxCooldownTicks,
			boolean activated
	) implements CustomPayload {
		public static final Id<AbilityState> TYPE = new Id<>(id("ability_state"));
		public static final PacketCodec<RegistryByteBuf, AbilityState> CODEC = PacketCodec.tuple(
				PacketCodecs.string(32), AbilityState::attunement,
				PacketCodecs.FLOAT, AbilityState::charge,
				PacketCodecs.VAR_INT, AbilityState::cooldownTicks,
				PacketCodecs.VAR_INT, AbilityState::maxCooldownTicks,
				PacketCodecs.BOOLEAN, AbilityState::activated,
				AbilityState::new
		);

		@Override
		public Id<AbilityState> getId() {
			return TYPE;
		}
	}

	public record ImpactFx(double x, double y, double z, float intensity) implements CustomPayload {
		public static final Id<ImpactFx> TYPE = new Id<>(id("impact_fx"));
		public static final PacketCodec<RegistryByteBuf, ImpactFx> CODEC = PacketCodec.tuple(
				PacketCodecs.DOUBLE, ImpactFx::x,
				PacketCodecs.DOUBLE, ImpactFx::y,
				PacketCodecs.DOUBLE, ImpactFx::z,
				PacketCodecs.FLOAT, ImpactFx::intensity,
				ImpactFx::new
		);

		@Override
		public Id<ImpactFx> getId() {
			return TYPE;
		}
	}
}

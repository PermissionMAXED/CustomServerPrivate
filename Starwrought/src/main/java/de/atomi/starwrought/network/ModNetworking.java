package de.atomi.starwrought.network;

import de.atomi.starwrought.Starwrought;
import de.atomi.starwrought.attunement.Attunement;
import de.atomi.starwrought.handbook.HandbookLoader;
import de.atomi.starwrought.handbook.UnlockCondition;
import de.atomi.starwrought.player.PlayerAttachments;
import net.fabricmc.fabric.api.networking.v1.PayloadTypeRegistry;
import net.fabricmc.fabric.api.networking.v1.ServerPlayNetworking;
import net.minecraft.entity.effect.StatusEffectInstance;
import net.minecraft.entity.effect.StatusEffects;
import net.minecraft.network.RegistryByteBuf;
import net.minecraft.network.codec.PacketCodec;
import net.minecraft.network.codec.PacketCodecs;
import net.minecraft.network.packet.CustomPayload;
import net.minecraft.registry.Registries;
import net.minecraft.server.network.ServerPlayerEntity;
import net.minecraft.server.world.ServerWorld;
import net.minecraft.text.Text;
import net.minecraft.util.math.Vec3d;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;
import java.util.UUID;

public final class ModNetworking {
    private static final Map<UUID, Long> ABILITY_COOLDOWNS = new HashMap<>();

    private ModNetworking() {
    }

    public static void initialize() {
        ClientboundPayloads.register();
        PayloadTypeRegistry.playC2S().register(AbilityC2S.ID, AbilityC2S.CODEC);
        PayloadTypeRegistry.playS2C().register(UnlockToastS2C.ID, UnlockToastS2C.CODEC);

        ServerPlayNetworking.registerGlobalReceiver(AbilityC2S.ID, (payload, context) ->
                context.server().execute(() -> activateAbility(context.player(), payload.ability())));
    }

    public static void openHandbook(ServerPlayerEntity player) {
        Set<String> unlocks = player.getAttachedOrCreate(PlayerAttachments.HANDBOOK_UNLOCKS);
        Set<String> items = new HashSet<>();
        for (int slot = 0; slot < player.getInventory().size(); slot++) {
            var stack = player.getInventory().getStack(slot);
            if (!stack.isEmpty()) {
                items.add(Registries.ITEM.getId(stack.getItem()).toString());
            }
        }
        var context = new UnlockCondition.UnlockContext(items, Set.of(), unlocks);
        if (ServerPlayNetworking.canSend(player, ClientboundPayloads.HandbookSync.TYPE)) {
            ServerPlayNetworking.send(player,
                    new ClientboundPayloads.HandbookSync(HandbookLoader.encodeFor(context)));
        }
        if (ServerPlayNetworking.canSend(player, ClientboundPayloads.OpenHandbook.TYPE)) {
            ServerPlayNetworking.send(player, new ClientboundPayloads.OpenHandbook());
        }
    }

    public static void unlock(ServerPlayerEntity player, String entryId) {
        Set<String> current = player.getAttachedOrCreate(PlayerAttachments.HANDBOOK_UNLOCKS);
        if (current.contains(entryId)) {
            return;
        }
        var updated = new java.util.HashSet<>(current);
        updated.add(entryId);
        player.setAttached(PlayerAttachments.HANDBOOK_UNLOCKS, updated);
        if (ServerPlayNetworking.canSend(player, UnlockToastS2C.ID)) {
            ServerPlayNetworking.send(player, new UnlockToastS2C(entryId));
        }
    }

    private static void activateAbility(ServerPlayerEntity player, String requestedAbility) {
        var progress = player.getAttachedOrCreate(PlayerAttachments.ATTUNEMENT);
        if (progress.level() < 5) {
            player.sendMessage(Text.translatable("message.starwrought.ability_locked"), true);
            return;
        }
        Attunement requested = switch (requestedAbility.toLowerCase()) {
            case "pack_howl", "wolf" -> Attunement.WOLF;
            case "comet_dash", "lyra" -> Attunement.LYRA;
            default -> Attunement.NONE;
        };
        if (requested == Attunement.NONE || progress.attunement() != requested) {
            return;
        }
        ServerWorld world = (ServerWorld) player.getEntityWorld();
        long now = world.getTime();
        long readyAt = ABILITY_COOLDOWNS.getOrDefault(player.getUuid(), 0L);
        if (now < readyAt) {
            player.sendMessage(Text.translatable("message.starwrought.ability_cooldown",
                    Math.max(1L, (readyAt - now + 19L) / 20L)), true);
            return;
        }

        if (requested == Attunement.WOLF) {
            for (ServerPlayerEntity ally : world.getPlayers(
                    other -> other.squaredDistanceTo(player) <= 144.0)) {
                ally.addStatusEffect(new StatusEffectInstance(StatusEffects.STRENGTH, 240, 1));
                ally.addStatusEffect(new StatusEffectInstance(StatusEffects.SPEED, 240, 1));
            }
            ABILITY_COOLDOWNS.put(player.getUuid(), now + 1_200L);
            sendAbilityState(player, "wolf", 1_200, true);
        } else {
            Vec3d direction = player.getRotationVec(1.0F).normalize();
            boolean moved = false;
            for (double distance = 7.0; distance >= 2.0; distance -= 1.0) {
                Vec3d offset = direction.multiply(distance);
                if (world.isSpaceEmpty(player, player.getBoundingBox().offset(offset))) {
                    moved = player.teleport(world,
                            player.getX() + offset.x, player.getY() + offset.y, player.getZ() + offset.z,
                            java.util.Set.of(), player.getYaw(), player.getPitch(), false);
                    break;
                }
            }
            if (moved) {
                ABILITY_COOLDOWNS.put(player.getUuid(), now + 500L);
                sendAbilityState(player, "lyra", 500, true);
            }
        }
    }

    private static void sendAbilityState(ServerPlayerEntity player, String attunement, int cooldown, boolean activated) {
        if (ServerPlayNetworking.canSend(player, ClientboundPayloads.AbilityState.TYPE)) {
            ServerPlayNetworking.send(player,
                    new ClientboundPayloads.AbilityState(attunement, 1.0F, cooldown, cooldown, activated));
        }
    }

    public record AbilityC2S(String ability) implements CustomPayload {
        public static final Id<AbilityC2S> ID = new Id<>(Starwrought.id("ability"));
        public static final PacketCodec<RegistryByteBuf, AbilityC2S> CODEC =
                PacketCodec.tuple(PacketCodecs.STRING.cast(), AbilityC2S::ability, AbilityC2S::new);

        @Override
        public Id<? extends CustomPayload> getId() {
            return ID;
        }
    }

    public record UnlockToastS2C(String entryId) implements CustomPayload {
        public static final Id<UnlockToastS2C> ID = new Id<>(Starwrought.id("unlock_toast"));
        public static final PacketCodec<RegistryByteBuf, UnlockToastS2C> CODEC =
                PacketCodec.tuple(PacketCodecs.STRING.cast(), UnlockToastS2C::entryId, UnlockToastS2C::new);

        @Override
        public Id<? extends CustomPayload> getId() {
            return ID;
        }
    }

}

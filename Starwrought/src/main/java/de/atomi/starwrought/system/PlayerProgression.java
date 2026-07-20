package de.atomi.starwrought.system;

import de.atomi.starwrought.attunement.Attunement;
import de.atomi.starwrought.content.ModBlocks;
import de.atomi.starwrought.content.ModItems;
import de.atomi.starwrought.network.ModNetworking;
import de.atomi.starwrought.player.PlayerAttachments;
import net.fabricmc.fabric.api.entity.event.v1.ServerEntityCombatEvents;
import net.fabricmc.fabric.api.event.lifecycle.v1.ServerTickEvents;
import net.fabricmc.fabric.api.event.player.PlayerBlockBreakEvents;
import net.minecraft.block.Block;
import net.minecraft.item.ItemStack;
import net.minecraft.server.MinecraftServer;
import net.minecraft.server.network.ServerPlayerEntity;
import net.minecraft.server.world.ServerWorld;
import net.minecraft.text.Text;
import net.minecraft.util.math.Vec3d;

import java.util.HashMap;
import java.util.Map;
import java.util.UUID;

public final class PlayerProgression {
    private static final Map<UUID, Vec3d> LAST_POSITIONS = new HashMap<>();
    private static final Map<UUID, Double> TRAVEL_REMAINDERS = new HashMap<>();

    private PlayerProgression() {
    }

    public static void initialize() {
        ServerTickEvents.END_SERVER_TICK.register(PlayerProgression::tick);
        ServerEntityCombatEvents.AFTER_KILLED_OTHER_ENTITY.register((world, entity, killed, damageSource) -> {
            if (entity instanceof ServerPlayerEntity player && isNight(world)) {
                addProgress(player, Attunement.WOLF, 1);
            }
        });
        PlayerBlockBreakEvents.AFTER.register((world, player, pos, state, blockEntity) -> {
            if (!(player instanceof ServerPlayerEntity serverPlayer) || !state.isOf(ModBlocks.METEORIC_STONE)) {
                return;
            }
            var progress = serverPlayer.getAttachedOrCreate(PlayerAttachments.ATTUNEMENT);
            if (progress.attunement() == Attunement.ANVIL) {
                addProgress(serverPlayer, Attunement.ANVIL, 1);
                if (world.getRandom().nextInt(7 - progress.level()) == 0) {
                    Block.dropStack(world, pos, new ItemStack(ModItems.STAR_SHARD));
                }
            }
        });
    }

    public static void recordCraftedOrSmelted(ServerPlayerEntity player, int amount) {
        addProgress(player, Attunement.ANVIL, Math.max(1, amount));
    }

    public static void addProgress(ServerPlayerEntity player, Attunement required, int amount) {
        var current = player.getAttachedOrCreate(PlayerAttachments.ATTUNEMENT);
        if (current.attunement() != required || amount <= 0) {
            return;
        }
        int previousLevel = current.level();
        var updated = current.addProgress(amount);
        player.setAttached(PlayerAttachments.ATTUNEMENT, updated);
        if (updated.level() > previousLevel) {
            player.sendMessage(Text.translatable("message.starwrought.attunement_level",
                    updated.level()), false);
        }
    }

    private static void tick(MinecraftServer server) {
        if (server.getTicks() % 20 != 0) {
            return;
        }
        for (ServerPlayerEntity player : server.getPlayerManager().getPlayerList()) {
            grantStarterCodex(player);
            trackLyraTravel(player);
        }
    }

    private static void grantStarterCodex(ServerPlayerEntity player) {
        if (!player.getInventory().contains(stack -> stack.isOf(ModItems.STAR_SHARD))) {
            return;
        }
        var unlocks = player.getAttachedOrCreate(PlayerAttachments.HANDBOOK_UNLOCKS);
        if (unlocks.contains("starwrought:getting_started")) {
            return;
        }
        if (!player.getInventory().contains(stack -> stack.isOf(ModItems.CODEX_ARCANA))) {
            player.getInventory().offerOrDrop(new ItemStack(ModItems.CODEX_ARCANA));
        }
        ModNetworking.unlock(player, "starwrought:getting_started");
        ModNetworking.unlock(player, "starwrought:sky_events");
        ModNetworking.unlock(player, "starwrought:star_shards");
        player.sendMessage(Text.translatable("message.starwrought.codex_granted"), false);
    }

    private static void trackLyraTravel(ServerPlayerEntity player) {
        Vec3d current = player.getEntityPos();
        Vec3d previous = LAST_POSITIONS.put(player.getUuid(), current);
        if (previous == null || player.getAttachedOrCreate(PlayerAttachments.ATTUNEMENT).attunement() != Attunement.LYRA) {
            return;
        }
        double distance = Math.min(32.0, current.distanceTo(previous));
        double accumulated = TRAVEL_REMAINDERS.getOrDefault(player.getUuid(), 0.0) + distance;
        int points = (int) (accumulated / 24.0);
        TRAVEL_REMAINDERS.put(player.getUuid(), accumulated - points * 24.0);
        if (points > 0) {
            addProgress(player, Attunement.LYRA, points);
        }
    }

    private static boolean isNight(ServerWorld world) {
        long time = Math.floorMod(world.getTimeOfDay(), 24_000L);
        return time >= 13_000L && time <= 23_000L;
    }
}

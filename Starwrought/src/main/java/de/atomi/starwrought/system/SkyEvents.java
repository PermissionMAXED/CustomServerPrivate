package de.atomi.starwrought.system;

import com.mojang.serialization.Codec;
import com.mojang.serialization.codecs.RecordCodecBuilder;
import de.atomi.starwrought.Starwrought;
import de.atomi.starwrought.content.ModBlocks;
import de.atomi.starwrought.entity.ModEntities;
import de.atomi.starwrought.logic.SkyEventSchedule;
import de.atomi.starwrought.network.ModNetworking;
import net.fabricmc.fabric.api.event.lifecycle.v1.ServerTickEvents;
import net.minecraft.block.BlockState;
import net.minecraft.block.Blocks;
import net.minecraft.datafixer.DataFixTypes;
import net.minecraft.entity.SpawnReason;
import net.minecraft.server.network.ServerPlayerEntity;
import net.minecraft.server.world.ServerWorld;
import net.minecraft.text.Text;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.math.random.Random;
import net.minecraft.world.Heightmap;
import net.minecraft.world.PersistentState;
import net.minecraft.world.PersistentStateType;
import net.minecraft.world.World;

public final class SkyEvents {
    private static final PersistentStateType<State> TYPE = new PersistentStateType<>(
            Starwrought.MOD_ID + "_sky_events", State::new, State.CODEC, DataFixTypes.LEVEL);

    private SkyEvents() {
    }

    public static void initialize() {
        ServerTickEvents.END_WORLD_TICK.register(SkyEvents::tick);
    }

    public static boolean isAurora(World world) {
        return world instanceof ServerWorld serverWorld
                && serverWorld.getRegistryKey() == World.OVERWORLD
                && get(serverWorld).activeEvent == SkyEventSchedule.Event.AURORA
                && isNight(serverWorld);
    }

    public static String forecastKey(ServerWorld world) {
        if (world.getRegistryKey() != World.OVERWORLD) {
            return "message.starwrought.forecast_distant";
        }
        State state = get(world);
        if (state.activeEvent == SkyEventSchedule.Event.AURORA && isNight(world)) {
            return "message.starwrought.forecast_aurora_now";
        }
        if (state.activeEvent == SkyEventSchedule.Event.UMBRAL && isNight(world)) {
            return "message.starwrought.forecast_umbral_now";
        }
        long night = Math.floorDiv(world.getTimeOfDay(), 24_000L);
        return state.nextAurora - night <= state.nextUmbral - night
                ? "message.starwrought.forecast_aurora"
                : "message.starwrought.forecast_umbral";
    }

    private static void tick(ServerWorld world) {
        if (world.getRegistryKey() != World.OVERWORLD) {
            return;
        }
        long dayTime = Math.floorMod(world.getTimeOfDay(), 24_000L);
        long night = Math.floorDiv(world.getTimeOfDay(), 24_000L);
        State state = get(world);

        if (dayTime >= 13_000L && dayTime < 13_020L && state.lastProcessedNight != night) {
            state.lastProcessedNight = night;
            state.activeEvent = SkyEventSchedule.eventForNight(night, state.nextAurora, state.nextUmbral);
            if (state.activeEvent == SkyEventSchedule.Event.AURORA) {
                state.nextAurora = SkyEventSchedule.avoidCollision(
                        SkyEventSchedule.nextAurora(night, world.getSeed()), state.nextUmbral);
                startAurora(world);
            } else if (state.activeEvent == SkyEventSchedule.Event.UMBRAL) {
                state.nextUmbral = SkyEventSchedule.avoidCollision(
                        SkyEventSchedule.nextUmbral(night, world.getSeed()), state.nextAurora);
                world.getServer().getPlayerManager().broadcast(
                        Text.translatable("message.starwrought.umbral_begins"), false);
                for (ServerPlayerEntity player : world.getPlayers()) {
                    ModNetworking.unlock(player, "starwrought:umbral_night");
                }
            }
            state.markDirty();
        }

        if (dayTime < 1_000L && state.activeEvent != SkyEventSchedule.Event.NONE) {
            state.activeEvent = SkyEventSchedule.Event.NONE;
            state.markDirty();
        }

        if (state.activeEvent == SkyEventSchedule.Event.UMBRAL && dayTime >= 13_000L
                && world.getTime() % 200L == 0L) {
            spawnUmbralStalkers(world);
        }
    }

    private static void startAurora(ServerWorld world) {
        world.getServer().getPlayerManager().broadcast(
                Text.translatable("message.starwrought.aurora_begins"), false);
        Random random = world.getRandom();
        for (ServerPlayerEntity player : world.getPlayers()) {
            int clusters = 2 + random.nextInt(4);
            for (int i = 0; i < clusters; i++) {
                int x = player.getBlockX() + random.nextBetween(-48, 48);
                int z = player.getBlockZ() + random.nextBetween(-48, 48);
                BlockPos surface = world.getTopPosition(Heightmap.Type.WORLD_SURFACE, new BlockPos(x, 0, z)).down();
                placeMeteorite(world, surface, random);
            }
        }
    }

    private static void placeMeteorite(ServerWorld world, BlockPos center, Random random) {
        if (!replaceable(world.getBlockState(center))) {
            return;
        }
        for (BlockPos pos : BlockPos.iterate(center.add(-2, -1, -2), center.add(2, 1, 2))) {
            double distance = pos.getSquaredDistance(center);
            if (distance <= 4.5 && replaceable(world.getBlockState(pos)) && random.nextFloat() > 0.18F) {
                world.setBlockState(pos, ModBlocks.METEORIC_STONE.getDefaultState(), 3);
            }
        }
        world.setBlockState(center, ModBlocks.METEORITE_CORE.getDefaultState(), 3);
    }

    private static boolean replaceable(BlockState state) {
        return state.isOf(Blocks.STONE) || state.isOf(Blocks.DIRT) || state.isOf(Blocks.GRASS_BLOCK)
                || state.isOf(Blocks.DEEPSLATE);
    }

    private static void spawnUmbralStalkers(ServerWorld world) {
        Random random = world.getRandom();
        for (ServerPlayerEntity player : world.getPlayers()) {
            if (random.nextInt(5) != 0) {
                continue;
            }
            int x = player.getBlockX() + random.nextBetween(-24, 24);
            int z = player.getBlockZ() + random.nextBetween(-24, 24);
            BlockPos pos = world.getTopPosition(Heightmap.Type.MOTION_BLOCKING_NO_LEAVES, new BlockPos(x, 0, z));
            ModEntities.HOLLOW_STALKER.spawn(world, pos, SpawnReason.EVENT);
        }
    }

    private static boolean isNight(ServerWorld world) {
        long time = Math.floorMod(world.getTimeOfDay(), 24_000L);
        return time >= 13_000L && time <= 23_000L;
    }

    private static State get(ServerWorld world) {
        return world.getPersistentStateManager().getOrCreate(TYPE);
    }

    public static final class State extends PersistentState {
        private static final Codec<State> CODEC = RecordCodecBuilder.create(instance -> instance.group(
                Codec.LONG.optionalFieldOf("next_aurora", 4L).forGetter(state -> state.nextAurora),
                Codec.LONG.optionalFieldOf("next_umbral", 12L).forGetter(state -> state.nextUmbral),
                Codec.LONG.optionalFieldOf("last_night", -1L).forGetter(state -> state.lastProcessedNight),
                Codec.STRING.optionalFieldOf("active", "NONE")
                        .xmap(value -> {
                            try {
                                return SkyEventSchedule.Event.valueOf(value);
                            } catch (IllegalArgumentException ignored) {
                                return SkyEventSchedule.Event.NONE;
                            }
                        }, Enum::name)
                        .forGetter(state -> state.activeEvent)
        ).apply(instance, State::new));

        private long nextAurora;
        private long nextUmbral;
        private long lastProcessedNight;
        private SkyEventSchedule.Event activeEvent;

        public State() {
            this(4L, 12L, -1L, SkyEventSchedule.Event.NONE);
        }

        private State(long nextAurora, long nextUmbral, long lastProcessedNight,
                      SkyEventSchedule.Event activeEvent) {
            this.nextAurora = nextAurora;
            this.nextUmbral = nextUmbral;
            this.lastProcessedNight = lastProcessedNight;
            this.activeEvent = activeEvent;
        }
    }
}

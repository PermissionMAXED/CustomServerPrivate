package de.atomi.starwrought.entity;

import de.atomi.starwrought.content.ModItems;
import de.atomi.starwrought.network.ClientboundPayloads;
import de.atomi.starwrought.registry.ModParticles;
import net.fabricmc.fabric.api.networking.v1.PlayerLookup;
import net.fabricmc.fabric.api.networking.v1.ServerPlayNetworking;
import net.minecraft.entity.EntityType;
import net.minecraft.entity.LivingEntity;
import net.minecraft.entity.SpawnReason;
import net.minecraft.entity.boss.BossBar;
import net.minecraft.entity.boss.ServerBossBar;
import net.minecraft.entity.damage.DamageSource;
import net.minecraft.entity.mob.ZombieEntity;
import net.minecraft.item.ItemStack;
import net.minecraft.particle.ParticleTypes;
import net.minecraft.server.network.ServerPlayerEntity;
import net.minecraft.server.world.ServerWorld;
import net.minecraft.text.Text;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.math.Vec3d;
import net.minecraft.world.World;

public final class HeraldEntity extends ZombieEntity {
    private final ServerBossBar bossBar = new ServerBossBar(
            Text.translatable("entity.starwrought.herald"),
            BossBar.Color.PURPLE,
            BossBar.Style.NOTCHED_10);
    private int phase = 1;

    public HeraldEntity(EntityType<? extends ZombieEntity> type, World world) {
        super(type, world);
        bossBar.setDarkenSky(true);
        setPersistent();
    }

    @Override
    protected boolean burnsInDaylight() {
        return false;
    }

    @Override
    public void tick() {
        super.tick();
        if (!(getEntityWorld() instanceof ServerWorld world)) {
            return;
        }
        float ratio = Math.clamp(getHealth() / getMaxHealth(), 0.0F, 1.0F);
        bossBar.setPercent(ratio);
        int nextPhase = ratio <= 0.33F ? 3 : ratio <= 0.66F ? 2 : 1;
        if (nextPhase != phase) {
            phase = nextPhase;
            bossBar.setColor(phase == 3 ? BossBar.Color.RED : BossBar.Color.PURPLE);
            world.getServer().getPlayerManager().broadcast(
                    Text.translatable("message.starwrought.herald_phase", phase), false);
            blastImpact(world, 1.4F + phase * 0.35F);
        }

        // Orbiting prism shards — constant spectacle around the Herald.
        if (age % 4 == 0) {
            double angle = (age % 360) * Math.PI / 180.0;
            for (int i = 0; i < 3; i++) {
                double a = angle + i * (Math.PI * 2.0 / 3.0);
                double px = getX() + Math.cos(a) * (1.6 + phase * 0.35);
                double pz = getZ() + Math.sin(a) * (1.6 + phase * 0.35);
                world.spawnParticles(ModParticles.PRISMA_SHARD, px, getBodyY(0.55), pz,
                        1, 0.02, 0.08, 0.02, 0.0);
            }
        }

        if (phase >= 2 && age % 80 == 0) {
            LivingEntity target = getTarget();
            if (target != null && squaredDistanceTo(target) > 25.0) {
                requestTeleport(target.getX() + getRandom().nextBetween(-2, 2), target.getY(),
                        target.getZ() + getRandom().nextBetween(-2, 2));
                world.spawnParticles(ParticleTypes.PORTAL, getX(), getBodyY(0.5), getZ(),
                        32, 0.8, 1.2, 0.8, 0.1);
                world.spawnParticles(ModParticles.HOLLOW_MOTE, getX(), getBodyY(0.5), getZ(),
                        24, 0.6, 1.0, 0.6, 0.02);
                blastImpact(world, 0.9F);
            }
        }

        // Phase 2+: shard barrage telegraph toward the current target.
        if (phase >= 2 && age % 45 == 0) {
            LivingEntity target = getTarget();
            if (target != null) {
                Vec3d from = getEntityPos().add(0, 1.4, 0);
                Vec3d to = target.getEntityPos().add(0, 1.0, 0);
                Vec3d step = to.subtract(from).multiply(0.1);
                for (int i = 0; i < 10; i++) {
                    Vec3d p = from.add(step.multiply(i));
                    world.spawnParticles(ModParticles.PRISMA_SPARK, p.x, p.y, p.z,
                            2, 0.05, 0.05, 0.05, 0.01);
                }
            }
        }

        if (phase == 3 && age % 200 == 0) {
            BlockPos spawnPos = getBlockPos().add(getRandom().nextBetween(-3, 3), 0,
                    getRandom().nextBetween(-3, 3));
            ModEntities.HOLLOW_STALKER.spawn(world, spawnPos, SpawnReason.REINFORCEMENT);
            blastImpact(world, 1.8F);
        }
    }

    private void blastImpact(ServerWorld world, float intensity) {
        world.spawnParticles(ModParticles.PRISMA_SPARK, getX(), getY() + 0.1, getZ(),
                48, 1.4, 0.2, 1.4, 0.08);
        for (ServerPlayerEntity player : PlayerLookup.tracking(this)) {
            if (ServerPlayNetworking.canSend(player, ClientboundPayloads.ImpactFx.TYPE)) {
                ServerPlayNetworking.send(player,
                        new ClientboundPayloads.ImpactFx(getX(), getY(), getZ(), intensity));
            }
        }
    }

    @Override
    public void onStartedTrackingBy(ServerPlayerEntity player) {
        super.onStartedTrackingBy(player);
        bossBar.addPlayer(player);
    }

    @Override
    public void onStoppedTrackingBy(ServerPlayerEntity player) {
        super.onStoppedTrackingBy(player);
        bossBar.removePlayer(player);
    }

    @Override
    public void onDeath(DamageSource damageSource) {
        if (getEntityWorld() instanceof ServerWorld world) {
            dropStack(world, new ItemStack(ModItems.ZENITH_CORE));
            blastImpact(world, 2.4F);
            world.spawnParticles(ModParticles.PRISMA_SHARD, getX(), getBodyY(0.5), getZ(),
                    80, 1.2, 1.5, 1.2, 0.12);
        }
        bossBar.clearPlayers();
        super.onDeath(damageSource);
    }
}

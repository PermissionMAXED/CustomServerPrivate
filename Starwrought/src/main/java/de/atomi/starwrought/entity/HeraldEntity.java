package de.atomi.starwrought.entity;

import de.atomi.starwrought.content.ModItems;
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
        }

        if (phase >= 2 && age % 80 == 0) {
            LivingEntity target = getTarget();
            if (target != null && squaredDistanceTo(target) > 25.0) {
                requestTeleport(target.getX() + getRandom().nextBetween(-2, 2), target.getY(),
                        target.getZ() + getRandom().nextBetween(-2, 2));
                world.spawnParticles(ParticleTypes.PORTAL, getX(), getBodyY(0.5), getZ(),
                        32, 0.8, 1.2, 0.8, 0.1);
            }
        }
        if (phase == 3 && age % 200 == 0) {
            BlockPos spawnPos = getBlockPos().add(getRandom().nextBetween(-3, 3), 0,
                    getRandom().nextBetween(-3, 3));
            ModEntities.HOLLOW_STALKER.spawn(world, spawnPos, SpawnReason.REINFORCEMENT);
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
        }
        bossBar.clearPlayers();
        super.onDeath(damageSource);
    }
}

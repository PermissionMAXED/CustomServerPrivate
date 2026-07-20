package de.atomi.starwrought.entity;

import net.minecraft.entity.EntityType;
import net.minecraft.entity.LivingEntity;
import net.minecraft.entity.mob.ZombieEntity;
import net.minecraft.server.world.ServerWorld;
import net.minecraft.world.World;

public class HollowStalkerEntity extends ZombieEntity {
    private int teleportCooldown = 80;

    public HollowStalkerEntity(EntityType<? extends ZombieEntity> type, World world) {
        super(type, world);
    }

    @Override
    protected boolean burnsInDaylight() {
        return false;
    }

    @Override
    public void tick() {
        super.tick();
        if (!(getEntityWorld() instanceof ServerWorld) || --teleportCooldown > 0) {
            return;
        }
        teleportCooldown = 80 + getRandom().nextInt(80);
        LivingEntity target = getTarget();
        if (target == null || squaredDistanceTo(target) < 16.0 || squaredDistanceTo(target) > 196.0) {
            return;
        }
        double angle = getRandom().nextDouble() * Math.PI * 2.0;
        requestTeleport(target.getX() + Math.cos(angle) * 3.0, target.getY(),
                target.getZ() + Math.sin(angle) * 3.0);
    }
}

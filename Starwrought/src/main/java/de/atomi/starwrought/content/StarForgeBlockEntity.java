package de.atomi.starwrought.content;

import de.atomi.starwrought.attunement.Attunement;
import de.atomi.starwrought.player.PlayerAttachments;
import de.atomi.starwrought.system.SkyEvents;
import net.minecraft.block.BlockState;
import net.minecraft.block.entity.BlockEntity;
import net.minecraft.entity.player.PlayerEntity;
import net.minecraft.inventory.Inventories;
import net.minecraft.inventory.Inventory;
import net.minecraft.item.ItemStack;
import net.minecraft.item.Items;
import net.minecraft.storage.ReadView;
import net.minecraft.storage.WriteView;
import net.minecraft.util.collection.DefaultedList;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.math.Box;
import net.minecraft.world.World;

public final class StarForgeBlockEntity extends BlockEntity implements Inventory {
    private final DefaultedList<ItemStack> stacks = DefaultedList.ofSize(3, ItemStack.EMPTY);
    private int progress;

    public StarForgeBlockEntity(BlockPos pos, BlockState state) {
        super(ModBlockEntities.STAR_FORGE, pos, state);
    }

    public static void tick(World world, BlockPos pos, BlockState state, StarForgeBlockEntity forge) {
        if (world.isClient() || !forge.canSmelt()) {
            if (forge.progress != 0) {
                forge.progress = 0;
                forge.markDirty();
            }
            return;
        }

        int speed = SkyEvents.isAurora(world) ? 2 : 1;
        for (PlayerEntity player : world.getEntitiesByClass(PlayerEntity.class, new Box(pos).expand(8), p -> true)) {
            var attunement = player.getAttachedOrCreate(PlayerAttachments.ATTUNEMENT);
            if (attunement.attunement() == Attunement.ANVIL) {
                speed = Math.max(speed, 1 + attunement.level() / 2);
            }
        }

        forge.progress += speed;
        if (forge.progress >= 160) {
            forge.getStack(0).decrement(1);
            forge.getStack(1).decrement(1);
            ItemStack output = forge.getStack(2);
            if (output.isEmpty()) {
                forge.setStack(2, new ItemStack(ModItems.STARSTEEL_INGOT));
            } else {
                output.increment(1);
            }
            forge.progress = 0;
            forge.markDirty();
            world.updateListeners(pos, state, state, 3);
        }
    }

    private boolean canSmelt() {
        return getStack(0).isOf(ModItems.STAR_SHARD)
                && getStack(1).isOf(Items.IRON_INGOT)
                && (getStack(2).isEmpty()
                || getStack(2).isOf(ModItems.STARSTEEL_INGOT) && getStack(2).getCount() < getMaxCountPerStack());
    }

    public boolean insert(int slot, ItemStack stack) {
        if (stack.isEmpty() || slot < 0 || slot > 1) {
            return false;
        }
        ItemStack existing = getStack(slot);
        if (existing.isEmpty()) {
            setStack(slot, stack);
            return true;
        }
        if (ItemStack.areItemsAndComponentsEqual(existing, stack) && existing.getCount() < getMaxCountPerStack()) {
            existing.increment(stack.getCount());
            return true;
        }
        return false;
    }

    @Override
    protected void readData(ReadView view) {
        super.readData(view);
        Inventories.readData(view, stacks);
        progress = view.getInt("progress", 0);
    }

    @Override
    protected void writeData(WriteView view) {
        super.writeData(view);
        Inventories.writeData(view, stacks);
        view.putInt("progress", progress);
    }

    @Override
    public int size() {
        return stacks.size();
    }

    @Override
    public boolean isEmpty() {
        return stacks.stream().allMatch(ItemStack::isEmpty);
    }

    @Override
    public ItemStack getStack(int slot) {
        return stacks.get(slot);
    }

    @Override
    public ItemStack removeStack(int slot, int amount) {
        ItemStack result = Inventories.splitStack(stacks, slot, amount);
        if (!result.isEmpty()) {
            markDirty();
        }
        return result;
    }

    @Override
    public ItemStack removeStack(int slot) {
        ItemStack result = Inventories.removeStack(stacks, slot);
        markDirty();
        return result;
    }

    @Override
    public void setStack(int slot, ItemStack stack) {
        stacks.set(slot, stack);
        stack.capCount(getMaxCountPerStack());
        markDirty();
    }

    @Override
    public boolean canPlayerUse(PlayerEntity player) {
        return world != null && world.getBlockEntity(pos) == this
                && player.squaredDistanceTo(pos.toCenterPos()) <= 64.0;
    }

    @Override
    public void clear() {
        stacks.clear();
        markDirty();
    }
}

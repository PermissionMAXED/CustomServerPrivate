package de.atomi.starwrought.content;

import com.mojang.serialization.MapCodec;
import de.atomi.starwrought.Starwrought;
import de.atomi.starwrought.attunement.Attunement;
import de.atomi.starwrought.attunement.AttunementProgress;
import de.atomi.starwrought.entity.ModEntities;
import de.atomi.starwrought.player.PlayerAttachments;
import de.atomi.starwrought.system.PlayerProgression;
import net.minecraft.block.AbstractBlock;
import net.minecraft.block.Block;
import net.minecraft.block.BlockState;
import net.minecraft.block.BlockWithEntity;
import net.minecraft.block.Blocks;
import net.minecraft.block.entity.BlockEntity;
import net.minecraft.block.entity.BlockEntityTicker;
import net.minecraft.block.entity.BlockEntityType;
import net.minecraft.entity.SpawnReason;
import net.minecraft.entity.player.PlayerEntity;
import net.minecraft.inventory.Inventory;
import net.minecraft.item.BlockItem;
import net.minecraft.item.Item;
import net.minecraft.item.ItemStack;
import net.minecraft.registry.Registries;
import net.minecraft.registry.Registry;
import net.minecraft.registry.RegistryKey;
import net.minecraft.registry.RegistryKeys;
import net.minecraft.server.network.ServerPlayerEntity;
import net.minecraft.server.world.ServerWorld;
import net.minecraft.sound.BlockSoundGroup;
import net.minecraft.state.StateManager;
import net.minecraft.state.property.IntProperty;
import net.minecraft.state.property.Properties;
import net.minecraft.text.Text;
import net.minecraft.util.ActionResult;
import net.minecraft.util.Hand;
import net.minecraft.util.Identifier;
import net.minecraft.util.ItemScatterer;
import net.minecraft.util.hit.BlockHitResult;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.math.random.Random;
import net.minecraft.world.World;

import java.util.ArrayList;
import java.util.List;
import java.util.function.Function;

public final class ModBlocks {
    private static final List<Item> BLOCK_ITEMS = new ArrayList<>();

    public static final Block METEORIC_STONE = register("meteoric_stone", Block::new,
            AbstractBlock.Settings.copy(Blocks.DEEPSLATE).strength(4.0F, 8.0F).requiresTool());
    public static final Block METEORITE_CORE = register("meteorite_core", Block::new,
            AbstractBlock.Settings.copy(Blocks.OBSIDIAN).strength(10.0F, 30.0F)
                    .requiresTool().luminance(state -> 10));
    public static final Block RESONANCE_ALTAR = register("resonance_altar", ResonanceAltarBlock::new,
            AbstractBlock.Settings.copy(Blocks.ENCHANTING_TABLE).strength(5.0F, 12.0F).luminance(state -> 5));
    public static final Block STAR_FORGE = register("star_forge", StarForgeBlock::new,
            AbstractBlock.Settings.copy(Blocks.BLAST_FURNACE).strength(4.5F).requiresTool().luminance(state -> 4));
    public static final Block LUMEN_LANTERN = register("lumen_lantern", Block::new,
            AbstractBlock.Settings.copy(Blocks.SEA_LANTERN).strength(1.0F).luminance(state -> 15));
    public static final Block LUMEN_SPIRE = register("lumen_spire", LumenSpireBlock::new,
            AbstractBlock.Settings.copy(Blocks.SEA_LANTERN).strength(3.0F).luminance(state -> 15));
    public static final Block VOIDGLASS = register("voidglass", Block::new,
            AbstractBlock.Settings.copy(Blocks.TINTED_GLASS).strength(2.0F, 9.0F).nonOpaque());
    public static final Block HOLLOW_BEACON = register("hollow_beacon", HollowBeaconBlock::new,
            AbstractBlock.Settings.copy(Blocks.CRYING_OBSIDIAN).strength(8.0F, 25.0F).luminance(state -> 7));
    public static final Block ASTRAL_BLOOM = register("astral_bloom", AstralBloomBlock::new,
            AbstractBlock.Settings.create().mapColor(net.minecraft.block.MapColor.PURPLE)
                    .noCollision().nonOpaque().breakInstantly().sounds(BlockSoundGroup.GRASS).ticksRandomly());

    private ModBlocks() {
    }

    private static <T extends Block> T register(String name, Function<AbstractBlock.Settings, T> factory,
                                                AbstractBlock.Settings settings) {
        Identifier id = Starwrought.id(name);
        RegistryKey<Block> blockKey = RegistryKey.of(RegistryKeys.BLOCK, id);
        T block = factory.apply(settings.registryKey(blockKey));
        Registry.register(Registries.BLOCK, blockKey, block);

        RegistryKey<Item> itemKey = RegistryKey.of(RegistryKeys.ITEM, id);
        BlockItem blockItem = new BlockItem(block,
                new Item.Settings().registryKey(itemKey).useBlockPrefixedTranslationKey());
        Registry.register(Registries.ITEM, itemKey, blockItem);
        BLOCK_ITEMS.add(blockItem);
        return block;
    }

    public static List<Item> blockItems() {
        return List.copyOf(BLOCK_ITEMS);
    }

    public static void initialize() {
        // Static initialization performs registration.
    }

    public static final class ResonanceAltarBlock extends Block {
        public static final MapCodec<ResonanceAltarBlock> CODEC = createCodec(ResonanceAltarBlock::new);

        public ResonanceAltarBlock(Settings settings) {
            super(settings);
        }

        @Override
        protected MapCodec<? extends Block> getCodec() {
            return CODEC;
        }

        @Override
        protected ActionResult onUseWithItem(ItemStack stack, BlockState state, World world, BlockPos pos,
                                             PlayerEntity player, Hand hand, BlockHitResult hit) {
            Attunement constellation = stack.isOf(ModItems.CHART_WOLF) ? Attunement.WOLF
                    : stack.isOf(ModItems.CHART_LYRA) ? Attunement.LYRA
                    : stack.isOf(ModItems.CHART_ANVIL) ? Attunement.ANVIL : Attunement.NONE;
            if (constellation == Attunement.NONE) {
                return ActionResult.PASS_TO_DEFAULT_BLOCK_ACTION;
            }
            if (!world.isClient()) {
                player.setAttached(PlayerAttachments.ATTUNEMENT, new AttunementProgress(constellation, 0));
                stack.decrementUnlessCreative(1, player);
                player.sendMessage(Text.translatable("message.starwrought.attuned",
                        Text.translatable("constellation.starwrought." + constellation.name().toLowerCase())), false);
            }
            return ActionResult.SUCCESS;
        }
    }

    public static final class LumenSpireBlock extends Block {
        public static final MapCodec<LumenSpireBlock> CODEC = createCodec(LumenSpireBlock::new);

        public LumenSpireBlock(Settings settings) {
            super(settings);
        }

        @Override
        protected MapCodec<? extends Block> getCodec() {
            return CODEC;
        }

        @Override
        protected ActionResult onUseWithItem(ItemStack stack, BlockState state, World world, BlockPos pos,
                                             PlayerEntity player, Hand hand, BlockHitResult hit) {
            if (!stack.isOf(ModItems.WAYBAND)) {
                return ActionResult.PASS_TO_DEFAULT_BLOCK_ACTION;
            }
            if (!world.isClient()) {
                player.setAttached(PlayerAttachments.WAYBAND_TARGET, new PlayerAttachments.BoundPosition(
                        world.getRegistryKey().getValue().toString(), pos.getX(), pos.getY(), pos.getZ()));
                player.sendMessage(Text.translatable("message.starwrought.wayband_bound"), true);
            }
            return ActionResult.SUCCESS;
        }
    }

    public static final class HollowBeaconBlock extends Block {
        public static final MapCodec<HollowBeaconBlock> CODEC = createCodec(HollowBeaconBlock::new);

        public HollowBeaconBlock(Settings settings) {
            super(settings);
        }

        @Override
        protected MapCodec<? extends Block> getCodec() {
            return CODEC;
        }

        @Override
        protected ActionResult onUseWithItem(ItemStack stack, BlockState state, World world, BlockPos pos,
                                             PlayerEntity player, Hand hand, BlockHitResult hit) {
            if (!stack.isOf(ModItems.HOLLOW_RESIDUE) || stack.getCount() < 4
                    || !player.getInventory().contains(item -> item.isOf(VOIDGLASS.asItem()))) {
                return ActionResult.PASS_TO_DEFAULT_BLOCK_ACTION;
            }
            if (world instanceof ServerWorld serverWorld) {
                stack.decrementUnlessCreative(4, player);
                if (!player.getAbilities().creativeMode) {
                    for (int slot = 0; slot < player.getInventory().size(); slot++) {
                        ItemStack candidate = player.getInventory().getStack(slot);
                        if (candidate.isOf(VOIDGLASS.asItem())) {
                            candidate.decrement(1);
                            break;
                        }
                    }
                }
                ModEntities.HERALD.spawn(serverWorld, pos.up(), SpawnReason.TRIGGERED);
                serverWorld.getServer().getPlayerManager().broadcast(
                        Text.translatable("message.starwrought.herald_summoned"), false);
            }
            return ActionResult.SUCCESS;
        }
    }

    public static final class AstralBloomBlock extends Block {
        public static final MapCodec<AstralBloomBlock> CODEC = createCodec(AstralBloomBlock::new);
        public static final IntProperty AGE = Properties.AGE_3;

        public AstralBloomBlock(Settings settings) {
            super(settings);
            setDefaultState(getStateManager().getDefaultState().with(AGE, 0));
        }

        @Override
        protected MapCodec<? extends Block> getCodec() {
            return CODEC;
        }

        @Override
        protected void appendProperties(StateManager.Builder<Block, BlockState> builder) {
            builder.add(AGE);
        }

        @Override
        protected void randomTick(BlockState state, ServerWorld world, BlockPos pos, Random random) {
            long time = Math.floorMod(world.getTimeOfDay(), 24_000L);
            int age = state.get(AGE);
            if (time >= 13_000L && time <= 23_000L && age < 3 && random.nextInt(3) == 0) {
                world.setBlockState(pos, state.with(AGE, age + 1), Block.NOTIFY_LISTENERS);
            }
        }

        @Override
        public void afterBreak(World world, PlayerEntity player, BlockPos pos, BlockState state,
                               BlockEntity blockEntity, ItemStack tool) {
            super.afterBreak(world, player, pos, state, blockEntity, tool);
            if (!world.isClient() && state.get(AGE) == 3) {
                Block.dropStack(world, pos, new ItemStack(ModItems.GLIMMER_PETAL, 1 + world.getRandom().nextInt(2)));
            }
        }
    }

    public static final class StarForgeBlock extends BlockWithEntity {
        public static final MapCodec<StarForgeBlock> CODEC = createCodec(StarForgeBlock::new);

        public StarForgeBlock(Settings settings) {
            super(settings);
        }

        @Override
        protected MapCodec<? extends BlockWithEntity> getCodec() {
            return CODEC;
        }

        @Override
        public BlockEntity createBlockEntity(BlockPos pos, BlockState state) {
            return new StarForgeBlockEntity(pos, state);
        }

        @Override
        public <T extends BlockEntity> BlockEntityTicker<T> getTicker(World world, BlockState state,
                                                                      BlockEntityType<T> type) {
            if (type != ModBlockEntities.STAR_FORGE) {
                return null;
            }
            return (tickWorld, pos, tickState, blockEntity) ->
                    StarForgeBlockEntity.tick(tickWorld, pos, tickState, (StarForgeBlockEntity) blockEntity);
        }

        @Override
        protected ActionResult onUseWithItem(ItemStack stack, BlockState state, World world, BlockPos pos,
                                             PlayerEntity player, Hand hand, BlockHitResult hit) {
            if (!(world.getBlockEntity(pos) instanceof StarForgeBlockEntity forge)) {
                return ActionResult.PASS;
            }
            if (stack.isOf(ModItems.STAR_SHARD) || stack.isOf(net.minecraft.item.Items.IRON_INGOT)) {
                if (!world.isClient()) {
                    ItemStack single = stack.copyWithCount(1);
                    if (forge.insert(stack.isOf(ModItems.STAR_SHARD) ? 0 : 1, single)) {
                        stack.decrementUnlessCreative(1, player);
                        forge.markDirty();
                    }
                }
                return ActionResult.SUCCESS;
            }
            if (stack.isEmpty() && !forge.getStack(2).isEmpty()) {
                if (!world.isClient()) {
                    ItemStack output = forge.removeStack(2);
                    player.giveItemStack(output);
                    if (player instanceof ServerPlayerEntity serverPlayer) {
                        PlayerProgression.recordCraftedOrSmelted(serverPlayer, output.getCount());
                    }
                    forge.markDirty();
                }
                return ActionResult.SUCCESS;
            }
            return ActionResult.PASS_TO_DEFAULT_BLOCK_ACTION;
        }

        @Override
        protected void onStateReplaced(BlockState state, ServerWorld world, BlockPos pos, boolean moved) {
            if (!state.isOf(world.getBlockState(pos).getBlock())) {
                BlockEntity blockEntity = world.getBlockEntity(pos);
                if (blockEntity instanceof Inventory inventory) {
                    ItemScatterer.spawn(world, pos, inventory);
                }
            }
            super.onStateReplaced(state, world, pos, moved);
        }
    }
}

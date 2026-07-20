package de.atomi.starwrought.content;

import de.atomi.starwrought.Starwrought;
import de.atomi.starwrought.network.ModNetworking;
import de.atomi.starwrought.player.PlayerAttachments;
import de.atomi.starwrought.system.SkyEvents;
import net.fabricmc.fabric.api.itemgroup.v1.FabricItemGroup;
import net.fabricmc.fabric.api.itemgroup.v1.ItemGroupEvents;
import net.minecraft.block.BlockState;
import net.minecraft.entity.Entity;
import net.minecraft.entity.EquipmentSlot;
import net.minecraft.entity.LivingEntity;
import net.minecraft.entity.player.PlayerEntity;
import net.minecraft.entity.projectile.ProjectileEntity;
import net.minecraft.item.BowItem;
import net.minecraft.item.Item;
import net.minecraft.item.ItemGroup;
import net.minecraft.item.ItemStack;
import net.minecraft.item.ToolMaterial;
import net.minecraft.item.consume.UseAction;
import net.minecraft.item.equipment.ArmorMaterial;
import net.minecraft.item.equipment.EquipmentAsset;
import net.minecraft.item.equipment.EquipmentAssetKeys;
import net.minecraft.item.equipment.EquipmentType;
import net.minecraft.registry.Registries;
import net.minecraft.registry.Registry;
import net.minecraft.registry.RegistryKey;
import net.minecraft.registry.RegistryKeys;
import net.minecraft.registry.tag.BlockTags;
import net.minecraft.registry.tag.TagKey;
import net.minecraft.server.network.ServerPlayerEntity;
import net.minecraft.server.world.ServerWorld;
import net.minecraft.sound.SoundEvents;
import net.minecraft.text.Text;
import net.minecraft.util.ActionResult;
import net.minecraft.util.Hand;
import net.minecraft.util.Identifier;
import net.minecraft.util.Rarity;
import net.minecraft.util.math.BlockPos;
import net.minecraft.util.math.Vec3d;
import net.minecraft.world.World;

import java.util.List;
import java.util.Map;
import java.util.function.Function;

public final class ModItems {
    public static final TagKey<Item> REPAIRS_STARSTEEL = TagKey.of(RegistryKeys.ITEM, Starwrought.id("repairs_starsteel"));
    public static final ToolMaterial STARSTEEL_TOOL_MATERIAL =
            new ToolMaterial(BlockTags.INCORRECT_FOR_DIAMOND_TOOL, 1840, 9.0F, 3.5F, 18, REPAIRS_STARSTEEL);
    public static final RegistryKey<EquipmentAsset> STARSTEEL_ASSET =
            RegistryKey.of(EquipmentAssetKeys.REGISTRY_KEY, Starwrought.id("starsteel"));
    public static final ArmorMaterial STARSTEEL_ARMOR_MATERIAL = new ArmorMaterial(
            34,
            Map.of(
                    EquipmentType.HELMET, 3,
                    EquipmentType.CHESTPLATE, 8,
                    EquipmentType.LEGGINGS, 6,
                    EquipmentType.BOOTS, 3),
            18,
            SoundEvents.ITEM_ARMOR_EQUIP_DIAMOND,
            2.5F,
            0.1F,
            REPAIRS_STARSTEEL,
            STARSTEEL_ASSET);

    public static final Item STAR_SHARD = register("star_shard", Item::new, new Item.Settings().rarity(Rarity.UNCOMMON));
    public static final Item ASTROLABE = register("astrolabe", AstrolabeItem::new, new Item.Settings().maxCount(1));
    public static final Item CODEX_ARCANA = register("codex_arcana", CodexItem::new, new Item.Settings().maxCount(1));
    public static final Item CHART_WOLF = register("chart_wolf", Item::new, new Item.Settings().maxCount(1));
    public static final Item CHART_LYRA = register("chart_lyra", Item::new, new Item.Settings().maxCount(1));
    public static final Item CHART_ANVIL = register("chart_anvil", Item::new, new Item.Settings().maxCount(1));
    public static final Item STARSTEEL_INGOT = register("starsteel_ingot", Item::new, new Item.Settings());
    public static final Item GLIMMER_DUST = register("glimmer_dust", Item::new, new Item.Settings());
    public static final Item GLIMMER_PETAL = register("glimmer_petal", Item::new, new Item.Settings());
    public static final Item HOLLOW_RESIDUE = register("hollow_residue", Item::new, new Item.Settings().rarity(Rarity.UNCOMMON));
    public static final Item ZENITH_CORE = register("zenith_core", Item::new, new Item.Settings().rarity(Rarity.EPIC).fireproof());
    public static final Item PHASE_FLARE = register("phase_flare", PhaseFlareItem::new,
            new Item.Settings().maxCount(1).rarity(Rarity.RARE));
    public static final Item WAYBAND = register("wayband", WaybandItem::new,
            new Item.Settings().maxCount(1).rarity(Rarity.RARE));
    public static final Item COMET_BOW = register("comet_bow", CometBowItem::new,
            new Item.Settings().maxCount(1).maxDamage(720).enchantable(14).rarity(Rarity.RARE));

    public static final Item STARSTEEL_SWORD = register("starsteel_sword", Item::new,
            new Item.Settings().sword(STARSTEEL_TOOL_MATERIAL, 3.0F, -2.4F));
    public static final Item STARSTEEL_PICKAXE = register("starsteel_pickaxe", Item::new,
            new Item.Settings().pickaxe(STARSTEEL_TOOL_MATERIAL, 1.0F, -2.8F));
    public static final Item STARSTEEL_AXE = register("starsteel_axe", Item::new,
            new Item.Settings().axe(STARSTEEL_TOOL_MATERIAL, 5.5F, -3.0F));
    public static final Item STARSTEEL_SHOVEL = register("starsteel_shovel", Item::new,
            new Item.Settings().shovel(STARSTEEL_TOOL_MATERIAL, 1.5F, -3.0F));
    public static final Item STARSTEEL_HOE = register("starsteel_hoe", Item::new,
            new Item.Settings().hoe(STARSTEEL_TOOL_MATERIAL, -3.0F, 0.0F));
    public static final Item STARSTEEL_HELMET = armor("starsteel_helmet", EquipmentType.HELMET);
    public static final Item STARSTEEL_CHESTPLATE = armor("starsteel_chestplate", EquipmentType.CHESTPLATE);
    public static final Item STARSTEEL_LEGGINGS = armor("starsteel_leggings", EquipmentType.LEGGINGS);
    public static final Item STARSTEEL_BOOTS = armor("starsteel_boots", EquipmentType.BOOTS);

    public static final RegistryKey<ItemGroup> GROUP_KEY =
            RegistryKey.of(RegistryKeys.ITEM_GROUP, Starwrought.id("starwrought"));
    public static final ItemGroup GROUP = Registry.register(Registries.ITEM_GROUP, GROUP_KEY,
            FabricItemGroup.builder()
                    .icon(() -> new ItemStack(STAR_SHARD))
                    .displayName(Text.translatable("itemGroup.starwrought"))
                    .build());

    private ModItems() {
    }

    private static Item armor(String name, EquipmentType type) {
        return register(name, Item::new, new Item.Settings()
                .armor(STARSTEEL_ARMOR_MATERIAL, type)
                .maxDamage(type.getMaxDamage(34)));
    }

    private static <T extends Item> T register(String name, Function<Item.Settings, T> factory, Item.Settings settings) {
        Identifier id = Starwrought.id(name);
        RegistryKey<Item> key = RegistryKey.of(RegistryKeys.ITEM, id);
        T item = factory.apply(settings.registryKey(key));
        return Registry.register(Registries.ITEM, key, item);
    }

    public static void initialize() {
        ItemGroupEvents.modifyEntriesEvent(GROUP_KEY).register(entries -> {
            for (Item item : List.of(
                    STAR_SHARD, ASTROLABE, CODEX_ARCANA, CHART_WOLF, CHART_LYRA, CHART_ANVIL,
                    STARSTEEL_INGOT, GLIMMER_DUST, GLIMMER_PETAL, HOLLOW_RESIDUE, ZENITH_CORE,
                    PHASE_FLARE, WAYBAND, COMET_BOW, STARSTEEL_SWORD, STARSTEEL_PICKAXE,
                    STARSTEEL_AXE, STARSTEEL_SHOVEL, STARSTEEL_HOE, STARSTEEL_HELMET,
                    STARSTEEL_CHESTPLATE, STARSTEEL_LEGGINGS, STARSTEEL_BOOTS)) {
                entries.add(new ItemStack(item));
            }
            for (Item item : ModBlocks.blockItems()) {
                entries.add(new ItemStack(item));
            }
        });
    }

    public static final class CodexItem extends Item {
        public CodexItem(Settings settings) {
            super(settings);
        }

        @Override
        public ActionResult use(World world, PlayerEntity user, Hand hand) {
            if (user instanceof ServerPlayerEntity player) {
                ModNetworking.openHandbook(player);
            }
            return ActionResult.SUCCESS;
        }
    }

    public static final class AstrolabeItem extends Item {
        public AstrolabeItem(Settings settings) {
            super(settings);
        }

        @Override
        public ActionResult use(World world, PlayerEntity user, Hand hand) {
            if (user instanceof ServerPlayerEntity player) {
                if (user.isSneaking()) {
                    ModNetworking.openHandbook(player);
                } else {
                    player.sendMessage(Text.translatable(
                            SkyEvents.forecastKey((ServerWorld) player.getEntityWorld())), true);
                }
            }
            return ActionResult.SUCCESS;
        }

        @Override
        public void inventoryTick(ItemStack stack, ServerWorld world, Entity entity, EquipmentSlot slot) {
            if (!(entity instanceof ServerPlayerEntity player) || slot != EquipmentSlot.MAINHAND
                    || world.getTime() % 20 != 0) {
                return;
            }
            BlockPos origin = player.getBlockPos();
            BlockPos nearest = null;
            double nearestDistance = Double.MAX_VALUE;
            for (BlockPos candidate : BlockPos.iterateOutwards(origin, 24, 12, 24)) {
                if (world.getBlockState(candidate).isOf(ModBlocks.METEORITE_CORE)) {
                    double distance = candidate.getSquaredDistance(origin);
                    if (distance < nearestDistance) {
                        nearest = candidate.toImmutable();
                        nearestDistance = distance;
                    }
                }
            }
            if (nearest != null) {
                double angle = Math.toDegrees(Math.atan2(nearest.getZ() - origin.getZ(), nearest.getX() - origin.getX()));
                player.sendMessage(Text.translatable("message.starwrought.astrolabe_bearing",
                        Math.floorMod(Math.round(angle), 360), Math.round(Math.sqrt(nearestDistance))), true);
            }
        }
    }

    public static final class PhaseFlareItem extends Item {
        public PhaseFlareItem(Settings settings) {
            super(settings);
        }

        @Override
        public ActionResult use(World world, PlayerEntity user, Hand hand) {
            if (!(user instanceof ServerPlayerEntity player)) {
                return ActionResult.SUCCESS;
            }
            ItemStack stack = player.getStackInHand(hand);
            PlayerAttachments.BoundPosition previous = player.getAttached(PlayerAttachments.PHASE_ANCHOR);
            PlayerAttachments.BoundPosition current = position(player);
            if (previous == null || !previous.dimension().equals(world.getRegistryKey().getValue().toString())) {
                player.setAttached(PlayerAttachments.PHASE_ANCHOR, current);
                player.sendMessage(Text.translatable("message.starwrought.phase_marked"), true);
            } else {
                player.setAttached(PlayerAttachments.PHASE_ANCHOR, current);
                player.teleport((ServerWorld) player.getEntityWorld(),
                        previous.x() + 0.5, previous.y(), previous.z() + 0.5,
                        java.util.Set.of(), player.getYaw(), player.getPitch(), false);
                player.sendMessage(Text.translatable("message.starwrought.phase_swapped"), true);
            }
            player.getItemCooldownManager().set(stack, 100);
            return ActionResult.SUCCESS_SERVER;
        }
    }

    public static final class WaybandItem extends Item {
        public WaybandItem(Settings settings) {
            super(settings);
        }

        @Override
        public ActionResult use(World world, PlayerEntity user, Hand hand) {
            if (user.getAttached(PlayerAttachments.WAYBAND_TARGET) == null) {
                if (!world.isClient()) {
                    user.sendMessage(Text.translatable("message.starwrought.wayband_unbound"), true);
                }
                return ActionResult.FAIL;
            }
            user.setCurrentHand(hand);
            return ActionResult.CONSUME;
        }

        @Override
        public int getMaxUseTime(ItemStack stack, LivingEntity user) {
            return 60;
        }

        @Override
        public UseAction getUseAction(ItemStack stack) {
            return UseAction.BOW;
        }

        @Override
        public ItemStack finishUsing(ItemStack stack, World world, LivingEntity user) {
            if (user instanceof ServerPlayerEntity player) {
                PlayerAttachments.BoundPosition target = player.getAttached(PlayerAttachments.WAYBAND_TARGET);
                if (target != null) {
                    RegistryKey<World> dimension = RegistryKey.of(RegistryKeys.WORLD, Identifier.of(target.dimension()));
                    ServerWorld destination = ((ServerWorld) player.getEntityWorld()).getServer().getWorld(dimension);
                    if (destination != null && destination.getBlockState(new BlockPos(target.x(), target.y(), target.z()))
                            .isOf(ModBlocks.LUMEN_SPIRE)) {
                        player.teleport(destination, target.x() + 0.5, target.y() + 1.0, target.z() + 0.5,
                                java.util.Set.of(), player.getYaw(), player.getPitch(), false);
                        player.getItemCooldownManager().set(stack, 400);
                    } else {
                        player.sendMessage(Text.translatable("message.starwrought.wayband_lost"), true);
                    }
                }
            }
            return stack;
        }
    }

    public static final class CometBowItem extends BowItem {
        public CometBowItem(Settings settings) {
            super(settings);
        }

        @Override
        protected void shoot(LivingEntity shooter, ProjectileEntity projectile, int index, float speed,
                             float divergence, float yaw, LivingEntity target) {
            super.shoot(shooter, projectile, index, speed * 1.12F, divergence, yaw, target);
            projectile.setGlowing(true);
            projectile.setVelocity(projectile.getVelocity().multiply(1.15));
        }
    }

    private static PlayerAttachments.BoundPosition position(ServerPlayerEntity player) {
        BlockPos pos = player.getBlockPos();
        return new PlayerAttachments.BoundPosition(
                player.getEntityWorld().getRegistryKey().getValue().toString(), pos.getX(), pos.getY(), pos.getZ());
    }
}

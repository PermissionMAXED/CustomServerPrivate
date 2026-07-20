package de.atomi.starwrought.player;

import com.mojang.serialization.Codec;
import com.mojang.serialization.codecs.RecordCodecBuilder;
import de.atomi.starwrought.Starwrought;
import de.atomi.starwrought.attunement.Attunement;
import de.atomi.starwrought.attunement.AttunementProgress;
import net.fabricmc.fabric.api.attachment.v1.AttachmentRegistry;
import net.fabricmc.fabric.api.attachment.v1.AttachmentSyncPredicate;
import net.fabricmc.fabric.api.attachment.v1.AttachmentType;
import net.minecraft.network.RegistryByteBuf;
import net.minecraft.network.codec.PacketCodec;
import net.minecraft.network.codec.PacketCodecs;

import java.util.HashSet;
import java.util.List;
import java.util.Set;

public final class PlayerAttachments {
    private static final Codec<AttunementProgress> ATTUNEMENT_CODEC = RecordCodecBuilder.create(instance -> instance.group(
            Codec.STRING.xmap(Attunement::parse, value -> value.name().toLowerCase())
                    .fieldOf("constellation").forGetter(AttunementProgress::attunement),
            Codec.INT.fieldOf("counter").forGetter(AttunementProgress::counter)
    ).apply(instance, AttunementProgress::new));

    private static final PacketCodec<RegistryByteBuf, AttunementProgress> ATTUNEMENT_PACKET_CODEC =
            PacketCodec.tuple(
                    PacketCodecs.STRING.cast(), value -> value.attunement().name(),
                    PacketCodecs.VAR_INT.cast(), AttunementProgress::counter,
                    (name, counter) -> new AttunementProgress(Attunement.parse(name), counter));

    private static final Codec<Set<String>> STRING_SET_CODEC = Codec.STRING.listOf()
            .xmap(HashSet::new, List::copyOf);

    public static final AttachmentType<AttunementProgress> ATTUNEMENT =
            AttachmentRegistry.<AttunementProgress>builder()
                    .initializer(AttunementProgress::unattuned)
                    .persistent(ATTUNEMENT_CODEC)
                    .copyOnDeath()
                    .syncWith(ATTUNEMENT_PACKET_CODEC, AttachmentSyncPredicate.all())
                    .buildAndRegister(Starwrought.id("attunement"));

    public static final AttachmentType<Set<String>> HANDBOOK_UNLOCKS =
            AttachmentRegistry.<Set<String>>builder()
                    .initializer(HashSet::new)
                    .persistent(STRING_SET_CODEC)
                    .copyOnDeath()
                    .buildAndRegister(Starwrought.id("handbook_unlocks"));

    public static final AttachmentType<BoundPosition> PHASE_ANCHOR =
            AttachmentRegistry.createPersistent(Starwrought.id("phase_anchor"), BoundPosition.CODEC);

    public static final AttachmentType<BoundPosition> WAYBAND_TARGET =
            AttachmentRegistry.createPersistent(Starwrought.id("wayband_target"), BoundPosition.CODEC);

    private PlayerAttachments() {
    }

    public static void initialize() {
        // Static initialization performs registration.
    }

    public record BoundPosition(String dimension, int x, int y, int z) {
        public static final Codec<BoundPosition> CODEC = RecordCodecBuilder.create(instance -> instance.group(
                Codec.STRING.fieldOf("dimension").forGetter(BoundPosition::dimension),
                Codec.INT.fieldOf("x").forGetter(BoundPosition::x),
                Codec.INT.fieldOf("y").forGetter(BoundPosition::y),
                Codec.INT.fieldOf("z").forGetter(BoundPosition::z)
        ).apply(instance, BoundPosition::new));
    }
}

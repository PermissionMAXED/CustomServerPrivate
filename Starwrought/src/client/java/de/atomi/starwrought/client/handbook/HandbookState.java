package de.atomi.starwrought.client.handbook;

import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import net.minecraft.text.Text;

/**
 * Client projection of the server handbook, with a complete offline catalog.
 */
public final class HandbookState {
	public static final HandbookState INSTANCE = new HandbookState();

	private volatile List<Entry> entries = fallbackEntries();

	private HandbookState() {
	}

	public List<Entry> entries() {
		return entries;
	}

	public void applyWire(String encoded) {
		if (encoded == null || encoded.isBlank()) {
			return;
		}

		List<Entry> decoded = new ArrayList<>();
		for (String line : encoded.split("\\R")) {
			String[] parts = line.split("\\|", -1);
			if (parts.length != 5) {
				continue;
			}
			decoded.add(new Entry(
					parts[0],
					parseCategory(parts[1]),
					parts[2],
					parts[3],
					Boolean.parseBoolean(parts[4])
			));
		}
		if (!decoded.isEmpty()) {
			entries = List.copyOf(decoded);
		}
	}

	public void unlock(String entryId) {
		entries = entries.stream()
				.map(entry -> entry.id().equals(entryId)
						? new Entry(entry.id(), entry.category(), entry.titleKey(), entry.bodyKey(), true)
						: entry)
				.toList();
	}

	private static Category parseCategory(String value) {
		String normalized = value.toUpperCase(Locale.ROOT);
		if (normalized.contains("ATTUNE") || normalized.contains("CONSTELLATION")) {
			return Category.ATTUNEMENTS;
		}
		if (normalized.contains("FORGE") || normalized.contains("CRAFT") || normalized.contains("ARTIFICE")) {
			return Category.FORGING;
		}
		if (normalized.contains("THREAT") || normalized.contains("BOSS") || normalized.contains("HOLLOW")) {
			return Category.THREATS;
		}
		if (normalized.equals("ALL")) {
			return Category.ALL;
		}
		return Category.GETTING_STARTED;
	}

	public enum Category {
		ALL("handbook.starwrought.category.all"),
		GETTING_STARTED("handbook.starwrought.category.getting_started"),
		ATTUNEMENTS("handbook.starwrought.category.attunements"),
		FORGING("handbook.starwrought.category.forging"),
		THREATS("handbook.starwrought.category.threats");

		private final String translationKey;

		Category(String translationKey) {
			this.translationKey = translationKey;
		}

		public Text label() {
			return Text.translatable(translationKey);
		}
	}

	public record Entry(
			String id,
			Category category,
			String titleKey,
			String bodyKey,
			boolean unlocked
	) {
		public Text title() {
			return Text.translatable(titleKey);
		}

		public Text body() {
			return unlocked
					? Text.translatable(bodyKey)
					: Text.translatable("handbook.starwrought.locked_body");
		}
	}

	private static List<Entry> fallbackEntries() {
		return List.of(
				new Entry("welcome", Category.GETTING_STARTED,
						"handbook.starwrought.entry.getting_started.title",
						"handbook.starwrought.entry.getting_started.body", true),
				new Entry("starfall", Category.GETTING_STARTED,
						"handbook.starwrought.entry.sky_events.title",
						"handbook.starwrought.entry.sky_events.body", true),
				new Entry("wolf", Category.ATTUNEMENTS,
						"handbook.starwrought.entry.wolf.title",
						"handbook.starwrought.entry.wolf.body", true),
				new Entry("lyra", Category.ATTUNEMENTS,
						"handbook.starwrought.entry.lyra.title",
						"handbook.starwrought.entry.lyra.body", true),
				new Entry("anvil", Category.ATTUNEMENTS,
						"handbook.starwrought.entry.anvil.title",
						"handbook.starwrought.entry.anvil.body", true),
				new Entry("star_forge", Category.FORGING,
						"handbook.starwrought.entry.star_forge.title",
						"handbook.starwrought.entry.star_forge.body", true),
				new Entry("voidglass", Category.FORGING,
						"handbook.starwrought.entry.voidglass.title",
						"handbook.starwrought.entry.voidglass.body", false),
				new Entry("umbral_night", Category.THREATS,
						"handbook.starwrought.entry.umbral_night.title",
						"handbook.starwrought.entry.umbral_night.body", true),
				new Entry("herald", Category.THREATS,
						"handbook.starwrought.entry.herald.title",
						"handbook.starwrought.entry.herald.body", false)
		);
	}
}

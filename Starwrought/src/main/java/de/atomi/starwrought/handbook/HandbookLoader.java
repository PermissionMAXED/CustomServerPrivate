package de.atomi.starwrought.handbook;

import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import de.atomi.starwrought.Starwrought;
import net.fabricmc.fabric.api.resource.ResourceManagerHelper;
import net.fabricmc.fabric.api.resource.SimpleSynchronousResourceReloadListener;
import net.minecraft.resource.Resource;
import net.minecraft.resource.ResourceManager;
import net.minecraft.resource.ResourceType;
import net.minecraft.util.Identifier;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;
import java.util.Map;

public final class HandbookLoader {
    private static final Gson GSON = new Gson();
    private static volatile Content content = new Content(List.of(), List.of(), "{\"chapters\":[],\"entries\":[]}");

    private HandbookLoader() {
    }

    public static void initialize() {
        ResourceManagerHelper.get(ResourceType.SERVER_DATA).registerReloadListener(new ReloadListener());
    }

    public static Content content() {
        return content;
    }

    public static String encodeFor(UnlockCondition.UnlockContext context) {
        StringBuilder result = new StringBuilder();
        for (Entry entry : content.entries()) {
            JsonObject json = entry.json();
            String category = json.has("category") ? json.get("category").getAsString() : "getting_started";
            String title = json.has("title") ? json.get("title").getAsString()
                    : "handbook.starwrought.entry." + entry.id().replace("starwrought:", "") + ".title";
            String body = json.has("body") ? json.get("body").getAsString()
                    : "handbook.starwrought.entry." + entry.id().replace("starwrought:", "") + ".body";
            result.append(sanitize(entry.id())).append('|')
                    .append(sanitize(category)).append('|')
                    .append(sanitize(title)).append('|')
                    .append(sanitize(body)).append('|')
                    .append(entry.unlock().isUnlocked(context)).append('\n');
        }
        return result.toString();
    }

    public static UnlockCondition parseUnlock(JsonObject object, String fallbackEntryId) {
        if (object == null || !object.has("type")) {
            return new UnlockCondition.Always();
        }
        String type = object.get("type").getAsString();
        String value = object.has("value") ? object.get("value").getAsString() : fallbackEntryId;
        return switch (type) {
            case "has_item" -> new UnlockCondition.HasItem(value);
            case "advancement" -> new UnlockCondition.Advancement(value);
            case "manual" -> new UnlockCondition.Manual(value);
            default -> new UnlockCondition.Always();
        };
    }

    public record Chapter(String id, JsonObject json) {
    }

    public record Entry(String id, UnlockCondition unlock, JsonObject json) {
    }

    public record Content(List<Chapter> chapters, List<Entry> entries, String encodedJson) {
    }

    private static String sanitize(String value) {
        return value.replace('|', '_').replace('\n', ' ').replace('\r', ' ');
    }

    private static final class ReloadListener implements SimpleSynchronousResourceReloadListener {
        @Override
        public Identifier getFabricId() {
            return Starwrought.id("handbook");
        }

        @Override
        public void reload(ResourceManager manager) {
            List<Chapter> chapters = read(manager, "handbook/chapters").stream()
                    .map(document -> new Chapter(document.id(), document.json()))
                    .toList();
            List<Entry> entries = read(manager, "handbook/entries").stream()
                    .map(document -> new Entry(document.id(),
                            parseUnlock(document.json().has("unlock")
                                            ? document.json().getAsJsonObject("unlock") : null,
                                    document.id()),
                            document.json()))
                    .toList();

            JsonObject root = new JsonObject();
            root.add("chapters", GSON.toJsonTree(chapters.stream().map(Chapter::json).toList()));
            root.add("entries", GSON.toJsonTree(entries.stream().map(Entry::json).toList()));
            content = new Content(List.copyOf(chapters), List.copyOf(entries), GSON.toJson(root));
            Starwrought.LOGGER.info("Loaded {} handbook chapters and {} entries", chapters.size(), entries.size());
        }

        private static List<Document> read(ResourceManager manager, String path) {
            List<Document> documents = new ArrayList<>();
            Map<Identifier, Resource> resources = manager.findResources(path,
                    identifier -> identifier.getNamespace().equals(Starwrought.MOD_ID)
                            && identifier.getPath().endsWith(".json"));
            resources.entrySet().stream().sorted(Comparator.comparing(entry -> entry.getKey().toString()))
                    .forEach(entry -> {
                        try (var reader = entry.getValue().getReader()) {
                            JsonElement parsed = JsonParser.parseReader(reader);
                            if (parsed.isJsonObject()) {
                                JsonObject object = parsed.getAsJsonObject();
                                String id = object.has("id") ? object.get("id").getAsString()
                                        : entry.getKey().toString();
                                documents.add(new Document(id, object));
                            }
                        } catch (IOException | RuntimeException exception) {
                            Starwrought.LOGGER.error("Unable to load handbook document {}", entry.getKey(), exception);
                        }
                    });
            return documents;
        }
    }

    private record Document(String id, JsonObject json) {
    }
}

#!/usr/bin/env python3
"""Generate procedural 16x16 (and GUI) PNG textures for Starwrought — Prismbreak palette."""
from __future__ import annotations

import math
import json
import struct
import zlib
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
ASSETS = ROOT / "src/main/resources/assets/starwrought"
DATA = ROOT / "src/main/resources/data/starwrought"

# Prismbreak palette
INDIGO = (42, 27, 94, 255)
CYAN = (77, 227, 255, 255)
GOLD = (255, 233, 168, 255)
VOID = (12, 8, 28, 255)
WHITE = (255, 255, 255, 255)
PURPLE = (90, 40, 140, 255)
METEOR = (60, 55, 70, 255)
IRON = (140, 150, 170, 255)


def png(path: Path, w: int, h: int, rgba_fn):
    rows = []
    for y in range(h):
        row = bytearray([0])  # filter none
        for x in range(w):
            r, g, b, a = rgba_fn(x, y, w, h)
            row.extend((r & 255, g & 255, b & 255, a & 255))
        rows.append(bytes(row))
    raw = b"".join(rows)

    def chunk(tag: bytes, data: bytes) -> bytes:
        return struct.pack(">I", len(data)) + tag + data + struct.pack(">I", zlib.crc32(tag + data) & 0xFFFFFFFF)

    ihdr = struct.pack(">IIBBBBB", w, h, 8, 6, 0, 0, 0)
    data = b"\x89PNG\r\n\x1a\n" + chunk(b"IHDR", ihdr) + chunk(b"IDAT", zlib.compress(raw, 9)) + chunk(b"IEND", b"")
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_bytes(data)


def lerp(a, b, t):
    return tuple(int(a[i] + (b[i] - a[i]) * t) for i in range(4))


def noise(x, y, seed=0):
    n = math.sin((x + 11.1) * 12.9898 + (y + 7.3) * 78.233 + seed * 37.1) * 43758.5453
    return n - math.floor(n)


def star_item(name, core=CYAN, arms=GOLD, bg=VOID):
    def px(x, y, w, h):
        cx, cy = (w - 1) / 2, (h - 1) / 2
        dx, dy = x - cx, y - cy
        r = math.hypot(dx, dy)
        ang = abs(math.atan2(dy, dx))
        # 4-point star
        spike = (math.cos(ang * 2) ** 2) * 6.5
        if r < 2.2:
            return core
        if r < spike:
            t = r / max(spike, 0.1)
            return lerp(core, arms, t * 0.7)
        if r < spike + 1.2:
            return (*arms[:3], 180)
        return (0, 0, 0, 0)

    png(ASSETS / f"textures/item/{name}.png", 16, 16, px)


def cube_block(name, base, edge, sparkle=True):
    def px(x, y, w, h):
        # simple top-face-ish shading
        t = (x + y) / (2 * (w - 1))
        c = lerp(base, edge, t * 0.55)
        if sparkle and noise(x, y, hash(name) % 97) > 0.88:
            return GOLD if noise(x, y, 3) > 0.5 else CYAN
        # border
        if x in (0, w - 1) or y in (0, h - 1):
            return lerp(edge, VOID, 0.3)
        return c

    png(ASSETS / f"textures/block/{name}.png", 16, 16, px)


def particle(name, color):
    def px(x, y, w, h):
        cx, cy = (w - 1) / 2, (h - 1) / 2
        dx, dy = x - cx, y - cy
        ax, ay = abs(dx), abs(dy)
        if name == "prisma_spark":
            # Four-point, hard-edged additive star.
            if ax + ay < 2.2:
                return WHITE
            if (min(ax, ay) < 0.8 and max(ax, ay) < 7.0) or ax + ay < 4.2:
                return color
            if min(ax, ay) < 1.2 and max(ax, ay) < 7.5:
                return (*color[:3], 110)
        elif name == "prisma_shard":
            # Long rotated crystal with a white-gold edge and cyan core.
            major = dx * 0.5 + dy * 0.866
            minor = -dx * 0.866 + dy * 0.5
            limit = max(0.0, 2.1 * (1.0 - abs(major) / 7.4))
            if abs(major) < 7.4 and abs(minor) < limit:
                if abs(minor) < limit * 0.45:
                    return WHITE if abs(major) < 2.0 else CYAN
                return color
            if abs(major) < 7.6 and abs(minor) < limit + 0.55:
                return (*color[:3], 100)
        else:
            # Hollow indigo diamond with cyan fracture points.
            diamond = ax + ay
            if 3.2 < diamond < 5.8:
                return CYAN if ax < 1.0 or ay < 1.0 else color
            if 2.7 < diamond < 6.4:
                return (*color[:3], 105)
        return (0, 0, 0, 0)

    png(ASSETS / f"textures/particle/{name}.png", 16, 16, px)


def gui_panel():
    def px(x, y, w, h):
        # parchment with gold border
        border = x < 3 or y < 3 or x >= w - 3 or y >= h - 3
        if border:
            t = noise(x, y, 1)
            return lerp(GOLD, (180, 140, 60, 255), t * 0.4)
        # inner
        parchment = (232, 217, 176, 255)
        dark = (210, 190, 150, 255)
        t = noise(x // 2, y // 2, 2) * 0.35
        return lerp(parchment, dark, t)

    png(ASSETS / "textures/gui/handbook/background.png", 320, 200, px)


def icon():
    def px(x, y, w, h):
        cx, cy = 63.5, 63.5
        dx, dy = x - cx, y - cy
        r = math.hypot(dx, dy)
        if r > 60:
            return (0, 0, 0, 0)
        if r > 54:
            return GOLD
        # voidglass disk
        base = lerp(VOID, INDIGO, r / 54)
        ang = math.atan2(dy, dx)
        spike = abs(math.cos(ang * 4)) ** 3
        if r < 18 + spike * 22:
            return lerp(CYAN, GOLD, spike)
        if noise(x, y, 9) > 0.93:
            return WHITE
        return base

    png(ASSETS / "icon.png", 128, 128, px)


def write_json(path: Path, value):
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(json.dumps(value, ensure_ascii=False, indent=2) + "\n", encoding="utf-8")


def generate_models():
    items = [
        "star_shard", "astrolabe", "codex_arcana", "chart_wolf", "chart_lyra", "chart_anvil",
        "starsteel_ingot", "glimmer_dust", "glimmer_petal", "hollow_residue", "zenith_core",
        "phase_flare", "wayband", "comet_bow", "starsteel_helmet", "starsteel_chestplate",
        "starsteel_leggings", "starsteel_boots", "starsteel_sword", "starsteel_pickaxe",
        "starsteel_axe", "starsteel_shovel", "starsteel_hoe",
    ]
    handheld = {"starsteel_sword", "starsteel_pickaxe", "starsteel_axe", "starsteel_shovel",
                "starsteel_hoe", "comet_bow"}
    blocks = [
        "meteoric_stone", "meteorite_core", "resonance_altar", "star_forge", "lumen_lantern",
        "lumen_spire", "voidglass", "hollow_beacon", "astral_bloom",
    ]
    for name in items:
        write_json(ASSETS / f"models/item/{name}.json", {
            "parent": "minecraft:item/handheld" if name in handheld else "minecraft:item/generated",
            "textures": {"layer0": f"starwrought:item/{name}"},
        })
        write_json(ASSETS / f"items/{name}.json", {
            "model": {"type": "minecraft:model", "model": f"starwrought:item/{name}"}
        })
    for name in blocks:
        write_json(ASSETS / f"models/block/{name}.json", {
            "parent": "minecraft:block/cube_all",
            "textures": {"all": f"starwrought:block/{name}"},
        })
        variants = {"": {"model": f"starwrought:block/{name}"}}
        if name == "astral_bloom":
            variants = {f"age={age}": {"model": "starwrought:block/astral_bloom"} for age in range(4)}
        write_json(ASSETS / f"blockstates/{name}.json", {"variants": variants})
        write_json(ASSETS / f"models/item/{name}.json", {"parent": f"starwrought:block/{name}"})
        write_json(ASSETS / f"items/{name}.json", {
            "model": {"type": "minecraft:model", "model": f"starwrought:item/{name}"}
        })
    write_json(ASSETS / "equipment/starsteel.json", {
        "layers": {
            "humanoid": [{"texture": "starwrought:starsteel"}],
            "humanoid_leggings": [{"texture": "starwrought:starsteel"}],
        }
    })
    def armor_px(x, y, w, h):
        if noise(x, y, 31) > 0.92:
            return CYAN
        return lerp(IRON, INDIGO, (x + y) / (w + h) * 0.55)
    png(ASSETS / "textures/entity/equipment/humanoid/starsteel.png", 64, 32, armor_px)
    png(ASSETS / "textures/entity/equipment/humanoid_leggings/starsteel.png", 64, 32, armor_px)
    for name in ("prisma_spark", "prisma_shard", "hollow_mote"):
        write_json(ASSETS / f"particles/{name}.json", {"textures": [f"starwrought:{name}"]})


def generate_lang():
    names = {
        "star_shard": ("Star Shard", "Sternensplitter"),
        "astrolabe": ("Astrolabe", "Astrolabium"),
        "codex_arcana": ("Codex Arcana", "Codex Arcana"),
        "chart_wolf": ("Chart of the Wolf", "Karte des Wolfs"),
        "chart_lyra": ("Chart of Lyra", "Karte der Leier"),
        "chart_anvil": ("Chart of the Anvil", "Karte des Ambosses"),
        "starsteel_ingot": ("Starsteel Ingot", "Sternenstahlbarren"),
        "glimmer_dust": ("Glimmer Dust", "Schimmerstaub"),
        "glimmer_petal": ("Glimmer Petal", "Schimmerblüte"),
        "hollow_residue": ("Hollow Residue", "Leerenrückstand"),
        "zenith_core": ("Zenith Core", "Zenitkern"),
        "phase_flare": ("Phase Flare", "Phasenfackel"),
        "wayband": ("Wayband", "Pfadband"),
        "comet_bow": ("Comet Bow", "Kometenbogen"),
        "starsteel_helmet": ("Starsteel Helmet", "Sternenstahlhelm"),
        "starsteel_chestplate": ("Starsteel Chestplate", "Sternenstahlharnisch"),
        "starsteel_leggings": ("Starsteel Leggings", "Sternenstahlbeinschutz"),
        "starsteel_boots": ("Starsteel Boots", "Sternenstahlstiefel"),
        "starsteel_sword": ("Starsteel Sword", "Sternenstahlschwert"),
        "starsteel_pickaxe": ("Starsteel Pickaxe", "Sternenstahlspitzhacke"),
        "starsteel_axe": ("Starsteel Axe", "Sternenstahlaxt"),
        "starsteel_shovel": ("Starsteel Shovel", "Sternenstahlschaufel"),
        "starsteel_hoe": ("Starsteel Hoe", "Sternenstahlhacke"),
    }
    block_names = {
        "meteoric_stone": ("Meteoric Stone", "Meteorstein"),
        "meteorite_core": ("Meteorite Core", "Meteoritenkern"),
        "resonance_altar": ("Resonance Altar", "Resonanzaltar"),
        "star_forge": ("Star Forge", "Sternenschmiede"),
        "lumen_lantern": ("Lumen Lantern", "Lumenlaterne"),
        "lumen_spire": ("Lumen Spire", "Lumenspitze"),
        "voidglass": ("Voidglass", "Leerglas"),
        "hollow_beacon": ("Hollow Beacon", "Leerenleuchtfeuer"),
        "astral_bloom": ("Astral Bloom", "Astralblüte"),
    }
    en = {f"item.starwrought.{key}": value[0] for key, value in names.items()}
    de = {f"item.starwrought.{key}": value[1] for key, value in names.items()}
    en.update({f"block.starwrought.{key}": value[0] for key, value in block_names.items()})
    de.update({f"block.starwrought.{key}": value[1] for key, value in block_names.items()})
    en.update({
        "itemGroup.starwrought": "Starwrought",
        "entity.starwrought.hollow_stalker": "Hollow Stalker",
        "entity.starwrought.herald": "Herald of the Hollow Star",
        "constellation.starwrought.wolf": "Wolf",
        "constellation.starwrought.lyra": "Lyra",
        "constellation.starwrought.anvil": "Anvil",
        "message.starwrought.aurora_begins": "An aurora kindles above. Starfall is near!",
        "message.starwrought.umbral_begins": "The stars dim. An Umbral Night has begun.",
        "message.starwrought.herald_summoned": "The Herald of the Hollow Star awakens!",
        "message.starwrought.herald_phase": "The Herald enters phase %s!",
        "message.starwrought.attuned": "Attuned to %s.",
        "message.starwrought.attunement_level": "Attunement reached level %s.",
        "message.starwrought.phase_marked": "Phase position marked.",
        "message.starwrought.phase_swapped": "Positions swapped.",
        "message.starwrought.wayband_unbound": "Bind this Wayband to a Lumen Spire first.",
        "message.starwrought.wayband_bound": "Wayband bound to this Lumen Spire.",
        "message.starwrought.wayband_lost": "The bound Lumen Spire can no longer be found.",
        "message.starwrought.astrolabe_bearing": "Meteoric resonance: %s° (%s blocks)",
        "message.starwrought.forecast_distant": "The constellations are distant in this realm.",
        "message.starwrought.forecast_aurora_now": "The aurora burns tonight.",
        "message.starwrought.forecast_umbral_now": "An Umbral Night is underway.",
        "message.starwrought.forecast_aurora": "The aurora is the next celestial event.",
        "message.starwrought.forecast_umbral": "An Umbral Night approaches before the next aurora.",
        "message.starwrought.ability_locked": "Reach attunement level 5 to use this ability.",
        "message.starwrought.ability_cooldown": "Ability ready in %s seconds.",
        "message.starwrought.codex_granted": "A Codex Arcana forms around your first Star Shard.",
        "key.starwrought.handbook": "Open Codex Arcana",
        "key.starwrought.ability": "Activate Attunement Ability",
        "key.category.starwrought": "Starwrought",
        "key.category.starwrought.starwrought": "Starwrought",
        "hud.starwrought.attunement.wolf": "WOLF // HUNT",
        "hud.starwrought.attunement.lyra": "LYRA // RESONANCE",
        "hud.starwrought.attunement.anvil": "ANVIL // FORGE",
        "hud.starwrought.attunement.unattuned": "UNATTUNED",
        "hud.starwrought.cooldown": "%ss",
        "handbook.starwrought.title": "CODEX ARCANA",
        "handbook.starwrought.subtitle": "PRISMBREAK ARCHIVE",
        "handbook.starwrought.search": "Search the archive...",
        "handbook.starwrought.no_results": "No resonance found",
        "handbook.starwrought.locked": "ENTRY SEALED",
        "handbook.starwrought.category.all": "All",
        "handbook.starwrought.category.getting_started": "Getting Started",
        "handbook.starwrought.category.attunements": "Attunements",
        "handbook.starwrought.category.forging": "Forging",
        "handbook.starwrought.category.threats": "Threats",
        "handbook.starwrought.locked_body": "This knowledge has not yet been unlocked.",
        "advancement.starwrought.first_shard.title": "A Fallen Star",
        "advancement.starwrought.first_shard.description": "Recover your first Star Shard",
        "advancement.starwrought.altar.title": "Resonant Foundations",
        "advancement.starwrought.altar.description": "Place a Resonance Altar",
        "advancement.starwrought.attune.title": "Written in the Stars",
        "advancement.starwrought.attune.description": "Use a chart at a Resonance Altar",
        "advancement.starwrought.herald.title": "At the Zenith",
        "advancement.starwrought.herald.description": "Defeat the Herald of the Hollow Star",
        "tag.item.starwrought.repairs_starsteel": "Repairs Starsteel",
    })
    de.update({
        "itemGroup.starwrought": "Sternengewirkt",
        "entity.starwrought.hollow_stalker": "Leerenpirscher",
        "entity.starwrought.herald": "Herold des Hohlsterns",
        "constellation.starwrought.wolf": "Wolf",
        "constellation.starwrought.lyra": "Leier",
        "constellation.starwrought.anvil": "Amboss",
        "message.starwrought.aurora_begins": "Ein Polarlicht entflammt. Sternenfall naht!",
        "message.starwrought.umbral_begins": "Die Sterne verblassen. Eine Umbralnacht beginnt.",
        "message.starwrought.herald_summoned": "Der Herold des Hohlsterns erwacht!",
        "message.starwrought.herald_phase": "Der Herold erreicht Phase %s!",
        "message.starwrought.attuned": "Auf %s eingestimmt.",
        "message.starwrought.attunement_level": "Einstimmung erreicht Stufe %s.",
        "message.starwrought.phase_marked": "Phasenposition markiert.",
        "message.starwrought.phase_swapped": "Positionen getauscht.",
        "message.starwrought.wayband_unbound": "Binde dieses Pfadband zuerst an eine Lumenspitze.",
        "message.starwrought.wayband_bound": "Pfadband an diese Lumenspitze gebunden.",
        "message.starwrought.wayband_lost": "Die gebundene Lumenspitze ist nicht mehr auffindbar.",
        "message.starwrought.astrolabe_bearing": "Meteorresonanz: %s° (%s Blöcke)",
        "message.starwrought.forecast_distant": "In diesem Reich sind die Sternbilder fern.",
        "message.starwrought.forecast_aurora_now": "Heute Nacht brennt das Polarlicht.",
        "message.starwrought.forecast_umbral_now": "Eine Umbralnacht ist im Gange.",
        "message.starwrought.forecast_aurora": "Das Polarlicht ist das nächste Himmelsereignis.",
        "message.starwrought.forecast_umbral": "Vor dem nächsten Polarlicht naht eine Umbralnacht.",
        "message.starwrought.ability_locked": "Erreiche Einstimmungsstufe 5 für diese Fähigkeit.",
        "message.starwrought.ability_cooldown": "Fähigkeit in %s Sekunden bereit.",
        "message.starwrought.codex_granted": "Ein Codex Arcana formt sich um deinen ersten Sternensplitter.",
        "key.starwrought.handbook": "Codex Arcana öffnen",
        "key.starwrought.ability": "Einstimmungsfähigkeit aktivieren",
        "key.category.starwrought": "Sternengewirkt",
        "key.category.starwrought.starwrought": "Sternengewirkt",
        "hud.starwrought.attunement.wolf": "WOLF // JAGD",
        "hud.starwrought.attunement.lyra": "LEIER // RESONANZ",
        "hud.starwrought.attunement.anvil": "AMBOSS // SCHMIEDE",
        "hud.starwrought.attunement.unattuned": "NICHT EINGESTIMMT",
        "hud.starwrought.cooldown": "%ss",
        "handbook.starwrought.title": "CODEX ARCANA",
        "handbook.starwrought.subtitle": "PRISMBRUCH-ARCHIV",
        "handbook.starwrought.search": "Archiv durchsuchen...",
        "handbook.starwrought.no_results": "Keine Resonanz gefunden",
        "handbook.starwrought.locked": "EINTRAG VERSIEGELT",
        "handbook.starwrought.category.all": "Alle",
        "handbook.starwrought.category.getting_started": "Erste Schritte",
        "handbook.starwrought.category.attunements": "Einstimmungen",
        "handbook.starwrought.category.forging": "Schmieden",
        "handbook.starwrought.category.threats": "Bedrohungen",
        "handbook.starwrought.locked_body": "Dieses Wissen wurde noch nicht freigeschaltet.",
        "advancement.starwrought.first_shard.title": "Ein gefallener Stern",
        "advancement.starwrought.first_shard.description": "Berge deinen ersten Sternensplitter",
        "advancement.starwrought.altar.title": "Resonantes Fundament",
        "advancement.starwrought.altar.description": "Platziere einen Resonanzaltar",
        "advancement.starwrought.attune.title": "In den Sternen geschrieben",
        "advancement.starwrought.attune.description": "Nutze eine Karte an einem Resonanzaltar",
        "advancement.starwrought.herald.title": "Am Zenit",
        "advancement.starwrought.herald.description": "Besiege den Herold des Hohlsterns",
        "tag.item.starwrought.repairs_starsteel": "Repariert Sternenstahl",
    })
    entries = {
        "getting_started": ("First Light", "Erstes Licht",
                            "Find Star Shards in meteorites during aurora nights.", "Finde Sternensplitter in Meteoriten während Polarlichtnächten."),
        "sky_events": ("Celestial Calendar", "Himmelskalender",
                       "Auroras arrive about every four nights; Umbral Nights about every twelve.", "Polarlichter erscheinen etwa alle vier, Umbralnächte alle zwölf Nächte."),
        "star_shards": ("Star Shards", "Sternensplitter",
                        "Meteorite cores and surrounding stone hold celestial material.", "Meteoritenkerne und ihr Gestein bergen Himmelsmaterial."),
        "astrolabe": ("Astrolabe", "Astrolabium",
                      "Use it for a forecast. Held astrolabes seek nearby meteorite cores.", "Nutze es für Vorhersagen. Gehalten weist es zu Meteoritenkernen."),
        "resonance_altar": ("Resonance Altar", "Resonanzaltar",
                           "Use a constellation chart on the altar to attune.", "Nutze eine Sternbildkarte am Altar zur Einstimmung."),
        "wolf": ("The Wolf", "Der Wolf",
                 "Night kills deepen Wolf attunement. Level 5 unlocks Pack Howl.", "Nächtliche Siege stärken den Wolf. Stufe 5 entfesselt das Rudelheulen."),
        "lyra": ("Lyra", "Die Leier",
                 "Travel deepens Lyra attunement. Level 5 unlocks Comet Dash.", "Reisen stärkt die Leier. Stufe 5 entfesselt den Kometensprung."),
        "anvil": ("The Anvil", "Der Amboss",
                  "Forging deepens Anvil attunement and hastens the Star Forge.", "Schmieden stärkt den Amboss und beschleunigt die Sternenschmiede."),
        "star_forge": ("Star Forge", "Sternenschmiede",
                       "Insert a Star Shard and iron. Aurora light doubles its pace.", "Lege Sternensplitter und Eisen ein. Polarlicht verdoppelt das Tempo."),
        "lumen_network": ("Lumen Network", "Lumennetz",
                          "Bind a Wayband to a Lumen Spire, then channel to return.", "Binde ein Pfadband an eine Lumenspitze und kanalisiere die Rückkehr."),
        "phase_flare": ("Phase Flare", "Phasenfackel",
                        "The first use marks a place; later uses swap it with your position.", "Die erste Nutzung markiert einen Ort; weitere tauschen die Position."),
        "umbral_night": ("Umbral Night", "Umbralnacht",
                         "Hollow Stalkers blink through darkness and leave Hollow Residue.", "Leerenpirscher springen durch Dunkelheit und hinterlassen Rückstand."),
        "voidglass": ("Voidglass", "Leerglas",
                      "Voidglass is needed to wake the Hollow Beacon.", "Leerglas wird benötigt, um das Leerenleuchtfeuer zu wecken."),
        "herald": ("The Herald", "Der Herold",
                   "Four Hollow Residue and Voidglass awaken a three-phase boss.", "Vier Leerenrückstände und Leerglas erwecken einen Boss mit drei Phasen."),
        "zenith": ("Zenith", "Zenit",
                   "The Herald's Zenith Core marks mastery of Starwrought.", "Der Zenitkern des Herolds bezeugt die Meisterschaft."),
    }
    for key, (en_title, de_title, en_body, de_body) in entries.items():
        en[f"handbook.starwrought.entry.{key}.title"] = en_title
        en[f"handbook.starwrought.entry.{key}.body"] = en_body
        de[f"handbook.starwrought.entry.{key}.title"] = de_title
        de[f"handbook.starwrought.entry.{key}.body"] = de_body
    write_json(ASSETS / "lang/en_us.json", en)
    write_json(ASSETS / "lang/de_de.json", de)


def generate_data():
    blocks = [
        "meteoric_stone", "meteorite_core", "resonance_altar", "star_forge", "lumen_lantern",
        "lumen_spire", "voidglass", "hollow_beacon", "astral_bloom",
    ]
    for name in blocks:
        write_json(DATA / f"loot_table/blocks/{name}.json", {
            "type": "minecraft:block",
            "pools": [{"rolls": 1, "entries": [{"type": "minecraft:item", "name": f"starwrought:{name}"}],
                       "conditions": [{"condition": "minecraft:survives_explosion"}]}],
        })
    write_json(DATA / "loot_table/entities/hollow_stalker.json", {
        "type": "minecraft:entity",
        "pools": [{"rolls": {"type": "minecraft:uniform", "min": 0, "max": 2},
                   "entries": [{"type": "minecraft:item", "name": "starwrought:hollow_residue"}]}],
    })
    write_json(DATA / "loot_table/entities/herald.json", {"type": "minecraft:entity", "pools": []})
    write_json(DATA / "tags/item/repairs_starsteel.json", {"replace": False, "values": ["starwrought:starsteel_ingot"]})

    def shaped(name, pattern, keys, result, count=1):
        used_symbols = set("".join(pattern)) - {" "}
        write_json(DATA / f"recipe/{name}.json", {
            "type": "minecraft:crafting_shaped", "category": "misc", "pattern": pattern,
            "key": {symbol: value for symbol, value in keys.items() if symbol in used_symbols},
            "result": {"id": result, "count": count},
        })

    def shapeless(name, ingredients, result, count=1):
        write_json(DATA / f"recipe/{name}.json", {
            "type": "minecraft:crafting_shapeless", "category": "misc",
            "ingredients": ingredients, "result": {"id": result, "count": count},
        })

    shaped("astrolabe", [" G ", "ISI", " I "], {"G": "starwrought:glimmer_dust", "I": "minecraft:iron_ingot",
                                                "S": "starwrought:star_shard"}, "starwrought:astrolabe")
    shaped("codex_arcana", ["GS ", "GB ", "GS "], {"G": "minecraft:gold_nugget", "S": "starwrought:star_shard",
                                                   "B": "minecraft:book"}, "starwrought:codex_arcana")
    for chart, dye in (("wolf", "red_dye"), ("lyra", "light_blue_dye"), ("anvil", "gray_dye")):
        shapeless(f"chart_{chart}", ["minecraft:paper", f"minecraft:{dye}", "starwrought:glimmer_dust"],
                  f"starwrought:chart_{chart}")
    shaped("resonance_altar", ["SAS", "ODO", "OOO"], {"S": "starwrought:star_shard",
                                                     "A": "minecraft:amethyst_shard",
                                                     "O": "minecraft:obsidian",
                                                     "D": "minecraft:diamond"}, "starwrought:resonance_altar")
    shaped("star_forge", ["SBS", "IFI", "III"], {"S": "starwrought:star_shard", "B": "minecraft:blast_furnace",
                                                 "I": "minecraft:iron_ingot", "F": "minecraft:furnace"},
           "starwrought:star_forge")
    shaped("lumen_lantern", [" G ", "GSG", " G "], {"G": "starwrought:glimmer_dust",
                                                   "S": "starwrought:star_shard"}, "starwrought:lumen_lantern")
    shaped("lumen_spire", [" L ", " L ", " V "], {"L": "starwrought:lumen_lantern",
                                                 "V": "starwrought:voidglass"}, "starwrought:lumen_spire")
    shapeless("voidglass", ["minecraft:tinted_glass", "minecraft:amethyst_shard",
                            "starwrought:hollow_residue"], "starwrought:voidglass", 2)
    shaped("hollow_beacon", ["VRV", "RSR", "OOO"], {"V": "starwrought:voidglass",
                                                   "R": "starwrought:hollow_residue",
                                                   "S": "starwrought:star_shard",
                                                   "O": "minecraft:obsidian"}, "starwrought:hollow_beacon")
    shaped("phase_flare", [" G ", "SAS", " G "], {"G": "starwrought:glimmer_dust",
                                                 "S": "starwrought:starsteel_ingot",
                                                 "A": "minecraft:amethyst_shard"}, "starwrought:phase_flare")
    shaped("wayband", [" SG", "S S", "GS "], {"G": "starwrought:glimmer_dust",
                                              "S": "starwrought:starsteel_ingot"}, "starwrought:wayband")
    shaped("comet_bow", [" GS", "G S", " GS"], {"G": "starwrought:glimmer_dust",
                                                "S": "starwrought:starsteel_ingot"}, "starwrought:comet_bow")
    shapeless("glimmer_dust", ["starwrought:glimmer_petal"], "starwrought:glimmer_dust", 2)
    write_json(DATA / "recipe/meteorite_refining.json", {
        "type": "minecraft:smelting", "category": "misc",
        "ingredient": "starwrought:meteoric_stone",
        "result": {"id": "starwrought:star_shard"},
        "experience": 0.7, "cookingtime": 200,
    })
    shaped("meteorite_core", ["MMM", "MSM", "MMM"], {"M": "starwrought:meteoric_stone",
                                                    "S": "starwrought:star_shard"}, "starwrought:meteorite_core")
    tool_patterns = {
        "sword": [" S ", " S ", " T "], "pickaxe": ["SSS", " T ", " T "],
        "axe": ["SS ", "ST ", " T "], "shovel": [" S ", " T ", " T "],
        "hoe": ["SS ", " T ", " T "], "helmet": ["SSS", "S S"],
        "chestplate": ["S S", "SSS", "SSS"], "leggings": ["SSS", "S S", "S S"],
        "boots": ["S S", "S S"],
    }
    for piece, pattern in tool_patterns.items():
        shaped(f"starsteel_{piece}", pattern, {"S": "starwrought:starsteel_ingot", "T": "minecraft:stick"},
               f"starwrought:starsteel_{piece}")

    advancement_base = {"show_toast": True, "announce_to_chat": True, "hidden": False}
    write_json(DATA / "advancement/first_shard.json", {
        "display": {**advancement_base, "icon": {"id": "starwrought:star_shard"},
                    "title": "advancement.starwrought.first_shard.title",
                    "description": "advancement.starwrought.first_shard.description"},
        "criteria": {"shard": {"trigger": "minecraft:inventory_changed",
                               "conditions": {"items": [{"items": "starwrought:star_shard"}]}}},
    })
    write_json(DATA / "advancement/altar.json", {
        "parent": "starwrought:first_shard",
        "display": {**advancement_base, "icon": {"id": "starwrought:resonance_altar"},
                    "title": "advancement.starwrought.altar.title",
                    "description": "advancement.starwrought.altar.description"},
        "criteria": {"altar": {"trigger": "minecraft:placed_block",
                               "conditions": {"block": "starwrought:resonance_altar"}}},
    })
    write_json(DATA / "advancement/attune.json", {
        "parent": "starwrought:altar",
        "display": {**advancement_base, "icon": {"id": "starwrought:chart_wolf"},
                    "title": "advancement.starwrought.attune.title",
                    "description": "advancement.starwrought.attune.description"},
        "criteria": {"attune": {"trigger": "minecraft:item_used_on_block",
                                "conditions": {"location": [{
                                    "condition": "minecraft:location_check",
                                    "predicate": {"block": {"blocks": "starwrought:resonance_altar"}}
                                }]}}},
    })
    write_json(DATA / "advancement/herald.json", {
        "parent": "starwrought:attune",
        "display": {**advancement_base, "icon": {"id": "starwrought:zenith_core"},
                    "title": "advancement.starwrought.herald.title",
                    "description": "advancement.starwrought.herald.description"},
        "criteria": {"herald": {"trigger": "minecraft:player_killed_entity",
                                "conditions": {"entity": {"type": "starwrought:herald"}}}},
    })

    chapters = [
        ("origins", "handbook.starwrought.category.getting_started", 0),
        ("constellations", "handbook.starwrought.category.attunements", 1),
        ("artifice", "handbook.starwrought.category.forging", 2),
        ("hollow", "handbook.starwrought.category.threats", 3),
    ]
    for chapter, title, order in chapters:
        write_json(DATA / f"handbook/chapters/{chapter}.json",
                   {"id": f"starwrought:{chapter}", "title": title, "order": order})
    entry_defs = [
        ("getting_started", "origins", "getting_started", "always", ""),
        ("sky_events", "origins", "getting_started", "always", ""),
        ("star_shards", "origins", "getting_started", "has_item", "starwrought:star_shard"),
        ("astrolabe", "origins", "getting_started", "has_item", "starwrought:astrolabe"),
        ("resonance_altar", "constellations", "attunements", "has_item", "starwrought:resonance_altar"),
        ("wolf", "constellations", "attunements", "has_item", "starwrought:chart_wolf"),
        ("lyra", "constellations", "attunements", "has_item", "starwrought:chart_lyra"),
        ("anvil", "constellations", "attunements", "has_item", "starwrought:chart_anvil"),
        ("star_forge", "artifice", "forging", "has_item", "starwrought:star_forge"),
        ("lumen_network", "artifice", "forging", "has_item", "starwrought:wayband"),
        ("phase_flare", "artifice", "forging", "has_item", "starwrought:phase_flare"),
        ("umbral_night", "hollow", "threats", "manual", "starwrought:umbral_night"),
        ("voidglass", "hollow", "forging", "has_item", "starwrought:voidglass"),
        ("herald", "hollow", "threats", "has_item", "starwrought:hollow_beacon"),
        ("zenith", "hollow", "threats", "has_item", "starwrought:zenith_core"),
    ]
    for order, (entry, chapter, category, unlock_type, value) in enumerate(entry_defs):
        unlock = {"type": unlock_type}
        if value:
            unlock["value"] = value
        write_json(DATA / f"handbook/entries/{chapter}/{entry}.json", {
            "id": f"starwrought:{entry}", "chapter": f"starwrought:{chapter}", "category": category,
            "title": f"handbook.starwrought.entry.{entry}.title",
            "body": f"handbook.starwrought.entry.{entry}.body",
            "order": order, "unlock": unlock,
        })


def main():
    # Items
    star_item("star_shard")
    star_item("astrolabe", core=GOLD, arms=CYAN)
    star_item("codex_arcana", core=GOLD, arms=INDIGO)
    star_item("chart_wolf", core=(220, 80, 80, 255), arms=GOLD)
    star_item("chart_lyra", core=(120, 180, 255, 255), arms=CYAN)
    star_item("chart_anvil", core=(180, 180, 190, 255), arms=GOLD)
    star_item("starsteel_ingot", core=IRON, arms=CYAN)
    star_item("glimmer_dust", core=CYAN, arms=WHITE)
    star_item("glimmer_petal", core=(200, 120, 255, 255), arms=GOLD)
    star_item("hollow_residue", core=PURPLE, arms=VOID)
    star_item("zenith_core", core=GOLD, arms=WHITE)
    star_item("phase_flare", core=CYAN, arms=WHITE)
    star_item("wayband", core=INDIGO, arms=GOLD)
    star_item("comet_bow", core=CYAN, arms=INDIGO)
    for piece in ("helmet", "chestplate", "leggings", "boots", "sword", "pickaxe", "axe", "shovel", "hoe"):
        star_item(f"starsteel_{piece}", core=IRON, arms=CYAN)

    # Blocks
    cube_block("meteoric_stone", METEOR, VOID)
    cube_block("meteorite_core", INDIGO, CYAN)
    cube_block("resonance_altar", INDIGO, GOLD)
    cube_block("star_forge", (80, 50, 40, 255), CYAN)
    cube_block("lumen_lantern", GOLD, CYAN)
    cube_block("lumen_spire", CYAN, WHITE)
    cube_block("voidglass", PURPLE, INDIGO)
    cube_block("hollow_beacon", VOID, PURPLE)
    cube_block("astral_bloom", (40, 80, 60, 255), (180, 120, 255, 255))

    particle("prisma_spark", CYAN)
    particle("prisma_shard", GOLD)
    particle("hollow_mote", PURPLE)

    gui_panel()
    icon()
    generate_models()
    generate_lang()
    generate_data()
    print("Generated Starwrought procedural assets under", ASSETS)


if __name__ == "__main__":
    main()

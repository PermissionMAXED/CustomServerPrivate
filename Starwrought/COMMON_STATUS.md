# Starwrought Common/Server Status

- Fabric 1.21.9 common code, shared payloads, registries, attachments, celestial events, attunements,
  abilities, Star Forge, mobs/boss, handbook loader, recipes, advancements, models, loot, and EN/DE
  language data are implemented.
- `./gradlew compileJava test --no-daemon` passes; 4 pure-logic JUnit tests pass.
- Dedicated-server smoke reached `Done`: 1,487 recipes, 1,578 advancements, 4 handbook chapters, and
  15 handbook entries loaded without data errors.

Deliberate simple implementations:

- The Star Forge is a three-slot, block-interaction inventory rather than a furnace GUI.
- The Comet Bow subclasses the vanilla bow and boosts/glows arrows rather than adding a projectile type.
- A held Astrolabe reports a numeric bearing in the action bar; visual needle work remains client-side.

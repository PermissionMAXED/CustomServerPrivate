export const meta = {
  name: 'wf2-char-catalog-data',
  description: 'Search character catalog, data structures, definitions, configs — 10 agents',
  phases: [{ title: 'Search Catalog', detail: '10 agents searching character data pipeline' }]
}
phase('Search Catalog')

const SEARCHES = [
  { p: 'CharacterCatalog|characterCatalog|charCatalog|InitCatalog|LoadCatalog|characterData', l: 'catalog-def', w: 'CharacterCatalog definition, initialization, and usage' },
  { p: 'CharacterInfo|CharInfo|characterInfo|charInfo|CharacterData|CharData', l: 'char-struct', w: 'Character data structures and their fields' },
  { p: 'MapCatalog|mapCatalog|InitMapCatalog|mapList|MapList|mapData', l: 'map-catalog', w: 'MapCatalog and its relationship to characters' },
  { p: 'catalog.json|catalog_.*\\.json|character.*\\.json|chars\\.json', l: 'catalog-files', w: 'Catalog JSON files on disk' },
  { p: 'nameToId|NameToId|charNameToId|characterNameToId|GetIdByName|getIdByName', l: 'name-id-resolv', w: 'Name-to-ID resolution for characters' },
  { p: 'enum.*Character|CharacterEnum|CharId|charId.*=.*[0-9]|CharacterType', l: 'char-enums', w: 'Character enum definitions and ID constants' },
  { p: 'Medusa|medusa|charId.*15|character.*15', l: 'medusa-custom', w: 'Custom character (Medusa, id 15+) handling' },
  { p: 'DefaultCharacter|defaultChar|defaultCharacter|startingChar|startChar', l: 'default-char', w: 'Default character selection/assignment' },
  { p: 'customServerOptions.*[Cc]har|CustomServerOptions.*[Cc]har|[Cc]har.*customServerOptions', l: 'config-bind', w: 'Character config binding in CustomServerOptions' },
  { p: 'appsettings.*[Cc]har|char.*catalog|Char.*Catalog|catalogItem|catalogEntry', l: 'config-files', w: 'Character settings in appsettings.json and AMP configs' },
]

const results = await parallel(SEARCHES.map(s => () =>
  agent(`Search ALL files in C:\\Users\\Administrator\\Downloads\\CustomServer recursively for regex pattern "${s.p}" (case INSENSITIVE, multiline). Return EVERY match with file path, line number, the matching code line, and 5 lines of surrounding context. Check ALL file types (.cs, .json, .ps1, .ini, .kvp, .md, .txt, .sh). Focus especially on: CustomMatchServer/Program.cs, CustomMatchServer/CustomServerOptions.cs, CustomMatchServer/LobbyService.cs, CustomMatchServer/PlayerOverrides.cs, BapCustomServerMelon/CustomServerMod.cs, docs/, deployment/*.json, deployment/*.kvp, tests/, appsettings.json. Be EXHAUSTIVE - every single match matters.

For each match tell me: ${s.w}`, {
    label: s.l,
    schema: { type: 'object', properties: { findings: { type: 'array', items: { type: 'object', properties: { file: { type: 'string' }, line: { type: 'number' }, code: { type: 'string' }, context: { type: 'string' }, relevance: { type: 'string' } }, required: ['file', 'line', 'code'] } } }, required: ['findings'] }
  })
))

return { workflow: 'wf2-char-catalog-data', agentResults: results }

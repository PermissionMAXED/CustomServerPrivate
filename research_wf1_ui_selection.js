export const meta = {
  name: 'wf1-char-ui-selection',
  description: 'Search character selection UI, locked states, menu rendering — 10 agents',
  phases: [{ title: 'Search UI', detail: '10 agents searching character selection UI patterns' }]
}
phase('Search UI')

const SEARCHES = [
  { p: 'CharacterSelection|CharSelect|characterPanel|charPanel|customization', l: 'ui-components', w: 'UI component names for character selection screens' },
  { p: 'SelectCharacter|OnCharacterSelect|setCharacter|SetCharacter', l: 'char-select-calls', w: 'Character selection function calls and handlers' },
  { p: 'locked|isLocked|IsLocked|lockState|LOCKED|unlockCharacter', l: 'locked-states', w: 'Locked/unlocked state management for characters' },
  { p: 'BuildOwnedAssets|ownedChar|OwnedChar|characterOwned', l: 'owned-assets', w: 'Owned character asset list construction' },
  { p: 'AvailableCharacter|availableChar|characterList|CharacterList', l: 'char-lists', w: 'Available/selectable character list generation' },
  { p: 'SkinData.*Asset|AssetId.*300|skinId|SkinId', l: 'skin-assets', w: 'Skin asset IDs (300001/300004/300006 crash issue)' },
  { p: 'devPanel|DevPanel|AllowDevPanel|dev_panel|devPanelCharacter', l: 'dev-panel', w: 'Developer panel character overrides' },
  { p: 'characterButton|charButton|characterSlot|characterEntry|charEntry', l: 'ui-slots', w: 'Character UI slot/button rendering' },
  { p: 'OnCharacterClick|CharacterClick|characterClick|onCharSelect', l: 'click-hndl', w: 'Character click handler logic and conditions' },
  { p: 'characterState|CharacterState|charState|CharState|currentCharIndex', l: 'state-mgmt', w: 'Character state tracking in UI flow' },
]

const results = await parallel(SEARCHES.map(s => () =>
  agent(`Search ALL files in C:\\Users\\Administrator\\Downloads\\CustomServer recursively for regex pattern "${s.p}" (case INSENSITIVE, multiline). Return EVERY match with file path, line number, the matching code line, and 5 lines of surrounding context for CONTEXT. Check .cs, .json, .ps1, .ini, .kvp, .md, .txt, .sh files. Focus especially on: CustomMatchServer/Program.cs, CustomMatchServer/LobbyService.cs, CustomMatchServer/PlayerOverrides.cs, CustomMatchServer/EconomyService.cs, BapCustomServerMelon/CustomServerMod.cs, BapCustomServerMelon/LocalReverseProxy.cs, tests/, deployment/, tools/. Be EXHAUSTIVE - every single match matters.

Return ALL findings grouped by file. For each match tell me: ${s.w}`, {
    label: s.l,
    schema: { type: 'object', properties: { findings: { type: 'array', items: { type: 'object', properties: { file: { type: 'string' }, line: { type: 'number' }, code: { type: 'string' }, context: { type: 'string' }, relevance: { type: 'string' } }, required: ['file', 'line', 'code'] } } }, required: ['findings'] }
  })
))

return { workflow: 'wf1-char-ui-selection', agentResults: results }

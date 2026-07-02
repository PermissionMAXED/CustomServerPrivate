export const meta = {
  name: 'wf3-char-unlock-economy',
  description: 'Search unlock logic, PlayerOverrides, economy, permissions — 10 agents',
  phases: [{ title: 'Search Unlocks', detail: '10 agents searching character unlock/economy logic' }]
}
phase('Search Unlocks')

const SEARCHES = [
  { p: 'PlayerOverrides|playerOverrides|player_override|PlayerOverride', l: 'player-overrides', w: 'PlayerOverrides system for character unlocks' },
  { p: 'EconomyService|economyService|Economy|AddGold|GetGold|spendGold|purchaseItem', l: 'economy-svc', w: 'EconomyService character purchase/economy logic' },
  { p: 'ShopService|shopService|ShopItem|shopItem|shopEntries|shopCatalog', l: 'shop-svc', w: 'ShopService character-related items for sale' },
  { p: 'ServerAdminService|AdminService|AdminAccount|grantChar|grantItem|GrantCharacter|UnlockCharacter', l: 'admin-svc', w: 'Admin unlock/grant operations for characters' },
  { p: 'PlayerStorageService|playerStorage|PlayerData|playerData|LoadPlayer|SavePlayer|playerFile', l: 'player-storage', w: 'PlayerStorageService character state persistence' },
  { p: 'LobbyService.*[Cc]har|[Cc]har.*LobbyService|HandleSocket.*char|char.*HandleSocket|JoinLobby|UpdateCustom', l: 'lobby-char', w: 'LobbyService character handling in WS flow' },
  { p: 'FriendsService|RankedService|MatchHistoryService|Matchmaking', l: 'other-svcs', w: 'Other services that might affect character state' },
  { p: 'authenticate|Authenticate|login|Login|guestId|GuestId|sessionId|SessionId', l: 'auth-flow', w: 'Authentication flow that sets up character identity' },
  { p: 'unlockAll|UnlockAll|allUnlocked|allCharacters|allChars|giveAll|unlockall', l: 'unlock-all', w: 'Unlock-all / give-all flags for characters' },
  { p: 'isAdmin|IsAdmin|admin.*char|admin.*character|hasPermission|permission.*char', l: 'admin-perms', w: 'Admin permission checks for character operations' },
]

const results = await parallel(SEARCHES.map(s => () =>
  agent(`Search ALL files in C:\\Users\\Administrator\\Downloads\\CustomServer recursively for regex pattern "${s.p}" (case INSENSITIVE, multiline). Return EVERY match with file path, line number, the matching code line, and 5 lines of surrounding context for CONTEXT. Check ALL file types (.cs, .json, .ps1, .ini, .kvp, .md, .txt, .sh). Focus especially on: CustomMatchServer/Program.cs, CustomMatchServer/EconomyService.cs, CustomMatchServer/PlayerOverrides.cs, CustomMatchServer/LobbyService.cs, CustomMatchServer/ShopService.cs, CustomMatchServer/MatchmakingQueueService.cs, CustomMatchServer/MatchmakingHostedService.cs, CustomMatchServer/CharacterUnlockService.cs, CustomMatchServer/ServerAdminService.cs, CustomMatchServer/FriendsService.cs, BapCustomServerMelon/CustomServerMod.cs. Be EXHAUSTIVE - every single match matters.

For each match tell me: ${s.w}`, {
    label: s.l,
    schema: { type: 'object', properties: { findings: { type: 'array', items: { type: 'object', properties: { file: { type: 'string' }, line: { type: 'number' }, code: { type: 'string' }, context: { type: 'string' }, relevance: { type: 'string' } }, required: ['file', 'line', 'code'] } } }, required: ['findings'] }
  })
))

return { workflow: 'wf3-char-unlock-economy', agentResults: results }

export const meta = {
  name: 'wf3-server-contract',
  description: 'Server contract vs client expectations',
  phases: [{title: 'DTO'}, {title: 'Proxy'}, {title: 'Gaps'}, {title: 'Tests'}, {title: 'Verdict'}],
}
phase('DTO')
await agent('Read AssetRip LoadResponse.cs. List ALL properties. Compare with Program.cs BuildLoadResponse output. Are any fields missing or mismatched? Is there an ownedCharacters or unlockedCharacters field the client expects? Output JSON: {missingFields:[],gaps:[{serverField:string,clientField:string,issue:string}]}', {schema:{type:'object',properties:{missingFields:{type:'array',items:{type:'string'}},gaps:{type:'array',items:{type:'object',properties:{serverField:{type:'string'},clientField:{type:'string'},issue:{type:'string'}}}}},required:['missingFields','gaps']}})
phase('Proxy')
await agent('Read LocalReverseProxy.cs. Does it rewrite any HTTP responses? Could it add fields to /api/load or /api/chars/listing responses before the native client parses them? Output JSON: {rewritesHttpResponses:bool,canModifyCharData:bool,currentRewrites:[string]}', {schema:{type:'object',properties:{rewritesHttpResponses:{type:'boolean'},canModifyCharData:{type:'boolean'},currentRewrites:{type:'array',items:{type:'string'}}},required:['rewritesHttpResponses','canModifyCharData']}})
phase('Gaps')
await agent('Compare the FULL schema of AssetRip CharListingResponse.cs with Program.cs MinimalCharacterListing / BuildCharacterListings output. Are field names, types, or conventions mismatched? Specifically check: purchases (0=locked vs 0=owned), costs, rewards structure. Output JSON: {mismatches:[{field:string,serverSends:string,clientExpects:string,severity:string}]}', {schema:{type:'object',properties:{mismatches:{type:'array',items:{type:'object',properties:{field:{type:'string'},serverSends:{type:'string'},clientExpects:{type:'string'},severity:{type:'string'}}}}},required:['mismatches']}})
phase('Tests')
await agent('Read tests/BapCustomServer.Tests/EndpointIntegrationTests.cs. Find tests for /api/chars/listing and /api/load. Are there tests that verify response shapes against AssetRip DTOs? What new tests would catch contract mismatches? Output JSON: {existingCharTests:[string],testGap:string,suggestedTest:string}', {schema:{type:'object',properties:{existingCharTests:{type:'array',items:{type:'string'}},testGap:{type:'string'},suggestedTest:{type:'string'}},required:['testGap']}})
phase('Verdict')
await agent('Given all evidence: server already sends availableCharacters, purchases=1, unlock assets 100000+charId. Yet chars still locked. Is this a server contract issue or a mod/client issue? Can server-only fix work? Output JSON: {serverOnlyPossible:bool,reason:string,modFixRequired:bool}', {schema:{type:'object',properties:{serverOnlyPossible:{type:'boolean'},reason:{type:'string'},modFixRequired:{type:'boolean'}},required:['serverOnlyPossible','reason','modFixRequired']}})

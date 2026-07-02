export const meta = {
  name: 'wf1-il2cpp',
  description: 'IL2CPP Harmony root cause analysis',
  phases: [{title: 'FindType'}, {title: 'Harmony'}, {title: 'IL2CPP'}, {title: 'Alternative'}, {title: 'Fix'}],
}
phase('FindType')
await agent('Read BapCustomServerMelon/CustomServerMod.cs. Find FindType(). How does it search types? Does it handle Il2Cpp prefix? Why might UICharactersConfiguration not be found? Output as JSON: {searchStrategies:[],handlesIl2CppPrefix:bool,likelyFailureReason:string}', {schema:{type:'object',properties:{searchStrategies:{type:'array',items:{type:'string'}},handlesIl2CppPrefix:{type:'boolean'},likelyFailureReason:{type:'string'}},required:['handlesIl2CppPrefix','likelyFailureReason']}})
phase('Harmony')
await agent('Search the entire AssetRip dir for TryGetLobbyCharConfigByIndex method. Does the stub file have this method? Does it have a mangled name? Is reflection likely to find it? Output JSON: {foundInStubs:bool,mangledName:string,reflectionSearchWorks:bool}', {schema:{type:'object',properties:{foundInStubs:{type:'boolean'},mangledName:{type:'string'},reflectionSearchWorks:{type:'boolean'}},required:['foundInStubs','reflectionSearchWorks']}})
phase('IL2CPP')
await agent('Why would MethodInfo.GetMethod on an IL2CPP type fail? Do stub methods get generated as managed wrappers? Explain known Il2CppInterop limitations with method resolution. Output JSON: {methodsExposed:string,knownIssue:string,likelyExplanation:string}', {schema:{type:'object',properties:{methodsExposed:{type:'string'},knownIssue:{type:'string'},likelyExplanation:{type:'string'}},required:['likelyExplanation']}})
phase('Alternative')
await agent('Read CustomServerMod.cs. List ALL successfully installed Harmony patches. Why do those work? Identify safer hooks that dont depend on UICharactersConfiguration. Which CharacterPageModel methods definitely exist? Output JSON: {workingPatches:[{method:string,reasonWorks:string}],recommendedHooks:[{method:string,rationale:string}]}', {schema:{type:'object',properties:{workingPatches:{type:'array',items:{type:'object',properties:{method:{type:'string'},reasonWorks:{type:'string'}}}},recommendedHooks:{type:'array',items:{type:'object',properties:{method:{type:'string'},rationale:{type:'string'}}}}},required:['workingPatches','recommendedHooks']}})
phase('Fix')
await agent('Score these approaches 1-10 for feasibility/reliability: A) Hook CharacterPageModel init, B) Hook UILobby.Build postfix, C) Resources.FindObjectsOfTypeAll with Il2CppSystem.Type, D) Hook LoginController+CharSelectController, E) Server response rewrite. Pick top, give pseudocode. Output JSON: {topOption:string,score:int,codeOutline:string}', {schema:{type:'object',properties:{topOption:{type:'string'},score:{type:'integer'},codeOutline:{type:'string'}},required:['topOption','codeOutline']}})

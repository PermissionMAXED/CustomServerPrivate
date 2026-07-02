export const meta = {
  name: 'wf2-char-model',
  description: 'Direct CharacterPageModel population approach',
  phases: [{title: 'Anatomy'}, {title: 'ExistingPatches'}, {title: 'BuildPostfix'}, {title: 'Il2CppAccess'}, {title: 'Plan'}],
}
phase('Anatomy')
await agent('Read AssetRip/CharacterPageModel.cs. List ALL fields. How is unlockedCharacters populated? How is availableCharacters populated? Does it reference UICharactersConfiguration? Are fields directly settable? Output JSON: {fields:[{name:string,type:string}],referencesUICharsConfig:bool,directSettable:bool,unlockedCharsSource:string}', {schema:{type:'object',properties:{fields:{type:'array',items:{type:'object',properties:{name:{type:'string'},type:{type:'string'}}}},directSettable:{type:'boolean'},unlockedCharsSource:{type:'string'}},required:['directSettable','unlockedCharsSource']}})
phase('ExistingPatches')
await agent('Search CustomServerMod.cs for ALL references to CharacterPageModel, charListings, unlockedCharacters, availableCharacters, CharListing, HandleCharListingResponse. Report each harmony touchpoint. Output JSON: {touchPoints:[{methodName:string,action:string,works:bool}]}', {schema:{type:'object',properties:{touchPoints:{type:'array',items:{type:'object',properties:{methodName:{type:'string'},action:{type:'string'},works:{type:'boolean'}}}}},required:['touchPoints']}})
phase('BuildPostfix')
await agent('Search CustomServerMod.cs for UILobby, LobbyController, Build references. Can we hook UILobby.Build postfix to: 1) detect crash, 2) manually create/populate CharacterPageModel, 3) call HandleUpdateAvailableCharacterList? Output JSON: {canBypass:bool,recoveryMethod:string,keyMethod:string}', {schema:{type:'object',properties:{canBypass:{type:'boolean'},recoveryMethod:{type:'string'},keyMethod:{type:'string'}},required:['canBypass','recoveryMethod']}})
phase('Il2CppAccess')
await agent('Search for AddUnlockCharacter or UnlockCharacter across whole codebase. Also check if CustomServerMod uses Il2CppObjectBase or IntPtr field access. Is there a native unlock method callable via interop? Output JSON: {hasDirectAccess:bool,nativeUnlockMethod:string,recommendedApproach:string}', {schema:{type:'object',properties:{hasDirectAccess:{type:'boolean'},nativeUnlockMethod:{type:'string'},recommendedApproach:{type:'string'}},required:['hasDirectAccess','recommendedApproach']}})
phase('Plan')
await agent('Write a concrete plan: exact code changes to CustomServerMod.cs. Target CharacterPageModel directly (not UICharactersConfiguration). Write pseudocode. Include hook target, new method name. Output JSON: {approach:string,hookTarget:string,pseudocode:string}', {schema:{type:'object',properties:{approach:{type:'string'},hookTarget:{type:'string'},pseudocode:{type:'string'}},required:['approach','hookTarget','pseudocode']}})

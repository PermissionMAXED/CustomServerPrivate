using System;
using BAPBAP.ModAPI;
using HarmonyLib;
using MelonLoader;

namespace BAPBAP.Medusa;

public sealed class MedusaMelon : MelonMod
{
	private readonly MedusaMod _mod = new MedusaMod();

	internal static HarmonyLib.Harmony? SharedHarmony;

	public override void OnInitializeMelon()
	{
		SharedHarmony = ((MelonBase)this).HarmonyInstance;
		((ModBase)_mod).Register(((MelonBase)this).LoggerInstance);
		try
		{
			SharedHarmony.PatchAll(typeof(MedusaMod.CharAnimatorRebindPatch));
			SharedHarmony.PatchAll(typeof(MedusaMod.CharFootstepsRebindPatch));
			((MelonBase)this).LoggerInstance.Msg("[Medusa] Harmony rebind patches installed (CharAnimator.Awake + CharFootsteps.Awake postfixes).");
		}
		catch (Exception value)
		{
			((MelonBase)this).LoggerInstance.Warning($"[Medusa] Harmony PatchAll failed (rebind safety-net disabled): {value}");
		}
		int uiPatchOk = 0;
		int uiPatchFailed = 0;
		int uiPatchSkipped = 0;
		SkipUi("LobbyCharacterPageBuildPatch");
		PatchUi(typeof(MedusaMod.DebugLogFilterPatch), "DebugLogFilterPatch");
		SkipUi("LobbyCharacterPageInitialisePatch");
		SkipUi("LobbyCharacterPageUpdateDataPatch");
		SkipUi("LobbyCharacterPageUpdateAvailablePatch");
		SkipUi("LobbyCharacterPageOpenPatch");
		PatchUi(typeof(MedusaMod.LobbyCharacterPageOnOpenPatch), "LobbyCharacterPageOnOpenPatch");
		PatchUi(typeof(MedusaMod.LobbyCharacterIsSelectablePatch), "LobbyCharacterIsSelectablePatch");
		SkipUi("LobbyCharacterIsUnlockedPatch");
		PatchUi(typeof(MedusaMod.LobbyCharacterIsInRotationPatch), "LobbyCharacterIsInRotationPatch");
		PatchUi(typeof(MedusaMod.LobbySetUnlockButtonActiveStatePatch), "LobbySetUnlockButtonActiveStatePatch");
		SkipUi("MatchCharacterPageBuildPatch");
		SkipUi("MatchCharacterPageInitialisePatch");
		PatchUi(typeof(MedusaMod.MatchCharacterPageSetActionsPatch), "MatchCharacterPageSetActionsPatch");
		SkipUi("MatchCharacterPageUpdateDataPatch");
		SkipUi("MatchCharacterPageUpdateAvailablePatch");
		PatchUi(typeof(MedusaMod.MatchCharacterPageOpenPatch), "MatchCharacterPageOpenPatch");
		PatchUi(typeof(MedusaMod.MatchCharacterPageGetCharIndexPatch), "MatchCharacterPageGetCharIndexPatch");
		PatchUi(typeof(MedusaMod.MatchCharacterButtonSelectPatch), "MatchCharacterButtonSelectPatch");
		PatchUi(typeof(MedusaMod.MatchCharacterLockButtonPatch), "MatchCharacterLockButtonPatch");
		PatchUi(typeof(MedusaMod.UIPreMatchPopulatePatch), "UIPreMatchPopulatePatch");
		PatchUi(typeof(MedusaMod.UIPreMatchUpdatePatch), "UIPreMatchUpdatePatch");
		PatchUi(typeof(MedusaMod.UIPreMatchOpenCharacterSelectPatch), "UIPreMatchOpenCharacterSelectPatch");
		PatchUi(typeof(MedusaMod.UIPreMatchSetLocalPlayerCharacterPatch), "UIPreMatchSetLocalPlayerCharacterPatch");
		PatchUi(typeof(MedusaMod.ViewPreMatchCharSelectInitializePatch), "ViewPreMatchCharSelectInitializePatch");
		PatchUi(typeof(MedusaMod.ViewPreMatchCharSelectPopulatePatch), "ViewPreMatchCharSelectPopulatePatch");
		PatchUi(typeof(MedusaMod.ViewPreMatchCharSelectSetDisplayedPatch), "ViewPreMatchCharSelectSetDisplayedPatch");
		PatchUi(typeof(MedusaMod.ViewPreMatchCharSelectGetCharIndexPatch), "ViewPreMatchCharSelectGetCharIndexPatch");
		PatchUi(typeof(MedusaMod.PlayerPreMatchInitializePatch), "PlayerPreMatchInitializePatch");
		PatchUi(typeof(MedusaMod.PlayerPreMatchCmdTrySelectCharacterPatch), "PlayerPreMatchCmdTrySelectCharacterPatch");
		PatchUi(typeof(MedusaMod.PlayerPreMatchUserCodeTrySelectCharacterPatch), "PlayerPreMatchUserCodeTrySelectCharacterPatch");
		PatchUi(typeof(MedusaMod.PlayerPreMatchCmdTryLockCharacterPatch), "PlayerPreMatchCmdTryLockCharacterPatch");
		PatchUi(typeof(MedusaMod.PlayerPreMatchUserCodeTryLockCharacterPatch), "PlayerPreMatchUserCodeTryLockCharacterPatch");
		PatchUi(typeof(MedusaMod.PlayerPreMatchSetPlayerCharacterPatch), "PlayerPreMatchSetPlayerCharacterPatch");
		PatchUi(typeof(MedusaMod.PlayerPreMatchSetTeammateCharacterPatch), "PlayerPreMatchSetTeammateCharacterPatch");
		PatchUi(typeof(MedusaMod.PreMatchManagerTrySelectCharacterPatch), "PreMatchManagerTrySelectCharacterPatch");
		PatchUi(typeof(MedusaMod.PreMatchManagerAssignCharactersPatch), "PreMatchManagerAssignCharactersPatch");
		PatchUi(typeof(MedusaMod.GameModeSpawnPlayerCharPatch), "GameModeSpawnPlayerCharPatch");
		PatchUi(typeof(MedusaMod.GameNetworkManagerAwakePatch), "GameNetworkManagerAwakePatch");
		PatchUi(typeof(MedusaMod.GameNetworkManagerOnStartServerPatch), "GameNetworkManagerOnStartServerPatch");
		PatchUi(typeof(MedusaMod.GameNetworkManagerOnServerQueueMatchedPatch), "GameNetworkManagerOnServerQueueMatchedPatch");
		PatchUi(typeof(MedusaMod.GameNetworkManagerOnServerMatchAddTeamsPatch), "GameNetworkManagerOnServerMatchAddTeamsPatch");
		PatchUi(typeof(MedusaMod.GameNetworkManagerGetCharacterBotPrefabPatch), "GameNetworkManagerGetCharacterBotPrefabPatch");
		PatchUi(typeof(MedusaMod.PlayerManagerCharacterChangedPatch), "PlayerManagerCharacterChangedPatch");
		PatchUi(typeof(MedusaMod.EntityManagerStartPatch), "EntityManagerStartPatch");
		PatchUi(typeof(MedusaMod.EntityManagerOnStartClientPatch), "EntityManagerOnStartClientPatch");
		PatchUi(typeof(MedusaMod.CharAbilitiesPreAwakePatch), "CharAbilitiesPreAwakePatch");
		PatchUi(typeof(MedusaMod.AbilityLoadUiPatch), "AbilityLoadUiPatch");
		PatchUi(typeof(MedusaMod.MedusaAbilityTooltipDescriptionPatch), "MedusaAbilityTooltipDescriptionPatch");
		PatchUi(typeof(MedusaMod.MedusaAbilityTooltipExpandedDescriptionPatch), "MedusaAbilityTooltipExpandedDescriptionPatch");
		PatchUi(typeof(MedusaMod.UIAbilitiesShowAbilityTooltipPatch), "UIAbilitiesShowAbilityTooltipPatch");
		PatchUi(typeof(MedusaMod.UIAbilityElementLoadIconConfigPatch), "UIAbilityElementLoadIconConfigPatch");
		PatchUi(typeof(MedusaMod.UIAbilityElementLoadIconDirectPatch), "UIAbilityElementLoadIconDirectPatch");
		PatchUi(typeof(MedusaMod.MedusaAbilitySetStatePatch), "MedusaAbilitySetStatePatch");
		PatchUi(typeof(MedusaMod.MedusaCatShotShootPatch), "MedusaCatShotShootPatch");
		PatchUi(typeof(MedusaMod.MedusaCatMissileShootPatch), "MedusaCatMissileShootPatch");
		PatchUi(typeof(MedusaMod.MedusaCatPolymorphShootPatch), "MedusaCatPolymorphShootPatch");
		PatchUi(typeof(MedusaMod.MedusaCatJumpShootPatch), "MedusaCatJumpShootPatch");
		PatchUi(typeof(MedusaMod.MinimapAddIconOnPosByNetIdPatch), "MinimapAddIconOnPosByNetIdPatch");
		SkipUi("LobbyPlayTabBuildPatch");
		SkipUi("LobbyPlayTabInitialisePatch");
		SkipUi("LobbyPlayTabUpdateDataPatch");
		PatchUi(typeof(MedusaMod.UiManagerPreAwakePatch), "UiManagerPreAwakePatch");
		PatchUi(typeof(MedusaMod.UiManagerAwakePatch), "UiManagerAwakePatch");
		((MelonBase)this).LoggerInstance.Msg($"[Medusa] Harmony UI/prematch patches installed: ok={uiPatchOk}, failed={uiPatchFailed}, skipped={uiPatchSkipped}.");
		if (uiPatchSkipped > 0)
		{
			((MelonBase)this).LoggerInstance.Msg("[Medusa] Skipped known IL2CPP page-warmup prefixes; runtime UIManager, prematch, selection, spawn, and ability patches remain active.");
		}
		try
		{
			SharedHarmony.PatchAll(typeof(MedusaMod.HitboxDoEntityHitPetrifyPatch));
			((MelonBase)this).LoggerInstance.Msg("[Medusa] Harmony status-on-hit patch installed (HitboxBase.OnHitSuccess postfix: poison + petrify).");
		}
		catch (Exception value2)
		{
			((MelonBase)this).LoggerInstance.Warning($"[Medusa] Harmony status-on-hit PatchAll failed: {value2}");
		}
		void PatchUi(Type type, string name)
		{
			try
			{
				SharedHarmony.PatchAll(type);
				uiPatchOk++;
			}
			catch (Exception ex)
			{
				uiPatchFailed++;
				((MelonBase)this).LoggerInstance.Warning($"[Medusa] Harmony patch '{name}' failed: {ex.GetType().Name}: {ex.Message}");
			}
		}

		void SkipUi(string name)
		{
			uiPatchSkipped++;
		}
	}
}

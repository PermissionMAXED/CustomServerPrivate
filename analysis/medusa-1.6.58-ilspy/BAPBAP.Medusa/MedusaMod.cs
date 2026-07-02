using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using BAPBAP.ModAPI;
using BAPBAP.ModAPI.API;
using BAPBAP.ModAPI.Events;
using BAPBAP.ModAPI.Mirror;
using HarmonyLib;
using Il2CppBAPBAP.Entities;
using Il2CppBAPBAP.Entities.View;
using Il2CppBAPBAP.Game;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Localisation;
using Il2CppBAPBAP.Network;
using Il2CppBAPBAP.Player;
using Il2CppBAPBAP.Pooling;
using Il2CppBAPBAP.UI;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppMirror;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Reflection;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace BAPBAP.Medusa;

public sealed class MedusaMod : ModBase
{
	[HarmonyPatch]
	public static class DebugLogFilterPatch
	{
		[HarmonyTargetMethods]
		public static IEnumerable<MethodBase> TargetMethods()
		{
			MethodInfo[] methods = typeof(DebugLogHandler).GetMethods(BindingFlags.Instance | BindingFlags.Public);
			foreach (MethodInfo methodInfo in methods)
			{
				if (methodInfo.Name == "LogFormat")
				{
					yield return methodInfo;
				}
			}
		}

		[HarmonyPrefix]
		[HarmonyPriority(800)]
		public static bool Prefix(object[] __args)
		{
			return !ContainsBlockedUnityLog(__args, 0);
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "Build")]
	public static class LobbyCharacterPageBuildPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyCharacterSelectPage __instance)
		{
			EnsureRegisteredForUi("UILobbyCharacterSelectPage.Build");
			EnsureLobbyCharacterPageDataAvailable(__instance, "UILobbyCharacterSelectPage.Build");
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "Initialise")]
	public static class LobbyCharacterPageInitialisePatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyCharacterSelectPage __instance, CharacterPageModel data)
		{
			EnsureRegisteredForUi("UILobbyCharacterSelectPage.Initialise");
			ForceCharacterPageModelUnlocked(data, "UILobbyCharacterSelectPage.Initialise");
			if ((Object)(object)__instance != (Object)null && data != null)
			{
				__instance._data = data;
			}
			EnsureLobbyCharacterPageDataAvailable(__instance, "UILobbyCharacterSelectPage.Initialise");
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "UpdateData")]
	public static class LobbyCharacterPageUpdateDataPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyCharacterSelectPage __instance, CharacterPageModel data)
		{
			EnsureRegisteredForUi("UILobbyCharacterSelectPage.UpdateData");
			ForceCharacterPageModelUnlocked(data, "UILobbyCharacterSelectPage.UpdateData");
			if ((Object)(object)__instance != (Object)null && data != null)
			{
				__instance._data = data;
			}
			EnsureLobbyCharacterPageDataAvailable(__instance, "UILobbyCharacterSelectPage.UpdateData");
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "UpdateAvailableCharactersData")]
	public static class LobbyCharacterPageUpdateAvailablePatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyCharacterSelectPage __instance)
		{
			EnsureRegisteredForUi("UILobbyCharacterSelectPage.UpdateAvailableCharactersData");
			EnsureLobbyCharacterPageDataAvailable(__instance, "UILobbyCharacterSelectPage.UpdateAvailableCharactersData");
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "OpenCharSelectPanel")]
	public static class LobbyCharacterPageOpenPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyCharacterSelectPage __instance)
		{
			EnsureRegisteredForUi("UILobbyCharacterSelectPage.OpenCharSelectPanel");
			EnsureLobbyCharacterPageDataAvailable(__instance, "UILobbyCharacterSelectPage.OpenCharSelectPanel");
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "OnPageOpen")]
	public static class LobbyCharacterPageOnOpenPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyCharacterSelectPage __instance)
		{
			EnsureRegisteredForUi("UILobbyCharacterSelectPage.OnPageOpen");
			EnsureLobbyCharacterPageDataAvailable(__instance, "UILobbyCharacterSelectPage.OnPageOpen");
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "CharacterIsSelectable")]
	public static class LobbyCharacterIsSelectablePatch
	{
		[HarmonyPrefix]
		public static bool Prefix(int charId, ref bool __result)
		{
			if (!IsMedusaId(charId))
			{
				return true;
			}
			__result = true;
			return false;
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "CharacterIsUnlocked")]
	public static class LobbyCharacterIsUnlockedPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(int charId, ref bool __result)
		{
			__result = true;
			return false;
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "CharacterIsInRotation")]
	public static class LobbyCharacterIsInRotationPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(int charId, ref bool __result)
		{
			__result = true;
			return false;
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "SetUnlockButtonActiveState")]
	public static class LobbySetUnlockButtonActiveStatePatch
	{
		[HarmonyPrefix]
		public static bool Prefix(UILobbyCharacterSelectPage __instance, int charId)
		{
			if (!IsMedusaId(charId))
			{
				return true;
			}
			try
			{
				__instance.HideUnlockButton();
			}
			catch
			{
			}
			return false;
		}
	}

	[HarmonyPatch(typeof(UILobbyCharacterSelectPage), "GetCharacterListingIndexFromCharId")]
	public static class LobbyCharacterListingIndexPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(UILobbyCharacterSelectPage __instance, int charId, ref int __result)
		{
			if (TryGetLobbyCharacterListingIndex(__instance, charId, out var index))
			{
				__result = index;
				if (_lobbyListingIndexLogCount < 12)
				{
					_lobbyListingIndexLogCount++;
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] lobby listing index resolved safely: charId={charId} index={index}.");
					}
				}
				return false;
			}
			__result = -1;
			if (_lobbyListingIndexLogCount < 12)
			{
				_lobbyListingIndexLogCount++;
				MedusaMod instance2 = _instance;
				if (instance2 != null)
				{
					((ModBase)instance2).Log.Warn($"[Medusa] lobby listing index missing for charId={charId}; returning -1 to avoid native NullReference.");
				}
			}
			return false;
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "Build")]
	public static class MatchCharacterPageBuildPatch
	{
		[HarmonyPrefix]
		public static void Prefix(Configuration configuration)
		{
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Expected O, but got Unknown
			try
			{
				EnsureRegisteredForUi("UILobbyMatchCharacterSelectPage.Build");
				if (_instance != null && (Object)((configuration != null) ? configuration.CharacterConfiguration : null) != (Object)null)
				{
					_instance.TryRegisterMedusa(configuration.CharacterConfiguration);
					_instance.MakeRosterAvailable(configuration.CharacterConfiguration);
				}
			}
			catch (Exception ex)
			{
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Warn("[Medusa] match select Build bridge failed: " + ex.Message);
				}
			}
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "Initialise")]
	public static class MatchCharacterPageInitialisePatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyMatchCharacterSelectPage __instance, CharacterSelectModel data)
		{
			EnsureRegisteredForMatchPage(__instance, "UILobbyMatchCharacterSelectPage.Initialise");
			ForceMatchCharacterSelectModelAvailable(data, "UILobbyMatchCharacterSelectPage.Initialise");
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "SetActions")]
	public static class MatchCharacterPageSetActionsPatch
	{
		[HarmonyPostfix]
		public static void Postfix(UILobbyMatchCharacterSelectPage __instance)
		{
			EnsureRegisteredForMatchPage(__instance, "UILobbyMatchCharacterSelectPage.SetActions");
			if (_matchSelectLogCount >= 12)
			{
				return;
			}
			_matchSelectLogCount++;
			MedusaMod instance = _instance;
			if (instance != null)
			{
				ModLogger log = ((ModBase)instance).Log;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(58, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[Medusa] match select actions ready: select=");
				object obj;
				if ((Object)(object)__instance == (Object)null)
				{
					obj = null;
				}
				else
				{
					Actions actions = __instance._actions;
					obj = ((actions != null) ? actions.SelectCharAction : null);
				}
				defaultInterpolatedStringHandler.AppendFormatted((object)(Delegate)obj != null);
				defaultInterpolatedStringHandler.AppendLiteral(" lock=");
				object obj2;
				if ((Object)(object)__instance == (Object)null)
				{
					obj2 = null;
				}
				else
				{
					Actions actions2 = __instance._actions;
					obj2 = ((actions2 != null) ? actions2.LockCharAction : null);
				}
				defaultInterpolatedStringHandler.AppendFormatted((object)(Delegate)obj2 != null);
				defaultInterpolatedStringHandler.AppendLiteral(" spawn=");
				object obj3;
				if ((Object)(object)__instance == (Object)null)
				{
					obj3 = null;
				}
				else
				{
					Actions actions3 = __instance._actions;
					obj3 = ((actions3 != null) ? actions3.SpawnSelectAction : null);
				}
				defaultInterpolatedStringHandler.AppendFormatted((object)(Delegate)obj3 != null);
				defaultInterpolatedStringHandler.AppendLiteral(".");
				log.Info(defaultInterpolatedStringHandler.ToStringAndClear());
			}
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "UpdateData")]
	public static class MatchCharacterPageUpdateDataPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyMatchCharacterSelectPage __instance, CharacterSelectModel data)
		{
			EnsureRegisteredForMatchPage(__instance, "UILobbyMatchCharacterSelectPage.UpdateData");
			ForceMatchCharacterSelectModelAvailable(data, "UILobbyMatchCharacterSelectPage.UpdateData");
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "UpdateAvailableCharactersData")]
	public static class MatchCharacterPageUpdateAvailablePatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyMatchCharacterSelectPage __instance)
		{
			EnsureRegisteredForMatchPage(__instance, "UILobbyMatchCharacterSelectPage.UpdateAvailableCharactersData");
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "OpenCharacterSelect")]
	public static class MatchCharacterPageOpenPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyMatchCharacterSelectPage __instance)
		{
			EnsureRegisteredForMatchPage(__instance, "UILobbyMatchCharacterSelectPage.OpenCharacterSelect");
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "GetCharIndexByID")]
	public static class MatchCharacterPageGetCharIndexPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(int charID, ref int __result)
		{
			if (!IsMedusaId(charID))
			{
				return true;
			}
			__result = FindCharacterConfigIndex(charID);
			if (_matchSelectLogCount < 12)
			{
				_matchSelectLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] match select GetCharIndexByID({charID}) -> {__result}.");
				}
			}
			return false;
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "OnCharacterButtonSelect")]
	public static class MatchCharacterButtonSelectPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyMatchCharacterSelectPage __instance, UILobbyCharacterSelectIcon icon, int lobbyCharIndex)
		{
			EnsureRegisteredForMatchPage(__instance, "UILobbyMatchCharacterSelectPage.OnCharacterButtonSelect");
			int matchDataCharacterId = GetMatchDataCharacterId(__instance, lobbyCharIndex);
			if (IsMedusaId(matchDataCharacterId))
			{
				RememberExplicitMedusaSelection("UILobbyMatchCharacterSelectPage.OnCharacterButtonSelect");
				ScheduleMedusaSelection("UILobbyMatchCharacterSelectPage.OnCharacterButtonSelect.explicit", lockAfter: false);
			}
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] match character button selected: index={lobbyCharIndex} charId={matchDataCharacterId} isMedusa={IsMedusaId(matchDataCharacterId)}.");
			}
		}
	}

	[HarmonyPatch(typeof(UILobbyMatchCharacterSelectPage), "OnCharacterLockButtonSelect")]
	public static class MatchCharacterLockButtonPatch
	{
		[HarmonyPrefix]
		public static void Prefix(UILobbyMatchCharacterSelectPage __instance)
		{
			EnsureRegisteredForMatchPage(__instance, "UILobbyMatchCharacterSelectPage.OnCharacterLockButtonSelect");
			int num = (((Object)(object)__instance != (Object)null) ? __instance._selectedCharIndex : (-1));
			int matchDataCharacterId = GetMatchDataCharacterId(__instance, num);
			if (IsMedusaId(matchDataCharacterId))
			{
				RememberExplicitMedusaSelection("UILobbyMatchCharacterSelectPage.OnCharacterLockButtonSelect");
				ScheduleMedusaSelection("UILobbyMatchCharacterSelectPage.OnCharacterLockButtonSelect.explicit", lockAfter: true);
			}
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] match character lock pressed: selectedIndex={num} charId={matchDataCharacterId} isMedusa={IsMedusaId(matchDataCharacterId)}.");
			}
		}
	}

	[HarmonyPatch(typeof(UILobbyPlayTabPage), "Build")]
	public static class LobbyPlayTabBuildPatch
	{
		[HarmonyPrefix]
		public static void Prefix()
		{
			EnsureRegisteredForUi("UILobbyPlayTabPage.Build");
		}
	}

	[HarmonyPatch(typeof(UILobbyPlayTabPage), "Initialise")]
	public static class LobbyPlayTabInitialisePatch
	{
		[HarmonyPrefix]
		public static void Prefix()
		{
			EnsureRegisteredForUi("UILobbyPlayTabPage.Initialise");
		}
	}

	[HarmonyPatch(typeof(UILobbyPlayTabPage), "UpdateData")]
	public static class LobbyPlayTabUpdateDataPatch
	{
		[HarmonyPrefix]
		public static void Prefix()
		{
			EnsureRegisteredForUi("UILobbyPlayTabPage.UpdateData");
		}
	}

	[HarmonyPatch(typeof(UIManager), "PreAwake")]
	public static class UiManagerPreAwakePatch
	{
		[HarmonyPostfix]
		public static void Postfix(UIManager __instance)
		{
			EnsureRegisteredForUiManager(__instance, "UIManager.PreAwake");
		}
	}

	[HarmonyPatch(typeof(UIManager), "Awake")]
	public static class UiManagerAwakePatch
	{
		[HarmonyPostfix]
		public static void Postfix(UIManager __instance)
		{
			EnsureRegisteredForUiManager(__instance, "UIManager.Awake");
		}
	}

	[HarmonyPatch(typeof(UIPreMatch), "PopulatePreMatchUI")]
	public static class UIPreMatchPopulatePatch
	{
		[HarmonyPrefix]
		public static void Prefix(QueueMatchedData qmd)
		{
			EnsureLobbyCharacterPageDataAvailable("UIPreMatch.PopulatePreMatchUI");
			ForceQueueMatchedDataAvailable(qmd, "UIPreMatch.PopulatePreMatchUI");
		}
	}

	[HarmonyPatch(typeof(UIPreMatch), "UpdatePreMatchUI")]
	public static class UIPreMatchUpdatePatch
	{
		[HarmonyPrefix]
		public static void Prefix(QueueMatchedData qmd)
		{
			EnsureLobbyCharacterPageDataAvailable("UIPreMatch.UpdatePreMatchUI");
			ForceQueueMatchedDataAvailable(qmd, "UIPreMatch.UpdatePreMatchUI");
		}
	}

	[HarmonyPatch(typeof(UIPreMatch), "OpenCharacterSelect")]
	public static class UIPreMatchOpenCharacterSelectPatch
	{
		[HarmonyPostfix]
		public static void Postfix()
		{
			MaybeAutoSelectMedusa("UIPreMatch.OpenCharacterSelect");
		}
	}

	[HarmonyPatch(typeof(UIPreMatch), "SetLocalPlayerCharacter")]
	public static class UIPreMatchSetLocalPlayerCharacterPatch
	{
		[HarmonyPostfix]
		public static void Postfix(int newCharId)
		{
			if (!IsMedusaId(newCharId))
			{
				return;
			}
			RememberExplicitMedusaSelection("UIPreMatch.SetLocalPlayerCharacter");
			if (_prematchLocalCharLogCount < 4)
			{
				_prematchLocalCharLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] UIPreMatch local player character is Medusa (charId={newCharId}).");
				}
			}
			TrySubmitMedusaSelection("UIPreMatch.SetLocalPlayerCharacter", lockAfter: false);
		}
	}

	[HarmonyPatch(typeof(View_PreMatch_CharSelect), "Initialize")]
	public static class ViewPreMatchCharSelectInitializePatch
	{
		[HarmonyPrefix]
		public static void Prefix(Configuration configuration)
		{
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_0032: Expected O, but got Unknown
			EnsureLobbyCharacterPageDataAvailable("View_PreMatch_CharSelect.Initialize");
			EnsureRegisteredForUi("View_PreMatch_CharSelect.Initialize");
			if (_instance != null && (Object)((configuration != null) ? configuration.CharacterConfiguration : null) != (Object)null)
			{
				_instance.TryRegisterMedusa(configuration.CharacterConfiguration);
				_instance.MakeRosterAvailable(configuration.CharacterConfiguration);
			}
		}
	}

	[HarmonyPatch(typeof(View_PreMatch_CharSelect), "PopulateCharacterButtons")]
	public static class ViewPreMatchCharSelectPopulatePatch
	{
		[HarmonyPrefix]
		public static void Prefix()
		{
			EnsureRegisteredForUi("View_PreMatch_CharSelect.PopulateCharacterButtons");
		}

		[HarmonyPostfix]
		public static void Postfix(View_PreMatch_CharSelect __instance)
		{
			RepairPrematchMedusaButton(__instance, "View_PreMatch_CharSelect.PopulateCharacterButtons");
			if (_matchSelectLogCount < 8)
			{
				_matchSelectLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] View_PreMatch_CharSelect populated; medusaId={CurrentMedusaId()} autoEnabled={AutoSelectMedusaEnabled()}.");
				}
			}
			MaybeAutoSelectMedusa("View_PreMatch_CharSelect.PopulateCharacterButtons");
		}
	}

	[HarmonyPatch(typeof(View_PreMatch_CharSelect), "SetDisplayedCharacter")]
	public static class ViewPreMatchCharSelectSetDisplayedPatch
	{
		[HarmonyPostfix]
		public static void Postfix(CharacterConfiguration character)
		{
			try
			{
				int num = ((character != null) ? character.charId : (-1));
				if (!IsMedusaId(num))
				{
					return;
				}
				if (_viewDisplayMedusaLogCount < 4)
				{
					_viewDisplayMedusaLogCount++;
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] View_PreMatch_CharSelect displayed Medusa; charId={num} autoEnabled={AutoSelectMedusaEnabled()}.");
					}
				}
				RememberExplicitMedusaSelection("View_PreMatch_CharSelect.SetDisplayedCharacter");
				ScheduleMedusaSelection("View_PreMatch_CharSelect.SetDisplayedCharacter.explicit", lockAfter: false);
			}
			catch (Exception ex)
			{
				MedusaMod instance2 = _instance;
				if (instance2 != null)
				{
					((ModBase)instance2).Log.Warn("[Medusa] View_PreMatch_CharSelect.SetDisplayedCharacter bridge failed: " + ex.Message);
				}
			}
		}
	}

	[HarmonyPatch(typeof(View_PreMatch_CharSelect), "GetCharIndexByID")]
	public static class ViewPreMatchCharSelectGetCharIndexPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(int charID, ref int __result)
		{
			if (!IsMedusaId(charID))
			{
				return true;
			}
			__result = FindCharacterConfigIndex(charID);
			if (_matchSelectLogCount < 8)
			{
				_matchSelectLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] View_PreMatch_CharSelect.GetCharIndexByID({charID}) -> {__result}.");
				}
			}
			return false;
		}
	}

	[HarmonyPatch(typeof(PlayerPreMatch), "Initialize")]
	public static class PlayerPreMatchInitializePatch
	{
		[HarmonyPostfix]
		public static void Postfix(PlayerPreMatch __instance)
		{
			//IL_0003: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Expected O, but got Unknown
			try
			{
				bool flag = false;
				try
				{
					flag = (Object)__instance != (Object)null && ((NetworkBehaviour)__instance).isLocalPlayer;
				}
				catch
				{
				}
				if (flag)
				{
					MaybeAutoSelectMedusa("PlayerPreMatch.Initialize");
				}
			}
			catch
			{
			}
		}
	}

	[HarmonyPatch(typeof(PlayerPreMatch), "CmdTrySelectCharacter")]
	public static class PlayerPreMatchCmdTrySelectCharacterPatch
	{
		[HarmonyPrefix]
		public static void Prefix(PlayerManager player, int charId)
		{
			if (IsMedusaId(charId))
			{
				RememberExplicitMedusaSelection("PlayerPreMatch.CmdTrySelectCharacter");
			}
			if (!IsMedusaId(charId) || _prematchCmdSelectLogCount >= 8)
			{
				return;
			}
			_prematchCmdSelectLogCount++;
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] CmdTrySelectCharacter sent/received: charId={charId} playerOld={SafeInt(() => player.charId)}.");
			}
		}
	}

	[HarmonyPatch(typeof(PlayerPreMatch), "UserCode_CmdTrySelectCharacter__PlayerManager__Int32")]
	public static class PlayerPreMatchUserCodeTrySelectCharacterPatch
	{
		[HarmonyPostfix]
		public static void Postfix(PlayerManager player, int charId)
		{
			if (IsMedusaId(charId))
			{
				RememberExplicitMedusaSelection("PlayerPreMatch.UserCode_CmdTrySelectCharacter");
				ForcePlayerMedusaChar(player, charId, "PlayerPreMatch.UserCode_CmdTrySelectCharacter");
			}
		}
	}

	[HarmonyPatch(typeof(PlayerPreMatch), "CmdTryLockCharacter")]
	public static class PlayerPreMatchCmdTryLockCharacterPatch
	{
		[HarmonyPrefix]
		public static void Prefix(PlayerManager player)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			try
			{
				if (!((Object)player == (Object)null) && IsMedusaId(player.charId) && _prematchCmdLockLogCount < 8)
				{
					_prematchCmdLockLogCount++;
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] CmdTryLockCharacter for Medusa player charId={player.charId}.");
					}
				}
			}
			catch
			{
			}
		}
	}

	[HarmonyPatch(typeof(PlayerPreMatch), "UserCode_CmdTryLockCharacter__PlayerManager")]
	public static class PlayerPreMatchUserCodeTryLockCharacterPatch
	{
		[HarmonyPostfix]
		public static void Postfix(PlayerManager player)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			if (!((Object)player == (Object)null) && TryGetPreMatchSelectedChar(player, out var charId) && IsMedusaId(charId))
			{
				ForcePlayerMedusaChar(player, charId, "PlayerPreMatch.UserCode_CmdTryLockCharacter");
			}
		}
	}

	[HarmonyPatch(typeof(PlayerPreMatch), "SetPlayerCharacter")]
	public static class PlayerPreMatchSetPlayerCharacterPatch
	{
		[HarmonyPostfix]
		public static void Postfix(PlayerPreMatch __instance, int charId)
		{
			if (IsMedusaId(charId))
			{
				RememberExplicitMedusaSelection("PlayerPreMatch.SetPlayerCharacter");
				ForcePlayerMedusaChar(((Object)(object)__instance != (Object)null) ? __instance._playerManager : null, charId, "PlayerPreMatch.SetPlayerCharacter");
			}
		}
	}

	[HarmonyPatch(typeof(PlayerPreMatch), "SetTeammateCharacter")]
	public static class PlayerPreMatchSetTeammateCharacterPatch
	{
		[HarmonyPostfix]
		public static void Postfix(PlayerManager teammate, int charId)
		{
			if (IsMedusaId(charId))
			{
				ForcePlayerMedusaChar(teammate, charId, "PlayerPreMatch.SetTeammateCharacter");
			}
		}
	}

	[HarmonyPatch(typeof(PreMatchManager), "TrySelectCharacter")]
	public static class PreMatchManagerTrySelectCharacterPatch
	{
		[HarmonyPostfix]
		public static void Postfix(PlayerManager player, int requestedCharId)
		{
			if (IsMedusaId(requestedCharId))
			{
				RememberExplicitMedusaSelection("PreMatchManager.TrySelectCharacter");
				ForcePlayerMedusaChar(player, requestedCharId, "PreMatchManager.TrySelectCharacter");
			}
		}
	}

	[HarmonyPatch(typeof(PreMatchManager), "AssignCharacters")]
	public static class PreMatchManagerAssignCharactersPatch
	{
		[HarmonyPrefix]
		public static void Prefix(PreMatchManager __instance)
		{
			ForceSelectedMedusaPlayers(__instance, "PreMatchManager.AssignCharacters.prefix");
		}

		[HarmonyPostfix]
		public static void Postfix(PreMatchManager __instance)
		{
			ForceSelectedMedusaPlayers(__instance, "PreMatchManager.AssignCharacters.postfix");
		}
	}

	[HarmonyPatch(typeof(GameMode), "SpawnPlayerChar")]
	public static class GameModeSpawnPlayerCharPatch
	{
		[HarmonyPrefix]
		public static void Prefix(PlayerManager playerManager, Vector3 spawnPos)
		{
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Expected O, but got Unknown
			_instance?.EnsureMedusaPrefabRegistered(CurrentMedusaId(), "GameMode.SpawnPlayerChar.prefix");
			if (!((Object)playerManager == (Object)null))
			{
				if (TryGetPreMatchSelectedChar(playerManager, out var charId) && IsMedusaId(charId))
				{
					ForcePlayerMedusaChar(playerManager, charId, "GameMode.SpawnPlayerChar.prefix.selected");
				}
				else if (IsMedusaId(SafeIntValue(() => playerManager.charId)))
				{
					ForcePlayerMedusaChar(playerManager, CurrentMedusaId(), "GameMode.SpawnPlayerChar.prefix.player");
				}
			}
		}

		[HarmonyPostfix]
		public static void Postfix(PlayerManager playerManager)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			try
			{
				if (!((Object)playerManager == (Object)null) && IsMedusaId(playerManager.charId))
				{
					ForcePlayerMedusaChar(playerManager, playerManager.charId, "GameMode.SpawnPlayerChar.postfix");
					EnsureLiveMedusaEntity(playerManager.primaryCharManager, "GameMode.SpawnPlayerChar.postfix");
				}
			}
			catch
			{
			}
		}
	}

	[HarmonyPatch(typeof(GameNetworkManager), "Awake")]
	public static class GameNetworkManagerAwakePatch
	{
		[HarmonyPostfix]
		public static void Postfix()
		{
			_instance?.EnsureMedusaPrefabRegistered(CurrentMedusaId(), "GameNetworkManager.Awake");
		}
	}

	[HarmonyPatch(typeof(GameNetworkManager), "OnStartServer")]
	public static class GameNetworkManagerOnStartServerPatch
	{
		[HarmonyPostfix]
		public static void Postfix()
		{
			_instance?.EnsureMedusaPrefabRegistered(CurrentMedusaId(), "GameNetworkManager.OnStartServer");
		}
	}

	[HarmonyPatch(typeof(GameNetworkManager), "OnServerQueueMatched")]
	public static class GameNetworkManagerOnServerQueueMatchedPatch
	{
		[HarmonyPrefix]
		public static void Prefix(QueueMatchedData qmd)
		{
			_instance?.EnsureMedusaPrefabRegistered(CurrentMedusaId(), "GameNetworkManager.OnServerQueueMatched");
			ForceQueueMatchedDataAvailable(qmd, "GameNetworkManager.OnServerQueueMatched");
		}
	}

	[HarmonyPatch(typeof(GameNetworkManager), "OnServerMatchAddTeams")]
	public static class GameNetworkManagerOnServerMatchAddTeamsPatch
	{
		[HarmonyPrefix]
		public static void Prefix()
		{
			_instance?.EnsureMedusaPrefabRegistered(CurrentMedusaId(), "GameNetworkManager.OnServerMatchAddTeams");
		}
	}

	[HarmonyPatch(typeof(GameNetworkManager), "GetCharacterBotPrefab")]
	public static class GameNetworkManagerGetCharacterBotPrefabPatch
	{
		[HarmonyPrefix]
		public static void Prefix(ref int charId, BotDifficulty botDifficulty)
		{
			//IL_0086: Unknown result type (might be due to invalid IL or missing references)
			if (!IsMedusaId(charId))
			{
				return;
			}
			int num = _instance?.ResolveBotFallbackCharId("GameNetworkManager.GetCharacterBotPrefab") ?? 0;
			if (_medusaBotFallbackLogCount < 12)
			{
				_medusaBotFallbackLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] bot prefab fallback: requested Medusa charId={charId}, using base bot charId={num}, difficulty={botDifficulty}.");
				}
			}
			charId = num;
		}
	}

	[HarmonyPatch(typeof(PlayerManager), "OnCharacterChanged")]
	public static class PlayerManagerCharacterChangedPatch
	{
		[HarmonyPostfix]
		public static void Postfix(PlayerManager __instance, int oldValue, int newValue)
		{
			if (IsMedusaId(newValue))
			{
				ForcePlayerMedusaChar(__instance, newValue, $"PlayerManager.OnCharacterChanged({oldValue}->{newValue})");
			}
		}
	}

	[HarmonyPatch(typeof(EntityManager), "Start")]
	public static class EntityManagerStartPatch
	{
		[HarmonyPostfix]
		public static void Postfix(EntityManager __instance)
		{
			EnsureLiveMedusaEntity(__instance, "EntityManager.Start");
		}
	}

	[HarmonyPatch(typeof(EntityManager), "OnStartClient")]
	public static class EntityManagerOnStartClientPatch
	{
		[HarmonyPostfix]
		public static void Postfix(EntityManager __instance)
		{
			EnsureLiveMedusaEntity(__instance, "EntityManager.OnStartClient");
		}
	}

	[HarmonyPatch(typeof(CharAbilities), "PreAwake")]
	public static class CharAbilitiesPreAwakePatch
	{
		[HarmonyPostfix]
		public static void Postfix(CharAbilities __instance, EntityManager e)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			try
			{
				if (!((Object)e == (Object)null) && IsMedusaId(e.charId))
				{
					ApplyMedusaAbilityRuntimeUi(__instance, "CharAbilities.PreAwake");
				}
			}
			catch
			{
			}
		}
	}

	[HarmonyPatch(typeof(CharAbilities), "SetCastAbility")]
	public static class MedusaCharAbilitiesSetCastAbilityPatch
	{
		[HarmonyPostfix]
		public static void Postfix(CharAbilities __instance, CastFlags castFlag)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			TryRunMedusaAbilityDriverFromCastFlag(__instance, castFlag, "CharAbilities.SetCastAbility");
		}
	}

	[HarmonyPatch(typeof(Ability), "LoadAbilityUI")]
	public static class AbilityLoadUiPatch
	{
		[HarmonyPrefix]
		public static void Prefix(Ability __instance)
		{
			ApplyMedusaAbilityRuntimeUi(__instance, "Ability.LoadAbilityUI");
		}
	}

	[HarmonyPatch(typeof(Ability), "GetTooltipDescription")]
	public static class MedusaAbilityTooltipDescriptionPatch
	{
		[HarmonyPostfix]
		public static void Postfix(Ability __instance, ref string __result)
		{
			OverrideMedusaAbilityTooltipText(__instance, expanded: false, ref __result);
		}
	}

	[HarmonyPatch(typeof(Ability), "GetTooltipExpandedDescription")]
	public static class MedusaAbilityTooltipExpandedDescriptionPatch
	{
		[HarmonyPostfix]
		public static void Postfix(Ability __instance, ref string __result)
		{
			OverrideMedusaAbilityTooltipText(__instance, expanded: true, ref __result);
		}
	}

	[HarmonyPatch(typeof(Ability), "SetState")]
	public static class MedusaAbilitySetStatePatch
	{
		[HarmonyPrefix]
		public static void Prefix(Ability __instance, out int __state)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				__state = ((!((Object)__instance != (Object)null)) ? (-1) : ((int)__instance.state));
			}
			catch
			{
				__state = -1;
			}
		}

		[HarmonyPostfix]
		public static void Postfix(Ability __instance, AbilityStates _state, int __state)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Expected I4, but got Unknown
			try
			{
				int newState = (int)_state;
				if (IsMedusaCastStartState(__state, newState))
				{
					TryRunMedusaAbilityDriverFromState(__instance, newState);
				}
			}
			catch
			{
			}
		}
	}

	[HarmonyPatch(typeof(CatShotAbility), "Shoot")]
	public static class MedusaCatShotShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(CatShotAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "CatShotAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(CatMissileAbility), "Shoot")]
	public static class MedusaCatMissileShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(CatMissileAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "CatMissileAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(CatPolymorphAbility), "Shoot")]
	public static class MedusaCatPolymorphShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(CatPolymorphAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "CatPolymorphAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(CatJumpAbility), "Shoot")]
	public static class MedusaCatJumpShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(CatJumpAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "CatJumpAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(ArrowAbility), "Shoot")]
	public static class MedusaArrowShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(ArrowAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "ArrowAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(ChargedArrowsAbility), "Shoot")]
	public static class MedusaChargedArrowsShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(ChargedArrowsAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "ChargedArrowsAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(RecoilArrowAbility), "Shoot")]
	public static class MedusaRecoilArrowShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(RecoilArrowAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "RecoilArrowAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(ArrowMissileAbility), "Shoot")]
	public static class MedusaArrowMissileShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(ArrowMissileAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot((Ability?)(object)__instance, "ArrowMissileAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(UIAbilities), "ShowAbilityTooltip")]
	public static class UIAbilitiesShowAbilityTooltipPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(UIAbilities __instance, int cmdId, bool fadeIn)
		{
			return !TryShowMedusaAbilityTooltip(__instance, cmdId, fadeIn, "UIAbilities.ShowAbilityTooltip");
		}
	}

	[HarmonyPatch(typeof(UIAbilityElement), "LoadIcon", new Type[] { typeof(CharacterConfiguration) })]
	public static class UIAbilityElementLoadIconConfigPatch
	{
		[HarmonyPrefix]
		public static void Prefix(CharacterConfiguration charConfig)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				if (charConfig != null && IsMedusaId(charConfig.charId))
				{
					charConfig.abilityIconColor = MedusaAbilityIconColor;
					charConfig.abilityBGColor = MedusaAbilityBgColor;
					charConfig.titleTextColor = MedusaTitleTextColor;
				}
			}
			catch
			{
			}
		}

		[HarmonyPostfix]
		public static void Postfix(UIAbilityElement __instance, CharacterConfiguration charConfig)
		{
			try
			{
				if (charConfig != null && IsMedusaId(charConfig.charId))
				{
					ApplyMedusaAbilityElementPalette(__instance, "UIAbilityElement.LoadIcon(CharacterConfiguration)");
				}
			}
			catch
			{
			}
		}
	}

	[HarmonyPatch(typeof(UIAbilityElement), "LoadIcon", new Type[]
	{
		typeof(Sprite),
		typeof(Color),
		typeof(Color),
		typeof(string),
		typeof(string)
	})]
	public static class UIAbilityElementLoadIconDirectPatch
	{
		[HarmonyPrefix]
		public static void Prefix(ref Color iconColor, ref Color titleColor, string titleStr, string descStr)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0016: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				if (IsMedusaAbilityText(titleStr) || IsMedusaAbilityText(descStr))
				{
					iconColor = MedusaAbilityIconColor;
					titleColor = MedusaTitleTextColor;
				}
			}
			catch
			{
			}
		}

		[HarmonyPostfix]
		public static void Postfix(UIAbilityElement __instance, string titleStr, string descStr)
		{
			try
			{
				if (IsMedusaAbilityText(titleStr) || IsMedusaAbilityText(descStr))
				{
					ApplyMedusaAbilityElementPalette(__instance, "UIAbilityElement.LoadIcon(Sprite,Color,Color,string,string)");
				}
			}
			catch
			{
			}
		}
	}

	[HarmonyPatch(typeof(UIMinimap), "AddIconOnPosByNetId")]
	public static class MinimapAddIconOnPosByNetIdPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(UIMinimap __instance, uint netId, ref UIMinimapIcon __result)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_001b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Expected O, but got Unknown
			try
			{
				if ((Object)__instance == (Object)null)
				{
					return true;
				}
				UIMinimapIcon iconByNetId = __instance.GetIconByNetId(netId);
				if ((Object)iconByNetId == (Object)null)
				{
					return true;
				}
				__result = iconByNetId;
				if (_minimapDuplicateIconGuardLogCount < 6)
				{
					_minimapDuplicateIconGuardLogCount++;
					MedusaMod? instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] skipped duplicate minimap netId icon add for netId={netId}; reused existing icon.");
					}
				}
				return false;
			}
			catch
			{
				return true;
			}
		}

		[HarmonyFinalizer]
		public static Exception Finalizer(Exception __exception, UIMinimap __instance, uint netId, ref UIMinimapIcon __result)
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_0033: Expected O, but got Unknown
			if (__exception == null)
			{
				return null;
			}
			if (__exception is ArgumentException && __exception.Message.IndexOf("same key", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				try
				{
					if ((Object)__instance != (Object)null)
					{
						__result = __instance.GetIconByNetId(netId);
					}
				}
				catch
				{
				}
				if (_minimapDuplicateIconGuardLogCount < 6)
				{
					_minimapDuplicateIconGuardLogCount++;
					MedusaMod? instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Warn($"[Medusa] suppressed duplicate minimap netId exception for netId={netId}: {__exception.Message}");
					}
				}
				return null;
			}
			return __exception;
		}
	}

	[HarmonyPatch(typeof(CharAnimator), "Awake")]
	public static class CharAnimatorRebindPatch
	{
		[HarmonyPostfix]
		public static void Postfix(CharAnimator __instance)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d8: Expected O, but got Unknown
			try
			{
				if ((Object)__instance == (Object)null)
				{
					return;
				}
				Animator val = FindMedusaAnimator(((Component)__instance).transform);
				if ((Object)val == (Object)null)
				{
					return;
				}
				try
				{
					__instance.animator = val;
				}
				catch (Exception ex)
				{
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Warn("[Medusa] HM rebind CA.animator: " + ex.Message);
					}
					return;
				}
				try
				{
					__instance.customAnimator = true;
				}
				catch
				{
				}
				if (_instance != null)
				{
					_instance._harmonyRebindFiredAtLeastOnce = true;
					((ModBase)_instance).Log.Info($"[Medusa] HM postfix rebound CharAnimator on '{((Object)((Component)__instance).gameObject).name}' -> Medusa's Animator (controller='{(((Object)val.runtimeAnimatorController != (Object)null) ? ((Object)val.runtimeAnimatorController).name : "?")}').");
				}
			}
			catch (Exception ex2)
			{
				if (_instance != null)
				{
					((ModBase)_instance).Log.Warn("[Medusa] CharAnimatorRebindPatch.Postfix: " + ex2);
				}
			}
		}
	}

	[HarmonyPatch(typeof(CharFootsteps), "Awake")]
	public static class CharFootstepsRebindPatch
	{
		[HarmonyPostfix]
		public static void Postfix(CharFootsteps __instance)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Expected O, but got Unknown
			try
			{
				if ((Object)__instance == (Object)null)
				{
					return;
				}
				Animator val = FindMedusaAnimator(((Component)__instance).transform);
				if ((Object)val == (Object)null)
				{
					return;
				}
				try
				{
					__instance.animator = val;
				}
				catch (Exception ex)
				{
					if (_instance != null)
					{
						((ModBase)_instance).Log.Warn("[Medusa] HM rebind CF.animator: " + ex.Message);
					}
				}
			}
			catch (Exception ex2)
			{
				if (_instance != null)
				{
					((ModBase)_instance).Log.Warn("[Medusa] CharFootstepsRebindPatch.Postfix: " + ex2);
				}
			}
		}
	}

	[HarmonyPatch(typeof(HitboxBase), "OnHitSuccess", new Type[] { typeof(EntityManager) })]
	public static class HitboxDoEntityHitPetrifyPatch
	{
		[HarmonyPostfix]
		public static void Postfix(HitboxBase __instance, EntityManager otherEntityManager)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Expected O, but got Unknown
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Expected O, but got Unknown
			//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cb: Expected O, but got Unknown
			//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00da: Expected O, but got Unknown
			//IL_0251: Unknown result type (might be due to invalid IL or missing references)
			//IL_025c: Expected O, but got Unknown
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_0272: Unknown result type (might be due to invalid IL or missing references)
			//IL_0279: Unknown result type (might be due to invalid IL or missing references)
			//IL_0281: Expected O, but got Unknown
			//IL_0138: Unknown result type (might be due to invalid IL or missing references)
			//IL_0143: Expected O, but got Unknown
			//IL_0159: Unknown result type (might be due to invalid IL or missing references)
			//IL_0160: Unknown result type (might be due to invalid IL or missing references)
			//IL_0168: Expected O, but got Unknown
			//IL_0060: Unknown result type (might be due to invalid IL or missing references)
			//IL_006b: Expected O, but got Unknown
			//IL_007c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0087: Expected O, but got Unknown
			try
			{
				if ((Object)__instance == (Object)null)
				{
					return;
				}
				Ability val = null;
				try
				{
					val = __instance.ability;
				}
				catch
				{
				}
				if ((Object)val == (Object)null)
				{
					return;
				}
				int medusaAbilitySlot = GetMedusaAbilitySlot(val);
				if (medusaAbilitySlot < 0)
				{
					return;
				}
				bool flag = medusaAbilitySlot == 3;
				bool flag2 = medusaAbilitySlot == 0 || medusaAbilitySlot == 1;
				if ((!flag && !flag2) || (Object)otherEntityManager == (Object)null)
				{
					return;
				}
				CharStatusEffects charStatusEffects = otherEntityManager.charStatusEffects;
				if ((Object)charStatusEffects == (Object)null || charStatusEffects.ignoreAllStatusEffects)
				{
					return;
				}
				int num = -1;
				try
				{
					num = __instance.ownerPlayerId;
				}
				catch
				{
				}
				Vector3 val2 = Vector3.zero;
				try
				{
					Transform transform = ((Component)otherEntityManager).transform;
					Transform transform2 = ((Component)__instance).transform;
					if ((Object)transform != (Object)null && (Object)transform2 != (Object)null)
					{
						Vector3 val3 = transform.position - transform2.position;
						val2 = ((Vector3)(ref val3)).normalized;
					}
				}
				catch
				{
				}
				if (flag)
				{
					Interlocked.Increment(ref _petrifyHitObservedCount);
					if ((_petrifyId < 0 || !charStatusEffects.IsStatusEffectApplied(_petrifyId)) && TryResolvePetrifySO() && !((Object)_petrifySO == (Object)null))
					{
						charStatusEffects.ActivateStatusEffect(new StatusEffectInfo(_petrifySO, 2.5f, 1f), num, val2, false);
						int num2 = Interlocked.Increment(ref _petrifyAppliedCount);
						if (_instance != null && (num2 <= 5 || num2 % 10 == 0))
						{
							((ModBase)_instance).Log.Info($"[Medusa] PETRIFY applied (#{num2}) to '{VictimName(otherEntityManager)}' (charId={GetVictimCharIdSafe(otherEntityManager)}, ownerPid={num}, dur={2.5f:F2}s).");
						}
					}
					return;
				}
				Interlocked.Increment(ref _poisonHitObservedCount);
				if (TryResolvePoisonSO() && !((Object)_poisonSO == (Object)null))
				{
					charStatusEffects.ActivateStatusEffect(new StatusEffectInfo(_poisonSO, 3f, 1f), num, val2, false);
					int num3 = Interlocked.Increment(ref _poisonAppliedCount);
					if (_instance != null && (num3 <= 5 || num3 % 25 == 0))
					{
						((ModBase)_instance).Log.Info($"[Medusa] POISON applied (#{num3}, slot {medusaAbilitySlot}) to '{VictimName(otherEntityManager)}' (charId={GetVictimCharIdSafe(otherEntityManager)}, ownerPid={num}, dur={3f:F2}s).");
					}
				}
			}
			catch (Exception ex)
			{
				if (_instance != null)
				{
					((ModBase)_instance).Log.Warn("[Medusa] HitboxStatusPatch: " + ex);
				}
			}
		}

		private static string VictimName(EntityManager em)
		{
			try
			{
				return ((Object)((Component)em).gameObject).name ?? "<?>";
			}
			catch
			{
				return "<?>";
			}
		}

		private static int GetVictimCharIdSafe(EntityManager em)
		{
			try
			{
				return em.charId;
			}
			catch
			{
				return -1;
			}
		}
	}

	public const string MedusaName = "Medusa";

	private const string BasePreference = "Kitsu";

	private const uint MedusaMirrorAssetId = 1296385109u;

	private static readonly Color MedusaColor = new Color(0.45f, 0.85f, 0.35f, 1f);

	private static readonly Color MedusaAbilityIconColor = new Color(0.3f, 0.95f, 0.42f, 1f);

	private static readonly Color MedusaAbilityBgColor = new Color(0.05f, 0.2f, 0.1f, 0.95f);

	private static readonly Color MedusaTitleTextColor = new Color(0.78f, 1f, 0.62f, 1f);

	private static readonly Color MedusaVenomFxColor = new Color(0.18f, 1f, 0.32f, 0.95f);

	private static readonly Color MedusaVenomPuddleColor = new Color(0.03f, 0.78f, 0.18f, 0.7f);

	private static readonly Color MedusaPetrifyFxColor = new Color(0.78f, 0.82f, 0.74f, 0.96f);

	public const string MedusaVisualName = "Medusa_Visual";

	public const string MedusaControllerName = "Medusa";

	private const string VfxEscapeName = "VFX_Medusa_Poison_Escape";

	private const string VfxHitName = "VFX_Medusa_Poison_Hit";

	private const string VfxMuzzleName = "VFX_Medusa_Poison_Muzzle";

	private const string VfxPuddleName = "VFX_Medusa_Poison_Puddle";

	private const string VfxTrailName = "VFX_Medusa_Poison_Trail";

	private const string VfxWallName = "VFX_Medusa_Poison_Wall";

	private static readonly string[] NativeVfxNames = new string[6] { "VFX_Medusa_Poison_Escape", "VFX_Medusa_Poison_Hit", "VFX_Medusa_Poison_Muzzle", "VFX_Medusa_Poison_Puddle", "VFX_Medusa_Poison_Trail", "VFX_Medusa_Poison_Wall" };

	private const string K_NAME = "MEDUSA_NAME";

	private const string K_DESC = "MEDUSA_DESC";

	private const string K_LMB_TITLE = "MEDUSA_AB_LMB_TITLE";

	private const string K_LMB_SHORT = "MEDUSA_AB_LMB_DESC_SHORT";

	private const string K_LMB_DESC = "MEDUSA_AB_LMB_DESC";

	private const string K_Q_TITLE = "MEDUSA_AB_Q_TITLE";

	private const string K_Q_SHORT = "MEDUSA_AB_Q_DESC_SHORT";

	private const string K_Q_DESC = "MEDUSA_AB_Q_DESC";

	private const string K_SPACE_TITLE = "MEDUSA_AB_SPACE_TITLE";

	private const string K_SPACE_SHORT = "MEDUSA_AB_SPACE_DESC_SHORT";

	private const string K_SPACE_DESC = "MEDUSA_AB_SPACE_DESC";

	private const string K_ULT_TITLE = "MEDUSA_AB_ULT_TITLE";

	private const string K_ULT_SHORT = "MEDUSA_AB_ULT_DESC_SHORT";

	private const string K_ULT_DESC = "MEDUSA_AB_ULT_DESC";

	private static readonly Dictionary<string, string> MedusaPhrases = new Dictionary<string, string>
	{
		["MEDUSA_NAME"] = "Medusa",
		["MEDUSA_DESC"] = "Gorgon priestess of the cursed temple. Petrifies foes with her gaze and strikes from afar with venom-tipped serpent bolts.",
		["MEDUSA_AB_LMB_TITLE"] = "Serpent Bolt",
		["MEDUSA_AB_LMB_DESC_SHORT"] = "Loose a venom-tipped bolt at a single target.",
		["MEDUSA_AB_LMB_DESC"] = "Loose a venom-tipped serpent bolt, dealing {1}.",
		["MEDUSA_AB_Q_TITLE"] = "Venom Spit",
		["MEDUSA_AB_Q_DESC_SHORT"] = "Spit a wave of venom into an area. Slows foes caught in it.",
		["MEDUSA_AB_Q_DESC"] = "Rain venom on an area, dealing {1} and applying {2} on hit.",
		["MEDUSA_AB_SPACE_TITLE"] = "Slither",
		["MEDUSA_AB_SPACE_DESC_SHORT"] = "Coil and slither away. Knocks up foes at the launch point.",
		["MEDUSA_AB_SPACE_DESC"] = "Coil and slither away from the ground, dealing {1} and applying {2} on hit.",
		["MEDUSA_AB_ULT_TITLE"] = "Petrifying Gaze",
		["MEDUSA_AB_ULT_DESC_SHORT"] = "Pierce all in your line of sight. Stone-roots whoever you hit.",
		["MEDUSA_AB_ULT_DESC"] = "Stare a piercing curse through obstacles and enemies, dealing {1} and petrifying (root) any target struck for {2}."
	};

	private bool _registered;

	private bool _phrasesInjected;

	private int _pollTicks;

	private bool _firstCfgSeen;

	private int _runtimeUiLogCount;

	private int _liveGraftLogCount;

	private int _castFxLogCount;

	private int _nativeVfxSpawnLogCount;

	private int _abilityDriverLogCount;

	private int _networkPrefabLogCount;

	private int _abilityElementPaletteLogCount;

	private readonly Dictionary<long, float> _recentCastFx = new Dictionary<long, float>();

	private readonly Dictionary<long, float> _recentAbilityDriver = new Dictionary<long, float>();

	private float _nextWorldBindingPollAt;

	private float _nextLiveDiagnosticsAt;

	private static UICharactersConfiguration? _cachedCharConfig;

	private static float _nextCharConfigScanAt;

	private static readonly Dictionary<int, float> _liveRefreshScheduledAt = new Dictionary<int, float>();

	private static readonly HashSet<int> _liveRefreshScheduledOnceRoots = new HashSet<int>();

	private static readonly HashSet<int> _stableLiveVisualRoots = new HashSet<int>();

	private static readonly HashSet<int> _runtimeReboundVisualRoots = new HashSet<int>();

	private static readonly HashSet<int> _charMaterialBoundRoots = new HashSet<int>();

	private static readonly HashSet<int> _charMaterialVisibleRoots = new HashSet<int>();

	private static readonly HashSet<int> _materialPreparedVisuals = new HashSet<int>();

	private static readonly Dictionary<int, float> _stableVisualLastCheapCheckAt = new Dictionary<int, float>();

	private static readonly HashSet<int> _dismissedLoadingOverlayTargets = new HashSet<int>();

	private static float _lastLoadingOverlayDismissScanAt;

	private static readonly HashSet<int> _tunedCharAbilityPrefabs = new HashSet<int>();

	private static readonly HashSet<int> _suppressedInheritedVfxRoots = new HashSet<int>();

	private static readonly HashSet<int> _clientPoolRegisteredPrefabs = new HashSet<int>();

	private static readonly HashSet<int> _serverPoolRegisteredPrefabs = new HashSet<int>();

	private static bool _mirrorClientPrefabRegistered;

	private static bool _mirrorClientSpawnPrefabsLogEmitted;

	private static bool _localMedusaExplicitlySelected;

	private static View_PreMatch_CharSelect? _lastPrematchCharSelectView;

	private static UILobbyCharacterSelectIcon? _lastPrematchMedusaIcon;

	private static bool _launchRequestedMedusaChecked;

	private static bool _launchRequestedMedusa;

	private int _lobbySwitchLogCount;

	private int _lobbySwitchSendCount;

	private float _lastLobbySwitchAt;

	private bool _autoSelectAugmentEnabledChecked;

	private bool _autoSelectAugmentEnabled;

	private float _nextAutoAugmentScanAt;

	private int _autoAugmentScanCount;

	private int _autoAugmentSelectCount;

	private readonly HashSet<int> _autoSelectedAugmentUiIds = new HashSet<int>();

	private static int _prematchSubmitLogCount;

	private static int _prematchCmdSelectLogCount;

	private static int _prematchCmdLockLogCount;

	private static int _prematchLocalCharLogCount;

	private static int _viewDisplayMedusaLogCount;

	private static int _medusaVisibleSlotLogCount;

	private static int _prematchButtonRepairLogCount;

	private static DateTime _lastPrematchSubmitUtc = DateTime.MinValue;

	private static DateTime _lastPrematchScheduleUtc = DateTime.MinValue;

	private const int ExpectedMedusaCharId = 15;

	private const int MedusaVisibleMatchSlotIndex = 7;

	private const string BundleRel = "Medusa\\medusa.bundle";

	private Il2CppAssetBundle? _bundle;

	private GameObject? _medusaVisualPrefab;

	private readonly Dictionary<string, GameObject> _medusaNativeVfxPrefabs = new Dictionary<string, GameObject>(StringComparer.OrdinalIgnoreCase);

	private Texture? _medusaAlbedoTexture;

	private Texture? _medusaNormalTexture;

	private Material? _medusaBundleMaterial;

	private bool _bundleLoaded;

	private bool _bundleAttempted;

	private Animator? _medusaAnimatorOnPrefab;

	private RuntimeAnimatorController? _medusaRuntimeController;

	private bool _medusaVisualDefaultTransformCaptured;

	private Vector3 _medusaVisualDefaultLocalPosition = Vector3.zero;

	private Quaternion _medusaVisualDefaultLocalRotation = Quaternion.identity;

	private Vector3 _medusaVisualDefaultLocalScale = Vector3.one;

	private string? _toonShaderApplied;

	private string? _toonTemplateMaterialName;

	private Material? _toonTemplateMaterial;

	private int _charAnimatorWired;

	private int _charFootstepsWired;

	private int _disabledNonMedusaAnims;

	private bool _harmonyRebindFiredAtLeastOnce;

	private int _visualAnchorLogCount;

	private int _animatorRepairLogCount;

	private int _charMaterialBindLogCount;

	private int _materialVisibilityLogCount;

	private int _materialOverrideLogCount;

	private int _visualLayerSyncLogCount;

	private int _visualDiagnosticsLogCount;

	private readonly HashSet<string> _visualDiagnosticSourcesLogged = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private int _visualFitLogCount;

	private readonly HashSet<string> _visualFitSourcesLogged = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private int _loadingOverlayHideLogCount;

	private static int _minimapDuplicateIconGuardLogCount;

	private int _liveLocalDiagnosticsLogCount;

	private bool _liveLocalDiagnosticsSuccessLogged;

	private int _inheritedVfxSuppressLogCount;

	private int _nativeVfxMaterialRepairLogCount;

	private readonly Dictionary<int, Material> _nativeVfxReplacementMaterials = new Dictionary<int, Material>();

	private static int _localBindingRepairLogCount;

	private static int _localBindingNoCandidateLogCount;

	private static DateTime _lastLocalBindingNoCandidateLogUtc = DateTime.MinValue;

	private static readonly HashSet<int> _localBindingRepairIds = new HashSet<int>();

	private static int _cameraTargetRepairLogCount;

	private static readonly HashSet<int> _cameraTargetRepairIds = new HashSet<int>();

	private static EntityManager? _lastLiveMedusaEntity;

	internal static MedusaMod? _instance;

	private const int ULT_SLOT_INDEX = 3;

	private const float PETRIFY_DURATION = 2.5f;

	internal static StatusEffectSO? _petrifySO;

	internal static int _petrifyId = -1;

	internal static int _petrifyAppliedCount;

	internal static int _petrifyHitObservedCount;

	internal static bool _petrifyLookupAttempted;

	internal static bool _petrifyLookupSucceeded;

	private const float POISON_DURATION = 3f;

	internal static StatusEffectSO? _poisonSO;

	internal static int _poisonId = -1;

	internal static int _poisonAppliedCount;

	internal static int _poisonHitObservedCount;

	internal static bool _poisonLookupAttempted;

	internal static bool _poisonLookupSucceeded;

	private static int _uiWarmupLogCount;

	private static int _matchSelectLogCount;

	private static int _lobbyListingIndexLogCount;

	private static int _medusaBotFallbackLogCount;

	public override string Id => "com.bapbap.medusa";

	public override string DisplayName => "Medusa";

	public int MedusaCharId { get; private set; } = -1;

	private static bool ContainsBlockedUnityLog(object? value, int depth)
	{
		if (value == null || depth > 4)
		{
			return false;
		}
		if (value is string text)
		{
			return ContainsBlockedUnityLogText(text);
		}
		if (value is Array array)
		{
			foreach (object item in array)
			{
				if (ContainsBlockedUnityLog(item, depth + 1))
				{
					return true;
				}
			}
			return false;
		}
		if (value is IEnumerable enumerable)
		{
			int num = 0;
			foreach (object item2 in enumerable)
			{
				if (ContainsBlockedUnityLog(item2, depth + 1))
				{
					return true;
				}
				if (++num >= 32)
				{
					break;
				}
			}
		}
		return ContainsBlockedUnityLogText(value.ToString());
	}

	private static bool ContainsBlockedUnityLogText(string? text)
	{
		if (!string.IsNullOrWhiteSpace(text))
		{
			if (text.IndexOf("data was null on CharacterSelectPage.CharacterIsUnlocked", StringComparison.OrdinalIgnoreCase) < 0)
			{
				return text.IndexOf("data was null on CharacterSelectPage.CharacterIsUnlockedInRotation", StringComparison.OrdinalIgnoreCase) >= 0;
			}
			return true;
		}
		return false;
	}

	public override void OnRegistered()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0027: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004d: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected O, but got Unknown
		_instance = this;
		ChatCommands.Register("medusa", (Handler)delegate(string[] args)
		{
			if (args.Length != 0 && args[0].Equals("status", StringComparison.OrdinalIgnoreCase))
			{
				Status();
			}
			else if (args.Length != 0 && args[0].Equals("anim", StringComparison.OrdinalIgnoreCase))
			{
				LogAnimatorState();
			}
			else
			{
				TryRegisterMedusa();
			}
		}, "Register Medusa (/medusa, /medusa status, /medusa anim)", (ModBase)this);
		KeybindManager.Register("medusa.register", (KeyCode)288, (KeyHandler)delegate
		{
			TryRegisterMedusa();
		}, (KeyHandler)null, (KeyHandler)null, false, false, false, (ModBase)this);
		((ModBase)this).Subscribe<CastStarted>((Action<CastStarted>)OnAbilityCastStarted);
		((ModBase)this).Log.Info("[Medusa] Loaded (v1.6.58). Auto-registers at the lobby; /medusa or F7 to force, /medusa status, /medusa anim.");
		((ModBase)this).Log.Info("[Medusa] v1.6.58: keeps Melon/assembly versions aligned, avoids active-base Awake during prefab cloning, treats a visible live Medusa visual as stable instead of repeatedly re-anchoring it, keeps the prematch click proxy, suppresses inherited Kitsu/Cat/Arrow VFX, drives all four Medusa abilities, reapplies native Medusa ability titles, and keeps CharMaterial opacity repairs targeted. Bundle: UserData\\Medusa\\medusa.bundle.");
		TryLoadBundle();
		TimerAPI.Every(1f, (Action)PollOnce, (ModBase)this);
		TimerAPI.Every(0.05f, (Action)PollLocalInputCastFx, (ModBase)this);
		TimerAPI.Once(5f, (Action)LogAnimatorState, (ModBase)this);
	}

	public override void OnUpdate(float deltaTime)
	{
		if (!AutoSelectAugmentEnabled())
		{
			return;
		}
		try
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			if (!(realtimeSinceStartup < _nextAutoAugmentScanAt))
			{
				_nextAutoAugmentScanAt = realtimeSinceStartup + 0.25f;
				TryAutoSelectOpenAugment("OnUpdate");
			}
		}
		catch (Exception ex)
		{
			if (_autoAugmentScanCount < 8)
			{
				((ModBase)this).Log.Warn("[Medusa] AugmentFix update failed: " + ex.Message);
			}
		}
	}

	public override void OnSceneLoaded(int buildIndex, string sceneName)
	{
		ResetRuntimeSceneState($"scene loaded {buildIndex}:{sceneName}");
	}

	public override void OnSceneUnloaded(int buildIndex, string sceneName)
	{
		ResetRuntimeSceneState($"scene unloaded {buildIndex}:{sceneName}");
	}

	private void ResetRuntimeSceneState(string reason)
	{
		try
		{
			if (ShouldClearExplicitSelectionForSceneReset(reason))
			{
				_localMedusaExplicitlySelected = false;
			}
			_registered = false;
			_firstCfgSeen = false;
			_liveLocalDiagnosticsSuccessLogged = false;
			_liveLocalDiagnosticsLogCount = 0;
			_nextWorldBindingPollAt = 0f;
			_nextLiveDiagnosticsAt = 0f;
			_recentCastFx.Clear();
			_recentAbilityDriver.Clear();
			_visualDiagnosticSourcesLogged.Clear();
			_visualFitSourcesLogged.Clear();
			_cachedCharConfig = null;
			_nextCharConfigScanAt = 0f;
			_lastLiveMedusaEntity = null;
			_liveRefreshScheduledAt.Clear();
			_liveRefreshScheduledOnceRoots.Clear();
			_stableLiveVisualRoots.Clear();
			_runtimeReboundVisualRoots.Clear();
			_charMaterialBoundRoots.Clear();
			_charMaterialVisibleRoots.Clear();
			_materialPreparedVisuals.Clear();
			_stableVisualLastCheapCheckAt.Clear();
			_dismissedLoadingOverlayTargets.Clear();
			_lastLoadingOverlayDismissScanAt = 0f;
			_suppressedInheritedVfxRoots.Clear();
			_localBindingRepairIds.Clear();
			_cameraTargetRepairIds.Clear();
			_cameraTargetRepairLogCount = 0;
			_autoSelectedAugmentUiIds.Clear();
			_autoAugmentScanCount = 0;
			_autoAugmentSelectCount = 0;
			_nextAutoAugmentScanAt = 0f;
			((ModBase)this).Log.Info("[Medusa] runtime scene state reset: " + reason);
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] runtime scene reset failed: " + ex.Message);
		}
	}

	private static bool ShouldClearExplicitSelectionForSceneReset(string reason)
	{
		try
		{
			string text = reason.ToLowerInvariant();
			return text.Contains("lobby", StringComparison.Ordinal) || text.Contains("menu", StringComparison.Ordinal) || text.Contains("main", StringComparison.Ordinal) || text.Contains("login", StringComparison.Ordinal);
		}
		catch
		{
			return false;
		}
	}

	private void PollOnce()
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		_pollTicks++;
		try
		{
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			UICharactersConfiguration val = ((!_registered || !_firstCfgSeen || !_phrasesInjected || _pollTicks % 5 == 0) ? FindCharConfig() : null);
			if ((Object)val != (Object)null && !_firstCfgSeen)
			{
				_firstCfgSeen = true;
				((ModBase)this).Log.Info($"[Medusa] UICharactersConfiguration first seen at poll #{_pollTicks} (roster={SafeLen(val.Characters)}).");
			}
			if (!_registered)
			{
				TryRegisterMedusa();
			}
			if (!_phrasesInjected)
			{
				TryInjectPhrases();
			}
			if (_registered && AutoSelectMedusaEnabled())
			{
				TrySendLobbySwitchCharacter(CurrentMedusaId(), "PollOnce.autoSelect");
			}
			if (realtimeSinceStartup >= _nextWorldBindingPollAt)
			{
				_nextWorldBindingPollAt = realtimeSinceStartup + 1f;
				EnsureLocalMedusaBindingFromWorld("PollOnce");
			}
			if (realtimeSinceStartup >= _nextLiveDiagnosticsAt)
			{
				_nextLiveDiagnosticsAt = realtimeSinceStartup + 2f;
				LogLiveLocalDiagnostics();
			}
			if (AutoSelectAugmentEnabled())
			{
				TryAutoSelectOpenAugment("PollOnce");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Error("[Medusa] poll: " + ex);
		}
	}

	private void LogLiveLocalDiagnostics()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Expected O, but got Unknown
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_0672: Unknown result type (might be due to invalid IL or missing references)
		//IL_067d: Expected O, but got Unknown
		try
		{
			PlayerManager local = PlayerAPI.Local;
			EntityManager auth = PlayerAPI.AuthViewCharacter;
			if ((Object)local == (Object)null && (Object)auth == (Object)null)
			{
				return;
			}
			EntityManager localEntity = (((Object)local != (Object)null) ? local.primaryCharManager : null);
			EntityManager worldMedusa = _lastLiveMedusaEntity;
			bool flag = (Object)local != (Object)null && IsMedusaId(SafeIntValue(() => local.charId));
			bool flag2 = (Object)localEntity != (Object)null && IsMedusaId(SafeIntValue(() => localEntity.charId));
			bool flag3 = (Object)auth != (Object)null && IsMedusaId(SafeIntValue(() => auth.charId));
			bool flag4 = (Object)worldMedusa != (Object)null && LooksLikeMedusaEntity(worldMedusa);
			if (!flag && !flag2 && !flag3 && !flag4)
			{
				return;
			}
			if (flag4)
			{
				RepairMedusaCameraTarget(worldMedusa, "LogLiveLocalDiagnostics");
			}
			Il2CppArrayBase<PlayerManager> val = null;
			Il2CppArrayBase<EntityManager> val2 = null;
			if (flag && flag2 && flag3)
			{
				if (!_liveLocalDiagnosticsSuccessLogged)
				{
					_liveLocalDiagnosticsSuccessLogged = true;
					val = Object.FindObjectsOfType<PlayerManager>();
					val2 = Object.FindObjectsOfType<EntityManager>();
					((ModBase)this).Log.Info($"[Medusa] live local diag ready: localPlayerId={PlayerAPI.LocalId} localChar={SafeIntValue(() => local.charId)} localPrimary='{ObjName((Object?)(object)localEntity)}' auth='{ObjName((Object?)(object)auth)}' pos={FmtPos((Component?)(object)localEntity)} screen={ScreenPos((Component?)(object)localEntity)} players={val?.Length ?? 0} entities={val2?.Length ?? 0} camera={CameraInfo()}.");
				}
			}
			else
			{
				if (_liveLocalDiagnosticsLogCount >= 12 || _pollTicks % 5 != 0)
				{
					return;
				}
				_liveLocalDiagnosticsLogCount++;
				val = Object.FindObjectsOfType<PlayerManager>();
				val2 = Object.FindObjectsOfType<EntityManager>();
				((ModBase)this).Log.Info($"[Medusa] live local diag #{_liveLocalDiagnosticsLogCount}: local={(Object)local != (Object)null} localPlayerId={PlayerAPI.LocalId} localChar={SafeIntValue(() => local.charId)} localDead={SafeBool(() => local.isDead)} localDowned={SafeInt(() => (int)local.downedState)} localIsLocal={SafeBool(() => ((NetworkBehaviour)local).isLocalPlayer)} localOwned={SafeBool(() => ((NetworkBehaviour)local).isOwned)} localPrimary='{ObjName((Object?)(object)localEntity)}' localPrimaryChar={SafeIntValue(() => localEntity.charId)} localPos={FmtPos((Component?)(object)localEntity)} localScreen={ScreenPos((Component?)(object)localEntity)} auth='{ObjName((Object?)(object)auth)}' authChar={SafeIntValue(() => auth.charId)} authPos={FmtPos((Component?)(object)auth)} authScreen={ScreenPos((Component?)(object)auth)} worldMedusa='{ObjName((Object?)(object)worldMedusa)}' worldChar={SafeIntValue(() => worldMedusa.charId)} worldPos={FmtPos((Component?)(object)worldMedusa)} worldScreen={ScreenPos((Component?)(object)worldMedusa)} spectating={SafeBool(() => PlayerAPI.IsSpectating)} players={val?.Length ?? 0} entities={val2?.Length ?? 0} camera={CameraInfo()}.");
				if (val == null || _liveLocalDiagnosticsLogCount > 3)
				{
					return;
				}
				int num = Math.Min(val.Length, 4);
				for (int num2 = 0; num2 < num; num2++)
				{
					PlayerManager player = val[num2];
					if (!((Object)player == (Object)null))
					{
						EntityManager entity = player.primaryCharManager;
						((ModBase)this).Log.Info($"[Medusa] live player[{num2}]: name='{ObjName((Object?)(object)player)}' id={SafeIntValue(() => player.playerId)} char={SafeIntValue(() => player.charId)} team={SafeIntValue(() => player.teamId)} local={SafeBool(() => ((NetworkBehaviour)player).isLocalPlayer)} owned={SafeBool(() => ((NetworkBehaviour)player).isOwned)} dead={SafeBool(() => player.isDead)} primary='{ObjName((Object?)(object)entity)}' primaryChar={SafeIntValue(() => entity.charId)} pos={FmtPos((Component?)(object)entity)} screen={ScreenPos((Component?)(object)entity)}.");
					}
				}
			}
		}
		catch (Exception ex)
		{
			if (_liveLocalDiagnosticsLogCount < 12)
			{
				((ModBase)this).Log.Warn("[Medusa] live local diag failed: " + ex.Message);
			}
		}
	}

	private static void EnsureLocalMedusaBindingFromWorld(string source)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Expected O, but got Unknown
		try
		{
			PlayerManager local = PlayerAPI.Local;
			if ((Object)local == (Object)null || !IsMedusaId(SafeIntValue(() => local.charId)))
			{
				return;
			}
			EntityManager currentPrimary = local.primaryCharManager;
			if ((Object)currentPrimary != (Object)null && IsMedusaId(SafeIntValue(() => currentPrimary.charId)))
			{
				EnsureLiveMedusaEntity(currentPrimary, source + ".primary");
				return;
			}
			string reason;
			int medusaCount;
			EntityManager candidate = FindBestLocalMedusaEntity(local, out reason, out medusaCount);
			if ((Object)candidate == (Object)null)
			{
				MedusaMod instance = _instance;
				DateTime utcNow = DateTime.UtcNow;
				if (instance != null && _localBindingNoCandidateLogCount < 4 && (utcNow - _lastLocalBindingNoCandidateLogUtc).TotalSeconds >= 5.0)
				{
					_localBindingNoCandidateLogCount++;
					_lastLocalBindingNoCandidateLogUtc = utcNow;
					((ModBase)instance).Log.Warn($"[Medusa] local binding found no Medusa entity via {source}: candidates={medusaCount} localId={SafeIntValue(() => local.playerId)} entities={SafeIntValue(() => Object.FindObjectsOfType<EntityManager>()?.Length ?? 0)}.");
				}
				return;
			}
			RepairLocalMedusaBinding(candidate, $"{source}.world.{reason}.count{medusaCount}", forceWhenLocalPrimaryMissing: true);
			EnsureLiveMedusaEntity(candidate, $"{source}.world.{reason}.count{medusaCount}");
			if (!((Object)local.primaryCharManager == (Object)null))
			{
				return;
			}
			MedusaMod instance2 = _instance;
			if (instance2 != null && _localBindingRepairLogCount < 32)
			{
				_localBindingRepairLogCount++;
				((ModBase)instance2).Log.Warn($"[Medusa] local binding still missing after {source}: candidate='{ObjName((Object?)(object)candidate)}' reason={reason} count={medusaCount} owner={SafeIntValue(() => candidate.ownerPlayerId)} getPlayerId={SafeIntValue(() => candidate.GetPlayerId())} playerObj='{ObjName((Object?)(object)candidate.playerObj)}' entityPlayer='{ObjName((Object?)(object)candidate.playerManager)}'.");
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance3 = _instance;
			if (instance3 != null && _localBindingRepairLogCount < 32)
			{
				_localBindingRepairLogCount++;
				((ModBase)instance3).Log.Warn("[Medusa] local binding world scan failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static EntityManager? FindBestLocalMedusaEntity(PlayerManager local, out string reason, out int medusaCount)
	{
		//IL_0190: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_00c9: Expected O, but got Unknown
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00fc: Expected O, but got Unknown
		reason = "none";
		medusaCount = 0;
		try
		{
			int num = SafeIntValue(() => local.playerId);
			GameObject gameObject = ((Component)local).gameObject;
			Il2CppArrayBase<EntityManager> val = Object.FindObjectsOfType<EntityManager>();
			EntityManager val2 = null;
			if (val != null)
			{
				for (int num2 = 0; num2 < val.Length; num2++)
				{
					EntityManager entity = val[num2];
					if (!((Object)entity == (Object)null) && LooksLikeMedusaEntity(entity))
					{
						medusaCount++;
						if ((Object)val2 == (Object)null)
						{
							val2 = entity;
						}
						if ((Object)entity.playerManager == (Object)local)
						{
							reason = "entityPlayerRef";
							return entity;
						}
						if ((Object)entity.playerObj == (Object)gameObject)
						{
							reason = "entityPlayerObj";
							return entity;
						}
						int num3 = SafeIntValue(() => entity.ownerPlayerId);
						int num4 = SafeIntValue(() => entity.GetPlayerId());
						if (num3 == num || num4 == num)
						{
							reason = "ownerMatch";
							return entity;
						}
					}
				}
			}
			if (medusaCount == 1 && (Object)val2 != (Object)null)
			{
				reason = "soleMedusaEntity";
				return val2;
			}
			EntityManager lastLiveMedusaEntity = _lastLiveMedusaEntity;
			if ((Object)lastLiveMedusaEntity != (Object)null && LooksLikeMedusaEntity(lastLiveMedusaEntity))
			{
				medusaCount = Math.Max(medusaCount, 1);
				reason = "lastLiveEntity";
				return lastLiveMedusaEntity;
			}
		}
		catch
		{
		}
		return null;
	}

	public void Status()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Expected O, but got Unknown
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Expected O, but got Unknown
		UICharactersConfiguration val = FindCharConfig();
		int value = (((Object)val != (Object)null) ? SafeLen(val.Characters) : (-1));
		string value2 = "?";
		try
		{
			value2 = Loc.Get("MEDUSA_AB_LMB_TITLE");
		}
		catch
		{
		}
		((ModBase)this).Log.Info($"[Medusa] registered={_registered} charId={MedusaCharId} rosterSize={value} cfgFound={(Object)val != (Object)null} phrasesInjected={_phrasesInjected} LMB.title='{value2}'");
		((ModBase)this).Log.Info($"[Medusa] graft: charAnimatorWired={_charAnimatorWired} charFootstepsWired={_charFootstepsWired} disabledNonMedusaAnims={_disabledNonMedusaAnims} toonShader='{_toonShaderApplied ?? "<not applied>"}' toonTemplateFrom='{_toonTemplateMaterialName ?? "<none>"}' harmonyFallbackFired={_harmonyRebindFiredAtLeastOnce}.");
		((ModBase)this).Log.Info($"[Medusa] petrify: SO='{(((Object)_petrifySO != (Object)null) ? ((Object)_petrifySO).name : "<not-resolved>")}' petrifyId={_petrifyId} lookupAttempted={_petrifyLookupAttempted} lookupSucceeded={_petrifyLookupSucceeded} hitsObserved={_petrifyHitObservedCount} applied={_petrifyAppliedCount}.");
		((ModBase)this).Log.Info($"[Medusa] poison: SO='{(((Object)_poisonSO != (Object)null) ? ((Object)_poisonSO).name : "<not-resolved>")}' poisonId={_poisonId} lookupAttempted={_poisonLookupAttempted} lookupSucceeded={_poisonLookupSucceeded} hitsObserved={_poisonHitObservedCount} applied={_poisonAppliedCount}.");
		((ModBase)this).Log.Info($"[Medusa] castFx: graphicsReady={CanSpawnClientFx()} recentKeys={_recentCastFx.Count} logCount={_castFxLogCount} lobbySwitchLogs={_lobbySwitchLogCount}.");
		((ModBase)this).Log.Info($"[Medusa] networkPrefab: assetId=0x{1296385109u:X8} logs={_networkPrefabLogCount} uiPaletteLogs={_abilityElementPaletteLogCount}.");
		LogAnimatorState();
	}

	private void OnAbilityCastStarted(CastStarted e)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		try
		{
			if (e != null && !((Object)e.Caster == (Object)null) && IsMedusaId(SafeIntValue(() => e.Caster.charId)))
			{
				int num = e.SlotId;
				if ((num < 0 || num > 3) && (Object)e.Ability != (Object)null)
				{
					num = GetMedusaAbilitySlot(e.Ability);
				}
				if (num >= 0 && num <= 3)
				{
					TryEmitMedusaCastFx(e.Ability, e.Caster, num, "AbilityEvents.CastStarted");
				}
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] cast FX event failed: " + ex.Message);
		}
	}

	private void PollLocalInputCastFx()
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		try
		{
			int num = -1;
			if (Input.GetMouseButtonDown(0) || Input.GetKeyDown((KeyCode)49))
			{
				num = 0;
			}
			else if (Input.GetMouseButtonDown(1) || Input.GetKeyDown((KeyCode)113) || Input.GetKeyDown((KeyCode)50))
			{
				num = 1;
			}
			else if (Input.GetKeyDown((KeyCode)32) || Input.GetKeyDown((KeyCode)102) || Input.GetKeyDown((KeyCode)51))
			{
				num = 2;
			}
			else if (Input.GetKeyDown((KeyCode)101) || Input.GetKeyDown((KeyCode)114) || Input.GetKeyDown((KeyCode)52))
			{
				num = 3;
			}
			if (num < 0)
			{
				return;
			}
			EntityManager val = FindLocalMedusaEntity();
			if (!((Object)val == (Object)null))
			{
				RunAuthoredMedusaAbilityDriver(null, val, num, "InputFallback");
				if (_castFxLogCount < 20)
				{
					((ModBase)this).Log.Info($"[Medusa] cast FX source=InputFallback slot={num}.");
				}
			}
		}
		catch (Exception ex)
		{
			if (_castFxLogCount < 20)
			{
				((ModBase)this).Log.Warn("[Medusa] input cast FX hook failed: " + ex.Message);
			}
		}
	}

	private static bool IsMedusaCastStartState(int oldState, int newState)
	{
		if (oldState >= 0 && oldState < 2)
		{
			if (newState != 2)
			{
				return newState == 3;
			}
			return true;
		}
		return false;
	}

	private static void TryRunMedusaAbilityDriverFromState(Ability? ability, int newState)
	{
		try
		{
			if (TryGetMedusaAbilityContext(ability, out EntityManager caster, out int slot))
			{
				_instance?.RunAuthoredMedusaAbilityDriver(ability, caster, slot, $"Ability.SetState:{(AbilityStates)(byte)newState}");
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null && instance._abilityDriverLogCount < 32)
			{
				instance._abilityDriverLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] state ability driver failed: " + ex.Message);
			}
		}
	}

	private static void TryRunMedusaAbilityDriverFromCastFlag(CharAbilities? abilities, CastFlags castFlag, string source)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)abilities == (Object)null)
			{
				return;
			}
			EntityManager caster = abilities.entityManager;
			if ((Object)caster == (Object)null || !IsMedusaId(SafeIntValue(() => caster.charId)))
			{
				return;
			}
			MedusaMod instance = _instance;
			if (instance == null)
			{
				return;
			}
			ApplyMedusaAbilityRuntimeUi(abilities, source);
			instance.SuppressInheritedKitsuAbilityVfx(abilities, source);
			for (int num = 0; num <= 3; num++)
			{
				CastFlags val = (CastFlags)(num switch
				{
					0 => 1, 
					1 => 2, 
					2 => 4, 
					3 => 8, 
					_ => 0, 
				});
				if ((int)val != 0 && (castFlag & val) != 0)
				{
					Ability ability = TryGetAbilityBySlot(abilities, num);
					instance.RunAuthoredMedusaAbilityDriver(ability, caster, num, source);
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null && instance2._abilityDriverLogCount < 32)
			{
				instance2._abilityDriverLogCount++;
				((ModBase)instance2).Log.Warn("[Medusa] cast flag ability driver failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static EntityManager? FindLocalMedusaEntity()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		try
		{
			PlayerManager local = PlayerAPI.Local;
			EntityManager entity = (((Object)local != (Object)null) ? local.primaryCharManager : null);
			if ((Object)entity != (Object)null && IsMedusaId(SafeIntValue(() => entity.charId)))
			{
				return entity;
			}
		}
		catch
		{
		}
		try
		{
			Il2CppArrayBase<EntityManager> val = Object.FindObjectsOfType<EntityManager>();
			if (val != null)
			{
				for (int num = 0; num < val.Length; num++)
				{
					EntityManager entity2 = val[num];
					if ((Object)entity2 != (Object)null && IsMedusaId(SafeIntValue(() => entity2.charId)))
					{
						return entity2;
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static Ability? TryGetAbilityBySlot(CharAbilities? abilities, int slot)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		try
		{
			if ((Object)abilities == (Object)null || slot < 0)
			{
				return null;
			}
			Il2CppReferenceArray<Ability> abilities2 = abilities.abilities;
			if (abilities2 == null || slot >= ((Il2CppArrayBase<Ability>)(object)abilities2).Length)
			{
				return null;
			}
			return ((Il2CppArrayBase<Ability>)(object)abilities2)[slot];
		}
		catch
		{
			return null;
		}
	}

	private static void TryEmitMedusaCastFx(Ability? ability, EntityManager? caster, int slot, string source)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		try
		{
			MedusaMod instance = _instance;
			if (instance == null)
			{
				return;
			}
			if ((Object)caster == (Object)null && (Object)ability != (Object)null)
			{
				caster = ability.entityManager;
			}
			if ((Object)caster == (Object)null || !IsMedusaId(SafeIntValue(() => caster.charId)))
			{
				return;
			}
			if ((slot < 0 || slot > 3) && (Object)ability != (Object)null)
			{
				slot = GetMedusaAbilitySlot(ability);
			}
			if (slot < 0 || slot > 3)
			{
				return;
			}
			ApplyLiveAbilityUiPalette("castFx." + source);
			if (instance.ShouldEmitCastFx(ability, slot))
			{
				instance.SpawnMedusaCastFx(caster, slot, ability);
				if (instance._castFxLogCount < 20)
				{
					((ModBase)instance).Log.Info($"[Medusa] cast FX source={source} slot={slot}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] direct cast FX hook failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static bool TrySuppressInheritedKitsuShoot(Ability? ability, string source)
	{
		try
		{
			if (!TryGetMedusaAbilityContext(ability, out EntityManager caster, out int slot))
			{
				return false;
			}
			MedusaMod instance = _instance;
			if (instance == null)
			{
				return true;
			}
			instance.RunAuthoredMedusaAbilityDriver(ability, caster, slot, source);
			return true;
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null && instance2._abilityDriverLogCount < 24)
			{
				instance2._abilityDriverLogCount++;
				((ModBase)instance2).Log.Warn("[Medusa] inherited Kitsu Shoot intercept failed via " + source + ": " + ex.Message);
			}
			return false;
		}
	}

	private static bool TryGetMedusaAbilityContext(Ability? ability, out EntityManager caster, out int slot)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected O, but got Unknown
		caster = null;
		slot = -1;
		try
		{
			if ((Object)ability == (Object)null)
			{
				return false;
			}
			EntityManager resolvedCaster = ability.entityManager;
			if ((Object)resolvedCaster == (Object)null || !IsMedusaId(SafeIntValue(() => resolvedCaster.charId)))
			{
				return false;
			}
			caster = resolvedCaster;
			slot = GetMedusaAbilitySlot(ability);
			return slot >= 0 && slot <= 3;
		}
		catch
		{
			return false;
		}
	}

	private void RunAuthoredMedusaAbilityDriver(Ability? ability, EntityManager caster, int slot, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		if (!((Object)caster == (Object)null) && slot >= 0 && slot <= 3 && ShouldRunAbilityDriver(ability, caster, slot))
		{
			ApplyMedusaAbilityRuntimeUi(ability, source + ".driver");
			SuppressInheritedKitsuAbilityVfx(caster.charAbilities, source + ".driver");
			PlayMedusaAbilityAnimation(caster, slot, source);
			SpawnMedusaCastFx(caster, slot, ability);
			ReassertMedusaVisibilityAfterAbilityCast(caster, source);
			int value = 0;
			if (IsAuthoritativeServer(caster))
			{
				value = ApplyAuthoredMedusaGameplay(caster, slot, source);
			}
			if (_abilityDriverLogCount < 32)
			{
				_abilityDriverLogCount++;
				((ModBase)this).Log.Info($"[Medusa] authored ability driver via {source}: slot={slot} server={IsAuthoritativeServer(caster)} hits={value}; inherited Kitsu Shoot suppressed.");
			}
		}
	}

	private static void PlayMedusaAbilityAnimation(EntityManager caster, int slot, string source)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		if (slot == 2)
		{
			return;
		}
		try
		{
			Animator val = FindMedusaAnimatorUnder(((Component)caster).gameObject.transform);
			if (!((Object)val == (Object)null))
			{
				string text = slot switch
				{
					0 => "Ability1", 
					1 => "Ability2", 
					3 => "Ability4", 
					_ => string.Empty, 
				};
				if (text.Length != 0)
				{
					val.CrossFade(text, 0.05f, -1, 0f);
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null && instance._abilityDriverLogCount < 32)
			{
				instance._abilityDriverLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] ability animation failed via " + source + ": " + ex.Message);
			}
		}
	}

	private void ReassertMedusaVisibilityAfterAbilityCast(EntityManager caster, string source)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Expected O, but got Unknown
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		try
		{
			Reassert("+now");
			TimerAPI.Once(0.03f, (Action)delegate
			{
				Reassert("+0.03s");
			}, (ModBase)this);
			TimerAPI.Once(0.12f, (Action)delegate
			{
				Reassert("+0.12s");
			}, (ModBase)this);
			TimerAPI.Once(0.3f, (Action)delegate
			{
				Reassert("+0.30s");
			}, (ModBase)this);
			TimerAPI.Once(0.7f, (Action)delegate
			{
				Reassert("+0.70s");
			}, (ModBase)this);
		}
		catch
		{
		}
		void Reassert(string suffix)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Expected O, but got Unknown
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_003a: Expected O, but got Unknown
			try
			{
				if (!((Object)caster == (Object)null))
				{
					GameObject gameObject = ((Component)caster).gameObject;
					GameObject val = FindMedusaVisualObject(gameObject);
					if (!((Object)val == (Object)null))
					{
						ForceMedusaCharMaterialVisible(gameObject, val, source + ".abilityVisibility" + suffix);
					}
				}
			}
			catch
			{
			}
		}
	}

	private bool ShouldRunAbilityDriver(Ability? ability, EntityManager caster, int slot)
	{
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		long num = 0L;
		try
		{
			int num2 = SafeIntValue(() => caster.ownerPlayerId);
			if (num2 <= 0)
			{
				num2 = SafeIntValue(() => caster.GetPlayerId());
			}
			if (num2 > 0)
			{
				num = num2;
			}
		}
		catch
		{
		}
		try
		{
			if (num == 0L)
			{
				num = ((Il2CppObjectBase)caster).Pointer.ToInt64();
			}
		}
		catch
		{
		}
		if (num == 0L)
		{
			try
			{
				if ((Object)ability != (Object)null)
				{
					num = ((Il2CppObjectBase)ability).Pointer.ToInt64();
				}
			}
			catch
			{
			}
		}
		long key = (num << 4) ^ (slot & 0xF);
		float num3;
		try
		{
			num3 = Time.unscaledTime;
		}
		catch
		{
			num3 = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
		}
		if (_recentAbilityDriver.TryGetValue(key, out var value) && num3 - value < 0.28f)
		{
			return false;
		}
		_recentAbilityDriver[key] = num3;
		if (_recentAbilityDriver.Count > 128)
		{
			_recentAbilityDriver.Clear();
		}
		return true;
	}

	private static bool IsAuthoritativeServer(EntityManager entity)
	{
		try
		{
			return ((NetworkBehaviour)entity).isServer;
		}
		catch
		{
			return false;
		}
	}

	private int ApplyAuthoredMedusaGameplay(EntityManager caster, int slot, string source)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Vector3 origin = SafeEntityPosition(caster);
			Vector3 val = SafeAimDirection(caster);
			int num = SafeIntValue(() => caster.ownerPlayerId);
			if (num <= 0)
			{
				num = SafeIntValue(() => caster.GetPlayerId());
			}
			List<EntityManager> list = FindMedusaAbilityTargets(caster, slot, origin, val);
			int num2 = 0;
			for (int num3 = 0; num3 < list.Count; num3++)
			{
				EntityManager val2 = list[num3];
				if (!((Object)val2 == (Object)null) && ApplyAuthoredMedusaHit(caster, val2, slot, num, origin, val))
				{
					num2++;
				}
			}
			if (slot == 2)
			{
				ApplyMedusaSlitherMovement(caster, val);
			}
			return num2;
		}
		catch (Exception ex)
		{
			if (_abilityDriverLogCount < 32)
			{
				_abilityDriverLogCount++;
				((ModBase)this).Log.Warn("[Medusa] authored gameplay failed via " + source + ": " + ex.Message);
			}
			return 0;
		}
	}

	private void ApplyMedusaSlitherMovement(EntityManager caster, Vector3 direction)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((Object)caster.charMove == (Object)null))
			{
				Vector3 val = direction * 4.25f;
				caster.charMove.PostMove(val, (PostMoveTypes)1, false);
				if (_abilityDriverLogCount < 32)
				{
					_abilityDriverLogCount++;
					((ModBase)this).Log.Info($"[Medusa] Slither moved authoritative entity by ({val.x:F1},{val.y:F1},{val.z:F1}).");
				}
			}
		}
		catch (Exception ex)
		{
			if (_abilityDriverLogCount < 32)
			{
				_abilityDriverLogCount++;
				((ModBase)this).Log.Warn("[Medusa] Slither movement failed: " + ex.Message);
			}
		}
	}

	private static List<EntityManager> FindMedusaAbilityTargets(EntityManager caster, int slot, Vector3 origin, Vector3 dir)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		List<EntityManager> list = new List<EntityManager>();
		try
		{
			Il2CppArrayBase<EntityManager> val = Object.FindObjectsOfType<EntityManager>();
			if (val == null)
			{
				return list;
			}
			for (int i = 0; i < val.Length; i++)
			{
				EntityManager val2 = val[i];
				if (!IsValidMedusaAbilityTarget(caster, val2))
				{
					continue;
				}
				Vector3 val3 = SafeEntityPosition(val2) - origin;
				val3.y = 0f;
				float magnitude = ((Vector3)(ref val3)).magnitude;
				if (!(magnitude < 0.01f))
				{
					Vector3 val4 = dir;
					val4.y = 0f;
					if (((Vector3)(ref val4)).sqrMagnitude < 0.01f)
					{
						val4 = Vector3.forward;
					}
					((Vector3)(ref val4)).Normalize();
					float num = Vector3.Dot(val3, val4);
					Vector3 val5 = val3 - val4 * num;
					float magnitude2 = ((Vector3)(ref val5)).magnitude;
					if (slot switch
					{
						0 => num > 0f && num <= 9.2f && magnitude2 <= 0.9f, 
						1 => num > 0f && num <= 6f && magnitude2 <= 2.25f, 
						2 => magnitude <= 2.75f, 
						3 => num > 0f && num <= 11.5f && magnitude2 <= 1.35f, 
						_ => false, 
					})
					{
						list.Add(val2);
					}
				}
			}
			if (slot == 0 && list.Count > 1)
			{
				list.Sort((EntityManager a, EntityManager b) => Vector3.Distance(origin, SafeEntityPosition(a)).CompareTo(Vector3.Distance(origin, SafeEntityPosition(b))));
				while (list.Count > 1)
				{
					list.RemoveAt(list.Count - 1);
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private static bool IsValidMedusaAbilityTarget(EntityManager caster, EntityManager target)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Expected O, but got Unknown
		//IL_0055: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		if ((Object)caster == (Object)null || (Object)target == (Object)null || (Object)caster == (Object)target)
		{
			return false;
		}
		try
		{
			if (IsMedusaId(SafeIntValue(() => target.charId)) && SafeIntValue(() => target.ownerPlayerId) == SafeIntValue(() => caster.ownerPlayerId))
			{
				return false;
			}
		}
		catch
		{
		}
		try
		{
			if (target.isItem || target.isLootbox || target.isInteractable)
			{
				return false;
			}
		}
		catch
		{
		}
		try
		{
			if ((Object)target.charHurtbox == (Object)null || target.charHurtbox.isDead || target.charHurtbox.nonDamagable)
			{
				return false;
			}
		}
		catch
		{
		}
		int num = SafeIntValue(() => caster.entityTeamId);
		int num2 = SafeIntValue(() => target.entityTeamId);
		if (num >= 0 && num2 >= 0 && num == num2)
		{
			return false;
		}
		int num3 = SafeIntValue(() => caster.ownerPlayerId);
		int num4 = SafeIntValue(() => target.ownerPlayerId);
		if (num3 > 0 && num4 > 0)
		{
			return num3 != num4;
		}
		return true;
	}

	private bool ApplyAuthoredMedusaHit(EntityManager caster, EntityManager target, int slot, int ownerPlayerId, Vector3 origin, Vector3 dir)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			CharHurtbox charHurtbox = target.charHurtbox;
			if ((Object)charHurtbox == (Object)null)
			{
				return false;
			}
			StatusEffectInfo[] array = BuildMedusaStatusEffects(slot);
			Vector3 val = SafeEntityPosition(target) - origin;
			val.y = 0f;
			if (((Vector3)(ref val)).sqrMagnitude < 0.01f)
			{
				val = dir;
			}
			((Vector3)(ref val)).Normalize();
			GameObject val2 = null;
			try
			{
				val2 = ((Component)caster).gameObject;
			}
			catch
			{
			}
			charHurtbox.ApplyHit(slot switch
			{
				0 => 120, 
				1 => 85, 
				2 => 70, 
				3 => 160, 
				_ => 0, 
			}, Il2CppReferenceArray<StatusEffectInfo>.op_Implicit(array), ownerPlayerId, val2, false, false, true, true, false, val, true, false, (Collider)null);
			return true;
		}
		catch (Exception ex)
		{
			if (_abilityDriverLogCount < 32)
			{
				_abilityDriverLogCount++;
				((ModBase)this).Log.Warn($"[Medusa] authored hit failed: slot={slot} target='{ObjName((Object?)(object)target)}': {ex.Message}");
			}
			return false;
		}
	}

	private static StatusEffectInfo[] BuildMedusaStatusEffects(int slot)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected O, but got Unknown
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Expected O, but got Unknown
		List<StatusEffectInfo> list = new List<StatusEffectInfo>();
		try
		{
			if ((slot == 0 || slot == 1 || slot == 2) && TryResolvePoisonSO() && (Object)_poisonSO != (Object)null)
			{
				list.Add(new StatusEffectInfo(_poisonSO, (slot == 1) ? 4f : 3f, 1f));
			}
			if (slot == 3 && TryResolvePetrifySO() && (Object)_petrifySO != (Object)null)
			{
				list.Add(new StatusEffectInfo(_petrifySO, 2.5f, 1f));
			}
		}
		catch
		{
		}
		if (list.Count != 0)
		{
			return list.ToArray();
		}
		return Array.Empty<StatusEffectInfo>();
	}

	private static Vector3 SafeEntityPosition(EntityManager entity)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return ((Component)entity).transform.position;
		}
		catch
		{
			return Vector3.zero;
		}
	}

	private static Vector3 SafeAimDirection(EntityManager caster)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		Vector3 result;
		try
		{
			CharAim charAim = caster.charAim;
			if ((Object)charAim != (Object)null)
			{
				result = charAim.lookDir;
				if (((Vector3)(ref result)).sqrMagnitude > 0.01f)
				{
					Vector3 lookDir = charAim.lookDir;
					lookDir.y = 0f;
					if (((Vector3)(ref lookDir)).sqrMagnitude > 0.01f)
					{
						((Vector3)(ref lookDir)).Normalize();
						result = lookDir;
						goto IL_0098;
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			Vector3 forward = ((Component)caster).transform.forward;
			forward.y = 0f;
			if (((Vector3)(ref forward)).sqrMagnitude > 0.01f)
			{
				((Vector3)(ref forward)).Normalize();
				result = forward;
				goto IL_0098;
			}
		}
		catch
		{
		}
		return Vector3.forward;
		IL_0098:
		return result;
	}

	private bool ShouldEmitCastFx(Ability? ability, int slot)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		long num = 0L;
		try
		{
			if ((Object)ability != (Object)null)
			{
				num = ((Il2CppObjectBase)ability).Pointer.ToInt64();
			}
		}
		catch
		{
		}
		long key = (num << 4) ^ slot;
		float num2;
		try
		{
			num2 = Time.unscaledTime;
		}
		catch
		{
			num2 = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
		}
		if (_recentCastFx.TryGetValue(key, out var value) && num2 - value < 0.18f)
		{
			return false;
		}
		_recentCastFx[key] = num2;
		if (_recentCastFx.Count > 128)
		{
			_recentCastFx.Clear();
		}
		return true;
	}

	private void SpawnMedusaCastFx(EntityManager caster, int slot, Ability? ability)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		if (!CanSpawnClientFx())
		{
			return;
		}
		Transform val = null;
		try
		{
			val = ((Component)caster).transform;
		}
		catch
		{
		}
		if ((Object)val == (Object)null)
		{
			return;
		}
		Vector3 origin = val.position + Vector3.up * 0.75f;
		Vector3 dir = Vector3.zero;
		try
		{
			CharAim val2 = (((Object)ability != (Object)null) ? ability.charAim : caster.charAim);
			if ((Object)val2 != (Object)null)
			{
				dir = val2.lookDir;
			}
		}
		catch
		{
		}
		if (((Vector3)(ref dir)).sqrMagnitude < 0.01f)
		{
			dir = val.forward;
		}
		dir.y = 0f;
		if (((Vector3)(ref dir)).sqrMagnitude < 0.01f)
		{
			dir = Vector3.forward;
		}
		((Vector3)(ref dir)).Normalize();
		if (TrySpawnNativeMedusaCastFx(val, origin, dir, slot))
		{
			if (_castFxLogCount < 20)
			{
				_castFxLogCount++;
				((ModBase)this).Log.Info($"[Medusa] native cast FX emitted: slot={slot} prefabCount={_medusaNativeVfxPrefabs.Count}.");
			}
		}
		else if (_castFxLogCount < 20)
		{
			_castFxLogCount++;
			((ModBase)this).Log.Warn($"[Medusa] authored VFX unavailable for slot={slot}; green primitive fallback intentionally disabled.");
		}
	}

	private bool TrySpawnNativeMedusaCastFx(Transform casterTransform, Vector3 origin, Vector3 dir, int slot)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		if (_medusaNativeVfxPrefabs.Count == 0)
		{
			return false;
		}
		try
		{
			Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
			Vector3 val = casterTransform.position + Vector3.up * 0.04f;
			bool flag = false;
			switch (slot)
			{
			case 0:
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Muzzle", origin + dir * 0.45f, rotation, 1.25f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Trail", origin + dir * 2.2f, rotation, 1f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Hit", origin + dir * 6.8f, rotation, 1f);
				break;
			case 1:
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Muzzle", origin + dir * 0.5f, rotation, 1.2f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Trail", origin + dir * 1.8f, rotation, 1f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Puddle", val + dir * 2.8f, rotation, 2.4f);
				break;
			case 2:
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Escape", val, rotation, 1.4f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Trail", val - dir * 1.2f + Vector3.up * 0.2f, rotation, 1f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Puddle", val, rotation, 1.3f);
				break;
			case 3:
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Muzzle", origin + Vector3.up * 0.16f, rotation, 1.35f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Wall", casterTransform.position + dir * 4.6f + Vector3.up * 0.04f, rotation, 1.8f);
				flag |= SpawnNativeMedusaVfx("VFX_Medusa_Poison_Hit", origin + dir * 7.2f, rotation, 1.25f);
				break;
			}
			return flag;
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] native cast FX failed: " + ex.Message);
			return false;
		}
	}

	private bool SpawnNativeMedusaVfx(string prefabName, Vector3 position, Quaternion rotation, float ttl)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		GameObject val = ResolveNativeMedusaVfxPrefab(prefabName);
		if ((Object)val == (Object)null)
		{
			if (_nativeVfxSpawnLogCount < 24)
			{
				_nativeVfxSpawnLogCount++;
				((ModBase)this).Log.Warn($"[Medusa] native FX prefab unavailable: '{prefabName}' cached={_medusaNativeVfxPrefabs.Count} bundleLoaded={_bundleLoaded}.");
			}
			return false;
		}
		try
		{
			GameObject val2 = Object.Instantiate<GameObject>(val);
			if ((Object)val2 == (Object)null)
			{
				return false;
			}
			((Object)val2).name = "MedusaFX_Native_" + prefabName;
			((Object)val2).hideFlags = (HideFlags)52;
			val2.transform.position = position;
			val2.transform.rotation = rotation;
			val2.transform.localScale = Vector3.one * NativeVfxRootScale(prefabName);
			DisableNativeVfxGameplay(val2);
			val2.SetActive(true);
			SanitizeNativeMedusaVfxRenderers(val2, prefabName);
			Object.Destroy((Object)val2, ttl);
			if (_nativeVfxSpawnLogCount < 24)
			{
				_nativeVfxSpawnLogCount++;
				int value = 0;
				int value2 = 0;
				try
				{
					value = val2.GetComponentsInChildren<ParticleSystem>(true).Length;
					value2 = val2.GetComponentsInChildren<Renderer>(true).Length;
				}
				catch
				{
				}
				((ModBase)this).Log.Info($"[Medusa] native FX spawned: name='{prefabName}' particles={value} renderers={value2} ttl={ttl:F2}.");
			}
			return true;
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] native FX '" + prefabName + "' failed: " + ex.Message);
			return false;
		}
	}

	private GameObject? ResolveNativeMedusaVfxPrefab(string prefabName)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected O, but got Unknown
		if (_medusaNativeVfxPrefabs.TryGetValue(prefabName, out GameObject value) && (Object)value != (Object)null)
		{
			return value;
		}
		try
		{
			Type goType = Il2CppType.Of<GameObject>();
			GameObject val = TryLoadAssetTyped(prefabName, goType) ?? TryLoadAssetTyped("Assets/GameObject/MedusaVfx/" + prefabName + ".prefab", goType) ?? TryLoadAssetTyped("Assets/GameObject/" + prefabName + ".prefab", goType);
			if ((Object)val != (Object)null)
			{
				_medusaNativeVfxPrefabs[prefabName] = val;
				return val;
			}
		}
		catch
		{
		}
		return null;
	}

	private static void DisableNativeVfxGameplay(GameObject root)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		try
		{
			Il2CppArrayBase<Collider> componentsInChildren = root.GetComponentsInChildren<Collider>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Collider val = componentsInChildren[i];
				if ((Object)val != (Object)null)
				{
					val.enabled = false;
				}
			}
		}
		catch
		{
		}
		try
		{
			Il2CppArrayBase<Rigidbody> componentsInChildren2 = root.GetComponentsInChildren<Rigidbody>(true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				Rigidbody val2 = componentsInChildren2[j];
				if ((Object)val2 != (Object)null)
				{
					val2.isKinematic = true;
					val2.detectCollisions = false;
					val2.useGravity = false;
				}
			}
		}
		catch
		{
		}
		try
		{
			Il2CppArrayBase<MonoBehaviour> componentsInChildren3 = root.GetComponentsInChildren<MonoBehaviour>(true);
			for (int k = 0; k < componentsInChildren3.Length; k++)
			{
				MonoBehaviour val3 = componentsInChildren3[k];
				if ((Object)val3 == (Object)null)
				{
					continue;
				}
				string text = ((object)val3).GetType().Name ?? "";
				try
				{
					Type il2CppType = ((Object)val3).GetIl2CppType();
					if (il2CppType != (Type)null)
					{
						text = ((MemberInfo)il2CppType).Name ?? text;
					}
				}
				catch
				{
				}
				if (text.IndexOf("Network", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Hitbox", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Damage", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Projectile", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Ability", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Gameplay", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Dps", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Spawner", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					((Behaviour)val3).enabled = false;
				}
			}
		}
		catch
		{
		}
	}

	private static float NativeVfxRootScale(string prefabName)
	{
		if (string.Equals(prefabName, "VFX_Medusa_Poison_Puddle", StringComparison.OrdinalIgnoreCase))
		{
			return 0.55f;
		}
		if (string.Equals(prefabName, "VFX_Medusa_Poison_Trail", StringComparison.OrdinalIgnoreCase))
		{
			return 0.7f;
		}
		if (string.Equals(prefabName, "VFX_Medusa_Poison_Hit", StringComparison.OrdinalIgnoreCase))
		{
			return 0.62f;
		}
		if (string.Equals(prefabName, "VFX_Medusa_Poison_Escape", StringComparison.OrdinalIgnoreCase))
		{
			return 0.65f;
		}
		if (string.Equals(prefabName, "VFX_Medusa_Poison_Wall", StringComparison.OrdinalIgnoreCase))
		{
			return 0.18f;
		}
		return 0.75f;
	}

	private static Color NativeVfxColor(string prefabName)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		if (string.Equals(prefabName, "VFX_Medusa_Poison_Wall", StringComparison.OrdinalIgnoreCase) || string.Equals(prefabName, "VFX_Medusa_Poison_Hit", StringComparison.OrdinalIgnoreCase))
		{
			return MedusaPetrifyFxColor;
		}
		if (string.Equals(prefabName, "VFX_Medusa_Poison_Puddle", StringComparison.OrdinalIgnoreCase))
		{
			return MedusaVenomPuddleColor;
		}
		return MedusaVenomFxColor;
	}

	private void SanitizeNativeMedusaVfxRenderers(GameObject root, string prefabName)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_012e: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		try
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			try
			{
				Il2CppArrayBase<ParticleSystem> componentsInChildren = root.GetComponentsInChildren<ParticleSystem>(true);
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					ParticleSystem val = componentsInChildren[i];
					if (!((Object)val == (Object)null))
					{
						val.Clear(true);
						val.Play(true);
						val.Simulate(0.05f, true, false, true);
					}
				}
			}
			catch
			{
			}
			Il2CppArrayBase<Renderer> componentsInChildren2 = root.GetComponentsInChildren<Renderer>(true);
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				Renderer val2 = componentsInChildren2[j];
				if ((Object)val2 == (Object)null)
				{
					continue;
				}
				num++;
				try
				{
					val2.receiveShadows = false;
					val2.shadowCastingMode = (ShadowCastingMode)0;
					if (ShouldReplaceNativeVfxRendererMaterial(val2, prefabName))
					{
						Material val3 = CreateNativeVfxReplacementMaterial(val2, prefabName);
						if ((Object)val3 != (Object)null)
						{
							val2.sharedMaterial = val3;
							val2.enabled = true;
							num3++;
						}
						else
						{
							val2.enabled = false;
						}
					}
					if (val2.enabled)
					{
						num2++;
						Material val4 = val2.sharedMaterial;
						if ((Object)val4 == (Object)null)
						{
							val4 = val2.material;
						}
						Shader val5 = (((Object)val4 != (Object)null) ? val4.shader : null);
						if ((Object)val5 != (Object)null)
						{
							hashSet.Add(((Object)val5).name ?? "<unnamed>");
						}
					}
				}
				catch
				{
				}
			}
			if (_nativeVfxMaterialRepairLogCount < 24)
			{
				_nativeVfxMaterialRepairLogCount++;
				((ModBase)this).Log.Info($"[Medusa] native FX renderer repair: name='{prefabName}' renderers={num} enabled={num2} repaired={num3} shaders=[{string.Join(", ", hashSet)}].");
			}
		}
		catch (Exception ex)
		{
			if (_nativeVfxMaterialRepairLogCount < 24)
			{
				_nativeVfxMaterialRepairLogCount++;
				((ModBase)this).Log.Warn("[Medusa] native FX renderer repair failed for '" + prefabName + "': " + ex.Message);
			}
		}
	}

	private Material? CreateNativeVfxReplacementMaterial(Renderer renderer, string prefabName)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_018e: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		Material val = null;
		int num = 0;
		try
		{
			val = renderer.sharedMaterial;
			if ((Object)val == (Object)null)
			{
				val = renderer.material;
			}
			if ((Object)val != (Object)null)
			{
				num = ((Object)val).GetInstanceID();
				if (_nativeVfxReplacementMaterials.TryGetValue(num, out Material value) && (Object)value != (Object)null)
				{
					return value;
				}
			}
		}
		catch
		{
		}
		Shader val2 = null;
		string[] array = new string[4] { "Universal Render Pipeline/Particles/Unlit", "Particles/Standard Unlit", "Legacy Shaders/Particles/Additive", "Sprites/Default" };
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				Shader val3 = Shader.Find(array[i]);
				if ((Object)val3 != (Object)null && val3.isSupported)
				{
					val2 = val3;
					break;
				}
			}
			catch
			{
			}
		}
		if ((Object)val2 == (Object)null)
		{
			return null;
		}
		Material val4 = new Material(val2)
		{
			name = "MedusaVfxRuntime_" + prefabName,
			color = Color.white
		};
		Texture val5 = null;
		if ((Object)val != (Object)null)
		{
			string[] array2 = new string[4] { "_Tex", "_MainTex", "_BaseMap", "_EmissionMap" };
			for (int j = 0; j < array2.Length; j++)
			{
				try
				{
					string text = array2[j];
					if (val.HasProperty(text))
					{
						Texture texture = val.GetTexture(text);
						if ((Object)texture != (Object)null)
						{
							val5 = texture;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		if ((Object)val5 != (Object)null)
		{
			string[] array3 = new string[2] { "_BaseMap", "_MainTex" };
			for (int k = 0; k < array3.Length; k++)
			{
				try
				{
					string text2 = array3[k];
					if (val4.HasProperty(text2))
					{
						val4.SetTexture(text2, val5);
					}
				}
				catch
				{
				}
			}
		}
		try
		{
			if (val4.HasProperty("_Surface"))
			{
				val4.SetFloat("_Surface", 1f);
			}
			if (val4.HasProperty("_Blend"))
			{
				val4.SetFloat("_Blend", 0f);
			}
			if (val4.HasProperty("_SrcBlend"))
			{
				val4.SetInt("_SrcBlend", 5);
			}
			if (val4.HasProperty("_DstBlend"))
			{
				val4.SetInt("_DstBlend", 10);
			}
			if (val4.HasProperty("_ZWrite"))
			{
				val4.SetInt("_ZWrite", 0);
			}
			val4.SetOverrideTag("RenderType", "Transparent");
			val4.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
			val4.EnableKeyword("_ALPHABLEND_ON");
			val4.renderQueue = 3000;
		}
		catch
		{
		}
		if (num != 0)
		{
			_nativeVfxReplacementMaterials[num] = val4;
		}
		return val4;
	}

	private static bool ShouldReplaceNativeVfxRendererMaterial(Renderer renderer, string prefabName)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		try
		{
			Material val = renderer.sharedMaterial;
			if ((Object)val == (Object)null)
			{
				val = renderer.material;
			}
			if ((Object)val == (Object)null)
			{
				return true;
			}
			Shader shader = val.shader;
			string text = (((Object)shader != (Object)null) ? (((Object)shader).name ?? string.Empty) : string.Empty);
			if (text.Length == 0 || text.IndexOf("InternalError", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("/Lush/", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Uber_Particles", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				return true;
			}
		}
		catch
		{
			return true;
		}
		return false;
	}

	private static bool CanSpawnClientFx()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Invalid comparison between Unknown and I4
		try
		{
			if (Application.isBatchMode)
			{
				return false;
			}
			if ((int)SystemInfo.graphicsDeviceType == 4)
			{
				return false;
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	private static void SpawnMedusaBeam(Vector3 origin, Vector3 dir, float length, float width, float ttl, Color color, string name)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		try
		{
			GameObject val = new GameObject("MedusaFX_" + name)
			{
				hideFlags = (HideFlags)52
			};
			LineRenderer obj = val.AddComponent<LineRenderer>();
			obj.useWorldSpace = true;
			obj.positionCount = 2;
			obj.SetPosition(0, origin);
			obj.SetPosition(1, origin + ((Vector3)(ref dir)).normalized * length);
			obj.startWidth = width;
			obj.endWidth = width * 0.12f;
			obj.startColor = color;
			obj.endColor = new Color(color.r, color.g, color.b, 0f);
			((Renderer)obj).material = MakeFxMaterial(color, transparent: true);
			Object.Destroy((Object)val, ttl);
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] beam FX failed: " + ex.Message);
			}
		}
	}

	private static void SpawnMedusaOrb(Vector3 pos, float radius, float ttl, Color color, string name)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		try
		{
			GameObject obj = GameObject.CreatePrimitive((PrimitiveType)0);
			((Object)obj).name = "MedusaFX_" + name;
			((Object)obj).hideFlags = (HideFlags)52;
			obj.transform.position = pos;
			obj.transform.localScale = Vector3.one * radius;
			TryDestroyCollider(obj);
			ApplyMaterial(obj, color, transparent: true);
			Object.Destroy((Object)obj, ttl);
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] orb FX failed: " + ex.Message);
			}
		}
	}

	private static void SpawnMedusaPuddle(Vector3 pos, float radius, float ttl, Color color, string name)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		try
		{
			GameObject obj = GameObject.CreatePrimitive((PrimitiveType)2);
			((Object)obj).name = "MedusaFX_" + name;
			((Object)obj).hideFlags = (HideFlags)52;
			obj.transform.position = pos;
			obj.transform.localScale = new Vector3(radius, 0.035f, radius);
			TryDestroyCollider(obj);
			ApplyMaterial(obj, color, transparent: true);
			Object.Destroy((Object)obj, ttl);
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] puddle FX failed: " + ex.Message);
			}
		}
	}

	private static void ApplyMaterial(GameObject go, Color color, bool transparent)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		Renderer component = go.GetComponent<Renderer>();
		if (!((Object)component == (Object)null))
		{
			component.material = MakeFxMaterial(color, transparent);
		}
	}

	private static Material MakeFxMaterial(Color color, bool transparent)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		Shader val = null;
		try
		{
			val = Shader.Find("Sprites/Default");
		}
		catch
		{
		}
		if ((Object)val == (Object)null)
		{
			try
			{
				val = Shader.Find("Unlit/Color");
			}
			catch
			{
			}
		}
		if ((Object)val == (Object)null)
		{
			try
			{
				val = Shader.Find("Standard");
			}
			catch
			{
			}
		}
		Material val2 = (((Object)val != (Object)null) ? new Material(val) : new Material(Shader.Find("Hidden/InternalErrorShader")));
		val2.color = color;
		if (transparent)
		{
			try
			{
				val2.SetInt("_SrcBlend", 5);
			}
			catch
			{
			}
			try
			{
				val2.SetInt("_DstBlend", 10);
			}
			catch
			{
			}
			try
			{
				val2.SetInt("_ZWrite", 0);
			}
			catch
			{
			}
			try
			{
				val2.EnableKeyword("_ALPHABLEND_ON");
			}
			catch
			{
			}
			try
			{
				val2.renderQueue = 3000;
			}
			catch
			{
			}
		}
		return val2;
	}

	private static void TryDestroyCollider(GameObject go)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Expected O, but got Unknown
		try
		{
			Collider component = go.GetComponent<Collider>();
			if ((Object)component != (Object)null)
			{
				Object.Destroy((Object)component);
			}
		}
		catch
		{
		}
	}

	public void TryRegisterMedusa()
	{
		TryRegisterMedusa(null);
	}

	private void TryRegisterMedusa(UICharactersConfiguration? explicitCfg)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Expected O, but got Unknown
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected O, but got Unknown
		if (_registered)
		{
			try
			{
				UICharactersConfiguration val = explicitCfg ?? FindCharConfig();
				if ((Object)val != (Object)null)
				{
					MoveMedusaIntoVisibleMatchSlot(val, "TryRegisterMedusa.registered");
					MakeRosterAvailable(val);
				}
			}
			catch
			{
			}
			EnsureMedusaPrefabRegistered(CurrentMedusaId(), "TryRegisterMedusa.registered");
			TuneCharAbilities(CurrentMedusaId());
			TryInjectPhrases();
			return;
		}
		try
		{
			UICharactersConfiguration val2 = explicitCfg ?? FindCharConfig();
			if ((Object)val2 == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] UICharactersConfiguration not loaded yet.");
				return;
			}
			Il2CppReferenceArray<CharacterConfiguration> characters = val2.Characters;
			if (characters == null || ((Il2CppArrayBase<CharacterConfiguration>)(object)characters).Length == 0)
			{
				((ModBase)this).Log.Warn("[Medusa] roster empty, retrying later.");
				return;
			}
			for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)characters).Length; i++)
			{
				if (((Il2CppArrayBase<CharacterConfiguration>)(object)characters)[i] != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)characters)[i].name == "Medusa")
				{
					_registered = true;
					MedusaCharId = ((Il2CppArrayBase<CharacterConfiguration>)(object)characters)[i].charId;
					CharacterConfiguration val3 = PickBase(characters);
					EnsureMedusaPrefabRegistered(val3.charId, "TryRegisterMedusa.alreadyPresent");
					MoveMedusaIntoVisibleMatchSlot(val2, "TryRegisterMedusa.alreadyPresent");
					MakeRosterAvailable(val2);
					TuneCharAbilities(MedusaCharId);
					TryInjectPhrases();
					((ModBase)this).Log.Info($"[Medusa] already registered; verified prefab/pool/roster for CharId={MedusaCharId}.");
					return;
				}
			}
			CharacterConfiguration val4 = PickBase(characters);
			((ModBase)this).Log.Info($"[Medusa] cloning base character '{val4.name}' (charId={val4.charId}).");
			if (!EnsureMedusaPrefabRegistered(val4.charId, "TryRegisterMedusa"))
			{
				((ModBase)this).Log.Warn("[Medusa] could not register prefab; aborting.");
				return;
			}
			int medusaCharId = MedusaCharId;
			CharacterConfiguration item = CloneConfig(val4, medusaCharId);
			val2._characters = Append(val2._characters, item);
			val2._lobbyCharacters = AppendLobby(val2, item);
			MoveMedusaIntoVisibleMatchSlot(val2, "TryRegisterMedusa.appended");
			MakeRosterAvailable(val2);
			TuneCharAbilities(medusaCharId);
			TryInjectPhrases();
			_registered = true;
			((ModBase)this).Log.Info($"[Medusa] ✓ registered as CharId={medusaCharId}, name='{"Medusa"}'. Roster now {((Il2CppArrayBase<CharacterConfiguration>)(object)val2.Characters).Length}.");
			try
			{
				NotificationAPI.Show($"Medusa registered (CharId {medusaCharId})", (Severity)1, 4f);
			}
			catch
			{
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Error("[Medusa] TryRegisterMedusa: " + ex);
		}
	}

	private CharacterConfiguration PickBase(Il2CppReferenceArray<CharacterConfiguration> roster)
	{
		for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)roster).Length; i++)
		{
			if (((Il2CppArrayBase<CharacterConfiguration>)(object)roster)[i] != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)roster)[i].name == "Kitsu")
			{
				return ((Il2CppArrayBase<CharacterConfiguration>)(object)roster)[i];
			}
		}
		for (int j = 0; j < ((Il2CppArrayBase<CharacterConfiguration>)(object)roster).Length; j++)
		{
			if (((Il2CppArrayBase<CharacterConfiguration>)(object)roster)[j] != null)
			{
				return ((Il2CppArrayBase<CharacterConfiguration>)(object)roster)[j];
			}
		}
		return ((Il2CppArrayBase<CharacterConfiguration>)(object)roster)[0];
	}

	private CharacterConfiguration CloneConfig(CharacterConfiguration b, int charId)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		CharacterConfiguration val = new CharacterConfiguration
		{
			name = "Medusa",
			descriptionTranslationKey = "MEDUSA_DESC",
			charId = charId,
			enabledInLobby = true,
			enabledInDevLobby = true,
			Color = MedusaColor,
			UIAccentColor = MedusaColor,
			smallSprite = b.smallSprite,
			IconSprite = b.IconSprite,
			LobbyBackground = b.LobbyBackground,
			FullSprite = b.FullSprite,
			StandingSprite = b.StandingSprite,
			CircleIcon = b.CircleIcon,
			SquareIcon = b.SquareIcon,
			SquareSmallIcon = b.SquareSmallIcon,
			gameStatsLobbySpriteModifier = b.gameStatsLobbySpriteModifier,
			DefaultSkin = b.DefaultSkin,
			abilityIconColor = MedusaAbilityIconColor,
			abilityBGColor = MedusaAbilityBgColor,
			titleTextColor = MedusaTitleTextColor,
			ability1 = MakeAbility(b.ability1, "MEDUSA_AB_LMB_TITLE", "MEDUSA_AB_LMB_DESC_SHORT", "MEDUSA_AB_LMB_DESC"),
			ability2 = MakeAbility(b.ability2, "MEDUSA_AB_Q_TITLE", "MEDUSA_AB_Q_DESC_SHORT", "MEDUSA_AB_Q_DESC"),
			ability3 = MakeAbility(b.ability3, "MEDUSA_AB_SPACE_TITLE", "MEDUSA_AB_SPACE_DESC_SHORT", "MEDUSA_AB_SPACE_DESC"),
			ability4 = MakeAbility(b.ability4, "MEDUSA_AB_ULT_TITLE", "MEDUSA_AB_ULT_DESC_SHORT", "MEDUSA_AB_ULT_DESC")
		};
		ApplyMedusaArtwork(val, b);
		return val;
	}

	private static AbilityData MakeAbility(AbilityData src, string titleKey, string shortKey, string descKey)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		AbilityData val = new AbilityData();
		try
		{
			val.icon = src.icon;
		}
		catch
		{
		}
		val.titleKey = titleKey;
		val.shortDescriptionKey = shortKey;
		val.descriptionKey = descKey;
		return val;
	}

	private void ApplyMedusaArtwork(CharacterConfiguration cfg, CharacterConfiguration fallback)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Expected O, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0107: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Expected O, but got Unknown
		try
		{
			Sprite val = LoadMedusaSprite("medusa-portrait.png", "medusa-card.png", "portrait.png", "card.png");
			if ((Object)val != (Object)null)
			{
				cfg.smallSprite = val;
				cfg.IconSprite = val;
				cfg.CircleIcon = val;
				cfg.SquareIcon = val;
				cfg.SquareSmallIcon = val;
			}
			Sprite val2 = LoadMedusaSprite("medusa-wide.png", "medusa-lobby.png", "wide.png", "lobby.png");
			if ((Object)val2 != (Object)null)
			{
				cfg.LobbyBackground = val2;
				cfg.FullSprite = val2;
				cfg.StandingSprite = val2;
			}
			if ((Object)val != (Object)null || (Object)val2 != (Object)null)
			{
				((ModBase)this).Log.Info($"[Medusa] custom artwork applied: portrait={(Object)val != (Object)null} wide={(Object)val2 != (Object)null}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] custom artwork failed, keeping base sprites: " + ex.Message);
			cfg.smallSprite = fallback.smallSprite;
			cfg.IconSprite = fallback.IconSprite;
			cfg.LobbyBackground = fallback.LobbyBackground;
			cfg.FullSprite = fallback.FullSprite;
			cfg.StandingSprite = fallback.StandingSprite;
			cfg.CircleIcon = fallback.CircleIcon;
			cfg.SquareIcon = fallback.SquareIcon;
			cfg.SquareSmallIcon = fallback.SquareSmallIcon;
		}
	}

	private Sprite? LoadMedusaSprite(params string[] names)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		Rect val2 = default(Rect);
		for (int i = 0; i < names.Length; i++)
		{
			string text = ResolveMedusaUserDataFile(names[i]);
			if (!File.Exists(text))
			{
				continue;
			}
			try
			{
				byte[] array = File.ReadAllBytes(text);
				Texture2D val = new Texture2D(2, 2, (TextureFormat)4, false);
				if (!ImageConversion.LoadImage(val, Il2CppStructArray<byte>.op_Implicit(array)))
				{
					continue;
				}
				((Object)val).name = Path.GetFileNameWithoutExtension(text);
				((Texture)val).wrapMode = (TextureWrapMode)1;
				((Texture)val).filterMode = (FilterMode)1;
				((Rect)(ref val2))._002Ector(0f, 0f, (float)((Texture)val).width, (float)((Texture)val).height);
				Sprite obj = Sprite.Create(val, val2, new Vector2(0.5f, 0.5f), 100f);
				((Object)obj).name = Path.GetFileNameWithoutExtension(text);
				return obj;
			}
			catch (Exception ex)
			{
				((ModBase)this).Log.Warn("[Medusa] artwork load failed for '" + text + "': " + ex.Message);
			}
		}
		return null;
	}

	private static string ResolveMedusaUserDataFile(string fileName)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(ResolveBundlePath());
			if (!string.IsNullOrWhiteSpace(directoryName))
			{
				return Path.Combine(directoryName, fileName);
			}
		}
		catch
		{
		}
		return Path.Combine(AppContext.BaseDirectory, "UserData", "Medusa", fileName);
	}

	private void TuneCharAbilities(int charId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Expected O, but got Unknown
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected O, but got Unknown
		try
		{
			GameNetworkManager val = Object.FindObjectOfType<GameNetworkManager>();
			if ((Object)val == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] tune: GameNetworkManager not found.");
				return;
			}
			Il2CppReferenceArray<GameObject> characterPrefabsByCharId = val.characterPrefabsByCharId;
			if (characterPrefabsByCharId == null || charId < 0 || charId >= ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length || (Object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[charId] == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] tune: prefab missing.");
				return;
			}
			GameObject val2 = ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[charId];
			int num = 0;
			try
			{
				num = ((Object)val2).GetInstanceID();
			}
			catch
			{
			}
			CharAbilities componentInChildren = val2.GetComponentInChildren<CharAbilities>(true);
			if ((Object)componentInChildren == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] tune: CharAbilities component not found on prefab.");
				return;
			}
			if (num != 0 && _tunedCharAbilityPrefabs.Contains(num))
			{
				ApplyMedusaAbilityRuntimeUi(componentInChildren, "TuneCharAbilities(prefab.idempotent)");
				SuppressInheritedKitsuAbilityVfx(componentInChildren, "TuneCharAbilities(prefab.idempotent)");
				return;
			}
			float damage = componentInChildren.damage;
			float attackSpeed = componentInChildren.attackSpeed;
			float cooldown = componentInChildren.cooldown;
			float critChance = componentInChildren.critChance;
			float maxAttackSpeed = componentInChildren.maxAttackSpeed;
			componentInChildren.damage = ((damage > 0f) ? (damage * 1.4f) : damage);
			componentInChildren.attackSpeed = ((attackSpeed > 0f) ? (attackSpeed * 0.9f) : attackSpeed);
			componentInChildren.cooldown = ((cooldown > 0f) ? (cooldown * 1.1f) : cooldown);
			componentInChildren.critChance = Math.Max(critChance, 0.2f);
			componentInChildren.maxAttackSpeed = ((maxAttackSpeed > 0f) ? (maxAttackSpeed * 0.95f) : maxAttackSpeed);
			ApplyMedusaAbilityRuntimeUi(componentInChildren, "TuneCharAbilities(prefab)");
			SuppressInheritedKitsuAbilityVfx(componentInChildren, "TuneCharAbilities(prefab)");
			if (num != 0)
			{
				_tunedCharAbilityPrefabs.Add(num);
			}
			((ModBase)this).Log.Info($"[Medusa] tuned CharAbilities: damage {damage:0.##}->{componentInChildren.damage:0.##}, attackSpeed {attackSpeed:0.##}->{componentInChildren.attackSpeed:0.##}, cooldown {cooldown:0.##}->{componentInChildren.cooldown:0.##}, critChance {critChance:0.##}->{componentInChildren.critChance:0.##}, maxAttackSpeed {maxAttackSpeed:0.##}->{componentInChildren.maxAttackSpeed:0.##}.");
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Error("[Medusa] TuneCharAbilities: " + ex);
		}
	}

	private void SuppressInheritedKitsuAbilityVfx(CharAbilities abilities, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0133: Expected O, but got Unknown
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Expected O, but got Unknown
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Expected O, but got Unknown
		//IL_0246: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Expected O, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_0332: Expected O, but got Unknown
		//IL_0347: Unknown result type (might be due to invalid IL or missing references)
		//IL_0352: Expected O, but got Unknown
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039d: Expected O, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b1: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f1: Expected O, but got Unknown
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_0448: Unknown result type (might be due to invalid IL or missing references)
		//IL_0453: Expected O, but got Unknown
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0473: Expected O, but got Unknown
		try
		{
			if ((Object)abilities == (Object)null)
			{
				return;
			}
			GameObject gameObject = ((Component)abilities).gameObject;
			if ((Object)gameObject == (Object)null)
			{
				return;
			}
			int unityInstanceId = GetUnityInstanceId((Object?)(object)gameObject);
			int num = 0;
			foreach (CatShotAbility componentsInChild in gameObject.GetComponentsInChildren<CatShotAbility>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					if ((Object)componentsInChild.vfxCastPrefab != (Object)null)
					{
						componentsInChild.vfxCastPrefab = null;
						num++;
					}
					if ((Object)componentsInChild.spellPrefab != (Object)null)
					{
						componentsInChild.spellPrefab = null;
						num++;
					}
					if ((Object)componentsInChild.catSpellPrefabSmall != (Object)null)
					{
						componentsInChild.catSpellPrefabSmall = null;
						num++;
					}
					if ((Object)componentsInChild.catSpellPrefabBig != (Object)null)
					{
						componentsInChild.catSpellPrefabBig = null;
						num++;
					}
				}
			}
			foreach (CatMissileAbility componentsInChild2 in gameObject.GetComponentsInChildren<CatMissileAbility>(true))
			{
				if (!((Object)componentsInChild2 == (Object)null))
				{
					if ((Object)componentsInChild2.vfxCastPrefab != (Object)null)
					{
						componentsInChild2.vfxCastPrefab = null;
						num++;
					}
					if ((Object)componentsInChild2.spellPrefab != (Object)null)
					{
						componentsInChild2.spellPrefab = null;
						num++;
					}
				}
			}
			foreach (CatPolymorphAbility componentsInChild3 in gameObject.GetComponentsInChildren<CatPolymorphAbility>(true))
			{
				if (!((Object)componentsInChild3 == (Object)null))
				{
					if ((Object)componentsInChild3.vfxCastPrefab != (Object)null)
					{
						componentsInChild3.vfxCastPrefab = null;
						num++;
					}
					if ((Object)componentsInChild3.spellPrefab != (Object)null)
					{
						componentsInChild3.spellPrefab = null;
						num++;
					}
				}
			}
			foreach (CatJumpAbility componentsInChild4 in gameObject.GetComponentsInChildren<CatJumpAbility>(true))
			{
				if (!((Object)componentsInChild4 == (Object)null))
				{
					if ((Object)componentsInChild4.vfxJumpPrefab != (Object)null)
					{
						componentsInChild4.vfxJumpPrefab = null;
						num++;
					}
					if ((Object)componentsInChild4.vfxLandPrefab != (Object)null)
					{
						componentsInChild4.vfxLandPrefab = null;
						num++;
					}
					if ((Object)componentsInChild4.spellPrefab != (Object)null)
					{
						componentsInChild4.spellPrefab = null;
						num++;
					}
				}
			}
			foreach (ArrowAbility componentsInChild5 in gameObject.GetComponentsInChildren<ArrowAbility>(true))
			{
				if ((Object)componentsInChild5 != (Object)null && (Object)componentsInChild5.spellPrefab != (Object)null)
				{
					componentsInChild5.spellPrefab = null;
					num++;
				}
			}
			foreach (ChargedArrowsAbility componentsInChild6 in gameObject.GetComponentsInChildren<ChargedArrowsAbility>(true))
			{
				if (!((Object)componentsInChild6 == (Object)null))
				{
					if ((Object)componentsInChild6.spellPrefab != (Object)null)
					{
						componentsInChild6.spellPrefab = null;
						num++;
					}
					if ((Object)componentsInChild6.vfxCastPrefab != (Object)null)
					{
						componentsInChild6.vfxCastPrefab = null;
						num++;
					}
				}
			}
			foreach (RecoilArrowAbility componentsInChild7 in gameObject.GetComponentsInChildren<RecoilArrowAbility>(true))
			{
				if (!((Object)componentsInChild7 == (Object)null))
				{
					if ((Object)componentsInChild7.spellPrefab != (Object)null)
					{
						componentsInChild7.spellPrefab = null;
						num++;
					}
					if ((Object)componentsInChild7.vfxJumpPrefab != (Object)null)
					{
						componentsInChild7.vfxJumpPrefab = null;
						num++;
					}
					if ((Object)componentsInChild7.vfxLandPrefab != (Object)null)
					{
						componentsInChild7.vfxLandPrefab = null;
						num++;
					}
				}
			}
			foreach (ArrowMissileAbility componentsInChild8 in gameObject.GetComponentsInChildren<ArrowMissileAbility>(true))
			{
				if (!((Object)componentsInChild8 == (Object)null))
				{
					if ((Object)componentsInChild8.spellPrefab != (Object)null)
					{
						componentsInChild8.spellPrefab = null;
						num++;
					}
					if ((Object)componentsInChild8.vfxCastPrefab != (Object)null)
					{
						componentsInChild8.vfxCastPrefab = null;
						num++;
					}
				}
			}
			if (unityInstanceId != 0 && num > 0)
			{
				_suppressedInheritedVfxRoots.Add(unityInstanceId);
			}
			if (num > 0 && _inheritedVfxSuppressLogCount < 12)
			{
				_inheritedVfxSuppressLogCount++;
				((ModBase)this).Log.Info($"[Medusa] suppressed {num} inherited Kitsu VFX prefab reference(s) via {source} on '{((Object)gameObject).name}'.");
			}
		}
		catch (Exception ex)
		{
			if (_inheritedVfxSuppressLogCount < 12)
			{
				_inheritedVfxSuppressLogCount++;
				((ModBase)this).Log.Warn("[Medusa] inherited Kitsu VFX suppression failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static AbilityData[] MedusaAbilityData()
	{
		CharacterConfiguration val = FindMedusaConfig();
		if (val != null)
		{
			return (AbilityData[])(object)new AbilityData[4] { val.ability1, val.ability2, val.ability3, val.ability4 };
		}
		UICharactersConfiguration val2 = FindCharConfig();
		Il2CppReferenceArray<CharacterConfiguration> val3 = (((Object)(object)val2 != (Object)null) ? val2.Characters : null);
		if (val3 != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)val3).Length > 0)
		{
			for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val3).Length; i++)
			{
				CharacterConfiguration val4 = ((Il2CppArrayBase<CharacterConfiguration>)(object)val3)[i];
				if (val4 != null)
				{
					return (AbilityData[])(object)new AbilityData[4]
					{
						MakeAbility(val4.ability1, "MEDUSA_AB_LMB_TITLE", "MEDUSA_AB_LMB_DESC_SHORT", "MEDUSA_AB_LMB_DESC"),
						MakeAbility(val4.ability2, "MEDUSA_AB_Q_TITLE", "MEDUSA_AB_Q_DESC_SHORT", "MEDUSA_AB_Q_DESC"),
						MakeAbility(val4.ability3, "MEDUSA_AB_SPACE_TITLE", "MEDUSA_AB_SPACE_DESC_SHORT", "MEDUSA_AB_SPACE_DESC"),
						MakeAbility(val4.ability4, "MEDUSA_AB_ULT_TITLE", "MEDUSA_AB_ULT_DESC_SHORT", "MEDUSA_AB_ULT_DESC")
					};
				}
			}
		}
		return Array.Empty<AbilityData>();
	}

	private static void ApplyMedusaAbilityRuntimeUi(CharAbilities? ca, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)ca == (Object)null)
			{
				return;
			}
			Il2CppReferenceArray<Ability> abilities = ca.abilities;
			if (abilities == null || ((Il2CppArrayBase<Ability>)(object)abilities).Length == 0)
			{
				return;
			}
			AbilityData[] array = MedusaAbilityData();
			int num = 0;
			for (int i = 0; i < ((Il2CppArrayBase<Ability>)(object)abilities).Length && i < array.Length; i++)
			{
				Ability val = ((Il2CppArrayBase<Ability>)(object)abilities)[i];
				if (!((Object)val == (Object)null))
				{
					val.useCustomUIData = true;
					val.customUIData = array[i];
					val.customUIIconColor = MedusaAbilityIconColor;
					val.customUITitleColor = MedusaTitleTextColor;
					num++;
				}
			}
			MedusaMod instance = _instance;
			if (instance != null && num > 0 && instance._runtimeUiLogCount < 12)
			{
				instance._runtimeUiLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] runtime ability UI applied via {source}: abilities={num} colors=medusa-green.");
			}
			ApplyLiveAbilityUiPalette(source);
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] runtime ability UI failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ApplyMedusaAbilityRuntimeUi(Ability? ability, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)ability == (Object)null)
			{
				return;
			}
			int medusaAbilitySlot = GetMedusaAbilitySlot(ability);
			if (medusaAbilitySlot < 0)
			{
				return;
			}
			AbilityData[] array = MedusaAbilityData();
			if (medusaAbilitySlot < array.Length)
			{
				ability.useCustomUIData = true;
				ability.customUIData = array[medusaAbilitySlot];
				ability.customUIIconColor = MedusaAbilityIconColor;
				ability.customUITitleColor = MedusaTitleTextColor;
				ApplyLiveAbilityUiPalette(source);
				MedusaMod instance = _instance;
				if (instance != null && instance._runtimeUiLogCount < 12)
				{
					instance._runtimeUiLogCount++;
					((ModBase)instance).Log.Info($"[Medusa] ability LoadAbilityUI bridge applied via {source}: slot={medusaAbilitySlot}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] ability runtime UI failed via " + source + ": " + ex.Message);
			}
		}
	}

	private void TryInjectPhrases()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		if (_phrasesInjected)
		{
			return;
		}
		try
		{
			UIManager manager = UIAPI.Manager;
			Translator val = (((Object)manager != (Object)null) ? manager.translator : null);
			if (val == null)
			{
				return;
			}
			Dictionary<string, string> val2 = null;
			try
			{
				val2 = val.phraseLookup;
			}
			catch (Exception ex)
			{
				((ModBase)this).Log.Warn("[Medusa] phraseLookup access threw: " + ex.Message);
			}
			if (val2 == null)
			{
				((ModBase)this).Log.Warn("[Medusa] phraseLookup is null; cannot inject.");
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (KeyValuePair<string, string> medusaPhrase in MedusaPhrases)
			{
				bool flag = false;
				try
				{
					flag = val2.ContainsKey(medusaPhrase.Key);
				}
				catch
				{
				}
				try
				{
					if (flag)
					{
						val2[medusaPhrase.Key] = medusaPhrase.Value;
						num2++;
					}
					else
					{
						val2.Add(medusaPhrase.Key, medusaPhrase.Value);
						num++;
					}
				}
				catch (Exception ex2)
				{
					try
					{
						val2[medusaPhrase.Key] = medusaPhrase.Value;
						num2++;
					}
					catch (Exception ex3)
					{
						((ModBase)this).Log.Warn($"[Medusa] inject '{medusaPhrase.Key}': {ex2.Message} / fallback: {ex3.Message}");
					}
				}
			}
			string text = "?";
			try
			{
				text = val.LocalisePhrase("MEDUSA_AB_LMB_TITLE");
			}
			catch
			{
			}
			((ModBase)this).Log.Info($"[Medusa] phrases injected (added={num}, updated={num2}, total={MedusaPhrases.Count}). Sample {"MEDUSA_AB_LMB_TITLE"} -> '{text}'.");
			_phrasesInjected = num + num2 > 0 || text == MedusaPhrases["MEDUSA_AB_LMB_TITLE"];
		}
		catch (Exception ex4)
		{
			((ModBase)this).Log.Error("[Medusa] TryInjectPhrases: " + ex4);
		}
	}

	private bool EnsureMedusaPrefabRegistered(int preferredBaseCharId, string source)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0175: Expected O, but got Unknown
		try
		{
			GameNetworkManager val = FindGameNetworkManager();
			if ((Object)val == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] " + source + ": GameNetworkManager not found.");
				return false;
			}
			Il2CppReferenceArray<GameObject> characterPrefabsByCharId = val.characterPrefabsByCharId;
			if (characterPrefabsByCharId == null || ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length == 0)
			{
				((ModBase)this).Log.Warn("[Medusa] " + source + ": characterPrefabsByCharId empty.");
				return false;
			}
			int num = FindMedusaPrefabIndex(characterPrefabsByCharId);
			if (num >= 0)
			{
				if (MedusaCharId != num)
				{
					MedusaCharId = num;
					((ModBase)this).Log.Info($"[Medusa] prefab already registered via {source}: charId={num} prefabs={((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length}.");
				}
				TryConfigureMirrorPrefab(((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[num], source + ".existing", val);
				TryAddSpawnPrefab(val, ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[num], source + ".existing");
				TuneCharAbilities(num);
				return true;
			}
			int num2 = preferredBaseCharId;
			if (num2 < 0 || num2 >= ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length || (Object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[num2] == (Object)null)
			{
				num2 = FindFallbackBasePrefabIndex(characterPrefabsByCharId);
			}
			if (num2 < 0)
			{
				((ModBase)this).Log.Warn("[Medusa] " + source + ": no base prefab available.");
				return false;
			}
			int num3 = RegisterPrefab(num2);
			if (num3 < 0)
			{
				return false;
			}
			MedusaCharId = num3;
			TuneCharAbilities(num3);
			((ModBase)this).Log.Info($"[Medusa] prefab registration ready via {source}: baseCharId={num2} medusaCharId={num3}.");
			return true;
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] EnsureMedusaPrefabRegistered failed via " + source + ": " + ex.Message);
			return false;
		}
	}

	private static GameNetworkManager? FindGameNetworkManager()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		try
		{
			GameNetworkManager instance = GameNetworkManager.Instance;
			if ((Object)instance != (Object)null)
			{
				return instance;
			}
		}
		catch
		{
		}
		try
		{
			return Object.FindObjectOfType<GameNetworkManager>();
		}
		catch
		{
			return null;
		}
	}

	private static int FindMedusaPrefabIndex(Il2CppReferenceArray<GameObject>? prefabs)
	{
		if (prefabs == null)
		{
			return -1;
		}
		try
		{
			if (15 < ((Il2CppArrayBase<GameObject>)(object)prefabs).Length && IsMedusaPrefab(((Il2CppArrayBase<GameObject>)(object)prefabs)[15]))
			{
				return 15;
			}
			for (int i = 0; i < ((Il2CppArrayBase<GameObject>)(object)prefabs).Length; i++)
			{
				if (IsMedusaPrefab(((Il2CppArrayBase<GameObject>)(object)prefabs)[i]))
				{
					return i;
				}
			}
		}
		catch
		{
		}
		return -1;
	}

	private static bool IsMedusaPrefab(GameObject? prefab)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Expected O, but got Unknown
		try
		{
			if ((Object)prefab == (Object)null)
			{
				return false;
			}
			try
			{
				if ((((Object)prefab).name ?? string.Empty).IndexOf("Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return true;
				}
			}
			catch
			{
			}
			try
			{
				return (Object)FindMedusaAnimatorUnder(prefab.transform) != (Object)null;
			}
			catch
			{
				return false;
			}
		}
		catch
		{
			return false;
		}
	}

	private static int FindFallbackBasePrefabIndex(Il2CppReferenceArray<GameObject>? prefabs)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		if (prefabs == null)
		{
			return -1;
		}
		for (int i = 0; i < ((Il2CppArrayBase<GameObject>)(object)prefabs).Length; i++)
		{
			try
			{
				if ((Object)((Il2CppArrayBase<GameObject>)(object)prefabs)[i] == (Object)null || !((Object)((Il2CppArrayBase<GameObject>)(object)prefabs)[i].GetComponentInChildren<CharAbilities>(true) != (Object)null))
				{
					continue;
				}
				return i;
			}
			catch
			{
			}
		}
		for (int j = 0; j < ((Il2CppArrayBase<GameObject>)(object)prefabs).Length; j++)
		{
			try
			{
				if ((Object)((Il2CppArrayBase<GameObject>)(object)prefabs)[j] != (Object)null)
				{
					return j;
				}
			}
			catch
			{
			}
		}
		return -1;
	}

	private int ResolveBotFallbackCharId(string source)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		try
		{
			GameNetworkManager val = FindGameNetworkManager();
			if ((Object)val == (Object)null)
			{
				return 0;
			}
			Il2CppReferenceArray<GameObject> characterPrefabsByCharId = val.characterPrefabsByCharId;
			int num = FindPreferredBasePrefabIndex(characterPrefabsByCharId);
			if (num >= 0)
			{
				return num;
			}
			num = FindFallbackBasePrefabIndex(characterPrefabsByCharId);
			return (num >= 0) ? num : 0;
		}
		catch (Exception ex)
		{
			if (_medusaBotFallbackLogCount < 12)
			{
				((ModBase)this).Log.Warn("[Medusa] " + source + ": bot fallback lookup failed: " + ex.Message);
			}
			return 0;
		}
	}

	private static int FindPreferredBasePrefabIndex(Il2CppReferenceArray<GameObject>? prefabs)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		if (prefabs == null)
		{
			return -1;
		}
		for (int i = 0; i < ((Il2CppArrayBase<GameObject>)(object)prefabs).Length; i++)
		{
			try
			{
				GameObject val = ((Il2CppArrayBase<GameObject>)(object)prefabs)[i];
				if ((Object)val == (Object)null || IsMedusaPrefab(val) || (((Object)val).name ?? string.Empty).IndexOf("Kitsu", StringComparison.OrdinalIgnoreCase) < 0)
				{
					continue;
				}
				return i;
			}
			catch
			{
			}
		}
		return -1;
	}

	private int RegisterPrefab(int baseCharId)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Expected O, but got Unknown
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0187: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Expected O, but got Unknown
		try
		{
			GameNetworkManager val = Object.FindObjectOfType<GameNetworkManager>();
			if ((Object)val == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] GameNetworkManager not found.");
				return -1;
			}
			Il2CppReferenceArray<GameObject> characterPrefabsByCharId = val.characterPrefabsByCharId;
			if (characterPrefabsByCharId == null || ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length == 0)
			{
				((ModBase)this).Log.Warn("[Medusa] characterPrefabsByCharId empty.");
				return -1;
			}
			GameObject val2 = ((baseCharId >= 0 && baseCharId < ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length) ? ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[baseCharId] : null);
			if ((Object)val2 == (Object)null)
			{
				for (int i = 0; i < ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length; i++)
				{
					if ((Object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[i] != (Object)null)
					{
						val2 = ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[i];
						break;
					}
				}
			}
			if ((Object)val2 == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] no base prefab to clone.");
				return -1;
			}
			bool flag = false;
			try
			{
				flag = val2.activeSelf;
				if (flag)
				{
					val2.SetActive(false);
				}
			}
			catch
			{
			}
			GameObject val3;
			try
			{
				val3 = Object.Instantiate<GameObject>(val2);
			}
			finally
			{
				try
				{
					if (flag)
					{
						val2.SetActive(true);
					}
				}
				catch
				{
				}
			}
			((Object)val3).name = "Char_Medusa";
			val3.SetActive(false);
			Object.DontDestroyOnLoad((Object)val3);
			GraftMedusaVisual(val3);
			TryConfigureMirrorPrefab(val3, "RegisterPrefab.clone", val);
			int num = ((15 >= ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length || (Object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[15] == (Object)null) ? 15 : ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length);
			Il2CppReferenceArray<GameObject> val4 = new Il2CppReferenceArray<GameObject>((long)Math.Max(((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length, num + 1));
			for (int j = 0; j < ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length; j++)
			{
				((Il2CppArrayBase<GameObject>)(object)val4)[j] = ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[j];
			}
			((Il2CppArrayBase<GameObject>)(object)val4)[num] = val3;
			val.characterPrefabsByCharId = val4;
			TryAddSpawnPrefab(val, val3, "RegisterPrefab.clone");
			((ModBase)this).Log.Info($"[Medusa] prefab cloned -> characterPrefabsByCharId[{num}] (visualGrafted={_bundleLoaded && (Object)_medusaVisualPrefab != (Object)null}).");
			return num;
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Error("[Medusa] RegisterPrefab: " + ex);
			return -1;
		}
	}

	private bool TryConfigureMirrorPrefab(GameObject? prefab, string source, GameNetworkManager? gnm = null)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		try
		{
			if ((Object)prefab == (Object)null)
			{
				return false;
			}
			NetworkIdentity val = prefab.GetComponent<NetworkIdentity>();
			if ((Object)val == (Object)null)
			{
				val = prefab.GetComponentInChildren<NetworkIdentity>(true);
			}
			if ((Object)val == (Object)null)
			{
				((ModBase)this).Log.Warn($"[Medusa] Mirror prefab registration via {source}: NetworkIdentity missing on '{((Object)prefab).name}'.");
				return false;
			}
			uint value = 0u;
			ulong value2 = 0uL;
			uint value3 = 0u;
			bool value4 = false;
			bool value5 = false;
			try
			{
				value = val._assetId;
			}
			catch
			{
			}
			try
			{
				value2 = val.sceneId;
			}
			catch
			{
			}
			try
			{
				value3 = val._netId_k__BackingField;
			}
			catch
			{
			}
			try
			{
				value4 = val.hasSpawned;
			}
			catch
			{
			}
			try
			{
				value5 = val._SpawnedFromInstantiate_k__BackingField;
			}
			catch
			{
			}
			SanitizeMirrorIdentities(prefab, source);
			val._assetId = 1296385109u;
			if (!_mirrorClientPrefabRegistered)
			{
				_mirrorClientPrefabRegistered = true;
				if (!_mirrorClientSpawnPrefabsLogEmitted && _networkPrefabLogCount < 12)
				{
					_mirrorClientSpawnPrefabsLogEmitted = true;
					((ModBase)this).Log.Info($"[Medusa] Mirror client registration delegated to NetworkManager.spawnPrefabs for assetId=0x{1296385109u:X8}; skipped direct NetworkClient.RegisterPrefab via {source}.");
				}
			}
			TryRegisterNetworkPrefabPool(gnm ?? FindGameNetworkManager(), prefab, source);
			if (_networkPrefabLogCount < 12)
			{
				_networkPrefabLogCount++;
				((ModBase)this).Log.Info($"[Medusa] Mirror prefab ready via {source}: prefab='{((Object)prefab).name}' oldAssetId=0x{value:X8} newAssetId=0x{1296385109u:X8} oldSceneId={value2} oldNetId={value3} oldHasSpawned={value4} oldSpawnedFromInstantiate={value5} sceneId={SafeULong(() => val.sceneId)} hasSpawned={SafeBool(() => val.hasSpawned)}.");
			}
			return true;
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] TryConfigureMirrorPrefab failed via " + source + ": " + ex.Message);
			return false;
		}
	}

	private void SanitizeMirrorIdentities(GameObject prefab, string source)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		try
		{
			int num = 0;
			Il2CppArrayBase<NetworkIdentity> componentsInChildren = prefab.GetComponentsInChildren<NetworkIdentity>(true);
			if (componentsInChildren != null)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					NetworkIdentity val = componentsInChildren[i];
					if (!((Object)val == (Object)null))
					{
						try
						{
							val.sceneId = 0uL;
						}
						catch
						{
						}
						try
						{
							val._netId_k__BackingField = 0u;
						}
						catch
						{
						}
						try
						{
							val.hasSpawned = false;
						}
						catch
						{
						}
						try
						{
							val._SpawnedFromInstantiate_k__BackingField = false;
						}
						catch
						{
						}
						try
						{
							val.destroyCalled = false;
						}
						catch
						{
						}
						try
						{
							val.serverOnly = false;
						}
						catch
						{
						}
						try
						{
							val._connectionToServer_k__BackingField = null;
						}
						catch
						{
						}
						try
						{
							val._connectionToClient = null;
						}
						catch
						{
						}
						try
						{
							val.InitializeNetworkBehaviours();
						}
						catch
						{
						}
						num++;
					}
				}
			}
			if (_networkPrefabLogCount < 12)
			{
				((ModBase)this).Log.Info($"[Medusa] Mirror runtime identity sanitized via {source}: prefab='{((Object)prefab).name}' identities={num}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] SanitizeMirrorIdentities failed via " + source + ": " + ex.Message);
		}
	}

	private bool TryRegisterNetworkPrefabPool(GameNetworkManager? gnm, GameObject? prefab, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e8: Expected O, but got Unknown
		//IL_00e8: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		try
		{
			if ((Object)prefab == (Object)null)
			{
				return false;
			}
			Config val = new Config();
			val.prefab = prefab;
			val.initialSizeServer = 1;
			val.initialSizeClient = 1;
			val.resizeStrategy = (ResizeStrategy)0;
			bool flag = false;
			bool flag2 = false;
			try
			{
				bool flag3 = false;
				try
				{
					flag3 = Application.isBatchMode || NetworkServer.active;
				}
				catch
				{
				}
				if (flag3)
				{
					NetworkPrefabLibrary val2 = (((Object)gnm != (Object)null) ? gnm.networkPrefabLibrary : null);
					Il2CppReferenceArray<Config> val3 = (((Object)val2 != (Object)null) ? val2.PooledPrefabs : null);
					int num = ((val3 != null) ? ((Il2CppArrayBase<Config>)(object)val3).Length : 0);
					Config val4 = null;
					if (val3 != null)
					{
						for (int i = 0; i < num; i++)
						{
							Config val5 = ((Il2CppArrayBase<Config>)(object)val3)[i];
							if (val5 != null)
							{
								GameObject val6 = null;
								try
								{
									val6 = val5.prefab;
								}
								catch
								{
								}
								if ((Object)val6 == (Object)prefab || IsMedusaPrefab(val6))
								{
									val4 = val5;
									flag = true;
									break;
								}
							}
						}
					}
					if (val4 != null)
					{
						val = val4;
						val.prefab = prefab;
						val.initialSizeServer = Math.Max(val.initialSizeServer, 1);
						val.initialSizeClient = Math.Max(val.initialSizeClient, 1);
					}
					else if ((Object)val2 != (Object)null)
					{
						Il2CppReferenceArray<Config> val7 = new Il2CppReferenceArray<Config>((long)(num + 1));
						for (int j = 0; j < num; j++)
						{
							((Il2CppArrayBase<Config>)(object)val7)[j] = ((Il2CppArrayBase<Config>)(object)val3)[j];
						}
						((Il2CppArrayBase<Config>)(object)val7)[num] = val;
						val2.PooledPrefabs = val7;
						flag2 = true;
					}
				}
			}
			catch (Exception ex)
			{
				((ModBase)this).Log.Warn("[Medusa] NetworkPrefabLibrary patch failed via " + source + ": " + ex.Message);
			}
			int num2 = 0;
			try
			{
				num2 = ((Object)prefab).GetInstanceID();
			}
			catch
			{
			}
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			bool flag7 = false;
			try
			{
				flag6 = NetworkClient.active;
			}
			catch
			{
			}
			try
			{
				flag7 = NetworkServer.active;
			}
			catch
			{
			}
			if (num2 != 0 && flag6 && _mirrorClientPrefabRegistered)
			{
				_clientPoolRegisteredPrefabs.Add(num2);
			}
			else if (num2 != 0 && flag6 && !_clientPoolRegisteredPrefabs.Contains(num2))
			{
				try
				{
					NetworkPrefabPool.ClientCreate(val);
					_clientPoolRegisteredPrefabs.Add(num2);
					flag4 = true;
				}
				catch (Exception ex2)
				{
					((ModBase)this).Log.Warn("[Medusa] NetworkPrefabPool.ClientCreate failed via " + source + ": " + ex2.Message);
				}
			}
			if (num2 != 0 && flag7 && !_serverPoolRegisteredPrefabs.Contains(num2))
			{
				try
				{
					NetworkPrefabPool.ServerCreate(val);
					_serverPoolRegisteredPrefabs.Add(num2);
					flag5 = true;
				}
				catch (Exception ex3)
				{
					((ModBase)this).Log.Warn("[Medusa] NetworkPrefabPool.ServerCreate failed via " + source + ": " + ex3.Message);
				}
			}
			if (_networkPrefabLogCount < 16)
			{
				_networkPrefabLogCount++;
				((ModBase)this).Log.Info($"[Medusa] NetworkPrefabPool ready via {source}: prefab='{((Object)prefab).name}' libraryHad={flag} libraryAppended={flag2} clientActive={flag6} clientCreated={flag4} serverActive={flag7} serverCreated={flag5}.");
			}
			return flag || flag2 || flag4 || flag5;
		}
		catch (Exception ex4)
		{
			((ModBase)this).Log.Warn("[Medusa] TryRegisterNetworkPrefabPool failed via " + source + ": " + ex4.Message);
			return false;
		}
	}

	private bool TryAddSpawnPrefab(GameNetworkManager? gnm, GameObject? prefab, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_0051: Expected O, but got Unknown
		try
		{
			if ((Object)gnm == (Object)null || (Object)prefab == (Object)null)
			{
				return false;
			}
			List<GameObject> spawnPrefabs = ((NetworkManager)gnm).spawnPrefabs;
			if (spawnPrefabs == null)
			{
				return false;
			}
			for (int i = 0; i < spawnPrefabs.Count; i++)
			{
				GameObject val = spawnPrefabs[i];
				if ((Object)val == (Object)prefab || IsMedusaPrefab(val))
				{
					return true;
				}
			}
			spawnPrefabs.Add(prefab);
			if (_networkPrefabLogCount < 12)
			{
				_networkPrefabLogCount++;
				((ModBase)this).Log.Info($"[Medusa] NetworkManager.spawnPrefabs appended via {source}: prefab='{((Object)prefab).name}' count={spawnPrefabs.Count}.");
			}
			return true;
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] TryAddSpawnPrefab failed via " + source + ": " + ex.Message);
			return false;
		}
	}

	private void TryLoadBundle()
	{
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0229: Expected O, but got Unknown
		//IL_029a: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Expected O, but got Unknown
		if (_bundleAttempted)
		{
			return;
		}
		_bundleAttempted = true;
		string value = "init";
		try
		{
			value = "resolve-path";
			string text = ResolveBundlePath();
			if (!File.Exists(text))
			{
				((ModBase)this).Log.Warn("[Medusa] bundle not found at '" + text + "'; running in Kitsu-clone visual mode.");
				return;
			}
			long length = new FileInfo(text).Length;
			((ModBase)this).Log.Info($"[Medusa] bundle file located: '{text}' ({length} bytes).");
			value = "loadFromFile";
			_bundle = Il2CppAssetBundleManager.LoadFromFile(text);
			if (_bundle == null)
			{
				((ModBase)this).Log.Warn("[Medusa] Il2CppAssetBundleManager.LoadFromFile returned null for '" + text + "'.");
				return;
			}
			((ModBase)this).Log.Info("[Medusa] AssetBundle loaded (handle obtained).");
			value = "list-assets";
			Il2CppStringArray val;
			try
			{
				val = _bundle.GetAllAssetNames();
			}
			catch (Exception ex)
			{
				((ModBase)this).Log.Warn("[Medusa] GetAllAssetNames threw: " + ex.Message);
				val = null;
			}
			int num = ((Il2CppArrayBase<string>)(object)val)?.Length ?? 0;
			List<string> list = new List<string>();
			if (val != null)
			{
				int num2 = Math.Min(num, 6);
				for (int i = 0; i < num2; i++)
				{
					list.Add(((Il2CppArrayBase<string>)(object)val)[i] ?? "<null>");
				}
			}
			((ModBase)this).Log.Info($"[Medusa] bundle contains {num} asset(s). Sample: {string.Join(" | ", list)}");
			value = "loadAsset(by-name)";
			Type goType = Il2CppType.Of<GameObject>();
			_medusaVisualPrefab = TryLoadAssetTyped("Medusa_Visual", goType);
			if ((Object)_medusaVisualPrefab == (Object)null)
			{
				value = "loadAsset(by-path)";
				_medusaVisualPrefab = TryLoadAssetTyped("Assets/GameObject/Medusa_Visual.prefab", goType);
			}
			if ((Object)_medusaVisualPrefab == (Object)null)
			{
				value = "loadAsset(scan)";
				if (val != null)
				{
					for (int j = 0; j < ((Il2CppArrayBase<string>)(object)val).Length; j++)
					{
						string text2 = ((Il2CppArrayBase<string>)(object)val)[j];
						if (text2 != null && text2.IndexOf("Medusa_Visual", StringComparison.OrdinalIgnoreCase) >= 0)
						{
							_medusaVisualPrefab = TryLoadAssetTyped(text2, goType);
							if ((Object)_medusaVisualPrefab != (Object)null)
							{
								break;
							}
						}
					}
				}
			}
			if ((Object)_medusaVisualPrefab == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] 'Medusa_Visual' prefab not retrievable from bundle.");
				return;
			}
			_bundleLoaded = true;
			((ModBase)this).Log.Info("[Medusa] visual prefab '" + ((Object)_medusaVisualPrefab).name + "' loaded from bundle.");
			CacheMedusaBundleTextures(val);
			LoadNativeMedusaVfxPrefabs(val, goType);
			CacheMedusaRuntimeController(_medusaVisualPrefab, "TryLoadBundle.prefab");
			LogMedusaVisualDiagnostics(_medusaVisualPrefab, _medusaVisualPrefab, "TryLoadBundle.prefab");
		}
		catch (Exception value2)
		{
			((ModBase)this).Log.Error($"[Medusa] TryLoadBundle (stage={value}): {value2}");
		}
	}

	private void CacheMedusaBundleTextures(Il2CppStringArray? assetNames)
	{
		try
		{
			_medusaAlbedoTexture = TryLoadTextureAsset("Medusa_Tex_Albedo_1024") ?? TryLoadTextureAsset("Assets/Texture2D/Medusa_Tex_Albedo_1024.png") ?? FindTextureAssetByName(assetNames, "Medusa_Tex_Albedo");
			_medusaNormalTexture = TryLoadTextureAsset("Medusa_Tex_Normal_1024") ?? TryLoadTextureAsset("Assets/Texture2D/Medusa_Tex_Normal_1024.png") ?? FindTextureAssetByName(assetNames, "Medusa_Tex_Normal");
			_medusaBundleMaterial = TryLoadMaterialAsset("Medusa_Material") ?? TryLoadMaterialAsset("Assets/Material/Medusa_Material.mat") ?? FindMaterialAssetByName(assetNames, "Medusa_Material");
			((ModBase)this).Log.Info($"[Medusa] cached bundle textures/material: albedo='{ObjName((Object?)(object)_medusaAlbedoTexture)}' normal='{ObjName((Object?)(object)_medusaNormalTexture)}' material='{ObjName((Object?)(object)_medusaBundleMaterial)}'.");
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] cache bundle textures failed: " + ex.Message);
		}
	}

	private Texture? FindTextureAssetByName(Il2CppStringArray? assetNames, string contains)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		if (assetNames == null)
		{
			return null;
		}
		for (int i = 0; i < ((Il2CppArrayBase<string>)(object)assetNames).Length; i++)
		{
			string text = ((Il2CppArrayBase<string>)(object)assetNames)[i];
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf(contains, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				Texture val = TryLoadTextureAsset(text);
				if ((Object)val != (Object)null)
				{
					return val;
				}
			}
		}
		return null;
	}

	private Texture? TryLoadTextureAsset(string name)
	{
		try
		{
			if (_bundle == null || string.IsNullOrWhiteSpace(name))
			{
				return null;
			}
			Object val = _bundle.LoadAsset(name, Il2CppType.Of<Texture>());
			if (val == (Object)null)
			{
				val = _bundle.LoadAsset(name, Il2CppType.Of<Texture2D>());
			}
			if (val == (Object)null)
			{
				return null;
			}
			return ((Il2CppObjectBase)val).Cast<Texture>();
		}
		catch
		{
			return null;
		}
	}

	private Material? FindMaterialAssetByName(Il2CppStringArray? assetNames, string contains)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		if (assetNames == null)
		{
			return null;
		}
		for (int i = 0; i < ((Il2CppArrayBase<string>)(object)assetNames).Length; i++)
		{
			string text = ((Il2CppArrayBase<string>)(object)assetNames)[i];
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf(contains, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				Material val = TryLoadMaterialAsset(text);
				if ((Object)val != (Object)null)
				{
					return val;
				}
			}
		}
		return null;
	}

	private Material? TryLoadMaterialAsset(string name)
	{
		try
		{
			if (_bundle == null || string.IsNullOrWhiteSpace(name))
			{
				return null;
			}
			Object val = _bundle.LoadAsset(name, Il2CppType.Of<Material>());
			if (val == (Object)null)
			{
				return null;
			}
			return ((Il2CppObjectBase)val).Cast<Material>();
		}
		catch
		{
			return null;
		}
	}

	private void LoadNativeMedusaVfxPrefabs(Il2CppStringArray? assetNames, Type goType)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		_medusaNativeVfxPrefabs.Clear();
		List<string> list = new List<string>();
		string[] nativeVfxNames = NativeVfxNames;
		foreach (string text in nativeVfxNames)
		{
			GameObject val = TryLoadNativeVfxPrefab(text, assetNames, goType);
			if (!((Object)val == (Object)null))
			{
				_medusaNativeVfxPrefabs[text] = val;
				list.Add(((Object)val).name);
			}
		}
		((ModBase)this).Log.Info($"[Medusa] native VFX prefabs loaded: {_medusaNativeVfxPrefabs.Count}/{NativeVfxNames.Length} [{string.Join(", ", list)}].");
	}

	private GameObject? TryLoadNativeVfxPrefab(string shortName, Il2CppStringArray? assetNames, Type goType)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		GameObject val = TryLoadAssetTyped(shortName, goType);
		if ((Object)val != (Object)null)
		{
			return val;
		}
		val = TryLoadAssetTyped("Assets/GameObject/MedusaVfx/" + shortName + ".prefab", goType);
		if ((Object)val != (Object)null)
		{
			return val;
		}
		val = TryLoadAssetTyped("Assets/GameObject/" + shortName + ".prefab", goType);
		if ((Object)val != (Object)null)
		{
			return val;
		}
		if (assetNames == null)
		{
			return null;
		}
		for (int i = 0; i < ((Il2CppArrayBase<string>)(object)assetNames).Length; i++)
		{
			string text = ((Il2CppArrayBase<string>)(object)assetNames)[i];
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf(shortName, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				val = TryLoadAssetTyped(text, goType);
				if ((Object)val != (Object)null)
				{
					return val;
				}
			}
		}
		return null;
	}

	private static string ResolveBundlePath()
	{
		List<string> candidates = new List<string>();
		Add(AssetAPI.ResolvePath("Medusa\\medusa.bundle"));
		Add(Path.Combine(AppContext.BaseDirectory, "UserData", "Medusa\\medusa.bundle"));
		string currentDirectory = Directory.GetCurrentDirectory();
		Add(Path.Combine(currentDirectory, "UserData", "Medusa\\medusa.bundle"));
		Add(Path.Combine(currentDirectory, "medusa.bundle"));
		string directoryName = Path.GetDirectoryName(typeof(MedusaMod).Assembly.Location);
		if (!string.IsNullOrWhiteSpace(directoryName))
		{
			string fullPath = Path.GetFullPath(Path.Combine(directoryName, ".."));
			Add(Path.Combine(fullPath, "UserData", "Medusa\\medusa.bundle"));
			Add(Path.Combine(fullPath, "medusa.bundle"));
		}
		string text = null;
		long num = -1L;
		foreach (string item in candidates)
		{
			try
			{
				if (File.Exists(item))
				{
					long length = new FileInfo(item).Length;
					if (length > num)
					{
						text = item;
						num = length;
					}
				}
			}
			catch
			{
				if (text == null && File.Exists(item))
				{
					text = item;
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		if (candidates.Count <= 0)
		{
			return "Medusa\\medusa.bundle";
		}
		return candidates[0];
		void Add(string? path)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				return;
			}
			try
			{
				candidates.Add(Path.GetFullPath(path));
			}
			catch
			{
				candidates.Add(path);
			}
		}
	}

	private GameObject? TryLoadAssetTyped(string name, Type goType)
	{
		try
		{
			Object val = _bundle.LoadAsset(name, goType);
			if (val == (Object)null)
			{
				return null;
			}
			return ((Il2CppObjectBase)val).Cast<GameObject>();
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] LoadAsset('" + name + "') threw: " + ex.Message);
			return null;
		}
	}

	private static float ClampFloat(float value, float min, float max)
	{
		if (value < min)
		{
			return min;
		}
		if (value > max)
		{
			return max;
		}
		return value;
	}

	private static bool TryGetRendererBounds(GameObject root, bool includeMedusaVisual, out Bounds bounds)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		bounds = default(Bounds);
		bool flag = false;
		try
		{
			if ((Object)root == (Object)null)
			{
				return false;
			}
			foreach (Renderer componentsInChild in root.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)componentsInChild == (Object)null || (!includeMedusaVisual && IsUnderMedusaVisual(((Component)componentsInChild).transform)))
				{
					continue;
				}
				try
				{
					Bounds bounds2 = componentsInChild.bounds;
					if (!(((Bounds)(ref bounds2)).size.y <= 0.001f))
					{
						if (!flag)
						{
							bounds = bounds2;
							flag = true;
						}
						else
						{
							((Bounds)(ref bounds)).Encapsulate(bounds2);
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return flag;
	}

	private static bool TryGetSkinnedRendererBounds(GameObject root, bool includeMedusaVisual, out Bounds bounds)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		bounds = default(Bounds);
		bool flag = false;
		try
		{
			if ((Object)root == (Object)null)
			{
				return false;
			}
			foreach (SkinnedMeshRenderer componentsInChild in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)componentsInChild == (Object)null || (!includeMedusaVisual && IsUnderMedusaVisual(((Component)componentsInChild).transform)))
				{
					continue;
				}
				try
				{
					Bounds bounds2 = ((Renderer)componentsInChild).bounds;
					if (!(((Bounds)(ref bounds2)).size.y <= 0.001f))
					{
						if (!flag)
						{
							bounds = bounds2;
							flag = true;
						}
						else
						{
							((Bounds)(ref bounds)).Encapsulate(bounds2);
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return flag;
	}

	private void FitMedusaVisualToBaseBounds(GameObject visual, bool hasBaseBounds, Bounds baseBounds, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0409: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)visual == (Object)null)
			{
				return;
			}
			Bounds bounds = default(Bounds);
			bool flag = TryGetSkinnedRendererBounds(visual, includeMedusaVisual: true, out bounds);
			if (hasBaseBounds && flag && ((Bounds)(ref baseBounds)).size.y > 0.001f && ((Bounds)(ref bounds)).size.y > 0.001f)
			{
				float num = ClampFloat(((Bounds)(ref baseBounds)).size.y * 0.98f / ((Bounds)(ref bounds)).size.y, 0.02f, 1f);
				visual.transform.localScale = visual.transform.localScale * num;
				if (TryGetSkinnedRendererBounds(visual, includeMedusaVisual: true, out bounds))
				{
					Vector3 val = default(Vector3);
					((Vector3)(ref val))._002Ector(((Bounds)(ref baseBounds)).center.x - ((Bounds)(ref bounds)).center.x, ((Bounds)(ref baseBounds)).min.y - ((Bounds)(ref bounds)).min.y, ((Bounds)(ref baseBounds)).center.z - ((Bounds)(ref bounds)).center.z);
					visual.transform.position = visual.transform.position + val;
				}
				Vector3 localPosition = visual.transform.localPosition;
				bool num2 = Mathf.Abs(localPosition.y) > 4f;
				bool flag2 = Mathf.Abs(localPosition.x) > 12f || Mathf.Abs(localPosition.z) > 60f;
				if (num2 || flag2)
				{
					if (ShouldLogMedusaVisualFit(source))
					{
						((ModBase)this).Log.Warn($"[Medusa] visual fit via {source}: rejected excessive local offset ({localPosition.x:0.###},{localPosition.y:0.###},{localPosition.z:0.###}); restoring captured prefab visual transform.");
					}
					RestoreMedusaVisualDefaultTransform(visual, source);
				}
				else if ((Mathf.Abs(localPosition.x) > 4f || Mathf.Abs(localPosition.z) > 4f) && ShouldLogMedusaVisualFit(source))
				{
					((ModBase)this).Log.Info($"[Medusa] visual fit via {source}: accepted large horizontal mesh offset ({localPosition.x:0.###},{localPosition.y:0.###},{localPosition.z:0.###}).");
				}
				if (ShouldLogMedusaVisualFit(source))
				{
					((ModBase)this).Log.Info($"[Medusa] visual fit via {source}: skinnedBaseH={((Bounds)(ref baseBounds)).size.y:0.###} skinnedVisualH={((Bounds)(ref bounds)).size.y:0.###} scaleFactor={num:0.###} localScale={visual.transform.localScale.x:0.###} localPos=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}).");
				}
			}
			else
			{
				visual.transform.localScale = Vector3.one * 0.16f;
				if (ShouldLogMedusaVisualFit(source))
				{
					((ModBase)this).Log.Warn($"[Medusa] visual fit via {source}: bounds unavailable (base={hasBaseBounds}, visual={flag}); fallback localScale=0.16.");
				}
			}
		}
		catch (Exception ex)
		{
			if (ShouldLogMedusaVisualFit(source))
			{
				((ModBase)this).Log.Warn("[Medusa] visual fit failed via " + source + ": " + ex.Message);
			}
		}
	}

	private bool ShouldLogMedusaVisualFit(string source)
	{
		if (_visualFitLogCount >= 24)
		{
			return false;
		}
		string item = NormalizeVisualDiagnosticSource(source);
		if (!_visualFitSourcesLogged.Add(item))
		{
			return false;
		}
		_visualFitLogCount++;
		return true;
	}

	private void CaptureMedusaVisualDefaultTransform(GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((Object)visual == (Object)null))
			{
				_medusaVisualDefaultLocalPosition = visual.transform.localPosition;
				_medusaVisualDefaultLocalRotation = visual.transform.localRotation;
				_medusaVisualDefaultLocalScale = visual.transform.localScale;
				_medusaVisualDefaultTransformCaptured = true;
				((ModBase)this).Log.Info($"[Medusa] visual default transform captured via {source}: localPos=({_medusaVisualDefaultLocalPosition.x:0.###},{_medusaVisualDefaultLocalPosition.y:0.###},{_medusaVisualDefaultLocalPosition.z:0.###}) localScale={_medusaVisualDefaultLocalScale.x:0.###}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual default transform capture failed via " + source + ": " + ex.Message);
		}
	}

	private void RestoreMedusaVisualDefaultTransform(GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((Object)visual == (Object)null))
			{
				if (_medusaVisualDefaultTransformCaptured)
				{
					visual.transform.localPosition = _medusaVisualDefaultLocalPosition;
					visual.transform.localRotation = _medusaVisualDefaultLocalRotation;
					visual.transform.localScale = _medusaVisualDefaultLocalScale;
				}
				else
				{
					visual.transform.localPosition = Vector3.zero;
					visual.transform.localRotation = Quaternion.identity;
					visual.transform.localScale = Vector3.one;
				}
				((ModBase)this).Log.Info($"[Medusa] visual default transform restored via {source}: captured={_medusaVisualDefaultTransformCaptured} localPos=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}) localScale={visual.transform.localScale.x:0.###}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual default transform restore failed via " + source + ": " + ex.Message);
		}
	}

	private static int ResolveCharacterRenderLayer(GameObject root)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null)
			{
				return 0;
			}
			foreach (Renderer componentsInChild in root.GetComponentsInChildren<Renderer>(true))
			{
				if (!((Object)componentsInChild == (Object)null) && !IsUnderMedusaVisual(((Component)componentsInChild).transform))
				{
					return ((Component)componentsInChild).gameObject.layer;
				}
			}
			return root.layer;
		}
		catch
		{
			return 0;
		}
	}

	private void ApplyCharacterRenderLayer(GameObject root, GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null || (Object)visual == (Object)null)
			{
				return;
			}
			int num = ResolveCharacterRenderLayer(root);
			int num2 = 0;
			foreach (Transform componentsInChild in visual.GetComponentsInChildren<Transform>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					((Component)componentsInChild).gameObject.layer = num;
					num2++;
				}
			}
			if (_visualLayerSyncLogCount < 12)
			{
				_visualLayerSyncLogCount++;
				string text = null;
				try
				{
					text = LayerMask.LayerToName(num);
				}
				catch
				{
				}
				((ModBase)this).Log.Info($"[Medusa] visual layer sync via {source}: layer={num} '{(string.IsNullOrEmpty(text) ? "<unnamed>" : text)}' objects={num2}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual layer sync failed via " + source + ": " + ex.Message);
		}
	}

	private void BindMedusaVisualToCharMaterial(GameObject root, GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01b1: Expected O, but got Unknown
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null || (Object)visual == (Object)null)
			{
				return;
			}
			int unityInstanceId = GetUnityInstanceId((Object?)(object)root);
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)componentInChildren == (Object)null)
			{
				return;
			}
			if (unityInstanceId != 0 && _charMaterialBoundRoots.Contains(unityInstanceId) && IsCharMaterialBoundToVisual(root, visual))
			{
				ApplyCharacterRenderLayer(root, visual, source + ".alreadyBound");
				return;
			}
			List<Renderer> list = new List<Renderer>();
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					list.Add(componentsInChild);
				}
			}
			if (list.Count == 0)
			{
				return;
			}
			Renderer val = null;
			foreach (SkinnedMeshRenderer componentsInChild2 in visual.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if (!((Object)componentsInChild2 == (Object)null))
				{
					val = (Renderer)componentsInChild2;
					break;
				}
			}
			if ((Object)val == (Object)null)
			{
				val = list[0];
			}
			componentInChildren.charRigObj = visual;
			componentInChildren.charAnimatedRoot = visual.transform;
			try
			{
				Animator componentInChildren2 = visual.GetComponentInChildren<Animator>(true);
				if ((Object)componentInChildren2 != (Object)null)
				{
					componentInChildren.charAnimatedRoot = ((Component)componentInChildren2).transform;
				}
			}
			catch
			{
			}
			componentInChildren.charRenderer = val;
			int num = Math.Max(0, list.Count - 1);
			Il2CppReferenceArray<Renderer> val2 = new Il2CppReferenceArray<Renderer>((long)num);
			int num2 = 0;
			for (int i = 0; i < list.Count; i++)
			{
				Renderer val3 = list[i];
				if (!((Object)val3 == (Object)val) && num2 < num)
				{
					((Il2CppArrayBase<Renderer>)(object)val2)[num2++] = val3;
				}
			}
			componentInChildren.extraRenderers = val2;
			if (TryGetSkinnedRendererBounds(visual, includeMedusaVisual: true, out var bounds))
			{
				componentInChildren.customVisRendererBounds = true;
				componentInChildren.customVisBounds = bounds;
			}
			componentInChildren.rendererIsActive = true;
			try
			{
				componentInChildren.SetRendererEnabled(true);
			}
			catch
			{
			}
			try
			{
				componentInChildren.ReInitializeMaterialWrappers();
			}
			catch
			{
			}
			ApplyCharacterRenderLayer(root, visual, source + ".postCharMaterial");
			ForceMedusaCharMaterialVisible(root, visual, source + ".postCharMaterial");
			if (unityInstanceId != 0)
			{
				_charMaterialBoundRoots.Add(unityInstanceId);
			}
			if (_charMaterialBindLogCount < 12)
			{
				_charMaterialBindLogCount++;
				((ModBase)this).Log.Info($"[Medusa] CharMaterial rebound via {source}: primary='{((Object)((Component)val).gameObject).name}' primaryLayer={((Component)val).gameObject.layer} renderers={list.Count} extras={num2} customBounds={((Bounds)(ref bounds)).size.y > 0.001f}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] CharMaterial rebind failed via " + source + ": " + ex.Message);
		}
	}

	private void ForceMedusaCharMaterialVisible(GameObject root, GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null || (Object)visual == (Object)null)
			{
				return;
			}
			int unityInstanceId = GetUnityInstanceId((Object?)(object)root);
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if (!((Object)componentInChildren == (Object)null) && (unityInstanceId == 0 || !_charMaterialVisibleRoots.Contains(unityInstanceId) || NeedsCharMaterialVisibilityRepair(root, visual)))
			{
				try
				{
					componentInChildren.rendererIsActive = true;
				}
				catch
				{
				}
				try
				{
					componentInChildren.alpha = 1f;
				}
				catch
				{
				}
				try
				{
					componentInChildren.isOpaque = true;
				}
				catch
				{
				}
				try
				{
					componentInChildren.isPartialHidden = false;
				}
				catch
				{
				}
				try
				{
					componentInChildren.SetCharacterVisible(true);
				}
				catch
				{
				}
				try
				{
					componentInChildren.SetCharRendererEnabled(true);
				}
				catch
				{
				}
				try
				{
					componentInChildren.SetRendererEnabled(true);
				}
				catch
				{
				}
				try
				{
					componentInChildren.SetRendererMaterialAlpha(1f);
				}
				catch
				{
				}
				try
				{
					componentInChildren.UpdateCurrentRendererMaterialAlpha();
				}
				catch
				{
				}
				try
				{
					componentInChildren.ForceAlphaLerpFinish();
				}
				catch
				{
				}
				try
				{
					componentInChildren.RevealHiddenCharacter();
				}
				catch
				{
				}
				ApplyCharacterRenderLayer(root, visual, source + ".postVisibility");
				if (unityInstanceId != 0)
				{
					_charMaterialVisibleRoots.Add(unityInstanceId);
				}
				if (_materialVisibilityLogCount < 12)
				{
					_materialVisibilityLogCount++;
					((ModBase)this).Log.Info($"[Medusa] CharMaterial visibility forced via {source}: alpha=1 opaque=true partialHidden=false rendererActive=true visualActive={visual.activeInHierarchy}.");
				}
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] CharMaterial visibility force failed via " + source + ": " + ex.Message);
		}
	}

	private GameObject? FindMedusaVisualObject(GameObject root)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null)
			{
				return null;
			}
			foreach (Transform componentsInChild in root.GetComponentsInChildren<Transform>(true))
			{
				if (!((Object)componentsInChild == (Object)null) && ((Object)componentsInChild).name == "Medusa_Visual")
				{
					return ((Component)componentsInChild).gameObject;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static int GetUnityInstanceId(Object? obj)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		try
		{
			return (!(obj == (Object)null)) ? obj.GetInstanceID() : 0;
		}
		catch
		{
			return 0;
		}
	}

	private static bool IsCharMaterialBoundToVisual(GameObject root, GameObject visual)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null || (Object)visual == (Object)null)
			{
				return false;
			}
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)componentInChildren == (Object)null)
			{
				return true;
			}
			Renderer charRenderer = componentInChildren.charRenderer;
			if ((Object)charRenderer == (Object)null)
			{
				return false;
			}
			return IsUnderMedusaVisual(((Component)charRenderer).transform);
		}
		catch
		{
			return false;
		}
	}

	private static bool NeedsCharMaterialVisibilityRepair(GameObject root, GameObject visual)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null || (Object)visual == (Object)null)
			{
				return false;
			}
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)componentInChildren == (Object)null)
			{
				return false;
			}
			try
			{
				if (!componentInChildren.rendererIsActive)
				{
					return true;
				}
			}
			catch
			{
			}
			try
			{
				if (componentInChildren.alpha < 0.99f)
				{
					return true;
				}
			}
			catch
			{
			}
			try
			{
				if (!componentInChildren.isOpaque || componentInChildren.isPartialHidden)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}
		catch
		{
			return false;
		}
	}

	private bool IsLiveMedusaVisualStable(GameObject root, GameObject visual, string source)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		try
		{
			int unityInstanceId = GetUnityInstanceId((Object?)(object)root);
			if (unityInstanceId == 0 || !_stableLiveVisualRoots.Contains(unityInstanceId) || (Object)visual == (Object)null || !visual.activeInHierarchy)
			{
				return false;
			}
			int num = 0;
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)componentsInChild == (Object)null)
				{
					continue;
				}
				num++;
				if (!componentsInChild.enabled)
				{
					return false;
				}
				try
				{
					if (componentsInChild.forceRenderingOff)
					{
						return false;
					}
				}
				catch
				{
				}
			}
			if (num == 0 || (Object)FindMedusaAnimatorUnder(visual.transform) == (Object)null)
			{
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			if (_visualDiagnosticsLogCount < 24)
			{
				((ModBase)this).Log.Warn("[Medusa] stable visual check failed via " + source + ": " + ex.Message);
			}
			return false;
		}
	}

	private void EnsureStableLiveMedusaVisualCheap(GameObject root, GameObject visual, string source)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		try
		{
			int unityInstanceId = GetUnityInstanceId((Object?)(object)root);
			if (unityInstanceId == 0)
			{
				return;
			}
			float num;
			try
			{
				num = Time.unscaledTime;
			}
			catch
			{
				num = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
			}
			if (_stableVisualLastCheapCheckAt.TryGetValue(unityInstanceId, out var value) && num - value < 1f)
			{
				return;
			}
			_stableVisualLastCheapCheckAt[unityInstanceId] = num;
			if (_stableVisualLastCheapCheckAt.Count > 128)
			{
				_stableVisualLastCheapCheckAt.Clear();
			}
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					componentsInChild.enabled = true;
					try
					{
						componentsInChild.forceRenderingOff = false;
					}
					catch
					{
					}
				}
			}
			ApplyCharacterRenderLayer(root, visual, source + ".cheapLayer");
			if (NeedsCharMaterialVisibilityRepair(root, visual))
			{
				ForceMedusaCharMaterialVisible(root, visual, source + ".cheapVisibility");
			}
			DisableBaseCharacterRenderers(root, source + ".cheapBaseHide");
		}
		catch (Exception ex)
		{
			if (_visualDiagnosticsLogCount < 24)
			{
				((ModBase)this).Log.Warn("[Medusa] stable visual cheap check failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void MarkLiveMedusaVisualStable(GameObject root, GameObject visual)
	{
		int unityInstanceId = GetUnityInstanceId((Object?)(object)root);
		int unityInstanceId2 = GetUnityInstanceId((Object?)(object)visual);
		if (unityInstanceId != 0)
		{
			_stableLiveVisualRoots.Add(unityInstanceId);
		}
		if (unityInstanceId2 != 0)
		{
			_materialPreparedVisuals.Add(unityInstanceId2);
		}
		if (_stableLiveVisualRoots.Count > 128)
		{
			_stableLiveVisualRoots.Clear();
			_runtimeReboundVisualRoots.Clear();
			_charMaterialBoundRoots.Clear();
			_charMaterialVisibleRoots.Clear();
			_materialPreparedVisuals.Clear();
		}
	}

	private Transform ResolveMedusaVisualAnchor(GameObject root, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Expected O, but got Unknown
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Expected O, but got Unknown
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Expected O, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null)
			{
				return null;
			}
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)componentInChildren != (Object)null)
			{
				try
				{
					Transform charAnimatedRoot = componentInChildren.charAnimatedRoot;
					if ((Object)charAnimatedRoot != (Object)null && !IsUnderMedusaVisual(charAnimatedRoot))
					{
						return charAnimatedRoot;
					}
				}
				catch
				{
				}
				try
				{
					Renderer charRenderer = componentInChildren.charRenderer;
					if ((Object)charRenderer != (Object)null)
					{
						Transform transform = ((Component)charRenderer).transform;
						if ((Object)transform != (Object)null && !IsUnderMedusaVisual(transform))
						{
							Transform parent = transform.parent;
							if ((Object)parent != (Object)null && !IsUnderMedusaVisual(parent))
							{
								return parent;
							}
							return transform;
						}
					}
				}
				catch
				{
				}
			}
			EntityEventAnimator componentInChildren2 = root.GetComponentInChildren<EntityEventAnimator>(true);
			if ((Object)componentInChildren2 != (Object)null)
			{
				try
				{
					Transform meshTransform = componentInChildren2.meshTransform;
					if ((Object)meshTransform != (Object)null && !IsUnderMedusaVisual(meshTransform))
					{
						return meshTransform;
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual anchor resolve failed via " + source + ": " + ex.Message);
		}
		return root.transform;
	}

	private void AnchorMedusaVisual(GameObject root, GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0057: Expected O, but got Unknown
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (!((Object)root == (Object)null) && !((Object)visual == (Object)null))
			{
				Transform val = ResolveMedusaVisualAnchor(root, source);
				if ((Object)val == (Object)null)
				{
					val = root.transform;
				}
				Transform transform = visual.transform;
				if ((Object)val == (Object)transform || IsUnderMedusaVisual(val))
				{
					((ModBase)this).Log.Warn($"[Medusa] visual anchor via {source}: rejected self/visual-child anchor '{((Object)val).name}', falling back to root '{((Object)root).name}'.");
					val = root.transform;
				}
				string value = (((Object)transform.parent != (Object)null) ? ((Object)transform.parent).name : "<none>");
				transform.SetParent(val, false);
				transform.localPosition = Vector3.zero;
				transform.localRotation = Quaternion.identity;
				transform.localScale = Vector3.one;
				if (_visualAnchorLogCount < 12)
				{
					_visualAnchorLogCount++;
					((ModBase)this).Log.Info($"[Medusa] visual anchor via {source}: root='{((Object)root).name}' parent {value}->{((Object)val).name} localPos=({transform.localPosition.x:0.###},{transform.localPosition.y:0.###},{transform.localPosition.z:0.###}) worldPos=({transform.position.x:0.###},{transform.position.y:0.###},{transform.position.z:0.###}).");
				}
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual anchor failed via " + source + ": " + ex.Message);
		}
	}

	private void ForceMedusaVisualRenderable(GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)visual == (Object)null)
			{
				return;
			}
			visual.SetActive(true);
			int num = 0;
			int num2 = 0;
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)componentsInChild == (Object)null)
				{
					continue;
				}
				try
				{
					((Component)componentsInChild).gameObject.SetActive(true);
					if (!componentsInChild.enabled)
					{
						num2++;
					}
					componentsInChild.enabled = true;
					num++;
				}
				catch
				{
				}
			}
			int num3 = 0;
			foreach (SkinnedMeshRenderer componentsInChild2 in visual.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if (!((Object)componentsInChild2 == (Object)null))
				{
					try
					{
						componentsInChild2.updateWhenOffscreen = true;
						num3++;
					}
					catch
					{
					}
				}
			}
			if (_liveGraftLogCount < 10)
			{
				_liveGraftLogCount++;
				((ModBase)this).Log.Info($"[Medusa] visual render enable via {source}: renderers={num} newlyEnabled={num2} smrsUpdateWhenOffscreen={num3} active={visual.activeInHierarchy} localPos=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}) localScale={visual.transform.localScale.x:0.###}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual render enable failed via " + source + ": " + ex.Message);
		}
	}

	private void LogMedusaVisualDiagnostics(GameObject root, GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected O, but got Unknown
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0402: Unknown result type (might be due to invalid IL or missing references)
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Expected O, but got Unknown
		//IL_01c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0595: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0601: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0225: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Unknown result type (might be due to invalid IL or missing references)
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)root == (Object)null || (Object)visual == (Object)null || _visualDiagnosticsLogCount >= 24 || (_liveLocalDiagnosticsSuccessLogged && IsHighFrequencyVisualDiagnosticSource(source)))
			{
				return;
			}
			string item = NormalizeVisualDiagnosticSource(source);
			if (!_visualDiagnosticSourcesLogged.Add(item))
			{
				return;
			}
			_visualDiagnosticsLogCount++;
			int num = 0;
			int num2 = 0;
			string text = "<none>";
			int value = -1;
			string text2 = "<none>";
			string value2 = "<none>";
			string value3 = "<none>";
			string value4 = "<none>";
			string value5 = "<none>";
			Bounds val = default(Bounds);
			bool flag = false;
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)componentsInChild == (Object)null)
				{
					continue;
				}
				num++;
				if (text == "<none>")
				{
					text = ((Object)((Component)componentsInChild).gameObject).name;
					value = ((Component)componentsInChild).gameObject.layer;
				}
				try
				{
					Bounds bounds = componentsInChild.bounds;
					if (((Bounds)(ref bounds)).size.y > 0.001f)
					{
						if (!flag)
						{
							val = bounds;
							flag = true;
						}
						else
						{
							((Bounds)(ref val)).Encapsulate(bounds);
						}
					}
				}
				catch
				{
				}
			}
			foreach (SkinnedMeshRenderer componentsInChild2 in visual.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)componentsInChild2 == (Object)null)
				{
					continue;
				}
				num2++;
				if (!(text2 == "<none>"))
				{
					continue;
				}
				text2 = ((Object)((Component)componentsInChild2).gameObject).name;
				try
				{
					value2 = ((Object)componentsInChild2.sharedMesh).name;
				}
				catch
				{
				}
				try
				{
					value3 = ((Object)componentsInChild2.rootBone).name;
				}
				catch
				{
				}
				try
				{
					Material sharedMaterial = ((Renderer)componentsInChild2).sharedMaterial;
					if ((Object)sharedMaterial != (Object)null)
					{
						value4 = ((Object)sharedMaterial).name;
						value5 = ((Object)sharedMaterial.shader).name;
					}
				}
				catch
				{
				}
			}
			string value6 = "<no-main-camera>";
			try
			{
				Camera main = Camera.main;
				if ((Object)main != (Object)null)
				{
					Vector3 val2 = main.WorldToScreenPoint(flag ? ((Bounds)(ref val)).center : visual.transform.position);
					value6 = $"{val2.x:0.0},{val2.y:0.0},{val2.z:0.0}";
				}
			}
			catch
			{
			}
			((ModBase)this).Log.Info($"[Medusa] visual diagnostics via {source}: root='{((Object)root).name}' visualActive={visual.activeInHierarchy} layer={visual.layer} world=({visual.transform.position.x:0.###},{visual.transform.position.y:0.###},{visual.transform.position.z:0.###}) local=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}) scale=({visual.transform.localScale.x:0.###},{visual.transform.localScale.y:0.###},{visual.transform.localScale.z:0.###}) renderers={num} smrs={num2} firstRenderer='{text}' firstRendererLayer={value} firstSmr='{text2}' mesh='{value2}' rootBone='{value3}' material='{value4}' shader='{value5}' bounds={(flag ? $"{((Bounds)(ref val)).center.x:0.###},{((Bounds)(ref val)).center.y:0.###},{((Bounds)(ref val)).center.z:0.###}/{((Bounds)(ref val)).size.x:0.###},{((Bounds)(ref val)).size.y:0.###},{((Bounds)(ref val)).size.z:0.###}" : "<none>")} screen='{value6}'.");
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual diagnostics failed via " + source + ": " + ex.Message);
		}
	}

	private static bool IsHighFrequencyVisualDiagnosticSource(string source)
	{
		if (!source.StartsWith("PollOnce.", StringComparison.OrdinalIgnoreCase))
		{
			return source.StartsWith("PollOnce", StringComparison.OrdinalIgnoreCase);
		}
		return true;
	}

	private static string NormalizeVisualDiagnosticSource(string source)
	{
		int num = source.IndexOf('+');
		int num2 = source.IndexOf(".existing.postFit", StringComparison.OrdinalIgnoreCase);
		if (num > 0 && num2 > num)
		{
			string text = source.Substring(0, num);
			string text2 = source;
			int num3 = num2;
			return text + text2.Substring(num3, text2.Length - num3);
		}
		int num4 = source.IndexOf(".existing", StringComparison.OrdinalIgnoreCase);
		if (num > 0 && num4 > num)
		{
			string text3 = source.Substring(0, num);
			string text2 = source;
			int num3 = num4;
			return text3 + text2.Substring(num3, text2.Length - num3);
		}
		return source;
	}

	private void CopyMedusaMaterialProperties(Material material, string source)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Material medusaBundleMaterial = _medusaBundleMaterial;
			if ((Object)material == (Object)null || (Object)medusaBundleMaterial == (Object)null)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			string[] array = new string[18]
			{
				"_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap", "_BaseColorMap", "_DiffuseMap", "_DiffuseTex", "_ColorMap", "_MainTexture", "_Texture",
				"_Texture2D", "_CharTex", "_BodyTex", "_VariationTex", "_BumpMap", "_NormalMap", "_NormalTex", "_BumpTex"
			};
			foreach (string text in array)
			{
				if (material.HasProperty(text) && medusaBundleMaterial.HasProperty(text))
				{
					Texture texture = medusaBundleMaterial.GetTexture(text);
					if ((Object)texture != (Object)null)
					{
						material.SetTexture(text, texture);
						num++;
					}
				}
			}
			array = new string[16]
			{
				"_AmbientColor", "_Color", "_BaseColor", "_TintColor", "_MainColor", "_HColor", "_SColor", "_ShadowColor", "_ShadowTint", "_SpecularColor",
				"_SpecularTint", "_FresnelColor", "_RimColor", "_EmissionColor", "_EmissionTint", "_CoverageColor"
			};
			foreach (string text2 in array)
			{
				if (material.HasProperty(text2) && medusaBundleMaterial.HasProperty(text2))
				{
					material.SetColor(text2, medusaBundleMaterial.GetColor(text2));
					num2++;
				}
			}
			array = new string[31]
			{
				"_BumpScale", "_NormalScale", "_LightingIntensity", "_AmbientContribution", "_ShadingThreshold", "_ShadingTreshold", "_ShadingSmooth", "_ShadingSoftness", "_RampShading", "_RampSmooth",
				"_RampThreshold", "_RimAmount", "_RimSmooth", "_RimThreshold", "_VariationHue", "_VariationMask", "_VariationValue", "_VariationScale", "_VariationStep", "_VariationStepOffset",
				"_VariationBlendMode", "_VariationHSVInfo", "_VariationInfo", "_VariationOverlayInfo", "_VariationAltBlendAmount", "_VariationExponent", "_VariationNoise", "_VariationOffset", "_VariationValueChannel", "_VariationHueChannel",
				"_SkipVariationValueMask"
			};
			foreach (string text3 in array)
			{
				if (material.HasProperty(text3) && medusaBundleMaterial.HasProperty(text3))
				{
					material.SetFloat(text3, medusaBundleMaterial.GetFloat(text3));
					num3++;
				}
			}
			if ((num > 0 || num2 > 0 || num3 > 0) && _materialOverrideLogCount < 12)
			{
				_materialOverrideLogCount++;
				((ModBase)this).Log.Info($"[Medusa] copied bundle material props via {source}: target='{ObjName((Object?)(object)material)}' textures={num} colors={num2} floats={num3} sourceMaterial='{ObjName((Object?)(object)medusaBundleMaterial)}'.");
			}
		}
		catch (Exception ex)
		{
			if (_materialOverrideLogCount < 12)
			{
				_materialOverrideLogCount++;
				((ModBase)this).Log.Warn("[Medusa] material prop copy failed via " + source + ": " + ex.Message);
			}
		}
	}

	private void ApplyMedusaTextureOverrides(Material? material, Texture? albedoFallback, Texture? normalFallback, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)material == (Object)null)
			{
				return;
			}
			CopyMedusaMaterialProperties(material, source);
			Texture val = _medusaAlbedoTexture ?? albedoFallback;
			Texture val2 = _medusaNormalTexture ?? normalFallback;
			string[] array;
			if ((Object)val != (Object)null)
			{
				array = new string[14]
				{
					"_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap", "_BaseColorMap", "_DiffuseMap", "_DiffuseTex", "_ColorMap", "_MainTexture", "_Texture",
					"_Texture2D", "_CharTex", "_BodyTex", "_VariationTex"
				};
				foreach (string text in array)
				{
					if (material.HasProperty(text))
					{
						material.SetTexture(text, val);
					}
				}
			}
			if ((Object)val2 != (Object)null)
			{
				array = new string[4] { "_BumpMap", "_NormalMap", "_NormalTex", "_BumpTex" };
				foreach (string text2 in array)
				{
					if (material.HasProperty(text2))
					{
						material.SetTexture(text2, val2);
					}
				}
			}
			array = new string[4] { "_Color", "_BaseColor", "_TintColor", "_MainColor" };
			foreach (string text3 in array)
			{
				if (material.HasProperty(text3))
				{
					material.SetColor(text3, Color.white);
				}
			}
			array = new string[3] { "_Alpha", "_Opacity", "_CoverageAlpha" };
			foreach (string text4 in array)
			{
				if (material.HasProperty(text4))
				{
					material.SetFloat(text4, 1f);
				}
			}
			array = new string[7] { "_HitAmmount", "_HitAmount", "_HitBlinkAmount", "_IsEroded", "_FoWOccludeOverlay", "_MultiplyFoWToAlpha", "_MultiplyFoWToColor" };
			foreach (string text5 in array)
			{
				if (material.HasProperty(text5))
				{
					material.SetFloat(text5, 0f);
				}
			}
		}
		catch (Exception ex)
		{
			if (_materialVisibilityLogCount < 12)
			{
				((ModBase)this).Log.Warn("[Medusa] texture override failed via " + source + ": " + ex.Message);
			}
		}
	}

	private void ForceMedusaVisualMaterialVisibility(GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Expected O, but got Unknown
		//IL_0230: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_020d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_01f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Expected O, but got Unknown
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Expected O, but got Unknown
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00af: Expected O, but got Unknown
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e6: Expected O, but got Unknown
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_04f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_051f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0547: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected O, but got Unknown
		try
		{
			if ((Object)visual == (Object)null)
			{
				return;
			}
			int unityInstanceId = GetUnityInstanceId((Object?)(object)visual);
			if (unityInstanceId != 0 && _materialPreparedVisuals.Contains(unityInstanceId))
			{
				foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
				{
					if (!((Object)componentsInChild == (Object)null))
					{
						componentsInChild.enabled = true;
						try
						{
							componentsInChild.forceRenderingOff = false;
						}
						catch
						{
						}
					}
				}
				return;
			}
			int num = 0;
			string value = "<none>";
			foreach (SkinnedMeshRenderer componentsInChild2 in visual.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)componentsInChild2 == (Object)null)
				{
					continue;
				}
				try
				{
					componentsInChild2.updateWhenOffscreen = true;
					((Renderer)componentsInChild2).localBounds = new Bounds(Vector3.zero, Vector3.one * 8f);
					Renderer val = (Renderer)componentsInChild2;
					Material sharedMaterial = val.sharedMaterial;
					Texture val2 = null;
					if ((Object)sharedMaterial != (Object)null)
					{
						string[] array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
						foreach (string text in array)
						{
							if (sharedMaterial.HasProperty(text))
							{
								Texture texture = sharedMaterial.GetTexture(text);
								if ((Object)texture != (Object)null)
								{
									val2 = texture;
									break;
								}
							}
						}
					}
					Material val3 = sharedMaterial;
					bool flag = false;
					try
					{
						string text2 = (((Object)sharedMaterial != (Object)null && (Object)sharedMaterial.shader != (Object)null) ? ((Object)sharedMaterial.shader).name : "");
						flag = string.IsNullOrEmpty(text2) || text2.StartsWith("Unlit/", StringComparison.OrdinalIgnoreCase) || string.Equals(text2, "Standard", StringComparison.OrdinalIgnoreCase);
					}
					catch
					{
					}
					if ((Object)_toonTemplateMaterial != (Object)null && flag)
					{
						val3 = new Material(_toonTemplateMaterial);
						((Object)val3).name = "Medusa_Material_NativeVisible";
					}
					if ((Object)val3 == (Object)null)
					{
						Shader val4 = null;
						try
						{
							val4 = Shader.Find("Standard");
						}
						catch
						{
						}
						if ((Object)val4 != (Object)null)
						{
							val3 = new Material(val4);
							((Object)val3).name = "Medusa_Material_FallbackVisible";
						}
					}
					if ((Object)val3 != (Object)null)
					{
						string[] array;
						if ((Object)val2 != (Object)null)
						{
							array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
							foreach (string text3 in array)
							{
								if (val3.HasProperty(text3))
								{
									val3.SetTexture(text3, val2);
								}
							}
						}
						array = new string[4] { "_Color", "_BaseColor", "_TintColor", "_MainColor" };
						foreach (string text4 in array)
						{
							if (val3.HasProperty(text4))
							{
								val3.SetColor(text4, new Color(1f, 1f, 1f, 1f));
							}
						}
						array = new string[5] { "_Alpha", "_Opacity", "_Cutoff", "_Surface", "_ZWrite" };
						foreach (string text5 in array)
						{
							if (val3.HasProperty(text5))
							{
								float num2 = ((text5 == "_Cutoff" || text5 == "_Surface") ? 0f : 1f);
								val3.SetFloat(text5, num2);
							}
						}
						ApplyMedusaTextureOverrides(val3, val2, _medusaNormalTexture, source);
						val.sharedMaterial = val3;
						try
						{
							val.material = val3;
						}
						catch
						{
						}
						value = (((Object)val3.shader != (Object)null) ? ((Object)val3.shader).name : "<shader-null>");
					}
					val.enabled = true;
					try
					{
						val.forceRenderingOff = false;
					}
					catch
					{
					}
					((Component)val).gameObject.SetActive(true);
					num++;
				}
				catch (Exception ex)
				{
					((ModBase)this).Log.Warn("[Medusa] material visibility renderer failed via " + source + ": " + ex.Message);
				}
			}
			if (_materialVisibilityLogCount < 12)
			{
				_materialVisibilityLogCount++;
				((ModBase)this).Log.Info($"[Medusa] material visibility via {source}: smrs={num} shader='{value}' localPos=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}).");
			}
			if (unityInstanceId != 0 && num > 0)
			{
				_materialPreparedVisuals.Add(unityInstanceId);
			}
		}
		catch (Exception ex2)
		{
			((ModBase)this).Log.Warn("[Medusa] material visibility failed via " + source + ": " + ex2.Message);
		}
	}

	private void GraftMedusaVisual(GameObject clone)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Expected O, but got Unknown
		//IL_064f: Unknown result type (might be due to invalid IL or missing references)
		//IL_065a: Expected O, but got Unknown
		//IL_077c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0787: Expected O, but got Unknown
		//IL_0856: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Expected O, but got Unknown
		//IL_0865: Unknown result type (might be due to invalid IL or missing references)
		//IL_086c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0876: Expected O, but got Unknown
		//IL_0876: Expected O, but got Unknown
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Expected O, but got Unknown
		//IL_06e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0939: Expected O, but got Unknown
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_095c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0967: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		//IL_0970: Unknown result type (might be due to invalid IL or missing references)
		//IL_097b: Expected O, but got Unknown
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a1: Expected O, but got Unknown
		//IL_02b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c2: Expected O, but got Unknown
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a2: Expected O, but got Unknown
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0414: Unknown result type (might be due to invalid IL or missing references)
		//IL_041f: Expected O, but got Unknown
		//IL_0378: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_0508: Unknown result type (might be due to invalid IL or missing references)
		//IL_0513: Expected O, but got Unknown
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_0538: Unknown result type (might be due to invalid IL or missing references)
		//IL_0543: Expected O, but got Unknown
		try
		{
			if (!_bundleLoaded || (Object)_medusaVisualPrefab == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] graft: bundle/visual not loaded; clone keeps base char's model.");
				return;
			}
			Material val = null;
			foreach (SkinnedMeshRenderer componentsInChild in clone.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					Material sharedMaterial = ((Renderer)componentsInChild).sharedMaterial;
					if ((Object)sharedMaterial != (Object)null && (Object)sharedMaterial.shader != (Object)null)
					{
						val = sharedMaterial;
						_toonTemplateMaterial = sharedMaterial;
						_toonTemplateMaterialName = ((Object)sharedMaterial).name;
						((ModBase)this).Log.Info($"[Medusa] graft: captured native toon template - SMR='{((Object)componentsInChild).name}', material='{((Object)sharedMaterial).name}', shader='{((Object)sharedMaterial.shader).name}'.");
						break;
					}
				}
			}
			if ((Object)val == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] graft: no base material to clone toon shader from; Medusa will keep her bundled Standard shader.");
			}
			Bounds bounds;
			bool hasBaseBounds = TryGetSkinnedRendererBounds(clone, includeMedusaVisual: false, out bounds);
			int value = DisableBaseCharacterRenderers(clone, "GraftMedusaVisual");
			((ModBase)this).Log.Info($"[Medusa] graft: disabled {value} base Renderer(s).");
			GameObject val2 = Object.Instantiate<GameObject>(_medusaVisualPrefab, clone.transform, false);
			((Object)val2).name = "Medusa_Visual";
			AnchorMedusaVisual(clone, val2, "GraftMedusaVisual");
			FitMedusaVisualToBaseBounds(val2, hasBaseBounds, bounds, "GraftMedusaVisual");
			CaptureMedusaVisualDefaultTransform(val2, "GraftMedusaVisual");
			ApplyCharacterRenderLayer(clone, val2, "GraftMedusaVisual");
			ForceMedusaVisualRenderable(val2, "GraftMedusaVisual");
			BindMedusaVisualToCharMaterial(clone, val2, "GraftMedusaVisual");
			int length = val2.GetComponentsInChildren<SkinnedMeshRenderer>(true).Length;
			Animator val3 = (_medusaAnimatorOnPrefab = val2.GetComponentInChildren<Animator>(true));
			CacheMedusaRuntimeController(val2, "GraftMedusaVisual");
			if ((Object)val != (Object)null)
			{
				Il2CppArrayBase<SkinnedMeshRenderer> componentsInChildren = val2.GetComponentsInChildren<SkinnedMeshRenderer>(true);
				int num = 0;
				string name = ((Object)val.shader).name;
				foreach (SkinnedMeshRenderer item in componentsInChildren)
				{
					if ((Object)item == (Object)null)
					{
						continue;
					}
					Material sharedMaterial2 = ((Renderer)item).sharedMaterial;
					Texture val4 = null;
					Texture val5 = null;
					string[] array;
					if ((Object)sharedMaterial2 != (Object)null)
					{
						array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
						foreach (string text in array)
						{
							if (sharedMaterial2.HasProperty(text))
							{
								Texture texture = sharedMaterial2.GetTexture(text);
								if ((Object)texture != (Object)null)
								{
									val4 = texture;
									break;
								}
							}
						}
						array = new string[3] { "_BumpMap", "_NormalMap", "_NormalTex" };
						foreach (string text2 in array)
						{
							if (sharedMaterial2.HasProperty(text2))
							{
								Texture texture2 = sharedMaterial2.GetTexture(text2);
								if ((Object)texture2 != (Object)null)
								{
									val5 = texture2;
									break;
								}
							}
						}
					}
					Material val6;
					try
					{
						val6 = new Material(val);
					}
					catch (Exception ex)
					{
						((ModBase)this).Log.Warn("[Medusa] graft: new Material(template) threw: " + ex.Message);
						break;
					}
					((Object)val6).name = "Medusa_Material_Native";
					array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
					foreach (string text3 in array)
					{
						if (val6.HasProperty(text3) && (Object)val4 != (Object)null)
						{
							val6.SetTexture(text3, val4);
						}
					}
					array = new string[3] { "_BumpMap", "_NormalMap", "_NormalTex" };
					foreach (string text4 in array)
					{
						if (val6.HasProperty(text4) && (Object)val5 != (Object)null)
						{
							val6.SetTexture(text4, val5);
						}
					}
					ApplyMedusaTextureOverrides(val6, val4, val5, "GraftMedusaVisual");
					((Renderer)item).sharedMaterial = val6;
					num++;
					((ModBase)this).Log.Info($"[Medusa] graft: shader applied to '{((Object)item).name}' (shader='{name}', albedo='{(((Object)val4 != (Object)null) ? ((Object)val4).name : "<none>")}', normal='{(((Object)val5 != (Object)null) ? ((Object)val5).name : "<none>")}').");
				}
				if (num > 0)
				{
					_toonShaderApplied = name;
				}
				((ModBase)this).Log.Info($"[Medusa] graft: applied native toon shader '{name}' to {num} Medusa SkinnedMeshRenderer(s).");
			}
			ForceMedusaVisualMaterialVisibility(val2, "GraftMedusaVisual.postShader");
			ForceMedusaVisualRenderable(val2, "GraftMedusaVisual.postMaterial");
			ForceMedusaCharMaterialVisible(clone, val2, "GraftMedusaVisual.postMaterial");
			LogMedusaVisualDiagnostics(clone, val2, "GraftMedusaVisual.postMaterial");
			if ((Object)val3 != (Object)null)
			{
				Il2CppArrayBase<CharAnimator> componentsInChildren2 = clone.GetComponentsInChildren<CharAnimator>(true);
				int num2 = 0;
				foreach (CharAnimator item2 in componentsInChildren2)
				{
					if ((Object)item2 == (Object)null)
					{
						continue;
					}
					try
					{
						item2.animator = val3;
						try
						{
							item2.customAnimator = true;
						}
						catch (Exception ex2)
						{
							((ModBase)this).Log.Warn("[Medusa] graft: ca.customAnimator setter threw (continuing): " + ex2.Message);
						}
						num2++;
					}
					catch (Exception ex3)
					{
						((ModBase)this).Log.Warn("[Medusa] graft: CharAnimator.animator wire failed: " + ex3.Message);
					}
				}
				_charAnimatorWired = num2;
				string value2 = "?";
				try
				{
					value2 = (((Object)val3.runtimeAnimatorController != (Object)null) ? ((Object)val3.runtimeAnimatorController).name : "<null>");
				}
				catch
				{
				}
				((ModBase)this).Log.Info($"[Medusa] graft: wired CharAnimator.animator -> Medusa's Animator (count={num2}, customAnimator=true, controller='{value2}').");
				try
				{
					Il2CppArrayBase<CharFootsteps> componentsInChildren3 = clone.GetComponentsInChildren<CharFootsteps>(true);
					int num3 = 0;
					foreach (CharFootsteps item3 in componentsInChildren3)
					{
						if (!((Object)item3 == (Object)null))
						{
							try
							{
								item3.animator = val3;
								num3++;
							}
							catch (Exception ex4)
							{
								((ModBase)this).Log.Warn("[Medusa] graft: CharFootsteps.animator wire failed: " + ex4.Message);
							}
						}
					}
					_charFootstepsWired = num3;
					((ModBase)this).Log.Info($"[Medusa] graft: wired CharFootsteps.animator -> Medusa's Animator (count={num3}).");
				}
				catch (Exception ex5)
				{
					((ModBase)this).Log.Warn("[Medusa] graft: CharFootsteps section: " + ex5.Message);
				}
				Il2CppArrayBase<Animator> componentsInChildren4 = clone.GetComponentsInChildren<Animator>(true);
				int num4 = 0;
				foreach (Animator item4 in componentsInChildren4)
				{
					if (!((Object)item4 == (Object)null) && !((Object)item4 == (Object)val3))
					{
						try
						{
							((Behaviour)item4).enabled = false;
							num4++;
						}
						catch
						{
						}
					}
				}
				_disabledNonMedusaAnims = num4;
				((ModBase)this).Log.Info($"[Medusa] graft: disabled {num4} non-Medusa Animator(s) on the clone.");
			}
			else
			{
				((ModBase)this).Log.Warn("[Medusa] graft: no Animator under Medusa_Visual - CharAnimator wiring skipped.");
			}
			((ModBase)this).Log.Info($"[Medusa] graft: instantiated Medusa_Visual under clone (SkinnedMeshRenderers={length}, animator={(((Object)val3 != (Object)null) ? "yes" : "no")}, controller='{(((Object)val3 != (Object)null && (Object)val3.runtimeAnimatorController != (Object)null) ? ((Object)val3.runtimeAnimatorController).name : "?")}').");
		}
		catch (Exception ex6)
		{
			((ModBase)this).Log.Error("[Medusa] GraftMedusaVisual: " + ex6);
		}
	}

	private void EnsureLiveMedusaVisual(GameObject root, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Expected O, but got Unknown
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Expected O, but got Unknown
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_023c: Expected O, but got Unknown
		//IL_068e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0699: Expected O, but got Unknown
		//IL_0333: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Expected O, but got Unknown
		//IL_0354: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Expected O, but got Unknown
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_047e: Expected O, but got Unknown
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bb: Expected O, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dd: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_041a: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null || !_bundleLoaded || (Object)_medusaVisualPrefab == (Object)null)
			{
				return;
			}
			int unityInstanceId = GetUnityInstanceId((Object?)(object)root);
			GameObject val = FindMedusaVisualObject(root);
			if ((Object)val != (Object)null && IsLiveMedusaVisualStable(root, val, source))
			{
				EnsureStableLiveMedusaVisualCheap(root, val, source + ".stable");
				return;
			}
			if ((Object)FindMedusaAnimatorUnder(root.transform) != (Object)null)
			{
				Bounds bounds;
				bool hasBaseBounds = TryGetSkinnedRendererBounds(root, includeMedusaVisual: false, out bounds);
				if ((Object)val != (Object)null)
				{
					AnchorMedusaVisual(root, val, source + ".existing");
					FitMedusaVisualToBaseBounds(val, hasBaseBounds, bounds, source + ".existing");
					ApplyCharacterRenderLayer(root, val, source + ".existing");
					ForceMedusaVisualRenderable(val, source + ".existing");
					if (unityInstanceId == 0 || !_charMaterialBoundRoots.Contains(unityInstanceId) || !IsCharMaterialBoundToVisual(root, val))
					{
						BindMedusaVisualToCharMaterial(root, val, source + ".existing");
					}
					ForceMedusaVisualMaterialVisibility(val, source + ".existing.postCharMaterial");
					ForceMedusaVisualRenderable(val, source + ".existing.postFit");
					if (unityInstanceId == 0 || !_charMaterialVisibleRoots.Contains(unityInstanceId) || NeedsCharMaterialVisibilityRepair(root, val))
					{
						ForceMedusaCharMaterialVisible(root, val, source + ".existing.postFit");
					}
					LogMedusaVisualDiagnostics(root, val, source + ".existing.postFit");
					TryDismissLoadingOverlayAfterMedusaSpawn(source + ".existing");
					MarkLiveMedusaVisualStable(root, val);
				}
				DisableBaseCharacterRenderers(root, source + ".existing");
				if (unityInstanceId == 0 || _runtimeReboundVisualRoots.Add(unityInstanceId))
				{
					RebindMedusaRuntime(root, source + ".existing");
				}
				return;
			}
			Material val2 = null;
			foreach (SkinnedMeshRenderer componentsInChild in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)componentsInChild == (Object)null)
				{
					continue;
				}
				Material sharedMaterial = ((Renderer)componentsInChild).sharedMaterial;
				if ((Object)sharedMaterial != (Object)null && (Object)sharedMaterial.shader != (Object)null)
				{
					val2 = sharedMaterial;
					if ((Object)_toonTemplateMaterial == (Object)null)
					{
						_toonTemplateMaterial = sharedMaterial;
					}
					break;
				}
			}
			Bounds bounds2;
			bool hasBaseBounds2 = TryGetSkinnedRendererBounds(root, includeMedusaVisual: false, out bounds2);
			GameObject val3 = Object.Instantiate<GameObject>(_medusaVisualPrefab, root.transform, false);
			((Object)val3).name = "Medusa_Visual";
			AnchorMedusaVisual(root, val3, source + ".new");
			FitMedusaVisualToBaseBounds(val3, hasBaseBounds2, bounds2, source + ".new");
			ApplyCharacterRenderLayer(root, val3, source + ".new");
			ForceMedusaVisualRenderable(val3, source + ".new");
			BindMedusaVisualToCharMaterial(root, val3, source + ".new");
			CacheMedusaRuntimeController(val3, source + ".new");
			if ((Object)val2 != (Object)null)
			{
				foreach (SkinnedMeshRenderer componentsInChild2 in val3.GetComponentsInChildren<SkinnedMeshRenderer>(true))
				{
					if ((Object)componentsInChild2 == (Object)null)
					{
						continue;
					}
					Material sharedMaterial2 = ((Renderer)componentsInChild2).sharedMaterial;
					Texture val4 = null;
					Texture val5 = null;
					string[] array;
					if ((Object)sharedMaterial2 != (Object)null)
					{
						array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
						foreach (string text in array)
						{
							if (sharedMaterial2.HasProperty(text))
							{
								val4 = sharedMaterial2.GetTexture(text);
								if ((Object)val4 != (Object)null)
								{
									break;
								}
							}
						}
						array = new string[3] { "_BumpMap", "_NormalMap", "_NormalTex" };
						foreach (string text2 in array)
						{
							if (sharedMaterial2.HasProperty(text2))
							{
								val5 = sharedMaterial2.GetTexture(text2);
								if ((Object)val5 != (Object)null)
								{
									break;
								}
							}
						}
					}
					Material val6 = new Material(val2)
					{
						name = "Medusa_Material_Native_Live"
					};
					array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
					foreach (string text3 in array)
					{
						if ((Object)val4 != (Object)null && val6.HasProperty(text3))
						{
							val6.SetTexture(text3, val4);
						}
					}
					array = new string[3] { "_BumpMap", "_NormalMap", "_NormalTex" };
					foreach (string text4 in array)
					{
						if ((Object)val5 != (Object)null && val6.HasProperty(text4))
						{
							val6.SetTexture(text4, val5);
						}
					}
					ApplyMedusaTextureOverrides(val6, val4, val5, source + ".new");
					((Renderer)componentsInChild2).sharedMaterial = val6;
				}
			}
			ForceMedusaVisualMaterialVisibility(val3, source + ".new.postShader");
			ForceMedusaVisualRenderable(val3, source + ".new.postMaterial");
			ForceMedusaCharMaterialVisible(root, val3, source + ".new.postMaterial");
			int value = DisableBaseCharacterRenderers(root, source + ".new");
			ForceMedusaVisualMaterialVisibility(val3, source + ".new.postBaseHide");
			ForceMedusaVisualRenderable(val3, source + ".new.postBaseHide");
			ForceMedusaCharMaterialVisible(root, val3, source + ".new.postBaseHide");
			LogMedusaVisualDiagnostics(root, val3, source + ".new.postMaterial");
			TryDismissLoadingOverlayAfterMedusaSpawn(source + ".new");
			if (unityInstanceId == 0 || _runtimeReboundVisualRoots.Add(unityInstanceId))
			{
				RebindMedusaRuntime(root, source + ".new");
			}
			MarkLiveMedusaVisualStable(root, val3);
			if (_liveGraftLogCount < 10)
			{
				_liveGraftLogCount++;
				((ModBase)this).Log.Info($"[Medusa] live visual graft via {source}: root='{((Object)root).name}' disabledBaseSmr={value} shaderTemplate='{(((Object)val2 != (Object)null) ? ((Object)val2).name : "<none>")}'.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] EnsureLiveMedusaVisual failed via " + source + ": " + ex.Message);
		}
	}

	private void TryDismissLoadingOverlayAfterMedusaSpawn(string source)
	{
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		try
		{
			float num;
			try
			{
				num = Time.unscaledTime;
			}
			catch
			{
				num = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
			}
			if (_lastLoadingOverlayDismissScanAt > 0f && num - _lastLoadingOverlayDismissScanAt < 3f)
			{
				return;
			}
			_lastLoadingOverlayDismissScanAt = num;
			int num2 = 0;
			HashSet<int> hashSet = new HashSet<int>();
			foreach (GameObject item in Object.FindObjectsOfType<GameObject>(true))
			{
				if (!((Object)item == (Object)null) && IsLoadingOverlayObject(item))
				{
					GameObject val = ResolveLoadingOverlayTarget(item);
					int instanceID = ((Object)val).GetInstanceID();
					if (hashSet.Add(instanceID) && _dismissedLoadingOverlayTargets.Add(instanceID))
					{
						num2 += HideLoadingOverlayObject(val);
					}
				}
			}
			if (num2 > 0 && _loadingOverlayHideLogCount < 6)
			{
				_loadingOverlayHideLogCount++;
				((ModBase)this).Log.Info($"[Medusa] dismissed {num2} loading overlay object(s) after live spawn via {source}.");
			}
			else if (num2 == 0 && _loadingOverlayHideLogCount < 2)
			{
				_loadingOverlayHideLogCount++;
				((ModBase)this).Log.Info("[Medusa] no loading overlay candidates found after live spawn via " + source + ".");
			}
		}
		catch (Exception ex)
		{
			if (_loadingOverlayHideLogCount < 6)
			{
				_loadingOverlayHideLogCount++;
				((ModBase)this).Log.Warn("[Medusa] loading overlay dismiss failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static bool IsLoadingOverlayObject(GameObject gameObject)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		if ((Object)gameObject == (Object)null)
		{
			return false;
		}
		string transformPath = GetTransformPath(gameObject.transform);
		if (transformPath.IndexOf("Loading", StringComparison.OrdinalIgnoreCase) >= 0 || transformPath.IndexOf("UILobbySplashScreen", StringComparison.OrdinalIgnoreCase) >= 0 || transformPath.IndexOf("GameStarting", StringComparison.OrdinalIgnoreCase) >= 0 || transformPath.IndexOf("Game Starting", StringComparison.OrdinalIgnoreCase) >= 0 || transformPath.IndexOf("Starting Game", StringComparison.OrdinalIgnoreCase) >= 0 || transformPath.IndexOf("Game is Starting", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		return ContainsLoadingText(gameObject, includeChildren: false);
	}

	private static GameObject ResolveLoadingOverlayTarget(GameObject gameObject)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Expected O, but got Unknown
		Canvas componentInParent = gameObject.GetComponentInParent<Canvas>();
		if ((Object)componentInParent == (Object)null || (Object)(object)gameObject.transform == (Object)(object)((Component)componentInParent).transform)
		{
			return gameObject;
		}
		Transform val = gameObject.transform;
		Transform val2 = null;
		while ((Object)val.parent != (Object)null && (Object)(object)val.parent != (Object)(object)((Component)componentInParent).transform)
		{
			string text = ((Object)val).name ?? "";
			if (text.IndexOf("Loading", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("UILobbySplashScreen", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("GameStarting", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("GameStart", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Starting Game", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Game is Starting", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				val2 = val;
			}
			val = val.parent;
		}
		if ((Object)val2 != (Object)null)
		{
			return ((Component)val2).gameObject;
		}
		if (ContainsLoadingText(gameObject, includeChildren: false) && (Object)gameObject.transform.parent != (Object)null)
		{
			return ((Component)gameObject.transform.parent).gameObject;
		}
		return gameObject;
	}

	private static bool ContainsLoadingText(GameObject gameObject, bool includeChildren = true)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		try
		{
			foreach (Component item in (IEnumerable<Component>)(includeChildren ? gameObject.GetComponentsInChildren<Component>(true) : gameObject.GetComponents<Component>()))
			{
				if (!((Object)item == (Object)null))
				{
					Type type = ((object)item).GetType();
					if ((type.Name.IndexOf("Text", StringComparison.OrdinalIgnoreCase) >= 0 || type.Name.IndexOf("Label", StringComparison.OrdinalIgnoreCase) >= 0) && (TryReadStringProperty(item, "text") ?? TryReadStringProperty(item, "m_text")) is string text && IsBlockingOverlayText(text))
					{
						return true;
					}
				}
			}
		}
		catch
		{
			return false;
		}
		return false;
	}

	private static bool IsBlockingOverlayText(string text)
	{
		if (text.IndexOf("Loading", StringComparison.OrdinalIgnoreCase) < 0 && text.IndexOf("Game Starting", StringComparison.OrdinalIgnoreCase) < 0 && text.IndexOf("Game is Starting", StringComparison.OrdinalIgnoreCase) < 0)
		{
			return text.IndexOf("Starting Game", StringComparison.OrdinalIgnoreCase) >= 0;
		}
		return true;
	}

	private static object TryReadStringProperty(object instance, string name)
	{
		try
		{
			PropertyInfo property = instance.GetType().GetProperty(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (property != null && property.GetIndexParameters().Length == 0)
			{
				return property.GetValue(instance);
			}
			FieldInfo field = instance.GetType().GetField(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			return (field != null) ? field.GetValue(instance) : null;
		}
		catch
		{
			return null;
		}
	}

	private static int HideLoadingOverlayObject(GameObject gameObject)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		int num = 0;
		try
		{
			foreach (CanvasGroup componentsInChild in gameObject.GetComponentsInChildren<CanvasGroup>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					componentsInChild.alpha = 0f;
					componentsInChild.interactable = false;
					componentsInChild.blocksRaycasts = false;
					num++;
				}
			}
		}
		catch
		{
		}
		if (gameObject.activeSelf)
		{
			gameObject.SetActive(false);
			num++;
		}
		return num;
	}

	private static string GetTransformPath(Transform transform)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Expected O, but got Unknown
		List<string> list = new List<string>();
		Transform val = transform;
		while ((Object)val != (Object)null)
		{
			list.Add(((Object)val).name);
			val = val.parent;
		}
		list.Reverse();
		return string.Join("/", list);
	}

	private static int DisableBaseCharacterRenderers(GameObject root, string source)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Expected O, but got Unknown
		int num = 0;
		try
		{
			if ((Object)root == (Object)null)
			{
				return 0;
			}
			foreach (Renderer componentsInChild in root.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)componentsInChild == (Object)null || IsUnderMedusaVisual(((Component)componentsInChild).transform))
				{
					continue;
				}
				try
				{
					if (componentsInChild.enabled)
					{
						num++;
					}
					componentsInChild.enabled = false;
					try
					{
						componentsInChild.forceRenderingOff = true;
					}
					catch
					{
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] DisableBaseCharacterRenderers failed via " + source + ": " + ex.Message);
			}
		}
		return num;
	}

	private static bool IsUnderMedusaVisual(Transform? t)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		try
		{
			while ((Object)t != (Object)null)
			{
				string text = ((Object)t).name ?? "";
				if (string.Equals(text, "Medusa_Visual", StringComparison.Ordinal) || string.Equals(text, "MedusaBase", StringComparison.Ordinal) || text.StartsWith("Medusa_Visual", StringComparison.Ordinal) || text.StartsWith("MedusaBase", StringComparison.Ordinal))
				{
					return true;
				}
				t = t.parent;
			}
		}
		catch
		{
		}
		return false;
	}

	private static Animator? FindMedusaAnimatorUnder(Transform root)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected O, but got Unknown
		//IL_00bb: Expected O, but got Unknown
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_008e: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null)
			{
				return null;
			}
			foreach (Animator componentsInChild in ((Component)root).GetComponentsInChildren<Animator>(true))
			{
				if ((Object)componentsInChild == (Object)null)
				{
					continue;
				}
				try
				{
					if (IsMedusaRuntimeController(componentsInChild.runtimeAnimatorController))
					{
						return componentsInChild;
					}
				}
				catch
				{
				}
				try
				{
					Transform val = ((Component)componentsInChild).transform;
					bool flag = false;
					while ((Object)val != (Object)null && (Object)val != (Object)root.parent)
					{
						if (((Object)val).name == "Medusa_Visual")
						{
							flag = true;
							break;
						}
						if ((Object)val == (Object)root)
						{
							break;
						}
						val = val.parent;
					}
					if (flag && TryAssignCachedMedusaController(componentsInChild, "FindMedusaAnimatorUnder"))
					{
						return componentsInChild;
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static bool IsMedusaRuntimeController(RuntimeAnimatorController? controller)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		try
		{
			if ((Object)controller == (Object)null)
			{
				return false;
			}
			string text = ((Object)controller).name ?? string.Empty;
			return text == "Medusa" || text.IndexOf("Medusa", StringComparison.OrdinalIgnoreCase) >= 0;
		}
		catch
		{
			return false;
		}
	}

	private RuntimeAnimatorController? ResolveMedusaRuntimeController()
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Expected O, but got Unknown
		try
		{
			if (IsMedusaRuntimeController(_medusaRuntimeController))
			{
				return _medusaRuntimeController;
			}
			if ((Object)_medusaAnimatorOnPrefab != (Object)null && IsMedusaRuntimeController(_medusaAnimatorOnPrefab.runtimeAnimatorController))
			{
				_medusaRuntimeController = _medusaAnimatorOnPrefab.runtimeAnimatorController;
				return _medusaRuntimeController;
			}
			if ((Object)_medusaVisualPrefab != (Object)null)
			{
				return CacheMedusaRuntimeController(_medusaVisualPrefab, "ResolveMedusaRuntimeController.prefab");
			}
		}
		catch
		{
		}
		return null;
	}

	private RuntimeAnimatorController? CacheMedusaRuntimeController(GameObject visual, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		try
		{
			if ((Object)visual == (Object)null)
			{
				return null;
			}
			foreach (Animator componentsInChild in visual.GetComponentsInChildren<Animator>(true))
			{
				if ((Object)componentsInChild == (Object)null)
				{
					continue;
				}
				RuntimeAnimatorController val = null;
				try
				{
					val = componentsInChild.runtimeAnimatorController;
				}
				catch
				{
				}
				if (IsMedusaRuntimeController(val))
				{
					_medusaAnimatorOnPrefab = componentsInChild;
					_medusaRuntimeController = val;
					if (_animatorRepairLogCount < 8)
					{
						_animatorRepairLogCount++;
						((ModBase)this).Log.Info($"[Medusa] cached animator controller via {source}: animator='{((Object)((Component)componentsInChild).gameObject).name}' controller='{((Object)val).name}'.");
					}
					return val;
				}
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] animator controller cache failed via " + source + ": " + ex.Message);
		}
		return null;
	}

	private static bool TryAssignCachedMedusaController(Animator animator, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		try
		{
			if ((Object)animator == (Object)null)
			{
				return false;
			}
			if (IsMedusaRuntimeController(animator.runtimeAnimatorController))
			{
				return true;
			}
			MedusaMod instance = _instance;
			RuntimeAnimatorController val = instance?.ResolveMedusaRuntimeController();
			if (!IsMedusaRuntimeController(val))
			{
				return false;
			}
			animator.runtimeAnimatorController = val;
			if (instance != null && instance._animatorRepairLogCount < 8)
			{
				instance._animatorRepairLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] animator controller repaired via {source}: animator='{((Object)((Component)animator).gameObject).name}' controller='{((Object)val).name}'.");
			}
			return IsMedusaRuntimeController(animator.runtimeAnimatorController);
		}
		catch
		{
			return false;
		}
	}

	private static void RebindMedusaRuntime(GameObject root, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		//IL_0118: Expected O, but got Unknown
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		try
		{
			if ((Object)root == (Object)null)
			{
				return;
			}
			Animator val = FindMedusaAnimatorUnder(root.transform);
			if ((Object)val == (Object)null)
			{
				return;
			}
			int num = 0;
			foreach (CharAnimator componentsInChild in root.GetComponentsInChildren<CharAnimator>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					try
					{
						componentsInChild.animator = val;
						componentsInChild.customAnimator = true;
						num++;
					}
					catch
					{
					}
				}
			}
			int num2 = 0;
			foreach (CharFootsteps componentsInChild2 in root.GetComponentsInChildren<CharFootsteps>(true))
			{
				if (!((Object)componentsInChild2 == (Object)null))
				{
					try
					{
						componentsInChild2.animator = val;
						num2++;
					}
					catch
					{
					}
				}
			}
			foreach (Animator componentsInChild3 in root.GetComponentsInChildren<Animator>(true))
			{
				if (!((Object)componentsInChild3 == (Object)null) && !((Object)componentsInChild3 == (Object)val))
				{
					try
					{
						((Behaviour)componentsInChild3).enabled = false;
					}
					catch
					{
					}
				}
			}
			DisableBaseCharacterRenderers(root, source + ".rebind");
			MedusaMod instance = _instance;
			if (instance != null && instance._liveGraftLogCount < 10)
			{
				instance._liveGraftLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] live rebind via {source}: root='{((Object)root).name}' charAnim={num} footsteps={num2} controller='{(((Object)val.runtimeAnimatorController != (Object)null) ? ((Object)val.runtimeAnimatorController).name : "?")}'.");
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] RebindMedusaRuntime failed via " + source + ": " + ex.Message);
			}
		}
	}

	public void LogAnimatorState()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_01ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Expected O, but got Unknown
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected O, but got Unknown
		//IL_014d: Expected O, but got Unknown
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		try
		{
			if ((Object)_medusaAnimatorOnPrefab != (Object)null)
			{
				Animator medusaAnimatorOnPrefab = _medusaAnimatorOnPrefab;
				string value = "?";
				int value2 = -1;
				try
				{
					value = (((Object)medusaAnimatorOnPrefab.runtimeAnimatorController != (Object)null) ? ((Object)medusaAnimatorOnPrefab.runtimeAnimatorController).name : "<null>");
				}
				catch
				{
				}
				try
				{
					value2 = medusaAnimatorOnPrefab.parameterCount;
				}
				catch
				{
				}
				((ModBase)this).Log.Info($"[Medusa] anim(prefab): name='{((Object)((Component)medusaAnimatorOnPrefab).gameObject).name}' enabled={((Behaviour)medusaAnimatorOnPrefab).enabled} controller='{value}' parameterCount={value2}");
				LogAnimatorParams("anim(prefab)", medusaAnimatorOnPrefab);
			}
			else
			{
				((ModBase)this).Log.Info("[Medusa] anim(prefab): not yet captured (graft hasn't run).");
			}
			int num = 0;
			Il2CppArrayBase<Animator> val = null;
			try
			{
				val = Object.FindObjectsOfType<Animator>();
			}
			catch
			{
			}
			if (val != null)
			{
				foreach (Animator item in val)
				{
					if ((Object)item == (Object)null || (Object)item == (Object)_medusaAnimatorOnPrefab)
					{
						continue;
					}
					bool flag = false;
					try
					{
						RuntimeAnimatorController runtimeAnimatorController = item.runtimeAnimatorController;
						if ((Object)runtimeAnimatorController != (Object)null && ((Object)runtimeAnimatorController).name == "Medusa")
						{
							flag = true;
						}
					}
					catch
					{
					}
					if (!flag)
					{
						try
						{
							Transform val2 = ((Component)item).transform;
							while ((Object)val2 != (Object)null)
							{
								if (((Object)val2).name == "Medusa_Visual")
								{
									flag = true;
									break;
								}
								val2 = val2.parent;
							}
						}
						catch
						{
						}
					}
					if (flag)
					{
						num++;
						string value3 = "?";
						try
						{
							value3 = (((Object)item.runtimeAnimatorController != (Object)null) ? ((Object)item.runtimeAnimatorController).name : "<null>");
						}
						catch
						{
						}
						((ModBase)this).Log.Info($"[Medusa] anim(LIVE@{num}): name='{((Object)((Component)item).transform).name}' enabled={((Behaviour)item).enabled} controller='{value3}'");
						LogAnimatorParamsLive($"anim(LIVE@{num})", item);
					}
				}
			}
			if (num == 0)
			{
				((ModBase)this).Log.Info("[Medusa] anim(LIVE): no Medusa instance in the active scene yet (need a match with someone selecting Medusa).");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] LogAnimatorState: " + ex);
		}
	}

	private void LogAnimatorParams(string tag, Animator a)
	{
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int num = -1;
			try
			{
				num = a.parameterCount;
			}
			catch
			{
			}
			if (num <= 0)
			{
				((ModBase)this).Log.Info($"[Medusa] {tag}: parameters not enumerable on inactive prefab (n={num}).");
				return;
			}
			int num2 = Math.Min(num, 12);
			List<string> list = new List<string>();
			for (int i = 0; i < num2; i++)
			{
				try
				{
					AnimatorControllerParameter parameter = a.GetParameter(i);
					if (parameter != null)
					{
						list.Add($"{parameter.name}({parameter.type})");
					}
				}
				catch
				{
				}
			}
			((ModBase)this).Log.Info($"[Medusa] {tag}: parameters({num2}/{num}) = [{string.Join(", ", list)}]");
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] " + tag + ": param enum: " + ex.Message);
		}
	}

	private void LogAnimatorParamsLive(string tag, Animator a)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		float value = 0f;
		float value2 = 0f;
		float value3 = 0f;
		float value4 = 0f;
		float value5 = 0f;
		bool value6 = false;
		string value7 = "?";
		try
		{
			value = a.GetFloat("Forward");
		}
		catch
		{
		}
		try
		{
			value2 = a.GetFloat("Strafe");
		}
		catch
		{
		}
		try
		{
			value3 = a.GetFloat("Turn");
		}
		catch
		{
		}
		try
		{
			value4 = a.GetFloat("MoveSpeed");
		}
		catch
		{
		}
		try
		{
			value5 = a.GetFloat("AttackSpeed");
		}
		catch
		{
		}
		try
		{
			value6 = a.GetBool("IsMoving");
		}
		catch
		{
		}
		try
		{
			AnimatorStateInfo currentAnimatorStateInfo = a.GetCurrentAnimatorStateInfo(0);
			value7 = $"hash={((AnimatorStateInfo)(ref currentAnimatorStateInfo)).fullPathHash} norm={((AnimatorStateInfo)(ref currentAnimatorStateInfo)).normalizedTime:F2}";
		}
		catch
		{
		}
		((ModBase)this).Log.Info($"[Medusa] {tag}: Forward={value:F2} Strafe={value2:F2} Turn={value3:F2} MoveSpeed={value4:F2} AttackSpeed={value5:F2} IsMoving={value6} state[{value7}]");
		LogAnimatorParams(tag, a);
	}

	private static Il2CppReferenceArray<CharacterConfiguration> Append(Il2CppReferenceArray<CharacterConfiguration> arr, CharacterConfiguration item)
	{
		int num = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)?.Length ?? 0;
		Il2CppReferenceArray<CharacterConfiguration> val = new Il2CppReferenceArray<CharacterConfiguration>((long)(num + 1));
		for (int i = 0; i < num; i++)
		{
			((Il2CppArrayBase<CharacterConfiguration>)(object)val)[i] = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)[i];
		}
		((Il2CppArrayBase<CharacterConfiguration>)(object)val)[num] = item;
		return val;
	}

	private static void MoveMedusaIntoVisibleMatchSlot(UICharactersConfiguration cfg, string source)
	{
		try
		{
			int medusaId = CurrentMedusaId();
			cfg._characters = MoveMedusaIntoVisibleSlot(cfg._characters, medusaId, out var changed, out var oldIndex, out var newIndex);
			bool changed2;
			try
			{
				cfg._lobbyCharacters = MoveMedusaIntoVisibleSlot(cfg._lobbyCharacters, medusaId, out changed2, out var _, out var _);
			}
			catch
			{
				changed2 = false;
			}
			if ((changed || changed2) && _medusaVisibleSlotLogCount < 8)
			{
				_medusaVisibleSlotLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] moved Medusa into visible match select slot via {source}: oldIndex={oldIndex} newIndex={newIndex} lobbyChanged={changed2}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] visible match slot reorder failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static Il2CppReferenceArray<CharacterConfiguration> MoveMedusaIntoVisibleSlot(Il2CppReferenceArray<CharacterConfiguration> arr, int medusaId, out bool changed, out int oldIndex, out int newIndex)
	{
		changed = false;
		oldIndex = -1;
		newIndex = -1;
		int num = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)?.Length ?? 0;
		if (num <= 0)
		{
			return arr;
		}
		for (int i = 0; i < num; i++)
		{
			CharacterConfiguration val = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)[i];
			if (val != null && val.charId == medusaId)
			{
				oldIndex = i;
				break;
			}
		}
		if (oldIndex < 0)
		{
			return arr;
		}
		int num2 = Math.Min(7, num - 1);
		if (num2 <= 0 || oldIndex <= num2)
		{
			newIndex = oldIndex;
			return arr;
		}
		Il2CppReferenceArray<CharacterConfiguration> val2 = new Il2CppReferenceArray<CharacterConfiguration>((long)num);
		CharacterConfiguration val3 = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)[oldIndex];
		int num3 = 0;
		for (int j = 0; j < num; j++)
		{
			if (num3 == num2)
			{
				((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[num3++] = val3;
			}
			if (j != oldIndex)
			{
				((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[num3++] = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)[j];
			}
		}
		changed = true;
		newIndex = num2;
		return val2;
	}

	private static void RepairPrematchMedusaButton(View_PreMatch_CharSelect view, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0222: Unknown result type (might be due to invalid IL or missing references)
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		//IL_027a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0310: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)view == (Object)null)
			{
				return;
			}
			Il2CppReferenceArray<UILobbyCharacterSelectIcon> charSelectButtons = view._charSelectButtons;
			int num = ((Il2CppArrayBase<UILobbyCharacterSelectIcon>)(object)charSelectButtons)?.Length ?? 0;
			if (num <= 0)
			{
				return;
			}
			int num2 = FindCharacterConfigIndex(CurrentMedusaId());
			if (num2 < 0 || num2 >= num)
			{
				if (_prematchButtonRepairLogCount < 8)
				{
					_prematchButtonRepairLogCount++;
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Warn($"[Medusa] prematch button repair skipped via {source}: medusaIndex={num2} buttonCount={num}.");
					}
				}
				return;
			}
			UILobbyCharacterSelectIcon val = ((Il2CppArrayBase<UILobbyCharacterSelectIcon>)(object)charSelectButtons)[num2];
			if ((Object)val == (Object)null)
			{
				return;
			}
			((Component)val).gameObject.SetActive(true);
			_lastPrematchCharSelectView = view;
			_lastPrematchMedusaIcon = val;
			try
			{
				val.SetInteractable(true);
			}
			catch
			{
			}
			BindPrematchMedusaIcon(val, source);
			Transform transform = ((Component)val).transform;
			RectTransform val2 = (RectTransform)(object)((transform is RectTransform) ? transform : null);
			Vector3 value = (((Object)val2 != (Object)null) ? ((Transform)val2).localPosition : ((Component)val).transform.localPosition);
			Vector2 value2 = (((Object)val2 != (Object)null) ? val2.anchoredPosition : Vector2.zero);
			if ((Object)val2 != (Object)null)
			{
				((Transform)val2).SetAsLastSibling();
				((Transform)val2).localScale = Vector3.one * 1.15f;
				((Transform)val2).localPosition = new Vector3(((Transform)val2).localPosition.x, 262.5f, ((Transform)val2).localPosition.z);
				val2.anchoredPosition = new Vector2(val2.anchoredPosition.x, val2.anchoredPosition.y);
			}
			else
			{
				Vector3 localPosition = ((Component)val).transform.localPosition;
				((Component)val).transform.localPosition = new Vector3(localPosition.x, 262.5f, localPosition.z);
				((Component)val).transform.localScale = Vector3.one * 1.15f;
			}
			if (_prematchButtonRepairLogCount < 16)
			{
				_prematchButtonRepairLogCount++;
				MedusaMod instance2 = _instance;
				if (instance2 != null)
				{
					Vector3 value3 = (((Object)val2 != (Object)null) ? ((Transform)val2).localPosition : ((Component)val).transform.localPosition);
					Vector2 value4 = (((Object)val2 != (Object)null) ? val2.anchoredPosition : Vector2.zero);
					((ModBase)instance2).Log.Info($"[Medusa] prematch Medusa button repaired via {source}: index={num2}/{num} beforeLocal={value} afterLocal={value3} beforeAnchored={value2} afterAnchored={value4}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance3 = _instance;
			if (instance3 != null)
			{
				((ModBase)instance3).Log.Warn("[Medusa] prematch button repair failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void BindPrematchMedusaIcon(UILobbyCharacterSelectIcon icon, string source)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		try
		{
			if ((Object)icon == (Object)null)
			{
				return;
			}
			try
			{
				icon._action = null;
			}
			catch
			{
			}
			Button button = icon._button;
			bool value = false;
			if ((Object)button != (Object)null && button.onClick != null)
			{
				((UnityEventBase)button.onClick).RemoveAllListeners();
				((Selectable)button).interactable = true;
				value = true;
			}
			PrematchMedusaClickProxy.Attach(((Component)icon).gameObject, delegate
			{
				HandlePrematchMedusaIconClick(icon);
			}, source);
			if (_matchSelectLogCount < 48)
			{
				_matchSelectLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] prematch Medusa icon rebound via {source}: button={value} charId={CurrentMedusaId()}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] prematch Medusa icon bind failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void HandlePrematchMedusaIconClick(UILobbyCharacterSelectIcon icon)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		try
		{
			RememberExplicitMedusaSelection("PrematchMedusaIcon.click");
			try
			{
				if ((Object)icon != (Object)null)
				{
					_lastPrematchMedusaIcon = icon;
					icon.selected = true;
					icon.SetInteractable(true);
					icon.SelectUIButton(true);
					icon.CharacterSetSelected();
				}
			}
			catch
			{
			}
			try
			{
				View_PreMatch_CharSelect lastPrematchCharSelectView = _lastPrematchCharSelectView;
				CharacterConfiguration val = FindMedusaConfig();
				if ((Object)lastPrematchCharSelectView != (Object)null && val != null)
				{
					lastPrematchCharSelectView.SetDisplayedCharacter(val, true);
				}
			}
			catch (Exception ex)
			{
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Warn("[Medusa] prematch Medusa display update failed: " + ex.Message);
				}
			}
			TrySubmitMedusaSelection("PrematchMedusaIcon.click", lockAfter: false);
			ScheduleMedusaSelection("PrematchMedusaIcon.click", lockAfter: false);
			if (_matchSelectLogCount < 48)
			{
				_matchSelectLogCount++;
				MedusaMod instance2 = _instance;
				if (instance2 != null)
				{
					((ModBase)instance2).Log.Info($"[Medusa] prematch Medusa icon clicked; submitted charId={CurrentMedusaId()} autoEnabled={AutoSelectMedusaEnabled()}.");
				}
			}
		}
		catch (Exception ex2)
		{
			MedusaMod instance3 = _instance;
			if (instance3 != null)
			{
				((ModBase)instance3).Log.Warn("[Medusa] prematch Medusa icon click failed: " + ex2.Message);
			}
		}
	}

	private Il2CppReferenceArray<CharacterConfiguration> AppendLobby(UICharactersConfiguration cfg, CharacterConfiguration item)
	{
		try
		{
			return Append(cfg._lobbyCharacters, item);
		}
		catch
		{
			return cfg._lobbyCharacters;
		}
	}

	private static int SafeLen(Il2CppReferenceArray<CharacterConfiguration> a)
	{
		try
		{
			return ((Il2CppArrayBase<CharacterConfiguration>)(object)a)?.Length ?? 0;
		}
		catch
		{
			return -1;
		}
	}

	private void MakeRosterAvailable(UICharactersConfiguration cfg)
	{
		try
		{
			Il2CppReferenceArray<CharacterConfiguration> characters = cfg.Characters;
			int num = ((Il2CppArrayBase<CharacterConfiguration>)(object)characters)?.Length ?? 0;
			if (num != 0)
			{
				Il2CppStructArray<int> val = new Il2CppStructArray<int>((long)num);
				for (int i = 0; i < num; i++)
				{
					((Il2CppArrayBase<int>)(object)val)[i] = ((((Il2CppArrayBase<CharacterConfiguration>)(object)characters)[i] != null) ? ((Il2CppArrayBase<CharacterConfiguration>)(object)characters)[i].charId : 0);
				}
				cfg.UpdateAvailableCharacterList(val);
				((ModBase)this).Log.Info($"[Medusa] made {num} characters available in lobby (incl. Medusa).");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] MakeRosterAvailable: " + ex.Message);
		}
	}

	private static UICharactersConfiguration? FindCharConfig()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		try
		{
			UIManager manager = UIAPI.Manager;
			if ((Object)manager != (Object)null && (Object)manager.characterConfig != (Object)null)
			{
				_cachedCharConfig = manager.characterConfig;
				return _cachedCharConfig;
			}
		}
		catch
		{
		}
		try
		{
			if ((Object)_cachedCharConfig != (Object)null)
			{
				return _cachedCharConfig;
			}
		}
		catch
		{
			_cachedCharConfig = null;
		}
		float realtimeSinceStartup = Time.realtimeSinceStartup;
		if (realtimeSinceStartup < _nextCharConfigScanAt)
		{
			return null;
		}
		_nextCharConfigScanAt = realtimeSinceStartup + 1.5f;
		try
		{
			Il2CppArrayBase<UICharactersConfiguration> val = Resources.FindObjectsOfTypeAll<UICharactersConfiguration>();
			if (val != null && val.Length > 0)
			{
				_cachedCharConfig = val[0];
				return _cachedCharConfig;
			}
		}
		catch
		{
		}
		try
		{
			Il2CppArrayBase<UIManager> val2 = Resources.FindObjectsOfTypeAll<UIManager>();
			if (val2 != null)
			{
				for (int i = 0; i < val2.Length; i++)
				{
					UICharactersConfiguration val3 = (((Object)val2[i] != (Object)null) ? val2[i].characterConfig : null);
					if ((Object)val3 != (Object)null)
					{
						_cachedCharConfig = val3;
						return _cachedCharConfig;
					}
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static CharacterConfiguration? FindMedusaConfig()
	{
		try
		{
			UICharactersConfiguration val = FindCharConfig();
			Il2CppReferenceArray<CharacterConfiguration> val2 = (((Object)(object)val != (Object)null) ? val.Characters : null);
			if (val2 == null)
			{
				return null;
			}
			for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val2).Length; i++)
			{
				CharacterConfiguration val3 = ((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[i];
				if (val3 != null && (val3.name == "Medusa" || IsMedusaId(val3.charId)))
				{
					return val3;
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static void RememberExplicitMedusaSelection(string source)
	{
		if (!_localMedusaExplicitlySelected)
		{
			_localMedusaExplicitlySelected = true;
			MedusaMod instance = _instance;
			if (instance != null && _matchSelectLogCount < 48)
			{
				_matchSelectLogCount++;
				((ModBase)instance).Log.Info("[Medusa] explicit local Medusa selection remembered via " + source + ".");
			}
		}
	}

	private static bool LaunchRequestedMedusa()
	{
		if (_launchRequestedMedusaChecked)
		{
			return _launchRequestedMedusa;
		}
		_launchRequestedMedusaChecked = true;
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("BAPBAP_MEDUSA_SELECTED");
			if (!string.IsNullOrWhiteSpace(environmentVariable) && (environmentVariable == "1" || environmentVariable.Equals("true", StringComparison.OrdinalIgnoreCase) || environmentVariable.Equals("yes", StringComparison.OrdinalIgnoreCase) || environmentVariable == "15"))
			{
				_launchRequestedMedusa = true;
			}
		}
		catch
		{
		}
		try
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				string text = commandLineArgs[i] ?? string.Empty;
				if (text.Equals("--bapcustom-medusa-selected", StringComparison.OrdinalIgnoreCase))
				{
					_launchRequestedMedusa = true;
					break;
				}
				if (text.StartsWith("--bapcustom-selected-char=", StringComparison.OrdinalIgnoreCase) && IsMedusaId(ParseIntOr(text.Substring("--bapcustom-selected-char=".Length), -1)))
				{
					_launchRequestedMedusa = true;
					break;
				}
				if (text.StartsWith("--bapcustom-character-id=", StringComparison.OrdinalIgnoreCase) && IsMedusaId(ParseIntOr(text.Substring("--bapcustom-character-id=".Length), -1)))
				{
					_launchRequestedMedusa = true;
					break;
				}
			}
		}
		catch
		{
		}
		return _launchRequestedMedusa;
	}

	private static int ParseIntOr(string value, int fallback)
	{
		try
		{
			if (int.TryParse(value, out var result))
			{
				return result;
			}
		}
		catch
		{
		}
		return fallback;
	}

	private static bool AutoSelectMedusaEnabled()
	{
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT");
			if (!string.IsNullOrWhiteSpace(environmentVariable) && (environmentVariable == "1" || environmentVariable.Equals("true", StringComparison.OrdinalIgnoreCase) || environmentVariable.Equals("yes", StringComparison.OrdinalIgnoreCase)))
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(Path.Combine("UserData", "Medusa", "auto-select.txt")))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	private bool AutoSelectAugmentEnabled()
	{
		if (_autoSelectAugmentEnabledChecked)
		{
			return _autoSelectAugmentEnabled;
		}
		_autoSelectAugmentEnabledChecked = true;
		try
		{
			string text = Environment.GetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT_AUGMENT") ?? Environment.GetEnvironmentVariable("BAPBAP_AUTOSELECT_AUGMENT");
			if (!string.IsNullOrWhiteSpace(text) && (text == "1" || text.Equals("true", StringComparison.OrdinalIgnoreCase) || text.Equals("yes", StringComparison.OrdinalIgnoreCase)))
			{
				_autoSelectAugmentEnabled = true;
			}
		}
		catch
		{
		}
		try
		{
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			for (int i = 0; i < commandLineArgs.Length; i++)
			{
				string text2 = commandLineArgs[i] ?? string.Empty;
				if (text2.Equals("--bapcustom-auto-select-augment", StringComparison.OrdinalIgnoreCase) || text2.Equals("--bapcustom-auto-select-augments", StringComparison.OrdinalIgnoreCase))
				{
					_autoSelectAugmentEnabled = true;
					break;
				}
			}
		}
		catch
		{
		}
		if (_autoSelectAugmentEnabled)
		{
			((ModBase)this).Log.Info("[Medusa] AugmentFix typed auto-select enabled for this test client.");
		}
		return _autoSelectAugmentEnabled;
	}

	private void TryAutoSelectOpenAugment(string source)
	{
		_autoAugmentScanCount++;
		bool flag = _autoAugmentSelectCount == 0 && (_autoAugmentScanCount <= 8 || _autoAugmentScanCount % 80 == 0);
		if (!TryAutoSelectViaPlayerAugments(source, flag) && !TryAutoSelectViaUiManagers(source, flag) && !TryAutoSelectViaUiAugmentsScan(source, flag) && flag)
		{
			((ModBase)this).Log.Info($"[Medusa] AugmentFix no selectable augment UI yet via {source} scan={_autoAugmentScanCount}.");
		}
	}

	private bool TryAutoSelectViaPlayerAugments(string source, bool verbose)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		try
		{
			PlayerManager local = PlayerAPI.Local;
			if ((Object)local != (Object)null && TryAutoSelectPlayerAugments(local.playerAugments, source + ".PlayerAPI.Local", verbose))
			{
				return true;
			}
		}
		catch (Exception ex)
		{
			if (verbose)
			{
				((ModBase)this).Log.Warn("[Medusa] AugmentFix PlayerAPI.Local failed: " + ex.Message);
			}
		}
		try
		{
			Il2CppArrayBase<PlayerAugments> val = Object.FindObjectsOfType<PlayerAugments>();
			if (val == null || val.Length == 0)
			{
				return false;
			}
			PlayerAugments val2 = null;
			for (int i = 0; i < val.Length; i++)
			{
				PlayerAugments val3 = val[i];
				if (!((Object)val3 == (Object)null))
				{
					if (val2 == null)
					{
						val2 = val3;
					}
					NetworkBehaviour val4 = (NetworkBehaviour)val3;
					bool flag = false;
					try
					{
						flag = val4.isLocalPlayer || val4.isOwned;
					}
					catch
					{
					}
					if (flag)
					{
						return TryAutoSelectPlayerAugments(val3, source + ".owned PlayerAugments", verbose);
					}
				}
			}
			if (val.Length == 1)
			{
				return TryAutoSelectPlayerAugments(val2, source + ".single PlayerAugments", verbose);
			}
		}
		catch (Exception ex2)
		{
			if (verbose)
			{
				((ModBase)this).Log.Warn("[Medusa] AugmentFix PlayerAugments scan failed: " + ex2.Message);
			}
		}
		return false;
	}

	private bool TryAutoSelectPlayerAugments(PlayerAugments? playerAugments, string source, bool verbose)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		if ((Object)playerAugments == (Object)null)
		{
			return false;
		}
		try
		{
			if (TryAutoSelectUiAugments(playerAugments.uiAugments, source + ".uiAugments", verbose))
			{
				return true;
			}
			AugmentSelection currentSelection = playerAugments.CurrentSelection;
			if (currentSelection == null && playerAugments.currentSelection != null)
			{
				currentSelection = playerAugments.currentSelection;
			}
			if (currentSelection == null)
			{
				return false;
			}
			int instanceID = ((Object)playerAugments).GetInstanceID();
			if (_autoSelectedAugmentUiIds.Contains(instanceID))
			{
				return false;
			}
			playerAugments.CmdSelectAugment(0);
			_autoSelectedAugmentUiIds.Add(instanceID);
			_autoAugmentSelectCount++;
			((ModBase)this).Log.Info($"[Medusa] AugmentFix auto-selected first augment via {source}.CmdSelectAugment(0), total={_autoAugmentSelectCount}.");
			return true;
		}
		catch (Exception ex)
		{
			if (verbose)
			{
				((ModBase)this).Log.Warn("[Medusa] AugmentFix PlayerAugments select failed via " + source + ": " + ex.Message);
			}
			return false;
		}
	}

	private bool TryAutoSelectViaUiManagers(string source, bool verbose)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		try
		{
			Il2CppArrayBase<UIManager> val = Resources.FindObjectsOfTypeAll<UIManager>();
			if (val == null || val.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < val.Length; i++)
			{
				UIManager val2 = val[i];
				if (!((Object)val2 == (Object)null) && TryAutoSelectUiAugments(val2.uiAugments, source + ".UIManager.uiAugments", verbose))
				{
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			if (verbose)
			{
				((ModBase)this).Log.Warn("[Medusa] AugmentFix UIManager scan failed: " + ex.Message);
			}
		}
		return false;
	}

	private bool TryAutoSelectViaUiAugmentsScan(string source, bool verbose)
	{
		try
		{
			Il2CppArrayBase<UIAugments> val = Resources.FindObjectsOfTypeAll<UIAugments>();
			if (val == null || val.Length == 0)
			{
				try
				{
					val = Object.FindObjectsOfType<UIAugments>(true);
				}
				catch
				{
				}
			}
			if (val == null || val.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < val.Length; i++)
			{
				if (TryAutoSelectUiAugments(val[i], source + ".UIAugments scan", verbose))
				{
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			if (verbose)
			{
				((ModBase)this).Log.Warn("[Medusa] AugmentFix UIAugments scan failed: " + ex.Message);
			}
		}
		return false;
	}

	private bool TryAutoSelectUiAugments(UIAugments? uiAugments, string source, bool verbose)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Expected O, but got Unknown
		if ((Object)uiAugments == (Object)null)
		{
			return false;
		}
		try
		{
			int instanceID = ((Object)uiAugments).GetInstanceID();
			if (_autoSelectedAugmentUiIds.Contains(instanceID))
			{
				return false;
			}
			if (!IsAugmentUiVisible(uiAugments))
			{
				return false;
			}
			try
			{
				uiAugments.ClSelectAugment(0);
				_autoSelectedAugmentUiIds.Add(instanceID);
				_autoAugmentSelectCount++;
				((ModBase)this).Log.Info($"[Medusa] AugmentFix auto-selected first augment via {source}.ClSelectAugment(0), total={_autoAugmentSelectCount}.");
				return true;
			}
			catch (Exception ex)
			{
				if (verbose)
				{
					((ModBase)this).Log.Warn("[Medusa] AugmentFix ClSelectAugment failed via " + source + ": " + ex.Message);
				}
			}
			Il2CppReferenceArray<UIAugmentElement> augmentElements = uiAugments.augmentElements;
			if (augmentElements != null && ((Il2CppArrayBase<UIAugmentElement>)(object)augmentElements).Length > 0)
			{
				UIAugmentElement val = ((Il2CppArrayBase<UIAugmentElement>)(object)augmentElements)[0];
				if ((Object)val != (Object)null)
				{
					val.SelectedAugment();
					_autoSelectedAugmentUiIds.Add(instanceID);
					_autoAugmentSelectCount++;
					((ModBase)this).Log.Info($"[Medusa] AugmentFix auto-selected first augment via {source}.augmentElements[0].SelectedAugment(), total={_autoAugmentSelectCount}.");
					return true;
				}
			}
		}
		catch (Exception ex2)
		{
			if (verbose)
			{
				((ModBase)this).Log.Warn("[Medusa] AugmentFix UI select failed via " + source + ": " + ex2.Message);
			}
		}
		return false;
	}

	private static bool IsAugmentUiVisible(UIAugments uiAugments)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		try
		{
			if (uiAugments._showingAugments || uiAugments.augmentsEnabled)
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			GameObject augmentSelectHolder = uiAugments.augmentSelectHolder;
			if ((Object)augmentSelectHolder != (Object)null && augmentSelectHolder.activeInHierarchy)
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			CanvasGroup augmentsCanvasGroup = uiAugments.augmentsCanvasGroup;
			if ((Object)augmentsCanvasGroup != (Object)null && ((Component)augmentsCanvasGroup).gameObject.activeInHierarchy && augmentsCanvasGroup.alpha > 0.01f)
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	private void TrySendLobbySwitchCharacter(int charId, string source)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		try
		{
			if (!IsMedusaId(charId) || _lobbySwitchSendCount >= 4)
			{
				return;
			}
			float num;
			try
			{
				num = Time.unscaledTime;
			}
			catch
			{
				num = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
			}
			if (num - _lastLobbySwitchAt < 3f)
			{
				return;
			}
			_lastLobbySwitchAt = num;
			int num2 = 0;
			Il2CppArrayBase<LobbyNetworkClient> val = Resources.FindObjectsOfTypeAll<LobbyNetworkClient>();
			if (val != null)
			{
				for (int i = 0; i < val.Length; i++)
				{
					try
					{
						LobbyNetworkClient val2 = val[i];
						object obj2;
						if ((Object)(object)val2 == (Object)null)
						{
							obj2 = null;
						}
						else
						{
							ControllerManager controller = val2._controller;
							obj2 = ((controller != null) ? controller.CharSelect : null);
						}
						CharSelectController val3 = (CharSelectController)obj2;
						if (val3 != null)
						{
							val3.SwitchCharacter(charId);
							num2++;
						}
					}
					catch
					{
					}
				}
			}
			if (num2 > 0 && _lobbySwitchLogCount < 8)
			{
				_lobbySwitchSendCount += num2;
				_lobbySwitchLogCount++;
				((ModBase)this).Log.Info($"[Medusa] lobby SWITCH_CHAR bridge via {source}: charId={charId} sent={num2} total={_lobbySwitchSendCount}.");
			}
		}
		catch (Exception ex)
		{
			if (_lobbySwitchLogCount < 8)
			{
				_lobbySwitchLogCount++;
				((ModBase)this).Log.Warn("[Medusa] lobby SWITCH_CHAR bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void EnsureRegisteredForUiManager(UIManager __instance, string source)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		try
		{
			MedusaMod instance = _instance;
			if (instance == null || instance._registered)
			{
				return;
			}
			UICharactersConfiguration val = (((Object)__instance != (Object)null) ? __instance.characterConfig : null);
			if ((Object)val == (Object)null)
			{
				val = FindCharConfig();
			}
			if (!((Object)val == (Object)null))
			{
				instance.TryRegisterMedusa(val);
				if (instance._registered && _uiWarmupLogCount < 4)
				{
					_uiWarmupLogCount++;
					((ModBase)instance).Log.Info($"[Medusa] UIManager early registration via {source}: charId={instance.MedusaCharId} roster={SafeLen(val.Characters)}.");
				}
			}
		}
		catch (Exception ex)
		{
			if (_instance != null)
			{
				((ModBase)_instance).Log.Warn("[Medusa] UIManager early registration failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void EnsureRegisteredForUi(string source)
	{
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		try
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				bool registered = instance._registered;
				instance.EnsureMedusaPrefabRegistered((CurrentMedusaId() >= 0) ? CurrentMedusaId() : 0, source + ".prefab");
				instance.TryRegisterMedusa();
				UICharactersConfiguration val = FindCharConfig();
				if ((Object)val != (Object)null)
				{
					instance.MakeRosterAvailable(val);
				}
				if (_uiWarmupLogCount < 4 && (!registered || instance._registered))
				{
					_uiWarmupLogCount++;
					((ModBase)instance).Log.Info($"[Medusa] UI warmup before {source}: registered={instance._registered} charId={instance.MedusaCharId}.");
				}
			}
		}
		catch (Exception ex)
		{
			if (_instance != null)
			{
				((ModBase)_instance).Log.Warn("[Medusa] UI warmup failed before " + source + ": " + ex.Message);
			}
		}
	}

	private static bool IsMedusaId(int charId)
	{
		if (charId == 15)
		{
			return true;
		}
		int num = _instance?.MedusaCharId ?? (-1);
		if (num >= 0)
		{
			return charId == num;
		}
		return false;
	}

	private static bool LooksLikeMedusaEntity(EntityManager? entity)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		if ((Object)entity == (Object)null)
		{
			return false;
		}
		if (IsMedusaId(SafeIntValue(() => entity.charId)))
		{
			return true;
		}
		try
		{
			return ObjectRootNameLooksLikeMedusa(((Object)((Component)entity).gameObject).name);
		}
		catch
		{
			return false;
		}
	}

	private static bool LooksLikeMedusaObject(GameObject? gameObject)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		if ((Object)gameObject == (Object)null)
		{
			return false;
		}
		try
		{
			if (ObjectRootNameLooksLikeMedusa(((Object)gameObject).name ?? ""))
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			foreach (SkinnedMeshRenderer componentsInChild in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					string text = ((Object)componentsInChild).name ?? "";
					if (text.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						return true;
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			foreach (Transform componentsInChild2 in gameObject.GetComponentsInChildren<Transform>(true))
			{
				if (!((Object)componentsInChild2 == (Object)null))
				{
					string text2 = ((Object)componentsInChild2).name ?? "";
					if (text2.IndexOf("Medusa_Visual", StringComparison.OrdinalIgnoreCase) >= 0 || text2.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						return true;
					}
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static bool HasMedusaVisualUnder(GameObject? gameObject)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Expected O, but got Unknown
		if ((Object)gameObject == (Object)null)
		{
			return false;
		}
		try
		{
			foreach (SkinnedMeshRenderer componentsInChild in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if (!((Object)componentsInChild == (Object)null))
				{
					string text = ((Object)componentsInChild).name ?? "";
					if (text.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						return true;
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			foreach (Transform componentsInChild2 in gameObject.GetComponentsInChildren<Transform>(true))
			{
				if (!((Object)componentsInChild2 == (Object)null))
				{
					string text2 = ((Object)componentsInChild2).name ?? "";
					if (text2.IndexOf("Medusa_Visual", StringComparison.OrdinalIgnoreCase) >= 0 || text2.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						return true;
					}
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static bool ObjectRootNameLooksLikeMedusa(string? name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return false;
		}
		string text = name.Trim();
		if (text.Equals("Medusa", StringComparison.OrdinalIgnoreCase) || text.Equals("Medusa(Clone)", StringComparison.OrdinalIgnoreCase) || text.Equals("Char_Medusa", StringComparison.OrdinalIgnoreCase) || text.Equals("Char_Medusa(Clone)", StringComparison.OrdinalIgnoreCase) || text.Equals("Medusa_Visual", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (text.IndexOf("Char_Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		int num = text.LastIndexOf(']');
		if (num >= 0 && num + 1 < text.Length)
		{
			string text2 = text.Substring(num + 1).Trim();
			if (!text2.Equals("Medusa", StringComparison.OrdinalIgnoreCase))
			{
				return text2.Equals("Medusa(Clone)", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	private static int CurrentMedusaId()
	{
		int num = _instance?.MedusaCharId ?? (-1);
		if (num < 0)
		{
			return 15;
		}
		return num;
	}

	private static int[] CurrentCharacterIds()
	{
		try
		{
			UICharactersConfiguration val = FindCharConfig();
			Il2CppReferenceArray<CharacterConfiguration> val2 = (((Object)(object)val != (Object)null) ? val.Characters : null);
			if (val2 != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)val2).Length > 0)
			{
				List<int> list = new List<int>();
				for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val2).Length; i++)
				{
					int num = ((((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[i] != null) ? ((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[i].charId : (-1));
					if (num >= 0 && !list.Contains(num))
					{
						list.Add(num);
					}
				}
				if (list.Count > 0)
				{
					return list.ToArray();
				}
			}
		}
		catch
		{
		}
		int[] array = new int[16];
		for (int j = 0; j < array.Length; j++)
		{
			array[j] = j;
		}
		return array;
	}

	private static void NormalizeQueueMatchedMedusaSelections(QueueMatchedData? qmd, string source)
	{
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		try
		{
			if (qmd == null || qmd.players == null)
			{
				return;
			}
			List<MatchmakingPlayerData> players = qmd.players;
			int count = players.Count;
			PlayerManager local = null;
			try
			{
				local = PlayerAPI.Local;
			}
			catch
			{
			}
			int num = SafeIntValue(() => local.playerId);
			string localAccountId = string.Empty;
			try
			{
				PlayerManager obj2 = local;
				localAccountId = ((obj2 != null) ? obj2.accountId : null) ?? string.Empty;
			}
			catch
			{
			}
			bool flag = LaunchRequestedMedusa();
			bool flag2 = AutoSelectMedusaEnabled();
			bool localMedusaExplicitlySelected = _localMedusaExplicitlySelected;
			bool flag3 = flag || flag2;
			int num2 = 0;
			int num3 = 0;
			for (int num4 = 0; num4 < count; num4++)
			{
				MatchmakingPlayerData playerData = players[num4];
				if (playerData == null)
				{
					continue;
				}
				bool flag4 = PlayerDataMatchesLocal(playerData, num, localAccountId) || (count == 1 && flag3);
				if (!IsMedusaId(SafeIntValue(() => playerData.charId)) && !(flag3 && flag4))
				{
					continue;
				}
				int value = SafeIntValue(() => playerData.charId);
				int value2 = SafeIntValue(() => playerData.skinAssetId);
				try
				{
					playerData.charId = CurrentMedusaId();
				}
				catch
				{
				}
				try
				{
					playerData.skinAssetId = -1;
				}
				catch
				{
				}
				int num5 = SafeIntValue(() => playerData.playerId);
				if (num5 > 0)
				{
					num3 += SetPreMatchSelectionForPlayerId(num5, CurrentMedusaId(), source + ".qmd");
				}
				if (flag4)
				{
					RememberExplicitMedusaSelection(source + ".qmd.local");
					if ((Object)local != (Object)null)
					{
						ForcePlayerMedusaChar(local, CurrentMedusaId(), source + ".qmd.local");
					}
				}
				num2++;
				if (_matchSelectLogCount >= 48)
				{
					continue;
				}
				_matchSelectLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] qmd Medusa normalized via {source}: playerId={num5} account={SafeString(() => playerData.accountId)} localMatch={flag4} old={value} new={CurrentMedusaId()} skin={value2}->-1.");
				}
			}
			if ((num2 > 0 || num3 > 0) && _matchSelectLogCount < 48)
			{
				_matchSelectLogCount++;
				MedusaMod instance2 = _instance;
				if (instance2 != null)
				{
					((ModBase)instance2).Log.Info($"[Medusa] qmd Medusa selection summary via {source}: forcedPlayers={num2} prematchSelections={num3} explicitLocal={flag3} launch={flag} autoSelect={flag2} remembered={localMedusaExplicitlySelected} localPlayerId={num}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance3 = _instance;
			if (instance3 != null)
			{
				((ModBase)instance3).Log.Warn("[Medusa] qmd Medusa normalization failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static bool PlayerDataMatchesLocal(MatchmakingPlayerData playerData, int localPlayerId, string localAccountId)
	{
		try
		{
			if (localPlayerId > 0 && playerData.playerId == localPlayerId)
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			if (!string.IsNullOrWhiteSpace(localAccountId) && string.Equals(playerData.accountId ?? string.Empty, localAccountId, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	private static int SetPreMatchSelectionForPlayerId(int playerId, int charId, string source)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Expected O, but got Unknown
		if (playerId <= 0 || !IsMedusaId(charId))
		{
			return 0;
		}
		int num = 0;
		try
		{
			Il2CppArrayBase<PreMatchManager> val = Object.FindObjectsOfType<PreMatchManager>();
			if (val == null)
			{
				return 0;
			}
			foreach (PreMatchManager item in val)
			{
				if ((Object)item == (Object)null || item._currentSelectedCharacters == null)
				{
					continue;
				}
				Dictionary<int, int> currentSelectedCharacters = item._currentSelectedCharacters;
				bool flag = false;
				int value = -1;
				try
				{
					flag = currentSelectedCharacters.ContainsKey(playerId);
				}
				catch
				{
				}
				if (flag)
				{
					try
					{
						value = currentSelectedCharacters[playerId];
					}
					catch
					{
					}
					try
					{
						currentSelectedCharacters[playerId] = charId;
						num++;
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						currentSelectedCharacters.Add(playerId, charId);
						num++;
					}
					catch
					{
					}
				}
				if (_matchSelectLogCount < 48)
				{
					_matchSelectLogCount++;
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] prematch selected char via {source}: playerId={playerId} old={value} new={charId} existed={flag}.");
					}
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] SetPreMatchSelectionForPlayerId failed via " + source + ": " + ex.Message);
			}
		}
		return num;
	}

	private static void ForceQueueMatchedDataAvailable(QueueMatchedData? qmd, string source)
	{
		try
		{
			if (qmd == null)
			{
				return;
			}
			EnsureRegisteredForUi(source);
			int[] array = CurrentCharacterIds();
			Il2CppStructArray<int> val = new Il2CppStructArray<int>((long)array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				((Il2CppArrayBase<int>)(object)val)[i] = array[i];
			}
			qmd.availableCharacters = val;
			NormalizeQueueMatchedMedusaSelections(qmd, source);
			if (_matchSelectLogCount >= 4)
			{
				return;
			}
			_matchSelectLogCount++;
			List<string> list = new List<string>();
			try
			{
				List<MatchmakingPlayerData> players = qmd.players;
				if (players != null)
				{
					for (int j = 0; j < players.Count; j++)
					{
						MatchmakingPlayerData val2 = players[j];
						if (val2 != null)
						{
							list.Add($"{val2.accountId}:{val2.charId}");
						}
					}
				}
			}
			catch
			{
			}
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] prematch qmd via {source}: available={string.Join(",", array)} players=[{string.Join(", ", list)}].");
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] prematch qmd bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void TrySubmitMedusaSelection(string source, bool lockAfter)
	{
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Expected O, but got Unknown
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
		//IL_0381: Expected O, but got Unknown
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039c: Expected O, but got Unknown
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		try
		{
			MedusaMod instance = _instance;
			if (instance == null)
			{
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			if ((utcNow - _lastPrematchSubmitUtc).TotalMilliseconds < 250.0)
			{
				return;
			}
			_lastPrematchSubmitUtc = utcNow;
			EnsureRegisteredForUi(source);
			int num = CurrentMedusaId();
			Il2CppArrayBase<PlayerPreMatch> val = Object.FindObjectsOfType<PlayerPreMatch>();
			int num2 = 0;
			int value = val?.Length ?? 0;
			try
			{
				PlayerManager localPlayer = PlayerAPI.Local;
				PlayerPreMatch localPreMatch = (((Object)localPlayer != (Object)null) ? localPlayer.playerPreMatch : null);
				if ((Object)localPlayer != (Object)null)
				{
					ForcePlayerMedusaChar(localPlayer, num, source + ".localPreSubmit");
					if ((Object)localPreMatch != (Object)null)
					{
						localPreMatch.CmdTrySelectCharacter(localPlayer, num);
						num2++;
						if (lockAfter)
						{
							TimerAPI.Once(0.35f, (Action)delegate
							{
								try
								{
									localPreMatch.CmdTryLockCharacter(localPlayer);
								}
								catch (Exception ex6)
								{
									MedusaMod instance3 = _instance;
									if (instance3 != null)
									{
										((ModBase)instance3).Log.Warn("[Medusa] local CmdTryLockCharacter failed via " + source + ": " + ex6.Message);
									}
								}
							}, (ModBase)instance);
						}
					}
				}
			}
			catch (Exception ex)
			{
				((ModBase)instance).Log.Warn("[Medusa] local prematch submit failed via " + source + ": " + ex.Message);
			}
			try
			{
				MirrorCmdRegistry.Cmd_PlayerPreMatch_CmdTrySelectCharacter(num);
				num2++;
				if (lockAfter)
				{
					TimerAPI.Once(0.45f, (Action)delegate
					{
						MirrorCmdRegistry.Cmd_PlayerPreMatch_CmdTryLockCharacter();
					}, (ModBase)instance);
				}
			}
			catch (Exception ex2)
			{
				((ModBase)instance).Log.Warn("[Medusa] MirrorCmdRegistry prematch submit failed via " + source + ": " + ex2.Message);
			}
			if (val != null)
			{
				foreach (PlayerPreMatch item in val)
				{
					if ((Object)item == (Object)null)
					{
						continue;
					}
					bool flag = false;
					try
					{
						flag = ((NetworkBehaviour)item).isLocalPlayer;
					}
					catch
					{
					}
					try
					{
						flag = flag || ((Object)item._playerManager != (Object)null && ((NetworkBehaviour)item._playerManager).isLocalPlayer);
					}
					catch
					{
					}
					if (!flag && val.Length > 1)
					{
						continue;
					}
					PlayerManager playerManager = item._playerManager;
					if ((Object)playerManager == (Object)null)
					{
						continue;
					}
					try
					{
						item.CmdTrySelectCharacter(playerManager, num);
						num2++;
					}
					catch (Exception ex3)
					{
						((ModBase)instance).Log.Warn($"[Medusa] CmdTrySelectCharacter({num}) failed via {source}: {ex3.Message}");
					}
					if (!lockAfter)
					{
						continue;
					}
					PlayerPreMatch captured = item;
					PlayerManager capturedPlayer = playerManager;
					TimerAPI.Once(0.35f, (Action)delegate
					{
						try
						{
							captured.CmdTryLockCharacter(capturedPlayer);
						}
						catch (Exception ex6)
						{
							MedusaMod instance3 = _instance;
							if (instance3 != null)
							{
								((ModBase)instance3).Log.Warn("[Medusa] CmdTryLockCharacter failed via " + source + ": " + ex6.Message);
							}
						}
					}, (ModBase)instance);
				}
				if (num2 == 0)
				{
					foreach (PlayerPreMatch item2 in val)
					{
						if ((Object)item2 == (Object)null)
						{
							continue;
						}
						PlayerManager playerManager2 = item2._playerManager;
						if (!((Object)playerManager2 == (Object)null))
						{
							try
							{
								item2.CmdTrySelectCharacter(playerManager2, num);
								num2++;
							}
							catch (Exception ex4)
							{
								((ModBase)instance).Log.Warn($"[Medusa] fallback CmdTrySelectCharacter({num}) failed via {source}: {ex4.Message}");
							}
							break;
						}
					}
				}
			}
			if (_prematchSubmitLogCount < 8)
			{
				_prematchSubmitLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] prematch submit via {source}: charId={num} playerPreMatchSeen={value} attempts={num2} lockAfter={lockAfter} autoEnabled={AutoSelectMedusaEnabled()}.");
			}
		}
		catch (Exception ex5)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] prematch submit failed via " + source + ": " + ex5.Message);
			}
		}
	}

	private static void ScheduleMedusaSelection(string source, bool lockAfter)
	{
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Expected O, but got Unknown
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Expected O, but got Unknown
		try
		{
			MedusaMod instance = _instance;
			if (instance == null)
			{
				return;
			}
			DateTime utcNow = DateTime.UtcNow;
			if (!((utcNow - _lastPrematchScheduleUtc).TotalMilliseconds < 500.0))
			{
				_lastPrematchScheduleUtc = utcNow;
				TrySubmitMedusaSelection(source + "+now", lockAfter);
				TimerAPI.Once(0.35f, (Action)delegate
				{
					TrySubmitMedusaSelection(source + "+0.35s", lockAfter);
				}, (ModBase)instance);
				TimerAPI.Once(1f, (Action)delegate
				{
					TrySubmitMedusaSelection(source + "+1.00s", lockAfter);
				}, (ModBase)instance);
				TimerAPI.Once(2.5f, (Action)delegate
				{
					TrySubmitMedusaSelection(source + "+2.50s", lockAfter);
				}, (ModBase)instance);
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] ScheduleMedusaSelection failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void MaybeAutoSelectMedusa(string source)
	{
		if (AutoSelectMedusaEnabled())
		{
			ScheduleMedusaSelection(source + ".auto", lockAfter: true);
		}
	}

	private static void UpdatePreMatchSelectionState(PlayerManager? player, int charId, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		try
		{
			if ((Object)player == (Object)null || !IsMedusaId(charId))
			{
				return;
			}
			int num = -1;
			try
			{
				num = player.playerId;
			}
			catch
			{
			}
			if (num <= 0)
			{
				return;
			}
			Il2CppArrayBase<PreMatchManager> val = Object.FindObjectsOfType<PreMatchManager>();
			int num2 = 0;
			if (val == null)
			{
				return;
			}
			foreach (PreMatchManager item in val)
			{
				if ((Object)item == (Object)null)
				{
					continue;
				}
				Dictionary<int, int> currentSelectedCharacters = item._currentSelectedCharacters;
				if (currentSelectedCharacters == null)
				{
					continue;
				}
				int value = -1;
				bool flag = false;
				try
				{
					flag = currentSelectedCharacters.ContainsKey(num);
				}
				catch
				{
				}
				if (flag)
				{
					try
					{
						value = currentSelectedCharacters[num];
					}
					catch
					{
					}
					try
					{
						currentSelectedCharacters[num] = charId;
						num2++;
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						currentSelectedCharacters.Add(num, charId);
						num2++;
					}
					catch
					{
					}
				}
				if (_matchSelectLogCount < 36)
				{
					_matchSelectLogCount++;
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] prematch selection state via {source}: playerId={num} old={value} new={charId} existed={flag}.");
					}
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] UpdatePreMatchSelectionState failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static bool TryGetPreMatchSelectedChar(PlayerManager? player, out int charId)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Expected O, but got Unknown
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		charId = -1;
		try
		{
			if ((Object)player == (Object)null)
			{
				return false;
			}
			int playerId = player.playerId;
			if (playerId <= 0)
			{
				return false;
			}
			Il2CppArrayBase<PreMatchManager> val = Object.FindObjectsOfType<PreMatchManager>();
			if (val == null)
			{
				return false;
			}
			foreach (PreMatchManager item in val)
			{
				if ((Object)item == (Object)null)
				{
					continue;
				}
				Dictionary<int, int> currentSelectedCharacters = item._currentSelectedCharacters;
				if (currentSelectedCharacters == null)
				{
					continue;
				}
				bool flag = false;
				try
				{
					flag = currentSelectedCharacters.ContainsKey(playerId);
				}
				catch
				{
				}
				if (flag)
				{
					try
					{
						charId = currentSelectedCharacters[playerId];
						return true;
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static void UpdateMatchmakingPlayerDataForPlayer(PlayerManager? player, int charId, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		try
		{
			if ((Object)player == (Object)null || !IsMedusaId(charId))
			{
				return;
			}
			int num = -1;
			string text = string.Empty;
			try
			{
				num = player.playerId;
			}
			catch
			{
			}
			try
			{
				text = player.accountId ?? string.Empty;
			}
			catch
			{
			}
			Il2CppArrayBase<GameManager> val = Object.FindObjectsOfType<GameManager>();
			int num2 = 0;
			if (val == null)
			{
				return;
			}
			foreach (GameManager item in val)
			{
				if ((Object)item == (Object)null)
				{
					continue;
				}
				QueueMatchedData qmd = item.qmd;
				List<MatchmakingPlayerData> val2 = ((qmd != null) ? qmd.players : null);
				if (val2 == null)
				{
					continue;
				}
				for (int i = 0; i < val2.Count; i++)
				{
					MatchmakingPlayerData val3 = val2[i];
					if (val3 == null)
					{
						continue;
					}
					bool flag = false;
					try
					{
						flag = num > 0 && val3.playerId == num;
					}
					catch
					{
					}
					try
					{
						flag = flag || (!string.IsNullOrWhiteSpace(text) && string.Equals(val3.accountId ?? string.Empty, text, StringComparison.OrdinalIgnoreCase));
					}
					catch
					{
					}
					if (!flag)
					{
						continue;
					}
					int value = -1;
					try
					{
						value = val3.charId;
					}
					catch
					{
					}
					int value2 = -999;
					try
					{
						value2 = val3.skinAssetId;
					}
					catch
					{
					}
					try
					{
						val3.charId = charId;
						val3.skinAssetId = -1;
						num2++;
					}
					catch
					{
					}
					if (_matchSelectLogCount < 42)
					{
						_matchSelectLogCount++;
						MedusaMod instance = _instance;
						if (instance != null)
						{
							((ModBase)instance).Log.Info($"[Medusa] qmd player char via {source}: playerId={num} account={text} old={value} new={charId} skin={value2}->-1.");
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] UpdateMatchmakingPlayerData failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ForceSelectedMedusaPlayers(PreMatchManager? manager, string source)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		try
		{
			Il2CppArrayBase<PlayerManager> val = Object.FindObjectsOfType<PlayerManager>();
			if (val == null)
			{
				return;
			}
			foreach (PlayerManager player in val)
			{
				if ((Object)player == (Object)null)
				{
					continue;
				}
				int charId = -1;
				if ((Object)manager != (Object)null)
				{
					try
					{
						Dictionary<int, int> currentSelectedCharacters = manager._currentSelectedCharacters;
						int playerId = player.playerId;
						if (currentSelectedCharacters != null && playerId > 0 && currentSelectedCharacters.ContainsKey(playerId))
						{
							charId = currentSelectedCharacters[playerId];
						}
					}
					catch
					{
					}
				}
				if (IsMedusaId(charId) || IsMedusaId(SafeIntValue(() => player.charId)))
				{
					ForcePlayerMedusaChar(player, CurrentMedusaId(), source);
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] ForceSelectedMedusaPlayers failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ForcePlayerMedusaChar(PlayerManager? player, int charId, string source)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		try
		{
			if ((Object)player == (Object)null || !IsMedusaId(charId))
			{
				return;
			}
			int num = -1;
			try
			{
				num = player.charId;
			}
			catch
			{
			}
			int value = -999;
			try
			{
				value = player.skinAssetId;
			}
			catch
			{
			}
			UpdatePreMatchSelectionState(player, charId, source);
			UpdateMatchmakingPlayerDataForPlayer(player, charId, source);
			try
			{
				player.charId = charId;
			}
			catch
			{
			}
			try
			{
				player.skinAssetId = -1;
			}
			catch
			{
			}
			try
			{
				player.NetworkcharId = charId;
			}
			catch
			{
			}
			if (num != charId)
			{
				try
				{
					player.OnCharacterChanged(num, charId);
				}
				catch
				{
				}
			}
			try
			{
				EntityManager primaryCharManager = player.primaryCharManager;
				if ((Object)primaryCharManager != (Object)null)
				{
					primaryCharManager.charId = charId;
					try
					{
						primaryCharManager.NetworkcharId = charId;
					}
					catch
					{
					}
					EnsureLiveMedusaEntity(primaryCharManager, source + ".primaryChar");
				}
			}
			catch
			{
			}
			if (_matchSelectLogCount >= 24)
			{
				return;
			}
			_matchSelectLogCount++;
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] forced PlayerManager char via {source}: old={num} new={charId} skin={value}->-1 isServer={SafeBool(() => ((NetworkBehaviour)player).isServer)} isLocal={SafeBool(() => ((NetworkBehaviour)player).isLocalPlayer)}.");
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] ForcePlayerMedusaChar failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static string ObjName(Object? obj)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		try
		{
			return (obj == (Object)null) ? "<null>" : obj.name;
		}
		catch
		{
			return "?";
		}
	}

	private static string FmtVec(Vector3 v)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		return $"({v.x:0.###},{v.y:0.###},{v.z:0.###})";
	}

	private static string FmtPos(Component? component)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			return ((Object)component == (Object)null) ? "<null>" : FmtVec(component.transform.position);
		}
		catch
		{
			return "?";
		}
	}

	private static string ScreenPos(Component? component)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected O, but got Unknown
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)component == (Object)null)
			{
				return "<null>";
			}
			Camera main = Camera.main;
			if ((Object)main == (Object)null)
			{
				return "<no-main-camera>";
			}
			Vector3 val = main.WorldToScreenPoint(component.transform.position);
			return $"{val.x:0.0},{val.y:0.0},{val.z:0.0}";
		}
		catch
		{
			return "?";
		}
	}

	private static string CameraInfo()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Camera main = Camera.main;
			if ((Object)main == (Object)null)
			{
				return "<null>";
			}
			return $"{ObjName((Object?)(object)main)} pos={FmtVec(((Component)main).transform.position)} rot={FmtVec(((Component)main).transform.eulerAngles)} size={main.pixelWidth}x{main.pixelHeight}";
		}
		catch
		{
			return "?";
		}
	}

	private static string SafeBool(Func<bool> fn)
	{
		try
		{
			return fn() ? "true" : "false";
		}
		catch
		{
			return "?";
		}
	}

	private static ulong SafeULong(Func<ulong> fn)
	{
		try
		{
			return fn();
		}
		catch
		{
			return 0uL;
		}
	}

	private static int SafeIntValue(Func<int> fn)
	{
		try
		{
			return fn();
		}
		catch
		{
			return -1;
		}
	}

	private static void RepairLocalMedusaBinding(EntityManager? entity, string source, bool forceWhenLocalPrimaryMissing = false)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Expected O, but got Unknown
		//IL_0095: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0129: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015a: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_0178: Expected O, but got Unknown
		try
		{
			if ((Object)entity == (Object)null || !LooksLikeMedusaEntity(entity))
			{
				return;
			}
			PlayerManager local = PlayerAPI.Local;
			if ((Object)local == (Object)null || !IsMedusaId(SafeIntValue(() => local.charId)))
			{
				return;
			}
			EntityManager primaryCharManager = local.primaryCharManager;
			if ((Object)primaryCharManager == (Object)entity)
			{
				RepairMedusaCameraTarget(entity, source + ".alreadyPrimary");
				return;
			}
			GameObject gameObject = ((Component)entity).gameObject;
			GameObject gameObject2 = ((Component)local).gameObject;
			int num = ((!((Object)gameObject == (Object)null)) ? ((Object)gameObject).GetInstanceID() : 0);
			int num2 = SafeIntValue(() => local.playerId);
			int num3 = SafeIntValue(() => entity.ownerPlayerId);
			int num4 = SafeIntValue(() => entity.GetPlayerId());
			bool flag = (Object)primaryCharManager == (Object)null;
			bool num5 = num3 == num2 || num4 == num2;
			bool flag2 = (Object)entity.playerManager == (Object)local || (Object)entity.playerObj == (Object)gameObject2;
			bool flag3 = num3 <= 0 && num4 <= 0;
			bool flag4 = forceWhenLocalPrimaryMissing && flag && flag3;
			if (!num5 && !flag2 && !(flag && flag3) && !flag4)
			{
				if (_localBindingRepairLogCount < 16 && _localBindingRepairIds.Add(-num))
				{
					_localBindingRepairLogCount++;
					MedusaMod instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] local binding skipped via {source}: entity='{ObjName((Object?)(object)gameObject)}' owner={num3} getPlayerId={num4} localId={num2} localPrimary='{ObjName((Object?)(object)primaryCharManager)}' playerObj='{ObjName((Object?)(object)entity.playerObj)}' entityPlayer='{ObjName((Object?)(object)entity.playerManager)}' force={forceWhenLocalPrimaryMissing}.");
					}
				}
				return;
			}
			try
			{
				entity.charId = CurrentMedusaId();
			}
			catch
			{
			}
			try
			{
				entity.NetworkcharId = CurrentMedusaId();
			}
			catch
			{
			}
			try
			{
				entity.playerManager = local;
			}
			catch
			{
			}
			try
			{
				entity.playerObj = gameObject2;
			}
			catch
			{
			}
			try
			{
				entity.NetworkplayerObj = gameObject2;
			}
			catch
			{
			}
			try
			{
				entity.OnPlayerObjChanged((GameObject)null, gameObject2);
			}
			catch
			{
			}
			try
			{
				entity.ownerPlayerId = num2;
			}
			catch
			{
			}
			try
			{
				entity.isPrimary = true;
			}
			catch
			{
			}
			try
			{
				entity.NetworkisPrimary = true;
			}
			catch
			{
			}
			try
			{
				local.primaryCharManager = entity;
			}
			catch
			{
			}
			try
			{
				local.followTargetOverride = ((Component)entity).transform;
			}
			catch
			{
			}
			try
			{
				PlayerManager.LocalInstance = local;
			}
			catch
			{
			}
			try
			{
				local.AddCharObj(entity, true);
			}
			catch
			{
			}
			try
			{
				entity.ClStartAuth();
			}
			catch
			{
			}
			try
			{
				local.UpdateAOI(((Component)entity).transform);
			}
			catch
			{
			}
			RepairMedusaCameraTarget(entity, source);
			if (_localBindingRepairLogCount >= 24 || !_localBindingRepairIds.Add(num))
			{
				return;
			}
			_localBindingRepairLogCount++;
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				EntityManager primaryCharManager2 = local.primaryCharManager;
				EntityManager authViewCharacter = PlayerAPI.AuthViewCharacter;
				((ModBase)instance2).Log.Info($"[Medusa] local binding repaired via {source}: entity='{ObjName((Object?)(object)gameObject)}' owner {num3}->{SafeIntValue(() => entity.ownerPlayerId)} localId={num2} hadPrimary='{ObjName((Object?)(object)primaryCharManager)}' nowPrimary='{ObjName((Object?)(object)primaryCharManager2)}' auth='{ObjName((Object?)(object)authViewCharacter)}' pos={FmtPos((Component?)(object)entity)} screen={ScreenPos((Component?)(object)entity)} owned={SafeBool(() => ((NetworkBehaviour)entity).isOwned)} localPlayerOwned={SafeBool(() => ((NetworkBehaviour)local).isOwned)} force={forceWhenLocalPrimaryMissing} forceAllowed={flag4}.");
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance3 = _instance;
			if (instance3 != null && _localBindingRepairLogCount < 24)
			{
				_localBindingRepairLogCount++;
				((ModBase)instance3).Log.Warn("[Medusa] local binding repair failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void RepairMedusaCameraTarget(EntityManager? entity, string source)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected O, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_00e9: Expected O, but got Unknown
		try
		{
			if ((Object)entity == (Object)null || !LooksLikeMedusaEntity(entity))
			{
				return;
			}
			PlayerManager local = PlayerAPI.Local;
			if ((Object)local == (Object)null || !IsMedusaId(SafeIntValue(() => local.charId)))
			{
				return;
			}
			Transform transform = ((Component)entity).transform;
			if ((Object)transform == (Object)null)
			{
				return;
			}
			try
			{
				local.followTargetOverride = transform;
			}
			catch
			{
			}
			try
			{
				PlayerManager.LocalInstance = local;
			}
			catch
			{
			}
			int num = 0;
			int num2 = 0;
			Il2CppArrayBase<CameraController> val = null;
			try
			{
				val = Object.FindObjectsOfType<CameraController>();
			}
			catch
			{
			}
			if (val != null)
			{
				for (int num3 = 0; num3 < val.Length; num3++)
				{
					CameraController val2 = val[num3];
					if ((Object)val2 == (Object)null)
					{
						continue;
					}
					bool flag = false;
					try
					{
						flag = (Object)val2.Target == (Object)transform;
					}
					catch
					{
					}
					if (flag)
					{
						num2++;
						continue;
					}
					try
					{
						val2.SetTarget(transform);
						num++;
					}
					catch
					{
						goto IL_010d;
					}
					continue;
					IL_010d:
					try
					{
						val2._target = transform;
						num++;
					}
					catch
					{
					}
				}
			}
			GameObject gameObject = ((Component)entity).gameObject;
			int item = ((!((Object)gameObject == (Object)null)) ? ((Object)gameObject).GetInstanceID() : 0);
			if ((num > 0 || _cameraTargetRepairIds.Add(item)) && _cameraTargetRepairLogCount < 24)
			{
				_cameraTargetRepairLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					EntityManager authViewCharacter = PlayerAPI.AuthViewCharacter;
					((ModBase)instance).Log.Info($"[Medusa] camera target repair via {source}: entity='{ObjName((Object?)(object)entity)}' target='{ObjName((Object?)(object)transform)}' updated={num} already={num2} controllers={val?.Length ?? 0} localPrimary='{ObjName((Object?)(object)local.primaryCharManager)}' auth='{ObjName((Object?)(object)authViewCharacter)}' entityScreen={ScreenPos((Component?)(object)entity)} camera={CameraInfo()}.");
				}
			}
		}
		catch (Exception ex)
		{
			if (_cameraTargetRepairLogCount < 24)
			{
				_cameraTargetRepairLogCount++;
				MedusaMod instance2 = _instance;
				if (instance2 != null)
				{
					((ModBase)instance2).Log.Warn("[Medusa] camera target repair failed via " + source + ": " + ex.Message);
				}
			}
		}
	}

	private static void EnsureLiveMedusaEntity(EntityManager? entity, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		try
		{
			if ((Object)entity == (Object)null || !LooksLikeMedusaEntity(entity))
			{
				return;
			}
			_lastLiveMedusaEntity = entity;
			try
			{
				entity.charId = CurrentMedusaId();
			}
			catch
			{
			}
			try
			{
				entity.NetworkcharId = CurrentMedusaId();
			}
			catch
			{
			}
			MedusaMod instance = _instance;
			if (instance != null)
			{
				GameObject gameObject = ((Component)entity).gameObject;
				if (!((Object)gameObject == (Object)null))
				{
					RepairLocalMedusaBinding(entity, source, forceWhenLocalPrimaryMissing: true);
					RepairMedusaCameraTarget(entity, source + ".ensure");
					instance.EnsureLiveMedusaVisual(gameObject, source);
					ApplyMedusaAbilityRuntimeUi(entity.charAbilities, source + ".CharAbilities");
					instance.SuppressInheritedKitsuAbilityVfx(entity.charAbilities, source + ".CharAbilities");
					ScheduleLiveMedusaRefresh(entity, source);
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] EnsureLiveMedusaEntity failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ScheduleLiveMedusaRefresh(EntityManager entity, string source)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		MedusaMod inst;
		try
		{
			inst = _instance;
			if (inst == null || (Object)entity == (Object)null)
			{
				return;
			}
			GameObject gameObject = ((Component)entity).gameObject;
			if ((Object)gameObject == (Object)null)
			{
				return;
			}
			int instanceID = ((Object)gameObject).GetInstanceID();
			if (_liveRefreshScheduledOnceRoots.Contains(instanceID))
			{
				return;
			}
			_liveRefreshScheduledOnceRoots.Add(instanceID);
			if (_liveRefreshScheduledOnceRoots.Count > 128)
			{
				_liveRefreshScheduledOnceRoots.Clear();
			}
			float num;
			try
			{
				num = Time.unscaledTime;
			}
			catch
			{
				num = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
			}
			if (!_liveRefreshScheduledAt.TryGetValue(instanceID, out var value) || !(num - value < 1.4f))
			{
				_liveRefreshScheduledAt[instanceID] = num;
				if (_liveRefreshScheduledAt.Count > 64)
				{
					_liveRefreshScheduledAt.Clear();
				}
				Once(0.15f);
				Once(0.45f);
				Once(0.95f);
				Once(1.8f);
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] ScheduleLiveMedusaRefresh failed via " + source + ": " + ex.Message);
			}
		}
		void Once(float delay)
		{
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0036: Expected O, but got Unknown
			TimerAPI.Once(delay, (Action)delegate
			{
				//IL_000b: Unknown result type (might be due to invalid IL or missing references)
				//IL_0016: Expected O, but got Unknown
				//IL_0052: Unknown result type (might be due to invalid IL or missing references)
				//IL_005d: Expected O, but got Unknown
				try
				{
					if (!((Object)entity == (Object)null) && LooksLikeMedusaEntity(entity))
					{
						_lastLiveMedusaEntity = entity;
						GameObject gameObject2 = ((Component)entity).gameObject;
						if (!((Object)gameObject2 == (Object)null))
						{
							RepairLocalMedusaBinding(entity, $"{source}+{delay:F2}s", forceWhenLocalPrimaryMissing: true);
							RepairMedusaCameraTarget(entity, $"{source}+{delay:F2}s");
							inst.EnsureLiveMedusaVisual(gameObject2, $"{source}+{delay:F2}s");
							ApplyMedusaAbilityRuntimeUi(entity.charAbilities, $"{source}+{delay:F2}s.CharAbilities");
							inst.SuppressInheritedKitsuAbilityVfx(entity.charAbilities, $"{source}+{delay:F2}s.CharAbilities");
							ApplyLiveAbilityUiPalette($"{source}+{delay:F2}s");
						}
					}
				}
				catch (Exception ex2)
				{
					MedusaMod instance2 = _instance;
					if (instance2 != null)
					{
						((ModBase)instance2).Log.Warn($"[Medusa] delayed live refresh failed via {source}+{delay:F2}s: {ex2.Message}");
					}
				}
			}, (ModBase)inst);
		}
	}

	private static bool IsMedusaAbilityText(string? value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		if (value.IndexOf("MEDUSA_", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		foreach (KeyValuePair<string, string> medusaPhrase in MedusaPhrases)
		{
			if (string.Equals(value, medusaPhrase.Key, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			if (string.Equals(value, medusaPhrase.Value, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
		}
		return false;
	}

	private static string ResolveMedusaPhrase(string? key)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		if (string.IsNullOrWhiteSpace(key))
		{
			return string.Empty;
		}
		try
		{
			UIManager manager = UIAPI.Manager;
			Translator val = (((Object)manager != (Object)null) ? manager.translator : null);
			if (val != null)
			{
				string text = val.LocalisePhrase(key);
				if (!string.IsNullOrWhiteSpace(text) && !string.Equals(text, key, StringComparison.OrdinalIgnoreCase))
				{
					return text;
				}
			}
		}
		catch
		{
		}
		if (MedusaPhrases.TryGetValue(key, out string value))
		{
			return value;
		}
		return key;
	}

	private static string CleanMedusaTooltipText(string text, int slot)
	{
		if (string.IsNullOrWhiteSpace(text))
		{
			return string.Empty;
		}
		return text.Replace("{1}", slot switch
		{
			0 => "poison damage", 
			1 => "poison damage", 
			2 => "knock-up pressure", 
			3 => "curse damage", 
			_ => "damage", 
		}).Replace("{2}", slot switch
		{
			1 => "poison", 
			2 => "knock-up", 
			3 => "2.5s petrify", 
			_ => "poison", 
		});
	}

	private static int NormalizeMedusaAbilitySlot(int cmdId)
	{
		if (cmdId < 0 || cmdId > 3)
		{
			return -1;
		}
		return cmdId;
	}

	private static AbilityData? MedusaAbilityDataForSlot(int slot)
	{
		AbilityData[] array = MedusaAbilityData();
		if (slot < 0 || slot >= array.Length)
		{
			return null;
		}
		return array[slot];
	}

	private static string MedusaAbilityTitleForSlot(int slot)
	{
		AbilityData val = MedusaAbilityDataForSlot(slot);
		string key = string.Empty;
		try
		{
			key = ((val != null) ? val.titleKey : null) ?? string.Empty;
		}
		catch
		{
		}
		return ResolveMedusaPhrase(key);
	}

	private static string MedusaAbilityTooltipForSlot(int slot, bool expanded)
	{
		AbilityData val = MedusaAbilityDataForSlot(slot);
		string key = string.Empty;
		try
		{
			key = ((!expanded) ? (((val != null) ? val.shortDescriptionKey : null) ?? string.Empty) : (((val != null) ? val.descriptionKey : null) ?? string.Empty));
		}
		catch
		{
		}
		string text = CleanMedusaTooltipText(ResolveMedusaPhrase(key), slot);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return slot switch
		{
			0 => "Loose a venom-tipped serpent bolt at a single target.", 
			1 => "Spit a wave of venom into an area. Slows and poisons enemies caught in it.", 
			2 => "Coil and slither away. Knocks up foes at the launch point.", 
			3 => "Stare a piercing curse through obstacles and enemies. Petrifies targets struck.", 
			_ => string.Empty, 
		};
	}

	private static void OverrideMedusaAbilityTooltipText(Ability? ability, bool expanded, ref string __result)
	{
		try
		{
			int medusaAbilitySlot = GetMedusaAbilitySlot(ability);
			if (medusaAbilitySlot >= 0)
			{
				string text = MedusaAbilityTooltipForSlot(medusaAbilitySlot, expanded);
				if (!string.IsNullOrWhiteSpace(text))
				{
					__result = text;
				}
			}
		}
		catch
		{
		}
	}

	private static bool TryShowMedusaAbilityTooltip(UIAbilities? uiAbilities, int cmdId, bool fadeIn, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)uiAbilities == (Object)null || !LocalPlayerIsMedusa())
			{
				return false;
			}
			int num = NormalizeMedusaAbilitySlot(cmdId);
			if (num < 0)
			{
				return false;
			}
			UITooltip uiTooltip = uiAbilities.uiTooltip;
			if ((Object)uiTooltip == (Object)null)
			{
				return false;
			}
			RectTransform val = null;
			UIAbilityElement val2 = null;
			try
			{
				Il2CppReferenceArray<UIAbilityElement> abilityElementsByCmdId = uiAbilities.abilityElementsByCmdId;
				if (abilityElementsByCmdId != null && cmdId >= 0 && cmdId < ((Il2CppArrayBase<UIAbilityElement>)(object)abilityElementsByCmdId).Length)
				{
					val2 = ((Il2CppArrayBase<UIAbilityElement>)(object)abilityElementsByCmdId)[cmdId];
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)val2 != (Object)null)
				{
					val = val2.rectTransform;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)val == (Object)null && (Object)val2 != (Object)null)
				{
					val = ((Component)val2).GetComponent<RectTransform>();
				}
			}
			catch
			{
			}
			if ((Object)val == (Object)null)
			{
				return false;
			}
			string text = MedusaAbilityTitleForSlot(num);
			string text2 = MedusaAbilityTooltipForSlot(num, expanded: false);
			if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(text2))
			{
				return false;
			}
			uiTooltip.ShowTooltip(MedusaTitleTextColor, text, text2, val, fadeIn);
			ApplyMedusaAbilityElementPalette(val2, source + ".directTooltip");
			MedusaMod instance = _instance;
			if (instance != null && instance._runtimeUiLogCount < 16)
			{
				instance._runtimeUiLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] direct ability tooltip via {source}: cmd={cmdId} slot={num} title='{text}'.");
			}
			return true;
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] direct ability tooltip failed via " + source + ": " + ex.Message);
			}
			return false;
		}
	}

	private static void ApplyMedusaAbilityElementPalette(UIAbilityElement? element, string source)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected O, but got Unknown
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Expected O, but got Unknown
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017b: Expected O, but got Unknown
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e1: Expected O, but got Unknown
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected O, but got Unknown
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)element == (Object)null)
			{
				return;
			}
			try
			{
				element.abilityTitleColor = MedusaTitleTextColor;
			}
			catch
			{
			}
			try
			{
				element._primaryAbilityColor = MedusaAbilityIconColor;
			}
			catch
			{
			}
			try
			{
				if ((Object)element.bgImage != (Object)null)
				{
					((Graphic)element.bgImage).color = MedusaAbilityBgColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)element.abilityIcon != (Object)null)
				{
					((Graphic)element.abilityIcon).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)element.activeState != (Object)null)
				{
					((Graphic)element.activeState).color = new Color(0.18f, 1f, 0.32f, 0.88f);
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)element.cdTopTab != (Object)null)
				{
					((Graphic)element.cdTopTab).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)element.cdProgressBarOutline != (Object)null)
				{
					((Graphic)element.cdProgressBarOutline).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)element.cdProgressBarFill != (Object)null)
				{
					((Graphic)element.cdProgressBarFill).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)element.inputIconBG != (Object)null)
				{
					((Graphic)element.inputIconBG).color = MedusaAbilityBgColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)element.readyAlphaAnimImage != (Object)null)
				{
					((Graphic)element.readyAlphaAnimImage).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				Il2CppReferenceArray<Image> chargeImages = element.chargeImages;
				if (chargeImages != null)
				{
					for (int i = 0; i < ((Il2CppArrayBase<Image>)(object)chargeImages).Length; i++)
					{
						if ((Object)((Il2CppArrayBase<Image>)(object)chargeImages)[i] != (Object)null)
						{
							((Graphic)((Il2CppArrayBase<Image>)(object)chargeImages)[i]).color = MedusaAbilityIconColor;
						}
					}
				}
			}
			catch
			{
			}
			MedusaMod instance = _instance;
			if (instance != null && instance._abilityElementPaletteLogCount < 16)
			{
				instance._abilityElementPaletteLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] ability element palette applied via {source}: cmd={SafeInt(() => element._cmdId)} title='{SafeString(() => element.titleStr)}'.");
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] ApplyMedusaAbilityElementPalette failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static bool LocalPlayerIsMedusa()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		try
		{
			PlayerManager local = PlayerAPI.Local;
			if ((Object)local != (Object)null && IsMedusaId(SafeIntValue(() => local.charId)))
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			Il2CppArrayBase<PlayerManager> val = Object.FindObjectsOfType<PlayerManager>();
			if (val != null)
			{
				foreach (PlayerManager item in val)
				{
					if (!((Object)item == (Object)null))
					{
						bool flag = false;
						try
						{
							flag = ((NetworkBehaviour)item).isLocalPlayer;
						}
						catch
						{
						}
						if (flag && IsMedusaId(SafeIntValue(() => item.charId)))
						{
							return true;
						}
					}
				}
			}
		}
		catch
		{
		}
		try
		{
			Il2CppArrayBase<EntityManager> val2 = Object.FindObjectsOfType<EntityManager>();
			if (val2 != null)
			{
				foreach (EntityManager item2 in val2)
				{
					if (!((Object)item2 == (Object)null))
					{
						bool flag2 = false;
						try
						{
							flag2 = ((NetworkBehaviour)item2).isLocalPlayer;
						}
						catch
						{
						}
						if (flag2 && IsMedusaId(SafeIntValue(() => item2.charId)))
						{
							return true;
						}
					}
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static void ApplyLiveAbilityUiPalette(string source)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		try
		{
			Il2CppArrayBase<UIAbilityElement> val = Object.FindObjectsOfType<UIAbilityElement>();
			if (val == null)
			{
				return;
			}
			bool flag = LocalPlayerIsMedusa();
			foreach (UIAbilityElement item in val)
			{
				if ((Object)item == (Object)null)
				{
					continue;
				}
				string value = string.Empty;
				try
				{
					value = item.titleStr ?? string.Empty;
				}
				catch
				{
				}
				int num = -1;
				try
				{
					num = item._cmdId;
				}
				catch
				{
				}
				if (!IsMedusaAbilityText(value) && (!flag || num < 0 || num > 3))
				{
					continue;
				}
				if (flag && num >= 0 && num <= 3)
				{
					string text = MedusaAbilityTitleForSlot(num);
					if (!string.IsNullOrWhiteSpace(text))
					{
						try
						{
							item.titleStr = text;
						}
						catch
						{
						}
					}
				}
				ApplyMedusaAbilityElementPalette(item, source + ".live");
			}
		}
		catch
		{
		}
	}

	private static CharacterPageModel BuildUnlockedCharacterPageModel(string source)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_000d: Expected O, but got Unknown
		CharacterPageModel val = new CharacterPageModel();
		ForceCharacterPageModelUnlocked(val, source);
		return val;
	}

	private static Il2CppReferenceArray<CharListing> BuildCharacterListings(int[] characterIds)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		Il2CppReferenceArray<CharListing> val = new Il2CppReferenceArray<CharListing>((long)characterIds.Length);
		for (int i = 0; i < characterIds.Length; i++)
		{
			CharListing val2 = new CharListing
			{
				listingId = $"character-{characterIds[i]}",
				charId = characterIds[i],
				levelRequirement = 0,
				costs = new Il2CppReferenceArray<AssetModel>(0L),
				purchases = 1
			};
			((Il2CppArrayBase<CharListing>)(object)val)[i] = val2;
		}
		return val;
	}

	private static void EnsureLobbyCharacterPageDataAvailable(string source)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		try
		{
			Il2CppArrayBase<UILobbyCharacterSelectPage> val = Resources.FindObjectsOfTypeAll<UILobbyCharacterSelectPage>();
			if (val == null || val.Length <= 0)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < val.Length; i++)
			{
				UILobbyCharacterSelectPage val2 = val[i];
				if (!((Object)val2 == (Object)null))
				{
					CharacterPageModel data = val2._data;
					if (data == null)
					{
						data = BuildUnlockedCharacterPageModel(source + ".new");
						val2._data = data;
					}
					else
					{
						ForceCharacterPageModelUnlocked(data, source + ".existing");
					}
					num++;
				}
			}
			if (num > 0 && _uiWarmupLogCount < 8)
			{
				_uiWarmupLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] ensured UILobbyCharacterSelectPage data before {source}: pages={num}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] lobby character page data bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void EnsureLobbyCharacterPageDataAvailable(UILobbyCharacterSelectPage? page, string source)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		try
		{
			if ((Object)page == (Object)null)
			{
				return;
			}
			CharacterPageModel data = page._data;
			if (data == null)
			{
				data = BuildUnlockedCharacterPageModel(source + ".new");
				page._data = data;
			}
			else
			{
				ForceCharacterPageModelUnlocked(data, source + ".existing");
			}
			if (_uiWarmupLogCount < 8)
			{
				_uiWarmupLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info("[Medusa] ensured UILobbyCharacterSelectPage instance data before " + source + ".");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] lobby character page instance bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ForceCharacterPageModelUnlocked(CharacterPageModel? data, string source)
	{
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Expected O, but got Unknown
		try
		{
			if (data == null)
			{
				return;
			}
			int[] array = CurrentCharacterIds();
			Il2CppStructArray<int> val = new Il2CppStructArray<int>((long)array.Length);
			Il2CppStructArray<int> val2 = new Il2CppStructArray<int>((long)array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				((Il2CppArrayBase<int>)(object)val)[i] = array[i];
				((Il2CppArrayBase<int>)(object)val2)[i] = array[i];
			}
			data.availableCharacters = val;
			data.charIdsInRotation = val2;
			HashSet<int> val3 = new HashSet<int>();
			for (int j = 0; j < array.Length; j++)
			{
				val3.Add(array[j]);
			}
			data.unlockedCharacters = val3;
			CharListings val4 = data.charListings;
			if (val4 == null)
			{
				val4 = (data.charListings = new CharListings());
			}
			Il2CppReferenceArray<CharListing> val6 = ((val4 != null) ? val4.charListings : null);
			if (val6 == null || ((Il2CppArrayBase<CharListing>)(object)val6).Length <= 0)
			{
				val6 = (val4.charListings = BuildCharacterListings(array));
			}
			if (val6 != null)
			{
				for (int k = 0; k < ((Il2CppArrayBase<CharListing>)(object)val6).Length; k++)
				{
					CharListing val8 = ((Il2CppArrayBase<CharListing>)(object)val6)[k];
					if (val8 == null)
					{
						continue;
					}
					int charId = val8.charId;
					bool flag = false;
					for (int l = 0; l < array.Length; l++)
					{
						if (array[l] == charId)
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						val8.levelRequirement = 0;
						val8.purchases = 1;
					}
				}
			}
			if (_uiWarmupLogCount < 8)
			{
				_uiWarmupLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] lobby page model unlocked via {source}: ids={string.Join(",", array)}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] lobby page model unlock bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void EnsureRegisteredForMatchPage(UILobbyMatchCharacterSelectPage? page, string source)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Expected O, but got Unknown
		try
		{
			EnsureRegisteredForUi(source);
			object obj;
			if ((Object)(object)page == (Object)null)
			{
				obj = null;
			}
			else
			{
				Configuration configuration = page._configuration;
				obj = ((configuration != null) ? configuration.CharacterConfiguration : null);
			}
			if (obj == null)
			{
				obj = FindCharConfig();
			}
			UICharactersConfiguration val = (UICharactersConfiguration)obj;
			if (_instance != null && (Object)val != (Object)null)
			{
				_instance.TryRegisterMedusa(val);
				_instance.MakeRosterAvailable(val);
			}
			ForceMatchCharacterSelectModelAvailable(((Object)(object)page != (Object)null) ? page._data : null, source + "._data");
		}
		catch (Exception ex)
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] match select registration failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ForceMatchCharacterSelectModelAvailable(CharacterSelectModel? data, string source)
	{
		try
		{
			if (data == null)
			{
				return;
			}
			int[] array = CurrentCharacterIds();
			Il2CppStructArray<int> val = new Il2CppStructArray<int>((long)array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				((Il2CppArrayBase<int>)(object)val)[i] = array[i];
			}
			data.availableCharacters = val;
			if (_matchSelectLogCount < 12)
			{
				_matchSelectLogCount++;
				MedusaMod instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] match select model available via {source}: ids={string.Join(",", array)}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] match select model bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static int GetMatchDataCharacterId(UILobbyMatchCharacterSelectPage? page, int index)
	{
		try
		{
			object obj;
			if ((Object)(object)page == (Object)null)
			{
				obj = null;
			}
			else
			{
				CharacterSelectModel data = page._data;
				obj = ((data != null) ? data.availableCharacters : null);
			}
			Il2CppStructArray<int> val = (Il2CppStructArray<int>)obj;
			if (val != null && index >= 0 && index < ((Il2CppArrayBase<int>)(object)val).Length)
			{
				return ((Il2CppArrayBase<int>)(object)val)[index];
			}
		}
		catch
		{
		}
		return index;
	}

	private static bool TryGetLobbyCharacterListingIndex(UILobbyCharacterSelectPage? page, int charId, out int index)
	{
		index = -1;
		try
		{
			CharacterPageModel val = (((Object)(object)page != (Object)null) ? page._data : null);
			Il2CppReferenceArray<CharListing> val2 = ((val != null && val.charListings != null) ? val.charListings.charListings : null);
			if (val2 != null)
			{
				for (int i = 0; i < ((Il2CppArrayBase<CharListing>)(object)val2).Length; i++)
				{
					CharListing val3 = ((Il2CppArrayBase<CharListing>)(object)val2)[i];
					if (val3 != null && val3.charId == charId)
					{
						index = i;
						return true;
					}
				}
			}
			Il2CppStructArray<int> val4 = ((val != null) ? val.availableCharacters : null);
			if (val4 != null)
			{
				for (int j = 0; j < ((Il2CppArrayBase<int>)(object)val4).Length; j++)
				{
					if (((Il2CppArrayBase<int>)(object)val4)[j] == charId)
					{
						index = j;
						return true;
					}
				}
			}
		}
		catch
		{
		}
		int[] array = CurrentCharacterIds();
		for (int k = 0; k < array.Length; k++)
		{
			if (array[k] == charId)
			{
				index = k;
				return true;
			}
		}
		return false;
	}

	private static int FindCharacterConfigIndex(int charId)
	{
		try
		{
			UICharactersConfiguration val = FindCharConfig();
			Il2CppReferenceArray<CharacterConfiguration> val2 = (((Object)(object)val != (Object)null) ? val.Characters : null);
			if (val2 != null)
			{
				for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val2).Length; i++)
				{
					if (((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[i] != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[i].charId == charId)
					{
						return i;
					}
				}
			}
		}
		catch
		{
		}
		int[] array = CurrentCharacterIds();
		for (int j = 0; j < array.Length; j++)
		{
			if (array[j] == charId)
			{
				return j;
			}
		}
		return charId;
	}

	private static string SafeInt(Func<int> fn)
	{
		try
		{
			return fn().ToString();
		}
		catch
		{
			return "?";
		}
	}

	private static string SafeString(Func<string> fn)
	{
		try
		{
			return fn() ?? string.Empty;
		}
		catch
		{
			return "?";
		}
	}

	private static Animator? FindMedusaAnimator(Transform t)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected O, but got Unknown
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		try
		{
			if ((Object)t == (Object)null)
			{
				return null;
			}
			Transform val = t;
			while ((Object)val.parent != (Object)null)
			{
				val = val.parent;
			}
			Il2CppArrayBase<Animator> componentsInChildren = ((Component)val).GetComponentsInChildren<Animator>(true);
			if (componentsInChildren == null || componentsInChildren.Length == 0)
			{
				return null;
			}
			foreach (Animator item in componentsInChildren)
			{
				if ((Object)item == (Object)null)
				{
					continue;
				}
				try
				{
					if (IsMedusaRuntimeController(item.runtimeAnimatorController))
					{
						return item;
					}
				}
				catch
				{
				}
				try
				{
					Transform val2 = ((Component)item).transform;
					bool flag = false;
					while ((Object)val2 != (Object)null)
					{
						if (((Object)val2).name == "Medusa_Visual")
						{
							flag = true;
							break;
						}
						val2 = val2.parent;
					}
					if (flag && TryAssignCachedMedusaController(item, "FindMedusaAnimator"))
					{
						return item;
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return null;
	}

	private static StatusEffectSO? FindSE(string className, string assetName, out int id)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		id = -1;
		try
		{
			Il2CppArrayBase<StatusEffectManager> val = Resources.FindObjectsOfTypeAll<StatusEffectManager>();
			if (val == null)
			{
				return null;
			}
			foreach (StatusEffectManager item in val)
			{
				if ((Object)item == (Object)null)
				{
					continue;
				}
				Il2CppReferenceArray<StatusEffectSO> statusEffects = item.statusEffects;
				if (statusEffects == null)
				{
					continue;
				}
				for (int i = 0; i < ((Il2CppArrayBase<StatusEffectSO>)(object)statusEffects).Length; i++)
				{
					StatusEffectSO val2 = ((Il2CppArrayBase<StatusEffectSO>)(object)statusEffects)[i];
					if ((Object)val2 == (Object)null)
					{
						continue;
					}
					string text = "";
					try
					{
						Type il2CppType = ((Object)val2).GetIl2CppType();
						text = ((il2CppType != (Type)null) ? ((MemberInfo)il2CppType).Name : "");
					}
					catch
					{
					}
					string text2 = "";
					try
					{
						text2 = ((Object)val2).name ?? "";
					}
					catch
					{
					}
					if (text == className || text2.Equals(assetName, StringComparison.OrdinalIgnoreCase))
					{
						try
						{
							id = item.GetStatusEffectId(val2);
						}
						catch
						{
							id = -1;
						}
						return val2;
					}
				}
			}
		}
		catch (Exception ex)
		{
			if (_instance != null)
			{
				((ModBase)_instance).Log.Warn("[Medusa] FindSE(" + assetName + ") threw: " + ex.Message);
			}
		}
		return null;
	}

	internal static bool TryResolvePetrifySO()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		if ((Object)_petrifySO != (Object)null)
		{
			return true;
		}
		_petrifyLookupAttempted = true;
		_petrifySO = FindSE("SE_Petrified_SO", "SE_Petrified", out _petrifyId);
		if ((Object)_petrifySO != (Object)null)
		{
			_petrifyLookupSucceeded = true;
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] petrify SO resolved (id={_petrifyId}).");
			}
			return true;
		}
		return false;
	}

	internal static bool TryResolvePoisonSO()
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		if ((Object)_poisonSO != (Object)null)
		{
			return true;
		}
		_poisonLookupAttempted = true;
		_poisonSO = FindSE("SE_Poisoned_SO", "SE_Poisoned", out _poisonId);
		if ((Object)_poisonSO != (Object)null)
		{
			_poisonLookupSucceeded = true;
			MedusaMod instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] poison SO resolved (id={_poisonId}).");
			}
			return true;
		}
		return false;
	}

	internal static int GetMedusaAbilitySlot(Ability ability)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Expected O, but got Unknown
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Expected O, but got Unknown
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		if ((Object)ability == (Object)null)
		{
			return -1;
		}
		try
		{
			EntityManager entityManager = ability.entityManager;
			if ((Object)entityManager == (Object)null || _instance == null)
			{
				return -1;
			}
			int medusaCharId = _instance.MedusaCharId;
			if (medusaCharId < 0 || entityManager.charId != medusaCharId)
			{
				return -1;
			}
			CharAbilities charAbilities = ability.charAbilities;
			if ((Object)charAbilities == (Object)null)
			{
				return -1;
			}
			Il2CppReferenceArray<Ability> abilities = charAbilities.abilities;
			if (abilities == null)
			{
				return -1;
			}
			for (int i = 0; i < ((Il2CppArrayBase<Ability>)(object)abilities).Length; i++)
			{
				if ((Object)((Il2CppArrayBase<Ability>)(object)abilities)[i] != (Object)null && ((Il2CppObjectBase)((Il2CppArrayBase<Ability>)(object)abilities)[i]).Pointer == ((Il2CppObjectBase)ability).Pointer)
				{
					return i;
				}
			}
		}
		catch
		{
		}
		return -1;
	}

	internal static bool IsMedusaUltAbility(Ability ability)
	{
		return GetMedusaAbilitySlot(ability) == 3;
	}
}

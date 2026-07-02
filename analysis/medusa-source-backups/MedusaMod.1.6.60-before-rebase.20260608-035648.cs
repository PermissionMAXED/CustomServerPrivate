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
using Il2CppBAPBAP.UI;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppMirror;
using UnityEngine;
using UnityEngine.UI;
using Actions = Il2CppBAPBAP.UI.UILobbyMatchCharacterSelectPage.Actions;
using AbilityData = Il2CppBAPBAP.UI.UICharactersConfiguration.CharacterConfiguration.AbilityData;
using CastStarted = BAPBAP.ModAPI.Events.AbilityEvents.CastStarted;
using CharacterConfiguration = Il2CppBAPBAP.UI.UICharactersConfiguration.CharacterConfiguration;
using Handler = BAPBAP.ModAPI.API.ChatCommands.Handler;
using CharListing = Il2CppBAPBAP.UI.CharacterPageModel.CharListing;
using CharListings = Il2CppBAPBAP.UI.CharacterPageModel.CharListings;
using Configuration = Il2CppBAPBAP.UI.UILobbyMatchCharacterSelectPage.Configuration;
using KeyHandler = BAPBAP.ModAPI.API.KeybindManager.KeyHandler;
using NetworkPrefabLibrary = Il2CppBAPBAP.Pooling.NetworkPrefabLibrary;
using NetworkPrefabPool = Il2CppBAPBAP.Pooling.NetworkPrefabPool;
using Severity = BAPBAP.ModAPI.API.NotificationAPI.Severity;
using Object = UnityEngine.Object;

namespace BAPBAP.Medusa;

public sealed class PrematchMedusaClickProxy : MonoBehaviour
{
	private static bool _registered;

	private Action? _callback;

	private RectTransform? _rect;

	public PrematchMedusaClickProxy(IntPtr ptr)
		: base(ptr)
	{
	}

	public static void Attach(GameObject go, Action onClick, string source)
	{
		EnsureRegistered();
		try
		{
			if ((Object)(object)go == (Object)null)
			{
				return;
			}
			PrematchMedusaClickProxy proxy = go.GetComponent<PrematchMedusaClickProxy>();
			if ((Object)(object)proxy == (Object)null)
			{
				proxy = go.AddComponent<PrematchMedusaClickProxy>();
			}
			proxy._callback = onClick;
			proxy._rect = go.GetComponent<RectTransform>() ?? go.transform as RectTransform;
			proxy.enabled = true;
			Debug.Log($"[Medusa] prematch Medusa click proxy attached via {source}.");
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[Medusa] prematch Medusa click proxy attach failed: " + ex.Message);
		}
	}

	private static void EnsureRegistered()
	{
		if (_registered)
		{
			return;
		}
		try
		{
			Il2CppInterop.Runtime.Injection.ClassInjector.RegisterTypeInIl2Cpp<PrematchMedusaClickProxy>();
			_registered = true;
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[Medusa] prematch Medusa click proxy registration failed: " + ex.Message);
		}
	}

	public void Update()
	{
		try
		{
			if (_callback == null || _rect == null || !Input.GetMouseButtonDown(0))
			{
				return;
			}
			if (RectTransformUtility.RectangleContainsScreenPoint(_rect, Input.mousePosition, null))
			{
				Debug.Log("[Medusa] prematch Medusa click proxy fired.");
				_callback();
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("[Medusa] prematch Medusa click proxy update failed: " + ex.Message);
		}
	}
}

public sealed class MedusaMod : ModBase
{
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
			foreach (object? item in array)
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
			int scanned = 0;
			foreach (object? item in enumerable)
			{
				if (ContainsBlockedUnityLog(item, depth + 1))
				{
					return true;
				}
				if (++scanned >= 32)
				{
					break;
				}
			}
		}
		return ContainsBlockedUnityLogText(value.ToString());
	}

	private static bool ContainsBlockedUnityLogText(string? text)
	{
		return !string.IsNullOrWhiteSpace(text) &&
			(text.IndexOf("data was null on CharacterSelectPage.CharacterIsUnlocked", StringComparison.OrdinalIgnoreCase) >= 0 ||
			 text.IndexOf("data was null on CharacterSelectPage.CharacterIsUnlockedInRotation", StringComparison.OrdinalIgnoreCase) >= 0);
	}

	[HarmonyPatch]
	public static class DebugLogFilterPatch
	{
		[HarmonyTargetMethods]
		public static IEnumerable<MethodBase> TargetMethods()
		{
			foreach (MethodInfo method in typeof(DebugLogHandler).GetMethods(BindingFlags.Instance | BindingFlags.Public))
			{
				if (method.Name == "LogFormat")
				{
					yield return method;
				}
			}
		}

		[HarmonyPrefix]
		[HarmonyPriority(Priority.First)]
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
			if (__instance != null && data != null)
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
			if (__instance != null && data != null)
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
			if (TryGetLobbyCharacterListingIndex(__instance, charId, out int index))
			{
				__result = index;
				if (_lobbyListingIndexLogCount < 12)
				{
					_lobbyListingIndexLogCount++;
					MedusaMod? instance = _instance;
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
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Warn($"[Medusa] lobby listing index missing for charId={charId}; returning -1 to avoid native NullReference.");
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
			try
			{
				EnsureRegisteredForUi("UILobbyMatchCharacterSelectPage.Build");
				if (_instance != null && (Object)(object)((configuration != null) ? configuration.CharacterConfiguration : null) != (Object)null)
				{
					_instance.TryRegisterMedusa(configuration.CharacterConfiguration);
					_instance.MakeRosterAvailable(configuration.CharacterConfiguration);
				}
			}
			catch (Exception ex)
			{
				MedusaMod? instance = _instance;
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
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				ModLogger log = ((ModBase)instance).Log;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(58, 3);
				defaultInterpolatedStringHandler.AppendLiteral("[Medusa] match select actions ready: select=");
				object obj;
				if (__instance == null)
				{
					obj = null;
				}
				else
				{
					Actions actions = __instance._actions;
					obj = ((actions != null) ? actions.SelectCharAction : null);
				}
				defaultInterpolatedStringHandler.AppendFormatted((Delegate)obj != (Delegate)null);
				defaultInterpolatedStringHandler.AppendLiteral(" lock=");
				object obj2;
				if (__instance == null)
				{
					obj2 = null;
				}
				else
				{
					Actions actions2 = __instance._actions;
					obj2 = ((actions2 != null) ? actions2.LockCharAction : null);
				}
				defaultInterpolatedStringHandler.AppendFormatted((Delegate)obj2 != (Delegate)null);
				defaultInterpolatedStringHandler.AppendLiteral(" spawn=");
				object obj3;
				if (__instance == null)
				{
					obj3 = null;
				}
				else
				{
					Actions actions3 = __instance._actions;
					obj3 = ((actions3 != null) ? actions3.SpawnSelectAction : null);
				}
				defaultInterpolatedStringHandler.AppendFormatted((Delegate)obj3 != (Delegate)null);
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
				MedusaMod? instance = _instance;
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
			MedusaMod? instance = _instance;
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
			int num = ((__instance != null) ? __instance._selectedCharIndex : (-1));
			int matchDataCharacterId = GetMatchDataCharacterId(__instance, num);
			if (IsMedusaId(matchDataCharacterId))
			{
				RememberExplicitMedusaSelection("UILobbyMatchCharacterSelectPage.OnCharacterLockButtonSelect");
				ScheduleMedusaSelection("UILobbyMatchCharacterSelectPage.OnCharacterLockButtonSelect.explicit", lockAfter: true);
			}
			MedusaMod? instance = _instance;
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
				MedusaMod? instance = _instance;
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
			EnsureLobbyCharacterPageDataAvailable("View_PreMatch_CharSelect.Initialize");
			EnsureRegisteredForUi("View_PreMatch_CharSelect.Initialize");
			if (_instance != null && (Object)(object)((configuration != null) ? configuration.CharacterConfiguration : null) != (Object)null)
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
				MedusaMod? instance = _instance;
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
					MedusaMod? instance = _instance;
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
				MedusaMod? instance2 = _instance;
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
				MedusaMod? instance = _instance;
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
			try
			{
				bool flag = false;
				try
				{
					flag = (Object)(object)__instance != (Object)null && ((NetworkBehaviour)__instance).isLocalPlayer;
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
			MedusaMod? instance = _instance;
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
			try
			{
				if (!((Object)(object)player == (Object)null) && IsMedusaId(player.charId) && _prematchCmdLockLogCount < 8)
				{
					_prematchCmdLockLogCount++;
					MedusaMod? instance = _instance;
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
			if (!((Object)(object)player == (Object)null) && TryGetPreMatchSelectedChar(player, out var charId) && IsMedusaId(charId))
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
				ForcePlayerMedusaChar((__instance != null) ? __instance._playerManager : null, charId, "PlayerPreMatch.SetPlayerCharacter");
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
			_instance?.EnsureMedusaPrefabRegistered(CurrentMedusaId(), "GameMode.SpawnPlayerChar.prefix");
			if (!((Object)(object)playerManager == (Object)null))
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
			try
			{
				if (!((Object)(object)playerManager == (Object)null) && IsMedusaId(playerManager.charId))
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
			if (!IsMedusaId(charId))
			{
				return;
			}
			int fallbackCharId = _instance?.ResolveBotFallbackCharId("GameNetworkManager.GetCharacterBotPrefab") ?? 0;
			if (_medusaBotFallbackLogCount < 12)
			{
				_medusaBotFallbackLogCount++;
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] bot prefab fallback: requested Medusa charId={charId}, using base bot charId={fallbackCharId}, difficulty={botDifficulty}.");
				}
			}
			charId = fallbackCharId;
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
			try
			{
				if (!((Object)(object)e == (Object)null) && IsMedusaId(e.charId))
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
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				__state = ((!((Object)(object)__instance != (Object)null)) ? (-1) : ((int)__instance.state));
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
				int num = (int)_state;
				if (IsMedusaCastStartState(__state, num))
				{
					TryRunMedusaAbilityDriverFromState(__instance, num);
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
			return !TrySuppressInheritedKitsuShoot(__instance, "CatShotAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(CatMissileAbility), "Shoot")]
	public static class MedusaCatMissileShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(CatMissileAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot(__instance, "CatMissileAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(CatPolymorphAbility), "Shoot")]
	public static class MedusaCatPolymorphShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(CatPolymorphAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot(__instance, "CatPolymorphAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(CatJumpAbility), "Shoot")]
	public static class MedusaCatJumpShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(CatJumpAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot(__instance, "CatJumpAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(ArrowAbility), "Shoot")]
	public static class MedusaArrowShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(ArrowAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot(__instance, "ArrowAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(ChargedArrowsAbility), "Shoot")]
	public static class MedusaChargedArrowsShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(ChargedArrowsAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot(__instance, "ChargedArrowsAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(RecoilArrowAbility), "Shoot")]
	public static class MedusaRecoilArrowShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(RecoilArrowAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot(__instance, "RecoilArrowAbility.Shoot");
		}
	}

	[HarmonyPatch(typeof(ArrowMissileAbility), "Shoot")]
	public static class MedusaArrowMissileShootPatch
	{
		[HarmonyPrefix]
		public static bool Prefix(ArrowMissileAbility __instance)
		{
			return !TrySuppressInheritedKitsuShoot(__instance, "ArrowMissileAbility.Shoot");
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
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0029: Unknown result type (might be due to invalid IL or missing references)
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
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0023: Unknown result type (might be due to invalid IL or missing references)
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
			try
			{
				if ((Object)(object)__instance == (Object)null)
				{
					return true;
				}
				UIMinimapIcon existing = __instance.GetIconByNetId(netId);
				if ((Object)(object)existing == (Object)null)
				{
					return true;
				}
				__result = existing;
				if (_minimapDuplicateIconGuardLogCount < 6)
				{
					_minimapDuplicateIconGuardLogCount++;
					((ModBase?)_instance)?.Log.Info($"[Medusa] skipped duplicate minimap netId icon add for netId={netId}; reused existing icon.");
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
			if (__exception == null)
			{
				return null;
			}
			if (__exception is ArgumentException && __exception.Message.IndexOf("same key", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				try
				{
					if ((Object)(object)__instance != (Object)null)
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
					((ModBase?)_instance)?.Log.Warn($"[Medusa] suppressed duplicate minimap netId exception for netId={netId}: {__exception.Message}");
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
			try
			{
				if ((Object)(object)__instance == (Object)null)
				{
					return;
				}
				Animator val = FindMedusaAnimator(((Component)__instance).transform);
				if ((Object)(object)val == (Object)null)
				{
					return;
				}
				try
				{
					__instance.animator = val;
				}
				catch (Exception ex)
				{
					MedusaMod? instance = _instance;
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
					((ModBase)_instance).Log.Info($"[Medusa] HM postfix rebound CharAnimator on '{((Object)((Component)__instance).gameObject).name}' -> Medusa's Animator (controller='{(((Object)(object)val.runtimeAnimatorController != (Object)null) ? ((Object)val.runtimeAnimatorController).name : "?")}').");
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
			try
			{
				if ((Object)(object)__instance == (Object)null)
				{
					return;
				}
				Animator val = FindMedusaAnimator(((Component)__instance).transform);
				if ((Object)(object)val == (Object)null)
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
			//IL_0098: Unknown result type (might be due to invalid IL or missing references)
			//IL_009d: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
			//IL_00db: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_025e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0265: Unknown result type (might be due to invalid IL or missing references)
			//IL_026d: Expected O, but got Unknown
			//IL_013d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Unknown result type (might be due to invalid IL or missing references)
			//IL_014c: Expected O, but got Unknown
			try
			{
				if ((Object)(object)__instance == (Object)null)
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
				if ((Object)(object)val == (Object)null)
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
				if (!flag && !flag2)
				{
					return;
				}
				if ((Object)(object)otherEntityManager == (Object)null)
				{
					return;
				}
				CharStatusEffects charStatusEffects = otherEntityManager.charStatusEffects;
				if ((Object)(object)charStatusEffects == (Object)null || charStatusEffects.ignoreAllStatusEffects)
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
					if ((Object)(object)transform != (Object)null && (Object)(object)transform2 != (Object)null)
					{
						Vector3 val3 = transform.position - transform2.position;
						val2 = val3.normalized;
					}
				}
				catch
				{
				}
				if (flag)
				{
					Interlocked.Increment(ref _petrifyHitObservedCount);
					if ((_petrifyId < 0 || !charStatusEffects.IsStatusEffectApplied(_petrifyId)) && TryResolvePetrifySO() && !((Object)(object)_petrifySO == (Object)null))
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
				if (TryResolvePoisonSO() && !((Object)(object)_poisonSO == (Object)null))
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

	private static readonly string[] NativeVfxNames = new string[6]
	{
		"VFX_Medusa_Poison_Escape",
		"VFX_Medusa_Poison_Hit",
		"VFX_Medusa_Poison_Muzzle",
		"VFX_Medusa_Poison_Puddle",
		"VFX_Medusa_Poison_Trail",
		"VFX_Medusa_Poison_Wall"
	};

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

	private readonly HashSet<string> _visualDiagnosticSourcesLogged = new(StringComparer.OrdinalIgnoreCase);

	private int _visualFitLogCount;

	private readonly HashSet<string> _visualFitSourcesLogged = new(StringComparer.OrdinalIgnoreCase);

	private int _loadingOverlayHideLogCount;

	private static int _minimapDuplicateIconGuardLogCount;

	private int _liveLocalDiagnosticsLogCount;

	private bool _liveLocalDiagnosticsSuccessLogged;

	private int _inheritedVfxSuppressLogCount;

	private int _nativeVfxMaterialRepairLogCount;

	private readonly Dictionary<int, Material> _nativeVfxReplacementMaterials = new();

	private static int _localBindingRepairLogCount;

	private static int _localBindingNoCandidateLogCount;

	private static DateTime _lastLocalBindingNoCandidateLogUtc = DateTime.MinValue;

	private static readonly HashSet<int> _localBindingRepairIds = new();

	private static int _cameraTargetRepairLogCount;

	private static readonly HashSet<int> _cameraTargetRepairIds = new();

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

	public override void OnRegistered()
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
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
		}, "Register Medusa (/medusa, /medusa status, /medusa anim)", (ModBase)(object)this);
		KeybindManager.Register("medusa.register", (KeyCode)288, (KeyHandler)delegate
		{
			TryRegisterMedusa();
		}, (KeyHandler)null, (KeyHandler)null, false, false, false, (ModBase)(object)this);
		Subscribe<CastStarted>((Action<CastStarted>)OnAbilityCastStarted);
		((ModBase)this).Log.Info("[Medusa] Loaded (v1.6.60). Auto-registers at the lobby; /medusa or F7 to force, /medusa status, /medusa anim.");
		((ModBase)this).Log.Info("[Medusa] v1.6.60: keeps Melon/assembly versions aligned, avoids active-base Awake during prefab cloning, treats a visible live Medusa visual as stable, rejects foreign Bot/Proxy entities from local Medusa repair, keeps the prematch click proxy, suppresses inherited Kitsu/Cat/Arrow VFX, drives all four Medusa abilities, reapplies native Medusa ability titles, and keeps CharMaterial opacity repairs targeted. Bundle: UserData\\Medusa\\medusa.bundle.");
		TryLoadBundle();
		TimerAPI.Every(1f, (Action)PollOnce, (ModBase)(object)this);
		TimerAPI.Every(0.05f, (Action)PollLocalInputCastFx, (ModBase)(object)this);
		TimerAPI.Once(5f, (Action)LogAnimatorState, (ModBase)(object)this);
	}

	public override void OnUpdate(float deltaTime)
	{
		if (!AutoSelectAugmentEnabled())
		{
			return;
		}
		try
		{
			float now = Time.realtimeSinceStartup;
			if (now < _nextAutoAugmentScanAt)
			{
				return;
			}
			_nextAutoAugmentScanAt = now + 0.25f;
			TryAutoSelectOpenAugment("OnUpdate");
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
			return text.Contains("lobby", StringComparison.Ordinal) ||
			       text.Contains("menu", StringComparison.Ordinal) ||
			       text.Contains("main", StringComparison.Ordinal) ||
			       text.Contains("login", StringComparison.Ordinal);
		}
		catch
		{
			return false;
		}
	}

	private void PollOnce()
	{
		_pollTicks++;
		try
		{
			float now = Time.realtimeSinceStartup;
			UICharactersConfiguration val = (!_registered || !_firstCfgSeen || !_phrasesInjected || _pollTicks % 5 == 0) ? FindCharConfig() : null;
			if ((Object)(object)val != (Object)null && !_firstCfgSeen)
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
			if (now >= _nextWorldBindingPollAt)
			{
				_nextWorldBindingPollAt = now + 1f;
				EnsureLocalMedusaBindingFromWorld("PollOnce");
			}
			if (now >= _nextLiveDiagnosticsAt)
			{
				_nextLiveDiagnosticsAt = now + 2f;
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
		try
		{
			PlayerManager local = PlayerAPI.Local;
			EntityManager auth = PlayerAPI.AuthViewCharacter;
			if ((Object)(object)local == (Object)null && (Object)(object)auth == (Object)null)
			{
				return;
			}
			EntityManager localEntity = ((Object)(object)local != (Object)null) ? local.primaryCharManager : null;
			EntityManager worldMedusa = _lastLiveMedusaEntity;
			bool localIsMedusa = (Object)(object)local != (Object)null && IsMedusaId(SafeIntValue(() => local.charId));
			bool localPrimaryReady = (Object)(object)localEntity != (Object)null && IsMedusaId(SafeIntValue(() => localEntity.charId));
			bool authReady = (Object)(object)auth != (Object)null && IsMedusaId(SafeIntValue(() => auth.charId));
			bool worldMedusaReady = (Object)(object)worldMedusa != (Object)null && LooksLikeMedusaEntity(worldMedusa) && !IsLikelyForeignBotProxyMedusaEntity(worldMedusa);
			if (!localIsMedusa && !localPrimaryReady && !authReady && !worldMedusaReady)
			{
				return;
			}
			if (worldMedusaReady)
			{
				RepairMedusaCameraTarget(worldMedusa, "LogLiveLocalDiagnostics");
			}
			Il2CppArrayBase<PlayerManager> players = null;
			Il2CppArrayBase<EntityManager> entities = null;
			if (localIsMedusa && localPrimaryReady && authReady)
			{
				if (!_liveLocalDiagnosticsSuccessLogged)
				{
					_liveLocalDiagnosticsSuccessLogged = true;
					players = Object.FindObjectsOfType<PlayerManager>();
					entities = Object.FindObjectsOfType<EntityManager>();
					((ModBase)this).Log.Info($"[Medusa] live local diag ready: localPlayerId={PlayerAPI.LocalId} localChar={SafeIntValue(() => local.charId)} localPrimary='{ObjName(localEntity)}' auth='{ObjName(auth)}' pos={FmtPos(localEntity)} screen={ScreenPos(localEntity)} players={(players != null ? players.Length : 0)} entities={(entities != null ? entities.Length : 0)} camera={CameraInfo()}.");
				}
				return;
			}
			if (_liveLocalDiagnosticsLogCount >= 12 || _pollTicks % 5 != 0)
			{
				return;
			}
			_liveLocalDiagnosticsLogCount++;
			players = Object.FindObjectsOfType<PlayerManager>();
			entities = Object.FindObjectsOfType<EntityManager>();
			((ModBase)this).Log.Info($"[Medusa] live local diag #{_liveLocalDiagnosticsLogCount}: local={(Object)(object)local != (Object)null} localPlayerId={PlayerAPI.LocalId} localChar={SafeIntValue(() => local.charId)} localDead={SafeBool(() => local.isDead)} localDowned={SafeInt(() => (int)local.downedState)} localIsLocal={SafeBool(() => ((NetworkBehaviour)local).isLocalPlayer)} localOwned={SafeBool(() => ((NetworkBehaviour)local).isOwned)} localPrimary='{ObjName(localEntity)}' localPrimaryChar={SafeIntValue(() => localEntity.charId)} localPos={FmtPos(localEntity)} localScreen={ScreenPos(localEntity)} auth='{ObjName(auth)}' authChar={SafeIntValue(() => auth.charId)} authPos={FmtPos(auth)} authScreen={ScreenPos(auth)} worldMedusa='{ObjName(worldMedusa)}' worldChar={SafeIntValue(() => worldMedusa.charId)} worldPos={FmtPos(worldMedusa)} worldScreen={ScreenPos(worldMedusa)} spectating={SafeBool(() => PlayerAPI.IsSpectating)} players={(players != null ? players.Length : 0)} entities={(entities != null ? entities.Length : 0)} camera={CameraInfo()}.");
			if (players != null && _liveLocalDiagnosticsLogCount <= 3)
			{
				int count = Math.Min(players.Length, 4);
				for (int i = 0; i < count; i++)
				{
					PlayerManager player = players[i];
					if ((Object)(object)player == (Object)null)
					{
						continue;
					}
					EntityManager entity = player.primaryCharManager;
					((ModBase)this).Log.Info($"[Medusa] live player[{i}]: name='{ObjName(player)}' id={SafeIntValue(() => player.playerId)} char={SafeIntValue(() => player.charId)} team={SafeIntValue(() => player.teamId)} local={SafeBool(() => ((NetworkBehaviour)player).isLocalPlayer)} owned={SafeBool(() => ((NetworkBehaviour)player).isOwned)} dead={SafeBool(() => player.isDead)} primary='{ObjName(entity)}' primaryChar={SafeIntValue(() => entity.charId)} pos={FmtPos(entity)} screen={ScreenPos(entity)}.");
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
		try
		{
			PlayerManager local = PlayerAPI.Local;
			if ((Object)(object)local == (Object)null || !IsMedusaId(SafeIntValue(() => local.charId)))
			{
				return;
			}
			EntityManager currentPrimary = local.primaryCharManager;
			if ((Object)(object)currentPrimary != (Object)null && IsMedusaId(SafeIntValue(() => currentPrimary.charId)))
			{
				EnsureLiveMedusaEntity(currentPrimary, source + ".primary");
				return;
			}
			EntityManager candidate = FindBestLocalMedusaEntity(local, out var reason, out var medusaCount);
			if ((Object)(object)candidate == (Object)null)
			{
				MedusaMod? noCandidateInstance = _instance;
				DateTime now = DateTime.UtcNow;
				if (noCandidateInstance != null && _localBindingNoCandidateLogCount < 4 && (now - _lastLocalBindingNoCandidateLogUtc).TotalSeconds >= 5.0)
				{
					_localBindingNoCandidateLogCount++;
					_lastLocalBindingNoCandidateLogUtc = now;
					((ModBase)noCandidateInstance).Log.Warn($"[Medusa] local binding found no Medusa entity via {source}: candidates={medusaCount} localId={SafeIntValue(() => local.playerId)} entities={SafeIntValue(() => Object.FindObjectsOfType<EntityManager>()?.Length ?? 0)}.");
				}
				return;
			}
			RepairLocalMedusaBinding(candidate, $"{source}.world.{reason}.count{medusaCount}", forceWhenLocalPrimaryMissing: true);
			EnsureLiveMedusaEntity(candidate, $"{source}.world.{reason}.count{medusaCount}");
			EntityManager newPrimary = local.primaryCharManager;
			if ((Object)(object)newPrimary == (Object)null)
			{
				MedusaMod? instance = _instance;
				if (instance != null && _localBindingRepairLogCount < 32)
				{
					_localBindingRepairLogCount++;
					((ModBase)instance).Log.Warn($"[Medusa] local binding still missing after {source}: candidate='{ObjName(candidate)}' reason={reason} count={medusaCount} owner={SafeIntValue(() => candidate.ownerPlayerId)} getPlayerId={SafeIntValue(() => candidate.GetPlayerId())} playerObj='{ObjName(candidate.playerObj)}' entityPlayer='{ObjName(candidate.playerManager)}'.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null && _localBindingRepairLogCount < 32)
			{
				_localBindingRepairLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] local binding world scan failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static EntityManager? FindBestLocalMedusaEntity(PlayerManager local, out string reason, out int medusaCount)
	{
		reason = "none";
		medusaCount = 0;
		try
		{
			int localId = SafeIntValue(() => local.playerId);
			GameObject localObj = ((Component)local).gameObject;
			Il2CppArrayBase<EntityManager> entities = Object.FindObjectsOfType<EntityManager>();
			EntityManager explicitRootFallback = null;
			if (entities != null)
			{
				for (int i = 0; i < entities.Length; i++)
				{
					EntityManager entity = entities[i];
					if ((Object)(object)entity == (Object)null || !LooksLikeMedusaEntity(entity))
					{
						continue;
					}
					medusaCount++;
					if ((Object)(object)explicitRootFallback == (Object)null && IsExplicitMedusaRootEntity(entity))
					{
						explicitRootFallback = entity;
					}
					if ((Object)(object)entity.playerManager == (Object)(object)local)
					{
						reason = "entityPlayerRef";
						return entity;
					}
					if ((Object)(object)entity.playerObj == (Object)(object)localObj)
					{
						reason = "entityPlayerObj";
						return entity;
					}
					int ownerId = SafeIntValue(() => entity.ownerPlayerId);
					int reportedPlayerId = SafeIntValue(() => entity.GetPlayerId());
					if (ownerId == localId || reportedPlayerId == localId)
					{
						reason = "ownerMatch";
						return entity;
					}
				}
			}
			if ((Object)(object)explicitRootFallback != (Object)null)
			{
				reason = "explicitMedusaRoot";
				return explicitRootFallback;
			}
		}
		catch
		{
		}
		return null;
	}

	public void Status()
	{
		UICharactersConfiguration val = FindCharConfig();
		int value = (((Object)(object)val != (Object)null) ? SafeLen(val.Characters) : (-1));
		string value2 = "?";
		try
		{
			value2 = Loc.Get("MEDUSA_AB_LMB_TITLE");
		}
		catch
		{
		}
		((ModBase)this).Log.Info($"[Medusa] registered={_registered} charId={MedusaCharId} rosterSize={value} cfgFound={(Object)(object)val != (Object)null} phrasesInjected={_phrasesInjected} LMB.title='{value2}'");
		((ModBase)this).Log.Info($"[Medusa] graft: charAnimatorWired={_charAnimatorWired} charFootstepsWired={_charFootstepsWired} disabledNonMedusaAnims={_disabledNonMedusaAnims} toonShader='{_toonShaderApplied ?? "<not applied>"}' toonTemplateFrom='{_toonTemplateMaterialName ?? "<none>"}' harmonyFallbackFired={_harmonyRebindFiredAtLeastOnce}.");
		((ModBase)this).Log.Info($"[Medusa] petrify: SO='{(((Object)(object)_petrifySO != (Object)null) ? ((Object)_petrifySO).name : "<not-resolved>")}' petrifyId={_petrifyId} lookupAttempted={_petrifyLookupAttempted} lookupSucceeded={_petrifyLookupSucceeded} hitsObserved={_petrifyHitObservedCount} applied={_petrifyAppliedCount}.");
		((ModBase)this).Log.Info($"[Medusa] poison: SO='{(((Object)(object)_poisonSO != (Object)null) ? ((Object)_poisonSO).name : "<not-resolved>")}' poisonId={_poisonId} lookupAttempted={_poisonLookupAttempted} lookupSucceeded={_poisonLookupSucceeded} hitsObserved={_poisonHitObservedCount} applied={_poisonAppliedCount}.");
		((ModBase)this).Log.Info($"[Medusa] castFx: graphicsReady={CanSpawnClientFx()} recentKeys={_recentCastFx.Count} logCount={_castFxLogCount} lobbySwitchLogs={_lobbySwitchLogCount}.");
		((ModBase)this).Log.Info($"[Medusa] networkPrefab: assetId=0x{1296385109u:X8} logs={_networkPrefabLogCount} uiPaletteLogs={_abilityElementPaletteLogCount}.");
		LogAnimatorState();
	}

	private void OnAbilityCastStarted(CastStarted e)
	{
		try
		{
			if (e != null && !((Object)(object)e.Caster == (Object)null) && IsMedusaId(SafeIntValue(() => e.Caster.charId)))
			{
				int num = e.SlotId;
				if ((num < 0 || num > 3) && (Object)(object)e.Ability != (Object)null)
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
			if (!((Object)(object)val == (Object)null))
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
		return oldState >= 0 && oldState < 2 && (newState == 2 || newState == 3);
	}

	private static void TryRunMedusaAbilityDriverFromState(Ability? ability, int newState)
	{
		try
		{
			if (!TryGetMedusaAbilityContext(ability, out EntityManager caster, out int slot))
			{
				return;
			}
			MedusaMod? instance = _instance;
			if (instance == null)
			{
				return;
			}
			instance.RunAuthoredMedusaAbilityDriver(ability, caster, slot, $"Ability.SetState:{(AbilityStates)newState}");
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null && instance._abilityDriverLogCount < 32)
			{
				instance._abilityDriverLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] state ability driver failed: " + ex.Message);
			}
		}
	}

	private static void TryRunMedusaAbilityDriverFromCastFlag(CharAbilities? abilities, CastFlags castFlag, string source)
	{
		try
		{
			if ((Object)(object)abilities == (Object)null)
			{
				return;
			}
			EntityManager caster = abilities.entityManager;
			if ((Object)(object)caster == (Object)null || !IsMedusaId(SafeIntValue(() => caster.charId)))
			{
				return;
			}
			MedusaMod? instance = _instance;
			if (instance == null)
			{
				return;
			}
			ApplyMedusaAbilityRuntimeUi(abilities, source);
			instance.SuppressInheritedKitsuAbilityVfx(abilities, source);
			for (int slot = 0; slot <= 3; slot++)
			{
				CastFlags slotFlag = slot switch
				{
					0 => CastFlags.Ability1,
					1 => CastFlags.Ability2,
					2 => CastFlags.Ability3,
					3 => CastFlags.Ability4,
					_ => CastFlags.None
				};
				if (slotFlag == CastFlags.None || (castFlag & slotFlag) == 0)
				{
					continue;
				}
				Ability? ability = TryGetAbilityBySlot(abilities, slot);
				instance.RunAuthoredMedusaAbilityDriver(ability, caster, slot, source);
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null && instance._abilityDriverLogCount < 32)
			{
				instance._abilityDriverLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] cast flag ability driver failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static EntityManager? FindLocalMedusaEntity()
	{
		try
		{
			PlayerManager local = PlayerAPI.Local;
			EntityManager entity = (((Object)(object)local != (Object)null) ? local.primaryCharManager : null);
			if ((Object)(object)entity != (Object)null && IsMedusaId(SafeIntValue(() => entity.charId)))
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
					if ((Object)(object)entity2 != (Object)null && IsMedusaId(SafeIntValue(() => entity2.charId)))
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
		try
		{
			if ((Object)(object)abilities == (Object)null || slot < 0)
			{
				return null;
			}
			Il2CppReferenceArray<Ability> abilityArray = abilities.abilities;
			if (abilityArray == null || slot >= ((Il2CppArrayBase<Ability>)(object)abilityArray).Length)
			{
				return null;
			}
			return ((Il2CppArrayBase<Ability>)(object)abilityArray)[slot];
		}
		catch
		{
			return null;
		}
	}

	private static void TryEmitMedusaCastFx(Ability? ability, EntityManager? caster, int slot, string source)
	{
		try
		{
			MedusaMod instance = _instance;
			if (instance == null)
			{
				return;
			}
			if ((Object)(object)caster == (Object)null && (Object)(object)ability != (Object)null)
			{
				caster = ability.entityManager;
			}
			if ((Object)(object)caster == (Object)null || !IsMedusaId(SafeIntValue(() => caster.charId)))
			{
				return;
			}
			if ((slot < 0 || slot > 3) && (Object)(object)ability != (Object)null)
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
			MedusaMod? instance2 = _instance;
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
			MedusaMod? instance = _instance;
			if (instance == null)
			{
				return true;
			}
			instance.RunAuthoredMedusaAbilityDriver(ability, caster, slot, source);
			return true;
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null && instance._abilityDriverLogCount < 24)
			{
				instance._abilityDriverLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] inherited Kitsu Shoot intercept failed via " + source + ": " + ex.Message);
			}
			return false;
		}
	}

	private static bool TryGetMedusaAbilityContext(Ability? ability, out EntityManager caster, out int slot)
	{
		caster = null;
		slot = -1;
		try
		{
			if ((Object)(object)ability == (Object)null)
			{
				return false;
			}
			EntityManager resolvedCaster = ability.entityManager;
			if ((Object)(object)resolvedCaster == (Object)null || !IsMedusaId(SafeIntValue(() => resolvedCaster.charId)))
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
		if ((Object)(object)caster == (Object)null || slot < 0 || slot > 3)
		{
			return;
		}
		if (!ShouldRunAbilityDriver(ability, caster, slot))
		{
			return;
		}
		ApplyMedusaAbilityRuntimeUi(ability, source + ".driver");
		SuppressInheritedKitsuAbilityVfx(caster.charAbilities, source + ".driver");
		PlayMedusaAbilityAnimation(caster, slot, source);
		SpawnMedusaCastFx(caster, slot, ability);
		ReassertMedusaVisibilityAfterAbilityCast(caster, source);
		int hitCount = 0;
		if (IsAuthoritativeServer(caster))
		{
			hitCount = ApplyAuthoredMedusaGameplay(caster, slot, source);
		}
		if (_abilityDriverLogCount < 32)
		{
			_abilityDriverLogCount++;
			((ModBase)this).Log.Info($"[Medusa] authored ability driver via {source}: slot={slot} server={IsAuthoritativeServer(caster)} hits={hitCount}; inherited Kitsu Shoot suppressed.");
		}
	}

	private static void PlayMedusaAbilityAnimation(EntityManager caster, int slot, string source)
	{
		if (slot == 2)
		{
			return;
		}
		try
		{
			GameObject root = ((Component)caster).gameObject;
			Animator animator = FindMedusaAnimatorUnder(root.transform);
			if ((Object)(object)animator == (Object)null)
			{
				return;
			}
			string state = slot switch
			{
				0 => "Ability1",
				1 => "Ability2",
				3 => "Ability4",
				_ => string.Empty
			};
			if (state.Length == 0)
			{
				return;
			}
			animator.CrossFade(state, 0.05f, -1, 0f);
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null && instance._abilityDriverLogCount < 32)
			{
				instance._abilityDriverLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] ability animation failed via " + source + ": " + ex.Message);
			}
		}
	}

	private void ReassertMedusaVisibilityAfterAbilityCast(EntityManager caster, string source)
	{
		void Reassert(string suffix)
		{
			try
			{
				if ((Object)(object)caster == (Object)null)
				{
					return;
				}
				GameObject root = ((Component)caster).gameObject;
				GameObject visual = FindMedusaVisualObject(root);
				if ((Object)(object)visual == (Object)null)
				{
					return;
				}
				ForceMedusaCharMaterialVisible(root, visual, source + ".abilityVisibility" + suffix);
			}
			catch
			{
			}
		}

		try
		{
			Reassert("+now");
			TimerAPI.Once(0.03f, (Action)delegate { Reassert("+0.03s"); }, (ModBase)(object)this);
			TimerAPI.Once(0.12f, (Action)delegate { Reassert("+0.12s"); }, (ModBase)(object)this);
			TimerAPI.Once(0.30f, (Action)delegate { Reassert("+0.30s"); }, (ModBase)(object)this);
			TimerAPI.Once(0.70f, (Action)delegate { Reassert("+0.70s"); }, (ModBase)(object)this);
		}
		catch
		{
		}
	}

	private bool ShouldRunAbilityDriver(Ability? ability, EntityManager caster, int slot)
	{
		long casterIdentity = 0L;
		try
		{
			int ownerPlayerId = SafeIntValue(() => caster.ownerPlayerId);
			if (ownerPlayerId <= 0)
			{
				ownerPlayerId = SafeIntValue(() => caster.GetPlayerId());
			}
			if (ownerPlayerId > 0)
			{
				casterIdentity = ownerPlayerId;
			}
		}
		catch
		{
		}
		try
		{
			// Every runtime hook for one physical cast must resolve to the same key.
			// InputFallback has no Ability instance while SetCastAbility/SetState/Shoot do,
			// and local/auth entity wrappers can differ. Prefer the stable owner player id.
			if (casterIdentity == 0L)
			{
				casterIdentity = ((Il2CppObjectBase)caster).Pointer.ToInt64();
			}
		}
		catch
		{
		}
		if (casterIdentity == 0L)
		{
			try
			{
				if ((Object)(object)ability != (Object)null)
				{
					casterIdentity = ((Il2CppObjectBase)ability).Pointer.ToInt64();
				}
			}
			catch
			{
			}
		}
		long key = (casterIdentity << 4) ^ (slot & 15);
		float now;
		try
		{
			now = Time.unscaledTime;
		}
		catch
		{
			now = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
		}
		if (_recentAbilityDriver.TryGetValue(key, out var last) && now - last < 0.28f)
		{
			return false;
		}
		_recentAbilityDriver[key] = now;
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
		try
		{
			Vector3 origin = SafeEntityPosition(caster);
			Vector3 dir = SafeAimDirection(caster);
			int ownerPlayerId = SafeIntValue(() => caster.ownerPlayerId);
			if (ownerPlayerId <= 0)
			{
				ownerPlayerId = SafeIntValue(() => caster.GetPlayerId());
			}
			List<EntityManager> targets = FindMedusaAbilityTargets(caster, slot, origin, dir);
			int applied = 0;
			for (int i = 0; i < targets.Count; i++)
			{
				EntityManager target = targets[i];
				if ((Object)(object)target == (Object)null)
				{
					continue;
				}
				if (ApplyAuthoredMedusaHit(caster, target, slot, ownerPlayerId, origin, dir))
				{
					applied++;
				}
			}
			if (slot == 2)
			{
				ApplyMedusaSlitherMovement(caster, dir);
			}
			return applied;
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
		try
		{
			if ((Object)(object)caster.charMove == (Object)null)
			{
				return;
			}
			Vector3 delta = direction * 4.25f;
			caster.charMove.PostMove(delta, PostMoveTypes.Warp, false);
			if (_abilityDriverLogCount < 32)
			{
				_abilityDriverLogCount++;
				((ModBase)this).Log.Info($"[Medusa] Slither moved authoritative entity by ({delta.x:F1},{delta.y:F1},{delta.z:F1}).");
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
		List<EntityManager> targets = new List<EntityManager>();
		try
		{
			Il2CppArrayBase<EntityManager> entities = Object.FindObjectsOfType<EntityManager>();
			if (entities == null)
			{
				return targets;
			}
			for (int i = 0; i < entities.Length; i++)
			{
				EntityManager target = entities[i];
				if (!IsValidMedusaAbilityTarget(caster, target))
				{
					continue;
				}
				Vector3 pos = SafeEntityPosition(target);
				Vector3 delta = pos - origin;
				delta.y = 0f;
				float dist = delta.magnitude;
				if (dist < 0.01f)
				{
					continue;
				}
				Vector3 flatDir = dir;
				flatDir.y = 0f;
				if (flatDir.sqrMagnitude < 0.01f)
				{
					flatDir = Vector3.forward;
				}
				flatDir.Normalize();
				float forward = Vector3.Dot(delta, flatDir);
				float side = (delta - flatDir * forward).magnitude;
				bool hit = slot switch
				{
					0 => forward > 0f && forward <= 9.2f && side <= 0.9f,
					1 => forward > 0f && forward <= 6.0f && side <= 2.25f,
					2 => dist <= 2.75f,
					3 => forward > 0f && forward <= 11.5f && side <= 1.35f,
					_ => false
				};
				if (!hit)
				{
					continue;
				}
				targets.Add(target);
			}
			if (slot == 0 && targets.Count > 1)
			{
				targets.Sort((a, b) => Vector3.Distance(origin, SafeEntityPosition(a)).CompareTo(Vector3.Distance(origin, SafeEntityPosition(b))));
				while (targets.Count > 1)
				{
					targets.RemoveAt(targets.Count - 1);
				}
			}
		}
		catch
		{
		}
		return targets;
	}

	private static bool IsValidMedusaAbilityTarget(EntityManager caster, EntityManager target)
	{
		if ((Object)(object)caster == (Object)null || (Object)(object)target == (Object)null || (Object)(object)caster == (Object)(object)target)
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
			if ((Object)(object)target.charHurtbox == (Object)null || target.charHurtbox.isDead || target.charHurtbox.nonDamagable)
			{
				return false;
			}
		}
		catch
		{
		}
		int casterTeam = SafeIntValue(() => caster.entityTeamId);
		int targetTeam = SafeIntValue(() => target.entityTeamId);
		if (casterTeam >= 0 && targetTeam >= 0 && casterTeam == targetTeam)
		{
			return false;
		}
		int casterOwner = SafeIntValue(() => caster.ownerPlayerId);
		int targetOwner = SafeIntValue(() => target.ownerPlayerId);
		return casterOwner <= 0 || targetOwner <= 0 || casterOwner != targetOwner;
	}

	private bool ApplyAuthoredMedusaHit(EntityManager caster, EntityManager target, int slot, int ownerPlayerId, Vector3 origin, Vector3 dir)
	{
		try
		{
			CharHurtbox hurtbox = target.charHurtbox;
			if ((Object)(object)hurtbox == (Object)null)
			{
				return false;
			}
			StatusEffectInfo[] statusEffects = BuildMedusaStatusEffects(slot);
			Vector3 pushDir = SafeEntityPosition(target) - origin;
			pushDir.y = 0f;
			if (pushDir.sqrMagnitude < 0.01f)
			{
				pushDir = dir;
			}
			pushDir.Normalize();
			GameObject casterObj = null;
			try
			{
				casterObj = ((Component)caster).gameObject;
			}
			catch
			{
			}
			int damage = slot switch
			{
				0 => 120,
				1 => 85,
				2 => 70,
				3 => 160,
				_ => 0
			};
			hurtbox.ApplyHit(damage, statusEffects, ownerPlayerId, casterObj, false, false, true, true, false, pushDir, true, false, null);
			return true;
		}
		catch (Exception ex)
		{
			if (_abilityDriverLogCount < 32)
			{
				_abilityDriverLogCount++;
				((ModBase)this).Log.Warn($"[Medusa] authored hit failed: slot={slot} target='{ObjName(target)}': {ex.Message}");
			}
			return false;
		}
	}

	private static StatusEffectInfo[] BuildMedusaStatusEffects(int slot)
	{
		List<StatusEffectInfo> effects = new List<StatusEffectInfo>();
		try
		{
			if ((slot == 0 || slot == 1 || slot == 2) && TryResolvePoisonSO() && (Object)(object)_poisonSO != (Object)null)
			{
				effects.Add(new StatusEffectInfo(_poisonSO, slot == 1 ? 4.0f : 3.0f, 1f));
			}
			if (slot == 3 && TryResolvePetrifySO() && (Object)(object)_petrifySO != (Object)null)
			{
				effects.Add(new StatusEffectInfo(_petrifySO, 2.5f, 1f));
			}
		}
		catch
		{
		}
		return effects.Count == 0 ? Array.Empty<StatusEffectInfo>() : effects.ToArray();
	}

	private static Vector3 SafeEntityPosition(EntityManager entity)
	{
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
		try
		{
			CharAim aim = caster.charAim;
			if ((Object)(object)aim != (Object)null && aim.lookDir.sqrMagnitude > 0.01f)
			{
				Vector3 lookDir = aim.lookDir;
				lookDir.y = 0f;
				if (lookDir.sqrMagnitude > 0.01f)
				{
					lookDir.Normalize();
					return lookDir;
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
			if (forward.sqrMagnitude > 0.01f)
			{
				forward.Normalize();
				return forward;
			}
		}
		catch
		{
		}
		return Vector3.forward;
	}

	private bool ShouldEmitCastFx(Ability? ability, int slot)
	{
		long num = 0L;
		try
		{
			if ((Object)(object)ability != (Object)null)
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
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Unknown result type (might be due to invalid IL or missing references)
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0170: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_0206: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_022a: Unknown result type (might be due to invalid IL or missing references)
		//IL_022f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_027c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_030c: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Unknown result type (might be due to invalid IL or missing references)
		//IL_0318: Unknown result type (might be due to invalid IL or missing references)
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
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
		if ((Object)(object)val == (Object)null)
		{
			return;
		}
		Vector3 val2 = val.position + Vector3.up * 0.75f;
		Vector3 val3 = Vector3.zero;
		try
		{
			CharAim val4 = (((Object)(object)ability != (Object)null) ? ability.charAim : caster.charAim);
			if ((Object)(object)val4 != (Object)null)
			{
				val3 = val4.lookDir;
			}
		}
		catch
		{
		}
		if (val3.sqrMagnitude < 0.01f)
		{
			val3 = val.forward;
		}
		val3.y = 0f;
		if (val3.sqrMagnitude < 0.01f)
		{
			val3 = Vector3.forward;
		}
		val3.Normalize();
		if (TrySpawnNativeMedusaCastFx(val, val2, val3, slot))
		{
			if (_castFxLogCount < 20)
			{
				_castFxLogCount++;
				((ModBase)this).Log.Info($"[Medusa] native cast FX emitted: slot={slot} prefabCount={_medusaNativeVfxPrefabs.Count}.");
			}
			return;
		}
		if (_castFxLogCount < 20)
		{
			_castFxLogCount++;
			((ModBase)this).Log.Warn($"[Medusa] authored VFX unavailable for slot={slot}; green primitive fallback intentionally disabled.");
		}
	}

	private bool TrySpawnNativeMedusaCastFx(Transform casterTransform, Vector3 origin, Vector3 dir, int slot)
	{
		if (_medusaNativeVfxPrefabs.Count == 0)
		{
			return false;
		}
		try
		{
			Quaternion rotation = Quaternion.LookRotation(dir, Vector3.up);
			Vector3 ground = casterTransform.position + Vector3.up * 0.04f;
			bool spawned = false;
			switch (slot)
			{
			case 0:
				spawned |= SpawnNativeMedusaVfx(VfxMuzzleName, origin + dir * 0.45f, rotation, 1.25f);
				spawned |= SpawnNativeMedusaVfx(VfxTrailName, origin + dir * 2.2f, rotation, 1.0f);
				spawned |= SpawnNativeMedusaVfx(VfxHitName, origin + dir * 6.8f, rotation, 1.0f);
				break;
			case 1:
				spawned |= SpawnNativeMedusaVfx(VfxMuzzleName, origin + dir * 0.5f, rotation, 1.2f);
				spawned |= SpawnNativeMedusaVfx(VfxTrailName, origin + dir * 1.8f, rotation, 1.0f);
				spawned |= SpawnNativeMedusaVfx(VfxPuddleName, ground + dir * 2.8f, rotation, 2.4f);
				break;
			case 2:
				spawned |= SpawnNativeMedusaVfx(VfxEscapeName, ground, rotation, 1.4f);
				spawned |= SpawnNativeMedusaVfx(VfxTrailName, ground - dir * 1.2f + Vector3.up * 0.2f, rotation, 1.0f);
				spawned |= SpawnNativeMedusaVfx(VfxPuddleName, ground, rotation, 1.3f);
				break;
			case 3:
				spawned |= SpawnNativeMedusaVfx(VfxMuzzleName, origin + Vector3.up * 0.16f, rotation, 1.35f);
				spawned |= SpawnNativeMedusaVfx(VfxWallName, casterTransform.position + dir * 4.6f + Vector3.up * 0.04f, rotation, 1.8f);
				spawned |= SpawnNativeMedusaVfx(VfxHitName, origin + dir * 7.2f, rotation, 1.25f);
				break;
			}
			return spawned;
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] native cast FX failed: " + ex.Message);
			return false;
		}
	}

	private bool SpawnNativeMedusaVfx(string prefabName, Vector3 position, Quaternion rotation, float ttl)
	{
		GameObject? prefab = ResolveNativeMedusaVfxPrefab(prefabName);
		if ((Object)(object)prefab == (Object)null)
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
			GameObject val = Object.Instantiate<GameObject>(prefab);
			if ((Object)(object)val == (Object)null)
			{
				return false;
			}
			((Object)val).name = "MedusaFX_Native_" + prefabName;
			((Object)val).hideFlags = (HideFlags)52;
			val.transform.position = position;
			val.transform.rotation = rotation;
			val.transform.localScale = Vector3.one * NativeVfxRootScale(prefabName);
			DisableNativeVfxGameplay(val);
			val.SetActive(true);
			SanitizeNativeMedusaVfxRenderers(val, prefabName);
			Object.Destroy((Object)(object)val, ttl);
			if (_nativeVfxSpawnLogCount < 24)
			{
				_nativeVfxSpawnLogCount++;
				int particles = 0;
				int renderers = 0;
				try
				{
					particles = val.GetComponentsInChildren<ParticleSystem>(true).Length;
					renderers = val.GetComponentsInChildren<Renderer>(true).Length;
				}
				catch
				{
				}
				((ModBase)this).Log.Info($"[Medusa] native FX spawned: name='{prefabName}' particles={particles} renderers={renderers} ttl={ttl:F2}.");
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
		if (_medusaNativeVfxPrefabs.TryGetValue(prefabName, out var cached) && (Object)(object)cached != (Object)null)
		{
			return cached;
		}
		try
		{
			Il2CppSystem.Type goType = Il2CppType.Of<GameObject>();
			GameObject? reloaded = TryLoadAssetTyped(prefabName, goType)
				?? TryLoadAssetTyped("Assets/GameObject/MedusaVfx/" + prefabName + ".prefab", goType)
				?? TryLoadAssetTyped("Assets/GameObject/" + prefabName + ".prefab", goType);
			if ((Object)(object)reloaded != (Object)null)
			{
				_medusaNativeVfxPrefabs[prefabName] = reloaded;
				return reloaded;
			}
		}
		catch
		{
		}
		return null;
	}

	private static void DisableNativeVfxGameplay(GameObject root)
	{
		try
		{
			Il2CppArrayBase<Collider> componentsInChildren = root.GetComponentsInChildren<Collider>(true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				Collider val = componentsInChildren[i];
				if ((Object)(object)val != (Object)null)
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
				if ((Object)(object)val2 != (Object)null)
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
				if ((Object)(object)val3 == (Object)null)
				{
					continue;
				}
				string text = ((object)val3).GetType().Name ?? "";
				try
				{
					Il2CppSystem.Type il2CppType = ((Object)val3).GetIl2CppType();
					if (il2CppType != null)
					{
						text = ((Il2CppSystem.Reflection.MemberInfo)il2CppType).Name ?? text;
					}
				}
				catch
				{
				}
				if (text.IndexOf("Network", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Hitbox", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Damage", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Projectile", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Ability", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Gameplay", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Dps", StringComparison.OrdinalIgnoreCase) >= 0 || text.IndexOf("Spawner", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					val3.enabled = false;
				}
			}
		}
		catch
		{
		}
	}

	private static float NativeVfxRootScale(string prefabName)
	{
		if (string.Equals(prefabName, VfxPuddleName, StringComparison.OrdinalIgnoreCase))
		{
			return 0.55f;
		}
		if (string.Equals(prefabName, VfxTrailName, StringComparison.OrdinalIgnoreCase))
		{
			return 0.7f;
		}
		if (string.Equals(prefabName, VfxHitName, StringComparison.OrdinalIgnoreCase))
		{
			return 0.62f;
		}
		if (string.Equals(prefabName, VfxEscapeName, StringComparison.OrdinalIgnoreCase))
		{
			return 0.65f;
		}
		if (string.Equals(prefabName, VfxWallName, StringComparison.OrdinalIgnoreCase))
		{
			return 0.18f;
		}
		return 0.75f;
	}

	private static Color NativeVfxColor(string prefabName)
	{
		if (string.Equals(prefabName, VfxWallName, StringComparison.OrdinalIgnoreCase) ||
			string.Equals(prefabName, VfxHitName, StringComparison.OrdinalIgnoreCase))
		{
			return MedusaPetrifyFxColor;
		}
		if (string.Equals(prefabName, VfxPuddleName, StringComparison.OrdinalIgnoreCase))
		{
			return MedusaVenomPuddleColor;
		}
		return MedusaVenomFxColor;
	}

	private void SanitizeNativeMedusaVfxRenderers(GameObject root, string prefabName)
	{
		try
		{
			int rendererCount = 0;
			int enabledCount = 0;
			int repairedCount = 0;
			var shaderNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
			try
			{
				Il2CppArrayBase<ParticleSystem> particleSystems = root.GetComponentsInChildren<ParticleSystem>(true);
				for (int i = 0; i < particleSystems.Length; i++)
				{
					ParticleSystem ps = particleSystems[i];
					if ((Object)(object)ps == (Object)null)
					{
						continue;
					}
					ps.Clear(true);
					ps.Play(true);
					ps.Simulate(0.05f, true, false, true);
				}
			}
			catch
			{
			}
			Il2CppArrayBase<Renderer> renderers = root.GetComponentsInChildren<Renderer>(true);
			for (int i = 0; i < renderers.Length; i++)
			{
				Renderer renderer = renderers[i];
				if ((Object)(object)renderer == (Object)null)
				{
					continue;
				}
				rendererCount++;
				try
				{
					renderer.receiveShadows = false;
					renderer.shadowCastingMode = (UnityEngine.Rendering.ShadowCastingMode)0;
					if (ShouldReplaceNativeVfxRendererMaterial(renderer, prefabName))
					{
						Material? repaired = CreateNativeVfxReplacementMaterial(renderer, prefabName);
						if ((Object)(object)repaired != (Object)null)
						{
							renderer.sharedMaterial = repaired;
							renderer.enabled = true;
							repairedCount++;
						}
						else
						{
							renderer.enabled = false;
						}
					}
					if (renderer.enabled)
					{
						enabledCount++;
						Material activeMaterial = renderer.sharedMaterial;
						if ((Object)(object)activeMaterial == (Object)null)
						{
							activeMaterial = renderer.material;
						}
						Shader activeShader = ((Object)(object)activeMaterial != (Object)null) ? activeMaterial.shader : null;
						if ((Object)(object)activeShader != (Object)null)
						{
							shaderNames.Add(((Object)activeShader).name ?? "<unnamed>");
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
				((ModBase)this).Log.Info($"[Medusa] native FX renderer repair: name='{prefabName}' renderers={rendererCount} enabled={enabledCount} repaired={repairedCount} shaders=[{string.Join(", ", shaderNames)}].");
			}
		}
		catch (Exception ex)
		{
			if (_nativeVfxMaterialRepairLogCount < 24)
			{
				_nativeVfxMaterialRepairLogCount++;
				((ModBase)this).Log.Warn($"[Medusa] native FX renderer repair failed for '{prefabName}': {ex.Message}");
			}
		}
	}

	private Material? CreateNativeVfxReplacementMaterial(Renderer renderer, string prefabName)
	{
		Material? source = null;
		int cacheKey = 0;
		try
		{
			source = renderer.sharedMaterial;
			if ((Object)(object)source == (Object)null)
			{
				source = renderer.material;
			}
			if ((Object)(object)source != (Object)null)
			{
				cacheKey = ((Object)source).GetInstanceID();
				if (_nativeVfxReplacementMaterials.TryGetValue(cacheKey, out Material cached) &&
					(Object)(object)cached != (Object)null)
				{
					return cached;
				}
			}
		}
		catch
		{
		}

		Shader? replacementShader = null;
		string[] shaderCandidates =
		{
			"Universal Render Pipeline/Particles/Unlit",
			"Particles/Standard Unlit",
			"Legacy Shaders/Particles/Additive",
			"Sprites/Default"
		};
		for (int i = 0; i < shaderCandidates.Length; i++)
		{
			try
			{
				Shader candidate = Shader.Find(shaderCandidates[i]);
				if ((Object)(object)candidate != (Object)null && candidate.isSupported)
				{
					replacementShader = candidate;
					break;
				}
			}
			catch
			{
			}
		}
		if ((Object)(object)replacementShader == (Object)null)
		{
			return null;
		}

		Material replacement = new Material(replacementShader)
		{
			name = "MedusaVfxRuntime_" + prefabName,
			color = Color.white
		};

		Texture? sourceTexture = null;
		if ((Object)(object)source != (Object)null)
		{
			string[] sourceTextureProperties = { "_Tex", "_MainTex", "_BaseMap", "_EmissionMap" };
			for (int i = 0; i < sourceTextureProperties.Length; i++)
			{
				try
				{
					string property = sourceTextureProperties[i];
					if (source.HasProperty(property))
					{
						Texture texture = source.GetTexture(property);
						if ((Object)(object)texture != (Object)null)
						{
							sourceTexture = texture;
							break;
						}
					}
				}
				catch
				{
				}
			}
		}
		if ((Object)(object)sourceTexture != (Object)null)
		{
			string[] destinationTextureProperties = { "_BaseMap", "_MainTex" };
			for (int i = 0; i < destinationTextureProperties.Length; i++)
			{
				try
				{
					string property = destinationTextureProperties[i];
					if (replacement.HasProperty(property))
					{
						replacement.SetTexture(property, sourceTexture);
					}
				}
				catch
				{
				}
			}
		}

		try
		{
			if (replacement.HasProperty("_Surface"))
			{
				replacement.SetFloat("_Surface", 1f);
			}
			if (replacement.HasProperty("_Blend"))
			{
				replacement.SetFloat("_Blend", 0f);
			}
			if (replacement.HasProperty("_SrcBlend"))
			{
				replacement.SetInt("_SrcBlend", 5);
			}
			if (replacement.HasProperty("_DstBlend"))
			{
				replacement.SetInt("_DstBlend", 10);
			}
			if (replacement.HasProperty("_ZWrite"))
			{
				replacement.SetInt("_ZWrite", 0);
			}
			replacement.SetOverrideTag("RenderType", "Transparent");
			replacement.EnableKeyword("_SURFACE_TYPE_TRANSPARENT");
			replacement.EnableKeyword("_ALPHABLEND_ON");
			replacement.renderQueue = 3000;
		}
		catch
		{
		}
		if (cacheKey != 0)
		{
			_nativeVfxReplacementMaterials[cacheKey] = replacement;
		}
		return replacement;
	}

	private static bool ShouldReplaceNativeVfxRendererMaterial(Renderer renderer, string prefabName)
	{
		try
		{
			Material material = renderer.sharedMaterial;
			if ((Object)(object)material == (Object)null)
			{
				material = renderer.material;
			}
			if ((Object)(object)material == (Object)null)
			{
				return true;
			}
			Shader shader = material.shader;
			string shaderName = ((Object)(object)shader != (Object)null) ? ((Object)shader).name ?? string.Empty : string.Empty;
			if (shaderName.Length == 0 ||
				shaderName.IndexOf("InternalError", StringComparison.OrdinalIgnoreCase) >= 0 ||
				shaderName.IndexOf("/Lush/", StringComparison.OrdinalIgnoreCase) >= 0 ||
				shaderName.IndexOf("Uber_Particles", StringComparison.OrdinalIgnoreCase) >= 0)
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
			obj.SetPosition(1, origin + dir.normalized * length);
			obj.startWidth = width;
			obj.endWidth = width * 0.12f;
			obj.startColor = color;
			obj.endColor = new Color(color.r, color.g, color.b, 0f);
			((Renderer)obj).material = MakeFxMaterial(color, transparent: true);
			Object.Destroy((Object)val, ttl);
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
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
		try
		{
			GameObject obj = GameObject.CreatePrimitive((PrimitiveType)0);
			((Object)obj).name = "MedusaFX_" + name;
			((Object)obj).hideFlags = (HideFlags)52;
			obj.transform.position = pos;
			obj.transform.localScale = Vector3.one * radius;
			TryDestroyCollider(obj);
			ApplyMaterial(obj, color, transparent: true);
			Object.Destroy((Object)(object)obj, ttl);
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
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
		try
		{
			GameObject obj = GameObject.CreatePrimitive((PrimitiveType)2);
			((Object)obj).name = "MedusaFX_" + name;
			((Object)obj).hideFlags = (HideFlags)52;
			obj.transform.position = pos;
			obj.transform.localScale = new Vector3(radius, 0.035f, radius);
			TryDestroyCollider(obj);
			ApplyMaterial(obj, color, transparent: true);
			Object.Destroy((Object)(object)obj, ttl);
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] puddle FX failed: " + ex.Message);
			}
		}
	}

	private static void ApplyMaterial(GameObject go, Color color, bool transparent)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		Renderer component = go.GetComponent<Renderer>();
		if (!((Object)(object)component == (Object)null))
		{
			component.material = MakeFxMaterial(color, transparent);
		}
	}

	private static Material MakeFxMaterial(Color color, bool transparent)
	{
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		Shader val = null;
		try
		{
			val = Shader.Find("Sprites/Default");
		}
		catch
		{
		}
		if ((Object)(object)val == (Object)null)
		{
			try
			{
				val = Shader.Find("Unlit/Color");
			}
			catch
			{
			}
		}
		if ((Object)(object)val == (Object)null)
		{
			try
			{
				val = Shader.Find("Standard");
			}
			catch
			{
			}
		}
		Material val2 = (((Object)(object)val != (Object)null) ? new Material(val) : new Material(Shader.Find("Hidden/InternalErrorShader")));
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
		try
		{
			Collider component = go.GetComponent<Collider>();
			if ((Object)(object)component != (Object)null)
			{
				Object.Destroy((Object)(object)component);
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
		if (_registered)
		{
			try
			{
				UICharactersConfiguration val = explicitCfg ?? FindCharConfig();
				if ((Object)(object)val != (Object)null)
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
			UICharactersConfiguration val = explicitCfg ?? FindCharConfig();
			if ((Object)(object)val == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] UICharactersConfiguration not loaded yet.");
				return;
			}
			Il2CppReferenceArray<CharacterConfiguration> characters = val.Characters;
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
					CharacterConfiguration baseCfg = PickBase(characters);
					EnsureMedusaPrefabRegistered(baseCfg.charId, "TryRegisterMedusa.alreadyPresent");
					MoveMedusaIntoVisibleMatchSlot(val, "TryRegisterMedusa.alreadyPresent");
					MakeRosterAvailable(val);
					TuneCharAbilities(MedusaCharId);
					TryInjectPhrases();
					((ModBase)this).Log.Info($"[Medusa] already registered; verified prefab/pool/roster for CharId={MedusaCharId}.");
					return;
				}
			}
			CharacterConfiguration val2 = PickBase(characters);
			((ModBase)this).Log.Info($"[Medusa] cloning base character '{val2.name}' (charId={val2.charId}).");
			if (!EnsureMedusaPrefabRegistered(val2.charId, "TryRegisterMedusa"))
			{
				((ModBase)this).Log.Warn("[Medusa] could not register prefab; aborting.");
				return;
			}
			int medusaCharId = MedusaCharId;
			CharacterConfiguration item = CloneConfig(val2, medusaCharId);
			val._characters = Append(val._characters, item);
			val._lobbyCharacters = AppendLobby(val, item);
			MoveMedusaIntoVisibleMatchSlot(val, "TryRegisterMedusa.appended");
			MakeRosterAvailable(val);
			TuneCharAbilities(medusaCharId);
			TryInjectPhrases();
			_registered = true;
			((ModBase)this).Log.Info($"[Medusa] ✓ registered as CharId={medusaCharId}, name='{"Medusa"}'. Roster now {((Il2CppArrayBase<CharacterConfiguration>)(object)val.Characters).Length}.");
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
		CharacterConfiguration cfg = new CharacterConfiguration
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
		ApplyMedusaArtwork(cfg, b);
		return cfg;
	}

	private static AbilityData MakeAbility(AbilityData src, string titleKey, string shortKey, string descKey)
	{
		AbilityData data = new AbilityData();
		try
		{
			data.icon = src.icon;
		}
		catch
		{
		}
		data.titleKey = titleKey;
		data.shortDescriptionKey = shortKey;
		data.descriptionKey = descKey;
		return data;
	}

	private void ApplyMedusaArtwork(CharacterConfiguration cfg, CharacterConfiguration fallback)
	{
		try
		{
			Sprite portrait = LoadMedusaSprite("medusa-portrait.png", "medusa-card.png", "portrait.png", "card.png");
			if ((Object)(object)portrait != (Object)null)
			{
				cfg.smallSprite = portrait;
				cfg.IconSprite = portrait;
				cfg.CircleIcon = portrait;
				cfg.SquareIcon = portrait;
				cfg.SquareSmallIcon = portrait;
			}
			Sprite wide = LoadMedusaSprite("medusa-wide.png", "medusa-lobby.png", "wide.png", "lobby.png");
			if ((Object)(object)wide != (Object)null)
			{
				cfg.LobbyBackground = wide;
				cfg.FullSprite = wide;
				cfg.StandingSprite = wide;
			}
			if ((Object)(object)portrait != (Object)null || (Object)(object)wide != (Object)null)
			{
				((ModBase)this).Log.Info($"[Medusa] custom artwork applied: portrait={(Object)(object)portrait != (Object)null} wide={(Object)(object)wide != (Object)null}.");
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
		foreach (string name in names)
		{
			string path = ResolveMedusaUserDataFile(name);
			if (!File.Exists(path))
			{
				continue;
			}
			try
			{
				byte[] bytes = File.ReadAllBytes(path);
				Texture2D texture = new Texture2D(2, 2, (TextureFormat)4, false);
				if (!ImageConversion.LoadImage(texture, bytes))
				{
					continue;
				}
				((Object)texture).name = Path.GetFileNameWithoutExtension(path);
				texture.wrapMode = (TextureWrapMode)1;
				texture.filterMode = (FilterMode)1;
				Rect rect = new Rect(0f, 0f, texture.width, texture.height);
				Sprite sprite = Sprite.Create(texture, rect, new Vector2(0.5f, 0.5f), 100f);
				((Object)sprite).name = Path.GetFileNameWithoutExtension(path);
				return sprite;
			}
			catch (Exception ex)
			{
				((ModBase)this).Log.Warn("[Medusa] artwork load failed for '" + path + "': " + ex.Message);
			}
		}
		return null;
	}

	private static string ResolveMedusaUserDataFile(string fileName)
	{
		try
		{
			string bundlePath = ResolveBundlePath();
			string? bundleDir = Path.GetDirectoryName(bundlePath);
			if (!string.IsNullOrWhiteSpace(bundleDir))
			{
				return Path.Combine(bundleDir, fileName);
			}
		}
		catch
		{
		}
		return Path.Combine(AppContext.BaseDirectory, "UserData", "Medusa", fileName);
	}

	private void TuneCharAbilities(int charId)
	{
		try
		{
			GameNetworkManager val = Object.FindObjectOfType<GameNetworkManager>();
			if ((Object)(object)val == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] tune: GameNetworkManager not found.");
				return;
			}
			Il2CppReferenceArray<GameObject> characterPrefabsByCharId = val.characterPrefabsByCharId;
			if (characterPrefabsByCharId == null || charId < 0 || charId >= ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length || (Object)(object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[charId] == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] tune: prefab missing.");
				return;
			}
			GameObject prefab = ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[charId];
			int num = 0;
			try
			{
				num = ((Object)prefab).GetInstanceID();
			}
			catch
			{
			}
			CharAbilities componentInChildren = prefab.GetComponentInChildren<CharAbilities>(true);
			if ((Object)(object)componentInChildren == (Object)null)
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
		try
		{
			if ((Object)(object)abilities == (Object)null)
			{
				return;
			}
			GameObject root = ((Component)abilities).gameObject;
			if ((Object)(object)root == (Object)null)
			{
				return;
			}
			int rootId = GetUnityInstanceId(root);
			int suppressed = 0;
			foreach (CatShotAbility ability in root.GetComponentsInChildren<CatShotAbility>(true))
			{
				if ((Object)(object)ability == (Object)null)
				{
					continue;
				}
				if ((Object)(object)ability.vfxCastPrefab != (Object)null)
				{
					ability.vfxCastPrefab = null;
					suppressed++;
				}
				if ((Object)(object)ability.spellPrefab != (Object)null)
				{
					ability.spellPrefab = null;
					suppressed++;
				}
				if ((Object)(object)ability.catSpellPrefabSmall != (Object)null)
				{
					ability.catSpellPrefabSmall = null;
					suppressed++;
				}
				if ((Object)(object)ability.catSpellPrefabBig != (Object)null)
				{
					ability.catSpellPrefabBig = null;
					suppressed++;
				}
			}
			foreach (CatMissileAbility ability2 in root.GetComponentsInChildren<CatMissileAbility>(true))
			{
				if ((Object)(object)ability2 == (Object)null)
				{
					continue;
				}
				if ((Object)(object)ability2.vfxCastPrefab != (Object)null)
				{
					ability2.vfxCastPrefab = null;
					suppressed++;
				}
				if ((Object)(object)ability2.spellPrefab != (Object)null)
				{
					ability2.spellPrefab = null;
					suppressed++;
				}
			}
			foreach (CatPolymorphAbility ability3 in root.GetComponentsInChildren<CatPolymorphAbility>(true))
			{
				if ((Object)(object)ability3 == (Object)null)
				{
					continue;
				}
				if ((Object)(object)ability3.vfxCastPrefab != (Object)null)
				{
					ability3.vfxCastPrefab = null;
					suppressed++;
				}
				if ((Object)(object)ability3.spellPrefab != (Object)null)
				{
					ability3.spellPrefab = null;
					suppressed++;
				}
			}
			foreach (CatJumpAbility ability4 in root.GetComponentsInChildren<CatJumpAbility>(true))
			{
				if ((Object)(object)ability4 == (Object)null)
				{
					continue;
				}
				if ((Object)(object)ability4.vfxJumpPrefab != (Object)null)
				{
					ability4.vfxJumpPrefab = null;
					suppressed++;
				}
				if ((Object)(object)ability4.vfxLandPrefab != (Object)null)
				{
					ability4.vfxLandPrefab = null;
					suppressed++;
				}
				if ((Object)(object)ability4.spellPrefab != (Object)null)
				{
					ability4.spellPrefab = null;
					suppressed++;
				}
			}
			foreach (ArrowAbility arrow in root.GetComponentsInChildren<ArrowAbility>(true))
			{
				if ((Object)(object)arrow != (Object)null && (Object)(object)arrow.spellPrefab != (Object)null)
				{
					arrow.spellPrefab = null;
					suppressed++;
				}
			}
			foreach (ChargedArrowsAbility charged in root.GetComponentsInChildren<ChargedArrowsAbility>(true))
			{
				if ((Object)(object)charged == (Object)null)
				{
					continue;
				}
				if ((Object)(object)charged.spellPrefab != (Object)null)
				{
					charged.spellPrefab = null;
					suppressed++;
				}
				if ((Object)(object)charged.vfxCastPrefab != (Object)null)
				{
					charged.vfxCastPrefab = null;
					suppressed++;
				}
			}
			foreach (RecoilArrowAbility recoil in root.GetComponentsInChildren<RecoilArrowAbility>(true))
			{
				if ((Object)(object)recoil == (Object)null)
				{
					continue;
				}
				if ((Object)(object)recoil.spellPrefab != (Object)null)
				{
					recoil.spellPrefab = null;
					suppressed++;
				}
				if ((Object)(object)recoil.vfxJumpPrefab != (Object)null)
				{
					recoil.vfxJumpPrefab = null;
					suppressed++;
				}
				if ((Object)(object)recoil.vfxLandPrefab != (Object)null)
				{
					recoil.vfxLandPrefab = null;
					suppressed++;
				}
			}
			foreach (ArrowMissileAbility missile in root.GetComponentsInChildren<ArrowMissileAbility>(true))
			{
				if ((Object)(object)missile == (Object)null)
				{
					continue;
				}
				if ((Object)(object)missile.spellPrefab != (Object)null)
				{
					missile.spellPrefab = null;
					suppressed++;
				}
				if ((Object)(object)missile.vfxCastPrefab != (Object)null)
				{
					missile.vfxCastPrefab = null;
					suppressed++;
				}
			}
			if (rootId != 0 && suppressed > 0)
			{
				_suppressedInheritedVfxRoots.Add(rootId);
			}
			if (suppressed > 0 && _inheritedVfxSuppressLogCount < 12)
			{
				_inheritedVfxSuppressLogCount++;
				((ModBase)this).Log.Info($"[Medusa] suppressed {suppressed} inherited Kitsu VFX prefab reference(s) via {source} on '{((Object)root).name}'.");
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
		UICharactersConfiguration? obj = FindCharConfig();
		Il2CppReferenceArray<CharacterConfiguration> val2 = ((obj != null) ? obj.Characters : null);
		if (val2 != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)val2).Length > 0)
		{
			for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val2).Length; i++)
			{
				CharacterConfiguration val3 = ((Il2CppArrayBase<CharacterConfiguration>)(object)val2)[i];
				if (val3 != null)
				{
					return (AbilityData[])(object)new AbilityData[4]
					{
						MakeAbility(val3.ability1, "MEDUSA_AB_LMB_TITLE", "MEDUSA_AB_LMB_DESC_SHORT", "MEDUSA_AB_LMB_DESC"),
						MakeAbility(val3.ability2, "MEDUSA_AB_Q_TITLE", "MEDUSA_AB_Q_DESC_SHORT", "MEDUSA_AB_Q_DESC"),
						MakeAbility(val3.ability3, "MEDUSA_AB_SPACE_TITLE", "MEDUSA_AB_SPACE_DESC_SHORT", "MEDUSA_AB_SPACE_DESC"),
						MakeAbility(val3.ability4, "MEDUSA_AB_ULT_TITLE", "MEDUSA_AB_ULT_DESC_SHORT", "MEDUSA_AB_ULT_DESC")
					};
				}
			}
		}
		return Array.Empty<AbilityData>();
	}

	private static void ApplyMedusaAbilityRuntimeUi(CharAbilities? ca, string source)
	{
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)(object)ca == (Object)null)
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
				if (!((Object)(object)val == (Object)null))
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
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] runtime ability UI failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ApplyMedusaAbilityRuntimeUi(Ability? ability, string source)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)(object)ability == (Object)null)
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
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] ability runtime UI failed via " + source + ": " + ex.Message);
			}
		}
	}

	private void TryInjectPhrases()
	{
		if (_phrasesInjected)
		{
			return;
		}
		try
		{
			UIManager manager = UIAPI.Manager;
			Translator val = (((Object)(object)manager != (Object)null) ? manager.translator : null);
			if (val == null)
			{
				return;
			}
			Il2CppSystem.Collections.Generic.Dictionary<string, string> val2 = null;
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
		try
		{
			GameNetworkManager val = FindGameNetworkManager();
			if ((Object)(object)val == (Object)null)
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
			if (num2 < 0 || num2 >= ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length || (Object)(object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[num2] == (Object)null)
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
		try
		{
			GameNetworkManager instance = GameNetworkManager.Instance;
			if ((Object)(object)instance != (Object)null)
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
		try
		{
			if ((Object)(object)prefab == (Object)null)
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
				return (Object)(object)FindMedusaAnimatorUnder(prefab.transform) != (Object)null;
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
		if (prefabs == null)
		{
			return -1;
		}
		for (int i = 0; i < ((Il2CppArrayBase<GameObject>)(object)prefabs).Length; i++)
		{
			try
			{
				if ((Object)(object)((Il2CppArrayBase<GameObject>)(object)prefabs)[i] == (Object)null || !((Object)(object)((Il2CppArrayBase<GameObject>)(object)prefabs)[i].GetComponentInChildren<CharAbilities>(true) != (Object)null))
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
				if ((Object)(object)((Il2CppArrayBase<GameObject>)(object)prefabs)[j] != (Object)null)
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
		try
		{
			GameNetworkManager? manager = FindGameNetworkManager();
			if ((Object)(object)manager == (Object)null)
			{
				return 0;
			}

			Il2CppReferenceArray<GameObject> characterPrefabsByCharId = manager.characterPrefabsByCharId;
			int baseId = FindPreferredBasePrefabIndex(characterPrefabsByCharId);
			if (baseId >= 0)
			{
				return baseId;
			}

			baseId = FindFallbackBasePrefabIndex(characterPrefabsByCharId);
			return baseId >= 0 ? baseId : 0;
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
		if (prefabs == null)
		{
			return -1;
		}

		for (int i = 0; i < ((Il2CppArrayBase<GameObject>)(object)prefabs).Length; i++)
		{
			try
			{
				GameObject prefab = ((Il2CppArrayBase<GameObject>)(object)prefabs)[i];
				if ((Object)(object)prefab == (Object)null || IsMedusaPrefab(prefab))
				{
					continue;
				}

				string name = ((Object)prefab).name ?? string.Empty;
				if (name.IndexOf(BasePreference, StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return i;
				}
			}
			catch
			{
			}
		}

		return -1;
	}

	private int RegisterPrefab(int baseCharId)
	{
		try
		{
			GameNetworkManager val = Object.FindObjectOfType<GameNetworkManager>();
			if ((Object)(object)val == (Object)null)
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
			if ((Object)(object)val2 == (Object)null)
			{
				for (int i = 0; i < ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length; i++)
				{
					if ((Object)(object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[i] != (Object)null)
					{
						val2 = ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[i];
						break;
					}
				}
			}
			if ((Object)(object)val2 == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] no base prefab to clone.");
				return -1;
			}
			bool baseWasActive = false;
			try
			{
				baseWasActive = val2.activeSelf;
				if (baseWasActive)
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
					if (baseWasActive)
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
			Object.DontDestroyOnLoad((Object)(object)val3);
			GraftMedusaVisual(val3);
			TryConfigureMirrorPrefab(val3, "RegisterPrefab.clone", val);
			int num = ((15 >= ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length || (Object)(object)((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[15] == (Object)null) ? 15 : ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length);
			Il2CppReferenceArray<GameObject> val4 = new Il2CppReferenceArray<GameObject>((long)Math.Max(((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length, num + 1));
			for (int j = 0; j < ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId).Length; j++)
			{
				((Il2CppArrayBase<GameObject>)(object)val4)[j] = ((Il2CppArrayBase<GameObject>)(object)characterPrefabsByCharId)[j];
			}
			((Il2CppArrayBase<GameObject>)(object)val4)[num] = val3;
			val.characterPrefabsByCharId = val4;
			TryAddSpawnPrefab(val, val3, "RegisterPrefab.clone");
			((ModBase)this).Log.Info($"[Medusa] prefab cloned -> characterPrefabsByCharId[{num}] (visualGrafted={_bundleLoaded && (Object)(object)_medusaVisualPrefab != (Object)null}).");
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
		try
		{
			if ((Object)(object)prefab == (Object)null)
			{
				return false;
			}
			NetworkIdentity val = prefab.GetComponent<NetworkIdentity>();
			if ((Object)(object)val == (Object)null)
			{
				val = prefab.GetComponentInChildren<NetworkIdentity>(true);
			}
			if ((Object)(object)val == (Object)null)
			{
				((ModBase)this).Log.Warn($"[Medusa] Mirror prefab registration via {source}: NetworkIdentity missing on '{((Object)prefab).name}'.");
				return false;
			}
			uint value = 0u;
			ulong oldSceneId = 0uL;
			uint oldNetId = 0u;
			bool oldHasSpawned = false;
			bool oldSpawnedFromInstantiate = false;
			try
			{
				value = val._assetId;
			}
			catch
			{
			}
			try { oldSceneId = val.sceneId; } catch { }
			try { oldNetId = val._netId_k__BackingField; } catch { }
			try { oldHasSpawned = val.hasSpawned; } catch { }
			try { oldSpawnedFromInstantiate = val._SpawnedFromInstantiate_k__BackingField; } catch { }
			SanitizeMirrorIdentities(prefab, source);
			val._assetId = MedusaMirrorAssetId;
			if (!_mirrorClientPrefabRegistered)
			{
				_mirrorClientPrefabRegistered = true;
				if (!_mirrorClientSpawnPrefabsLogEmitted && _networkPrefabLogCount < 12)
				{
					_mirrorClientSpawnPrefabsLogEmitted = true;
					((ModBase)this).Log.Info($"[Medusa] Mirror client registration delegated to NetworkManager.spawnPrefabs for assetId=0x{MedusaMirrorAssetId:X8}; skipped direct NetworkClient.RegisterPrefab via {source}.");
				}
			}
			TryRegisterNetworkPrefabPool(gnm ?? FindGameNetworkManager(), prefab, source);
			if (_networkPrefabLogCount < 12)
			{
				_networkPrefabLogCount++;
				((ModBase)this).Log.Info($"[Medusa] Mirror prefab ready via {source}: prefab='{((Object)prefab).name}' oldAssetId=0x{value:X8} newAssetId=0x{MedusaMirrorAssetId:X8} oldSceneId={oldSceneId} oldNetId={oldNetId} oldHasSpawned={oldHasSpawned} oldSpawnedFromInstantiate={oldSpawnedFromInstantiate} sceneId={SafeULong(() => val.sceneId)} hasSpawned={SafeBool(() => val.hasSpawned)}.");
			}
			return true;
		}
		catch (Exception ex2)
		{
			((ModBase)this).Log.Warn("[Medusa] TryConfigureMirrorPrefab failed via " + source + ": " + ex2.Message);
			return false;
		}
	}

	private void SanitizeMirrorIdentities(GameObject prefab, string source)
	{
		try
		{
			int count = 0;
			Il2CppArrayBase<NetworkIdentity> identities = prefab.GetComponentsInChildren<NetworkIdentity>(true);
			if (identities != null)
			{
				for (int i = 0; i < identities.Length; i++)
				{
					NetworkIdentity identity = identities[i];
					if ((Object)(object)identity == (Object)null)
					{
						continue;
					}
					try { identity.sceneId = 0uL; } catch { }
					try { identity._netId_k__BackingField = 0u; } catch { }
					try { identity.hasSpawned = false; } catch { }
					try { identity._SpawnedFromInstantiate_k__BackingField = false; } catch { }
					try { identity.destroyCalled = false; } catch { }
					try { identity.serverOnly = false; } catch { }
					try { identity._connectionToServer_k__BackingField = null; } catch { }
					try { identity._connectionToClient = null; } catch { }
					try { identity.InitializeNetworkBehaviours(); } catch { }
					count++;
				}
			}
			if (_networkPrefabLogCount < 12)
			{
				((ModBase)this).Log.Info($"[Medusa] Mirror runtime identity sanitized via {source}: prefab='{((Object)prefab).name}' identities={count}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] SanitizeMirrorIdentities failed via " + source + ": " + ex.Message);
		}
	}

	private bool TryRegisterNetworkPrefabPool(GameNetworkManager? gnm, GameObject? prefab, string source)
	{
		try
		{
			if ((Object)(object)prefab == (Object)null)
			{
				return false;
			}
			NetworkPrefabPool.Config val = new NetworkPrefabPool.Config();
			val.prefab = prefab;
			val.initialSizeServer = 1;
			val.initialSizeClient = 1;
			val.resizeStrategy = NetworkPrefabPool.ResizeStrategy.Increment;
			bool flag = false;
			bool flag2 = false;
			try
			{
				bool patchPooledLibrary = false;
				try
				{
					patchPooledLibrary = Application.isBatchMode || NetworkServer.active;
				}
				catch
				{
				}
				if (patchPooledLibrary)
				{
					NetworkPrefabLibrary networkPrefabLibrary = ((Object)(object)gnm != (Object)null) ? gnm.networkPrefabLibrary : null;
					Il2CppReferenceArray<NetworkPrefabPool.Config> pooledPrefabs = ((Object)(object)networkPrefabLibrary != (Object)null) ? networkPrefabLibrary.PooledPrefabs : null;
					int num = (pooledPrefabs != null) ? ((Il2CppArrayBase<NetworkPrefabPool.Config>)(object)pooledPrefabs).Length : 0;
					NetworkPrefabPool.Config val2 = null;
					if (pooledPrefabs != null)
					{
						for (int i = 0; i < num; i++)
						{
							NetworkPrefabPool.Config val3 = ((Il2CppArrayBase<NetworkPrefabPool.Config>)(object)pooledPrefabs)[i];
							if (val3 == null)
							{
								continue;
							}
							GameObject val4 = null;
							try
							{
								val4 = val3.prefab;
							}
							catch
							{
							}
							if ((Object)(object)val4 == (Object)(object)prefab || IsMedusaPrefab(val4))
							{
								val2 = val3;
								flag = true;
								break;
							}
						}
					}
					if (val2 != null)
					{
						val = val2;
						val.prefab = prefab;
						val.initialSizeServer = Math.Max(val.initialSizeServer, 1);
						val.initialSizeClient = Math.Max(val.initialSizeClient, 1);
					}
					else if ((Object)(object)networkPrefabLibrary != (Object)null)
					{
						Il2CppReferenceArray<NetworkPrefabPool.Config> val5 = new Il2CppReferenceArray<NetworkPrefabPool.Config>((long)(num + 1));
						for (int j = 0; j < num; j++)
						{
							((Il2CppArrayBase<NetworkPrefabPool.Config>)(object)val5)[j] = ((Il2CppArrayBase<NetworkPrefabPool.Config>)(object)pooledPrefabs)[j];
						}
						((Il2CppArrayBase<NetworkPrefabPool.Config>)(object)val5)[num] = val;
						networkPrefabLibrary.PooledPrefabs = val5;
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
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			bool flag6 = false;
			try
			{
				flag5 = NetworkClient.active;
			}
			catch
			{
			}
			try
			{
				flag6 = NetworkServer.active;
			}
			catch
			{
			}
			if (num2 != 0 && flag5 && _mirrorClientPrefabRegistered)
			{
				_clientPoolRegisteredPrefabs.Add(num2);
			}
			else if (num2 != 0 && flag5 && !_clientPoolRegisteredPrefabs.Contains(num2))
			{
				try
				{
					NetworkPrefabPool.ClientCreate(val);
					_clientPoolRegisteredPrefabs.Add(num2);
					flag3 = true;
				}
				catch (Exception ex2)
				{
					((ModBase)this).Log.Warn("[Medusa] NetworkPrefabPool.ClientCreate failed via " + source + ": " + ex2.Message);
				}
			}
			if (num2 != 0 && flag6 && !_serverPoolRegisteredPrefabs.Contains(num2))
			{
				try
				{
					NetworkPrefabPool.ServerCreate(val);
					_serverPoolRegisteredPrefabs.Add(num2);
					flag4 = true;
				}
				catch (Exception ex3)
				{
					((ModBase)this).Log.Warn("[Medusa] NetworkPrefabPool.ServerCreate failed via " + source + ": " + ex3.Message);
				}
			}
			if (_networkPrefabLogCount < 16)
			{
				_networkPrefabLogCount++;
				((ModBase)this).Log.Info($"[Medusa] NetworkPrefabPool ready via {source}: prefab='{((Object)prefab).name}' libraryHad={flag} libraryAppended={flag2} clientActive={flag5} clientCreated={flag3} serverActive={flag6} serverCreated={flag4}.");
			}
			return flag || flag2 || flag3 || flag4;
		}
		catch (Exception ex4)
		{
			((ModBase)this).Log.Warn("[Medusa] TryRegisterNetworkPrefabPool failed via " + source + ": " + ex4.Message);
			return false;
		}
	}

	private bool TryAddSpawnPrefab(GameNetworkManager? gnm, GameObject? prefab, string source)
	{
		try
		{
			if ((Object)(object)gnm == (Object)null || (Object)(object)prefab == (Object)null)
			{
				return false;
			}
			Il2CppSystem.Collections.Generic.List<GameObject> spawnPrefabs = ((NetworkManager)gnm).spawnPrefabs;
			if (spawnPrefabs == null)
			{
				return false;
			}
			for (int i = 0; i < spawnPrefabs.Count; i++)
			{
				GameObject val = spawnPrefabs[i];
				if ((Object)(object)val == (Object)(object)prefab || IsMedusaPrefab(val))
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
			Il2CppSystem.Type goType = Il2CppType.Of<GameObject>();
			_medusaVisualPrefab = TryLoadAssetTyped("Medusa_Visual", goType);
			if ((Object)(object)_medusaVisualPrefab == (Object)null)
			{
				value = "loadAsset(by-path)";
				_medusaVisualPrefab = TryLoadAssetTyped("Assets/GameObject/Medusa_Visual.prefab", goType);
			}
			if ((Object)(object)_medusaVisualPrefab == (Object)null)
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
							if ((Object)(object)_medusaVisualPrefab != (Object)null)
							{
								break;
							}
						}
					}
				}
			}
			if ((Object)(object)_medusaVisualPrefab == (Object)null)
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
			_medusaAlbedoTexture = TryLoadTextureAsset("Medusa_Tex_Albedo_1024")
				?? TryLoadTextureAsset("Assets/Texture2D/Medusa_Tex_Albedo_1024.png")
				?? FindTextureAssetByName(assetNames, "Medusa_Tex_Albedo");
			_medusaNormalTexture = TryLoadTextureAsset("Medusa_Tex_Normal_1024")
				?? TryLoadTextureAsset("Assets/Texture2D/Medusa_Tex_Normal_1024.png")
				?? FindTextureAssetByName(assetNames, "Medusa_Tex_Normal");
			_medusaBundleMaterial = TryLoadMaterialAsset("Medusa_Material")
				?? TryLoadMaterialAsset("Assets/Material/Medusa_Material.mat")
				?? FindMaterialAssetByName(assetNames, "Medusa_Material");
			((ModBase)this).Log.Info($"[Medusa] cached bundle textures/material: albedo='{ObjName(_medusaAlbedoTexture)}' normal='{ObjName(_medusaNormalTexture)}' material='{ObjName(_medusaBundleMaterial)}'.");
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] cache bundle textures failed: " + ex.Message);
		}
	}

	private Texture? FindTextureAssetByName(Il2CppStringArray? assetNames, string contains)
	{
		if (assetNames == null)
		{
			return null;
		}
		for (int i = 0; i < ((Il2CppArrayBase<string>)(object)assetNames).Length; i++)
		{
			string text = ((Il2CppArrayBase<string>)(object)assetNames)[i];
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf(contains, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				Texture? texture = TryLoadTextureAsset(text);
				if ((Object)(object)texture != (Object)null)
				{
					return texture;
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
		if (assetNames == null)
		{
			return null;
		}
		for (int i = 0; i < ((Il2CppArrayBase<string>)(object)assetNames).Length; i++)
		{
			string text = ((Il2CppArrayBase<string>)(object)assetNames)[i];
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf(contains, StringComparison.OrdinalIgnoreCase) >= 0)
			{
				Material? material = TryLoadMaterialAsset(text);
				if ((Object)(object)material != (Object)null)
				{
					return material;
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

	private void LoadNativeMedusaVfxPrefabs(Il2CppStringArray? assetNames, Il2CppSystem.Type goType)
	{
		_medusaNativeVfxPrefabs.Clear();
		List<string> list = new List<string>();
		foreach (string text in NativeVfxNames)
		{
			GameObject val = TryLoadNativeVfxPrefab(text, assetNames, goType);
			if ((Object)(object)val == (Object)null)
			{
				continue;
			}
			_medusaNativeVfxPrefabs[text] = val;
			list.Add(((Object)val).name);
		}
		((ModBase)this).Log.Info($"[Medusa] native VFX prefabs loaded: {_medusaNativeVfxPrefabs.Count}/{NativeVfxNames.Length} [{string.Join(", ", list)}].");
	}

	private GameObject? TryLoadNativeVfxPrefab(string shortName, Il2CppStringArray? assetNames, Il2CppSystem.Type goType)
	{
		GameObject val = TryLoadAssetTyped(shortName, goType);
		if ((Object)(object)val != (Object)null)
		{
			return val;
		}
		val = TryLoadAssetTyped("Assets/GameObject/MedusaVfx/" + shortName + ".prefab", goType);
		if ((Object)(object)val != (Object)null)
		{
			return val;
		}
		val = TryLoadAssetTyped("Assets/GameObject/" + shortName + ".prefab", goType);
		if ((Object)(object)val != (Object)null)
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
			if (string.IsNullOrWhiteSpace(text) || text.IndexOf(shortName, StringComparison.OrdinalIgnoreCase) < 0)
			{
				continue;
			}
			val = TryLoadAssetTyped(text, goType);
			if ((Object)(object)val != (Object)null)
			{
				return val;
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
		string? best = null;
		long bestBytes = -1L;
		foreach (string item in candidates)
		{
			try
			{
				if (!File.Exists(item))
				{
					continue;
				}
				long bytes = new FileInfo(item).Length;
				if (bytes > bestBytes)
				{
					best = item;
					bestBytes = bytes;
				}
			}
			catch
			{
				if (best == null && File.Exists(item))
				{
					best = item;
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(best))
		{
			return best;
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

	private GameObject? TryLoadAssetTyped(string name, Il2CppSystem.Type goType)
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
		bounds = default(Bounds);
		bool result = false;
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return false;
			}
			foreach (Renderer componentsInChild in root.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null || (!includeMedusaVisual && IsUnderMedusaVisual(((Component)componentsInChild).transform)))
				{
					continue;
				}
				try
				{
					Bounds bounds2 = componentsInChild.bounds;
					if (bounds2.size.y <= 0.001f)
					{
						continue;
					}
					if (!result)
					{
						bounds = bounds2;
						result = true;
					}
					else
					{
						bounds.Encapsulate(bounds2);
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
		return result;
	}

	private static bool TryGetSkinnedRendererBounds(GameObject root, bool includeMedusaVisual, out Bounds bounds)
	{
		bounds = default(Bounds);
		bool result = false;
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return false;
			}
			foreach (SkinnedMeshRenderer componentsInChild in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null || (!includeMedusaVisual && IsUnderMedusaVisual(((Component)componentsInChild).transform)))
				{
					continue;
				}
				try
				{
					Bounds bounds2 = ((Renderer)componentsInChild).bounds;
					if (bounds2.size.y <= 0.001f)
					{
						continue;
					}
					if (!result)
					{
						bounds = bounds2;
						result = true;
					}
					else
					{
						bounds.Encapsulate(bounds2);
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
		return result;
	}

	private void FitMedusaVisualToBaseBounds(GameObject visual, bool hasBaseBounds, Bounds baseBounds, string source)
	{
		try
		{
			if ((Object)(object)visual == (Object)null)
			{
				return;
			}
			Bounds bounds = default(Bounds);
			bool flag = TryGetSkinnedRendererBounds(visual, includeMedusaVisual: true, out bounds);
			if (hasBaseBounds && flag && baseBounds.size.y > 0.001f && bounds.size.y > 0.001f)
			{
				float num = baseBounds.size.y * 0.98f;
				float num2 = ClampFloat(num / bounds.size.y, 0.02f, 1f);
				visual.transform.localScale = visual.transform.localScale * num2;
				if (TryGetSkinnedRendererBounds(visual, includeMedusaVisual: true, out bounds))
				{
					Vector3 val = new Vector3(baseBounds.center.x - bounds.center.x, baseBounds.min.y - bounds.min.y, baseBounds.center.z - bounds.center.z);
					visual.transform.position = visual.transform.position + val;
				}
				Vector3 localPosition = visual.transform.localPosition;
				bool flag2 = Mathf.Abs(localPosition.y) > 4f;
				bool flag3 = Mathf.Abs(localPosition.x) > 12f || Mathf.Abs(localPosition.z) > 60f;
				if (flag2 || flag3)
				{
					if (ShouldLogMedusaVisualFit(source))
					{
						((ModBase)this).Log.Warn($"[Medusa] visual fit via {source}: rejected excessive local offset ({localPosition.x:0.###},{localPosition.y:0.###},{localPosition.z:0.###}); restoring captured prefab visual transform.");
					}
					RestoreMedusaVisualDefaultTransform(visual, source);
				}
				else if (Mathf.Abs(localPosition.x) > 4f || Mathf.Abs(localPosition.z) > 4f)
				{
					if (ShouldLogMedusaVisualFit(source))
					{
						((ModBase)this).Log.Info($"[Medusa] visual fit via {source}: accepted large horizontal mesh offset ({localPosition.x:0.###},{localPosition.y:0.###},{localPosition.z:0.###}).");
					}
				}
				if (ShouldLogMedusaVisualFit(source))
				{
					((ModBase)this).Log.Info($"[Medusa] visual fit via {source}: skinnedBaseH={baseBounds.size.y:0.###} skinnedVisualH={bounds.size.y:0.###} scaleFactor={num2:0.###} localScale={visual.transform.localScale.x:0.###} localPos=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}).");
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
		string key = NormalizeVisualDiagnosticSource(source);
		if (!_visualFitSourcesLogged.Add(key))
		{
			return false;
		}
		_visualFitLogCount++;
		return true;
	}

	private void CaptureMedusaVisualDefaultTransform(GameObject visual, string source)
	{
		try
		{
			if ((Object)(object)visual == (Object)null)
			{
				return;
			}
			_medusaVisualDefaultLocalPosition = visual.transform.localPosition;
			_medusaVisualDefaultLocalRotation = visual.transform.localRotation;
			_medusaVisualDefaultLocalScale = visual.transform.localScale;
			_medusaVisualDefaultTransformCaptured = true;
			((ModBase)this).Log.Info($"[Medusa] visual default transform captured via {source}: localPos=({_medusaVisualDefaultLocalPosition.x:0.###},{_medusaVisualDefaultLocalPosition.y:0.###},{_medusaVisualDefaultLocalPosition.z:0.###}) localScale={_medusaVisualDefaultLocalScale.x:0.###}.");
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual default transform capture failed via " + source + ": " + ex.Message);
		}
	}

	private void RestoreMedusaVisualDefaultTransform(GameObject visual, string source)
	{
		try
		{
			if ((Object)(object)visual == (Object)null)
			{
				return;
			}
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
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual default transform restore failed via " + source + ": " + ex.Message);
		}
	}

	private static int ResolveCharacterRenderLayer(GameObject root)
	{
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return 0;
			}
			foreach (Renderer componentsInChild in root.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null || IsUnderMedusaVisual(((Component)componentsInChild).transform))
				{
					continue;
				}
				return ((Component)componentsInChild).gameObject.layer;
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
		try
		{
			if ((Object)(object)root == (Object)null || (Object)(object)visual == (Object)null)
			{
				return;
			}
			int layer = ResolveCharacterRenderLayer(root);
			int num = 0;
			foreach (Transform componentsInChild in visual.GetComponentsInChildren<Transform>(true))
			{
				if (!((Object)(object)componentsInChild == (Object)null))
				{
					((Component)componentsInChild).gameObject.layer = layer;
					num++;
				}
			}
			if (_visualLayerSyncLogCount < 12)
			{
				_visualLayerSyncLogCount++;
				string text = null;
				try
				{
					text = LayerMask.LayerToName(layer);
				}
				catch
				{
				}
				((ModBase)this).Log.Info($"[Medusa] visual layer sync via {source}: layer={layer} '{(string.IsNullOrEmpty(text) ? "<unnamed>" : text)}' objects={num}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual layer sync failed via " + source + ": " + ex.Message);
		}
	}

	private void BindMedusaVisualToCharMaterial(GameObject root, GameObject visual, string source)
	{
		try
		{
			if ((Object)(object)root == (Object)null || (Object)(object)visual == (Object)null)
			{
				return;
			}
			int rootId = GetUnityInstanceId(root);
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)(object)componentInChildren == (Object)null)
			{
				return;
			}
			if (rootId != 0 && _charMaterialBoundRoots.Contains(rootId) && IsCharMaterialBoundToVisual(root, visual))
			{
				ApplyCharacterRenderLayer(root, visual, source + ".alreadyBound");
				return;
			}
			List<Renderer> list = new List<Renderer>();
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if (!((Object)(object)componentsInChild == (Object)null))
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
				if (!((Object)(object)componentsInChild2 == (Object)null))
				{
					val = (Renderer)(object)componentsInChild2;
					break;
				}
			}
			if ((Object)(object)val == (Object)null)
			{
				val = list[0];
			}
			componentInChildren.charRigObj = visual;
			componentInChildren.charAnimatedRoot = visual.transform;
			try
			{
				Animator componentInChildren2 = visual.GetComponentInChildren<Animator>(true);
				if ((Object)(object)componentInChildren2 != (Object)null)
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
				if (!((Object)(object)val3 == (Object)(object)val) && num2 < num)
				{
					val2[num2++] = val3;
				}
			}
			componentInChildren.extraRenderers = val2;
			Bounds bounds;
			if (TryGetSkinnedRendererBounds(visual, includeMedusaVisual: true, out bounds))
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
			// CharMaterial's overlay setup moves the custom Medusa SMR to layer 26 on live match spawn.
			// That layer is not rendered by the normal gameplay camera, so keep Medusa on the character's
			// resolved render layer after rebinding the renderer fields.
			ApplyCharacterRenderLayer(root, visual, source + ".postCharMaterial");
			ForceMedusaCharMaterialVisible(root, visual, source + ".postCharMaterial");
			if (rootId != 0)
			{
				_charMaterialBoundRoots.Add(rootId);
			}
			if (_charMaterialBindLogCount < 12)
			{
				_charMaterialBindLogCount++;
				((ModBase)this).Log.Info($"[Medusa] CharMaterial rebound via {source}: primary='{((Object)((Component)val).gameObject).name}' primaryLayer={((Component)val).gameObject.layer} renderers={list.Count} extras={num2} customBounds={(bounds.size.y > 0.001f)}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] CharMaterial rebind failed via " + source + ": " + ex.Message);
		}
	}

	private void ForceMedusaCharMaterialVisible(GameObject root, GameObject visual, string source)
	{
		try
		{
			if ((Object)(object)root == (Object)null || (Object)(object)visual == (Object)null)
			{
				return;
			}
			int rootId = GetUnityInstanceId(root);
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)(object)componentInChildren == (Object)null)
			{
				return;
			}
			if (rootId != 0 && _charMaterialVisibleRoots.Contains(rootId) && !NeedsCharMaterialVisibilityRepair(root, visual))
			{
				return;
			}
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
			if (rootId != 0)
			{
				_charMaterialVisibleRoots.Add(rootId);
			}
			if (_materialVisibilityLogCount < 12)
			{
				_materialVisibilityLogCount++;
				((ModBase)this).Log.Info($"[Medusa] CharMaterial visibility forced via {source}: alpha=1 opaque=true partialHidden=false rendererActive=true visualActive={visual.activeInHierarchy}.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] CharMaterial visibility force failed via " + source + ": " + ex.Message);
		}
	}

	private GameObject? FindMedusaVisualObject(GameObject root)
	{
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return null;
			}
			foreach (Transform componentsInChild in root.GetComponentsInChildren<Transform>(true))
			{
				if (!((Object)(object)componentsInChild == (Object)null) && ((Object)componentsInChild).name == "Medusa_Visual")
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

	private static int GetUnityInstanceId(UnityEngine.Object? obj)
	{
		try
		{
			return (Object)(object)obj == (Object)null ? 0 : ((Object)obj).GetInstanceID();
		}
		catch
		{
			return 0;
		}
	}

	private static bool IsCharMaterialBoundToVisual(GameObject root, GameObject visual)
	{
		try
		{
			if ((Object)(object)root == (Object)null || (Object)(object)visual == (Object)null)
			{
				return false;
			}
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)(object)componentInChildren == (Object)null)
			{
				return true;
			}
			Renderer charRenderer = componentInChildren.charRenderer;
			if ((Object)(object)charRenderer == (Object)null)
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
		try
		{
			if ((Object)(object)root == (Object)null || (Object)(object)visual == (Object)null)
			{
				return false;
			}
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)(object)componentInChildren == (Object)null)
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
		try
		{
			int rootId = GetUnityInstanceId(root);
			if (rootId == 0 || !_stableLiveVisualRoots.Contains(rootId) || (Object)(object)visual == (Object)null || !visual.activeInHierarchy)
			{
				return false;
			}
			int num = 0;
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null)
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
			if (num == 0 || (Object)(object)FindMedusaAnimatorUnder(visual.transform) == (Object)null)
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
		try
		{
			int rootId = GetUnityInstanceId(root);
			if (rootId == 0)
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
			if (_stableVisualLastCheapCheckAt.TryGetValue(rootId, out var value) && num - value < 1f)
			{
				return;
			}
			_stableVisualLastCheapCheckAt[rootId] = num;
			if (_stableVisualLastCheapCheckAt.Count > 128)
			{
				_stableVisualLastCheapCheckAt.Clear();
			}
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null)
				{
					continue;
				}
				componentsInChild.enabled = true;
				try
				{
					componentsInChild.forceRenderingOff = false;
				}
				catch
				{
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
		int rootId = GetUnityInstanceId(root);
		int visualId = GetUnityInstanceId(visual);
		if (rootId != 0)
		{
			_stableLiveVisualRoots.Add(rootId);
		}
		if (visualId != 0)
		{
			_materialPreparedVisuals.Add(visualId);
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
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return null;
			}
			CharMaterial componentInChildren = root.GetComponentInChildren<CharMaterial>(true);
			if ((Object)(object)componentInChildren != (Object)null)
			{
				try
				{
					Transform charAnimatedRoot = componentInChildren.charAnimatedRoot;
					if ((Object)(object)charAnimatedRoot != (Object)null && !IsUnderMedusaVisual(charAnimatedRoot))
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
					if ((Object)(object)charRenderer != (Object)null)
					{
						Transform transform = ((Component)charRenderer).transform;
						if ((Object)(object)transform != (Object)null && !IsUnderMedusaVisual(transform))
						{
							Transform parent = transform.parent;
							if ((Object)(object)parent != (Object)null && !IsUnderMedusaVisual(parent))
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
			if ((Object)(object)componentInChildren2 != (Object)null)
			{
				try
				{
					Transform meshTransform = componentInChildren2.meshTransform;
					if ((Object)(object)meshTransform != (Object)null && !IsUnderMedusaVisual(meshTransform))
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
		try
		{
			if ((Object)(object)root == (Object)null || (Object)(object)visual == (Object)null)
			{
				return;
			}
			Transform val = ResolveMedusaVisualAnchor(root, source);
			if ((Object)(object)val == (Object)null)
			{
				val = root.transform;
			}
			Transform transform = visual.transform;
			if ((Object)(object)val == (Object)(object)transform || IsUnderMedusaVisual(val))
			{
				((ModBase)this).Log.Warn($"[Medusa] visual anchor via {source}: rejected self/visual-child anchor '{((Object)val).name}', falling back to root '{((Object)root).name}'.");
				val = root.transform;
			}
			string text = (((Object)(object)transform.parent != (Object)null) ? ((Object)transform.parent).name : "<none>");
			transform.SetParent(val, false);
			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;
			transform.localScale = Vector3.one;
			if (_visualAnchorLogCount < 12)
			{
				_visualAnchorLogCount++;
				((ModBase)this).Log.Info($"[Medusa] visual anchor via {source}: root='{((Object)root).name}' parent {text}->{((Object)val).name} localPos=({transform.localPosition.x:0.###},{transform.localPosition.y:0.###},{transform.localPosition.z:0.###}) worldPos=({transform.position.x:0.###},{transform.position.y:0.###},{transform.position.z:0.###}).");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual anchor failed via " + source + ": " + ex.Message);
		}
	}

	private void ForceMedusaVisualRenderable(GameObject visual, string source)
	{
		try
		{
			if ((Object)(object)visual == (Object)null)
			{
				return;
			}
			visual.SetActive(true);
			int num = 0;
			int num2 = 0;
			foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null)
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
				if ((Object)(object)componentsInChild2 == (Object)null)
				{
					continue;
				}
				try
				{
					componentsInChild2.updateWhenOffscreen = true;
					num3++;
				}
				catch
				{
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
		try
		{
			if ((Object)(object)root == (Object)null || (Object)(object)visual == (Object)null || _visualDiagnosticsLogCount >= 24)
			{
				return;
			}
			if (_liveLocalDiagnosticsSuccessLogged && IsHighFrequencyVisualDiagnosticSource(source))
			{
				return;
			}
			string diagnosticKey = NormalizeVisualDiagnosticSource(source);
			if (!_visualDiagnosticSourcesLogged.Add(diagnosticKey))
			{
				return;
			}
			_visualDiagnosticsLogCount++;
			int rendererCount = 0;
			int smrCount = 0;
			string firstRenderer = "<none>";
			int firstRendererLayer = -1;
			string firstSmr = "<none>";
			string meshName = "<none>";
			string rootBoneName = "<none>";
			string materialName = "<none>";
			string shaderName = "<none>";
			Bounds bounds = default(Bounds);
			bool hasBounds = false;
			foreach (Renderer renderer in visual.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)(object)renderer == (Object)null)
				{
					continue;
				}
				rendererCount++;
				if (firstRenderer == "<none>")
				{
					firstRenderer = ((Object)((Component)renderer).gameObject).name;
					firstRendererLayer = ((Component)renderer).gameObject.layer;
				}
				try
				{
					Bounds rb = renderer.bounds;
					if (rb.size.y > 0.001f)
					{
						if (!hasBounds)
						{
							bounds = rb;
							hasBounds = true;
						}
						else
						{
							bounds.Encapsulate(rb);
						}
					}
				}
				catch
				{
				}
			}
			foreach (SkinnedMeshRenderer smr in visual.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)(object)smr == (Object)null)
				{
					continue;
				}
				smrCount++;
				if (firstSmr == "<none>")
				{
					firstSmr = ((Object)((Component)smr).gameObject).name;
					try
					{
						meshName = ((Object)smr.sharedMesh).name;
					}
					catch
					{
					}
					try
					{
						rootBoneName = ((Object)smr.rootBone).name;
					}
					catch
					{
					}
					try
					{
						Material sharedMaterial = ((Renderer)smr).sharedMaterial;
						if ((Object)(object)sharedMaterial != (Object)null)
						{
							materialName = ((Object)sharedMaterial).name;
							shaderName = ((Object)sharedMaterial.shader).name;
						}
					}
					catch
					{
					}
				}
			}
			string screen = "<no-main-camera>";
			try
			{
				Camera main = Camera.main;
				if ((Object)(object)main != (Object)null)
				{
					Vector3 val = main.WorldToScreenPoint(hasBounds ? bounds.center : visual.transform.position);
					screen = $"{val.x:0.0},{val.y:0.0},{val.z:0.0}";
				}
			}
			catch
			{
			}
			((ModBase)this).Log.Info($"[Medusa] visual diagnostics via {source}: root='{((Object)root).name}' visualActive={visual.activeInHierarchy} layer={visual.layer} world=({visual.transform.position.x:0.###},{visual.transform.position.y:0.###},{visual.transform.position.z:0.###}) local=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}) scale=({visual.transform.localScale.x:0.###},{visual.transform.localScale.y:0.###},{visual.transform.localScale.z:0.###}) renderers={rendererCount} smrs={smrCount} firstRenderer='{firstRenderer}' firstRendererLayer={firstRendererLayer} firstSmr='{firstSmr}' mesh='{meshName}' rootBone='{rootBoneName}' material='{materialName}' shader='{shaderName}' bounds={(hasBounds ? $"{bounds.center.x:0.###},{bounds.center.y:0.###},{bounds.center.z:0.###}/{bounds.size.x:0.###},{bounds.size.y:0.###},{bounds.size.z:0.###}" : "<none>")} screen='{screen}'.");
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] visual diagnostics failed via " + source + ": " + ex.Message);
		}
	}

	private static bool IsHighFrequencyVisualDiagnosticSource(string source)
	{
		return source.StartsWith("PollOnce.", StringComparison.OrdinalIgnoreCase)
			|| source.StartsWith("PollOnce", StringComparison.OrdinalIgnoreCase);
	}

	private static string NormalizeVisualDiagnosticSource(string source)
	{
		int delayedSuffix = source.IndexOf('+');
		int existingPostFitSuffix = source.IndexOf(".existing.postFit", StringComparison.OrdinalIgnoreCase);
		if (delayedSuffix > 0 && existingPostFitSuffix > delayedSuffix)
		{
			return source[..delayedSuffix] + source[existingPostFitSuffix..];
		}
		int existingSuffix = source.IndexOf(".existing", StringComparison.OrdinalIgnoreCase);
		if (delayedSuffix > 0 && existingSuffix > delayedSuffix)
		{
			return source[..delayedSuffix] + source[existingSuffix..];
		}
		return source;
	}

	private void CopyMedusaMaterialProperties(Material material, string source)
	{
		try
		{
			Material? medusaMaterial = _medusaBundleMaterial;
			if ((Object)(object)material == (Object)null || (Object)(object)medusaMaterial == (Object)null)
			{
				return;
			}

			int copiedTextures = 0;
			int copiedColors = 0;
			int copiedFloats = 0;

			foreach (string prop in new[]
			{
				"_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap", "_BaseColorMap",
				"_DiffuseMap", "_DiffuseTex", "_ColorMap", "_MainTexture", "_Texture",
				"_Texture2D", "_CharTex", "_BodyTex", "_VariationTex",
				"_BumpMap", "_NormalMap", "_NormalTex", "_BumpTex"
			})
			{
				if (material.HasProperty(prop) && medusaMaterial.HasProperty(prop))
				{
					Texture texture = medusaMaterial.GetTexture(prop);
					if ((Object)(object)texture != (Object)null)
					{
						material.SetTexture(prop, texture);
						copiedTextures++;
					}
				}
			}

			foreach (string prop in new[]
			{
				"_AmbientColor", "_Color", "_BaseColor", "_TintColor", "_MainColor",
				"_HColor", "_SColor", "_ShadowColor", "_ShadowTint",
				"_SpecularColor", "_SpecularTint", "_FresnelColor", "_RimColor",
				"_EmissionColor", "_EmissionTint", "_CoverageColor"
			})
			{
				if (material.HasProperty(prop) && medusaMaterial.HasProperty(prop))
				{
					material.SetColor(prop, medusaMaterial.GetColor(prop));
					copiedColors++;
				}
			}

			foreach (string prop in new[]
			{
				"_BumpScale", "_NormalScale", "_LightingIntensity", "_AmbientContribution",
				"_ShadingThreshold", "_ShadingTreshold", "_ShadingSmooth", "_ShadingSoftness",
				"_RampShading", "_RampSmooth", "_RampThreshold",
				"_RimAmount", "_RimSmooth", "_RimThreshold",
				"_VariationHue", "_VariationMask", "_VariationValue", "_VariationScale",
				"_VariationStep", "_VariationStepOffset", "_VariationBlendMode",
				"_VariationHSVInfo", "_VariationInfo", "_VariationOverlayInfo",
				"_VariationAltBlendAmount", "_VariationExponent", "_VariationNoise",
				"_VariationOffset", "_VariationValueChannel", "_VariationHueChannel",
				"_SkipVariationValueMask"
			})
			{
				if (material.HasProperty(prop) && medusaMaterial.HasProperty(prop))
				{
					material.SetFloat(prop, medusaMaterial.GetFloat(prop));
					copiedFloats++;
				}
			}

			if ((copiedTextures > 0 || copiedColors > 0 || copiedFloats > 0) && _materialOverrideLogCount < 12)
			{
				_materialOverrideLogCount++;
				((ModBase)this).Log.Info($"[Medusa] copied bundle material props via {source}: target='{ObjName(material)}' textures={copiedTextures} colors={copiedColors} floats={copiedFloats} sourceMaterial='{ObjName(medusaMaterial)}'.");
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
		try
		{
			if ((Object)(object)material == (Object)null)
			{
				return;
			}
			CopyMedusaMaterialProperties(material, source);
			Texture? albedo = _medusaAlbedoTexture ?? albedoFallback;
			Texture? normal = _medusaNormalTexture ?? normalFallback;
			if ((Object)(object)albedo != (Object)null)
			{
				foreach (string prop in new[]
				{
					"_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap", "_BaseColorMap",
					"_DiffuseMap", "_DiffuseTex", "_ColorMap", "_MainTexture", "_Texture",
					"_Texture2D", "_CharTex", "_BodyTex", "_VariationTex"
				})
				{
					if (material.HasProperty(prop))
					{
						material.SetTexture(prop, albedo);
					}
				}
			}
			if ((Object)(object)normal != (Object)null)
			{
				foreach (string prop in new[] { "_BumpMap", "_NormalMap", "_NormalTex", "_BumpTex" })
				{
					if (material.HasProperty(prop))
					{
						material.SetTexture(prop, normal);
					}
				}
			}
			foreach (string prop in new[] { "_Color", "_BaseColor", "_TintColor", "_MainColor" })
			{
				if (material.HasProperty(prop))
				{
					material.SetColor(prop, Color.white);
				}
			}
			foreach (string prop in new[] { "_Alpha", "_Opacity", "_CoverageAlpha" })
			{
				if (material.HasProperty(prop))
				{
					material.SetFloat(prop, 1f);
				}
			}
			foreach (string prop in new[] { "_HitAmmount", "_HitAmount", "_HitBlinkAmount", "_IsEroded", "_FoWOccludeOverlay", "_MultiplyFoWToAlpha", "_MultiplyFoWToColor" })
			{
				if (material.HasProperty(prop))
				{
					material.SetFloat(prop, 0f);
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
		try
		{
			if ((Object)(object)visual == (Object)null)
			{
				return;
			}
			int visualId = GetUnityInstanceId(visual);
			if (visualId != 0 && _materialPreparedVisuals.Contains(visualId))
			{
				foreach (Renderer componentsInChild in visual.GetComponentsInChildren<Renderer>(true))
				{
					if ((Object)(object)componentsInChild == (Object)null)
					{
						continue;
					}
					componentsInChild.enabled = true;
					try
					{
						componentsInChild.forceRenderingOff = false;
					}
					catch
					{
					}
				}
				return;
			}
			int num = 0;
			string text = "<none>";
			foreach (SkinnedMeshRenderer componentsInChild in visual.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null)
				{
					continue;
				}
				try
				{
					componentsInChild.updateWhenOffscreen = true;
					componentsInChild.localBounds = new Bounds(Vector3.zero, Vector3.one * 8f);
					Renderer val = (Renderer)(object)componentsInChild;
					Material sharedMaterial = val.sharedMaterial;
					Texture val2 = null;
					if ((Object)(object)sharedMaterial != (Object)null)
					{
						string[] array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
						foreach (string text2 in array)
						{
							if (sharedMaterial.HasProperty(text2))
							{
								Texture texture = sharedMaterial.GetTexture(text2);
								if ((Object)(object)texture != (Object)null)
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
						string name = (((Object)(object)sharedMaterial != (Object)null && (Object)(object)sharedMaterial.shader != (Object)null) ? ((Object)sharedMaterial.shader).name : "");
						flag = string.IsNullOrEmpty(name) || name.StartsWith("Unlit/", StringComparison.OrdinalIgnoreCase) || string.Equals(name, "Standard", StringComparison.OrdinalIgnoreCase);
					}
					catch
					{
					}
					if (((Object)(object)_toonTemplateMaterial != (Object)null) && flag)
					{
						val3 = new Material(_toonTemplateMaterial);
						((Object)val3).name = "Medusa_Material_NativeVisible";
					}
					if ((Object)(object)val3 == (Object)null)
					{
						Shader shader = null;
						try
						{
							shader = Shader.Find("Standard");
						}
						catch
						{
						}
						if ((Object)(object)shader != (Object)null)
						{
							val3 = new Material(shader);
							((Object)val3).name = "Medusa_Material_FallbackVisible";
						}
					}
					if ((Object)(object)val3 != (Object)null)
					{
						if ((Object)(object)val2 != (Object)null)
						{
							string[] array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
							foreach (string text3 in array)
							{
								if (val3.HasProperty(text3))
								{
									val3.SetTexture(text3, val2);
								}
							}
						}
						string[] array2 = new string[4] { "_Color", "_BaseColor", "_TintColor", "_MainColor" };
						foreach (string text4 in array2)
						{
							if (val3.HasProperty(text4))
							{
								val3.SetColor(text4, new Color(1f, 1f, 1f, 1f));
							}
						}
						string[] array3 = new string[5] { "_Alpha", "_Opacity", "_Cutoff", "_Surface", "_ZWrite" };
						foreach (string text5 in array3)
						{
							if (val3.HasProperty(text5))
							{
								float value = (text5 == "_Cutoff" || text5 == "_Surface") ? 0f : 1f;
								val3.SetFloat(text5, value);
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
						text = (((Object)(object)val3.shader != (Object)null) ? ((Object)val3.shader).name : "<shader-null>");
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
				((ModBase)this).Log.Info($"[Medusa] material visibility via {source}: smrs={num} shader='{text}' localPos=({visual.transform.localPosition.x:0.###},{visual.transform.localPosition.y:0.###},{visual.transform.localPosition.z:0.###}).");
			}
			if (visualId != 0 && num > 0)
			{
				_materialPreparedVisuals.Add(visualId);
			}
		}
		catch (Exception ex2)
		{
			((ModBase)this).Log.Warn("[Medusa] material visibility failed via " + source + ": " + ex2.Message);
		}
	}

	private void GraftMedusaVisual(GameObject clone)
	{
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Expected O, but got Unknown
		try
		{
			if (!_bundleLoaded || (Object)(object)_medusaVisualPrefab == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] graft: bundle/visual not loaded; clone keeps base char's model.");
				return;
			}
			Material val = null;
			foreach (SkinnedMeshRenderer componentsInChild in clone.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if (!((Object)(object)componentsInChild == (Object)null))
				{
					Material sharedMaterial = ((Renderer)componentsInChild).sharedMaterial;
					if ((Object)(object)sharedMaterial != (Object)null && (Object)(object)sharedMaterial.shader != (Object)null)
					{
						val = sharedMaterial;
						_toonTemplateMaterial = sharedMaterial;
						_toonTemplateMaterialName = ((Object)sharedMaterial).name;
						((ModBase)this).Log.Info($"[Medusa] graft: captured native toon template - SMR='{((Object)componentsInChild).name}', material='{((Object)sharedMaterial).name}', shader='{((Object)sharedMaterial.shader).name}'.");
						break;
					}
				}
			}
			if ((Object)(object)val == (Object)null)
			{
				((ModBase)this).Log.Warn("[Medusa] graft: no base material to clone toon shader from; Medusa will keep her bundled Standard shader.");
			}
			Bounds baseBounds;
			bool hasBaseBounds = TryGetSkinnedRendererBounds(clone, includeMedusaVisual: false, out baseBounds);
			int value = DisableBaseCharacterRenderers(clone, "GraftMedusaVisual");
			((ModBase)this).Log.Info($"[Medusa] graft: disabled {value} base Renderer(s).");
			GameObject val2 = Object.Instantiate<GameObject>(_medusaVisualPrefab, clone.transform, false);
			((Object)val2).name = "Medusa_Visual";
			AnchorMedusaVisual(clone, val2, "GraftMedusaVisual");
			FitMedusaVisualToBaseBounds(val2, hasBaseBounds, baseBounds, "GraftMedusaVisual");
			CaptureMedusaVisualDefaultTransform(val2, "GraftMedusaVisual");
			ApplyCharacterRenderLayer(clone, val2, "GraftMedusaVisual");
			ForceMedusaVisualRenderable(val2, "GraftMedusaVisual");
			BindMedusaVisualToCharMaterial(clone, val2, "GraftMedusaVisual");
			int length = val2.GetComponentsInChildren<SkinnedMeshRenderer>(true).Length;
			Animator val3 = (_medusaAnimatorOnPrefab = val2.GetComponentInChildren<Animator>(true));
			CacheMedusaRuntimeController(val2, "GraftMedusaVisual");
			if ((Object)(object)val != (Object)null)
			{
				Il2CppArrayBase<SkinnedMeshRenderer> componentsInChildren = val2.GetComponentsInChildren<SkinnedMeshRenderer>(true);
				int num = 0;
				string name = ((Object)val.shader).name;
				foreach (SkinnedMeshRenderer item in componentsInChildren)
				{
					if ((Object)(object)item == (Object)null)
					{
						continue;
					}
					Material sharedMaterial2 = ((Renderer)item).sharedMaterial;
					Texture val4 = null;
					Texture val5 = null;
					string[] array;
					if ((Object)(object)sharedMaterial2 != (Object)null)
					{
						array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
						foreach (string text in array)
						{
							if (sharedMaterial2.HasProperty(text))
							{
								Texture texture = sharedMaterial2.GetTexture(text);
								if ((Object)(object)texture != (Object)null)
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
								if ((Object)(object)texture2 != (Object)null)
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
						if (val6.HasProperty(text3) && (Object)(object)val4 != (Object)null)
						{
							val6.SetTexture(text3, val4);
						}
					}
					array = new string[3] { "_BumpMap", "_NormalMap", "_NormalTex" };
					foreach (string text4 in array)
					{
						if (val6.HasProperty(text4) && (Object)(object)val5 != (Object)null)
						{
							val6.SetTexture(text4, val5);
						}
					}
					ApplyMedusaTextureOverrides(val6, val4, val5, "GraftMedusaVisual");
					((Renderer)item).sharedMaterial = val6;
					num++;
					((ModBase)this).Log.Info($"[Medusa] graft: shader applied to '{((Object)item).name}' (shader='{name}', albedo='{(((Object)(object)val4 != (Object)null) ? ((Object)val4).name : "<none>")}', normal='{(((Object)(object)val5 != (Object)null) ? ((Object)val5).name : "<none>")}').");
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
			if ((Object)(object)val3 != (Object)null)
			{
				Il2CppArrayBase<CharAnimator> componentsInChildren2 = clone.GetComponentsInChildren<CharAnimator>(true);
				int num2 = 0;
				foreach (CharAnimator item2 in componentsInChildren2)
				{
					if ((Object)(object)item2 == (Object)null)
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
					value2 = (((Object)(object)val3.runtimeAnimatorController != (Object)null) ? ((Object)val3.runtimeAnimatorController).name : "<null>");
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
						if (!((Object)(object)item3 == (Object)null))
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
					if (!((Object)(object)item4 == (Object)null) && !((Object)(object)item4 == (Object)(object)val3))
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
			((ModBase)this).Log.Info($"[Medusa] graft: instantiated Medusa_Visual under clone (SkinnedMeshRenderers={length}, animator={(((Object)(object)val3 != (Object)null) ? "yes" : "no")}, controller='{(((Object)(object)val3 != (Object)null && (Object)(object)val3.runtimeAnimatorController != (Object)null) ? ((Object)val3.runtimeAnimatorController).name : "?")}').");
		}
		catch (Exception ex6)
		{
			((ModBase)this).Log.Error("[Medusa] GraftMedusaVisual: " + ex6);
		}
	}

	private void EnsureLiveMedusaVisual(GameObject root, string source)
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		try
		{
			if ((Object)(object)root == (Object)null || !_bundleLoaded || (Object)(object)_medusaVisualPrefab == (Object)null)
			{
				return;
			}
			int rootId = GetUnityInstanceId(root);
			GameObject valVisual = FindMedusaVisualObject(root);
			if ((Object)(object)valVisual != (Object)null && IsLiveMedusaVisualStable(root, valVisual, source))
			{
				EnsureStableLiveMedusaVisualCheap(root, valVisual, source + ".stable");
				return;
			}
			if ((Object)(object)FindMedusaAnimatorUnder(root.transform) != (Object)null)
			{
				Bounds baseBoundsExisting;
				bool hasBaseBoundsExisting = TryGetSkinnedRendererBounds(root, includeMedusaVisual: false, out baseBoundsExisting);
				if ((Object)(object)valVisual != (Object)null)
				{
					AnchorMedusaVisual(root, valVisual, source + ".existing");
					FitMedusaVisualToBaseBounds(valVisual, hasBaseBoundsExisting, baseBoundsExisting, source + ".existing");
					ApplyCharacterRenderLayer(root, valVisual, source + ".existing");
					ForceMedusaVisualRenderable(valVisual, source + ".existing");
					if (rootId == 0 || !_charMaterialBoundRoots.Contains(rootId) || !IsCharMaterialBoundToVisual(root, valVisual))
					{
						BindMedusaVisualToCharMaterial(root, valVisual, source + ".existing");
					}
					ForceMedusaVisualMaterialVisibility(valVisual, source + ".existing.postCharMaterial");
					ForceMedusaVisualRenderable(valVisual, source + ".existing.postFit");
					if (rootId == 0 || !_charMaterialVisibleRoots.Contains(rootId) || NeedsCharMaterialVisibilityRepair(root, valVisual))
					{
						ForceMedusaCharMaterialVisible(root, valVisual, source + ".existing.postFit");
					}
					LogMedusaVisualDiagnostics(root, valVisual, source + ".existing.postFit");
					TryDismissLoadingOverlayAfterMedusaSpawn(source + ".existing");
					MarkLiveMedusaVisualStable(root, valVisual);
				}
				DisableBaseCharacterRenderers(root, source + ".existing");
				if (rootId == 0 || _runtimeReboundVisualRoots.Add(rootId))
				{
					RebindMedusaRuntime(root, source + ".existing");
				}
				return;
			}
			Material val = null;
			foreach (SkinnedMeshRenderer componentsInChild in root.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if (!((Object)(object)componentsInChild == (Object)null))
				{
					Material sharedMaterial = ((Renderer)componentsInChild).sharedMaterial;
					if ((Object)(object)sharedMaterial != (Object)null && (Object)(object)sharedMaterial.shader != (Object)null)
					{
						val = sharedMaterial;
						if ((Object)(object)_toonTemplateMaterial == (Object)null)
						{
							_toonTemplateMaterial = sharedMaterial;
						}
						break;
					}
				}
			}
			Bounds baseBounds;
			bool hasBaseBounds = TryGetSkinnedRendererBounds(root, includeMedusaVisual: false, out baseBounds);
			GameObject val2 = Object.Instantiate<GameObject>(_medusaVisualPrefab, root.transform, false);
			((Object)val2).name = "Medusa_Visual";
			AnchorMedusaVisual(root, val2, source + ".new");
			FitMedusaVisualToBaseBounds(val2, hasBaseBounds, baseBounds, source + ".new");
			ApplyCharacterRenderLayer(root, val2, source + ".new");
			ForceMedusaVisualRenderable(val2, source + ".new");
			BindMedusaVisualToCharMaterial(root, val2, source + ".new");
			CacheMedusaRuntimeController(val2, source + ".new");
			if ((Object)(object)val != (Object)null)
			{
				foreach (SkinnedMeshRenderer componentsInChild2 in val2.GetComponentsInChildren<SkinnedMeshRenderer>(true))
				{
					if ((Object)(object)componentsInChild2 == (Object)null)
					{
						continue;
					}
					Material sharedMaterial2 = ((Renderer)componentsInChild2).sharedMaterial;
					Texture val3 = null;
					Texture val4 = null;
					string[] array;
					if ((Object)(object)sharedMaterial2 != (Object)null)
					{
						array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
						foreach (string text in array)
						{
							if (sharedMaterial2.HasProperty(text))
							{
								val3 = sharedMaterial2.GetTexture(text);
								if ((Object)(object)val3 != (Object)null)
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
								val4 = sharedMaterial2.GetTexture(text2);
								if ((Object)(object)val4 != (Object)null)
								{
									break;
								}
							}
						}
					}
					Material val5 = new Material(val)
					{
						name = "Medusa_Material_Native_Live"
					};
					array = new string[4] { "_MainTex", "_BaseMap", "_AlbedoTex", "_AlbedoMap" };
					foreach (string text3 in array)
					{
						if ((Object)(object)val3 != (Object)null && val5.HasProperty(text3))
						{
							val5.SetTexture(text3, val3);
						}
					}
					array = new string[3] { "_BumpMap", "_NormalMap", "_NormalTex" };
					foreach (string text4 in array)
					{
						if ((Object)(object)val4 != (Object)null && val5.HasProperty(text4))
						{
							val5.SetTexture(text4, val4);
						}
					}
					ApplyMedusaTextureOverrides(val5, val3, val4, source + ".new");
					((Renderer)componentsInChild2).sharedMaterial = val5;
				}
			}
			ForceMedusaVisualMaterialVisibility(val2, source + ".new.postShader");
			ForceMedusaVisualRenderable(val2, source + ".new.postMaterial");
			ForceMedusaCharMaterialVisible(root, val2, source + ".new.postMaterial");
			int value = DisableBaseCharacterRenderers(root, source + ".new");
			ForceMedusaVisualMaterialVisibility(val2, source + ".new.postBaseHide");
			ForceMedusaVisualRenderable(val2, source + ".new.postBaseHide");
			ForceMedusaCharMaterialVisible(root, val2, source + ".new.postBaseHide");
			LogMedusaVisualDiagnostics(root, val2, source + ".new.postMaterial");
			TryDismissLoadingOverlayAfterMedusaSpawn(source + ".new");
			if (rootId == 0 || _runtimeReboundVisualRoots.Add(rootId))
			{
				RebindMedusaRuntime(root, source + ".new");
			}
			MarkLiveMedusaVisualStable(root, val2);
			if (_liveGraftLogCount < 10)
			{
				_liveGraftLogCount++;
				((ModBase)this).Log.Info($"[Medusa] live visual graft via {source}: root='{((Object)root).name}' disabledBaseSmr={value} shaderTemplate='{(((Object)(object)val != (Object)null) ? ((Object)val).name : "<none>")}'.");
			}
		}
		catch (Exception ex)
		{
			((ModBase)this).Log.Warn("[Medusa] EnsureLiveMedusaVisual failed via " + source + ": " + ex.Message);
		}
	}

	private void TryDismissLoadingOverlayAfterMedusaSpawn(string source)
	{
		try
		{
			float now;
			try
			{
				now = Time.unscaledTime;
			}
			catch
			{
				now = (float)DateTime.UtcNow.TimeOfDay.TotalSeconds;
			}
			if (_lastLoadingOverlayDismissScanAt > 0f && now - _lastLoadingOverlayDismissScanAt < 3f)
			{
				return;
			}
			_lastLoadingOverlayDismissScanAt = now;

			int hidden = 0;
			HashSet<int> touched = new HashSet<int>();
			foreach (GameObject gameObject2 in Object.FindObjectsOfType<GameObject>(true))
			{
				if ((Object)(object)gameObject2 == (Object)null || !IsLoadingOverlayObject(gameObject2))
				{
					continue;
				}

				GameObject target = ResolveLoadingOverlayTarget(gameObject2);
				int targetId = target.GetInstanceID();
				if (touched.Add(targetId) && _dismissedLoadingOverlayTargets.Add(targetId))
				{
					hidden += HideLoadingOverlayObject(target);
				}
			}
			if (hidden > 0 && _loadingOverlayHideLogCount < 6)
			{
				_loadingOverlayHideLogCount++;
				((ModBase)this).Log.Info($"[Medusa] dismissed {hidden} loading overlay object(s) after live spawn via {source}.");
			}
			else if (hidden == 0 && _loadingOverlayHideLogCount < 2)
			{
				_loadingOverlayHideLogCount++;
				((ModBase)this).Log.Info($"[Medusa] no loading overlay candidates found after live spawn via {source}.");
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
		if ((Object)(object)gameObject == (Object)null)
		{
			return false;
		}

		string path = GetTransformPath(gameObject.transform);
		if (path.IndexOf("Loading", StringComparison.OrdinalIgnoreCase) >= 0 ||
			path.IndexOf("UILobbySplashScreen", StringComparison.OrdinalIgnoreCase) >= 0 ||
			path.IndexOf("GameStarting", StringComparison.OrdinalIgnoreCase) >= 0 ||
			path.IndexOf("Game Starting", StringComparison.OrdinalIgnoreCase) >= 0 ||
			path.IndexOf("Starting Game", StringComparison.OrdinalIgnoreCase) >= 0 ||
			path.IndexOf("Game is Starting", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}

		return ContainsLoadingText(gameObject, includeChildren: false);
	}

	private static GameObject ResolveLoadingOverlayTarget(GameObject gameObject)
	{
		Canvas componentInParent = gameObject.GetComponentInParent<Canvas>();
		if ((Object)(object)componentInParent == (Object)null || gameObject.transform == ((Component)componentInParent).transform)
		{
			return gameObject;
		}

		Transform transform = gameObject.transform;
		Transform transform2 = null;
		while ((Object)(object)transform.parent != (Object)null && transform.parent != ((Component)componentInParent).transform)
		{
			string name = ((Object)transform).name ?? "";
			if (name.IndexOf("Loading", StringComparison.OrdinalIgnoreCase) >= 0 ||
				name.IndexOf("UILobbySplashScreen", StringComparison.OrdinalIgnoreCase) >= 0 ||
				name.IndexOf("GameStarting", StringComparison.OrdinalIgnoreCase) >= 0 ||
				name.IndexOf("GameStart", StringComparison.OrdinalIgnoreCase) >= 0 ||
				name.IndexOf("Starting Game", StringComparison.OrdinalIgnoreCase) >= 0 ||
				name.IndexOf("Game is Starting", StringComparison.OrdinalIgnoreCase) >= 0)
			{
				transform2 = transform;
			}
			transform = transform.parent;
		}
		if ((Object)(object)transform2 != (Object)null)
		{
			return ((Component)transform2).gameObject;
		}
		if (ContainsLoadingText(gameObject, includeChildren: false) && (Object)(object)gameObject.transform.parent != (Object)null)
		{
			return ((Component)gameObject.transform.parent).gameObject;
		}
		return gameObject;
	}

	private static bool ContainsLoadingText(GameObject gameObject, bool includeChildren = true)
	{
		try
		{
			IEnumerable<Component> components = includeChildren ? gameObject.GetComponentsInChildren<Component>(true) : gameObject.GetComponents<Component>();
			foreach (Component componentsInChild in components)
			{
				if ((Object)(object)componentsInChild == (Object)null)
				{
					continue;
				}

				Type type = componentsInChild.GetType();
				if (type.Name.IndexOf("Text", StringComparison.OrdinalIgnoreCase) < 0 &&
					type.Name.IndexOf("Label", StringComparison.OrdinalIgnoreCase) < 0)
				{
					continue;
				}

				object textValue = TryReadStringProperty(componentsInChild, "text") ?? TryReadStringProperty(componentsInChild, "m_text");
				if (textValue is string text && IsBlockingOverlayText(text))
				{
					return true;
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
		return text.IndexOf("Loading", StringComparison.OrdinalIgnoreCase) >= 0 ||
			text.IndexOf("Game Starting", StringComparison.OrdinalIgnoreCase) >= 0 ||
			text.IndexOf("Game is Starting", StringComparison.OrdinalIgnoreCase) >= 0 ||
			text.IndexOf("Starting Game", StringComparison.OrdinalIgnoreCase) >= 0;
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
		int num = 0;
		try
		{
			foreach (CanvasGroup componentsInChild in gameObject.GetComponentsInChildren<CanvasGroup>(true))
			{
				if (!((Object)(object)componentsInChild == (Object)null))
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
		List<string> list = new List<string>();
		Transform val = transform;
		while ((Object)(object)val != (Object)null)
		{
			list.Add(((Object)val).name);
			val = val.parent;
		}
		list.Reverse();
		return string.Join("/", list);
	}

	private static int DisableBaseCharacterRenderers(GameObject root, string source)
	{
		int num = 0;
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return 0;
			}
			foreach (Renderer componentsInChild in root.GetComponentsInChildren<Renderer>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null || IsUnderMedusaVisual(((Component)componentsInChild).transform))
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
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] DisableBaseCharacterRenderers failed via " + source + ": " + ex.Message);
			}
		}
		return num;
	}

	private static bool IsUnderMedusaVisual(Transform? t)
	{
		try
		{
			while ((Object)(object)t != (Object)null)
			{
				string name = ((Object)t).name ?? "";
				if (string.Equals(name, "Medusa_Visual", StringComparison.Ordinal) ||
					string.Equals(name, "MedusaBase", StringComparison.Ordinal) ||
					name.StartsWith("Medusa_Visual", StringComparison.Ordinal) ||
					name.StartsWith("MedusaBase", StringComparison.Ordinal))
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
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return null;
			}
			foreach (Animator componentsInChild in ((Component)root).GetComponentsInChildren<Animator>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null)
				{
					continue;
				}
				try
				{
					RuntimeAnimatorController runtimeAnimatorController = componentsInChild.runtimeAnimatorController;
					if (IsMedusaRuntimeController(runtimeAnimatorController))
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
					while ((Object)(object)val != (Object)null && (Object)(object)val != (Object)(object)root.parent)
					{
						if (((Object)val).name == "Medusa_Visual")
						{
							flag = true;
							break;
						}
						if (!((Object)(object)val == (Object)(object)root))
						{
							val = val.parent;
							continue;
						}
						break;
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
		try
		{
			if ((Object)(object)controller == (Object)null)
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
		try
		{
			if (IsMedusaRuntimeController(_medusaRuntimeController))
			{
				return _medusaRuntimeController;
			}
			if ((Object)(object)_medusaAnimatorOnPrefab != (Object)null && IsMedusaRuntimeController(_medusaAnimatorOnPrefab.runtimeAnimatorController))
			{
				_medusaRuntimeController = _medusaAnimatorOnPrefab.runtimeAnimatorController;
				return _medusaRuntimeController;
			}
			if ((Object)(object)_medusaVisualPrefab != (Object)null)
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
		try
		{
			if ((Object)(object)visual == (Object)null)
			{
				return null;
			}
			foreach (Animator componentsInChild in visual.GetComponentsInChildren<Animator>(true))
			{
				if ((Object)(object)componentsInChild == (Object)null)
				{
					continue;
				}
				RuntimeAnimatorController runtimeAnimatorController = null;
				try
				{
					runtimeAnimatorController = componentsInChild.runtimeAnimatorController;
				}
				catch
				{
				}
				if (IsMedusaRuntimeController(runtimeAnimatorController))
				{
					_medusaAnimatorOnPrefab = componentsInChild;
					_medusaRuntimeController = runtimeAnimatorController;
					if (_animatorRepairLogCount < 8)
					{
						_animatorRepairLogCount++;
						((ModBase)this).Log.Info($"[Medusa] cached animator controller via {source}: animator='{((Object)((Component)componentsInChild).gameObject).name}' controller='{((Object)runtimeAnimatorController).name}'.");
					}
					return runtimeAnimatorController;
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
		try
		{
			if ((Object)(object)animator == (Object)null)
			{
				return false;
			}
			if (IsMedusaRuntimeController(animator.runtimeAnimatorController))
			{
				return true;
			}
			MedusaMod instance = _instance;
			RuntimeAnimatorController runtimeAnimatorController = instance?.ResolveMedusaRuntimeController();
			if (!IsMedusaRuntimeController(runtimeAnimatorController))
			{
				return false;
			}
			animator.runtimeAnimatorController = runtimeAnimatorController;
			if (instance != null && instance._animatorRepairLogCount < 8)
			{
				instance._animatorRepairLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] animator controller repaired via {source}: animator='{((Object)((Component)animator).gameObject).name}' controller='{((Object)runtimeAnimatorController).name}'.");
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
		try
		{
			if ((Object)(object)root == (Object)null)
			{
				return;
			}
			Animator val = FindMedusaAnimatorUnder(root.transform);
			if ((Object)(object)val == (Object)null)
			{
				return;
			}
			int num = 0;
			foreach (CharAnimator componentsInChild in root.GetComponentsInChildren<CharAnimator>(true))
			{
				if (!((Object)(object)componentsInChild == (Object)null))
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
				if (!((Object)(object)componentsInChild2 == (Object)null))
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
				if (!((Object)(object)componentsInChild3 == (Object)null) && !((Object)(object)componentsInChild3 == (Object)(object)val))
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
				((ModBase)instance).Log.Info($"[Medusa] live rebind via {source}: root='{((Object)root).name}' charAnim={num} footsteps={num2} controller='{(((Object)(object)val.runtimeAnimatorController != (Object)null) ? ((Object)val.runtimeAnimatorController).name : "?")}'.");
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] RebindMedusaRuntime failed via " + source + ": " + ex.Message);
			}
		}
	}

	public void LogAnimatorState()
	{
		try
		{
			if ((Object)(object)_medusaAnimatorOnPrefab != (Object)null)
			{
				Animator medusaAnimatorOnPrefab = _medusaAnimatorOnPrefab;
				string value = "?";
				int value2 = -1;
				try
				{
					value = (((Object)(object)medusaAnimatorOnPrefab.runtimeAnimatorController != (Object)null) ? ((Object)medusaAnimatorOnPrefab.runtimeAnimatorController).name : "<null>");
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
			Il2CppArrayBase<Animator> array = null;
			try
			{
				array = Object.FindObjectsOfType<Animator>();
			}
			catch
			{
			}
			if (array != null)
			{
				foreach (Animator val in array)
				{
					if ((Object)(object)val == (Object)null || (Object)(object)val == (Object)(object)_medusaAnimatorOnPrefab)
					{
						continue;
					}
					bool flag = false;
					try
					{
						RuntimeAnimatorController runtimeAnimatorController = val.runtimeAnimatorController;
						if ((Object)(object)runtimeAnimatorController != (Object)null && ((Object)runtimeAnimatorController).name == "Medusa")
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
							Transform val2 = ((Component)val).transform;
							while ((Object)(object)val2 != (Object)null)
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
							value3 = (((Object)(object)val.runtimeAnimatorController != (Object)null) ? ((Object)val.runtimeAnimatorController).name : "<null>");
						}
						catch
						{
						}
						((ModBase)this).Log.Info($"[Medusa] anim(LIVE@{num}): name='{((Object)((Component)val).transform).name}' enabled={((Behaviour)val).enabled} controller='{value3}'");
						LogAnimatorParamsLive($"anim(LIVE@{num})", val);
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
			value7 = $"hash={currentAnimatorStateInfo.fullPathHash} norm={currentAnimatorStateInfo.normalizedTime:F2}";
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
			bool changedCharacters;
			bool changedLobby;
			int oldIndex;
			int newIndex;
			cfg._characters = MoveMedusaIntoVisibleSlot(cfg._characters, medusaId, out changedCharacters, out oldIndex, out newIndex);
			try
			{
				int lobbyOldIndex;
				int lobbyNewIndex;
				cfg._lobbyCharacters = MoveMedusaIntoVisibleSlot(cfg._lobbyCharacters, medusaId, out changedLobby, out lobbyOldIndex, out lobbyNewIndex);
			}
			catch
			{
				changedLobby = false;
			}
			if ((changedCharacters || changedLobby) && _medusaVisibleSlotLogCount < 8)
			{
				_medusaVisibleSlotLogCount++;
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] moved Medusa into visible match select slot via {source}: oldIndex={oldIndex} newIndex={newIndex} lobbyChanged={changedLobby}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] visible match slot reorder failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static Il2CppReferenceArray<CharacterConfiguration> MoveMedusaIntoVisibleSlot(
		Il2CppReferenceArray<CharacterConfiguration> arr,
		int medusaId,
		out bool changed,
		out int oldIndex,
		out int newIndex)
	{
		changed = false;
		oldIndex = -1;
		newIndex = -1;
		int count = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)?.Length ?? 0;
		if (count <= 0)
		{
			return arr;
		}
		for (int i = 0; i < count; i++)
		{
			CharacterConfiguration cfg = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)[i];
			if (cfg != null && cfg.charId == medusaId)
			{
				oldIndex = i;
				break;
			}
		}
		if (oldIndex < 0)
		{
			return arr;
		}
		int targetIndex = Math.Min(MedusaVisibleMatchSlotIndex, count - 1);
		if (targetIndex <= 0 || oldIndex <= targetIndex)
		{
			newIndex = oldIndex;
			return arr;
		}
		Il2CppReferenceArray<CharacterConfiguration> reordered = new Il2CppReferenceArray<CharacterConfiguration>((long)count);
		CharacterConfiguration medusa = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)[oldIndex];
		int write = 0;
		for (int read = 0; read < count; read++)
		{
			if (write == targetIndex)
			{
				((Il2CppArrayBase<CharacterConfiguration>)(object)reordered)[write++] = medusa;
			}
			if (read == oldIndex)
			{
				continue;
			}
			((Il2CppArrayBase<CharacterConfiguration>)(object)reordered)[write++] = ((Il2CppArrayBase<CharacterConfiguration>)(object)arr)[read];
		}
		changed = true;
		newIndex = targetIndex;
		return reordered;
	}

	private static void RepairPrematchMedusaButton(View_PreMatch_CharSelect view, string source)
	{
		try
		{
			if ((Object)(object)view == (Object)null)
			{
				return;
			}
			Il2CppReferenceArray<UILobbyCharacterSelectIcon> buttons = view._charSelectButtons;
			int count = ((Il2CppArrayBase<UILobbyCharacterSelectIcon>)(object)buttons)?.Length ?? 0;
			if (count <= 0)
			{
				return;
			}
			int medusaIndex = FindCharacterConfigIndex(CurrentMedusaId());
			if (medusaIndex < 0 || medusaIndex >= count)
			{
				if (_prematchButtonRepairLogCount < 8)
				{
					_prematchButtonRepairLogCount++;
					MedusaMod? instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Warn($"[Medusa] prematch button repair skipped via {source}: medusaIndex={medusaIndex} buttonCount={count}.");
					}
				}
				return;
			}
			UILobbyCharacterSelectIcon icon = ((Il2CppArrayBase<UILobbyCharacterSelectIcon>)(object)buttons)[medusaIndex];
			if ((Object)(object)icon == (Object)null)
			{
				return;
			}
			icon.gameObject.SetActive(true);
			_lastPrematchCharSelectView = view;
			_lastPrematchMedusaIcon = icon;
			try { icon.SetInteractable(true); } catch { }
			BindPrematchMedusaIcon(icon, source);
			RectTransform rect = icon.transform as RectTransform;
			Vector3 beforeLocal = ((Object)(object)rect != (Object)null) ? rect.localPosition : icon.transform.localPosition;
			Vector2 beforeAnchored = ((Object)(object)rect != (Object)null) ? rect.anchoredPosition : Vector2.zero;
			if ((Object)(object)rect != (Object)null)
			{
				rect.SetAsLastSibling();
				rect.localScale = Vector3.one * 1.15f;
				rect.localPosition = new Vector3(rect.localPosition.x, 262.5f, rect.localPosition.z);
				rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y);
			}
			else
			{
				Vector3 current = icon.transform.localPosition;
				icon.transform.localPosition = new Vector3(current.x, 262.5f, current.z);
				icon.transform.localScale = Vector3.one * 1.15f;
			}
			if (_prematchButtonRepairLogCount < 16)
			{
				_prematchButtonRepairLogCount++;
				MedusaMod? instance2 = _instance;
				if (instance2 != null)
				{
					Vector3 afterLocal = ((Object)(object)rect != (Object)null) ? rect.localPosition : icon.transform.localPosition;
					Vector2 afterAnchored = ((Object)(object)rect != (Object)null) ? rect.anchoredPosition : Vector2.zero;
					((ModBase)instance2).Log.Info($"[Medusa] prematch Medusa button repaired via {source}: index={medusaIndex}/{count} beforeLocal={beforeLocal} afterLocal={afterLocal} beforeAnchored={beforeAnchored} afterAnchored={afterAnchored}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] prematch button repair failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void BindPrematchMedusaIcon(UILobbyCharacterSelectIcon icon, string source)
	{
		try
		{
			if ((Object)(object)icon == (Object)null)
			{
				return;
			}
			try { icon._action = null; } catch { }
			Button button = icon._button;
			bool reboundButton = false;
			if ((Object)(object)button != (Object)null && button.onClick != null)
			{
				button.onClick.RemoveAllListeners();
				button.interactable = true;
				reboundButton = true;
			}
			PrematchMedusaClickProxy.Attach(icon.gameObject, delegate
			{
				HandlePrematchMedusaIconClick(icon);
			}, source);
			if (_matchSelectLogCount < 48)
			{
				_matchSelectLogCount++;
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] prematch Medusa icon rebound via {source}: button={reboundButton} charId={CurrentMedusaId()}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] prematch Medusa icon bind failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void HandlePrematchMedusaIconClick(UILobbyCharacterSelectIcon icon)
	{
		try
		{
			RememberExplicitMedusaSelection("PrematchMedusaIcon.click");
			try
			{
				if ((Object)(object)icon != (Object)null)
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
				View_PreMatch_CharSelect view = _lastPrematchCharSelectView;
				CharacterConfiguration medusa = FindMedusaConfig();
				if ((Object)(object)view != (Object)null && medusa != null)
				{
					view.SetDisplayedCharacter(medusa, true);
				}
			}
			catch (Exception ex)
			{
				MedusaMod? instance2 = _instance;
				if (instance2 != null)
				{
					((ModBase)instance2).Log.Warn("[Medusa] prematch Medusa display update failed: " + ex.Message);
				}
			}
			TrySubmitMedusaSelection("PrematchMedusaIcon.click", lockAfter: false);
			ScheduleMedusaSelection("PrematchMedusaIcon.click", lockAfter: false);
			if (_matchSelectLogCount < 48)
			{
				_matchSelectLogCount++;
				MedusaMod? instance3 = _instance;
				if (instance3 != null)
				{
					((ModBase)instance3).Log.Info($"[Medusa] prematch Medusa icon clicked; submitted charId={CurrentMedusaId()} autoEnabled={AutoSelectMedusaEnabled()}.");
				}
			}
		}
		catch (Exception ex2)
		{
			MedusaMod? instance4 = _instance;
			if (instance4 != null)
			{
				((ModBase)instance4).Log.Warn("[Medusa] prematch Medusa icon click failed: " + ex2.Message);
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
		try
		{
			UIManager manager = UIAPI.Manager;
			if ((Object)(object)manager != (Object)null && (Object)(object)manager.characterConfig != (Object)null)
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
			if ((Object)(object)_cachedCharConfig != (Object)null)
			{
				return _cachedCharConfig;
			}
		}
		catch
		{
			_cachedCharConfig = null;
		}
		float now = Time.realtimeSinceStartup;
		if (now < _nextCharConfigScanAt)
		{
			return null;
		}
		_nextCharConfigScanAt = now + 1.5f;
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
					UICharactersConfiguration val3 = (((Object)(object)val2[i] != (Object)null) ? val2[i].characterConfig : null);
					if ((Object)(object)val3 != (Object)null)
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
			UICharactersConfiguration? obj = FindCharConfig();
			Il2CppReferenceArray<CharacterConfiguration> val = ((obj != null) ? obj.Characters : null);
			if (val == null)
			{
				return null;
			}
			for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val).Length; i++)
			{
				CharacterConfiguration val2 = ((Il2CppArrayBase<CharacterConfiguration>)(object)val)[i];
				if (val2 != null && (val2.name == "Medusa" || IsMedusaId(val2.charId)))
				{
					return val2;
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
		if (_localMedusaExplicitlySelected)
		{
			return;
		}
		_localMedusaExplicitlySelected = true;
		MedusaMod? instance = _instance;
		if (instance != null && _matchSelectLogCount < 48)
		{
			_matchSelectLogCount++;
			((ModBase)instance).Log.Info("[Medusa] explicit local Medusa selection remembered via " + source + ".");
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
			string environmentVariable = Environment.GetEnvironmentVariable("BAPBAP_MEDUSA_AUTOSELECT_AUGMENT") ?? Environment.GetEnvironmentVariable("BAPBAP_AUTOSELECT_AUGMENT");
			if (!string.IsNullOrWhiteSpace(environmentVariable) && (environmentVariable == "1" || environmentVariable.Equals("true", StringComparison.OrdinalIgnoreCase) || environmentVariable.Equals("yes", StringComparison.OrdinalIgnoreCase)))
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
				string text = commandLineArgs[i] ?? string.Empty;
				if (text.Equals("--bapcustom-auto-select-augment", StringComparison.OrdinalIgnoreCase) ||
					text.Equals("--bapcustom-auto-select-augments", StringComparison.OrdinalIgnoreCase))
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
		bool verbose = _autoAugmentSelectCount == 0 && (_autoAugmentScanCount <= 8 || _autoAugmentScanCount % 80 == 0);
		if (TryAutoSelectViaPlayerAugments(source, verbose))
		{
			return;
		}
		if (TryAutoSelectViaUiManagers(source, verbose))
		{
			return;
		}
		if (TryAutoSelectViaUiAugmentsScan(source, verbose))
		{
			return;
		}
		if (verbose)
		{
			((ModBase)this).Log.Info($"[Medusa] AugmentFix no selectable augment UI yet via {source} scan={_autoAugmentScanCount}.");
		}
	}

	private bool TryAutoSelectViaPlayerAugments(string source, bool verbose)
	{
		try
		{
			PlayerManager local = PlayerAPI.Local;
			if ((Object)(object)local != (Object)null && TryAutoSelectPlayerAugments(local.playerAugments, source + ".PlayerAPI.Local", verbose))
			{
				return true;
			}
		}
		catch (Exception ex)
		{
			if (verbose) ((ModBase)this).Log.Warn("[Medusa] AugmentFix PlayerAPI.Local failed: " + ex.Message);
		}
		try
		{
			Il2CppArrayBase<PlayerAugments> augments = Object.FindObjectsOfType<PlayerAugments>();
			if (augments == null || augments.Length == 0)
			{
				return false;
			}
			PlayerAugments? first = null;
			for (int i = 0; i < augments.Length; i++)
			{
				PlayerAugments playerAugments = augments[i];
				if ((Object)(object)playerAugments == (Object)null)
				{
					continue;
				}
				first ??= playerAugments;
				NetworkBehaviour networkBehaviour = (NetworkBehaviour)(object)playerAugments;
				bool owned = false;
				try { owned = networkBehaviour.isLocalPlayer || networkBehaviour.isOwned; }
				catch { }
				if (owned)
				{
					return TryAutoSelectPlayerAugments(playerAugments, source + ".owned PlayerAugments", verbose);
				}
			}
			if (augments.Length == 1)
			{
				return TryAutoSelectPlayerAugments(first, source + ".single PlayerAugments", verbose);
			}
		}
		catch (Exception ex2)
		{
			if (verbose) ((ModBase)this).Log.Warn("[Medusa] AugmentFix PlayerAugments scan failed: " + ex2.Message);
		}
		return false;
	}

	private bool TryAutoSelectPlayerAugments(PlayerAugments? playerAugments, string source, bool verbose)
	{
		if ((Object)(object)playerAugments == (Object)null)
		{
			return false;
		}
		try
		{
			if (TryAutoSelectUiAugments(playerAugments.uiAugments, source + ".uiAugments", verbose))
			{
				return true;
			}
			AugmentManager.AugmentSelection? currentSelection = playerAugments.CurrentSelection;
			if (currentSelection == null && playerAugments.currentSelection != null)
			{
				currentSelection = playerAugments.currentSelection;
			}
			if (currentSelection == null)
			{
				return false;
			}
			int id = ((Object)(object)playerAugments).GetInstanceID();
			if (_autoSelectedAugmentUiIds.Contains(id))
			{
				return false;
			}
			playerAugments.CmdSelectAugment(0);
			_autoSelectedAugmentUiIds.Add(id);
			_autoAugmentSelectCount++;
			((ModBase)this).Log.Info($"[Medusa] AugmentFix auto-selected first augment via {source}.CmdSelectAugment(0), total={_autoAugmentSelectCount}.");
			return true;
		}
		catch (Exception ex)
		{
			if (verbose) ((ModBase)this).Log.Warn("[Medusa] AugmentFix PlayerAugments select failed via " + source + ": " + ex.Message);
			return false;
		}
	}

	private bool TryAutoSelectViaUiManagers(string source, bool verbose)
	{
		try
		{
			Il2CppArrayBase<UIManager> managers = Resources.FindObjectsOfTypeAll<UIManager>();
			if (managers == null || managers.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < managers.Length; i++)
			{
				UIManager manager = managers[i];
				if ((Object)(object)manager == (Object)null)
				{
					continue;
				}
				if (TryAutoSelectUiAugments(manager.uiAugments, source + ".UIManager.uiAugments", verbose))
				{
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			if (verbose) ((ModBase)this).Log.Warn("[Medusa] AugmentFix UIManager scan failed: " + ex.Message);
		}
		return false;
	}

	private bool TryAutoSelectViaUiAugmentsScan(string source, bool verbose)
	{
		try
		{
			Il2CppArrayBase<UIAugments> all = Resources.FindObjectsOfTypeAll<UIAugments>();
			if (all == null || all.Length == 0)
			{
				try { all = Object.FindObjectsOfType<UIAugments>(true); }
				catch { }
			}
			if (all == null || all.Length == 0)
			{
				return false;
			}
			for (int i = 0; i < all.Length; i++)
			{
				if (TryAutoSelectUiAugments(all[i], source + ".UIAugments scan", verbose))
				{
					return true;
				}
			}
		}
		catch (Exception ex)
		{
			if (verbose) ((ModBase)this).Log.Warn("[Medusa] AugmentFix UIAugments scan failed: " + ex.Message);
		}
		return false;
	}

	private bool TryAutoSelectUiAugments(UIAugments? uiAugments, string source, bool verbose)
	{
		if ((Object)(object)uiAugments == (Object)null)
		{
			return false;
		}
		try
		{
			int id = ((Object)(object)uiAugments).GetInstanceID();
			if (_autoSelectedAugmentUiIds.Contains(id))
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
				_autoSelectedAugmentUiIds.Add(id);
				_autoAugmentSelectCount++;
				((ModBase)this).Log.Info($"[Medusa] AugmentFix auto-selected first augment via {source}.ClSelectAugment(0), total={_autoAugmentSelectCount}.");
				return true;
			}
			catch (Exception ex)
			{
				if (verbose) ((ModBase)this).Log.Warn("[Medusa] AugmentFix ClSelectAugment failed via " + source + ": " + ex.Message);
			}
			Il2CppReferenceArray<UIAugmentElement> elements = uiAugments.augmentElements;
			if (elements != null && ((Il2CppArrayBase<UIAugmentElement>)(object)elements).Length > 0)
			{
				UIAugmentElement element = ((Il2CppArrayBase<UIAugmentElement>)(object)elements)[0];
				if ((Object)(object)element != (Object)null)
				{
					element.SelectedAugment();
					_autoSelectedAugmentUiIds.Add(id);
					_autoAugmentSelectCount++;
					((ModBase)this).Log.Info($"[Medusa] AugmentFix auto-selected first augment via {source}.augmentElements[0].SelectedAugment(), total={_autoAugmentSelectCount}.");
					return true;
				}
			}
		}
		catch (Exception ex2)
		{
			if (verbose) ((ModBase)this).Log.Warn("[Medusa] AugmentFix UI select failed via " + source + ": " + ex2.Message);
		}
		return false;
	}

	private static bool IsAugmentUiVisible(UIAugments uiAugments)
	{
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
			GameObject holder = uiAugments.augmentSelectHolder;
			if ((Object)(object)holder != (Object)null && holder.activeInHierarchy)
			{
				return true;
			}
		}
		catch
		{
		}
		try
		{
			CanvasGroup group = uiAugments.augmentsCanvasGroup;
			if ((Object)(object)group != (Object)null && group.gameObject.activeInHierarchy && group.alpha > 0.01f)
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
						LobbyNetworkClient obj2 = val[i];
						object obj3;
						if (obj2 == null)
						{
							obj3 = null;
						}
						else
						{
							ControllerManager controller = obj2._controller;
							obj3 = ((controller != null) ? controller.CharSelect : null);
						}
						CharSelectController val2 = (CharSelectController)obj3;
						if (val2 != null)
						{
							val2.SwitchCharacter(charId);
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
		try
		{
			MedusaMod instance = _instance;
			if (instance == null || instance._registered)
			{
				return;
			}
			UICharactersConfiguration val = (((Object)(object)__instance != (Object)null) ? __instance.characterConfig : null);
			if ((Object)(object)val == (Object)null)
			{
				val = FindCharConfig();
			}
			if (!((Object)(object)val == (Object)null))
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
		try
		{
			MedusaMod instance = _instance;
			if (instance != null)
			{
				bool registered = instance._registered;
				instance.EnsureMedusaPrefabRegistered((CurrentMedusaId() >= 0) ? CurrentMedusaId() : 0, source + ".prefab");
				instance.TryRegisterMedusa();
				UICharactersConfiguration val = FindCharConfig();
				if ((Object)(object)val != (Object)null)
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
		if ((Object)(object)entity == (Object)null)
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

	private static bool IsExplicitMedusaRootEntity(EntityManager? entity)
	{
		if ((Object)(object)entity == (Object)null)
		{
			return false;
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

	private static bool IsLikelyForeignBotProxyMedusaEntity(EntityManager? entity)
	{
		if ((Object)(object)entity == (Object)null || IsExplicitMedusaRootEntity(entity))
		{
			return false;
		}
		try
		{
			string name = ((Object)((Component)entity).gameObject).name ?? "";
			if (name.IndexOf("Bot", StringComparison.OrdinalIgnoreCase) < 0)
			{
				return false;
			}
			int localId = PlayerAPI.LocalId;
			int ownerId = SafeIntValue(() => entity.ownerPlayerId);
			int reportedPlayerId = SafeIntValue(() => entity.GetPlayerId());
			if (localId > 0 && (ownerId == localId || reportedPlayerId == localId))
			{
				return false;
			}
			return ownerId <= 0 || reportedPlayerId > 0;
		}
		catch
		{
			return false;
		}
	}

	private static bool LooksLikeMedusaObject(GameObject? gameObject)
	{
		if ((Object)(object)gameObject == (Object)null)
		{
			return false;
		}
		try
		{
			string name = ((Object)gameObject).name ?? "";
			if (ObjectRootNameLooksLikeMedusa(name))
			{
				return true;
			}
		}
		catch { }
		try
		{
			foreach (SkinnedMeshRenderer smr in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)(object)smr == (Object)null)
				{
					continue;
				}
				string smrName = ((Object)smr).name ?? "";
				if (smrName.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0 ||
					smrName.IndexOf("Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return true;
				}
			}
		}
		catch { }
		try
		{
			foreach (Transform child in gameObject.GetComponentsInChildren<Transform>(true))
			{
				if ((Object)(object)child == (Object)null)
				{
					continue;
				}
				string childName = ((Object)child).name ?? "";
				if (childName.IndexOf("Medusa_Visual", StringComparison.OrdinalIgnoreCase) >= 0 ||
					childName.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return true;
				}
			}
		}
		catch { }
		return false;
	}

	private static bool HasMedusaVisualUnder(GameObject? gameObject)
	{
		if ((Object)(object)gameObject == (Object)null)
		{
			return false;
		}
		try
		{
			foreach (SkinnedMeshRenderer smr in gameObject.GetComponentsInChildren<SkinnedMeshRenderer>(true))
			{
				if ((Object)(object)smr == (Object)null)
				{
					continue;
				}
				string smrName = ((Object)smr).name ?? "";
				if (smrName.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0 ||
					smrName.IndexOf("Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return true;
				}
			}
		}
		catch { }
		try
		{
			foreach (Transform child in gameObject.GetComponentsInChildren<Transform>(true))
			{
				if ((Object)(object)child == (Object)null)
				{
					continue;
				}
				string childName = ((Object)child).name ?? "";
				if (childName.IndexOf("Medusa_Visual", StringComparison.OrdinalIgnoreCase) >= 0 ||
					childName.IndexOf("MedusaBase", StringComparison.OrdinalIgnoreCase) >= 0)
				{
					return true;
				}
			}
		}
		catch { }
		return false;
	}

	private static bool ObjectRootNameLooksLikeMedusa(string? name)
	{
		if (string.IsNullOrWhiteSpace(name))
		{
			return false;
		}
		string trimmed = name.Trim();
		if (trimmed.Equals("Medusa", StringComparison.OrdinalIgnoreCase) ||
			trimmed.Equals("Medusa(Clone)", StringComparison.OrdinalIgnoreCase) ||
			trimmed.Equals("Char_Medusa", StringComparison.OrdinalIgnoreCase) ||
			trimmed.Equals("Char_Medusa(Clone)", StringComparison.OrdinalIgnoreCase) ||
			trimmed.Equals("Medusa_Visual", StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}
		if (trimmed.IndexOf("Char_Medusa", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return true;
		}
		int bracket = trimmed.LastIndexOf(']');
		if (bracket >= 0 && bracket + 1 < trimmed.Length)
		{
			string characterName = trimmed.Substring(bracket + 1).Trim();
			return characterName.Equals("Medusa", StringComparison.OrdinalIgnoreCase) ||
				characterName.Equals("Medusa(Clone)", StringComparison.OrdinalIgnoreCase);
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
			UICharactersConfiguration? obj = FindCharConfig();
			Il2CppReferenceArray<CharacterConfiguration> val = ((obj != null) ? obj.Characters : null);
			if (val != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)val).Length > 0)
			{
				List<int> list = new List<int>();
				for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val).Length; i++)
				{
					int num = ((((Il2CppArrayBase<CharacterConfiguration>)(object)val)[i] != null) ? ((Il2CppArrayBase<CharacterConfiguration>)(object)val)[i].charId : (-1));
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
		try
		{
			if (qmd == null || qmd.players == null)
			{
				return;
			}
			Il2CppSystem.Collections.Generic.List<MatchmakingPlayerData> players = qmd.players;
			int count = players.Count;
			PlayerManager local = null;
			try
			{
				local = PlayerAPI.Local;
			}
			catch
			{
			}
			int localPlayerId = SafeIntValue(() => local.playerId);
			string localAccountId = string.Empty;
			try
			{
				localAccountId = local?.accountId ?? string.Empty;
			}
			catch
			{
			}
			bool launchRequested = LaunchRequestedMedusa();
			bool autoSelectRequested = AutoSelectMedusaEnabled();
			bool rememberedSelection = _localMedusaExplicitlySelected;
			bool explicitLocalIntent = launchRequested || autoSelectRequested;
			int forced = 0;
			int selections = 0;
			for (int i = 0; i < count; i++)
			{
				MatchmakingPlayerData playerData = players[i];
				if (playerData == null)
				{
					continue;
				}
				bool localMatch = PlayerDataMatchesLocal(playerData, localPlayerId, localAccountId) || (count == 1 && explicitLocalIntent);
				bool alreadyMedusa = IsMedusaId(SafeIntValue(() => playerData.charId));
				bool shouldNormalize = alreadyMedusa || (explicitLocalIntent && localMatch);
				if (!shouldNormalize)
				{
					continue;
				}
				int oldChar = SafeIntValue(() => playerData.charId);
				int oldSkin = SafeIntValue(() => playerData.skinAssetId);
				try { playerData.charId = CurrentMedusaId(); } catch { }
				try { playerData.skinAssetId = -1; } catch { }
				int playerId = SafeIntValue(() => playerData.playerId);
				if (playerId > 0)
				{
					selections += SetPreMatchSelectionForPlayerId(playerId, CurrentMedusaId(), source + ".qmd");
				}
				if (localMatch)
				{
					RememberExplicitMedusaSelection(source + ".qmd.local");
					if ((Object)(object)local != (Object)null)
					{
						ForcePlayerMedusaChar(local, CurrentMedusaId(), source + ".qmd.local");
					}
				}
				forced++;
				if (_matchSelectLogCount < 48)
				{
					_matchSelectLogCount++;
					MedusaMod? instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] qmd Medusa normalized via {source}: playerId={playerId} account={SafeString(() => playerData.accountId)} localMatch={localMatch} old={oldChar} new={CurrentMedusaId()} skin={oldSkin}->-1.");
					}
				}
			}
			if ((forced > 0 || selections > 0) && _matchSelectLogCount < 48)
			{
				_matchSelectLogCount++;
				MedusaMod? instance2 = _instance;
				if (instance2 != null)
					{
						((ModBase)instance2).Log.Info($"[Medusa] qmd Medusa selection summary via {source}: forcedPlayers={forced} prematchSelections={selections} explicitLocal={explicitLocalIntent} launch={launchRequested} autoSelect={autoSelectRequested} remembered={rememberedSelection} localPlayerId={localPlayerId}.");
					}
				}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] qmd Medusa normalization failed via " + source + ": " + ex.Message);
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
		if (playerId <= 0 || !IsMedusaId(charId))
		{
			return 0;
		}
		int updated = 0;
		try
		{
			Il2CppArrayBase<PreMatchManager> managers = Object.FindObjectsOfType<PreMatchManager>();
			if (managers == null)
			{
				return 0;
			}
			foreach (PreMatchManager manager in managers)
			{
				if ((Object)(object)manager == (Object)null || manager._currentSelectedCharacters == null)
				{
					continue;
				}
				Il2CppSystem.Collections.Generic.Dictionary<int, int> selected = manager._currentSelectedCharacters;
				bool had = false;
				int old = -1;
				try
				{
					had = selected.ContainsKey(playerId);
				}
				catch
				{
				}
				if (had)
				{
					try { old = selected[playerId]; } catch { }
					try
					{
						selected[playerId] = charId;
						updated++;
					}
					catch
					{
					}
				}
				else
				{
					try
					{
						selected.Add(playerId, charId);
						updated++;
					}
					catch
					{
					}
				}
				if (_matchSelectLogCount < 48)
				{
					_matchSelectLogCount++;
					MedusaMod? instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] prematch selected char via {source}: playerId={playerId} old={old} new={charId} existed={had}.");
					}
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] SetPreMatchSelectionForPlayerId failed via " + source + ": " + ex.Message);
			}
		}
		return updated;
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
				Il2CppSystem.Collections.Generic.List<MatchmakingPlayerData> players = qmd.players;
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
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] prematch qmd via {source}: available={string.Join(",", array)} players=[{string.Join(", ", list)}].");
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] prematch qmd bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void TrySubmitMedusaSelection(string source, bool lockAfter)
	{
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
				PlayerPreMatch localPreMatch = (((Object)(object)localPlayer != (Object)null) ? localPlayer.playerPreMatch : null);
				if ((Object)(object)localPlayer != (Object)null)
				{
					ForcePlayerMedusaChar(localPlayer, num, source + ".localPreSubmit");
					if ((Object)(object)localPreMatch != (Object)null)
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
									MedusaMod? instance3 = _instance;
									if (instance3 != null)
									{
										((ModBase)instance3).Log.Warn("[Medusa] local CmdTryLockCharacter failed via " + source + ": " + ex6.Message);
									}
								}
							}, (ModBase)(object)instance);
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
					}, (ModBase)(object)instance);
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
					if ((Object)(object)item == (Object)null)
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
						flag = flag || ((Object)(object)item._playerManager != (Object)null && ((NetworkBehaviour)item._playerManager).isLocalPlayer);
					}
					catch
					{
					}
					if (!flag && val.Length > 1)
					{
						continue;
					}
					PlayerManager playerManager = item._playerManager;
					if ((Object)(object)playerManager == (Object)null)
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
							MedusaMod? instance3 = _instance;
							if (instance3 != null)
							{
								((ModBase)instance3).Log.Warn("[Medusa] CmdTryLockCharacter failed via " + source + ": " + ex6.Message);
							}
						}
					}, (ModBase)(object)instance);
				}
				if (num2 == 0)
				{
					foreach (PlayerPreMatch item2 in val)
					{
						if ((Object)(object)item2 == (Object)null)
						{
							continue;
						}
						PlayerManager playerManager2 = item2._playerManager;
						if (!((Object)(object)playerManager2 == (Object)null))
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
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] prematch submit failed via " + source + ": " + ex5.Message);
			}
		}
	}

	private static void ScheduleMedusaSelection(string source, bool lockAfter)
	{
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
				}, (ModBase)(object)instance);
				TimerAPI.Once(1.0f, (Action)delegate
				{
					TrySubmitMedusaSelection(source + "+1.00s", lockAfter);
				}, (ModBase)(object)instance);
				TimerAPI.Once(2.5f, (Action)delegate
				{
					TrySubmitMedusaSelection(source + "+2.50s", lockAfter);
				}, (ModBase)(object)instance);
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
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
		try
		{
			if ((Object)(object)player == (Object)null || !IsMedusaId(charId))
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
				if ((Object)(object)item == (Object)null)
				{
					continue;
				}
				Il2CppSystem.Collections.Generic.Dictionary<int, int> currentSelectedCharacters = item._currentSelectedCharacters;
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
					MedusaMod? instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] prematch selection state via {source}: playerId={num} old={value} new={charId} existed={flag}.");
					}
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] UpdatePreMatchSelectionState failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static bool TryGetPreMatchSelectedChar(PlayerManager? player, out int charId)
	{
		charId = -1;
		try
		{
			if ((Object)(object)player == (Object)null)
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
				if ((Object)(object)item == (Object)null)
				{
					continue;
				}
				Il2CppSystem.Collections.Generic.Dictionary<int, int> currentSelectedCharacters = item._currentSelectedCharacters;
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
		try
		{
			if ((Object)(object)player == (Object)null || !IsMedusaId(charId))
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
				if ((Object)(object)item == (Object)null)
				{
					continue;
				}
				QueueMatchedData qmd = item.qmd;
				Il2CppSystem.Collections.Generic.List<MatchmakingPlayerData> val2 = ((qmd != null) ? qmd.players : null);
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
						MedusaMod? instance = _instance;
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
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] UpdateMatchmakingPlayerData failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ForceSelectedMedusaPlayers(PreMatchManager? manager, string source)
	{
		try
		{
			Il2CppArrayBase<PlayerManager> val = Object.FindObjectsOfType<PlayerManager>();
			if (val == null)
			{
				return;
			}
			foreach (PlayerManager player in val)
			{
				if ((Object)(object)player == (Object)null)
				{
					continue;
				}
				int charId = -1;
				if ((Object)(object)manager != (Object)null)
				{
					try
					{
						Il2CppSystem.Collections.Generic.Dictionary<int, int> currentSelectedCharacters = manager._currentSelectedCharacters;
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
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] ForceSelectedMedusaPlayers failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ForcePlayerMedusaChar(PlayerManager? player, int charId, string source)
	{
		try
		{
			if ((Object)(object)player == (Object)null || !IsMedusaId(charId))
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
			int num2 = -999;
			try
			{
				num2 = player.skinAssetId;
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
				if ((Object)(object)primaryCharManager != (Object)null)
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
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Info($"[Medusa] forced PlayerManager char via {source}: old={num} new={charId} skin={num2}->-1 isServer={SafeBool(() => ((NetworkBehaviour)player).isServer)} isLocal={SafeBool(() => ((NetworkBehaviour)player).isLocalPlayer)}.");
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] ForcePlayerMedusaChar failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static string ObjName(UnityEngine.Object? obj)
	{
		try
		{
			return (Object)(object)obj == (Object)null ? "<null>" : obj.name;
		}
		catch
		{
			return "?";
		}
	}

	private static string FmtVec(Vector3 v)
	{
		return $"({v.x:0.###},{v.y:0.###},{v.z:0.###})";
	}

	private static string FmtPos(Component? component)
	{
		try
		{
			return (Object)(object)component == (Object)null ? "<null>" : FmtVec(component.transform.position);
		}
		catch
		{
			return "?";
		}
	}

	private static string ScreenPos(Component? component)
	{
		try
		{
			if ((Object)(object)component == (Object)null)
			{
				return "<null>";
			}
			Camera main = Camera.main;
			if ((Object)(object)main == (Object)null)
			{
				return "<no-main-camera>";
			}
			Vector3 screen = main.WorldToScreenPoint(component.transform.position);
			return $"{screen.x:0.0},{screen.y:0.0},{screen.z:0.0}";
		}
		catch
		{
			return "?";
		}
	}

	private static string CameraInfo()
	{
		try
		{
			Camera main = Camera.main;
			if ((Object)(object)main == (Object)null)
			{
				return "<null>";
			}
			return $"{ObjName(main)} pos={FmtVec(((Component)main).transform.position)} rot={FmtVec(((Component)main).transform.eulerAngles)} size={main.pixelWidth}x{main.pixelHeight}";
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
		try
		{
			if ((Object)(object)entity == (Object)null || !LooksLikeMedusaEntity(entity))
			{
				return;
			}
			PlayerManager local = PlayerAPI.Local;
			if ((Object)(object)local == (Object)null || !IsMedusaId(SafeIntValue(() => local.charId)))
			{
				return;
			}
			EntityManager currentPrimary = local.primaryCharManager;
			if ((Object)(object)currentPrimary == (Object)(object)entity)
			{
				RepairMedusaCameraTarget(entity, source + ".alreadyPrimary");
				return;
			}
			GameObject entityObj = ((Component)entity).gameObject;
			GameObject localObj = ((Component)local).gameObject;
			int repairId = (Object)(object)entityObj == (Object)null ? 0 : ((Object)entityObj).GetInstanceID();
			int localId = SafeIntValue(() => local.playerId);
			int ownerId = SafeIntValue(() => entity.ownerPlayerId);
			int reportedPlayerId = SafeIntValue(() => entity.GetPlayerId());
			bool localPrimaryMissing = (Object)(object)currentPrimary == (Object)null;
			bool ownerMatches = ownerId == localId || reportedPlayerId == localId;
			bool refsMatch = (Object)(object)entity.playerManager == (Object)(object)local || (Object)(object)entity.playerObj == (Object)(object)localObj;
			bool ownerUnset = ownerId <= 0 && reportedPlayerId <= 0;
			bool forceAllowed = forceWhenLocalPrimaryMissing && localPrimaryMissing && ownerUnset && IsExplicitMedusaRootEntity(entity);
			if (!ownerMatches && !refsMatch && !forceAllowed)
			{
				if (_localBindingRepairLogCount < 16 && _localBindingRepairIds.Add(-repairId))
				{
					_localBindingRepairLogCount++;
					MedusaMod? instance = _instance;
					if (instance != null)
					{
						((ModBase)instance).Log.Info($"[Medusa] local binding skipped via {source}: entity='{ObjName(entityObj)}' owner={ownerId} getPlayerId={reportedPlayerId} localId={localId} localPrimary='{ObjName(currentPrimary)}' playerObj='{ObjName(entity.playerObj)}' entityPlayer='{ObjName(entity.playerManager)}' force={forceWhenLocalPrimaryMissing}.");
					}
				}
				return;
			}
			try { entity.charId = CurrentMedusaId(); } catch { }
			try { entity.NetworkcharId = CurrentMedusaId(); } catch { }
			try { entity.playerManager = local; } catch { }
			try { entity.playerObj = localObj; } catch { }
			try { entity.NetworkplayerObj = localObj; } catch { }
			try { entity.OnPlayerObjChanged(null, localObj); } catch { }
			try { entity.ownerPlayerId = localId; } catch { }
			try { entity.isPrimary = true; } catch { }
			try { entity.NetworkisPrimary = true; } catch { }
			try { local.primaryCharManager = entity; } catch { }
			try { local.followTargetOverride = ((Component)entity).transform; } catch { }
			try { PlayerManager.LocalInstance = local; } catch { }
			try { local.AddCharObj(entity, true); } catch { }
			try { entity.ClStartAuth(); } catch { }
			try { local.UpdateAOI(((Component)entity).transform); } catch { }
			RepairMedusaCameraTarget(entity, source);
			if (_localBindingRepairLogCount < 24 && _localBindingRepairIds.Add(repairId))
			{
				_localBindingRepairLogCount++;
				MedusaMod? instance2 = _instance;
				if (instance2 != null)
				{
					EntityManager newPrimary = local.primaryCharManager;
					EntityManager auth = PlayerAPI.AuthViewCharacter;
					((ModBase)instance2).Log.Info($"[Medusa] local binding repaired via {source}: entity='{ObjName(entityObj)}' owner {ownerId}->{SafeIntValue(() => entity.ownerPlayerId)} localId={localId} hadPrimary='{ObjName(currentPrimary)}' nowPrimary='{ObjName(newPrimary)}' auth='{ObjName(auth)}' pos={FmtPos(entity)} screen={ScreenPos(entity)} owned={SafeBool(() => ((NetworkBehaviour)entity).isOwned)} localPlayerOwned={SafeBool(() => ((NetworkBehaviour)local).isOwned)} force={forceWhenLocalPrimaryMissing} forceAllowed={forceAllowed}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null && _localBindingRepairLogCount < 24)
			{
				_localBindingRepairLogCount++;
				((ModBase)instance).Log.Warn("[Medusa] local binding repair failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void RepairMedusaCameraTarget(EntityManager? entity, string source)
	{
		try
		{
			if ((Object)(object)entity == (Object)null || !LooksLikeMedusaEntity(entity))
			{
				return;
			}
			PlayerManager local = PlayerAPI.Local;
			if ((Object)(object)local == (Object)null || !IsMedusaId(SafeIntValue(() => local.charId)))
			{
				return;
			}
			GameObject localObj = ((Component)local).gameObject;
			int localId = SafeIntValue(() => local.playerId);
			int ownerId = SafeIntValue(() => entity.ownerPlayerId);
			int reportedPlayerId = SafeIntValue(() => entity.GetPlayerId());
			bool entityMatchesLocal = ownerId == localId || reportedPlayerId == localId || (Object)(object)entity.playerManager == (Object)(object)local || (Object)(object)entity.playerObj == (Object)(object)localObj;
			bool explicitRoot = IsExplicitMedusaRootEntity(entity);
			EntityManager currentPrimary = local.primaryCharManager;
			bool ownerUnset = ownerId <= 0 && reportedPlayerId <= 0;
			bool explicitRootCanStandInForMissingLocal = explicitRoot && ownerUnset && (Object)(object)currentPrimary == (Object)null;
			if (!entityMatchesLocal && !explicitRootCanStandInForMissingLocal)
			{
				return;
			}
			Transform target = ((Component)entity).transform;
			if ((Object)(object)target == (Object)null)
			{
				return;
			}
			try { local.followTargetOverride = target; } catch { }
			try { PlayerManager.LocalInstance = local; } catch { }
			int updated = 0;
			int already = 0;
			Il2CppArrayBase<CameraController> controllers = null;
			try { controllers = Object.FindObjectsOfType<CameraController>(); } catch { }
			if (controllers != null)
			{
				for (int i = 0; i < controllers.Length; i++)
				{
					CameraController controller = controllers[i];
					if ((Object)(object)controller == (Object)null)
					{
						continue;
					}
					bool matches = false;
					try { matches = (Object)(object)controller.Target == (Object)(object)target; } catch { }
					if (matches)
					{
						already++;
						continue;
					}
					try
					{
						controller.SetTarget(target);
						updated++;
						continue;
					}
					catch
					{
					}
					try
					{
						controller._target = target;
						updated++;
					}
					catch
					{
					}
				}
			}
			GameObject entityObj = ((Component)entity).gameObject;
			int repairId = (Object)(object)entityObj == (Object)null ? 0 : ((Object)entityObj).GetInstanceID();
			bool shouldLog = updated > 0 || _cameraTargetRepairIds.Add(repairId);
			if (shouldLog && _cameraTargetRepairLogCount < 24)
			{
				_cameraTargetRepairLogCount++;
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					EntityManager auth = PlayerAPI.AuthViewCharacter;
					((ModBase)instance).Log.Info($"[Medusa] camera target repair via {source}: entity='{ObjName(entity)}' target='{ObjName(target)}' updated={updated} already={already} controllers={(controllers != null ? controllers.Length : 0)} localPrimary='{ObjName(local.primaryCharManager)}' auth='{ObjName(auth)}' entityScreen={ScreenPos(entity)} camera={CameraInfo()}.");
				}
			}
		}
		catch (Exception ex)
		{
			if (_cameraTargetRepairLogCount < 24)
			{
				_cameraTargetRepairLogCount++;
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Warn("[Medusa] camera target repair failed via " + source + ": " + ex.Message);
				}
			}
		}
	}

	private static void EnsureLiveMedusaEntity(EntityManager? entity, string source)
	{
		try
		{
			if ((Object)(object)entity == (Object)null || !LooksLikeMedusaEntity(entity) || IsLikelyForeignBotProxyMedusaEntity(entity))
			{
				return;
			}
			_lastLiveMedusaEntity = entity;
			try { entity.charId = CurrentMedusaId(); } catch { }
			try { entity.NetworkcharId = CurrentMedusaId(); } catch { }
			MedusaMod instance = _instance;
			if (instance != null)
			{
				GameObject gameObject = ((Component)entity).gameObject;
				if (!((Object)(object)gameObject == (Object)null))
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
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] EnsureLiveMedusaEntity failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ScheduleLiveMedusaRefresh(EntityManager entity, string source)
	{
		try
		{
			MedusaMod inst = _instance;
			if (inst == null || (Object)(object)entity == (Object)null)
			{
				return;
			}
			GameObject gameObject = ((Component)entity).gameObject;
			if ((Object)(object)gameObject == (Object)null)
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
			void Once(float delay)
			{
				TimerAPI.Once(delay, (Action)delegate
				{
					try
					{
						if (!((Object)(object)entity == (Object)null) && LooksLikeMedusaEntity(entity) && !IsLikelyForeignBotProxyMedusaEntity(entity))
						{
							_lastLiveMedusaEntity = entity;
							GameObject gameObject2 = ((Component)entity).gameObject;
							if (!((Object)(object)gameObject2 == (Object)null))
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
						MedusaMod? instance2 = _instance;
						if (instance2 != null)
						{
							((ModBase)instance2).Log.Warn($"[Medusa] delayed live refresh failed via {source}+{delay:F2}s: {ex2.Message}");
						}
					}
				}, (ModBase)(object)inst);
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] ScheduleLiveMedusaRefresh failed via " + source + ": " + ex.Message);
			}
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
		if (string.IsNullOrWhiteSpace(key))
		{
			return string.Empty;
		}
		try
		{
			UIManager manager = UIAPI.Manager;
			Translator val = (((Object)(object)manager != (Object)null) ? manager.translator : null);
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
		string replacement = slot switch
		{
			0 => "poison damage",
			1 => "poison damage",
			2 => "knock-up pressure",
			3 => "curse damage",
			_ => "damage"
		};
		string replacement2 = slot switch
		{
			1 => "poison",
			2 => "knock-up",
			3 => "2.5s petrify",
			_ => "poison"
		};
		return text.Replace("{1}", replacement).Replace("{2}", replacement2);
	}

	private static int NormalizeMedusaAbilitySlot(int cmdId)
	{
		if (cmdId < 0 || cmdId > ULT_SLOT_INDEX)
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
		AbilityData? data = MedusaAbilityDataForSlot(slot);
		string key = string.Empty;
		try
		{
			key = data?.titleKey ?? string.Empty;
		}
		catch
		{
		}
		return ResolveMedusaPhrase(key);
	}

	private static string MedusaAbilityTooltipForSlot(int slot, bool expanded)
	{
		AbilityData? data = MedusaAbilityDataForSlot(slot);
		string key = string.Empty;
		try
		{
			key = expanded ? (data?.descriptionKey ?? string.Empty) : (data?.shortDescriptionKey ?? string.Empty);
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
			_ => string.Empty
		};
	}

	private static void OverrideMedusaAbilityTooltipText(Ability? ability, bool expanded, ref string __result)
	{
		try
		{
			int slot = GetMedusaAbilitySlot(ability);
			if (slot < 0)
			{
				return;
			}
			string text = MedusaAbilityTooltipForSlot(slot, expanded);
			if (!string.IsNullOrWhiteSpace(text))
			{
				__result = text;
			}
		}
		catch
		{
		}
	}

	private static bool TryShowMedusaAbilityTooltip(UIAbilities? uiAbilities, int cmdId, bool fadeIn, string source)
	{
		try
		{
			if ((Object)(object)uiAbilities == (Object)null || !LocalPlayerIsMedusa())
			{
				return false;
			}
			int slot = NormalizeMedusaAbilitySlot(cmdId);
			if (slot < 0)
			{
				return false;
			}
			UITooltip tooltip = uiAbilities.uiTooltip;
			if ((Object)(object)tooltip == (Object)null)
			{
				return false;
			}
			RectTransform rectTransform = null;
			UIAbilityElement element = null;
			try
			{
				Il2CppReferenceArray<UIAbilityElement> elements = uiAbilities.abilityElementsByCmdId;
				if (elements != null && cmdId >= 0 && cmdId < ((Il2CppArrayBase<UIAbilityElement>)(object)elements).Length)
				{
					element = ((Il2CppArrayBase<UIAbilityElement>)(object)elements)[cmdId];
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element != (Object)null)
				{
					rectTransform = element.rectTransform;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)rectTransform == (Object)null && (Object)(object)element != (Object)null)
				{
					rectTransform = ((Component)element).GetComponent<RectTransform>();
				}
			}
			catch
			{
			}
			if ((Object)(object)rectTransform == (Object)null)
			{
				return false;
			}
			string title = MedusaAbilityTitleForSlot(slot);
			string body = MedusaAbilityTooltipForSlot(slot, expanded: false);
			if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(body))
			{
				return false;
			}
			tooltip.ShowTooltip(MedusaTitleTextColor, title, body, rectTransform, fadeIn);
			ApplyMedusaAbilityElementPalette(element, source + ".directTooltip");
			MedusaMod instance = _instance;
			if (instance != null && instance._runtimeUiLogCount < 16)
			{
				instance._runtimeUiLogCount++;
				((ModBase)instance).Log.Info($"[Medusa] direct ability tooltip via {source}: cmd={cmdId} slot={slot} title='{title}'.");
			}
			return true;
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] direct ability tooltip failed via " + source + ": " + ex.Message);
			}
			return false;
		}
	}

	private static void ApplyMedusaAbilityElementPalette(UIAbilityElement? element, string source)
	{
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if ((Object)(object)element == (Object)null)
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
				if ((Object)(object)element.bgImage != (Object)null)
				{
					((Graphic)element.bgImage).color = MedusaAbilityBgColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element.abilityIcon != (Object)null)
				{
					((Graphic)element.abilityIcon).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element.activeState != (Object)null)
				{
					((Graphic)element.activeState).color = new Color(0.18f, 1f, 0.32f, 0.88f);
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element.cdTopTab != (Object)null)
				{
					((Graphic)element.cdTopTab).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element.cdProgressBarOutline != (Object)null)
				{
					((Graphic)element.cdProgressBarOutline).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element.cdProgressBarFill != (Object)null)
				{
					((Graphic)element.cdProgressBarFill).color = MedusaAbilityIconColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element.inputIconBG != (Object)null)
				{
					((Graphic)element.inputIconBG).color = MedusaAbilityBgColor;
				}
			}
			catch
			{
			}
			try
			{
				if ((Object)(object)element.readyAlphaAnimImage != (Object)null)
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
						if ((Object)(object)((Il2CppArrayBase<Image>)(object)chargeImages)[i] != (Object)null)
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
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] ApplyMedusaAbilityElementPalette failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static bool LocalPlayerIsMedusa()
	{
		try
		{
			PlayerManager local = PlayerAPI.Local;
			if ((Object)(object)local != (Object)null && IsMedusaId(SafeIntValue(() => local.charId)))
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
					if ((Object)(object)item == (Object)null)
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
					if (flag && IsMedusaId(SafeIntValue(() => item.charId)))
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
			Il2CppArrayBase<EntityManager> val2 = Object.FindObjectsOfType<EntityManager>();
			if (val2 != null)
			{
				foreach (EntityManager item2 in val2)
				{
					if ((Object)(object)item2 == (Object)null)
					{
						continue;
					}
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
		catch
		{
		}
		return false;
	}

	private static void ApplyLiveAbilityUiPalette(string source)
	{
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
				if (!((Object)(object)item == (Object)null))
				{
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
					if (IsMedusaAbilityText(value) || (flag && num >= 0 && num <= 3))
					{
						if (flag && num >= 0 && num <= 3)
						{
							string title = MedusaAbilityTitleForSlot(num);
							if (!string.IsNullOrWhiteSpace(title))
							{
								try
								{
									item.titleStr = title;
								}
								catch
								{
								}
							}
						}
						ApplyMedusaAbilityElementPalette(item, source + ".live");
					}
				}
			}
		}
		catch
		{
		}
	}

	private static CharacterPageModel BuildUnlockedCharacterPageModel(string source)
	{
		CharacterPageModel data = new CharacterPageModel();
		ForceCharacterPageModelUnlocked(data, source);
		return data;
	}

	private static Il2CppReferenceArray<CharListing> BuildCharacterListings(int[] characterIds)
	{
		Il2CppReferenceArray<CharListing> listings = new Il2CppReferenceArray<CharListing>((long)characterIds.Length);
		for (int i = 0; i < characterIds.Length; i++)
		{
			CharListing listing = new CharListing
			{
				listingId = $"character-{characterIds[i]}",
				charId = characterIds[i],
				levelRequirement = 0,
				costs = new Il2CppReferenceArray<AssetModel>(0L),
				purchases = 1
			};
			((Il2CppArrayBase<CharListing>)(object)listings)[i] = listing;
		}
		return listings;
	}

	private static void EnsureLobbyCharacterPageDataAvailable(string source)
	{
		try
		{
			Il2CppArrayBase<UILobbyCharacterSelectPage> pages = Resources.FindObjectsOfTypeAll<UILobbyCharacterSelectPage>();
			if (pages == null || pages.Length <= 0)
			{
				return;
			}
			int patched = 0;
			for (int i = 0; i < pages.Length; i++)
			{
				UILobbyCharacterSelectPage page = pages[i];
				if ((Object)(object)page == (Object)null)
				{
					continue;
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
				patched++;
			}
			if (patched > 0 && _uiWarmupLogCount < 8)
			{
				_uiWarmupLogCount++;
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] ensured UILobbyCharacterSelectPage data before {source}: pages={patched}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] lobby character page data bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void EnsureLobbyCharacterPageDataAvailable(UILobbyCharacterSelectPage? page, string source)
	{
		try
		{
			if ((Object)(object)page == (Object)null)
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
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] ensured UILobbyCharacterSelectPage instance data before {source}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
			if (instance != null)
			{
				((ModBase)instance).Log.Warn("[Medusa] lobby character page instance bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void ForceCharacterPageModelUnlocked(CharacterPageModel? data, string source)
	{
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
			Il2CppSystem.Collections.Generic.HashSet<int> unlocked = new Il2CppSystem.Collections.Generic.HashSet<int>();
			for (int j = 0; j < array.Length; j++)
			{
				unlocked.Add(array[j]);
			}
			data.unlockedCharacters = unlocked;
			CharListings charListings = data.charListings;
			if (charListings == null)
			{
				charListings = new CharListings();
				data.charListings = charListings;
			}
			Il2CppReferenceArray<CharListing> val3 = ((charListings != null) ? charListings.charListings : null);
			if (val3 == null || ((Il2CppArrayBase<CharListing>)(object)val3).Length <= 0)
			{
				val3 = BuildCharacterListings(array);
				charListings.charListings = val3;
			}
			if (val3 != null)
			{
				for (int k = 0; k < ((Il2CppArrayBase<CharListing>)(object)val3).Length; k++)
				{
					CharListing val4 = ((Il2CppArrayBase<CharListing>)(object)val3)[k];
					if (val4 == null)
					{
						continue;
					}
					int charId = val4.charId;
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
						val4.levelRequirement = 0;
						val4.purchases = 1;
					}
				}
			}
			if (_uiWarmupLogCount < 8)
			{
				_uiWarmupLogCount++;
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] lobby page model unlocked via {source}: ids={string.Join(",", array)}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
			if (instance2 != null)
			{
				((ModBase)instance2).Log.Warn("[Medusa] lobby page model unlock bridge failed via " + source + ": " + ex.Message);
			}
		}
	}

	private static void EnsureRegisteredForMatchPage(UILobbyMatchCharacterSelectPage? page, string source)
	{
		try
		{
			EnsureRegisteredForUi(source);
			object obj;
			if (page == null)
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
			if (_instance != null && (Object)(object)val != (Object)null)
			{
				_instance.TryRegisterMedusa(val);
				_instance.MakeRosterAvailable(val);
			}
			ForceMatchCharacterSelectModelAvailable((page != null) ? page._data : null, source + "._data");
		}
		catch (Exception ex)
		{
			MedusaMod? instance = _instance;
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
				MedusaMod? instance = _instance;
				if (instance != null)
				{
					((ModBase)instance).Log.Info($"[Medusa] match select model available via {source}: ids={string.Join(",", array)}.");
				}
			}
		}
		catch (Exception ex)
		{
			MedusaMod? instance2 = _instance;
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
			if (page == null)
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
			CharacterPageModel data = (page != null) ? page._data : null;
			Il2CppReferenceArray<CharListing> listings = ((data != null && data.charListings != null) ? data.charListings.charListings : null);
			if (listings != null)
			{
				for (int i = 0; i < ((Il2CppArrayBase<CharListing>)(object)listings).Length; i++)
				{
					CharListing listing = ((Il2CppArrayBase<CharListing>)(object)listings)[i];
					if (listing != null && listing.charId == charId)
					{
						index = i;
						return true;
					}
				}
			}

			Il2CppStructArray<int> available = (data != null) ? data.availableCharacters : null;
			if (available != null)
			{
				for (int j = 0; j < ((Il2CppArrayBase<int>)(object)available).Length; j++)
				{
					if (((Il2CppArrayBase<int>)(object)available)[j] == charId)
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

		int[] characterIds = CurrentCharacterIds();
		for (int k = 0; k < characterIds.Length; k++)
		{
			if (characterIds[k] == charId)
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
			UICharactersConfiguration? obj = FindCharConfig();
			Il2CppReferenceArray<CharacterConfiguration> val = ((obj != null) ? obj.Characters : null);
			if (val != null)
			{
				for (int i = 0; i < ((Il2CppArrayBase<CharacterConfiguration>)(object)val).Length; i++)
				{
					if (((Il2CppArrayBase<CharacterConfiguration>)(object)val)[i] != null && ((Il2CppArrayBase<CharacterConfiguration>)(object)val)[i].charId == charId)
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
		try
		{
			if ((Object)(object)t == (Object)null)
			{
				return null;
			}
			Transform val = t;
			while ((Object)(object)val.parent != (Object)null)
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
				if ((Object)(object)item == (Object)null)
				{
					continue;
				}
				try
				{
					RuntimeAnimatorController runtimeAnimatorController = item.runtimeAnimatorController;
					if (IsMedusaRuntimeController(runtimeAnimatorController))
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
					while ((Object)(object)val2 != (Object)null)
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
				if ((Object)(object)item == (Object)null)
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
					if ((Object)(object)val2 == (Object)null)
					{
						continue;
					}
					string text = "";
					try
					{
						Il2CppSystem.Type il2CppType = ((Object)val2).GetIl2CppType();
						text = ((il2CppType != null) ? ((Il2CppSystem.Reflection.MemberInfo)il2CppType).Name : "");
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
		if ((Object)(object)_petrifySO != (Object)null)
		{
			return true;
		}
		_petrifyLookupAttempted = true;
		_petrifySO = FindSE("SE_Petrified_SO", "SE_Petrified", out _petrifyId);
		if ((Object)(object)_petrifySO != (Object)null)
		{
			_petrifyLookupSucceeded = true;
			MedusaMod? instance = _instance;
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
		if ((Object)(object)_poisonSO != (Object)null)
		{
			return true;
		}
		_poisonLookupAttempted = true;
		_poisonSO = FindSE("SE_Poisoned_SO", "SE_Poisoned", out _poisonId);
		if ((Object)(object)_poisonSO != (Object)null)
		{
			_poisonLookupSucceeded = true;
			MedusaMod? instance = _instance;
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
		if ((Object)(object)ability == (Object)null)
		{
			return -1;
		}
		try
		{
			EntityManager entityManager = ability.entityManager;
			if ((Object)(object)entityManager == (Object)null || _instance == null)
			{
				return -1;
			}
			int medusaCharId = _instance.MedusaCharId;
			if (medusaCharId < 0 || entityManager.charId != medusaCharId)
			{
				return -1;
			}
			CharAbilities charAbilities = ability.charAbilities;
			if ((Object)(object)charAbilities == (Object)null)
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
				if ((Object)(object)((Il2CppArrayBase<Ability>)(object)abilities)[i] != (Object)null && ((Il2CppObjectBase)((Il2CppArrayBase<Ability>)(object)abilities)[i]).Pointer == ((Il2CppObjectBase)ability).Pointer)
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

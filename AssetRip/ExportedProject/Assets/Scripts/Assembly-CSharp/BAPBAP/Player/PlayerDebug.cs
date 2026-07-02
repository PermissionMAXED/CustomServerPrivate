using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Debugging;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Utilities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Player
{
	public class PlayerDebug : NetworkBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CUpdatePingAndFPS_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PlayerDebug _003C_003E4__this;

			public float seconds;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CUpdatePingAndFPS_003Ed__25(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public PlayerManager playerManager;

		[NonSerialized]
		public DebugNetcodeManager debugNetManager;

		[NonSerialized]
		public DebugGameplayManager debugGameplayManager;

		[NonSerialized]
		public LocalManager localManager;

		[NonSerialized]
		public InputManager inputManager;

		[SerializeField]
		public int fpsEMAWindowSize;

		[NonSerialized]
		public ExpMovingAverage emaFps;

		[SerializeField]
		public int updateStatsCounter;

		[NonSerialized]
		public int svStatsCounter;

		[NonSerialized]
		[SyncVar(hook = "OnPingChanged")]
		public float ping;

		[SyncVar(hook = "OnTimeDilatedChanged")]
		public bool timeDilationDisabled;

		public bool displayIndicators;

		[NonSerialized]
		public Vector3 cinematicCameraPos;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public bool isCooldownEnabled;

		[NonSerialized]
		public bool isInvincibilityEnabled;

		[NonSerialized]
		public bool charSelectorAll;

		[NonSerialized]
		public bool noAggro;

		[NonSerialized]
		public bool isCinematicMode;

		[NonSerialized]
		[SyncVar]
		public bool speedHackEnabled;

		public Action<float, float> _Mirror_SyncVarHookDelegate_ping;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_timeDilationDisabled;

		public float Networkping
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworktimeDilationDisabled
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public bool NetworkspeedHackEnabled
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Initialize(PlayerManager _playerManager)
		{
		}

		public void Start()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void ManagedLateUpdate()
		{
		}

		[Command]
		public void CmdUpdateCamPos(Vector3 pos)
		{
		}

		[IteratorStateMachine(typeof(_003CUpdatePingAndFPS_003Ed__25))]
		public IEnumerator UpdatePingAndFPS(float seconds)
		{
			return null;
		}

		[Command]
		public void CmdUpdatePingAndFps(float ping, float fps)
		{
		}

		public void OnPingChanged(float oldValue, float newValue)
		{
		}

		[Command]
		public void CmdToggleFogOfWarAllClients(bool fowEnabled)
		{
		}

		[ClientRpc]
		public void RpcToggleFogOfWarAllClients(bool fowEnabled)
		{
		}

		public void DebugToggleBRZone(bool isEnabled)
		{
		}

		[Command]
		public void CmdToggleBattleRoyaleZone(bool isEnabled)
		{
		}

		[Server]
		public void ToggleBRZone(bool isEnabled)
		{
		}

		public void DebugToggleNextBRZone()
		{
		}

		[Command]
		public void CmdToggleNextBRZone()
		{
		}

		[Server]
		public void ToggleNextBRZone()
		{
		}

		public void DebugRestartBRZone()
		{
		}

		[Command]
		public void CmdRestartBRZone()
		{
		}

		[Server]
		public void ToggleRestartBRZone()
		{
		}

		[Command]
		public void CmdAddAugmentSelectionRound()
		{
		}

		[Command]
		public void CmdAddAugmentSelection(int tierId)
		{
		}

		[Command]
		public void CmdResetAllEntities()
		{
		}

		[Command]
		public void SvResetAllEntities()
		{
		}

		[Command]
		public void CmdSetNoCooldownModeAll(bool isEnabled)
		{
		}

		public void SetCharNoCooldownEnabled(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetInvincibilityModeAll(bool isEnabled)
		{
		}

		public void SetCharInvincibilityEnabled(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetNoAggro(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetNoAggroAll(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetCharSelectorAll(bool isEnabled)
		{
		}

		[ClientRpc]
		public void RpcSetCharSelectorAll(bool isEnabled)
		{
		}

		[Command]
		public void CmdHealMaxHpAll()
		{
		}

		[Command]
		public void CmdEndMatch(int winnerTeam)
		{
		}

		[Command]
		public void CmdDisposeNetworkPrefabPools()
		{
		}

		[Command]
		public void CmdSetInvincible(bool isInvincible)
		{
		}

		[Command]
		public void CmdSetNoCooldownEnabled(bool isEnabled)
		{
		}

		[Command]
		public void CmdSwitchCharacter(int charToSwitchId)
		{
		}

		[Command]
		public void CmdRespawnCharactersAll()
		{
		}

		[Server]
		public void SwitchCharacter(int charToSwitchId, int skinAssetId = -1)
		{
		}

		[Command]
		public void CmdRessurectDownedCharacterAll()
		{
		}

		[Command]
		public void CmdRessurectDownedCharacter()
		{
		}

		[Command]
		public void CmdApplyHit(int amount)
		{
		}

		[Command]
		public void CmdKillCharacter()
		{
		}

		[Command]
		public void CmdKillAllCharacters()
		{
		}

		[Command]
		public void CmdSetSelectedSkinId(int skinAssetId)
		{
		}

		[Command]
		public void CmdReviveAltarSetActiveAll()
		{
		}

		[Command]
		public void CmdClearAllWorldItems()
		{
		}

		[Command]
		public void CmdClearAllWorldTombstones()
		{
		}

		[Command]
		public void CmdTryEndMatch()
		{
		}

		[Command]
		public void CmdAddRotationLock(bool add)
		{
		}

		[Command]
		public void CmdSetMoveSpeedHack(bool isEnabled)
		{
		}

		public void SetMoveSpeedHack(bool isEnabled)
		{
		}

		[Command]
		public void CmdTeleportOnMap(Vector3 deltaPos)
		{
		}

		[Command]
		public void CmdLobbyForceStartMatch()
		{
		}

		[Command]
		public void CmdLoadModuleMaps()
		{
		}

		[ClientRpc]
		public void RpcLoadModuleMaps()
		{
		}

		[Command]
		public void CmdToggleTimeDilation()
		{
		}

		[Command]
		public void CmdToggleNetSyncServer()
		{
		}

		[Command]
		public void CmdToggleDeltaCompressionServer()
		{
		}

		[Command]
		public void CmdPrintAllEntities()
		{
		}

		[Command]
		public void CmdPrintAllSystemListeners()
		{
		}

		[Command]
		public void CmdPrintSceneCounts()
		{
		}

		[Command]
		public void CmdPrintNetWriters()
		{
		}

		[Command]
		public void CmdSetCinematicMode(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetTrainingAutoRespawnToggle()
		{
		}

		[Command]
		public void CmdActivateStatusEffect(int statusEffectId, float duration)
		{
		}

		[Command]
		public void CmdDeactivateStatusEffect(int statusEffectId)
		{
		}

		[Command]
		public void CmdAddPassive(int passiveId)
		{
		}

		[Command]
		public void CmdRemovePassive(int passiveId)
		{
		}

		[Command]
		public void CmdAddGameModifier(int gameModifierId)
		{
		}

		[Command]
		public void CmdRemoveGameModifier(int gameModifierId)
		{
		}

		[Command]
		public void CmdSpawnBotChar(int charId, Vector3 spawnPos, bool enableAI, int teamId, bool isInvincible, BotDifficulty difficulty)
		{
		}

		[Command]
		public void CmdSpawnEntity(int entityPrefabId, Vector3 position)
		{
		}

		public GameObject DebugSpawnEntity(int entityPrefabId, Vector3 position = default(Vector3))
		{
			return null;
		}

		[Command]
		public void CmdSpawnBrEvent(Vector3 position, int id)
		{
		}

		[Command]
		public void CmdSpawnItem(int itemId, int amount)
		{
		}

		public void SpawnItem(int itemId, int amount)
		{
		}

		[TargetRpc]
		public void TargetPrintAllEntities(NetworkConnection conn, string entities)
		{
		}

		[TargetRpc]
		public void TargetPrintAllSystemListeners(NetworkConnection conn, string systemListeners)
		{
		}

		[TargetRpc]
		public void TargetPrintNetWriters(NetworkConnection conn, string netWriters)
		{
		}

		[Command]
		public void CmdSetMapRotated45(bool isEnabled)
		{
		}

		[ClientRpc]
		public void RpcSetMapRotated45(bool isEnabled)
		{
		}

		[Command]
		public void CmdSpawnAoIFill()
		{
		}

		[Command]
		public void CmdTrainingToggleNpcRespawn(bool isEnabled)
		{
		}

		public string FormatAllEntities()
		{
			return null;
		}

		public void OnTimeDilatedChanged(bool oldValue, bool newValue)
		{
		}

		[Command]
		public void CmdToggleSilhouetteShaderAll(bool isEnabled)
		{
		}

		[ClientRpc]
		public void RpcToggleSilhouetteShaderAll(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetAllySharedVisionEnabled(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetGlobalThirdPersonMode(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetNoClip(bool isEnabled)
		{
		}

		[Command]
		public void CmdSetPlayerName(string playerName)
		{
		}

		public void SetPlayerName(string playerName)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdUpdateCamPos__Vector3(Vector3 pos)
		{
		}

		public static void InvokeUserCode_CmdUpdateCamPos__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdUpdatePingAndFps__Single__Single(float ping, float fps)
		{
		}

		public static void InvokeUserCode_CmdUpdatePingAndFps__Single__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleFogOfWarAllClients__Boolean(bool fowEnabled)
		{
		}

		public static void InvokeUserCode_CmdToggleFogOfWarAllClients__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcToggleFogOfWarAllClients__Boolean(bool fowEnabled)
		{
		}

		public static void InvokeUserCode_RpcToggleFogOfWarAllClients__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleBattleRoyaleZone__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdToggleBattleRoyaleZone__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleNextBRZone()
		{
		}

		public static void InvokeUserCode_CmdToggleNextBRZone(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdRestartBRZone()
		{
		}

		public static void InvokeUserCode_CmdRestartBRZone(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdAddAugmentSelectionRound()
		{
		}

		public static void InvokeUserCode_CmdAddAugmentSelectionRound(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdAddAugmentSelection__Int32(int tierId)
		{
		}

		public static void InvokeUserCode_CmdAddAugmentSelection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdResetAllEntities()
		{
		}

		public static void InvokeUserCode_CmdResetAllEntities(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_SvResetAllEntities()
		{
		}

		public static void InvokeUserCode_SvResetAllEntities(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetNoCooldownModeAll__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetNoCooldownModeAll__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetInvincibilityModeAll__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetInvincibilityModeAll__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetNoAggro__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetNoAggro__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetNoAggroAll__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetNoAggroAll__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetCharSelectorAll__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetCharSelectorAll__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetCharSelectorAll__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_RpcSetCharSelectorAll__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdHealMaxHpAll()
		{
		}

		public static void InvokeUserCode_CmdHealMaxHpAll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdEndMatch__Int32(int winnerTeam)
		{
		}

		public static void InvokeUserCode_CmdEndMatch__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdDisposeNetworkPrefabPools()
		{
		}

		public static void InvokeUserCode_CmdDisposeNetworkPrefabPools(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetInvincible__Boolean(bool isInvincible)
		{
		}

		public static void InvokeUserCode_CmdSetInvincible__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetNoCooldownEnabled__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetNoCooldownEnabled__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSwitchCharacter__Int32(int charToSwitchId)
		{
		}

		public static void InvokeUserCode_CmdSwitchCharacter__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdRespawnCharactersAll()
		{
		}

		public static void InvokeUserCode_CmdRespawnCharactersAll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdRessurectDownedCharacterAll()
		{
		}

		public static void InvokeUserCode_CmdRessurectDownedCharacterAll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdRessurectDownedCharacter()
		{
		}

		public static void InvokeUserCode_CmdRessurectDownedCharacter(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdApplyHit__Int32(int amount)
		{
		}

		public static void InvokeUserCode_CmdApplyHit__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdKillCharacter()
		{
		}

		public static void InvokeUserCode_CmdKillCharacter(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdKillAllCharacters()
		{
		}

		public static void InvokeUserCode_CmdKillAllCharacters(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetSelectedSkinId__Int32(int skinAssetId)
		{
		}

		public static void InvokeUserCode_CmdSetSelectedSkinId__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdReviveAltarSetActiveAll()
		{
		}

		public static void InvokeUserCode_CmdReviveAltarSetActiveAll(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdClearAllWorldItems()
		{
		}

		public static void InvokeUserCode_CmdClearAllWorldItems(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdClearAllWorldTombstones()
		{
		}

		public static void InvokeUserCode_CmdClearAllWorldTombstones(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdTryEndMatch()
		{
		}

		public static void InvokeUserCode_CmdTryEndMatch(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdAddRotationLock__Boolean(bool add)
		{
		}

		public static void InvokeUserCode_CmdAddRotationLock__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetMoveSpeedHack__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetMoveSpeedHack__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdTeleportOnMap__Vector3(Vector3 deltaPos)
		{
		}

		public static void InvokeUserCode_CmdTeleportOnMap__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdLobbyForceStartMatch()
		{
		}

		public static void InvokeUserCode_CmdLobbyForceStartMatch(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdLoadModuleMaps()
		{
		}

		public static void InvokeUserCode_CmdLoadModuleMaps(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcLoadModuleMaps()
		{
		}

		public static void InvokeUserCode_RpcLoadModuleMaps(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleTimeDilation()
		{
		}

		public static void InvokeUserCode_CmdToggleTimeDilation(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleNetSyncServer()
		{
		}

		public static void InvokeUserCode_CmdToggleNetSyncServer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleDeltaCompressionServer()
		{
		}

		public static void InvokeUserCode_CmdToggleDeltaCompressionServer(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdPrintAllEntities()
		{
		}

		public static void InvokeUserCode_CmdPrintAllEntities(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdPrintAllSystemListeners()
		{
		}

		public static void InvokeUserCode_CmdPrintAllSystemListeners(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdPrintSceneCounts()
		{
		}

		public static void InvokeUserCode_CmdPrintSceneCounts(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdPrintNetWriters()
		{
		}

		public static void InvokeUserCode_CmdPrintNetWriters(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetCinematicMode__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetCinematicMode__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetTrainingAutoRespawnToggle()
		{
		}

		public static void InvokeUserCode_CmdSetTrainingAutoRespawnToggle(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdActivateStatusEffect__Int32__Single(int statusEffectId, float duration)
		{
		}

		public static void InvokeUserCode_CmdActivateStatusEffect__Int32__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdDeactivateStatusEffect__Int32(int statusEffectId)
		{
		}

		public static void InvokeUserCode_CmdDeactivateStatusEffect__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdAddPassive__Int32(int passiveId)
		{
		}

		public static void InvokeUserCode_CmdAddPassive__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdRemovePassive__Int32(int passiveId)
		{
		}

		public static void InvokeUserCode_CmdRemovePassive__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdAddGameModifier__Int32(int gameModifierId)
		{
		}

		public static void InvokeUserCode_CmdAddGameModifier__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdRemoveGameModifier__Int32(int gameModifierId)
		{
		}

		public static void InvokeUserCode_CmdRemoveGameModifier__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSpawnBotChar__Int32__Vector3__Boolean__Int32__Boolean__BotDifficulty(int charId, Vector3 spawnPos, bool enableAI, int teamId, bool isInvincible, BotDifficulty difficulty)
		{
		}

		public static void InvokeUserCode_CmdSpawnBotChar__Int32__Vector3__Boolean__Int32__Boolean__BotDifficulty(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSpawnEntity__Int32__Vector3(int entityPrefabId, Vector3 position)
		{
		}

		public static void InvokeUserCode_CmdSpawnEntity__Int32__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSpawnBrEvent__Vector3__Int32(Vector3 position, int id)
		{
		}

		public static void InvokeUserCode_CmdSpawnBrEvent__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSpawnItem__Int32__Int32(int itemId, int amount)
		{
		}

		public static void InvokeUserCode_CmdSpawnItem__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetPrintAllEntities__NetworkConnection__String(NetworkConnection conn, string entities)
		{
		}

		public static void InvokeUserCode_TargetPrintAllEntities__NetworkConnection__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetPrintAllSystemListeners__NetworkConnection__String(NetworkConnection conn, string systemListeners)
		{
		}

		public static void InvokeUserCode_TargetPrintAllSystemListeners__NetworkConnection__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetPrintNetWriters__NetworkConnection__String(NetworkConnection conn, string netWriters)
		{
		}

		public static void InvokeUserCode_TargetPrintNetWriters__NetworkConnection__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetMapRotated45__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetMapRotated45__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetMapRotated45__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_RpcSetMapRotated45__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSpawnAoIFill()
		{
		}

		public static void InvokeUserCode_CmdSpawnAoIFill(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdTrainingToggleNpcRespawn__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdTrainingToggleNpcRespawn__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdToggleSilhouetteShaderAll__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdToggleSilhouetteShaderAll__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcToggleSilhouetteShaderAll__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_RpcToggleSilhouetteShaderAll__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetAllySharedVisionEnabled__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetAllySharedVisionEnabled__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetGlobalThirdPersonMode__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetGlobalThirdPersonMode__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetNoClip__Boolean(bool isEnabled)
		{
		}

		public static void InvokeUserCode_CmdSetNoClip__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdSetPlayerName__String(string playerName)
		{
		}

		public static void InvokeUserCode_CmdSetPlayerName__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerDebug()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}

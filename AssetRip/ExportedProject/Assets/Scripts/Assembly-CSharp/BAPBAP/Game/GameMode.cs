using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Entities;
using BAPBAP.Game.Dimensions;
using BAPBAP.Local;
using BAPBAP.Maps;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using BAPBAP.Player;
using BAPBAP.UI;
using BAPBAP.UI.Mobile;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game
{
	public class GameMode : NetworkBehaviour
	{
		[Serializable]
		public class GameModifierChance
		{
			public GameModifierSO gameModifier;

			[Range(0f, 1f)]
			public float normChance;
		}

		[Serializable]
		public class AugmentSelectionChances
		{
			[Range(0f, 1f)]
			public float commonTierProbability;

			[Range(0f, 1f)]
			public float uncommonTierProbability;

			[Range(0f, 1f)]
			public float rareTierProbability;

			[Range(0f, 1f)]
			public float epicTierProbability;

			[Range(0f, 1f)]
			public float legendaryTierProbability;
		}

		public struct SpawnedEntityInfo
		{
			public uint netId;

			public int entityPrefabId;
		}

		public class EntityInstanceObject
		{
			public GameObject instanceObj;

			public GameObject originalPrefab;

			public int mapEntityIndex;

			public Vector3 position;

			public Quaternion rotation;

			public Vector3 scale;
		}

		public class SpawnableAssetPercElement
		{
			public float percentage;

			public float spawnChance;

			public List<EntityInstanceObject> entityObjs;

			public SpawnableAssetPercElement(float percentage, float spawnChance, List<EntityInstanceObject> entityObjs)
			{
			}
		}

		public struct EntityMapIconSync
		{
			public uint netId;

			public int prefabId;

			public Vector2 worldPos;

			public override string ToString()
			{
				return null;
			}
		}

		[CompilerGenerated]
		public sealed class _003CLoadCoroutine_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameMode _003C_003E4__this;

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
			public _003CLoadCoroutine_003Ed__79(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CWaitToDestroyMapIconCoroutine_003Ed__135 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameMode _003C_003E4__this;

			public uint netId;

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
			public _003CWaitToDestroyMapIconCoroutine_003Ed__135(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CWaitToEnableSpectatorModeOnKilledPlayerSubroutine_003Ed__178 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameMode _003C_003E4__this;

			public PlayerManager killedPlayerManager;

			public int killerPlayerId;

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
			public _003CWaitToEnableSpectatorModeOnKilledPlayerSubroutine_003Ed__178(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CWaitToPlayAugmentAudio_003Ed__148 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameMode _003C_003E4__this;

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
			public _003CWaitToPlayAugmentAudio_003Ed__148(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CWaitToUpdateSpectatorTargetOnPlayer_003Ed__181 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PlayerManager playerManager;

			public int targetPlayerId;

			public PlayerSpectate.CycleAction cycleAction;

			[NonSerialized]
			public int _003ClastPlayerId_003E5__2;

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
			public _003CWaitToUpdateSpectatorTargetOnPlayer_003Ed__181(int _003C_003E1__state)
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
		public GameManager gameManager;

		[NonSerialized]
		public GameNetworkManager netManager;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public WebServer webServer;

		[NonSerialized]
		public EntityAssetsManager entityAssetsManager;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UICanvasEffect uiCanvasEffect;

		[NonSerialized]
		public UIGameMode uiGameMode;

		[NonSerialized]
		public UIPopUp uiPopUp;

		[NonSerialized]
		public UIKillFeed uiKillFeed;

		[NonSerialized]
		public UIMessages uiMessages;

		[NonSerialized]
		public UIMinimap uiMinimap;

		[NonSerialized]
		public UIMobileControls uiMobileControls;

		[SerializeField]
		[Space(10f)]
		public string[] levelNames;

		[SerializeField]
		[Tooltip("Is the minimap ui enabled for this gamemode?")]
		[Header("Gamemode Configs")]
		public bool enableMinimap;

		[SerializeField]
		[Tooltip("Check alive teammates to heal on kill?")]
		public bool killHealTeamCheck;

		[SerializeField]
		[Tooltip("How much percentage to heal a player when killing a character")]
		public float killHealPercentage;

		[Tooltip("How much it will take to heal a player over time when killing a character")]
		[SerializeField]
		public float killHealDuration;

		[Tooltip("The number of steps to heal a player during the duration when killing a character")]
		[SerializeField]
		public int killHealIntervals;

		[SerializeField]
		public float matchTime;

		[SerializeField]
		[Tooltip("Should this gamemode play the start match countdown and the end match sequence?")]
		[Header("Match Time Configs")]
		public bool startAndEndCountdownsEnabled;

		[SerializeField]
		public float matchCountdownTimeLobby;

		[SerializeField]
		public float matchCountdownTimeMatchmaking;

		[SerializeField]
		public float matchEndTime;

		[SerializeField]
		[Tooltip("Ability damage multiplier value for duos")]
		[Header("Team Multipliers Configs")]
		public float abilityDamageMultiplierDuos;

		[SerializeField]
		[Tooltip("Ability damage multiplier value for trios")]
		public float abilityDamageMultiplierTrios;

		[NonSerialized]
		public float currentAbilityDamageMultiplier;

		[Header("Spectator Configs")]
		[Tooltip("Should activate the spectator mode when a player gets killed?")]
		[SerializeField]
		public bool enableSpectatorMode;

		[Tooltip("When a player gets killed, how much to wait before activating the spectator mode")]
		[SerializeField]
		public float spectatorModeEnableDelay;

		[SerializeField]
		[Tooltip("Should a teammate only be able to spectate their other teammates, or should it be able to spectate anyone?")]
		public bool spectateOnlyTeammates;

		[SerializeField]
		[Header("Game Modifiers")]
		public bool enableGameModifiers;

		[Tooltip("(Only for dev lobby) Whats the chance for each spawn count. For example: [Element 0: 0.5] will have a 50% chance of spawning zero modifiers, [Element 1: 0.2] will have a 20% chance of spawning one.")]
		[Range(0f, 1f)]
		[SerializeField]
		public float[] devGameModifierCountPercentages;

		[SerializeField]
		public GameModifierChance[] devLobbyGameModifierPool;

		[SerializeField]
		[Header("Augments")]
		public bool enableAugments;

		[SerializeField]
		[Tooltip("List of augment selections for the gamemode to trigger, by index. If index exceeded this length, it will be clamped so the last index will be always used.")]
		public AugmentSelectionChances[] augmentSelectionsPerRound;

		[SerializeField]
		[Tooltip("Should characters get downed as ghosts when killed? If disabled, characters kill fully die instantly.")]
		[Header("Game Configs")]
		public bool enableDowned;

		[SerializeField]
		[Tooltip("Once a character dies, should it drop his inventory items on the world?")]
		public bool dropInventoryOnDeath;

		[SerializeField]
		[ConditionalHide("dropInventoryOnDeath", true)]
		[Tooltip("Once a character dies, should it drop the gold from his inventory on the world?")]
		public bool dropGold;

		[ConditionalHide("dropInventoryOnDeath", true)]
		[Tooltip("Once a character dies, should it drop the consumables from his inventory on the world?")]
		[SerializeField]
		public bool dropConsumables;

		[Tooltip("Once an enemy dies, always drop this fixed amount of gold on the world.")]
		[SerializeField]
		[Min(0f)]
		public int dropFixedGoldAmount;

		[Tooltip("Once killing an enemy, how much gold to grant to the killer player")]
		[SerializeField]
		public int killGoldAmount;

		[NonSerialized]
		public int selectedLevel;

		[NonSerialized]
		public bool isLoading;

		[NonSerialized]
		public int levelId;

		[NonSerialized]
		public GameObject currentEnvObj;

		[NonSerialized]
		public LevelRuntimeManager currentEnvManager;

		[NonSerialized]
		public Vector2Int currentMapSize;

		[NonSerialized]
		public float currentMapDiagonal;

		[NonSerialized]
		public float[] currentItemTierDropChanceMult;

		[NonSerialized]
		public float uniqueItemChanceMult;

		[NonSerialized]
		public float pinChanceMult;

		[NonSerialized]
		public float potionDropChanceMult;

		[NonSerialized]
		public float goldDropAmountMult;

		[NonSerialized]
		public List<GameModifier> currentGameModifiers;

		[NonSerialized]
		public List<MatchmakingDimensionData> currentDimensionData;

		[NonSerialized]
		public List<DimensionZone> activeDimensions;

		[NonSerialized]
		public Dictionary<int, int> spawnPointIndexByTeam;

		[NonSerialized]
		public List<int> availableSpawnPoints;

		[NonSerialized]
		public List<Vector3> spawnPoints;

		[NonSerialized]
		public List<Vector3> dimensionSpawnPoints;

		[NonSerialized]
		public int botSpawnIndex;

		[NonSerialized]
		public int botTeamSpawnIndex;

		[NonSerialized]
		public List<GameObject> spawnedObjs;

		[NonSerialized]
		public Dictionary<int, GameObject> spawnedEntitiesBySourceInstId;

		[NonSerialized]
		public List<EntityMapIconSync> mapEntitiesIconSync;

		[NonSerialized]
		public float matchRemainingTime;

		[SyncVar]
		[NonSerialized]
		public int matchRemainingTimeSync;

		[NonSerialized]
		public List<int> globalAugmentRoundTiers;

		public Vector2Int CurrentMapSize => default(Vector2Int);

		public int NetworkmatchRemainingTimeSync
		{
			get
			{
				return 0;
			}
			[param: In]
			set
			{
			}
		}

		public virtual void Awake()
		{
		}

		public void Load()
		{
		}

		public void Unload()
		{
		}

		[IteratorStateMachine(typeof(_003CLoadCoroutine_003Ed__79))]
		public IEnumerator LoadCoroutine()
		{
			return null;
		}

		public LevelMMCache GetMapDataMMCacheByLevelId(int levelId)
		{
			return null;
		}

		public virtual void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void OnMatchBegin()
		{
		}

		public virtual void OnMatchStarted()
		{
		}

		public virtual void OnMatchEnded(int winnerTeamId)
		{
		}

		public virtual void OnTimerEnd()
		{
		}

		public virtual void OnNPCDestroyed(EntityManager npcEntity)
		{
		}

		public virtual void OnPlayerHit(PlayerManager atkPlayer, PlayerManager defPlayer, int damage)
		{
		}

		public virtual void OnPlayerHealed(PlayerManager healedPlayer, int hp)
		{
		}

		public virtual void OnPlayerDowned(PlayerManager killerPlayer, PlayerManager killedPlayer)
		{
		}

		public virtual void OnPlayerKilled(PlayerManager killerPlayer, int killerPlayerId, PlayerManager killedPlayer, int killedPlayerId)
		{
		}

		public virtual void OnPlayerCharRespawned(EntityManager entityManager)
		{
		}

		public virtual void OnPlayerCharSpawned(EntityManager entityManager)
		{
		}

		public virtual void OnPlayerAssisted(PlayerManager assistingPlayer, PlayerManager killedPlayer)
		{
		}

		public virtual void OnPlayerAdded(PlayerManager addedPlayer, int teamId = -1)
		{
		}

		public virtual void OnPlayerRemoved(PlayerManager removedPlayer)
		{
		}

		public virtual void SpawnNetworkedObjects()
		{
		}

		public void SpawnPercentageOfNetworkedPrefabs(List<EntityInstanceObject> objPrefabList, float percentage, float spawnChance = 1f)
		{
		}

		public GameObject SpawnEntityPrefab(EntityInstanceObject mapObjInst, float spawnChance = 1f)
		{
			return null;
		}

		public GameObject InstantiateEntity(GameObject prefabObj, Vector3 worldPos, Quaternion rot = default(Quaternion), Vector3 scale = default(Vector3), GameObject sourceInstance = null)
		{
			return null;
		}

		[Server]
		public GameObject SpawnEntity(GameObject prefabObj, Vector3 worldPos, Quaternion rot = default(Quaternion), Vector3 scale = default(Vector3))
		{
			return null;
		}

		public void AssignSourceInstanceData(GameObject instance, GameObject sourceInstance)
		{
		}

		public void AssignAllSpawnedEntityData()
		{
		}

		public void GetMapEntitySyncIds()
		{
		}

		[Server]
		public void SvTargetSyncMapEntities(NetworkConnection conn)
		{
		}

		[TargetRpc]
		public void TargetSyncMapEntities(NetworkConnection conn, List<EntityMapIconSync> entitiesToSync)
		{
		}

		public void ClSyncMapEntities(List<EntityMapIconSync> entitiesSync)
		{
		}

		public virtual void DestroyNetworkedObjects()
		{
		}

		public void SpawnMeteorite(Vector2 worldPos, GM_MeteorShower.Config meteorConfig)
		{
		}

		public void TrackSpawnedEntity(GameObject entityInstance)
		{
		}

		public List<Vector3> GetDimensionSpawnPoints()
		{
			return null;
		}

		public void ReserveSpawnPoint(int teamId, int spawnIndex)
		{
		}

		public virtual Vector3 SelectSpawnPoint(int teamId)
		{
			return default(Vector3);
		}

		public void SpawnPlayerChar(PlayerManager playerManager, Vector3 spawnPos = default(Vector3))
		{
		}

		public void SpawnAllBotsFill(int squadSize = 1, int maxBotsToFill = 6, BotDifficulty difficulty = BotDifficulty.Easy)
		{
		}

		public void SpawnBotSquad(int teamId, int squadSize, Vector3 spawnPos = default(Vector3), BotDifficulty difficulty = BotDifficulty.Easy)
		{
		}

		public EntityManager SpawnBotChar(Vector3 spawnPos = default(Vector3), int charId = -1, BotDifficulty difficulty = BotDifficulty.Medium)
		{
			return null;
		}

		public EntityManager SpawnBotChar(int teamId, Vector3 spawnPos = default(Vector3), int charId = -1, BotDifficulty difficulty = BotDifficulty.Medium)
		{
			return null;
		}

		public EntityManager SpawnBotChar(int playerId, int teamId, Vector3 spawnPos = default(Vector3), int charId = -1, BotDifficulty difficulty = BotDifficulty.Medium)
		{
			return null;
		}

		public void RevivePlayer(PlayerManager playerManager, Vector3 spawnPosition)
		{
		}

		public EntityManager ReviveBot(int playerId, int teamId, int charId, Vector3 spawnPosition)
		{
			return null;
		}

		[ClientRpc]
		public void RpcStartCountdown()
		{
		}

		[ClientRpc]
		public void RpcSetCountdownUI_2()
		{
		}

		[ClientRpc]
		public void RpcSetCountdownUI_1()
		{
		}

		[ClientRpc]
		public void RpcSetCountdownUI_GO()
		{
		}

		[ClientRpc]
		public void RpcSendGameModeEvent(string eventMsg)
		{
		}

		[ClientRpc]
		public void RpcSetReviveInactive(uint netId)
		{
		}

		[ClientRpc]
		public void RpcSetReviveActive(uint netId)
		{
		}

		[ClientRpc]
		public void RpcSetSupplyDropLanded(uint supplyDropNetId)
		{
		}

		public void DestroyMapIcon(uint netId)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToDestroyMapIconCoroutine_003Ed__135))]
		public IEnumerator WaitToDestroyMapIconCoroutine(uint netId)
		{
			return null;
		}

		[ClientRpc]
		public void RpcSpawnMapIcon(uint netId, int prefabId, Vector2 worldPos)
		{
		}

		[ClientRpc]
		public void RpcDestroyMapIcon(uint netId)
		{
		}

		[ClientRpc]
		public void RpcAddMinimapIconByTeamId(uint eventNetId, int entityPrefabId, Vector3 worldPos, bool ping, int teamId)
		{
		}

		[ClientRpc]
		public void RpcSpawnGlobalSfxAtPosition(SfxEventData sfxEventData, uint netId, float distMultiplier, float minDist, SfxTeamTarget teamTarget, int teamId)
		{
		}

		[ClientRpc]
		public void RpcDestroyGlobalSfxAtPosition(int sfxId, uint netId)
		{
		}

		[ClientRpc]
		public void RpcOnCharDisconnected(Vector3 worldPos)
		{
		}

		[ClientRpc]
		public void RpcOnCharDownedVfx(Vector3 worldPos)
		{
		}

		public void InitializeRoundAugmentSelection()
		{
		}

		[Server]
		public void SvInitializeRoundAugmentSelectionStart(NetworkConnection conn, PlayerManager player)
		{
		}

		[ClientRpc]
		public void RpcShowAugmentMessage()
		{
		}

		[TargetRpc]
		public void TargetRpcShowAugmentMessage(NetworkConnection conn)
		{
		}

		public void ClShowAugmentMessage()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToPlayAugmentAudio_003Ed__148))]
		public IEnumerator WaitToPlayAugmentAudio()
		{
			return null;
		}

		public void TickGameModifiers(float dt)
		{
		}

		public int GetRandomModifierCount(float[] gameModifierCountPercentages)
		{
			return 0;
		}

		public int[] GetRandomGameModifierIdsFromPool(int modifierCount, GameModifierChance[] gameModifierPool)
		{
			return null;
		}

		public void InitializeGameModifiersMatchMaking(int[] gameModifierIds)
		{
		}

		public void InitializeDimensionDataMatchMaking(List<MatchmakingDimensionData> dimensionData)
		{
		}

		public void SvEnableGameModifiers(int[] modifierIds)
		{
		}

		public void SvDisableAllGameModifiers()
		{
		}

		public void SvAddGameModifier(int modifierId)
		{
		}

		public void SvRemoveGameModifier(int modifierId)
		{
		}

		public void SvTargetInitializeAllGameModifiers(NetworkConnection conn)
		{
		}

		public void ClDisableAllGameModifiers()
		{
		}

		[ClientRpc]
		public void RpcAddGameModifier(int modifierId)
		{
		}

		[ClientRpc]
		public void RpcRemoveGameModifier(int modifierId)
		{
		}

		[TargetRpc]
		public void TargetRpcAddGameModifier(NetworkConnection conn, int modifierId)
		{
		}

		public void ClAddGameModifier(int modifierId)
		{
		}

		public void ClRemoveGameModifier(int modifierId)
		{
		}

		[ClientRpc]
		public void RpcPlayGameModifierStart()
		{
		}

		[TargetRpc]
		public void TargetRpcPlayGameModifierStart(NetworkConnection conn)
		{
		}

		public void SetGameModeMultiplierTeamSize(int teamSize)
		{
		}

		public int GetGameModeTeamSize(int gameModeId)
		{
			return 0;
		}

		[Server]
		public void ResetAllPlayers()
		{
		}

		public void ReviveSquad(PlayerManager player, float spawnPosRadius = 1f)
		{
		}

		public void HealPlayersFromKill(List<int> playerIdsToHeal, int killedPlayerId)
		{
		}

		public void GetLastHittedPlayerId(EntityManager killedCharManager, ref int killerPlayerId)
		{
		}

		public void RegisterPlayerInventoryStats(EntityManager entityManager, PlayerManager player)
		{
		}

		public void RegisterAllAssistsForKillerPlayer(EntityManager killedCharManager, PlayerManager killedPlayerManager, PlayerManager killerPlayerManager, int killedCharId)
		{
		}

		public void AddAssistedPlayersToPlayersToHeal(EntityManager killedCharManager, PlayerManager killedPlayerManager, PlayerManager killerPlayerManager, int killedCharId, List<int> playerIdsToHeal)
		{
		}

		public void OnTeammateKilledCallback(PlayerManager killedPlayer)
		{
		}

		public void WaitToEnableSpectatorModeOnKilledPlayer(PlayerManager killedPlayerManager, int killerPlayerId)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToEnableSpectatorModeOnKilledPlayerSubroutine_003Ed__178))]
		public IEnumerator WaitToEnableSpectatorModeOnKilledPlayerSubroutine(PlayerManager killedPlayerManager, int killerPlayerId)
		{
			return null;
		}

		public void EnableSpectatorModeOnKilledPlayer(PlayerManager killedPlayerManager, int killerPlayerId)
		{
		}

		public void UpdateSpectatorPlayersTarget(int killedPlayerId, int killerPlayerId)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToUpdateSpectatorTargetOnPlayer_003Ed__181))]
		public IEnumerator WaitToUpdateSpectatorTargetOnPlayer(PlayerManager playerManager, int targetPlayerId, PlayerSpectate.CycleAction cycleAction = PlayerSpectate.CycleAction.None)
		{
			return null;
		}

		public void CreatePlayerTombstone(GameObject killedCharObj, PlayerManager killerPlayerManager, string killedCharName, string killerCharName)
		{
		}

		public void SpawnTombstone(Vector3 worldPos, int tombstoneAssetId, string killedName, string killerName)
		{
		}

		[Server]
		public void DestroyAllHitboxesImmediate()
		{
		}

		[Server]
		public void DestroyAllCharactersImmediate()
		{
		}

		[Server]
		public void DestroyCharacter(EntityManager entityManager, int playerId)
		{
		}

		[Server]
		public void KillCharacter(int killerPlayerId, EntityManager killedEntityManager)
		{
		}

		[Server]
		public void KillNpc(int killerPlayerId, EntityManager killedEntityManager)
		{
		}

		[Server]
		public void KillPlayerSecondaryCharacters(PlayerManager playerManager)
		{
		}

		[Server]
		public void DestroyPlayerOwnedCharactersImmediate(PlayerManager playerManager)
		{
		}

		[ClientRpc]
		public void RpcNPCKillEvent(int killerPlayerId, Vector3 targetPos)
		{
		}

		[ClientRpc]
		public void RpcKillEvent(GameObject killerPlayerObj, GameObject killedPlayerObj, bool killedCharShowKill, bool killedCharIsPrimary, int killedCharInstId, uint killedCharNetId, int killedCharOwnerPlayerId, bool squadEliminated, int _killerPlayerId, string _killerCharName, int _killerTeamId, int _killerCharId, int _killedPlayerId, string _killedCharName, int _killedTeamId, int _killedCharId)
		{
		}

		[ClientRpc]
		public void RpcSpawnDownedKillFeedElement(GameObject killerPlayerObj, int killerPlayerId, int killerCharId, string killerName, int killerTeamId, GameObject killedPlayerObj, int killedPlayerId, int killedCharId, string killedName, int killedTeamId)
		{
		}

		[ClientRpc]
		public void RpcDownedEvent(int killerPlayerId, GameObject killedPlayerObj, bool killedCharShowKill, bool killedCharIsPrimary, string killedName, int killerTotalKills, bool squadEliminated, bool downed)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_TargetSyncMapEntities__NetworkConnection__List_00601(NetworkConnection conn, List<EntityMapIconSync> entitiesToSync)
		{
		}

		public static void InvokeUserCode_TargetSyncMapEntities__NetworkConnection__List_00601(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcStartCountdown()
		{
		}

		public static void InvokeUserCode_RpcStartCountdown(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetCountdownUI_2()
		{
		}

		public static void InvokeUserCode_RpcSetCountdownUI_2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetCountdownUI_1()
		{
		}

		public static void InvokeUserCode_RpcSetCountdownUI_1(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetCountdownUI_GO()
		{
		}

		public static void InvokeUserCode_RpcSetCountdownUI_GO(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendGameModeEvent__String(string eventMsg)
		{
		}

		public static void InvokeUserCode_RpcSendGameModeEvent__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetReviveInactive__UInt32(uint netId)
		{
		}

		public static void InvokeUserCode_RpcSetReviveInactive__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetReviveActive__UInt32(uint netId)
		{
		}

		public static void InvokeUserCode_RpcSetReviveActive__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSetSupplyDropLanded__UInt32(uint supplyDropNetId)
		{
		}

		public static void InvokeUserCode_RpcSetSupplyDropLanded__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnMapIcon__UInt32__Int32__Vector2(uint netId, int prefabId, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_RpcSpawnMapIcon__UInt32__Int32__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyMapIcon__UInt32(uint netId)
		{
		}

		public static void InvokeUserCode_RpcDestroyMapIcon__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcAddMinimapIconByTeamId__UInt32__Int32__Vector3__Boolean__Int32(uint eventNetId, int entityPrefabId, Vector3 worldPos, bool ping, int teamId)
		{
		}

		public static void InvokeUserCode_RpcAddMinimapIconByTeamId__UInt32__Int32__Vector3__Boolean__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnGlobalSfxAtPosition__SfxEventData__UInt32__Single__Single__SfxTeamTarget__Int32(SfxEventData sfxEventData, uint netId, float distMultiplier, float minDist, SfxTeamTarget teamTarget, int teamId)
		{
		}

		public static void InvokeUserCode_RpcSpawnGlobalSfxAtPosition__SfxEventData__UInt32__Single__Single__SfxTeamTarget__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyGlobalSfxAtPosition__Int32__UInt32(int sfxId, uint netId)
		{
		}

		public static void InvokeUserCode_RpcDestroyGlobalSfxAtPosition__Int32__UInt32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnCharDisconnected__Vector3(Vector3 worldPos)
		{
		}

		public static void InvokeUserCode_RpcOnCharDisconnected__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnCharDownedVfx__Vector3(Vector3 worldPos)
		{
		}

		public static void InvokeUserCode_RpcOnCharDownedVfx__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcShowAugmentMessage()
		{
		}

		public static void InvokeUserCode_RpcShowAugmentMessage(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcShowAugmentMessage__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetRpcShowAugmentMessage__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcAddGameModifier__Int32(int modifierId)
		{
		}

		public static void InvokeUserCode_RpcAddGameModifier__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcRemoveGameModifier__Int32(int modifierId)
		{
		}

		public static void InvokeUserCode_RpcRemoveGameModifier__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcAddGameModifier__NetworkConnection__Int32(NetworkConnection conn, int modifierId)
		{
		}

		public static void InvokeUserCode_TargetRpcAddGameModifier__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlayGameModifierStart()
		{
		}

		public static void InvokeUserCode_RpcPlayGameModifierStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcPlayGameModifierStart__NetworkConnection(NetworkConnection conn)
		{
		}

		public static void InvokeUserCode_TargetRpcPlayGameModifierStart__NetworkConnection(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcNPCKillEvent__Int32__Vector3(int killerPlayerId, Vector3 targetPos)
		{
		}

		public static void InvokeUserCode_RpcNPCKillEvent__Int32__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcKillEvent__GameObject__GameObject__Boolean__Boolean__Int32__UInt32__Int32__Boolean__Int32__String__Int32__Int32__Int32__String__Int32__Int32(GameObject killerPlayerObj, GameObject killedPlayerObj, bool killedCharShowKill, bool killedCharIsPrimary, int killedCharInstId, uint killedCharNetId, int killedCharOwnerPlayerId, bool squadEliminated, int _killerPlayerId, string _killerCharName, int _killerTeamId, int _killerCharId, int _killedPlayerId, string _killedCharName, int _killedTeamId, int _killedCharId)
		{
		}

		public static void InvokeUserCode_RpcKillEvent__GameObject__GameObject__Boolean__Boolean__Int32__UInt32__Int32__Boolean__Int32__String__Int32__Int32__Int32__String__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSpawnDownedKillFeedElement__GameObject__Int32__Int32__String__Int32__GameObject__Int32__Int32__String__Int32(GameObject killerPlayerObj, int killerPlayerId, int killerCharId, string killerName, int killerTeamId, GameObject killedPlayerObj, int killedPlayerId, int killedCharId, string killedName, int killedTeamId)
		{
		}

		public static void InvokeUserCode_RpcSpawnDownedKillFeedElement__GameObject__Int32__Int32__String__Int32__GameObject__Int32__Int32__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDownedEvent__Int32__GameObject__Boolean__Boolean__String__Int32__Boolean__Boolean(int killerPlayerId, GameObject killedPlayerObj, bool killedCharShowKill, bool killedCharIsPrimary, string killedName, int killerTotalKills, bool squadEliminated, bool downed)
		{
		}

		public static void InvokeUserCode_RpcDownedEvent__Int32__GameObject__Boolean__Boolean__String__Int32__Boolean__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static GameMode()
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

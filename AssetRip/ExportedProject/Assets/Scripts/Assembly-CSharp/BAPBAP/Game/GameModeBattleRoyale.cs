using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Content;
using BAPBAP.Entities;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Player;
using BAPBAP.Utilities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game
{
	public class GameModeBattleRoyale : GameMode
	{
		[Serializable]
		public class SerializedMapZones
		{
			public SerializedZoneRound[] zones;

			public string ArrayLabels(SerializedZoneRound zone, int i)
			{
				return null;
			}

			public SerializedMapZones(SerializedZoneRound[] zones)
			{
			}
		}

		[Serializable]
		public class SerializedZoneRound
		{
			[Serializable]
			public class NpcSpawn
			{
				[Tooltip("Is this zone configured to randomly spawn npcs?")]
				public bool doNpcSpawns;

				public Z_Obj_SpawnEntity_SO npcSpawnObj;

				[Tooltip("Range of npcs to spawn randomly inside the current zone. If left at 0, will use the object's default values")]
				public IntRange overrideCountRange;

				[Tooltip("The min distance from other spawned entities to allow spawning. If left at 0, will use the object's default values")]
				public float overrideDensity;
			}

			[Min(0f)]
			[Tooltip("Time until the zone starts moving, in seconds.")]
			[Header("Zone Settings")]
			public int secondsUntilZoneStart;

			[Min(0f)]
			[Tooltip("How much time the zone will be moving for (NOTE: This variable changes based on the amount traveled)")]
			public int secondsZoneMoveDuration;

			[Tooltip("What percentage from original radius to 0 the zone radius should be.")]
			[Range(0f, 100f)]
			public int closePercentage;

			[Tooltip("The percentage of damage to apply to characters out of the zone.")]
			[Range(0f, 100f)]
			public int damagePercentage;

			[Space(5f)]
			[Header("Zone Modifiers")]
			[Range(0f, 1f)]
			[Tooltip("Normalized influence to reduce the until zone start duration based on current/total players factor.\nI.e: if set to 1, XX% of the players in the game will directly correlate to a XX% reduction of the duration. If set to 0, no changes to the duration will be made.")]
			public float untilStartPlayerFactorInfluence;

			[Range(0f, 1f)]
			[Tooltip("Normalized influence to reduce the zone move duration (increase zone move speed) based on current/total players factor.\nI.e: if set to 1, XX% of the players in the game will directly correlate in a XX% reduction of the duration. If set to 0, no changes to the duration will be made.")]
			public float moveDurationPlayerFactorInfluence;

			[NamedArray(typeof(ItemTiers), 0)]
			public float[] itemTierDropChanceMult;

			[Tooltip("Tries to spawn each event entry at the start of the zone.")]
			[Header("Events")]
			[Space(5f)]
			public EventDropChance[] supplyDropChances;

			[Space(5f)]
			public NpcSpawn npcSpawn;

			[Space(5f)]
			public bool doAugments;

			public float GetClosePercentageNorm()
			{
				return 0f;
			}

			public float GetDamagePercentageNorm()
			{
				return 0f;
			}

			public override string ToString()
			{
				return null;
			}
		}

		public class ZoneData
		{
			public Vector2 targetPos;

			public float targetRadius;

			public float waitStartSeconds;

			public float moveSeconds;

			public float damagePercentage;

			public EventDropChance[] supplyDropChances;

			public float[] itemTierDropChanceMult;

			public bool doAugments;

			public SerializedZoneRound.NpcSpawn npcSpawn;

			public ZoneData(Vector2 zonePos, float targetRadius, float zoneStartSeconds, float zoneMoveSeconds, float damagePercentage, EventDropChance[] supplyDropsChances, float[] itemTierDropChanceMult, bool doAugments, SerializedZoneRound.NpcSpawn npcSpawn)
			{
			}
		}

		[Serializable]
		public struct EventDropChance
		{
			[Serializable]
			public struct EventDrop
			{
				public GameObject eventDropPrefab;

				public Z_Obj_SO eventObjective;

				public float eventDropChance;
			}

			public float eventDropChance;

			public EventDrop[] supplyDropChances;
		}

		public enum MatchState
		{
			WaitingForFirstZone = 0,
			WaitingToStartZone = 1,
			ClosingZone = 2,
			AllZonesEnded = 3
		}

		[CompilerGenerated]
		public sealed class _003CSpecialEvent_003Ed__73 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameModeBattleRoyale _003C_003E4__this;

			public Vector3 dropPosition;

			public GameObject entityPrefab;

			[NonSerialized]
			public int _003Ci_003E5__2;

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
			public _003CSpecialEvent_003Ed__73(int _003C_003E1__state)
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
		public sealed class _003CUpdateTimerUI_003Ed__65 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameModeBattleRoyale _003C_003E4__this;

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
			public _003CUpdateTimerUI_003Ed__65(int _003C_003E1__state)
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

		[ExHeader("Battle Royale Configs", 1f, 1f, 0f)]
		[SerializeField]
		[Header("Default Zone Config")]
		public float mediumTimeStart;

		[SerializeField]
		[Tooltip("For maps with a size smaller than 230 units")]
		public SerializedMapZones zoneRoundDefaultMedium;

		[SerializeField]
		public float largeTimeStart;

		[Tooltip("For maps with a size between 230 and 310 units")]
		[SerializeField]
		public SerializedMapZones zoneRoundDefaultLarge;

		[SerializeField]
		public float giantTimeStart;

		[Tooltip("For maps with a size larger than 310 units")]
		[SerializeField]
		public SerializedMapZones zoneRoundDefaultGiant;

		[Header("Players Config")]
		[Tooltip("The intended player count, this should ideally be provided by the backend or on a map basis")]
		[SerializeField]
		public int targetPlayerCount;

		[Tooltip("The minimum intended player count to use for zone multipliers, ensures no less than this number of current players will be processed")]
		[SerializeField]
		public int minCurrentPlayerCount;

		[Header("Zone Config")]
		[SerializeField]
		[Tooltip("How much radius to add to the default zone, so it doesnt appear next to the edge of the map")]
		public float zoneMargin;

		[Tooltip("When the zone is fully closed, how much time to wait until the match ends")]
		[SerializeField]
		public float closedZoneWaitTime;

		[Header("Zone Stats")]
		[Tooltip("Flat damage value dealt by the zone. Will be multiplied by the battle royale gamemode damage setting")]
		[SerializeField]
		public int zoneOriginalDamage;

		[Tooltip("Percentage of the character's hp damage dealt by the zone. Will be multiplied by the battle royale gamemode damage setting")]
		[SerializeField]
		public float zoneOriginalDamageHpPercent;

		[Tooltip("Rate per second to apply damage to entered characters")]
		[SerializeField]
		public float zoneDamageRate;

		[SerializeField]
		[Tooltip("The zone damage multiplier to deal to bot characters, mapped to the normalized zone round progress")]
		public AnimationCurve zoneDamageToBotsMultiplier;

		[SerializeField]
		[Tooltip("Shows an augment selection at the start of a new battle royale zone round")]
		[Header("Augment Selection")]
		public bool augmentRoundPerZone;

		[SerializeField]
		[Tooltip("Shows an augment selection for every time this duration is reached")]
		public bool showAugmentSelectionByTime;

		[SerializeField]
		[Tooltip("The duration in seconds to initialize a new augment selection")]
		[ConditionalHide("showAugmentSelectionByTime", true)]
		[Min(0f)]
		public float augmentRoundDuration;

		[ConditionalHide("showAugmentSelectionByTime", true)]
		[Tooltip("If reached the max length of augment selections per round, stop initializing any more augments.")]
		[SerializeField]
		public bool augmentRoundsLimit;

		[Tooltip("Adds a new selection for a player when joining the game.")]
		[SerializeField]
		public bool addSelectionOnPlayerStart;

		[ConditionalHide("addSelectionOnPlayerStart", true)]
		[SerializeField]
		public AugmentManager.SelectionData.SelectionType onStartSelectionType;

		[NamedArray(typeof(Rarity), 0)]
		[SerializeField]
		public float[] onStartSelectionTierChances;

		[Header("Event Drop Configs")]
		[SerializeField]
		public float proximityEventPingDistance;

		[SerializeField]
		[Header("Prefabs")]
		public GameObject zonePrefab;

		[Header("Translation Keys")]
		[SerializeField]
		public string msgZoneClosingStrTranslationKey;

		[SerializeField]
		public string msgZoneMovesInXSecondsStrTranslationKey;

		[SerializeField]
		public string msgSupplyDropStrTranslationKey;

		[NonSerialized]
		public int mapSize;

		[NonSerialized]
		public int totalPlayerCount;

		[NonSerialized]
		public MatchState matchZoneState;

		[NonSerialized]
		public float zoneDurationMultiplier;

		[NonSerialized]
		public BattleRoyaleZone zone;

		[NonSerialized]
		public SerializedZoneRound[] zoneRounds;

		[NonSerialized]
		public ZoneData currentZone;

		[NonSerialized]
		public float startZoneRadius;

		[NonSerialized]
		public float augmentSelTimer;

		[NonSerialized]
		public List<EventDropChance> eventDropSpawnTimes;

		[NonSerialized]
		public int currentEventsToDrop;

		[NonSerialized]
		public int currentEventsToDropCount;

		[NonSerialized]
		public Vector3 currentEventDropChanceRotation;

		[NonSerialized]
		public float proximityEventPingDistanceSqr;

		[NonSerialized]
		public List<Vector3> fixedEventSpawnPositions;

		[NonSerialized]
		[NonSerialized]
		public List<Vector3> currentEventPositions;

		[NonSerialized]
		public Z_Obj currentEventObjective;

		[NonSerialized]
		public Z_Obj_SpawnEntity spawnNpcsObj;

		[NonSerialized]
		public IEnumerator updateTimerUICoroutine;

		[NonSerialized]
		public WaitForSecondsRealtime waitOneSecond;

		[NonSerialized]
		public string msgZoneClosingStr;

		[NonSerialized]
		public string msgZoneMovesInXSecondsStr;

		[NonSerialized]
		public string msgSupplyDropStr;

		[SyncVar]
		[NonSerialized]
		public int zoneRoundsCount;

		[SyncVar(hook = "OnPlayerCountChanged")]
		[NonSerialized]
		public int playerCount;

		[SyncVar(hook = "OnRoundChanged")]
		[NonSerialized]
		public int currentZoneRoundId;

		[SyncVar(hook = "OnMovingZoneChanged")]
		[NonSerialized]
		public bool closingZone;

		[NonSerialized]
		public bool debugDisableTime;

		public Action<int, int> _Mirror_SyncVarHookDelegate_playerCount;

		public Action<int, int> _Mirror_SyncVarHookDelegate_currentZoneRoundId;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_closingZone;

		public int NetworkzoneRoundsCount
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

		public int NetworkplayerCount
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

		public int NetworkcurrentZoneRoundId
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

		public bool NetworkclosingZone
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

		public override void Awake()
		{
		}

		public void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public override void FixedUpdate()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateTimerUI_003Ed__65))]
		public IEnumerator UpdateTimerUI()
		{
			return null;
		}

		public void InitializePlayer(PlayerManager player)
		{
		}

		public void StartZoneRound(int zoneRoundId)
		{
		}

		[Server]
		public void StartCloseZone()
		{
		}

		public void InitializeZoneData(int zoneRoundId)
		{
		}

		public Vector2 ChooseNextCirclePos(float currentRadius, float targetRadius, Vector2 currentPosition)
		{
			return default(Vector2);
		}

		public void InitializeRoundEvents()
		{
		}

		public void CreateNewEvent(EventDropChance e)
		{
		}

		[IteratorStateMachine(typeof(_003CSpecialEvent_003Ed__73))]
		public IEnumerator SpecialEvent(Vector3 dropPosition, GameObject entityPrefab)
		{
			return null;
		}

		public override void OnMatchBegin()
		{
		}

		public override void OnMatchStarted()
		{
		}

		public override void OnTimerEnd()
		{
		}

		public override void OnPlayerAdded(PlayerManager addedPlayer, int teamId = -1)
		{
		}

		public override void OnPlayerCharSpawned(EntityManager entityManager)
		{
		}

		public override void OnPlayerCharRespawned(EntityManager respawnedCharManager)
		{
		}

		public override void OnPlayerKilled(PlayerManager killerPlayer, int killerPlayerId, PlayerManager killedPlayer, int killedPlayerId)
		{
		}

		public void OnTeamWinMatch(int teamId, PlayerManager killedPlayer, PlayerManager killerPlayer)
		{
		}

		public void OnTeamLostMatch(int placementPosition, PlayerManager killedPlayer)
		{
		}

		public override void SpawnNetworkedObjects()
		{
		}

		public override void DestroyNetworkedObjects()
		{
		}

		public void SpawnBRZone()
		{
		}

		public void SpawnEventObject(GameObject entityPrefab, Vector3 worldPos)
		{
		}

		public void OnEventObjectSpawned(uint eventNetId, int entityPrefabId, Vector2 worldPos)
		{
		}

		public void UpdateCharacterZoneState(EntityManager entityManager)
		{
		}

		public Vector3 GetRandomPositionInCurrentZone(float radiusFromObstacles = 1.5f)
		{
			return default(Vector3);
		}

		public int GetRoundCount()
		{
			return 0;
		}

		public int GetCurrentRoundId()
		{
			return 0;
		}

		public float GetNormRoundProgress()
		{
			return 0f;
		}

		public float GetZoneBotDamageMultiplier()
		{
			return 0f;
		}

		[ClientRpc]
		public virtual void RpcSendGameModeEventZoneClosing()
		{
		}

		[ClientRpc]
		public virtual void RpcSendGameModeEventZoneClosingInSeconds(int seconds)
		{
		}

		[ClientRpc]
		public void RpcEventSupplyDropSpawned(uint eventNetId, Vector2 worldPos)
		{
		}

		[ClientRpc]
		public void RpcEventSpawned(uint eventNetId, int entityPrefabId, Vector2 worldPos)
		{
		}

		[ClientRpc]
		public void RpcOnZoneStartClosing()
		{
		}

		[TargetRpc]
		public void TargetRpcUpdatePlayerKillsUI(NetworkConnection conn, int kills)
		{
		}

		[TargetRpc]
		public void TargetOnTeamLoseMatch(NetworkConnection conn, int placementPosition)
		{
		}

		public void OnPlayerCountChanged(int oldValue, int newValue)
		{
		}

		public void OnRoundChanged(int oldValue, int newValue)
		{
		}

		public void OnMovingZoneChanged(bool oldValue, bool newValue)
		{
		}

		public void SetDisableTime(bool value)
		{
		}

		public void AdvanceMatch()
		{
		}

		public void RestartMatch()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public virtual void UserCode_RpcSendGameModeEventZoneClosing()
		{
		}

		public static void InvokeUserCode_RpcSendGameModeEventZoneClosing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public virtual void UserCode_RpcSendGameModeEventZoneClosingInSeconds__Int32(int seconds)
		{
		}

		public static void InvokeUserCode_RpcSendGameModeEventZoneClosingInSeconds__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcEventSupplyDropSpawned__UInt32__Vector2(uint eventNetId, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_RpcEventSupplyDropSpawned__UInt32__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcEventSpawned__UInt32__Int32__Vector2(uint eventNetId, int entityPrefabId, Vector2 worldPos)
		{
		}

		public static void InvokeUserCode_RpcEventSpawned__UInt32__Int32__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnZoneStartClosing()
		{
		}

		public static void InvokeUserCode_RpcOnZoneStartClosing(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcUpdatePlayerKillsUI__NetworkConnection__Int32(NetworkConnection conn, int kills)
		{
		}

		public static void InvokeUserCode_TargetRpcUpdatePlayerKillsUI__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeamLoseMatch__NetworkConnection__Int32(NetworkConnection conn, int placementPosition)
		{
		}

		public static void InvokeUserCode_TargetOnTeamLoseMatch__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static GameModeBattleRoyale()
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

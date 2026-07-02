using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Content;
using BAPBAP.Entities;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Player;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Game
{
	public class GameModeFFA : GameMode
	{
		public class PlayerEntry
		{
			public ScoreEntry scoreEntry;

			public CharItems.Inventory inventory;

			public PlayerEntry(ScoreEntry scoreEntry)
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CRemoveRecentSpawn_003Ed__64 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameModeFFA _003C_003E4__this;

			public int index;

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
			public _003CRemoveRecentSpawn_003Ed__64(int _003C_003E1__state)
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
		public sealed class _003CRespawnPlayerSubroutine_003Ed__62 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameModeFFA _003C_003E4__this;

			public int playerId;

			public PlayerManager player;

			[NonSerialized]
			public int _003CbotTeamId_003E5__2;

			[NonSerialized]
			public int _003CbotCharId_003E5__3;

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
			public _003CRespawnPlayerSubroutine_003Ed__62(int _003C_003E1__state)
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
		public sealed class _003CUpdateTimerUI_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameModeFFA _003C_003E4__this;

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
			public _003CUpdateTimerUI_003Ed__37(int _003C_003E1__state)
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

		[ExHeader("FFA Configs", 1f, 1f, 0f)]
		[Header("Score Configs")]
		[Tooltip("How much score does a player need to win the game")]
		[SerializeField]
		[Min(1f)]
		public int scoreToWin;

		[SerializeField]
		public int teamScoreToWin;

		[SerializeField]
		public int teamSizeScoreMultiplier;

		[Header("Configs")]
		[Tooltip("How much gold to add to any character once they spawn")]
		[Min(0f)]
		[SerializeField]
		public int goldOnSpawned;

		[Min(0f)]
		[SerializeField]
		[Tooltip("The starting lives for each player when the game begins")]
		public int startingLives;

		[Min(0f)]
		[SerializeField]
		[Tooltip("The maximum allowed lives per player")]
		public int maxLives;

		[Min(0f)]
		[SerializeField]
		[Tooltip("Give the player this juice amount when spawning")]
		public int juiceOnStart;

		[Header("Buy Configs")]
		[SerializeField]
		[Min(0f)]
		public int buyLivesGoldCost;

		[SerializeField]
		[Min(0f)]
		public int buyPassiveGoldCost;

		[SerializeField]
		public PassiveSO[] buyRandomPassives;

		[SerializeField]
		[Min(0f)]
		public int buyConsumableGoldCost;

		[SerializeField]
		public Consumable[] buyRandomConsumables;

		[Header("Augment Selection")]
		[Tooltip("The duration for each augment round to initialize a new augment selection")]
		[SerializeField]
		[Min(0f)]
		public float augmentRoundDuration;

		[SerializeField]
		[Tooltip("If reached the max length of augment selections per round, stop initializing any more augments.")]
		public bool augmentRoundsLimit;

		[SerializeField]
		[Tooltip("Adds a new selection for a player when joining the game.")]
		public bool addSelectionOnPlayerStart;

		[SerializeField]
		[ConditionalHide("addSelectionOnPlayerStart", true)]
		public AugmentManager.SelectionData.SelectionType onStartSelectionType;

		[SerializeField]
		[NamedArray(typeof(Rarity), 0)]
		public float[] onStartSelectionTierChances;

		[Tooltip("Adds a new selection for a player when is killed by another player.")]
		[SerializeField]
		public bool addSelectionOnKilledByPlayer;

		[ConditionalHide("addSelectionOnKilledByPlayer", true)]
		[SerializeField]
		public AugmentManager.SelectionData.SelectionType onKilledSelectionType;

		[NamedArray(typeof(Rarity), 0)]
		[SerializeField]
		public float[] onKilledSelectionTierChances;

		[Min(0f)]
		[Tooltip("The duration for the player respawn sequence (Note that some aspects of this are hardcoded)")]
		[SerializeField]
		[Header("Respawn Configs")]
		public float respawnTime;

		[Tooltip("Add this time to the respawn duration, multiplied by the players missing lives from the starting lives. i.e: if player is at live 1 from 3 starting lives, this time will be multipled by 2 and added to the base respawn duration.")]
		[SerializeField]
		[Min(0f)]
		public float respawnTimePerMissingLive;

		[SerializeField]
		[Min(0f)]
		public float invulnerableDuration;

		[SerializeField]
		[Min(0f)]
		public float spawnCheckRadius;

		[NonSerialized]
		public List<int> recentSpawns;

		[NonSerialized]
		public Dictionary<int, PlayerEntry> playerEntries;

		[NonSerialized]
		public IEnumerator updateTimerUICoroutine;

		[NonSerialized]
		public WaitForSecondsRealtime waitOneSecond;

		[NonSerialized]
		public float augmentRoundTimer;

		[NonSerialized]
		public int maxScore;

		public override void OnValidate()
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

		[IteratorStateMachine(typeof(_003CUpdateTimerUI_003Ed__37))]
		public IEnumerator UpdateTimerUI()
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

		public override void OnPlayerKilled(PlayerManager killerPlayer, int killerPlayerId, PlayerManager killedPlayer, int killedPlayerId)
		{
		}

		public override void OnPlayerCharSpawned(EntityManager entityManager)
		{
		}

		public override void OnPlayerCharRespawned(EntityManager entityManager)
		{
		}

		public void EndGame()
		{
		}

		public void OnTeamWinMatch(int teamId, PlayerManager killedPlayer, PlayerManager killerPlayer)
		{
		}

		public void OnTeamLostMatch(int placementPosition, PlayerManager killedPlayer)
		{
		}

		public void TryEndGameLives()
		{
		}

		public void InitializePlayer(PlayerManager player)
		{
		}

		public void SyncScoreOnAllPlayers(ScoreEntry entry)
		{
		}

		public void SyncAllScoresOnPlayer(PlayerManager player)
		{
		}

		public void SortPlayerScorePositions()
		{
		}

		public int GetRemainingActivePlayers()
		{
			return 0;
		}

		public void GetItemOnPlayer(PlayerManager player, int itemId, int amount = 1)
		{
		}

		public void ModifyGoldOnPlayer(PlayerManager player, int goldDelta)
		{
		}

		public int GetPlayerGold(PlayerManager player)
		{
			return 0;
		}

		public void BuyLivesOnPlayer(PlayerManager player)
		{
		}

		public void BuyPassiveOnPlayer(PlayerManager player)
		{
		}

		public void BuyConsumableOnPlayer(PlayerManager player)
		{
		}

		public void SvOnKillMsgEvent(PlayerEntry killerEntry)
		{
		}

		public float GetAdjustRespawnTime(int playerId)
		{
			return 0f;
		}

		[IteratorStateMachine(typeof(_003CRespawnPlayerSubroutine_003Ed__62))]
		public IEnumerator RespawnPlayerSubroutine(PlayerManager player, int playerId)
		{
			return null;
		}

		public Vector3 SelectRespawnPoint()
		{
			return default(Vector3);
		}

		[IteratorStateMachine(typeof(_003CRemoveRecentSpawn_003Ed__64))]
		public IEnumerator RemoveRecentSpawn(int index)
		{
			return null;
		}

		[ClientRpc]
		public void RpcWinAnnouncment(string winnerPlayerName)
		{
		}

		[TargetRpc]
		public void TargetOnTeamLoseMatch(NetworkConnection conn, int placementPosition)
		{
		}

		public void ClOnTeamLoseMatch(int placementPosition)
		{
		}

		[TargetRpc]
		public void TargetOnPlayerRespawn(NetworkConnection conn, float respawnTimer)
		{
		}

		[ClientRpc]
		public void RpcScoreAnnouncment(string playerName, int killsRemaining)
		{
		}

		[ClientRpc]
		public void RpcSendScore(int playerId, string name, int score, int lives)
		{
		}

		[TargetRpc]
		public void TargetRpcSendScore(NetworkConnection conn, int playerId, string name, int score, int lives)
		{
		}

		public void ClUpdateScore(int playerId, string name, int score, int lives)
		{
		}

		[TargetRpc]
		public void TargetShowLiveCounter(NetworkConnection conn, int lives)
		{
		}

		[TargetRpc]
		public void TargetGetLive(NetworkConnection conn, Vector3 pos, int lives)
		{
		}

		[TargetRpc]
		public void TargetRpcSetItemUIAdded(NetworkConnection conn, int itemId, int amount, byte slotId)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcWinAnnouncment__String(string winnerPlayerName)
		{
		}

		public static void InvokeUserCode_RpcWinAnnouncment__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnTeamLoseMatch__NetworkConnection__Int32(NetworkConnection conn, int placementPosition)
		{
		}

		public static void InvokeUserCode_TargetOnTeamLoseMatch__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetOnPlayerRespawn__NetworkConnection__Single(NetworkConnection conn, float respawnTimer)
		{
		}

		public static void InvokeUserCode_TargetOnPlayerRespawn__NetworkConnection__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcScoreAnnouncment__String__Int32(string playerName, int killsRemaining)
		{
		}

		public static void InvokeUserCode_RpcScoreAnnouncment__String__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendScore__Int32__String__Int32__Int32(int playerId, string name, int score, int lives)
		{
		}

		public static void InvokeUserCode_RpcSendScore__Int32__String__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcSendScore__NetworkConnection__Int32__String__Int32__Int32(NetworkConnection conn, int playerId, string name, int score, int lives)
		{
		}

		public static void InvokeUserCode_TargetRpcSendScore__NetworkConnection__Int32__String__Int32__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetShowLiveCounter__NetworkConnection__Int32(NetworkConnection conn, int lives)
		{
		}

		public static void InvokeUserCode_TargetShowLiveCounter__NetworkConnection__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetGetLive__NetworkConnection__Vector3__Int32(NetworkConnection conn, Vector3 pos, int lives)
		{
		}

		public static void InvokeUserCode_TargetGetLive__NetworkConnection__Vector3__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_TargetRpcSetItemUIAdded__NetworkConnection__Int32__Int32__Byte(NetworkConnection conn, int itemId, int amount, byte slotId)
		{
		}

		public static void InvokeUserCode_TargetRpcSetItemUIAdded__NetworkConnection__Int32__Int32__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static GameModeFFA()
		{
		}
	}
}

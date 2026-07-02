using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Entities;
using BAPBAP.Game.Dimensions;
using BAPBAP.Player;
using UnityEngine;

namespace BAPBAP.Game
{
	public class GameModeTraining : GameMode
	{
		[CompilerGenerated]
		public sealed class _003CNPCRespawn_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameModeTraining _003C_003E4__this;

			public GameObject npcPrefabToSpawn;

			public Vector3 respawnPosition;

			public Quaternion respawnRotation;

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
			public _003CNPCRespawn_003Ed__16(int _003C_003E1__state)
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
		public sealed class _003CWaitToMoveCharToLastPos_003Ed__17 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameModeTraining _003C_003E4__this;

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
			public _003CWaitToMoveCharToLastPos_003Ed__17(int _003C_003E1__state)
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
		public sealed class _003CWaitToRespawn_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float seconds;

			public GameModeTraining _003C_003E4__this;

			public PlayerManager playerManager;

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
			public _003CWaitToRespawn_003Ed__14(int _003C_003E1__state)
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
		public sealed class _003CWaitToRespawnBot_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float seconds;

			public GameModeTraining _003C_003E4__this;

			public int playerId;

			public int teamId;

			public Vector3 spawnPos;

			public int charId;

			public BotDifficulty difficulty;

			public bool enableAI;

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
			public _003CWaitToRespawnBot_003Ed__15(int _003C_003E1__state)
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

		[Header("Configs")]
		[SerializeField]
		[Tooltip("Should this gamemode allow for players to respawn after they are killed?")]
		public bool doPlayerRespawn;

		[SerializeField]
		[Tooltip("If this gamemode allows for players to respawn when killed, how much to wait until respawned?")]
		[ConditionalHide("doPlayerRespawn", true)]
		public float playerRespawnTime;

		[Tooltip("Should this gamemode allow for npcs to respawn after they are killed?")]
		[SerializeField]
		public bool doNpcRespawn;

		[SerializeField]
		[ConditionalHide("doNpcRespawn", true)]
		[Tooltip("If this gamemode allows for npcs to respawn when killed, how much to wait until respawned?")]
		public float npcRespawnTime;

		[SerializeField]
		public GameObject[] nonRespawnableEntityPrefabs;

		[SerializeField]
		public Dimension.DimensionType spawnDimensionType;

		[NonSerialized]
		public Vector3 lastWorldPos;

		[NonSerialized]
		public string lastMap;

		public override void OnEnable()
		{
		}

		public override void OnDisable()
		{
		}

		public override void FixedUpdate()
		{
		}

		public override void OnPlayerKilled(PlayerManager killerPlayer, int killerPlayerId, PlayerManager killedPlayer, int killedPlayerId)
		{
		}

		public override void OnPlayerRemoved(PlayerManager removedPlayer)
		{
		}

		public override void OnNPCDestroyed(EntityManager npcEntity)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToRespawn_003Ed__14))]
		public IEnumerator WaitToRespawn(PlayerManager playerManager, float seconds)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitToRespawnBot_003Ed__15))]
		public IEnumerator WaitToRespawnBot(int playerId, int teamId, Vector3 spawnPos, int charId, BotDifficulty difficulty, bool enableAI, float seconds)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CNPCRespawn_003Ed__16))]
		public IEnumerator NPCRespawn(GameObject npcPrefabToSpawn, Vector3 respawnPosition, Quaternion respawnRotation)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitToMoveCharToLastPos_003Ed__17))]
		public IEnumerator WaitToMoveCharToLastPos()
		{
			return null;
		}

		public void ExitTraining()
		{
		}

		public void SetCharCooldownEnabled(bool isEnabled)
		{
		}

		public void SetCharInvincibilityEnabled(bool isEnabled)
		{
		}

		public void SetCharAggroMode(bool isEnabled)
		{
		}

		public void CharDealDamage(int amount = 200)
		{
		}

		public void CharApplyHeal()
		{
		}

		public void SpawnItem(int itemId, int amount = 1)
		{
		}

		public void SwitchCharacter(int charToSwitchId)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

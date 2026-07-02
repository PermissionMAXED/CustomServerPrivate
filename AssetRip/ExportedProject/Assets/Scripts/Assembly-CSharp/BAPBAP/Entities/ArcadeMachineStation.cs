using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Localisation;
using BAPBAP.Minigames;
using BAPBAP.Player;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ArcadeMachineStation : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CGameOverCoroutine_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public ArcadeMachineStation _003C_003E4__this;

			public int score;

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
			public _003CGameOverCoroutine_003Ed__45(int _003C_003E1__state)
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
		public sealed class _003CWaitResetAuthCoroutine_003Ed__46 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public ArcadeMachineStation _003C_003E4__this;

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
			public _003CWaitResetAuthCoroutine_003Ed__46(int _003C_003E1__state)
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

		[Header("References")]
		[SerializeField]
		public Transform itemSpawnTr;

		[SerializeField]
		public GameObject clPlayingObj;

		[SerializeField]
		[Header("Prefabs")]
		public GameObject uiMinigameHolderPrefab;

		[SerializeField]
		public MinigameController minigamePrefab;

		[SerializeField]
		[Header("Config")]
		[Min(0f)]
		public float cooldownDuration;

		[Min(0f)]
		[SerializeField]
		public float gameOverWaitTime;

		[Tooltip("Enable the minigame to drop gold at a rate during the minigame playtime")]
		[Header("Gold Drop Config")]
		[SerializeField]
		public bool doDropRate;

		[SerializeField]
		[Min(0f)]
		[Tooltip("The base gold amount to drop per second")]
		[ConditionalHide("doDropRate", true)]
		public int baseRateGoldDropAmount;

		[Tooltip("The rate at which to drop gold per second")]
		[SerializeField]
		[Min(0.1f)]
		[ConditionalHide("doDropRate", true)]
		public float goldDropRate;

		[SerializeField]
		[Tooltip("Multiply the base gold amount for every drop")]
		[ConditionalHide("doDropRate", true)]
		[Min(0f)]
		public float goldAmountAdditiveMultiplier;

		[Tooltip("How much gold is worth per score")]
		[SerializeField]
		[Min(0f)]
		public float goldPerScore;

		[Header("Translation Keys")]
		[SerializeField]
		public string playTranslationKey;

		[SerializeField]
		public string inCooldownTranslationKey;

		[SerializeField]
		public string stopTranslationKey;

		[NonSerialized]
		public GameObject currentHolderInstance;

		[NonSerialized]
		public MinigameController currentMinigameInstance;

		[NonSerialized]
		public float currentGoldMult;

		[NonSerialized]
		public float dropRateTimer;

		[NonSerialized]
		public float cooldownTimer;

		[NonSerialized]
		public bool inUse;

		[NonSerialized]
		public Coroutine gameEndWaitCoroutine;

		[NonSerialized]
		public Coroutine waitResetAuthCoroutine;

		[NonSerialized]
		public bool _isClient;

		[NonSerialized]
		public string playStr;

		[NonSerialized]
		public string inCooldownStr;

		[NonSerialized]
		public string stopStr;

		[SyncVar(hook = "OnCurrentPlayerChanged")]
		[NonSerialized]
		public PlayerManager currentPlayer;

		[SyncVar(hook = "OnCooldownTimerSyncChanged")]
		[NonSerialized]
		public ushort cooldownTimerSync;

		[NonSerialized]
		public NetworkBehaviourSyncVar ___currentPlayerNetId;

		public Action<PlayerManager, PlayerManager> _Mirror_SyncVarHookDelegate_currentPlayer;

		public Action<ushort, ushort> _Mirror_SyncVarHookDelegate_cooldownTimerSync;

		public PlayerManager NetworkcurrentPlayer
		{
			get
			{
				return null;
			}
			[param: In]
			set
			{
			}
		}

		public ushort NetworkcooldownTimerSync
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

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public override void OnDestroy()
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public void UIShowCooldownWindow()
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public void StartPlayer(EntityManager playerChar)
		{
		}

		public void StopPlayer()
		{
		}

		public void EndMinigame()
		{
		}

		public void DropGold(int amount)
		{
		}

		public void SvOnMinigameEnded(int score)
		{
		}

		[IteratorStateMachine(typeof(_003CGameOverCoroutine_003Ed__45))]
		public IEnumerator GameOverCoroutine(int score)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CWaitResetAuthCoroutine_003Ed__46))]
		public IEnumerator WaitResetAuthCoroutine()
		{
			return null;
		}

		[TargetRpc]
		public void TargetForceClientExit(NetworkConnection conn, EntityManager entity)
		{
		}

		public void ClApplyAuth(PlayerManager player)
		{
		}

		public void ClRemoveAuth(PlayerManager player)
		{
		}

		public void ClOnMinigameEnded(int score)
		{
		}

		[Command]
		public void CmdOnMinigameEnded(ArcadeMachineStation arcadeMachine, int score)
		{
		}

		public void OnCooldownTimerSyncChanged(ushort oldValue, ushort newValue)
		{
		}

		public void OnCurrentPlayerChanged(PlayerManager oldValue, PlayerManager newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_TargetForceClientExit__NetworkConnection__EntityManager(NetworkConnection conn, EntityManager entity)
		{
		}

		public static void InvokeUserCode_TargetForceClientExit__NetworkConnection__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_CmdOnMinigameEnded__ArcadeMachineStation__Int32(ArcadeMachineStation arcadeMachine, int score)
		{
		}

		public static void InvokeUserCode_CmdOnMinigameEnded__ArcadeMachineStation__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ArcadeMachineStation()
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

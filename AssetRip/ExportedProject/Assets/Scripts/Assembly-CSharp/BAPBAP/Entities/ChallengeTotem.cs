using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Game;
using BAPBAP.Items;
using BAPBAP.Localisation;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ChallengeTotem : InteractableStation
	{
		[Serializable]
		public class Round
		{
			public PrefabConfig[] enemyEntities;
		}

		[CompilerGenerated]
		public sealed class _003CStartWaitCompleteChallenge_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public ChallengeTotem _003C_003E4__this;

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
			public _003CStartWaitCompleteChallenge_003Ed__31(int _003C_003E1__state)
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
		public sealed class _003CStartWaitStartRound_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public ChallengeTotem _003C_003E4__this;

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
			public _003CStartWaitStartRound_003Ed__34(int _003C_003E1__state)
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
		public ItemDrops rewardDrop;

		[SerializeField]
		[Header("References")]
		public GameObject inProgressFxObj;

		[SerializeField]
		public GameObject roundStartFxObj;

		[SerializeField]
		public GameObject challengeCompleteFxObj;

		[Header("Properties")]
		[SerializeField]
		public Round[] challengeRounds;

		[SerializeField]
		public float spawnRadius;

		[Min(0f)]
		[SerializeField]
		public float roundStartDelay;

		[Min(0f)]
		[SerializeField]
		public float completeChallengeDelay;

		[SerializeField]
		[Header("Translation Keys")]
		public string startChallengeTrKey;

		[SerializeField]
		public string startingStrTrKey;

		[SerializeField]
		public string challengeInProgressTrKey;

		[SerializeField]
		public string challengeCompletedTrKey;

		[SyncVar(hook = "OnChallengeInProgressChanged")]
		[NonSerialized]
		public bool challengeInProgress;

		[NonSerialized]
		public bool challengeCompleted;

		[NonSerialized]
		public int currentRound;

		[NonSerialized]
		public int enemyKillCount;

		[NonSerialized]
		public string startChallengeStr;

		[NonSerialized]
		public string startingStr;

		[NonSerialized]
		public string challengeInProgressStr;

		[NonSerialized]
		public string challengeCompletedStr;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_challengeInProgress;

		public bool NetworkchallengeInProgress
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

		public override void Start()
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void UIShowStartChallengeWindow(InteractableCollider slot)
		{
		}

		public void UIShowChallengeInProgressWindow(InteractableCollider slot)
		{
		}

		public void UIShowChallengeCompletedWindow(InteractableCollider slot)
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

		public void StartChallenge()
		{
		}

		[IteratorStateMachine(typeof(_003CStartWaitCompleteChallenge_003Ed__31))]
		public IEnumerator StartWaitCompleteChallenge()
		{
			return null;
		}

		public void CompleteChallenge()
		{
		}

		public void SpawnReward()
		{
		}

		[IteratorStateMachine(typeof(_003CStartWaitStartRound_003Ed__34))]
		public IEnumerator StartWaitStartRound()
		{
			return null;
		}

		public void StartRound()
		{
		}

		public void CompleteRound()
		{
		}

		[ServerCallback]
		public void OnEnemyKilled()
		{
		}

		[ClientRpc]
		public void RpcRoundStart()
		{
		}

		[ClientRpc]
		public void RpcChallengeCompleted()
		{
		}

		[ClientRpc]
		public void RpcUsed(EntityManager entity)
		{
		}

		[ClientRpc]
		public override void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		public void OnChallengeInProgressChanged(bool oldValue, bool newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcRoundStart()
		{
		}

		public static void InvokeUserCode_RpcRoundStart(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcChallengeCompleted()
		{
		}

		public static void InvokeUserCode_RpcChallengeCompleted(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcUsed__EntityManager(EntityManager entity)
		{
		}

		public static void InvokeUserCode_RpcUsed__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ChallengeTotem()
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

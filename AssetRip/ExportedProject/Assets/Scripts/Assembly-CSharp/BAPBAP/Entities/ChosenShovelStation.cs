using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Game;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ChosenShovelStation : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CBugFixCoroutine_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public ChosenShovelStation _003C_003E4__this;

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
			public _003CBugFixCoroutine_003Ed__31(int _003C_003E1__state)
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
		public sealed class _003CEnableAfterDelay_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GameObject g;

			public ChosenShovelStation _003C_003E4__this;

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
			public _003CEnableAfterDelay_003Ed__30(int _003C_003E1__state)
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

		[SerializeField]
		public Transform windowTransform;

		[Header("Properties")]
		[SerializeField]
		public float buffChance;

		[SerializeField]
		public PassiveSO buffPassive;

		[SerializeField]
		public PassiveSO costPassive;

		[SerializeField]
		public GameObject meshToHide;

		[SerializeField]
		public ParticleSystem successVfx;

		[SerializeField]
		public ParticleSystem costVfx;

		[NonSerialized]
		public AudioSource successAudioSource;

		[NonSerialized]
		public AudioSource costAudioSource;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[NonSerialized]
		public string completeStr;

		[NonSerialized]
		public string invalidStr;

		[SyncVar(hook = "OnCompletedChanged")]
		[NonSerialized]
		public bool completed;

		[NonSerialized]
		public readonly SyncList<int> interactedWithPlayers;

		[NonSerialized]
		public bool interactedWith;

		[NonSerialized]
		public bool bugFix;

		[NonSerialized]
		public GameManager gameManager;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_completed;

		public bool Networkcompleted
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

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void OnSlotEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
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

		public void OnCompletedChanged(bool oldValue, bool newValue)
		{
		}

		public void OnChosenPlayerIdChanged(int oldValue, int newValue)
		{
		}

		[IteratorStateMachine(typeof(_003CEnableAfterDelay_003Ed__30))]
		public IEnumerator EnableAfterDelay(GameObject g)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CBugFixCoroutine_003Ed__31))]
		public IEnumerator BugFixCoroutine()
		{
			return null;
		}

		[ClientRpc]
		public void RpcSuccessInteract()
		{
		}

		[ClientRpc]
		public void RpcFailCostInteract(EntityManager eM)
		{
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entityManager, int slotId)
		{
		}

		[ClientRpc]
		public void RpcEnable(GameObject g)
		{
		}

		[ClientRpc]
		public void RpcBugFix()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSuccessInteract()
		{
		}

		public static void InvokeUserCode_RpcSuccessInteract(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcFailCostInteract__EntityManager(EntityManager eM)
		{
		}

		public static void InvokeUserCode_RpcFailCostInteract__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entityManager, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcEnable__GameObject(GameObject g)
		{
		}

		public static void InvokeUserCode_RpcEnable__GameObject(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcBugFix()
		{
		}

		public static void InvokeUserCode_RpcBugFix(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ChosenShovelStation()
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

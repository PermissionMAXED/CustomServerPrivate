using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class WeaponRack : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CReStockRoutine_003Ed__29 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WeaponRack _003C_003E4__this;

			[NonSerialized]
			public float _003Ctime_003E5__2;

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
			public _003CReStockRoutine_003Ed__29(int _003C_003E1__state)
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
		[Header("References")]
		public Transform windowTransform;

		[SerializeField]
		public PassiveSO[] weapons;

		[SerializeField]
		public PassiveSO[] passivesToFail;

		[SerializeField]
		public GameObject[] gunObj;

		[SerializeField]
		public TextMesh restockTimerMesh;

		[SerializeField]
		public Animator gunAnimator;

		[SerializeField]
		public string buyStateName;

		[SerializeField]
		[Header("Properties")]
		[Min(0f)]
		public float reStockTime;

		[SerializeField]
		public ushort maxUses;

		[SerializeField]
		public int price;

		[SerializeField]
		[Header("Configs")]
		public string purchaseString;

		[SerializeField]
		public string purchaseForString;

		[NonSerialized]
		public bool restocking;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[NonSerialized]
		public int buyStateHash;

		[SyncVar(hook = "CurrentUsesChanged")]
		[NonSerialized]
		public ushort currentUses;

		[SyncVar(hook = "CurrentRestockTimerChanged")]
		[NonSerialized]
		public short syncRestockTimer;

		public Action<ushort, ushort> _Mirror_SyncVarHookDelegate_currentUses;

		public Action<short, short> _Mirror_SyncVarHookDelegate_syncRestockTimer;

		public ushort NetworkcurrentUses
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

		public short NetworksyncRestockTimer
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

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
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

		public void ApplyGun(EntityManager entity)
		{
		}

		public void StartRestock()
		{
		}

		[IteratorStateMachine(typeof(_003CReStockRoutine_003Ed__29))]
		public IEnumerator ReStockRoutine()
		{
			return null;
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		public void ClSetUses(int uses)
		{
		}

		public void CurrentUsesChanged(ushort oldValue, ushort newValue)
		{
		}

		public void CurrentRestockTimerChanged(short oldValue, short newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static WeaponRack()
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

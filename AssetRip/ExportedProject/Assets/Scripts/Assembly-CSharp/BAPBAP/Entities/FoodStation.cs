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
	public class FoodStation : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CReStockRoutine_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public FoodStation _003C_003E4__this;

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
			public _003CReStockRoutine_003Ed__25(int _003C_003E1__state)
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
		public Transform windowTransform;

		[SerializeField]
		public GameObject[] foodProgressItems;

		[Header("Properties")]
		[SerializeField]
		public bool doReStock;

		[ConditionalHide("doReStock", true)]
		[SerializeField]
		[Min(0f)]
		public float reStockTime;

		[SerializeField]
		public byte maxUses;

		[SerializeField]
		[Header("Food Effect Properties")]
		public int healAmount;

		[SerializeField]
		[Range(0f, 1f)]
		public float healPercent;

		[SerializeField]
		public int shieldAmount;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("Configs")]
		[SerializeField]
		public string purchaseString;

		[SerializeField]
		public string purchaseForString;

		[NonSerialized]
		public bool restocking;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[SyncVar(hook = "CurrentUsesChanged")]
		[NonSerialized]
		public byte currentUses;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_currentUses;

		public byte NetworkcurrentUses
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

		public void ApplyFoodEffect(EntityManager entity)
		{
		}

		public void StartRestock()
		{
		}

		[IteratorStateMachine(typeof(_003CReStockRoutine_003Ed__25))]
		public IEnumerator ReStockRoutine()
		{
			return null;
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		public void ClSetFoodUses(int uses)
		{
		}

		public void CurrentUsesChanged(byte oldValue, byte newValue)
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

		static FoodStation()
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

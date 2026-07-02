using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Items;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SlotMachine : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CDeliveryRoutine_003Ed__41 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public SlotMachine _003C_003E4__this;

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
			public _003CDeliveryRoutine_003Ed__41(int _003C_003E1__state)
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
		public sealed class _003CReStockRoutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public SlotMachine _003C_003E4__this;

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
			public _003CReStockRoutine_003Ed__43(int _003C_003E1__state)
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
		public sealed class _003CRecoverRoutine_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public SlotMachine _003C_003E4__this;

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
			public _003CRecoverRoutine_003Ed__42(int _003C_003E1__state)
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
		public sealed class _003CUpdateRestockTimer_003Ed__44 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public SlotMachine _003C_003E4__this;

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
			public _003CUpdateRestockTimer_003Ed__44(int _003C_003E1__state)
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
		[Header("Properties")]
		public int startingPrice;

		[SerializeField]
		public float priceMultiplicationPerRoll;

		[SerializeField]
		public int priceCap;

		[SerializeField]
		public LootDropEntry.GearDrop itemDropIncreasePerRoll;

		[SerializeField]
		public float deliveryTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		[Min(0f)]
		public ushort reStockTime;

		[SerializeField]
		public bool canRestock;

		[SerializeField]
		public bool showInStock;

		[SerializeField]
		public byte minLoot;

		[SerializeField]
		public string LocalisationString;

		[SerializeField]
		[Header("References")]
		public GameObject activeObj;

		[SerializeField]
		public ItemDrops randomDrops;

		[SerializeField]
		public TextMesh restockTimerMesh;

		[SerializeField]
		public Transform windowTransform;

		[NonSerialized]
		public bool restocking;

		[SyncVar(hook = "PriceOfBuffChanged")]
		[NonSerialized]
		public int price;

		[SyncVar(hook = "CurrentTryChanged")]
		[NonSerialized]
		public byte currentTry;

		[SyncVar(hook = "LootGivenChanged")]
		[NonSerialized]
		public byte lootGiven;

		[SerializeField]
		[SyncVar(hook = "MaxLootChanged")]
		public byte maxLoot;

		[SyncVar(hook = "RecoveringChanged")]
		[NonSerialized]
		public bool recovering;

		[SyncVar(hook = "CurrentRestockTimerChanged")]
		[NonSerialized]
		public ushort currentRestockTimer;

		[NonSerialized]
		public string purchaseStr;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[NonSerialized]
		public string completeStr;

		[NonSerialized]
		public string flavorStr;

		[NonSerialized]
		public string inStockStr;

		[NonSerialized]
		public string costStr;

		[NonSerialized]
		public string goldStr;

		[NonSerialized]
		public string needStr;

		public Action<int, int> _Mirror_SyncVarHookDelegate_price;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_currentTry;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_lootGiven;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_maxLoot;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_recovering;

		public Action<ushort, ushort> _Mirror_SyncVarHookDelegate_currentRestockTimer;

		public int Networkprice
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

		public byte NetworkcurrentTry
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

		public byte NetworklootGiven
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

		public byte NetworkmaxLoot
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

		public bool Networkrecovering
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

		public ushort NetworkcurrentRestockTimer
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

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override void ClOnForceUpdate(EntityManager entity, InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entityManager, int slotId)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CDeliveryRoutine_003Ed__41))]
		public IEnumerator DeliveryRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CRecoverRoutine_003Ed__42))]
		public IEnumerator RecoverRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CReStockRoutine_003Ed__43))]
		public IEnumerator ReStockRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CUpdateRestockTimer_003Ed__44))]
		public IEnumerator UpdateRestockTimer()
		{
			return null;
		}

		[ClientRpc]
		public void RpcRefreshCooldownUI(ushort i)
		{
		}

		[ClientRpc]
		public void RpcRecover(bool recov)
		{
		}

		[ClientRpc]
		public void RpcReStocking(bool restock)
		{
		}

		public void CurrentRestockTimerChanged(ushort oldValue, ushort newValue)
		{
		}

		public void RecoveringChanged(bool oldValue, bool newValue)
		{
		}

		public void LootGivenChanged(byte oldValue, byte newValue)
		{
		}

		public void MaxLootChanged(byte oldValue, byte newValue)
		{
		}

		public void PriceOfBuffChanged(int oldValue, int newValue)
		{
		}

		public void CurrentTryChanged(byte oldValue, byte newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcRefreshCooldownUI__UInt16(ushort i)
		{
		}

		public static void InvokeUserCode_RpcRefreshCooldownUI__UInt16(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcRecover__Boolean(bool recov)
		{
		}

		public static void InvokeUserCode_RpcRecover__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcReStocking__Boolean(bool restock)
		{
		}

		public static void InvokeUserCode_RpcReStocking__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SlotMachine()
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

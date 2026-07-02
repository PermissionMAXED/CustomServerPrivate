using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TreeOfLife : InteractableStation
	{
		[CompilerGenerated]
		public sealed class _003CCooldownRoutine_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public TreeOfLife _003C_003E4__this;

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
			public _003CCooldownRoutine_003Ed__37(int _003C_003E1__state)
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
		public sealed class _003CUpdateRestockTimer_003Ed__38 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public TreeOfLife _003C_003E4__this;

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
			public _003CUpdateRestockTimer_003Ed__38(int _003C_003E1__state)
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
		public ItemManager itemManager;

		[Header("Properties")]
		[SerializeField]
		public int healthPotMultiplier;

		[SerializeField]
		public int goldPrice;

		[SerializeField]
		public bool hasCooldown;

		[SerializeField]
		public bool resetInputType;

		[Min(0f)]
		[SerializeField]
		public ushort cooldownTime;

		[SerializeField]
		public TextMesh restockTimerMesh;

		[SerializeField]
		public Sprite helmIcon;

		[SerializeField]
		public Sprite bagIcon;

		[SerializeField]
		public Sprite bootsIcons;

		[SerializeField]
		public List<Item> itemRewards;

		[SerializeField]
		[Header("Translation Keys")]
		public string payingKey;

		[SerializeField]
		public string offerKey;

		[SerializeField]
		public string completeKey;

		[SerializeField]
		public string tributeKey;

		[SerializeField]
		public string needsKey;

		[NonSerialized]
		public bool onCooldown;

		[SyncVar(hook = "CurrentTributeCountChanged")]
		[NonSerialized]
		public byte currentTributeCount;

		[SyncVar(hook = "ActivatedChanged")]
		[NonSerialized]
		public bool activated;

		[SyncVar(hook = "InputTypeChanged")]
		[NonSerialized]
		public byte inputType;

		[SyncVar(hook = "ItemTypeAndRarityChanged")]
		[NonSerialized]
		public byte itemTypeAndRarity;

		[SyncVar(hook = "CurrentCooldownTimerChanged")]
		[NonSerialized]
		public ushort currentCooldownTimer;

		[SerializeField]
		[SyncVar(hook = "PriceOfBuffPerTeamMemberChanged")]
		public int priceOfBuffPerTeamMember;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		[NonSerialized]
		public string completeStr;

		[NonSerialized]
		public string tributeStr;

		[NonSerialized]
		public string needStr;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_currentTributeCount;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_activated;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_inputType;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_itemTypeAndRarity;

		public Action<ushort, ushort> _Mirror_SyncVarHookDelegate_currentCooldownTimer;

		public Action<int, int> _Mirror_SyncVarHookDelegate_priceOfBuffPerTeamMember;

		public byte NetworkcurrentTributeCount
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

		public bool Networkactivated
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

		public byte NetworkinputType
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

		public byte NetworkitemTypeAndRarity
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

		public ushort NetworkcurrentCooldownTimer
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

		public int NetworkpriceOfBuffPerTeamMember
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

		public void RollInputType()
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void UIShowFinishedWindow(InteractableCollider slot)
		{
		}

		public override void UIShowValidWindow(InteractableCollider slot)
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
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

		[IteratorStateMachine(typeof(_003CCooldownRoutine_003Ed__37))]
		public IEnumerator CooldownRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CUpdateRestockTimer_003Ed__38))]
		public IEnumerator UpdateRestockTimer()
		{
			return null;
		}

		[ClientRpc]
		public void RpcRefreshCooldownUI(ushort i)
		{
		}

		[ClientRpc]
		public void RpcActivateInputType(byte it)
		{
		}

		[ClientRpc]
		public void RpcCooldown(bool cd)
		{
		}

		public void PriceOfBuffPerTeamMemberChanged(int oldValue, int newValue)
		{
		}

		public void CurrentCooldownTimerChanged(ushort oldValue, ushort newValue)
		{
		}

		public void InputTypeChanged(byte oldValue, byte newValue)
		{
		}

		public void ItemTypeAndRarityChanged(byte oldValue, byte newValue)
		{
		}

		public void ActivatedChanged(bool oldValue, bool newValue)
		{
		}

		public void CurrentTributeCountChanged(byte oldValue, byte newValue)
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

		public void UserCode_RpcActivateInputType__Byte(byte it)
		{
		}

		public static void InvokeUserCode_RpcActivateInputType__Byte(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcCooldown__Boolean(bool cd)
		{
		}

		public static void InvokeUserCode_RpcCooldown__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static TreeOfLife()
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

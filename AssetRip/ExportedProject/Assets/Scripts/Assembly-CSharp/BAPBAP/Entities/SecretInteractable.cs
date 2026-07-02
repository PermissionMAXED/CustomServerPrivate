using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Localisation;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SecretInteractable : InteractableStation, IEntityDataProperty
	{
		[CompilerGenerated]
		public sealed class _003CReStockRoutine_003Ed__26 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public SecretInteractable _003C_003E4__this;

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
			public _003CReStockRoutine_003Ed__26(int _003C_003E1__state)
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
		[Header("Properties")]
		public bool doReStock;

		[ConditionalHide("doReStock", true)]
		[SerializeField]
		public float reStockTime;

		[SerializeField]
		public int maxUses;

		[SerializeField]
		[Header("Food Effect Properties")]
		public List<StatusEffectInfo> statusEffects;

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
		public EntityBehaviour entityBehaviour;

		[SyncVar(hook = "CurrentUsesChanged")]
		[NonSerialized]
		public int currentUses;

		[SyncVar(hook = "CurrentRestockTimerChanged")]
		[NonSerialized]
		public int syncRestockTimer;

		[SyncVar(hook = "HideUIChanged")]
		[NonSerialized]
		public bool hideUI;

		[SyncVar(hook = "IdChanged")]
		[NonSerialized]
		public int id;

		public Action<int, int> _Mirror_SyncVarHookDelegate_currentUses;

		public Action<int, int> _Mirror_SyncVarHookDelegate_syncRestockTimer;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_hideUI;

		public Action<int, int> _Mirror_SyncVarHookDelegate_id;

		public int NetworkcurrentUses
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

		public int NetworksyncRestockTimer
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

		public bool NetworkhideUI
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

		public int Networkid
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

		public void InitializeId()
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

		public void ApplyEffect(EntityManager entity)
		{
		}

		public void StartRestock()
		{
		}

		[IteratorStateMachine(typeof(_003CReStockRoutine_003Ed__26))]
		public IEnumerator ReStockRoutine()
		{
			return null;
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		public void CurrentUsesChanged(int oldValue, int newValue)
		{
		}

		public void CurrentRestockTimerChanged(int oldValue, int newValue)
		{
		}

		public void HideUIChanged(bool oldValue, bool newValue)
		{
		}

		public void IdChanged(int oldValue, int newValue)
		{
		}

		public virtual string PropertyName()
		{
			return null;
		}

		public MapEntityData.Property.Field[] GetPropertyFields()
		{
			return null;
		}

		public void CopyProperties(IEntityDataProperty _source)
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

		static SecretInteractable()
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

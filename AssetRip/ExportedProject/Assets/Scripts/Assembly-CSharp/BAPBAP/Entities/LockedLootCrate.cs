using System;
using System.Runtime.InteropServices;
using BAPBAP.Items;
using BAPBAP.Maps;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class LockedLootCrate : InteractableStation
	{
		[Header("Properties")]
		[SerializeField]
		public int startingPrice;

		[SerializeField]
		public int maxLoot;

		[SerializeField]
		public ItemDrops randomDrops;

		[SerializeField]
		public GameObject completionObject;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string noItemsStr;

		[NonSerialized]
		public string flavorStr;

		[NonSerialized]
		public string costStr;

		[SyncVar(hook = "LootGivenChanged")]
		[NonSerialized]
		public bool lootGiven;

		[SyncVar(hook = "LockTypeChanged")]
		[NonSerialized]
		public byte lockType;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_lootGiven;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_lockType;

		public bool NetworklootGiven
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

		public byte NetworklockType
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

		public virtual void InitializeLockType()
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

		public override void OnCastingCompleted(EntityManager entity, int slotId)
		{
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		public void LootGivenChanged(bool oldValue, bool newValue)
		{
		}

		public void LockTypeChanged(byte oldValue, byte newValue)
		{
		}

		public MapEntityData.Property.IntField[] GetPropertyIntFields()
		{
			return null;
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

		static LockedLootCrate()
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

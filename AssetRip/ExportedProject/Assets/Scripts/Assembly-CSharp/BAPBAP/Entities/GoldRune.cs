using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class GoldRune : InteractableStation
	{
		[Header("Properties")]
		[SerializeField]
		public List<PassiveSO> passiveList;

		[SerializeField]
		public List<int> priceList;

		[Header("Translation Keys")]
		[SerializeField]
		public string goldRuneTitleTranslationKey;

		[NonSerialized]
		public int passiveId;

		[NonSerialized]
		public int price;

		[NonSerialized]
		public string complete;

		[NonSerialized]
		public string purchase;

		[NonSerialized]
		public string purchaseFor;

		[NonSerialized]
		public string purchasing;

		[NonSerialized]
		public string hp;

		[NonSerialized]
		public string buff;

		[NonSerialized]
		public string myName;

		[SyncVar(hook = "GoldRuneIndexChanged")]
		[NonSerialized]
		public int goldRuneIndex;

		public Action<int, int> _Mirror_SyncVarHookDelegate_goldRuneIndex;

		public int NetworkgoldRuneIndex
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

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public void Localise(Translator translator)
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

		[ClientRpc]
		public void RpcUsed(EntityManager entity)
		{
		}

		[ClientRpc]
		public void RpcActivateSlot(int id)
		{
		}

		public void GoldRuneIndexChanged(int oldValue, int newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcUsed__EntityManager(EntityManager entity)
		{
		}

		public static void InvokeUserCode_RpcUsed__EntityManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcActivateSlot__Int32(int id)
		{
		}

		public static void InvokeUserCode_RpcActivateSlot__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static GoldRune()
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

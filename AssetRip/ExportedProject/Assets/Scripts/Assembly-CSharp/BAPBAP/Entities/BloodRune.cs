using System;
using System.Runtime.InteropServices;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BloodRune : InteractableStation
	{
		[Serializable]
		public class PassivePool
		{
			public PassiveSO passive;

			public int healthToSacrifice;

			public Sprite spriteIcon;

			public string descStr;
		}

		[Header("Properties")]
		[SerializeField]
		public PassivePool[] passivePool;

		[Header("References")]
		[SerializeField]
		public GameObject col;

		[NonSerialized]
		public int healthToSacrifice;

		[NonSerialized]
		public int passiveId;

		[NonSerialized]
		public string complete;

		[NonSerialized]
		public string sacrifice;

		[NonSerialized]
		public string sacrificing;

		[NonSerialized]
		public string hp;

		[NonSerialized]
		public string buff;

		[NonSerialized]
		public string current;

		[NonSerialized]
		public string max;

		[SyncVar(hook = "OnBloodRuneIndexChanged")]
		[NonSerialized]
		public int bloodRuneIndex;

		public Action<int, int> _Mirror_SyncVarHookDelegate_bloodRuneIndex;

		public int NetworkbloodRuneIndex
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

		public void SetPassivePrice()
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

		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		public void OnBloodRuneIndexChanged(int oldValue, int newValue)
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

		public override void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static BloodRune()
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

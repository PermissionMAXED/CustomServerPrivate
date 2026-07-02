using System;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class GooZone : InteractableStation
	{
		[Header("References")]
		[NonSerialized]
		public Transform windowTransform;

		[Header("Properties")]
		[SerializeField]
		public PassiveSO passiveToCheck;

		[SerializeField]
		public PassiveSO passiveToActivate;

		[SerializeField]
		public float colliderRadius;

		[SerializeField]
		public float meterCost;

		[SerializeField]
		[Header("Configs")]
		public string purchaseString;

		[SerializeField]
		public string purchaseForString;

		[NonSerialized]
		public string purchasingStr;

		[NonSerialized]
		public string purchaseForStr;

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void AddCollider(Vector3 pos, float radius)
		{
		}

		[ClientRpc]
		public void RpcAddCollider(Vector3 pos, float radius)
		{
		}

		public override void OnSlotEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
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

		public void Update()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcAddCollider__Vector3__Single(Vector3 pos, float radius)
		{
		}

		public static void InvokeUserCode_RpcAddCollider__Vector3__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static GooZone()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities.Pickups
{
	public class HpSpawner : PickupSpawner
	{
		[SerializeField]
		public float hpIncreasePercentage;

		[SerializeField]
		[Header("Sfx")]
		public AudioClipData pickupSfx;

		[NonSerialized]
		public List<EntityManager> enteredEntities;

		public override bool CharGetPickup(EntityManager entityManager)
		{
			return false;
		}

		[ServerCallback]
		public override void Update()
		{
		}

		public override void OnEnter(EntityManager e)
		{
		}

		public override void OnExit(EntityManager e)
		{
		}

		[ClientRpc]
		public void RpcPlayGetPickup()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayGetPickup()
		{
		}

		public static void InvokeUserCode_RpcPlayGetPickup(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static HpSpawner()
		{
		}
	}
}

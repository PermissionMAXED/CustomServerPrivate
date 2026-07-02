using System;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class PassiveRuneOnce : InteractableStation
	{
		[Header("Properties")]
		[SerializeField]
		public PassiveSO[] passivePool;

		[NonSerialized]
		public readonly SyncList<int> interactedWithPlayers;

		public override void Start()
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
		public override void RpcOnUseFail(EntityManager entity, int slotId)
		{
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entity, int slotId)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void UserCode_RpcOnUseFail__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseFail__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entity, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PassiveRuneOnce()
		{
		}
	}
}

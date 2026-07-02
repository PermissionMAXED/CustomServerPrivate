using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateObject : EntityActivateBase
	{
		[SerializeField]
		public GameObject g;

		[SerializeField]
		public bool active;

		[SerializeField]
		public float activateDelay;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool done;

		[ServerCallback]
		public override void Activate()
		{
		}

		[ClientCallback]
		public void FixedUpdate()
		{
		}

		[ClientRpc]
		public void RpcActivate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcActivate()
		{
		}

		public static void InvokeUserCode_RpcActivate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateObject()
		{
		}
	}
}

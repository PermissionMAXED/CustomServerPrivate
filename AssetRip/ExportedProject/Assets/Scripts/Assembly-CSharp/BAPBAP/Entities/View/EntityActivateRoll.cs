using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class EntityActivateRoll : EntityActivateBase
	{
		[NonSerialized]
		public EntityRoll entityRoll;

		public override void Awake()
		{
		}

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcStartRoll(Vector3 pushDir)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcStartRoll__Vector3(Vector3 pushDir)
		{
		}

		public static void InvokeUserCode_RpcStartRoll__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateRoll()
		{
		}
	}
}

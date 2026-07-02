using Mirror;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.Entities
{
	public class EntityActivateAction : EntityActivateBase
	{
		[SerializeField]
		public UnityEvent[] svActivateEvents;

		[SerializeField]
		public UnityEvent[] clActivateEvents;

		public override void Activate()
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

		static EntityActivateAction()
		{
		}
	}
}

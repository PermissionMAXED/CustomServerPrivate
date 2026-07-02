using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateVFXTriggerArea : EntityActivateBase
	{
		[Header("Settings")]
		[SerializeField]
		public GameObject vfxPrefab;

		[SerializeField]
		public float destroyTime;

		[SerializeField]
		public bool parented;

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcPlay()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlay()
		{
		}

		public static void InvokeUserCode_RpcPlay(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateVFXTriggerArea()
		{
		}
	}
}

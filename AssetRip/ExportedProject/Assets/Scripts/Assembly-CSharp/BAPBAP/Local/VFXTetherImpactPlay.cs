using BAPBAP.Entities;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXTetherImpactPlay : NetworkBehaviour
	{
		[SerializeField]
		public GameObject lightingTetherVfxPrefab;

		[SerializeField]
		public float vfxTtl;

		[ClientRpc]
		public void RpcOnLightingTargetHit(EntityManager sourceEntity, Vector3 sourcePos, EntityManager otherEntity, Vector3 otherEntityPos)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnLightingTargetHit__EntityManager__Vector3__EntityManager__Vector3(EntityManager sourceEntity, Vector3 sourcePos, EntityManager otherEntity, Vector3 otherEntityPos)
		{
		}

		public static void InvokeUserCode_RpcOnLightingTargetHit__EntityManager__Vector3__EntityManager__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static VFXTetherImpactPlay()
		{
		}
	}
}

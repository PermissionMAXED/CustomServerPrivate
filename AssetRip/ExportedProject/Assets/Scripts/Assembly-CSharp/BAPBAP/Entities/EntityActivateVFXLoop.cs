using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateVFXLoop : EntityActivateBase
	{
		[Header("Settings")]
		[SerializeField]
		public ParticleSystem vfxLoopReady;

		[SerializeField]
		public bool enable;

		public void Start()
		{
		}

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

		static EntityActivateVFXLoop()
		{
		}
	}
}

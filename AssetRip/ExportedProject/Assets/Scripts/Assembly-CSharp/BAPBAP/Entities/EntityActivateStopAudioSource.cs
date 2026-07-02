using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateStopAudioSource : EntityActivateBase
	{
		[SerializeField]
		[Header("Settings")]
		public AudioSource aS;

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcSpawnSfx()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnSfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnSfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateStopAudioSource()
		{
		}
	}
}

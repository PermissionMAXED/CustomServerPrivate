using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateConeIndicator : EntityActivateBase
	{
		[SerializeField]
		[Header("Settings")]
		public bool activateOnStart;

		[SerializeField]
		public bool showOnlyAllies;

		[Header("Indicator Config")]
		[SerializeField]
		public GameObject coneIndicatorPrefab;

		[SerializeField]
		public bool doTtl;

		[Min(0f)]
		[SerializeField]
		public float duration;

		[SerializeField]
		public float coneIndicatorRadius;

		[SerializeField]
		public float coneIndicatorHalfAngle;

		public void Start()
		{
		}

		[ServerCallback]
		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcSpawnIndicator()
		{
		}

		public void ClSpawnIndicator()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnIndicator()
		{
		}

		public static void InvokeUserCode_RpcSpawnIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateConeIndicator()
		{
		}
	}
}

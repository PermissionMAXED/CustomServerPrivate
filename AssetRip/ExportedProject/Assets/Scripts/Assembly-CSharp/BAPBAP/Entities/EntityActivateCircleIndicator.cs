using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateCircleIndicator : EntityActivateBase
	{
		[SerializeField]
		[Header("Settings")]
		public bool activateOnStart;

		[SerializeField]
		public bool showOnlyAllies;

		[Header("Indicator Config")]
		[SerializeField]
		public GameObject circleIndicatorPrefab;

		[SerializeField]
		public bool doTtl;

		[SerializeField]
		[Min(0f)]
		public float duration;

		[SerializeField]
		public float radius;

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

		static EntityActivateCircleIndicator()
		{
		}
	}
}

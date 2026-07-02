using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateBoxIndicator : EntityActivateBase
	{
		[Header("Settings")]
		[SerializeField]
		public bool activateOnStart;

		[SerializeField]
		public bool showOnlyAllies;

		[SerializeField]
		[Header("Indicator Config")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public bool doTtl;

		[SerializeField]
		[Min(0f)]
		public float duration;

		[SerializeField]
		public Vector2 mouseHalfScale;

		[SerializeField]
		public Vector2 baseHalfScale;

		[SerializeField]
		public Vector2 offset;

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

		static EntityActivateBoxIndicator()
		{
		}
	}
}

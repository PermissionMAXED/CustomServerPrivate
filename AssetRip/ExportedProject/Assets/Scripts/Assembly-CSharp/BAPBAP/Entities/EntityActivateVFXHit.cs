using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateVFXHit : EntityActivateBase
	{
		[Header("Settings")]
		[SerializeField]
		public GameObject onHitVfxPrefab;

		[SerializeField]
		public bool onHitVfxSpawnInWorld;

		[SerializeField]
		public Transform customParentTransform;

		[SerializeField]
		[Tooltip("Instead of spawning the vfx prefab on every hit, just call Play() on a single spawned vfx object")]
		public bool playVfxInsteadOfSpawn;

		[SerializeField]
		public float vfxDestroyDelay;

		[SerializeField]
		public float vfxScale;

		[NonSerialized]
		public GameObject spawnedHitVfx;

		public override void Activate()
		{
		}

		[ClientRpc]
		public void RpcPlayHit(int teamId)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayHit__Int32(int teamId)
		{
		}

		public static void InvokeUserCode_RpcPlayHit__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateVFXHit()
		{
		}
	}
}

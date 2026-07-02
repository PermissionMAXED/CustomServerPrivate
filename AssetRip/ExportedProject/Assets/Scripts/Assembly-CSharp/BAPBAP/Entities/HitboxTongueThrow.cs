using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxTongueThrow : NetworkBehaviour
	{
		[NonSerialized]
		public Hitbox hitbox;

		[NonSerialized]
		public TransformExpandScale expandScale;

		[NonSerialized]
		public HitboxFollowPosition followPosition;

		[NonSerialized]
		public TongueJumpAbility tongueAbility;

		[NonSerialized]
		public bool foundTarget;

		[NonSerialized]
		public bool isServerCache;

		[NonSerialized]
		public float castRadius;

		[NonSerialized]
		public RaycastHit[] hits;

		[NonSerialized]
		public LayerMask obstacleMask;

		public void Awake()
		{
		}

		public void OnDestroy()
		{
		}

		public void FixedUpdate()
		{
		}

		public override void OnStartServer()
		{
		}

		public void Initialize(TongueJumpAbility tongueAbility)
		{
		}

		public void OnHitboxCharHit(EntityManager entity, HitboxBase hitboxBase)
		{
		}

		public void OnHitboxObstacleCollision(Collider collider)
		{
		}

		public void OnLevelPositionHit(Vector3 pos)
		{
		}

		public void OnEntityHit(EntityManager entity, int entityTeamId, uint entityNetId)
		{
		}

		public void OnDisable()
		{
		}

		public void OnTongeDisable()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxDestroyOnDistanceToLookAtTarget : NetworkBehaviour
	{
		[SerializeField]
		public HitboxBase hitbox;

		[SerializeField]
		public ProjectileMove projectileMove;

		[SerializeField]
		public TransformLookAtTarget transformLookAtTarget;

		[SerializeField]
		public float distanceToDestroy;

		[SerializeField]
		public float stopDistance;

		[NonSerialized]
		public EntityManager targetEntity;

		public void Update()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

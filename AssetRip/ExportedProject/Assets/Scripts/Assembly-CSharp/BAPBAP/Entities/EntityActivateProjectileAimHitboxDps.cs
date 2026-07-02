using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateProjectileAimHitboxDps : EntityActivateBase
	{
		[Header("ProjectileAimHitboxDps settings")]
		[SerializeField]
		public GameObject beeSwarmPrefab;

		[SerializeField]
		public int damage;

		[SerializeField]
		public float tickRate;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float searchRadius;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("More Settings")]
		[SerializeField]
		public bool counterable;

		[SerializeField]
		public bool goToPositionIfNoTarget;

		public override void Activate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

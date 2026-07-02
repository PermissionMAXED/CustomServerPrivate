using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateProjectile : EntityActivateBase
	{
		[Header("Projectile Settings")]
		public GameObject projectileHitboxPrefab;

		public Transform firingPoint;

		public int projDamage;

		public float percentHpDamage;

		[SerializeField]
		public float projSpeed;

		[SerializeField]
		public float projTTL;

		[SerializeField]
		public float projBullets;

		[SerializeField]
		public float projAngleSpread;

		[SerializeField]
		public bool useSpeedCurve;

		[ConditionalHide("useSpeedCurve", true)]
		[SerializeField]
		public AnimationCurve speedCurve;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("More Settings")]
		[SerializeField]
		public bool directional;

		[SerializeField]
		public bool destroyOnCharHit;

		[SerializeField]
		public bool destroyOnStaticCollision;

		[SerializeField]
		public bool playImpactOnChar;

		[SerializeField]
		public bool allowLifesteal;

		[SerializeField]
		public bool allowThorns;

		[SerializeField]
		public bool applyDamageHpPercentageToNpcs;

		[SerializeField]
		public bool alwaysHitInteractables;

		[SerializeField]
		public bool counterable;

		[SerializeField]
		public bool collidesWithLowWalls;

		[SerializeField]
		public bool onlyHitCharacterOnce;

		[NonSerialized]
		public List<CharHurtbox> hittedChars;

		public override void Activate()
		{
		}

		[Server]
		public void SpawnProjectile(float angle)
		{
		}

		public void OnHitSuccess(EntityManager entity, HitboxBase hitbox)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

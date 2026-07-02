using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	public class EntityActivateProjectileContinuous : EntityActivateBase
	{
		[Header("Projectile Settings")]
		[SerializeField]
		public GameObject projectileHitboxPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public ParticleSystem vfxRight;

		[SerializeField]
		public ParticleSystem vfxLeft;

		[SerializeField]
		public int projDamage;

		[SerializeField]
		public float projSpeed;

		[SerializeField]
		public float projTTL;

		[SerializeField]
		public float projBullets;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public bool directional;

		[SerializeField]
		public bool enableSpeedCurve;

		[SerializeField]
		public AnimationCurve speedCurve;

		[SerializeField]
		public float duration;

		[SerializeField]
		public float expandDuration;

		[SerializeField]
		[FormerlySerializedAs("expandScale")]
		public float expandRadius;

		[Header("More Settings")]
		[SerializeField]
		public bool destroyOnCharHit;

		[SerializeField]
		public bool destroyOnStaticCollision;

		[SerializeField]
		public bool allowLifesteal;

		[SerializeField]
		public bool allowThorns;

		[SerializeField]
		public bool applyDamageHpPercentageToNpcs;

		[SerializeField]
		public bool counterable;

		[NonSerialized]
		public bool activated;

		[NonSerialized]
		public float fireRate;

		[NonSerialized]
		public float fireRateTimer;

		[NonSerialized]
		public float timer;

		public override void Awake()
		{
		}

		public override void Activate()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		[Server]
		public void SpawnProjectile(float angle, float speed, float ttl, int damage)
		{
		}

		public void RpcStopCastVFX()
		{
		}

		[ClientRpc]
		public void RpcPlayShootVFX()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayShootVFX()
		{
		}

		public static void InvokeUserCode_RpcPlayShootVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityActivateProjectileContinuous()
		{
		}
	}
}

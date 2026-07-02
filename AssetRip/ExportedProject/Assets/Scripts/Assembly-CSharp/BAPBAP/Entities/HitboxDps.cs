using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HitboxDps : HitboxBase
	{
		[NonSerialized]
		public float dmgPerTimeRate;

		[NonSerialized]
		public bool onlyDamageOnLineOfSight;

		[NonSerialized]
		public float elapsedTime;

		[NonSerialized]
		public float dmgPerTimeTimer;

		[NonSerialized]
		public bool doDmg;

		public static LayerMask obstacleMask;

		[NonSerialized]
		public Action<GameObject> onTriggerEnterAction;

		[NonSerialized]
		public RaycastHit[] hits;

		public override float ElapsedTime => 0f;

		public override void OnDespawn()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void FixedUpdate()
		{
		}

		[ServerCallback]
		public void OnTriggerStay(Collider collider)
		{
		}

		public virtual void ApplyHit(Hitbox.EntityHit entityHit)
		{
		}

		public bool IsLineOfSightBlocked(Vector3 targetPosition)
		{
			return false;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

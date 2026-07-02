using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Hitbox : HitboxBase
	{
		public struct EntityHit
		{
			public EntityManager entity;

			public Collider collider;

			public EntityHit(EntityManager entity, Collider collider)
			{
				this.entity = null;
				this.collider = null;
			}

			public EntityHit(EntityManager entity)
			{
				this.entity = null;
				collider = null;
			}
		}

		[SerializeField]
		[Tooltip("Should this hitbox check for static collision visibility on hit?")]
		public bool checkForStaticCollision;

		[SerializeField]
		[Tooltip("Set the point from where the raycast will check for obstacle collisions")]
		public float hitboxBackLength;

		[SerializeField]
		[Tooltip("Should the destroy fx spawn when not impacting?")]
		public bool spawnDestroyFxOnImpact;

		[SyncVar]
		[NonSerialized]
		public float elapsedTime;

		[NonSerialized]
		public LayerMask obstacleMask;

		[NonSerialized]
		public bool hasHitCollision;

		[NonSerialized]
		public List<Collider> obstacleHits;

		[NonSerialized]
		public List<EntityHit> entityHits;

		[NonSerialized]
		public RaycastHit losHit;

		public Action<GameObject> onTriggerEnterAction;

		public Action<Collider> onObstacleHitAction;

		public Action<EntityManager> onEntityImpactAction;

		public override float ElapsedTime => 0f;

		public float NetworkelapsedTime
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public override void Awake()
		{
		}

		public override void OnDespawn()
		{
		}

		[ServerCallback]
		public void Update()
		{
		}

		public void ProcessHits()
		{
		}

		[ServerCallback]
		public void OnTriggerEnter(Collider collider)
		{
		}

		[Server]
		public void DoObstacleHit(Collider collider)
		{
		}

		[Server]
		public void DoEntityHit(EntityHit entityHit)
		{
		}

		[Server]
		public void OnHitboxImpact(Vector3 impactPosition)
		{
		}

		public bool IsLineOfSightBlocked(EntityManager em)
		{
			return false;
		}

		public bool IsLevelObstacleHit(Collider col)
		{
			return false;
		}

		public void ResetHittedChars()
		{
		}

		public void ResetElapsedTime()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}

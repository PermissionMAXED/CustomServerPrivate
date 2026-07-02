using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TriggerPhysicsForceAreaHitbox : MonoBehaviour
	{
		[NonSerialized]
		public HitboxBase hitboxBase;

		[SerializeField]
		public bool applyOnHitEntities;

		[SerializeField]
		public bool checkForStaticCollision;

		[SerializeField]
		public float forceIntensity;

		[SerializeField]
		[Min(0f)]
		public float forceDecel;

		[NonSerialized]
		public int obstaclesMask;

		public void Awake()
		{
		}

		public void OnTriggerEnter(Collider col)
		{
		}

		public void ApplyForce(Collider col)
		{
		}

		public void ApplyForceEntity(EntityManager entity, HitboxBase hitboxBase)
		{
		}

		public Vector3 GetForceVel(Transform _transform)
		{
			return default(Vector3);
		}

		public bool IsLineOfSightBlocked(Vector3 targetPosition)
		{
			return false;
		}
	}
}

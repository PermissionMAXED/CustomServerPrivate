using System;
using UnityEngine;

namespace Gamekit3D
{
	public class MeleeWeapon : MonoBehaviour
	{
		[Serializable]
		public class AttackPoint
		{
			public float radius;

			public Vector3 offset;

			public Transform attackRoot;
		}

		public int damage;

		public ParticleSystem hitParticlePrefab;

		public LayerMask targetLayers;

		public AttackPoint[] attackPoints;

		public TimeEffect[] effects;

		[NonSerialized]
		public GameObject m_Owner;

		[NonSerialized]
		public Vector3[] m_PreviousPos;

		[NonSerialized]
		public Vector3 m_Direction;

		[NonSerialized]
		public bool m_IsThrowingHit;

		[NonSerialized]
		public bool m_InAttack;

		public const int PARTICLE_COUNT = 10;

		[NonSerialized]
		public ParticleSystem[] m_ParticlesPool;

		[NonSerialized]
		public int m_CurrentParticle;

		public static RaycastHit[] s_RaycastHitCache;

		public static Collider[] s_ColliderCache;

		public bool throwingHit
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void SetOwner(GameObject owner)
		{
		}

		public void BeginAttack(bool thowingAttack)
		{
		}

		public void EndAttack()
		{
		}

		public void FixedUpdate()
		{
		}

		public bool CheckDamage(Collider other, AttackPoint pts)
		{
			return false;
		}
	}
}

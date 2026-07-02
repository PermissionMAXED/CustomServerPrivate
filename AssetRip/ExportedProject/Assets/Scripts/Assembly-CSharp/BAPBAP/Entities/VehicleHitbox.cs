using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(Vehicle))]
	public class VehicleHitbox : NetworkBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public Vehicle vehicle;

		[Header("Settings")]
		[SerializeField]
		public float speedThresholdActivateHitbox;

		[SerializeField]
		public GameObject hitboxPrefab;

		[SerializeField]
		public int hitboxDamage;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[NonSerialized]
		public Hitbox collisionHitbox;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void FixedUpdate()
		{
		}

		public void CreateCollisionHitbox()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

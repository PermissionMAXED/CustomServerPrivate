using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateHitboxTrail : EntityActivateHitbox
	{
		[Header("Trail Spawn Settings")]
		[Tooltip("How many hitboxes to spawn spread through the distance and duration")]
		[SerializeField]
		[Min(1f)]
		public int spawnNum;

		[Tooltip("The distance from hitbox to hitbox spawned, in world units")]
		[SerializeField]
		[Min(0.01f)]
		public float distance;

		[Tooltip("The total duration for spawning hitboxes")]
		[Min(0.01f)]
		[SerializeField]
		public float duration;

		[NonSerialized]
		public float spawnRate;

		[NonSerialized]
		public bool isEnabled;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float spawnTimer;

		[NonSerialized]
		public Vector3 spawnPosition;

		[NonSerialized]
		public Vector3 direction;

		public override void Awake()
		{
		}

		[Server]
		public override void Activate()
		{
		}

		public void Update()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

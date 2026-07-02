using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SpriestAutoTarget : MonoBehaviour
	{
		[NonSerialized]
		public float expungeRange;

		[NonSerialized]
		public EntityManager target;

		[NonSerialized]
		public Transform player;

		[NonSerialized]
		public HitboxDps tendrilDps;

		public void SetTarget(Transform _player, EntityManager _target, float range, HitboxDps hDps)
		{
		}

		public void FixedUpdate()
		{
		}
	}
}

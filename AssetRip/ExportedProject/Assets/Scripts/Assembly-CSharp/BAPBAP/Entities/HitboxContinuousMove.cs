using System;
using System.Collections.Generic;

namespace BAPBAP.Entities
{
	public class HitboxContinuousMove : HitboxTriggerbox
	{
		[NonSerialized]
		public float force;

		[NonSerialized]
		public List<EntityManager> currentEntities;

		public override void Awake()
		{
		}

		public override void OnDespawn()
		{
		}

		public override void FixedUpdate()
		{
		}

		public void MovePassengerInPath(EntityManager entityManager, float fixedDt)
		{
		}

		public override void OnEnter(EntityManager entity)
		{
		}

		public override void OnExit(EntityManager entity)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

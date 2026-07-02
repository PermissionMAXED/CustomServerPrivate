using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CollisionVoidArea : NetworkBehaviour
	{
		public Action<EntityManager> onAreaEnter;

		public Action<EntityManager> onAreaExit;

		[NonSerialized]
		public List<EntityManager> hitEntities;

		[NonSerialized]
		public List<HitboxBase> hitHitboxes;

		public void OnTriggerEnter(Collider collider)
		{
		}

		public void OnTriggerExit(Collider collider)
		{
		}

		public void OnEntityEnter(EntityManager e)
		{
		}

		public void OnEntityExit(EntityManager e)
		{
		}

		public void OnDisable()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

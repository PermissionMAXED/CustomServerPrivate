using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class SlipperyArea : NetworkBehaviour, IPhysicsResimulated
	{
		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[NonSerialized]
		public bool isResim;

		public void Awake()
		{
		}

		public void SimTriggerEnter(Collider collider)
		{
		}

		public void SimTriggerExit(Collider collider)
		{
		}

		public void OnEnter(EntityManager e)
		{
		}

		public void OnExit(EntityManager e)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityLoopActivation : EntityActivateBase
	{
		[SerializeField]
		public EntityActivateBase[] activations;

		[SerializeField]
		public bool startTimerDuration;

		[Min(0f)]
		[SerializeField]
		public float loopDuration;

		[SerializeField]
		[Min(0f)]
		public float startDelay;

		[NonSerialized]
		public float timer;

		public override void Awake()
		{
		}

		public override void Activate()
		{
		}

		[ServerCallback]
		public virtual void FixedUpdate()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

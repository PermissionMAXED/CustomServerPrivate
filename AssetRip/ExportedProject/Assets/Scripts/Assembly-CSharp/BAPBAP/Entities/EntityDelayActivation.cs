using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityDelayActivation : EntityActivateBase
	{
		[SerializeField]
		public EntityActivateBase[] activations;

		[Min(0f)]
		[SerializeField]
		public float delay;

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

using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivatePush : EntityActivateBase
	{
		[NonSerialized]
		public EntityMovement entityMove;

		[Header("Settings")]
		[SerializeField]
		public float impulseForce;

		[SerializeField]
		public float decel;

		public override void Awake()
		{
		}

		public override void Activate()
		{
		}

		public void DoImpulse()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

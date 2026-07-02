using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityCooldownFXClock : NetworkBehaviour
	{
		[SerializeField]
		public Transform restockClockNeedle;

		[SerializeField]
		public SpriteRenderer restockProgressRingRend;

		[NonSerialized]
		public float cooldownDuration;

		[NonSerialized]
		public float cooldown;

		[NonSerialized]
		public EntityBehaviour entityBehaviour;

		public void Start()
		{
		}

		public void SetCooldown(float cd)
		{
		}

		public void SetRestockProgressRing(float normValue)
		{
		}

		public void SetRestockNeedleProgress(float normValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class HitboxTriggerbox : Hitbox
	{
		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		public override void Awake()
		{
		}

		public void Start()
		{
		}

		public virtual void OnEnter(EntityManager entity)
		{
		}

		public virtual void OnExit(EntityManager entity)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_CelesteFrozen : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public int maxStacks;

			public float freezeDuration;

			public float slowAmount;

			public float slowDuration;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int stacks;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_CelesteFrozen(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Reactivate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}
	}
}

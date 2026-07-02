using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Poisoned : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float poisonedDamagePerTick;

			public float tickDuration;

			public int maxPoisonStacks;

			public float burstMultiplier;

			public int burstBaseDmg;

			public float slowDuration;

			public float slowRate;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int poisonStacks;

		[NonSerialized]
		public float hitTimer;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Poisoned(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Deactivate()
		{
		}

		public void Trigger()
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}

		public override void ClDeactivate()
		{
		}

		public override void OnTick(float dt)
		{
		}
	}
}

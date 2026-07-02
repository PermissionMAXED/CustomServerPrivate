using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_FadingSnare : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float originalDuration;

		[NonSerialized]
		public SE_Slowed highestSlow;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_FadingSnare(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Deactivate()
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

		public static SE_Slowed FindHighestStatusEffect(CharStatusEffects charStatusEffects)
		{
			return null;
		}
	}
}

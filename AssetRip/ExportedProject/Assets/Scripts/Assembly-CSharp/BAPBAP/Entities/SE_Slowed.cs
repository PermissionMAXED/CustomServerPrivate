using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Slowed : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool isSlowestMultiplier;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Slowed(EntityManager entityManager, Config config)
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

		public void TryRevertHighest()
		{
		}

		public void TryApplyHighest()
		{
		}

		public static SE_Slowed FindHighestStatusEffect(CharStatusEffects charStatusEffects)
		{
			return null;
		}
	}
}

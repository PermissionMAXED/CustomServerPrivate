using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Weakened : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public bool isWeakestMultiplier;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Weakened(EntityManager entityManager, Config config)
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

		public SE_Weakened FindHighestStatusEffect()
		{
			return null;
		}
	}
}

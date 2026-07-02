using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_HealingPotion : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_HealingPotion(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}
	}
}

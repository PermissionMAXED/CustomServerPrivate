using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Skull : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public bool trueDamage;

			public PassiveSO passiveToDeactivate;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool hit;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Skull(EntityManager entityManager, Config config)
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
	}
}

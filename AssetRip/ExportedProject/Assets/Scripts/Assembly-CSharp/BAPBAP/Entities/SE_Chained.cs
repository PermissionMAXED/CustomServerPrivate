using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Chained : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float slowSpeed;
		}

		[NonSerialized]
		public Config config;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Chained(EntityManager entityManager, Config config)
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

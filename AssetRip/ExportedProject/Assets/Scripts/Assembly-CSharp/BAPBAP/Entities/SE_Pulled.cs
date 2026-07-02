using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Pulled : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float force;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float originalDuration;

		[NonSerialized]
		public float offsetAmount;

		[NonSerialized]
		public Vector3 dir;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Pulled(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void OnTick(float dt)
		{
		}

		public override void Deactivate()
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}
	}
}

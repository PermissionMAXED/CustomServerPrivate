using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_NearSight : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float nearSightAmount;
		}

		[NonSerialized]
		public Config config;

		public static float nearSightAmount;

		[NonSerialized]
		public int nearSightLocks;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_NearSight(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Deactivate()
		{
		}

		public override void OnTick(float dt)
		{
		}

		public override void ClActivate(float _duration, float _multiplier)
		{
		}

		public override void ClDeactivate()
		{
		}

		public override void Reactivate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}
	}
}

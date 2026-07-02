using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Airborne : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float jumpDuration;

			public float recoveryDuration;

			public AnimationCurve lerpCurve;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float startDuration;

		[NonSerialized]
		public Vector3 originalPos;

		[NonSerialized]
		public bool landed;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Airborne(EntityManager entityManager, Config config)
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

		public override void OnTick(float fixedDt)
		{
		}
	}
}

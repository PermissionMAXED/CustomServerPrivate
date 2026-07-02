using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_CementZone : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float slowAmount;

			public float timeUntilCemented;

			public float cementedDuration;

			public float moveLerpFactor;

			public float moveBreakThreshold;

			public float moveBreakTimerSpeed;

			public SE_Cemented_SO cementedStatusEffect;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int zoneLocks;

		[NonSerialized]
		public float cementZoneTimer;

		[NonSerialized]
		public bool isCemented;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_CementZone(EntityManager entityManager, Config config)
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

		public void ApplyCemented()
		{
		}

		public void RemoveCemented()
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

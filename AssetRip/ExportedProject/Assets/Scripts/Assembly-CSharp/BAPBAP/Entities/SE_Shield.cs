using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Shield : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public int minDurationToShowUI;

			public int maxDurationToShowUI;

			public PassiveSO P_ShowShieldEffect;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int addedShield;

		[NonSerialized]
		public bool isOldest;

		[NonSerialized]
		public Passive appliedPassive;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Shield(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Deactivate()
		{
		}

		public void OnShieldHit(int damage)
		{
		}

		public void SetOldest(bool isOldest)
		{
		}
	}
}

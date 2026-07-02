using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_BloodHunt : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float speedAmount;

			public float bonusPercentDmg;

			public float passiveUpdateRate;

			public PassiveSO passiveToCheckFor;

			public PassiveSO meterPassive;

			public PassiveSO gooDive;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int bloodHuntLocks;

		[NonSerialized]
		public bool hasPassive;

		[NonSerialized]
		public bool clHasPassive;

		[NonSerialized]
		public float updateTime;

		[NonSerialized]
		public float clUpdateTime;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_BloodHunt(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Activate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void Deactivate()
		{
		}

		public override void Reactivate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void OnTick(float dt)
		{
		}

		public override void ClOnTick(float dt)
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

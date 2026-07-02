using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Sprint : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float sprintGain;

		[NonSerialized]
		public bool isHighestMultiplier;

		[NonSerialized]
		public bool isDecaying;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Sprint(EntityManager entityManager, Config config)
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

		public override void OnTick(float dt)
		{
		}

		public override void Reactivate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public void TryRevertHighest()
		{
		}

		public void TryActivateHighest()
		{
		}

		public SE_Sprint FindHighestStatusEffect()
		{
			return null;
		}

		public override float GetMultiplier()
		{
			return 0f;
		}
	}
}

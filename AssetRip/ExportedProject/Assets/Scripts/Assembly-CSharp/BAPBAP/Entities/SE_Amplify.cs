using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Amplify : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool isAmpliestMultiplier;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Amplify(EntityManager entityManager, Config config)
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

		public void TryRevertHighest()
		{
		}

		public void TryActivateHighest()
		{
		}

		public SE_Amplify FindHighestStatusEffect()
		{
			return null;
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Revealed : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int revealedLocks;

		[NonSerialized]
		public int clRevealedLocks;

		[NonSerialized]
		public LayerMask obstacleMask;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Revealed(EntityManager entityManager, Config config)
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

		public override void ClReactivate(float _duration, float _multiplier)
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

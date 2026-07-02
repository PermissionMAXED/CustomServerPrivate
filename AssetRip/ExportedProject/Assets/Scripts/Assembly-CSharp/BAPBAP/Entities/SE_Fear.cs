using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Fear : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float changeDirRate;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public Vector3 moveDirOverride;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Fear(EntityManager entityManager, Config config)
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

		public override void Reactivate(float _duration, float _multiplier, int _otherPlayerId, Vector3 _direction)
		{
		}

		public override void OnTick(float dt)
		{
		}

		public void TickFear(float dt)
		{
		}

		public override Vector3 ApplyInputDirModification(Vector3 inputDir)
		{
			return default(Vector3);
		}
	}
}

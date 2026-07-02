using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SE_Cemented : StatusEffect
	{
		[Serializable]
		public class Config : StatusEffectConfiguration
		{
			[Header("Custom Config")]
			public float moveLerpFactor;

			public float moveBreakThreshold;

			public float moveBreakTimerAdvanceAmount;

			public float moveInputCooldown;

			[Header("Move Fx Config")]
			public float pushFxDuration;

			public float pushFxIntensity;

			public GameObject moveFxPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float initialDuration;

		[NonSerialized]
		public Vector3 prevMoveInput;

		[NonSerialized]
		public float lerpedInputMagnitude;

		[NonSerialized]
		public float inputCdTimer;

		[NonSerialized]
		public GameObject moveFxInstance;

		[NonSerialized]
		public ParticleSystem moveVfx;

		[NonSerialized]
		public AudioSource moveSfx;

		public override StatusEffectConfiguration statusEffectConfig => null;

		public SE_Cemented(EntityManager entityManager, Config config)
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

		public void ClOnMove()
		{
		}
	}
}

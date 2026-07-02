using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SlimeBossMoveJumpAbility : Ability
	{
		public class CustomGetJumpPointSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossMoveJumpAbility ability;

			public CustomGetJumpPointSubroutine(SlimeBossMoveJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomLookAtTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossMoveJumpAbility ability;

			public CustomLookAtTargetSubroutine(SlimeBossMoveJumpAbility _ability)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomJumpSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossMoveJumpAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			public CustomJumpSubroutine(SlimeBossMoveJumpAbility _ability, byte _trigger, float _waitTime)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float maxRange;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject takeoffVfxId;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData castSfx;

		[Header("Misc")]
		[SerializeField]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public AnimationCurve baseShadowAlphaCurve;

		[SerializeField]
		public float jumpRadiusCheck;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public Vector3 jumpPoint;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void ResetCooldown()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_BrainFreeze : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			[Header("Custom Config")]
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float startCooldownTime;

			public float castTime;

			[ConditionalHide("cancelable", true)]
			public float canceledTime;

			public float recoveryTime;

			public float baseCooldown;

			[Header("VFX/SFX")]
			public GameObject vfxCast;

			public AudioClipData sfxCast;

			[Space(5f)]
			public GameObject loopVfx;

			public AudioClipData loopSfx;

			[Space(5f)]
			public GameObject vfxUse;

			public AudioClipData sfxUse;

			public float freezeDuration;
		}

		public class CustomWaitForInputSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public Ability ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public byte buttonUpTrigger;

			[NonSerialized]
			public InputType inputType;

			[NonSerialized]
			public CastFlags blockedCastFlags;

			[NonSerialized]
			public InputSource inputSource;

			public CustomWaitForInputSubroutine(Ability ability, byte trigger, InputType inputType, CastFlags blockedCastFlags = CastFlags.Ability1 | CastFlags.Ability2 | CastFlags.Ability3 | CastFlags.Ability4, InputSource inputSource = InputSource.Any, byte buttonUpTrigger = 0)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}

			public virtual bool IsAbleToCast(CastFlags blockedCastFlags)
			{
				return false;
			}
		}

		public class CustomCheckCanUseFreeze : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public Ability ability;

			[NonSerialized]
			public byte finished;

			[NonSerialized]
			public byte canceled;

			public CustomCheckCanUseFreeze(Ability _ability, byte _finished, byte _canceled)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomUseSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_BrainFreeze behaviour;

			public CustomUseSubroutine(AB_BrainFreeze _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		public AB_BrainFreeze(Config config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void DoUse()
		{
		}
	}
}

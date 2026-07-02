using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_UseChanneling_Base : AbilityBehaviour
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

			public float channelingTime;

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

			[Space(5f)]
			public GameObject vfxChanneling;

			public AudioClipData sfxChanneling;
		}

		public class CustomUseSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_UseChanneling_Base behaviour;

			public CustomUseSubroutine(AB_UseChanneling_Base _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		public AB_UseChanneling_Base(Config config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public virtual void DoUse()
		{
		}
	}
}

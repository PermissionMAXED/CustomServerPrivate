using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_PoisonInfuse : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			[Header("Custom Config")]
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float startCooldownTime;

			public float castTime;

			public float buffTime;

			public PassiveSO additionalPassiveToActivate;

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
		}

		public class CustomUseSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_PoisonInfuse behaviour;

			public CustomUseSubroutine(AB_PoisonInfuse _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class RemoveBuffSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_PoisonInfuse behaviour;

			public RemoveBuffSubroutine(AB_PoisonInfuse _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool buffActive;

		public AB_PoisonInfuse(Config config)
		{
		}

		public override void OnDeactivate()
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

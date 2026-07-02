using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Consumable_Base_Use : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float castTime;

			[Tooltip("Interrupts the casting if entity just got damaged")]
			public bool interuptCastOnDamage;

			[Header("VFX/SFX")]
			public GameObject castVfx;

			public AudioClipData castSfx;

			public GameObject loopVfx;

			public AudioClipData loopSfx;

			public AudioClipData sfxEnd;
		}

		public class CustomUseConsumableSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Consumable_Base_Use behaviour;

			public CustomUseConsumableSubroutine(AB_Consumable_Base_Use behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		public AB_Consumable_Base_Use(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public virtual void DoUseConsumable(EntityManager cM)
		{
		}
	}
}

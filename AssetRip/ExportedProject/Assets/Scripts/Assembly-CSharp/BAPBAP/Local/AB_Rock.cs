using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Rock : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float castTime;

			[Tooltip("Interrupts the casting if entity just got damaged")]
			public bool interuptCastOnDamage;

			[Header("Custom Config")]
			public GameObject rockPrefab;

			public float firingPointOffset;

			public int damage;

			public float speed;

			public float ttl;

			public List<StatusEffectInfo> statusEffects;

			[Header("Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorHalfScale;

			public Vector2 indicatorOffset;

			public bool indicatorDoCollision;

			public bool indicatorClampToMouse;

			[Header("VFX/SFX")]
			public GameObject vfxCastPrefab;

			public AudioClipData sfxCast;
		}

		public class CustomThrowRockSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Rock behaviour;

			public CustomThrowRockSubroutine(AB_Rock behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		public AB_Rock(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void ThrowRock(EntityManager cM)
		{
		}
	}
}

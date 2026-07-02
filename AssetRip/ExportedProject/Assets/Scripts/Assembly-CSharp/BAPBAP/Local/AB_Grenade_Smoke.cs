using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Grenade_Smoke : AbilityBehaviour
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
			public GameObject smokeSpellPrefab;

			public GameObject dmgSpellPrefab;

			[Header("Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorMouseHalfScale;

			public Vector2 indicatorBaseHalfScale;

			public Vector2 indicatorOffset;

			public float indicatorMaxDistance;

			public bool indicatorRotateWithDirection;

			[Header("Hitbox-related")]
			public float abilityRange;

			public float radius;

			public int damage;

			public float damageScaling;

			public float ttl;

			public float dmgTTL;

			public float hitboxScaleTime;

			public List<StatusEffectInfo> statusEffects;

			[Header("Misc")]
			public float interpDuration;

			public float height;

			public AnimationCurve heightCurve;

			public float zoomOutMultiplier;

			[Header("VFX/SFX")]
			public GameObject castLoopVfx;

			public AudioClipData sfxCast;

			public GameObject vfxShootPrefab;

			public AudioClipData sfxShoot;
		}

		public class CustomThrowRockSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Grenade_Smoke behaviour;

			public CustomThrowRockSubroutine(AB_Grenade_Smoke behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		public AB_Grenade_Smoke(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void Shoot(EntityManager cM, Vector3 landingPoint)
		{
		}
	}
}

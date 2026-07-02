using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Explosive_C4 : AbilityBehaviour
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
			public GameObject c4ThrowPrefab;

			public GameObject c4FollowPrefab;

			public GameObject c4BombPrefab;

			public float firingPointOffset;

			public int damage;

			public float damageScaling;

			public float speed;

			public float ttl;

			public float radius;

			public float bombDelay;

			public List<StatusEffectInfo> statusEffects;

			[Header("Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorHalfScale;

			public Vector2 indicatorOffset;

			public bool indicatorDoCollision;

			public bool indicatorClampToMouse;

			public float maxDistance;

			[Header("VFX/SFX")]
			public GameObject vfxCastPrefab;

			public AudioClipData sfxCast;
		}

		public class CustomThrowBombSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Explosive_C4 behaviour;

			public CustomThrowBombSubroutine(AB_Explosive_C4 behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBombSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Explosive_C4 behaviour;

			[NonSerialized]
			public int buffer;

			public CustomBombSubroutine(AB_Explosive_C4 behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool hit;

		[NonSerialized]
		public HitboxBase currentBomb;

		public AB_Explosive_C4(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void OnDeactivate()
		{
		}

		public void ThrowC4(Vector3 landingPoint, EntityManager cM)
		{
		}

		public void SpawnBomb(HitboxBase hboxObj)
		{
		}

		public void BlowUpBomb(Vector3 pos, int predTickNum)
		{
		}

		public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hboxObj)
		{
		}

		public override void OnHitboxDestroy(HitboxBase hitboxBase)
		{
		}
	}
}

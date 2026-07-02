using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CelesteBlockAbility : Ability
	{
		public class CustomCastSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CelesteBlockAbility ability;

			public CustomCastSubroutine(CelesteBlockAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShieldStartSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CelesteBlockAbility ability;

			public CustomShieldStartSubroutine(CelesteBlockAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShieldEndSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CelesteBlockAbility ability;

			public CustomShieldEndSubroutine(CelesteBlockAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShieldDestroyedSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CelesteBlockAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float timeElapsed;

			public CustomShieldDestroyedSubroutine(CelesteBlockAbility _ability, byte _trigger)
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

		public class CustomDestroyLoopVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public LoopVfxSubroutine loopVfx;

			public CustomDestroyLoopVfxSubroutine(LoopVfxSubroutine _loopVfx)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject hitPrefab;

		[SerializeField]
		public GameObject dpsPrefab;

		[SerializeField]
		public GameObject pillarPrefab;

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
		public float impulseVel;

		[SerializeField]
		public float impulseDecel;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageRate;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float expandDuration;

		[SerializeField]
		public float expandTargetScale;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public float obstacleActivationTime;

		[SerializeField]
		public float dpsBonusTtl;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float minShieldTime;

		[SerializeField]
		public float shieldTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float recoveryTime2;

		[SerializeField]
		public float baseCooldownTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxLoopPrefab;

		[SerializeField]
		public Transform vfxLoopAttachTransform;

		[SerializeField]
		public GameObject vfxEndPrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData castSfx;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public LoopVfxSubroutine loopVfxSubroutine;

		[NonSerialized]
		public Hitbox obstacle;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(int predTickNum)
		{
		}

		public override string GetTooltipDescription()
		{
			return null;
		}

		public override string GetTooltipExpandedDescription()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

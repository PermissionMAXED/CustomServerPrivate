using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RockySmashAbility : Ability
	{
		public class CustomCastSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RockySmashAbility ability;

			[NonSerialized]
			public byte trigger;

			public CustomCastSubroutine(RockySmashAbility _ability, byte _trigger)
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

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RockySmashAbility ability;

			public CustomShootSubroutine(RockySmashAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CooldownCheckSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RockySmashAbility ability;

			public CooldownCheckSubroutine(RockySmashAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType jumpRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float personalShieldPercentPerHit;

		[SerializeField]
		public float shieldDuration;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Effects")]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public bool reset;

		public override void PreAwake(EntityManager _charManager)
		{
		}

		public override void ResetCooldown()
		{
		}

		public void Shoot(int predTickNum)
		{
		}

		public override void OnHitboxEnd(List<EntityManager> entityHits)
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

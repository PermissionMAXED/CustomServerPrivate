using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AssassinScytheHeavyAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AssassinScytheHeavyAbility ability;

			public CustomShootSubroutine(AssassinScytheHeavyAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBonusApplySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AssassinScytheHeavyAbility ability;

			public CustomBonusApplySubroutine(AssassinScytheHeavyAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBonusResetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AssassinScytheHeavyAbility ability;

			public CustomBonusResetSubroutine(AssassinScytheHeavyAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public GameObject spellRedPrefab;

		[SerializeField]
		public Transform firingPoint;

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

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public InvisibleEscapeAbility invisibleEscapeAbility;

		[NonSerialized]
		public bool hasBonus;

		[NonSerialized]
		public int damageToHealFrom;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase)
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

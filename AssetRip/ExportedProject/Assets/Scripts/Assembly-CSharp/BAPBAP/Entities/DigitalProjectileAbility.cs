using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DigitalProjectileAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalProjectileAbility ability;

			public CustomShootSubroutine(DigitalProjectileAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCloneFireSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalProjectileAbility ability;

			public CustomCloneFireSubroutine(DigitalProjectileAbility _ability)
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
		public Transform firingPoint;

		[SerializeField]
		public float spread;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Effects")]
		public float camKickPower;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxMuzzlePrefab;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public DigitalCloneAbility digitalCloneAbility;

		[NonSerialized]
		public DigitalCloneUpgradeAbility digitalCloneUpgradeAbility;

		[NonSerialized]
		public List<DigitalProjectileCloneAbility> cloneAbilities;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void GenericAbilityTrigger1()
		{
		}

		public void CloneAttack()
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
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

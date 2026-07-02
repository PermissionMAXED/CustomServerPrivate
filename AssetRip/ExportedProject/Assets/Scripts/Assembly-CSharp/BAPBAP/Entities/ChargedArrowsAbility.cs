using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ChargedArrowsAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ChargedArrowsAbility ability;

			public CustomShootSubroutine(ChargedArrowsAbility _ability)
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
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float abilityRadius;

		[SerializeField]
		[Header("Augment Passives")]
		public P_CharAugment_MultiProjectile_SO P_TRILUNAR_BARRAGE;

		[SerializeField]
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageRate;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float hitboxActivateTime;

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
		public float camKickPower;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 landingPos, int predTickNum)
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

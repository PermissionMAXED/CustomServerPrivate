using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SpriestTetherAbility : Ability
	{
		public class CustomSnapAimSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public Ability ability;

			public CustomSnapAimSubroutine(Ability _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SpriestTetherAbility ability;

			public CustomShootSubroutine(SpriestTetherAbility _ability)
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
		public GameObject tetherPrefab;

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
		public float chargeTime;

		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public int tetherDamage;

		[SerializeField]
		public float tetherDamageScaling;

		[SerializeField]
		public float tetherDamageRate;

		[SerializeField]
		public float tetherTtl;

		[SerializeField]
		public List<StatusEffectInfo> tetherStatusEffects;

		[SerializeField]
		public float tetherWidth;

		[SerializeField]
		public float tetherRange;

		[SerializeField]
		public float tetherHeight;

		[SerializeField]
		public float attackSpeedTetherScaling;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Effects")]
		public float camKickPower;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData castSfx;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

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

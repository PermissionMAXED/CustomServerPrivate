using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class PunchSequenceAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public PunchSequenceAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomShootSubroutine(PunchSequenceAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject spellPunch1Prefab;

		[SerializeField]
		public GameObject spellPunch2Prefab;

		[SerializeField]
		public GameObject spellPunch3Prefab;

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

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage1;

		[SerializeField]
		public float damage1Scaling;

		[SerializeField]
		public float ttl1;

		[SerializeField]
		public int damage2;

		[SerializeField]
		public float damage2Scaling;

		[SerializeField]
		public float ttl2;

		[SerializeField]
		public int damage3;

		[SerializeField]
		public float damage3Scaling;

		[SerializeField]
		public float ttl3;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime1;

		[SerializeField]
		public float recoveryTime1;

		[SerializeField]
		public float cooldownTime1;

		[SerializeField]
		public float castingTime2;

		[SerializeField]
		public float recoveryTime2;

		[SerializeField]
		public float cooldownTime2;

		[SerializeField]
		public float castingTime3;

		[SerializeField]
		public float recoveryTime3;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float comboResetTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCast1Prefab;

		[SerializeField]
		public GameObject vfxCast2Prefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast1;

		[SerializeField]
		public AudioClipData sfxCast2;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public HeavyPunchAbility heavyPunchAbility;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void DoPunch(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, float ttl, int predTickNum)
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherCharManager, HitboxBase hitboxBase)
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

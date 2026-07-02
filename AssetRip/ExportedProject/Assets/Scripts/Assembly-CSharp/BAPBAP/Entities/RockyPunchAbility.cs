using System;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RockyPunchAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RockyPunchAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomShootSubroutine(RockyPunchAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPunch1Prefab;

		[SerializeField]
		public GameObject spellPunch2Prefab;

		[SerializeField]
		public GameObject spellPunchBonusPrefab;

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
		public float percentMaxHpShield;

		[SerializeField]
		public float shieldDuration;

		[SerializeField]
		[Header("Hitbox-related")]
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
		public float bonusHitboxRadius;

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
		public float baseCooldownTime;

		[SerializeField]
		public float comboResetTime;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast1;

		[SerializeField]
		public AudioClipData sfxCast2;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _charManager)
		{
		}

		public void DoPunch(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, float ttl, int predTickNum)
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase)
		{
		}

		public void AddStack()
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

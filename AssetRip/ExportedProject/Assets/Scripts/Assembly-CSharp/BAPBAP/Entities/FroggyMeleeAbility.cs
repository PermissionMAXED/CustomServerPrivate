using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class FroggyMeleeAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FroggyMeleeAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomShootSubroutine(FroggyMeleeAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spell1Prefab;

		[SerializeField]
		public GameObject spell2Prefab;

		[SerializeField]
		public GameObject spell3Prefab;

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

		[SerializeField]
		public GameObject vfxCast3Prefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast1;

		[SerializeField]
		public AudioClipData sfxCast2;

		[SerializeField]
		public AudioClipData sfxCast3;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void DoAttack(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, float ttl, bool destroyOnCharHit, int predTickNum)
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

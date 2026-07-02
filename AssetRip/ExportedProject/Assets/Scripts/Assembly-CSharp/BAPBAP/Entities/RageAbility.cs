using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RageAbility : Ability
	{
		public class CustomRageStartSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RageAbility ability;

			public CustomRageStartSubroutine(RageAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCastStartSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RageAbility ability;

			public CustomCastStartSubroutine(RageAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomRageEndSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RageAbility ability;

			public CustomRageEndSubroutine(RageAbility _ability)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public float rageSpeedIncrease;

		[SerializeField]
		public float rageDmgPercentIncrease;

		[SerializeField]
		public float rageHpRegenPercent;

		[SerializeField]
		public float rageDmgReduction;

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

		[Header("Push Hitbox")]
		[SerializeField]
		public GameObject spellPushHitbox;

		[SerializeField]
		public float pushRadius;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float rageTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[SerializeField]
		public Color rageMaterialTintColor;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxRageLoopPrefab;

		[SerializeField]
		public Transform vfxRageLoopAttachTransform;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxStart;

		[SerializeField]
		public AudioClipData sfxEnd;

		[SerializeField]
		public AudioClipData sfxRageLoopData;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public bool isRaged;

		[NonSerialized]
		public int hpRegenAmount;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot()
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

		public void ClSetRageEnabled(bool isEnabled)
		{
		}

		public override void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public override void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public override bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public override void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

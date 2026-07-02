using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AO_SkullThrow : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public bool applyAtkSpeedMultiplier;

			public bool applyCooldownMultiplier;

			public InputType inputType;

			public MotionLockType motionLockType;

			public float equipTime;

			public float castTime;

			public float recoveryTime;

			public float cooldownTime;

			public float inputBufferDuration;

			public CommandId targetAbility;

			[Header("Anim/FX Config")]
			public GameObject harpoonViewPrefab;

			public AudioClipData equipStartSfx;

			public AudioClipData equipEndSfx;

			public float equipEndSfxDelay;

			public string gunShootState;

			public string gunReloadStartState;

			[Header("UI Config")]
			public string titleTranslationKey;

			public string descTranslationKey;

			public Color iconColor;

			public Color titleColor;

			[Header("Hitbox Config")]
			public GameObject rockPrefab;

			public GameObject explosionSpellPrefab;

			public float firingPointOffset;

			public int damage;

			public float damageScaling;

			public bool doCrits;

			public float speed;

			public float ttl;

			public float explosionTtl;

			public float explosionRadius;

			public List<StatusEffectInfo> statusEffects;
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_SkullThrow passive;

			public CustomShootSubroutine(P_AO_SkullThrow _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CallGenericAbilityTrigger1 : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_SkullThrow passive;

			public CallGenericAbilityTrigger1(P_AO_SkullThrow _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomEquipSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_SkullThrow passive;

			public CustomEquipSubroutine(P_AO_SkullThrow _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomRemovePistolSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_AO_SkullThrow passive;

			public CustomRemovePistolSubroutine(P_AO_SkullThrow _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public byte TRIGGER_FORCERELOAD;

		[NonSerialized]
		public Ability targetAbility;

		[NonSerialized]
		public float targetAbilityOriginalInputBufferDuration;

		[NonSerialized]
		public Transform harpoonHolderTransform;

		[NonSerialized]
		public PistolModelHolder harpoon;

		[NonSerialized]
		public PistolModelHolder dualPistol;

		[NonSerialized]
		public int harpoonShootStateHash;

		[NonSerialized]
		public int harpoonReloadStartStateHash;

		[NonSerialized]
		public string titleStr;

		[NonSerialized]
		public string descStr;

		[NonSerialized]
		public bool inactive;

		[NonSerialized]
		public CooldownSubroutine cooldownSubroutine;

		[NonSerialized]
		public int state;

		public override PassiveConfiguration passiveConfig => null;

		public P_AO_SkullThrow(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void Shoot(EntityManager cM, int predTickNum)
		{
		}

		public override void ClCustomEvent0()
		{
		}

		public override void ClCustomEvent1()
		{
		}

		public void ClOnShoot()
		{
		}

		public void ClOnEquip()
		{
		}

		public void ClShootHarpoon(PistolModelHolder pistol)
		{
		}

		public void ClEquipHarpoon(PistolModelHolder pistol)
		{
		}

		public PistolModelHolder ClSpawnHarpoonModel()
		{
			return null;
		}

		public void ClDespawnHarpoonModel(PistolModelHolder harpoon)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}

		public override void ClStartAuth()
		{
		}

		public override void ClStopAuth()
		{
		}
	}
}

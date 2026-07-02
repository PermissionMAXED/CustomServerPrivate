using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class KatanaMeleeAbility : Ability
	{
		public class CustomVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public KatanaMeleeAbility ability;

			[NonSerialized]
			public VfxTarget vfxTarget;

			[NonSerialized]
			public VfxEventAction vfxAction;

			[NonSerialized]
			public int vfxId;

			[NonSerialized]
			public int vfxFireId;

			[NonSerialized]
			public uint netId;

			[NonSerialized]
			public Vector3 position;

			[NonSerialized]
			public Quaternion rotation;

			[NonSerialized]
			public byte attachableId;

			public CustomVfxSubroutine(KatanaMeleeAbility ability, VfxEventAction vfxAction, VfxTarget vfxTarget, GameObject vfxPrefab, GameObject vfxFirePrefab, Vector3 position, Quaternion rotation, byte attachableId = 0)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

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

		public class CustomCheckBonusSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public KatanaMeleeAbility ability;

			[NonSerialized]
			public byte trigger;

			public CustomCheckBonusSubroutine(KatanaMeleeAbility _ability, byte _trigger)
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

		public class CustomRemoveBonusSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public KatanaMeleeAbility ability;

			public CustomRemoveBonusSubroutine(KatanaMeleeAbility _ability)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomAttackSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public KatanaMeleeAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomAttackSubroutine(KatanaMeleeAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject spellAttack1Prefab;

		[SerializeField]
		public GameObject spellAttack2Prefab;

		[SerializeField]
		public GameObject spellAttack3Prefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType rotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float extendedInputBufferDuration;

		[Header("Hitbox-related")]
		[SerializeField]
		public float ttl;

		[SerializeField]
		public int damage1;

		[SerializeField]
		public float damage1Scaling;

		[SerializeField]
		public int damage2;

		[SerializeField]
		public float damage2Scaling;

		[SerializeField]
		public int damage3;

		[SerializeField]
		public float damage3Scaling;

		[SerializeField]
		public List<StatusEffectInfo> bonusHitStatusEffects;

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
		public float comboCooldownTime;

		[SerializeField]
		public float comboResetTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCast1Prefab;

		[SerializeField]
		public GameObject vfxCast2Prefab;

		[SerializeField]
		public GameObject vfxCast3Prefab;

		[SerializeField]
		public GameObject vfxCast3FirePrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast1;

		[SerializeField]
		public AudioClipData sfxCast2;

		[SerializeField]
		public AudioClipData sfxCast3;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public FireyEmpoweredDashAbility dashAbility;

		[NonSerialized]
		public FireyChargedProjectileAbility projectileAbility;

		[NonSerialized]
		public bool bonusEnabled;

		[NonSerialized]
		public float baseInputBufferDuration;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void DoAttack(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, int attackId, int predTickNum)
		{
		}

		public void PrepareChargedAttack()
		{
		}

		public void SetExtendedInputBufferTime()
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherCharManager, HitboxBase hitboxBase)
		{
		}

		public void SetInputBufferTime(float b)
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

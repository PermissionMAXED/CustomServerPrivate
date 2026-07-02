using System;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AssassinMeleeAbility : Ability
	{
		public class CustomVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AssassinMeleeAbility ability;

			[NonSerialized]
			public VfxTarget vfxTarget;

			[NonSerialized]
			public VfxEventAction vfxAction;

			[NonSerialized]
			public int vfxIdNormal;

			[NonSerialized]
			public int vfxIdRed;

			[NonSerialized]
			public uint netId;

			[NonSerialized]
			public Vector3 position;

			[NonSerialized]
			public Quaternion rotation;

			[NonSerialized]
			public byte attachableId;

			[NonSerialized]
			public float rotateDelay;

			[NonSerialized]
			public bool applyAtkSpeedMultiplier;

			public CustomVfxSubroutine(AssassinMeleeAbility ability, VfxEventAction vfxAction, VfxTarget vfxTarget, GameObject vfxPrefabNormal, GameObject vfxPrefabRed, Vector3 position, Quaternion rotation, byte attachableId = 0, float rotateDelay = 0f, bool applyAtkSpeedMultiplier = false)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public float GetAdjustedCastingTime()
			{
				return 0f;
			}
		}

		public class CustomAttackSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AssassinMeleeAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomAttackSubroutine(AssassinMeleeAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBonusApplySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AssassinMeleeAbility ability;

			public CustomBonusApplySubroutine(AssassinMeleeAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBonusResetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AssassinMeleeAbility ability;

			public CustomBonusResetSubroutine(AssassinMeleeAbility _ability)
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
		public int BaseInvisibleBonusDamage;

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
		public float comboCooldownTime;

		[SerializeField]
		public float comboResetTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCast1Prefab;

		[SerializeField]
		public GameObject vfxCast2Prefab;

		[SerializeField]
		public GameObject vfxCast1RedPrefab;

		[SerializeField]
		public GameObject vfxCast2RedPrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxCast1;

		[SerializeField]
		public AudioClipData sfxCast2;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public InvisibleEscapeAbility invisibleEscapeAbility;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void DoAttack(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, int predTickNum)
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

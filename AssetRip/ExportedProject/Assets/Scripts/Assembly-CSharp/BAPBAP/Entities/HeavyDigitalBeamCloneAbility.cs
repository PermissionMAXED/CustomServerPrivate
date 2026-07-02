using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HeavyDigitalBeamCloneAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public HeavyDigitalBeamCloneAbility ability;

			public CustomShootSubroutine(HeavyDigitalBeamCloneAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSetCharTimerDestroyEnabledSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public HeavyDigitalBeamCloneAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomSetCharTimerDestroyEnabledSubroutine(HeavyDigitalBeamCloneAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public CharDestroyTimer charDestroyTimer;

		[NonSerialized]
		public EntityManager primaryCharManager;

		[NonSerialized]
		public EntityManager primaryTv;

		[NonSerialized]
		public byte EXTERNAL_TRIGGER_CAST;

		[NonSerialized]
		public byte EXTERNAL_TRIGGER_SILENCED;

		[NonSerialized]
		public byte EXTERNAL_TRIGGER_AIM;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void Start()
		{
		}

		public void Destroy()
		{
		}

		public void DoAttack()
		{
		}

		public void DoSilenced()
		{
		}

		public void DoAim()
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

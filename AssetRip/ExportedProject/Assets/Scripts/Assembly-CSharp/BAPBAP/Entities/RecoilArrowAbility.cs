using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RecoilArrowAbility : Ability
	{
		public class CustomJumpSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RecoilArrowAbility ability;

			public CustomJumpSubroutine(RecoilArrowAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RecoilArrowAbility ability;

			public CustomShootSubroutine(RecoilArrowAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomFloatSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public RecoilArrowAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public byte invisTrigger;

			[NonSerialized]
			public float jumpTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 landingPos;

			public CustomFloatSubroutine(RecoilArrowAbility _ability, byte _trigger, byte _invisTrigger, float _jumpTime)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
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
		}

		public class CustomInvisibilitySubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public RecoilArrowAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public byte silencedTrigger;

			[NonSerialized]
			public float invisTime;

			[NonSerialized]
			public float timeElapsed;

			public CustomInvisibilitySubroutine(RecoilArrowAbility _ability, byte _trigger, byte _silencedTrigger, float _invisTime)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
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

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType jumpRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("Augment Passives")]
		public PassiveSO P_KITSU_REPEL;

		[SerializeField]
		public P_Empty_SO P_KITSU_VANISH;

		[SerializeField]
		[Header("Vanish Augment")]
		public float invisTime;

		[SerializeField]
		public float speedPercentIncrease;

		[SerializeField]
		[Header("Repel Augment")]
		public float minFloatDistanceMult;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float floatTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Misc")]
		[SerializeField]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public AnimationCurve baseShadowAlphaCurve;

		[SerializeField]
		public float jumpDistance;

		[SerializeField]
		public float jumpRadiusCheck;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxJumpPrefab;

		[SerializeField]
		public GameObject vfxLandPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public Vector3 targetDir;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
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

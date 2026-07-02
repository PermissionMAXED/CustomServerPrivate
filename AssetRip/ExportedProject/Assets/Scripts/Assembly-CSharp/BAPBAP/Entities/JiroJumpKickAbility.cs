using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Network.EventData;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class JiroJumpKickAbility : Ability
	{
		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public JiroJumpKickAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 jumpPoint;

			public CustomJumpSubroutine(JiroJumpKickAbility _ability, byte _trigger, float _waitTime)
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

		public class CustomVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public JiroJumpKickAbility ability;

			[NonSerialized]
			public VfxTarget vfxTarget;

			[NonSerialized]
			public VfxEventAction vfxAction;

			[NonSerialized]
			public int vfxId;

			[NonSerialized]
			public uint netId;

			[NonSerialized]
			public Vector3 position;

			[NonSerialized]
			public Quaternion rotation;

			[NonSerialized]
			public byte attachableId;

			public CustomVfxSubroutine(JiroJumpKickAbility ability, VfxEventAction vfxAction, VfxTarget vfxTarget, int vfxId, Vector3 position, Quaternion rotation, byte attachableId = 0)
			{
			}

			public CustomVfxSubroutine(JiroJumpKickAbility ability, VfxEventAction vfxAction, VfxTarget vfxTarget, GameObject vfxPrefab, Vector3 position, Quaternion rotation, byte attachableId = 0)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject kickPrefab;

		[SerializeField]
		public MotionLockType kickMotionLock;

		[SerializeField]
		public RotationLockType kickRotationLock;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public Transform kickFiringPoint;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorKickPrefab;

		[SerializeField]
		public Vector2 indicatorKickMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorKickBaseHalfScale;

		[SerializeField]
		public Vector2 indicatorKickOffset;

		[SerializeField]
		public float indicatorKickMaxDistance;

		[SerializeField]
		public bool indicatorKickRotateWithDirection;

		[SerializeField]
		public float hitboxKickConeAngleHalf;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float kickTtl;

		[SerializeField]
		public float kickRadius;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float kickCastingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Misc")]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public AnimationCurve baseShadowAlphaCurve;

		[SerializeField]
		public float jumpRadiusCheck;

		[SerializeField]
		public float maxJumpDistance;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxJumpKickCastPrefab;

		[SerializeField]
		public GameObject vfxJumpKickLoopPrefab;

		[SerializeField]
		public GameObject vfxJumpKickLandPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxJumpKickCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void ShootKick(Vector3 lookDir, int predTickNum)
		{
		}

		public void HitSuccess()
		{
		}

		public void StopRecastEffect()
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

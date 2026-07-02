using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TongueJumpAbility : Ability
	{
		public class CustomActivateTongueSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public TongueJumpAbility ability;

			[NonSerialized]
			public float timeElapsed;

			public CustomActivateTongueSubroutine(TongueJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
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

		public class CustomDeactivateTongueSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public TongueJumpAbility ability;

			public CustomDeactivateTongueSubroutine(TongueJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public TongueJumpAbility ability;

			public CustomShootSubroutine(TongueJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public TongueJumpAbility ability;

			[NonSerialized]
			public byte finishTrigger;

			[NonSerialized]
			public float jumpTime;

			[NonSerialized]
			public float entityOffsetAmount;

			[NonSerialized]
			public LayerMask obstacleMask;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomJumpSubroutine(TongueJumpAbility _ability, byte _finishTrigger, float _jumpTime)
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

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public MotionLockType jumpMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("Hitbox-related")]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float throwTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[SerializeField]
		[Header("Misc")]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public float maxThrowDistance;

		[SerializeField]
		public float jumpRadiusCheck;

		[Header("Effects")]
		[SerializeField]
		public float camKickPower;

		[SerializeField]
		public FroggyTonguePosition tonguePosition;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public byte EXTERNAL_TRIGGER_HIT;

		[NonSerialized]
		public byte EXTERNAL_TRIGGER_NO_HIT;

		[NonSerialized]
		public EntityManager hitEntity;

		[NonSerialized]
		[NonSerialized]
		public bool tongueIsActive;

		[NonSerialized]
		public uint hitEntityNetId;

		[NonSerialized]
		public Vector2 hitPosition;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void OnTongueHitChar(EntityManager entity, uint netId)
		{
		}

		public void OnTongueHitWall(Vector2 pos)
		{
		}

		public void OnTongueHitNothing()
		{
		}

		public void OnTongueIsActiveChanged()
		{
		}

		public void OnHitNetIdChanged()
		{
		}

		public void Shoot(Vector3 lookDir)
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

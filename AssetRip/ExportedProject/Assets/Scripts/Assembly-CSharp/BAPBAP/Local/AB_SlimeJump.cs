using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Entities;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_SlimeJump : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float startCooldownTime;

			public float castTime;

			public float jumpDuration;

			public float canceledTime;

			public float baseCooldown;

			public float recoveryTime;

			public bool lockCastAim;

			[Header("Jump Config")]
			public float maxDistance;

			public bool pointWallCollision;

			public bool pointNavMeshClamp;

			public float pointNavRadiusAmount;

			public AnimationCurve jumpLerpCurve;

			[Header("Mouse Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorMouseHalfScale;

			public Vector2 indicatorBaseHalfScale;

			public Vector2 indicatorOffset;

			public bool indicatorRotateWithDirection;

			[Header("Visible Indicator")]
			public bool spawnVisibleIndicator;

			[ConditionalHide("spawnVisibleIndicator", true)]
			public GameObject visibleIndicatorPrefab;

			[Header("VFX/SFX")]
			public GameObject slimeBossSwapPrefab;

			public float slimeBossSwapAnimStartTime;

			public float slimeBossSwapAnimSpeed;

			public GameObject vfxCastPrefab;

			public AudioClipData jumpSfx;

			public AudioClipData sfxCast;

			public AudioClipData landVoSfx;

			[Header("Custom Config")]
			public GameObject landingHitboxPrefab;

			public int damage;

			public float damageScaling;

			public float ttl;

			public float hitboxRadius;

			public List<StatusEffectInfo> statusEffects;
		}

		public class CustomLockCastAimSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_SlimeJump behaviour;

			[NonSerialized]
			public RaycastHit hit;

			[NonSerialized]
			public LayerMask obstacleMask;

			public CustomLockCastAimSubroutine(AB_SlimeJump _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSlimeBossSwapSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_SlimeJump behaviour;

			[NonSerialized]
			public bool doEnable;

			public CustomSlimeBossSwapSubroutine(AB_SlimeJump _behaviour, bool _doEnable)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_SlimeJump behaviour;

			[NonSerialized]
			public bool spawn;

			public CustomVisibleIndicatorSubroutine(AB_SlimeJump _behaviour, bool _spawn)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_SlimeJump behaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public RaycastHit hit;

			[NonSerialized]
			public LayerMask obstacleMask;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 landingPosition;

			public CustomJumpSubroutine(AB_SlimeJump _behaviour, byte _trigger)
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

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public Vector3 lockCastAimPos;

		[NonSerialized]
		public GameObject currentIndicator;

		[NonSerialized]
		public GameObject currentBossMeshSwap;

		[NonSerialized]
		public bool slimeBossSwapEnabled;

		public AB_SlimeJump(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void OnDeactivate()
		{
		}

		public override void ClSpawnVisibleIndicator(Vector3 position)
		{
		}

		public override void ClDestroyVisibleIndicator()
		{
		}

		public void SetSlimeBossSwapState(bool isEnabled)
		{
		}

		public void SpawnLandingHitbox(Vector3 landingPoint, int predTickNum)
		{
		}

		public void OnSwapEnabledChanged()
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
}

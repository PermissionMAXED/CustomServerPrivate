using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Maps;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_BloodDive : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public CommandId targetAbility;

			public InputType inputType;

			public float startCooldownTime;

			public float castTime;

			public float jump1Duration;

			public float jump2Duration;

			public float jumpHeightMultiplier;

			public float initialDiveMeter;

			public float minDiveDuration;

			public float maxDiveMeter;

			public float minJumpDiveMeter;

			public float diveMeterDrainRate;

			public float diveMeterJumpDrain;

			public float diveMeterPoolDrain;

			public float bloodOrbDiveMeter;

			public float bloodOrbDiveMeterDelay;

			public bool ignoreJumpTime;

			public int maxRecasts;

			public float recoveryTime;

			public float baseCooldown;

			[Header("Aim Config")]
			public float maxDistance;

			public bool clampOnLineOfSight;

			public bool pointNavMeshClamp;

			[ConditionalHide("pointNavMeshClamp", true)]
			public float pointNavRadiusAmount;

			[Header("Mouse Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorMouseHalfScale;

			public Vector2 indicatorBaseHalfScale;

			public Vector2 indicatorOffset;

			public bool indicatorRotateWithDirection;

			[Header("VFX/SFX")]
			public GameObject vfxCast;

			public GameObject vfxJumpLoop;

			public GameObject vfxLand;

			public GameObject vfxGroundLoop;

			public AudioClipData sfxCast;

			public AudioClipData loopDiveSfx;

			public GameObject vfxExit;

			public AudioClipData sfxExit;

			[Header("UI Config")]
			public string titleTranslationKey;

			public string descTranslationKey;

			public Color iconColor;

			public Color titleColor;

			[Header("SWAP")]
			public GameObject swapPrefab;

			public float swapBackAnimStartTime;

			public float swapBackAnimSpeed;

			public float jump1AnimStartTime;

			public float jump1AnimSpeed;

			public float jump2AnimStartTime;

			public float jump2AnimSpeed;

			public AnimationCurve jumpLerpCurve;

			public AnimationCurve firstJumpZoomCurve;

			public AnimationCurve secondJumpZoomCurve;

			public float zoomInMultiplier;

			[Header("Hit Triggers")]
			public PrefabConfig bloodOrbPrefabConfig;

			[Space(5f)]
			[Header("Dive Config")]
			public UIProgressBarElement uiProgressPrefab;

			public GameObject bloodPoolJump1;

			public GameObject bloodPoolJump2;

			public bool puddleDoTtl;

			public float puddleTtl;

			public List<StatusEffectInfo> statusEffects;

			public float speedAmount;

			public float maxDistanceFromNavmesh;

			[Header("Camera Settings")]
			public bool vehicleCam;

			[ConditionalHide("vehicleCam", true)]
			public bool vehicleCamCustomPreset;

			[ConditionalHide("vehicleCamCustomPreset", true)]
			public CameraVehicle.DriverVehiclePreset vehicleCamPreset;
		}

		public class MeterSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_BloodDive behaviour;

			[NonSerialized]
			public byte trigger;

			public MeterSubroutine(P_BloodDive ability, byte trigger)
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

		public class CustomLoopVfxSubroutine : LoopVfxSubroutine
		{
			public CustomLoopVfxSubroutine(Ability ability, GameObject loopVfxPrefab)
				: base((Ability)null, (GameObject)null, (Transform)null)
			{
			}
		}

		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_BloodDive behaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float duration;

			[NonSerialized]
			public int jumpId;

			[NonSerialized]
			public float currentZoom;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			public CustomJumpSubroutine(P_BloodDive _behaviour, byte _trigger, float _duration, int _id)
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

		public class CustomWaitRecastSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_BloodDive behaviour;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public byte triggerCanceled;

			[NonSerialized]
			public float minTime;

			[NonSerialized]
			public bool frameDelay;

			public CustomWaitRecastSubroutine(P_BloodDive _behaviour, byte _trigger, byte _canceled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomCheckRecastSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_BloodDive behaviour;

			[NonSerialized]
			public byte triggerRecast;

			[NonSerialized]
			public byte triggerDive;

			public CustomCheckRecastSubroutine(P_BloodDive _behaviour, byte _triggerRecast, byte _triggerDive)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomDiveSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_BloodDive behaviour;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float minTime;

			[NonSerialized]
			public bool frameDelay;

			public CustomDiveSubroutine(P_BloodDive _behaviour, byte _trigger)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomSetSwapStateSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_BloodDive behaviour;

			[NonSerialized]
			public int state;

			public CustomSetSwapStateSubroutine(P_BloodDive _behaviour, int _state)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomExitSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_BloodDive behaviour;

			[NonSerialized]
			public bool jumpCasted;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public bool firstFrame;

			public CustomExitSubroutine(P_BloodDive behaviour, byte trigger, bool jumpCasted)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public Ability targetAbility;

		[NonSerialized]
		public bool inactive;

		[NonSerialized]
		public float maxDistanceFromNavmeshSqr;

		[NonSerialized]
		public GameObject currentMeshSwap;

		[NonSerialized]
		public UIProgressBarElement currentHpProgress;

		[NonSerialized]
		public LoopVfxSubroutine loopJumpVfxSubroutine;

		[NonSerialized]
		public LoopVfxSubroutine loopGroundVfxSubroutine;

		[NonSerialized]
		public int swapState;

		[NonSerialized]
		public int recastsCounter;

		[NonSerialized]
		public float diveMeterRemaining;

		public float timer;

		public override PassiveConfiguration passiveConfig => null;

		public P_BloodDive(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ClTick(float fixedDt, Command cmd, bool isResim)
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

		public void DoUse(Vector3 spawnPos)
		{
		}

		public void ClampPositionToMaxNavAllowed()
		{
		}

		public bool GetClampedMaxNavPosition(Vector3 sourcePos, out Vector3 clampedPos)
		{
			clampedPos = default(Vector3);
			return false;
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void OnDealtDamageInteractableTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public override void OnDealtDamageTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public void ClUsingElapsedTimeChanged(float diveMeterRemaining)
		{
		}

		public void ClSetSwapState(int oldSwapState, int swapState)
		{
		}

		public void OnSwapEnabledChanged(int oldValue, int newValue)
		{
		}

		public void OnDiveMeterChanged(float oldValue, float newValue)
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

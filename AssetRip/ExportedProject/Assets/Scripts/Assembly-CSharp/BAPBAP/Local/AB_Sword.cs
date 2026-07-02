using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Entities;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Sword : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType jumpRotationLockType;

			public float minCastingTime;

			public float maxCastingTime;

			public float maxDistanceChargeTime;

			public float teleportDuration;

			public float teleportEndDuration;

			public float canceledTime;

			public float recoveryTime;

			public bool lockCastAim;

			public float maxRange;

			public AnimationCurve jumpLerpCurve;

			[Header("Custom Config")]
			public GameObject dashPrefab;

			public int damage;

			public float damageScaling;

			public float ttl;

			public List<StatusEffectInfo> statusEffects;

			[Header("Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorHalfScale;

			public Vector2 indicatorOffset;

			public float indicatorMaxDistance;

			public bool indicatorDoCollision;

			public bool indicatorClampToMouse;

			[Header("Visible Indicator")]
			public bool spawnVisibleIndicator;

			[ConditionalHide("spawnVisibleIndicator", true)]
			public GameObject visibleIndicatorPrefab;

			[Header("VFX/SFX")]
			public GameObject vfxLerpEndPrefab;

			public GameObject swapPrefab;

			public float swapAnimStartTime;

			public float swapAnimSpeed;

			public GameObject vfxCastPrefab;

			public AudioClipData castSfx;

			public AudioClipData jumpStartSfx;

			public AudioClipData jumpEndSfx;
		}

		public class CustomConsumeSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behaviour;

			public CustomConsumeSubroutine(AB_Sword _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDirectionalIndicatorSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behav;

			[NonSerialized]
			public IndicatorDirectional indDirectional;

			[NonSerialized]
			public bool indicatorActive;

			public CustomDirectionalIndicatorSubroutine(AB_Sword behav, GameObject indicatorPrefab, Vector2 halfScale, Vector2 offset, bool doCollision, bool isExpanding, bool clampToMouse, bool followMouse)
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

			public void OnIndicatorChanged()
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

		public class CustomChargeSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behav;

			[NonSerialized]
			public byte finishTrigger;

			[NonSerialized]
			public bool inputUp;

			[NonSerialized]
			public float timeElapsed;

			public CustomChargeSubroutine(AB_Sword behav, byte finishTrigger)
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

		public class CustomBaseballSwapSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behaviour;

			[NonSerialized]
			public bool doEnable;

			public CustomBaseballSwapSubroutine(AB_Sword _behaviour, bool _doEnable)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomLookAtTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behaviour;

			public CustomLookAtTargetSubroutine(AB_Sword _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSwapSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behaviour;

			[NonSerialized]
			public bool doEnable;

			public CustomSwapSubroutine(AB_Sword _behaviour, bool _doEnable)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomTeleportLerpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behav;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public LayerMask obstacleMask;

			[NonSerialized]
			public float endDur;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomTeleportLerpSubroutine(AB_Sword _behav, byte _trigger, float _waitTime)
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

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Sword behaviour;

			public CustomShootSubroutine(AB_Sword _behaviour)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public GameObject currentIndicator;

		[NonSerialized]
		public GameObject currentBossMeshSwap;

		[NonSerialized]
		public bool swapEnabled;

		[NonSerialized]
		public float chargeFactor;

		[NonSerialized]
		public float distanceChargeFactor;

		[NonSerialized]
		public float teleportDistance;

		[NonSerialized]
		public RecoverySubroutine recovRoutine;

		public AB_Sword(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void OnDeactivate()
		{
		}

		public void SetSwapState(bool isEnabled)
		{
		}

		public void Shoot(Vector3 lookDir, Vector3 targetPos, int predTickNum, float teleportDistance)
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

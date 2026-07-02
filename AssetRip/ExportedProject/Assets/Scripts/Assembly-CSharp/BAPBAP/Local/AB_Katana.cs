using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Entities;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Katana : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float castTime;

			public float dashDuration;

			public float canceledTime;

			public float recoveryTime;

			public bool lockCastAim;

			[Header("Dash Config")]
			public float maxRange;

			public float impulseSpeed;

			public float impulseDeceleration;

			[Header("Custom Config")]
			public GameObject dashPrefab;

			public int damage;

			public float damageScaling;

			public float ttl;

			public float hitboxRadius;

			public List<StatusEffectInfo> statusEffects;

			[Header("Indicator")]
			public GameObject indicatorPrefab;

			public Vector2 indicatorHalfScale;

			public Vector2 indicatorOffset;

			public bool indicatorDoCollision;

			[Header("Visible Indicator")]
			public bool spawnVisibleIndicator;

			[ConditionalHide("spawnVisibleIndicator", true)]
			public GameObject visibleIndicatorPrefab;

			[Header("VFX/SFX")]
			public GameObject swapPrefab;

			public float swapAnimStartTime;

			public float swapAnimSpeed;

			public GameObject vfxCastPrefab;

			public AudioClipData jumpSfx;

			public AudioClipData jumpVoSfx;

			public AudioClipData jumpEndSfx;
		}

		public class CustomConsumeSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Katana behaviour;

			public CustomConsumeSubroutine(AB_Katana _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBaseballSwapSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Katana behaviour;

			[NonSerialized]
			public bool doEnable;

			public CustomBaseballSwapSubroutine(AB_Katana _behaviour, bool _doEnable)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomLookAtTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Katana behaviour;

			public CustomLookAtTargetSubroutine(AB_Katana _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Katana behaviour;

			[NonSerialized]
			public bool spawn;

			public CustomVisibleIndicatorSubroutine(AB_Katana _behaviour, bool _spawn)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSwapSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Katana behaviour;

			[NonSerialized]
			public bool doEnable;

			public CustomSwapSubroutine(AB_Katana _behaviour, bool _doEnable)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDashSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Katana behaviour;

			[NonSerialized]
			public byte finishTrigger;

			[NonSerialized]
			public float timeElapsed;

			public CustomDashSubroutine(AB_Katana behaviour, byte finishTrigger)
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
		public GameObject currentIndicator;

		[NonSerialized]
		public GameObject currentBossMeshSwap;

		[NonSerialized]
		public bool swapEnabled;

		public AB_Katana(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void OnDeactivate()
		{
		}

		public override void ClSpawnVisibleIndicator(Vector3 targetDir)
		{
		}

		public override void ClDestroyVisibleIndicator()
		{
		}

		public void SetSwapState(bool isEnabled)
		{
		}

		public void SpawnHitbox(Vector3 lookDir, int predTickNum)
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

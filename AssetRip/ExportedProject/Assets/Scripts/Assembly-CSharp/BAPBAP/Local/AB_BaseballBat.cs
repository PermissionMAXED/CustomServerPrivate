using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Entities;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_BaseballBat : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float castTime;

			public float hitboxTtl;

			public float canceledTime;

			public float baseCooldown;

			public float recoveryTime;

			[Header("Hitbox")]
			public GameObject hitbox;

			public float firingPointOffset;

			public float ttl;

			public int damage;

			public float damageScaling;

			public List<StatusEffectInfo> statusEffects;

			public float hitboxRadius;

			[Header("Indicator")]
			public GameObject visibleIndicatorPrefab;

			public GameObject visibleIndicatorEnemyPrefab;

			public float visibleRadius;

			public float halfAngle;

			[Header("VFX/SFX")]
			public GameObject batSwapPrefab;

			public float batSwapAnimStartTime;

			public float batSwapAnimSpeed;

			public GameObject vfxCastPrefab;

			public AudioClipData sfxCast;
		}

		public class CustomConsumeSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_BaseballBat behaviour;

			public CustomConsumeSubroutine(AB_BaseballBat _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomBaseballSwapSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_BaseballBat behaviour;

			[NonSerialized]
			public bool doEnable;

			public CustomBaseballSwapSubroutine(AB_BaseballBat _behaviour, bool _doEnable)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_BaseballBat behaviour;

			[NonSerialized]
			public byte trigger;

			public CustomShootSubroutine(AB_BaseballBat _behaviour, byte _trigger)
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

		public class CustomVisibleIndicatorSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_BaseballBat behaviour;

			[NonSerialized]
			public bool spawn;

			public CustomVisibleIndicatorSubroutine(AB_BaseballBat _behaviour, bool _spawn)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
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
		public bool batSwapEnabled;

		public AB_BaseballBat(Config _config)
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

		public void SetBatSwapState(bool isEnabled)
		{
		}

		public void SpawnHitbox(int predTickNum)
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

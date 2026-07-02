using System;
using BAPBAP.Entities;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_FoolsGold : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float castTime;

			public float canceledTime;

			public float baseCooldown;

			public float recoveryTime;

			[Header("VFX/SFX")]
			public GameObject vfxCastPrefab;

			public AudioClipData sfxCast;
		}

		public class CustomConsumeSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_FoolsGold behaviour;

			public CustomConsumeSubroutine(AB_FoolsGold _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomEndSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_FoolsGold behaviour;

			[NonSerialized]
			public byte trigger;

			public CustomEndSubroutine(AB_FoolsGold behaviour, byte trigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomTransformSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_FoolsGold behaviour;

			[NonSerialized]
			public byte trigger;

			public CustomTransformSubroutine(AB_FoolsGold _behaviour, byte _trigger)
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
		public bool active;

		[NonSerialized]
		public int lastSelectedModel;

		public AB_FoolsGold(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void OnDeactivate()
		{
		}

		public override bool OnStopItemRemove()
		{
			return false;
		}

		public void DoTransform()
		{
		}

		public void Deactivate()
		{
		}
	}
}

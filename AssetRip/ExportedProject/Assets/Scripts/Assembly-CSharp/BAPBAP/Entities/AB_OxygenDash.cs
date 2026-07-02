using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_OxygenDash : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float castingTime;

			public float maxVelocity;

			public float timeToMaxSpeed;

			public AnimationCurve speedCurve;

			public float baseCooldown;

			public float dashImpulse;

			public float impulseDecelSpeed;

			public float dashSpeedStart;

			public float dashSpeedEnd;

			public float dashDecel;

			[Header("Oxygen Cost")]
			public float impulseCost;

			public float driveCost;

			[Header("VFX/SFX")]
			public GameObject vfxCastPrefab;

			public AudioClipData sfxCast;
		}

		public class CustomWaitForInputSubroutine : WaitForInputOverrideSubroutine
		{
			[NonSerialized]
			public AB_OxygenDash behaviour;

			[NonSerialized]
			public int oxygenId;

			public CustomWaitForInputSubroutine(AB_OxygenDash _behaviour, byte trigger, InputType inputType, CastFlags blockedCastFlags = CastFlags.Ability1 | CastFlags.Ability2 | CastFlags.Ability3 | CastFlags.Ability4, InputSource inputSource = InputSource.Any, byte buttonUpTrigger = 0)
				: base(null, 0, default(InputType), default(CastFlags), default(InputSource), 0, checkForSilenced: false)
			{
			}

			public override bool IsAbleToCast(CastFlags blockedCastFlags)
			{
				return false;
			}
		}

		public class CustomDashSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_OxygenDash behaviour;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public Vector3 currentImpulse;

			[NonSerialized]
			public Vector3 originalImpulseDir;

			[NonSerialized]
			public int oxygenId;

			[NonSerialized]
			public float timeElapsed;

			public CustomDashSubroutine(AB_OxygenDash behaviour, byte trigger)
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

		[NonSerialized]
		public Config config;

		public AB_OxygenDash(Config config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}
	}
}

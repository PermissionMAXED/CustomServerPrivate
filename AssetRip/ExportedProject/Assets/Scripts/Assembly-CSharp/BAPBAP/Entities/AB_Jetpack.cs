using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Jetpack : AbilityBehaviour
	{
		[Serializable]
		public class Config : AB_Consumable_Base_Use.Config
		{
			[Header("Config")]
			public float usingDuration;

			public float unequipDuration;

			public float landDuration;

			public MotionLockType landedMotionLockType;

			public float landingProjectedVelocityMult;

			public float maxDistanceFromNavmesh;

			[Header("Visuals Config")]
			public GameObject jetpackPrefab;

			public float camZoomOutMultiplier;

			[Tooltip("The character height amount in world units")]
			public float yHeightAmount;

			[Tooltip("Duration of the character height raising when starting to fly")]
			public float startHeightDuration;

			public AnimationCurve heightLerpCurve;

			[Header("Sfx Config")]
			public AudioClipData startSfx;

			public AudioClipData preEndSfx;

			public AudioClipData endSfx;
		}

		public class CustomUsingSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Jetpack behaviour;

			[NonSerialized]
			public float timeElapsed;

			public CustomUsingSubroutine(AB_Jetpack behaviour)
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

		public class CustomWaitForInputSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public Ability ability;

			[NonSerialized]
			public byte shootTrigger;

			[NonSerialized]
			public byte cancelTrigger;

			[NonSerialized]
			public CastFlags cancelCastFlags;

			public CustomWaitForInputSubroutine(Ability ability, byte shootTrigger, byte cancelTrigger, CastFlags cancelCastFlags)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomLandingSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Jetpack behaviour;

			[NonSerialized]
			public float duration;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float timeElapsed;

			public CustomLandingSubroutine(AB_Jetpack behaviour, byte trigger, float duration)
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

		public class CustomLandSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Jetpack behaviour;

			public CustomLandSubroutine(AB_Jetpack behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomFinishSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public AB_Jetpack behaviour;

			public CustomFinishSubroutine(AB_Jetpack behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public VFXStopParticles jetpackInstance;

		[NonSerialized]
		public UIProgressBarElement currentHpProgress;

		[NonSerialized]
		public float maxDistanceFromNavmeshSqr;

		[NonSerialized]
		public float lerpedCharHeightFactor;

		[NonSerialized]
		public bool isUsing;

		[NonSerialized]
		public float charHeightFactor;

		public AB_Jetpack(Config _config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void OnStart()
		{
		}

		public override void OnUpdate()
		{
		}

		public override void OnDeactivate()
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

		public void ClUsingElapsedTimeChanged(float elapsedTime)
		{
		}

		public void ClSetFalling()
		{
		}

		public void ClSetCharHeightFactor(float charHeightFactor)
		{
		}

		public void ClSetCharHeight(float yHeight)
		{
		}

		public void ClAuthSetUsing(bool _isUsing)
		{
		}

		public override void ClStartAuth()
		{
		}

		public override void ClStopAuth()
		{
		}

		public void OnIsUsingChanged()
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

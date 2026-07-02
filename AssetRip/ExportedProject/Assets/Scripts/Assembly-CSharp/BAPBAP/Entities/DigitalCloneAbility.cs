using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DigitalCloneAbility : Ability
	{
		public class CustomTeleportSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomTeleportSubroutine(DigitalCloneAbility ability, byte trigger)
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

		public class CustomCloneWaitSwapSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneAbility ability;

			[NonSerialized]
			public byte swapTrigger;

			[NonSerialized]
			public byte finishedTrigger;

			[NonSerialized]
			public bool cloneDestroyed;

			[NonSerialized]
			public CastFlags blockedCastFlags;

			public CustomCloneWaitSwapSubroutine(DigitalCloneAbility ability, byte swapTrigger, byte finishedTrigger)
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

		public class CustomSwapTeleportSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomSwapTeleportSubroutine(DigitalCloneAbility ability, byte trigger)
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

		public class CustomCloneWaitSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneAbility ability;

			[NonSerialized]
			public byte trigger;

			public CustomCloneWaitSubroutine(DigitalCloneAbility ability, byte trigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomCastLockSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneAbility ability;

			[NonSerialized]
			public CastFlags castFlag;

			public CustomCastLockSubroutine(DigitalCloneAbility ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject clonePrefab;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType jumpRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Ability-related")]
		[SerializeField]
		public float cloneHpMultiplier;

		[SerializeField]
		public float cloneTtl;

		[Header("Misc")]
		[SerializeField]
		public float dashPosRadiusCheck;

		[SerializeField]
		public float maxCloneDistance;

		[SerializeField]
		public AnimationCurve dashCurve;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float teleportTime;

		[SerializeField]
		public float teleportTime2;

		[SerializeField]
		public float swapDelay;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[SerializeField]
		[Header("Effects")]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxTeleportPrefab;

		[SerializeField]
		public Material holoMaterial;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxTeleportIn;

		[SerializeField]
		public AudioClipData sfxTeleportOut;

		[SerializeField]
		public CharVoicelineConfig voicelineCast;

		[SerializeField]
		public CharVoicelineConfig voicelineSwap;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public EntityManager currentClone;

		[NonSerialized]
		public float cloneTimeElapsed;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public void SvSpawnClone(Vector3 spawnPos, Vector3 lookDir)
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

using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class DigitalCloneUpgradeAbility : Ability
	{
		public class CustomCloneSpawnSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneUpgradeAbility ability;

			[NonSerialized]
			public byte swapTrigger;

			[NonSerialized]
			public byte finishedTrigger;

			[NonSerialized]
			public bool cloneDestroyed;

			[NonSerialized]
			public bool delayPassed;

			[NonSerialized]
			public CastFlags castFlag;

			[NonSerialized]
			public CastFlags blockedCastFlags;

			[NonSerialized]
			public float timeElapsed;

			public CustomCloneSpawnSubroutine(DigitalCloneUpgradeAbility ability, byte swapTrigger, byte finishedTrigger)
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

		public class CustomSwapTeleportSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneUpgradeAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomSwapTeleportSubroutine(DigitalCloneUpgradeAbility ability, byte trigger)
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

		public class CustomCastLockSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneUpgradeAbility ability;

			[NonSerialized]
			public CastFlags castFlag;

			public CustomCastLockSubroutine(DigitalCloneUpgradeAbility ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomCloneWaitSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public DigitalCloneUpgradeAbility ability;

			[NonSerialized]
			public byte trigger;

			public CustomCloneWaitSubroutine(DigitalCloneUpgradeAbility ability, byte trigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[Header("General")]
		[SerializeField]
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

		[SerializeField]
		[Header("Misc")]
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
		public float swapDelay;

		[SerializeField]
		public float castRecoveryTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

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

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[SerializeField]
		public Material holoMaterial;

		[NonSerialized]
		public Material baseMaterial;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxTeleportPrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxTeleportIn;

		[SerializeField]
		public AudioClipData sfxTeleportOut;

		[SerializeField]
		public CharVoicelineConfig voicelineCast;

		[SerializeField]
		public CharVoicelineConfig voicelineSwap;

		[Header("Animation")]
		[SerializeField]
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

		public void SpawnClone(Vector3 spawnPos, Vector3 lookDir)
		{
		}

		[ClientRpc]
		public void RpcSpawnCloneFX(Vector3 spawnPos)
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

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnCloneFX__Vector3(Vector3 spawnPos)
		{
		}

		public static void InvokeUserCode_RpcSpawnCloneFX__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static DigitalCloneUpgradeAbility()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MechJetpackAbility : Ability
	{
		[Serializable]
		public class Config : AB_Consumable_Base_Use.Config
		{
			[Header("Config")]
			public float usingDuration;

			public float unequipDuration;

			public float landDuration;

			public float baseCooldownTime;

			public MotionLockType landedMotionLockType;

			public float maxDistanceFromNavmesh;

			[Header("Visuals Config")]
			public GameObject jetpackPrefab;

			public float camZoomOutMultiplier;

			[Tooltip("The character height amount in world units")]
			public float yHeightAmount;

			[Tooltip("Duration of the character height raising when starting to fly")]
			public float startHeightDuration;

			public AnimationCurve heightLerpCurve;

			[Header("Indicator")]
			public GameObject visibleIndicatorPrefab;

			public GameObject visibleIndicatorEnemyPrefab;

			[Header("Sfx Config")]
			public AudioClipData startSfx;

			public AudioClipData preEndSfx;

			public AudioClipData endSfx;

			[Header("Effects")]
			public float camShakeTrauma;

			[Header("Animation")]
			public AnimLayerIndices animLayer;

			[Header("Hitbox-related")]
			public GameObject landHitboxPrefab;

			public int damage;

			public float damageScaling;

			public float ttl;

			public List<StatusEffectInfo> statusEffects;

			public float hitboxRadius;
		}

		public class CustomUsingSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public MechJetpackAbility behaviour;

			[NonSerialized]
			public float timeElapsed;

			public CustomUsingSubroutine(MechJetpackAbility behaviour)
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
			public MechJetpackAbility behaviour;

			[NonSerialized]
			public float duration;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float timeElapsed;

			public CustomLandingSubroutine(MechJetpackAbility behaviour, byte trigger, float duration)
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
			public MechJetpackAbility behaviour;

			public CustomLandSubroutine(MechJetpackAbility behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechJetpackAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(MechJetpackAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomFinishSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechJetpackAbility behaviour;

			public CustomFinishSubroutine(MechJetpackAbility behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		public Config config;

		[NonSerialized]
		public VFXStopParticles jetpackInstance;

		[NonSerialized]
		public UIProgressBarElement currentHpProgress;

		[NonSerialized]
		public float maxDistanceFromNavmeshSqr;

		[NonSerialized]
		public GameObject currentIndicatorObject;

		[NonSerialized]
		public float lerpedCharHeightFactor;

		[NonSerialized]
		public bool isUsing;

		[NonSerialized]
		public float charHeightFactor;

		[NonSerialized]
		public MechJetpackAbility ability;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void Start()
		{
		}

		public void Update()
		{
		}

		public void OnDisable()
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

		public void Shoot(Vector3 landingPosition, int predTickNum)
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

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position)
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
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

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3(Vector3 position)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static MechJetpackAbility()
		{
		}
	}
}

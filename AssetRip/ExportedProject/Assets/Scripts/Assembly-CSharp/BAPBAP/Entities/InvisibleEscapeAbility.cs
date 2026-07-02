using System;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class InvisibleEscapeAbility : Ability
	{
		public class CustomInvisibleSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public InvisibleEscapeAbility ability;

			[NonSerialized]
			public float invisTime;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public CastFlags interruptCastFlags;

			[NonSerialized]
			public CastFlags beforeDelayFlags;

			[NonSerialized]
			public float timeElapsed;

			public CustomInvisibleSubroutine(InvisibleEscapeAbility _ability, byte _trigger, float _invisTime, CastFlags _interruptCastFlags)
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

		[Header("General")]
		[SerializeField]
		public float bonusDamagePercent;

		[SerializeField]
		public float bonusHealingPercent;

		[SerializeField]
		public float speedPercentIncrease;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float castDelay;

		[SerializeField]
		public GameObject nearbyDetectTrigger;

		[SerializeField]
		public GameObject globalNearbyDetectTriggerPrefab;

		[SerializeField]
		public float globalNearbyDetectRadius;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float invisibilityTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public MonoBehaviour flameScript;

		[SerializeField]
		public Material charInvisMaterial;

		[SerializeField]
		public Material scytheRedMaterial;

		[NonSerialized]
		public Material scytheOriginalMaterial;

		[SerializeField]
		public MeshRenderer scytheFlameRenderer;

		[SerializeField]
		public Material scytheFlameRedMaterial;

		[NonSerialized]
		public Material scytheFlameMaterial;

		[SerializeField]
		public ParticleSystem invisShadowParticles;

		[SerializeField]
		public GameObject normalHeadFlame;

		[SerializeField]
		public GameObject invisHeadFlame;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxEnterPrefab;

		[SerializeField]
		public GameObject vfxExitPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxEnter;

		[SerializeField]
		public AudioClipData sfxEnterEnemy;

		[Tooltip("Multiplier for audio source range. It will multiply min and max by this value")]
		[SerializeField]
		public float sfxEnterGlobalDistMult;

		[Tooltip("Sets the minimum distance for the audio source to the given value. Its still affected by the multiplier")]
		[SerializeField]
		public float sfxEnterGlobalMinDist;

		[SerializeField]
		public AudioClipData sfxExit;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public bool isInvisible;

		[NonSerialized]
		public bool bonusEnabled;

		[NonSerialized]
		public GameObject globalNearbyDetectTrigger;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Awake()
		{
		}

		public override void OnStartClient()
		{
		}

		public void OnDestroy()
		{
		}

		[ClientRpc]
		public void RpcEnableGlobalDetectTrigger()
		{
		}

		[ClientRpc]
		public void RpcDisableGlobalDetectTrigger()
		{
		}

		public void ClEnableGlobalDetectTrigger()
		{
		}

		public void ClDisableGlobalDetectTrigger()
		{
		}

		public void SvEnableInvisibility()
		{
		}

		public void SvDisableInvisibility()
		{
		}

		public void SetBonusEnabled()
		{
		}

		public void SetBonusDisabled()
		{
		}

		public void ClEnableInvisibilityFX()
		{
		}

		public void ClDisableInvisibilityFX()
		{
		}

		public void ClDisableScytheFX()
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

		public void OnInvisibilityChanged()
		{
		}

		public void OnBonusDamageChanged()
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

		public void UserCode_RpcEnableGlobalDetectTrigger()
		{
		}

		public static void InvokeUserCode_RpcEnableGlobalDetectTrigger(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDisableGlobalDetectTrigger()
		{
		}

		public static void InvokeUserCode_RpcDisableGlobalDetectTrigger(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static InvisibleEscapeAbility()
		{
		}
	}
}

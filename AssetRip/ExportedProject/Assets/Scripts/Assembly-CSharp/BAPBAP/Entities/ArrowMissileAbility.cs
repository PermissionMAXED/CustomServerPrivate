using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class ArrowMissileAbility : Ability
	{
		public class CustomZoomOutSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ArrowMissileAbility ability;

			public CustomZoomOutSubroutine(ArrowMissileAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomResetZoomSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ArrowMissileAbility ability;

			public CustomResetZoomSubroutine(ArrowMissileAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public ArrowMissileAbility ability;

			public CustomShootSubroutine(ArrowMissileAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[SerializeField]
		public float zoomOutMultiplier;

		[SerializeField]
		public float castVisibilityRadius;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxCastPrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxCast;

		[SerializeField]
		public AudioClipData sfxCastEnemy;

		[SerializeField]
		public AudioClipData targetHitAudioClipData;

		[Tooltip("Multiplier for audio source range. It will multiply min and max by this value")]
		[SerializeField]
		public float sfxCastGlobalDistMult;

		[Tooltip("Sets the minimum distance for the audio source to the given value. Its still affected by the multiplier")]
		[SerializeField]
		public float sfxCastGlobalMinDist;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public FogOfWarController fowController;

		[NonSerialized]
		public CameraController camController;

		[NonSerialized]
		public GameObject currIndicatorObject;

		[NonSerialized]
		public bool _isOwned;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public bool _isClient;

		[NonSerialized]
		public float zoomMultiplier;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase)
		{
		}

		[ClientRpc]
		public void RpcOnTargetHit(Vector3 hitPosition)
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

		public void OnZoomMultiplierChanged()
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

		public void UserCode_RpcOnTargetHit__Vector3(Vector3 hitPosition)
		{
		}

		public static void InvokeUserCode_RpcOnTargetHit__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ArrowMissileAbility()
		{
		}
	}
}

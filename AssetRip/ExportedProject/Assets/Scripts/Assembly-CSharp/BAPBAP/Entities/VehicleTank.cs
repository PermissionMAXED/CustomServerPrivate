using System;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class VehicleTank : Vehicle
	{
		[SerializeField]
		[Header("Turret Config")]
		[ExHeader("Tank Parameters", 0f, 1f, 1f)]
		public CommandId turretCommandId;

		[SerializeField]
		public float turretCooldown;

		[SerializeField]
		public float turretRecoilForce;

		[SerializeField]
		public int turretHitboxMissileDamage;

		[SerializeField]
		public float turretHitboxMissileTtl;

		[SerializeField]
		public float turretHitboxMissileSpeed;

		[SerializeField]
		public int turretHitboxImpactDamage;

		[SerializeField]
		public float turretHitboxImpactTtl;

		[SerializeField]
		public float turretHitboxImpactRadius;

		[SerializeField]
		public Transform rotationPivot;

		[SerializeField]
		public Transform turretPivot;

		[SerializeField]
		public Transform gunPivot;

		[SerializeField]
		public Transform muzzleFirePoint;

		[SerializeField]
		public GameObject turretHitboxMissilePrefab;

		[SerializeField]
		public GameObject turretHitboxExplosionPrefab;

		[SerializeField]
		public ParticleSystem muzzleVfx;

		[SerializeField]
		public PlayTrailEmitter muzzleVfxTrail;

		[Header("Recoil Anim Config")]
		[SerializeField]
		public float turretRecoilDuration;

		[SerializeField]
		public AnimationCurve turretRecoilCurve;

		[SerializeField]
		public float turretRecoilMult;

		[SerializeField]
		public AnimationCurve gunRecoilCurve;

		[SerializeField]
		public float gunRecoilMult;

		[Header("SFX")]
		[SerializeField]
		public AudioLoopSpeed turretTurnAudio;

		[SerializeField]
		public float turretTurnAudioFactorMult;

		[Header("Track Config")]
		[SerializeField]
		public float wheelPositionNoiseScale;

		[SerializeField]
		public float wheelPositionNoiseIntensity;

		[SerializeField]
		public float trackAnimationSpeed;

		[SerializeField]
		public SkinnedMeshRenderer rightTrackRenderer;

		[SerializeField]
		public SkinnedMeshRenderer leftTrackRenderer;

		[SerializeField]
		public Transform[] leftTrackBones;

		[SerializeField]
		public Transform[] rightTrackBones;

		[SerializeField]
		public Transform[] leftGearBones;

		[SerializeField]
		public Transform[] rightGearBones;

		[SerializeField]
		public Transform[] leftWheelTransforms;

		[SerializeField]
		public Transform[] rightWheelTransforms;

		[SerializeField]
		public Transform[] leftGearTransforms;

		[SerializeField]
		public Transform[] rightGearTransforms;

		[NonSerialized]
		public Vector3[] leftWheelPositions;

		[NonSerialized]
		public Vector3[] rightWheelPositions;

		[NonSerialized]
		public Material leftTrackMaterial;

		[NonSerialized]
		public Material rightTrackMaterial;

		[NonSerialized]
		public float turretCooldownRemaining;

		[NonSerialized]
		public float turretRecoilRemaining;

		[NonSerialized]
		public Vector3 turretRecoilDirection;

		[NonSerialized]
		public Quaternion slerpedTargetRotation;

		[SyncVar]
		[NonSerialized]
		public float turretTargetRotation;

		[SyncVar]
		[NonSerialized]
		public float angularYVelocity;

		[SyncVar]
		[NonSerialized]
		public float linearVelocity;

		[NonSerialized]
		public Vector3 turretOrigin;

		[NonSerialized]
		public Vector3 gunOrigin;

		public float NetworkturretTargetRotation
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkangularYVelocity
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public float NetworklinearVelocity
		{
			get
			{
				return 0f;
			}
			[param: In]
			set
			{
			}
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void Update()
		{
		}

		public void Shoot()
		{
		}

		public void SpawnProjectile()
		{
		}

		[ClientRpc]
		public void RpcOnTurretShoot(float rotation)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnTurretShoot__Single(float rotation)
		{
		}

		public static void InvokeUserCode_RpcOnTurretShoot__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static VehicleTank()
		{
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}

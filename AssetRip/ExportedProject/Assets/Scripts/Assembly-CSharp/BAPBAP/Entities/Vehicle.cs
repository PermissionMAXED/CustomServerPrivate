using System;
using System.Runtime.InteropServices;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.UI;
using JigglePhysics;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class Vehicle : MountableInteractable, INetworkPredicted
	{
		[NonSerialized]
		public Rigidbody rb;

		[ExHeader("Vehicle Parameters", 0f, 1f, 1f)]
		[Header("Properties")]
		[SerializeField]
		public bool interactLayerKinematicUsing;

		[Header("Speed Parameters")]
		[SerializeField]
		[Range(0.01f, 50f)]
		public float maxSpeed;

		[SerializeField]
		[Range(0f, 50f)]
		public float forwardAccelerationMult;

		[SerializeField]
		[Range(0f, 50f)]
		public float backwardsAccelerationMult;

		[Range(0f, 30f)]
		[Header("Turn Parameters")]
		[Tooltip("A multiplier for now many degrees for the turning speed.")]
		[SerializeField]
		public float turnSpeedMultiplier;

		[SerializeField]
		[Tooltip("How fast the turning will respond to inputs. The lower the value, the slower the turning will change.")]
		[Range(0f, 1f)]
		public float turnSnappines;

		[Tooltip("Should the turn input be inverted while moving the vehicle backwards?")]
		[SerializeField]
		public bool invertTurnOnBackwards;

		[Tooltip("Should the turn speed be multiplied by the current speed? In order to ensure vehicle only rotates while moving")]
		[SerializeField]
		public bool multiplyBySpeedFactor;

		[Tooltip("If more than 0, use a custom speed range from the current speed to this value for turn speed multiplying.")]
		[ConditionalHide("multiplyBySpeedFactor", true)]
		[Min(0f)]
		[SerializeField]
		public float customSpeedFactorRange;

		[Header("Traction Parameters")]
		[SerializeField]
		[Tooltip("The traction amount for this vehicle along its side axis. The higher value, the more friction the car will have to its side velocity.")]
		public AnimationCurve tractionBySpeed;

		[Range(0f, 10f)]
		[SerializeField]
		[Tooltip("How reactive the drifting should respong to its input. Higher values will result in a snappier result.")]
		[Header("Drift Parameters")]
		public float driftFactorAccel;

		[Tooltip("How reactive the drifting should respong to its input. Higher values will result in a snappier result.")]
		[Range(0f, 10f)]
		[SerializeField]
		public float driftFactorDecel;

		[Range(0f, 10f)]
		[Tooltip("How much drift force to apply to the current drifting velocity.")]
		[SerializeField]
		public float driftSpeedForceMult;

		[SerializeField]
		[Min(0f)]
		[Tooltip("Applies this multiplier to the rotation speed while drifting.")]
		public float driftRotationSpeedMult;

		[Tooltip("Applies this multiplier to the minimum turn rotation speed while drifting.")]
		[SerializeField]
		[Range(0f, 30f)]
		public float minTurnDriftSpeedMult;

		[SerializeField]
		public AnimationCurve driftVelBySideVelFactor;

		[SerializeField]
		[Header("Turbo Parameters")]
		public bool enableTurbo;

		[ConditionalHide("enableTurbo", true)]
		[Tooltip("The turbo speed to add to the current velocity.")]
		[SerializeField]
		[Range(0f, 10f)]
		public float turboSpeed;

		[SerializeField]
		[Min(0f)]
		[Tooltip("Amount of turbo available.")]
		[ConditionalHide("enableTurbo", true)]
		public float turboMaxCapacity;

		[ConditionalHide("enableTurbo", true)]
		[Tooltip("How much turbo to regenerate per second.")]
		[SerializeField]
		[Min(0f)]
		public float turboRegenPerSecond;

		[ConditionalHide("enableTurbo", true)]
		[Tooltip("How much turbo to consume from the current capacity")]
		[SerializeField]
		[Min(0f)]
		public float turboConsumePerSecond;

		[ConditionalHide("enableTurbo", true)]
		[Tooltip("How fast the turbo factor will respond to input changes")]
		[SerializeField]
		[Min(0f)]
		public float turboFactorLerpSpeed;

		[SerializeField]
		[ConditionalHide("enableTurbo", true)]
		public AudioLoopSpeed audioLoopTurbo;

		[ConditionalHide("enableTurbo", true)]
		[SerializeField]
		public ParticleSystem turboParticleSystem;

		[Range(0f, 1f)]
		[ExHeader("View Parameters", 1f, 1f, 0f)]
		[Header("Wheel Parameters")]
		[SerializeField]
		[Tooltip("The threshold for playing tire skid fx based on the current side velocity.")]
		public float tireSkidFxThreshold;

		[Range(0f, 1f)]
		[SerializeField]
		[Tooltip("The threshold for playing drifting fx based on the current drifting factor.")]
		public float driftVelFxThreshold;

		[SerializeField]
		public float wheelTurnAngle;

		[SerializeField]
		public float wheelTurnSpeed;

		[SerializeField]
		public float wheelRotationSpeed;

		[Header("Anim Parameters")]
		[SerializeField]
		public float meshTurnYawAmount;

		[SerializeField]
		public float turnYawSpeed;

		[Header("Audio Parameters")]
		[SerializeField]
		public float driftVolume;

		[SerializeField]
		public float driftPitchChange;

		[SerializeField]
		public bool useSpeedAudio;

		[ConditionalHide("useSpeedAudio", true)]
		[SerializeField]
		public AudioLoopSpeed audioLoopSpeed;

		[SerializeField]
		public bool useEngineAudio;

		[ConditionalHide("useEngineAudio", true)]
		[SerializeField]
		public AudioLoopSpeed audioLoopEngine;

		[Min(0f)]
		[ConditionalHide("useEngineAudio", true)]
		[SerializeField]
		public float engineLoopUsingMinVolume;

		[SerializeField]
		public AudioClipData sfxDriftStart;

		[SerializeField]
		public AudioClipData sfxDriftAfterburn;

		[SerializeField]
		[Header("Camera Parameters")]
		public bool vehicleCam;

		[ConditionalHide("vehicleCam", true)]
		[SerializeField]
		public bool vehicleCamUsePreset;

		[SerializeField]
		[ConditionalHide("vehicleCamUsePreset", true)]
		public CameraVehicle.DriverVehiclePreset vehicleCamPreset;

		[SerializeField]
		public AnimationCurve camFovBySpeed;

		[SerializeField]
		public float camFovMultiplier;

		[SerializeField]
		public float fovRangeMultiplier;

		[SerializeField]
		public float fovLerpSpeed;

		[SerializeField]
		public float camFollowTransformRange;

		[Header("References")]
		[SerializeField]
		public Transform meshTransform;

		[SerializeField]
		public ParticleSystem collisionPs;

		[SerializeField]
		public AudioPlayRandom collisionAudioPlay;

		[SerializeField]
		public JiggleRigBuilder jiggleRig;

		[SerializeField]
		public ParticleSystem usingPs;

		[Header("Wheel References")]
		[SerializeField]
		public Transform[] wheels;

		[SerializeField]
		public Transform[] turnWheels;

		[SerializeField]
		public TrailRenderer[] trailRenderers;

		[SerializeField]
		public ParticleSystem skidParticleSystem;

		[SerializeField]
		public ParticleSystem driftParticleSystem;

		[SerializeField]
		public AudioSource driftAudioSource;

		[Header("Interactable Input Info")]
		[SerializeField]
		public UIGameMode.InteractableInputInfo[] interactableInputInfo;

		[SerializeField]
		[Space(10f)]
		public bool debugGizmos;

		[NonSerialized]
		public float currentSpeed;

		[NonSerialized]
		public float currentTurnSpeed;

		[SyncVar]
		[NonSerialized]
		public float sideVelFactor;

		[SyncVar]
		[NonSerialized]
		public float lerpedDriftFactor;

		[SyncVar]
		[NonSerialized]
		public float currentTurboForce;

		[SyncVar]
		[NonSerialized]
		public float currentTurboCapacity;

		[SyncVar]
		[NonSerialized]
		public Vector2 dirInput;

		[SyncVar]
		[NonSerialized]
		public float driftingInput;

		[SyncVar]
		[NonSerialized]
		public float turboingInput;

		[NonSerialized]
		public float lastYInput;

		[NonSerialized]
		public UIProgressBarElement turboCapacityUI;

		[NonSerialized]
		public float lerpedWheelTurn;

		[NonSerialized]
		public float lerpedTurnYaw;

		[NonSerialized]
		public float lerpedCamFov;

		public Action<Collision, Vector3> onVehicleCollision;

		public bool InUse => false;

		public EntityManager Driver => null;

		public EntityManager[] Passengers => null;

		public float CurrentSpeed => 0f;

		public Rigidbody Rb => null;

		public float NetworksideVelFactor
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

		public float NetworklerpedDriftFactor
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

		public float NetworkcurrentTurboForce
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

		public float NetworkcurrentTurboCapacity
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

		public Vector2 NetworkdirInput
		{
			get
			{
				return default(Vector2);
			}
			[param: In]
			set
			{
			}
		}

		public float NetworkdriftingInput
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

		public float NetworkturboingInput
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

		public override void OnValidate()
		{
		}

		public override void Awake()
		{
		}

		public override void Start()
		{
		}

		public override void OnDisable()
		{
		}

		public void ForceExit()
		{
		}

		public override void AssignDriver(EntityManager entity)
		{
		}

		public override void RemoveDriver(EntityManager entity)
		{
		}

		public override void AssignCharInVehicle(EntityManager entity, Seat seat)
		{
		}

		public override void RemoveCharInVehicle(EntityManager entity, Seat seat)
		{
		}

		public virtual void OnTick(float fixedDt, Command cmd, bool isResim)
		{
		}

		public override void Update()
		{
		}

		public virtual void CarVelPhysics(float fixedDt)
		{
		}

		public void OnCollisionEnter(Collision collision)
		{
		}

		[ClientRpc]
		public override void RpcOnUseSuccess(EntityManager entityManager, int slotId)
		{
		}

		public override void ClOnApplyAuth(EntityManager entity)
		{
		}

		public override void ClOnRemoveAuth(EntityManager entity)
		{
		}

		public void OnNetDeserialize(NetworkReader netReader)
		{
		}

		public void OnNetSerialize(NetworkWriter netWriter)
		{
		}

		public bool OnNetDebugCompare(NetworkReader netReader)
		{
			return false;
		}

		public void OnNetDebugLog(StringBuilder sb)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void UserCode_RpcOnUseSuccess__EntityManager__Int32(EntityManager entityManager, int slotId)
		{
		}

		public new static void InvokeUserCode_RpcOnUseSuccess__EntityManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static Vehicle()
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

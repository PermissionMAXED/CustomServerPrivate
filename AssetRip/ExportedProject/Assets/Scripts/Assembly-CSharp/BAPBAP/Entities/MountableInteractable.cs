using System;
using System.Runtime.InteropServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MountableInteractable : InteractableStation
	{
		[Serializable]
		public class Seat
		{
			public Transform seatTransform;

			public Transform dismountTransform;
		}

		[NonSerialized]
		public Collider vehicleCollider;

		[NonSerialized]
		public CameraManager cameraManager;

		[Min(0f)]
		[SerializeField]
		[Header("Properties")]
		public float cooldownTime;

		[SerializeField]
		public bool showDismountWindow;

		[ConditionalHide("showDismountWindow", true)]
		[SerializeField]
		public float showDismountDuration;

		[ConditionalHide("showDismountWindow", true)]
		[SerializeField]
		public float clSpeedThresholdShowDismount;

		[SerializeField]
		public bool hideCharacter;

		[SerializeField]
		public bool hideHpBar;

		[SerializeField]
		[Tooltip("Should any driver or passengers be invulnerable while being in the interactable? (this will set triggerLocks on the entity)")]
		public bool invulnerableWhileUsing;

		[Tooltip("Are the drivers meant to be remote? If enabled, drivers wont be moved along the vehicle.")]
		[SerializeField]
		public bool remoteDriver;

		[SerializeField]
		[Header("Camera Parameters")]
		public float camZoomOutMultiplier;

		[SerializeField]
		public Transform camFollowTransform;

		[Header("Translation Keys")]
		[SerializeField]
		public string dismountTranslationKey;

		[SerializeField]
		public string vehicleFullTranslationKey;

		[Header("Seats")]
		[SerializeField]
		public Seat driverSeat;

		[SerializeField]
		public Seat[] passengerSeats;

		[NonSerialized]
		public bool inUse;

		[NonSerialized]
		public int passengerCount;

		[NonSerialized]
		public float clCurrentSpeed;

		[NonSerialized]
		public Vector3 clPrevPos;

		[NonSerialized]
		public float currentCooldownTimer;

		[NonSerialized]
		public float clShowDismountTimer;

		[NonSerialized]
		public string driveStr;

		[NonSerialized]
		public string mountStr;

		[NonSerialized]
		public string dismountStr;

		[NonSerialized]
		public string vehicleFullStr;

		[NonSerialized]
		public string gettingInStr;

		[NonSerialized]
		public string gettingOutStr;

		[NonSerialized]
		public EntityManager driver;

		[NonSerialized]
		public EntityManager[] passengers;

		[SyncVar(hook = "OnDriverChanged")]
		[NonSerialized]
		public uint driverNetId;

		[NonSerialized]
		public readonly SyncList<uint> passengersNetId;

		[SyncVar(hook = "OnCurrentCooldownTimerSyncChanged")]
		[NonSerialized]
		public byte currentCooldownTimerSync;

		public Action<EntityManager> SvOnDriverAssigned;

		public Action<EntityManager> SvOnDriverRemoved;

		public Action<EntityManager> SvOnCharInVehicleAssigned;

		public Action<EntityManager> SvOnCharInVehicleRemoved;

		[NonSerialized]
		public bool _isServer;

		[NonSerialized]
		public bool _isClient;

		public Action<uint, uint> _Mirror_SyncVarHookDelegate_driverNetId;

		public Action<byte, byte> _Mirror_SyncVarHookDelegate_currentCooldownTimerSync;

		public uint NetworkdriverNetId
		{
			get
			{
				return 0u;
			}
			[param: In]
			set
			{
			}
		}

		public byte NetworkcurrentCooldownTimerSync
		{
			get
			{
				return 0;
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

		public override void OnStartClient()
		{
		}

		public virtual void OnDisable()
		{
		}

		public override void OnDestroy()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public override void OnSlotExit(EntityManager entity, InteractableCollider slot)
		{
		}

		public override void ClOnEnter(EntityManager entity, InteractableCollider slot)
		{
		}

		public void UIShowDriveWindow()
		{
		}

		public void UIShowMountWindow()
		{
		}

		public void UIShowDismountWindow()
		{
		}

		public void UIShowVehicleFullWindow()
		{
		}

		public override void UIShowInvalidWindow(InteractableCollider slot)
		{
		}

		public override bool TryUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public override bool AbleToUseStation(EntityManager entity, int slotId)
		{
			return false;
		}

		public virtual void AssignDriver(EntityManager entity)
		{
		}

		public virtual void RemoveDriver(EntityManager entity)
		{
		}

		public void AssignPassenger(EntityManager entity, int seatId)
		{
		}

		public void RemovePassenger(EntityManager entity, int seatId)
		{
		}

		public virtual void AssignCharInVehicle(EntityManager entity, Seat seat)
		{
		}

		public virtual void RemoveCharInVehicle(EntityManager entity, Seat seat)
		{
		}

		public void SetCharPhysIgnore(EntityManager entity, bool ignore)
		{
		}

		public virtual void FixedUpdate()
		{
		}

		public virtual void Update()
		{
		}

		public void MoveCharacterInVehicle(Seat seat, EntityManager entity)
		{
		}

		public void ForceExitPlayer(EntityManager entity)
		{
		}

		public bool HasFreeSeat()
		{
			return false;
		}

		public int GetFreeSeatId()
		{
			return 0;
		}

		public bool ContainsPassenger(EntityManager passenger)
		{
			return false;
		}

		public int GetPassengerSeatId(EntityManager passenger)
		{
			return 0;
		}

		public Transform GetSeatTransform(EntityManager entity)
		{
			return null;
		}

		public virtual void ClOnApplyAuth(EntityManager entity)
		{
		}

		public virtual void ClOnRemoveAuth(EntityManager entity)
		{
		}

		public void OnDriverChanged(uint oldValue, uint newValue)
		{
		}

		public void OnPassengersChangedHook(SyncList<uint>.Operation op, int index, uint oldItem, uint newItem)
		{
		}

		public virtual void OnCharVehicleChanged(EntityManager oldValue, EntityManager newValue)
		{
		}

		public void OnCurrentCooldownTimerSyncChanged(byte oldValue, byte newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
		{
		}

		public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
		{
		}
	}
}

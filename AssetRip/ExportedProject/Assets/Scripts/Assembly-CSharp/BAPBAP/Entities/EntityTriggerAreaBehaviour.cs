using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class EntityTriggerAreaBehaviour : NetworkBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SphereCollider sphereCollider;

		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[Header("View References")]
		[SerializeField]
		public UnityEvent[] triggerEvents;

		[SerializeField]
		public UnityEvent[] activateEvents;

		[SerializeField]
		public UnityEvent[] resetEvents;

		[SerializeField]
		[Tooltip("If enabled, this entity will trigger on start even if there is not any current entered entities")]
		[Header("Configs")]
		public bool triggerOnStart;

		[Tooltip("Enables this entity to try to trigger on any current entered entities every frame")]
		[FormerlySerializedAs("triggerOnUpdate")]
		[SerializeField]
		public bool tryTriggerOnUpdate;

		[SerializeField]
		[Tooltip("Triggers a reset when there are no entities in the area (triggered when the last entity exits)")]
		public bool resetOnNoEntitiesInArea;

		[SerializeField]
		public bool ignoreItems;

		[SerializeField]
		public bool ignoreAllies;

		[SerializeField]
		public bool ignoreInteractables;

		[SerializeField]
		public bool ignoreAll;

		[SerializeField]
		[Header("Timer Settings")]
		[Min(0f)]
		public float chargeDuration;

		[SerializeField]
		[Min(0f)]
		public float cooldownDuration;

		[SerializeField]
		[Min(0f)]
		public float resetDuration;

		[SerializeField]
		[Header("Components to Activate")]
		public EntityActivateBase[] activations;

		[SerializeField]
		public EntityActivateBase[] charges;

		[SerializeField]
		public EntityActivateBase[] resets;

		[NonSerialized]
		public float chargeTimer;

		[NonSerialized]
		public float cooldownTimer;

		[NonSerialized]
		public float resetTimer;

		[NonSerialized]
		public bool hasTriggered;

		[NonSerialized]
		public bool activated;

		[NonSerialized]
		public Action onActivateAction;

		[SyncVar(hook = "OnInteractableEnabledChanged")]
		[NonSerialized]
		public bool interactableEnabled;

		public Action<bool, bool> _Mirror_SyncVarHookDelegate_interactableEnabled;

		public List<EntityManager> CurrentEntities => null;

		public bool NetworkinteractableEnabled
		{
			get
			{
				return false;
			}
			[param: In]
			set
			{
			}
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public bool IsOnCooldown()
		{
			return false;
		}

		public bool IsTriggered()
		{
			return false;
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		public bool ValidEntityExists()
		{
			return false;
		}

		public void OnEnter(EntityManager entity)
		{
		}

		public void OnExit(EntityManager entity)
		{
		}

		[Server]
		public void TriggerInteractable()
		{
		}

		[Server]
		public void ActivateCharges()
		{
		}

		[Server]
		public void Activate()
		{
		}

		[Server]
		public void Reset()
		{
		}

		public void OnInteractableEnabledChanged(bool oldValue, bool newValue)
		{
		}

		public void ClLockedChanged()
		{
		}

		[ClientRpc]
		public void RpcTrigger()
		{
		}

		[ClientRpc]
		public void RpcActivate()
		{
		}

		[ClientRpc]
		public void RpcReset()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcTrigger()
		{
		}

		public static void InvokeUserCode_RpcTrigger(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcActivate()
		{
		}

		public static void InvokeUserCode_RpcActivate(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcReset()
		{
		}

		public static void InvokeUserCode_RpcReset(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static EntityTriggerAreaBehaviour()
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

using System;
using System.Runtime.InteropServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities.Pickups
{
	[RequireComponent(typeof(EntityTriggerboxListener))]
	public class PickupSpawner : NetworkBehaviour
	{
		[NonSerialized]
		public SphereCollider col;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public EntityTriggerboxListener triggerboxListener;

		[SerializeField]
		[Header("Refrences")]
		public SpriteRenderer ringRenderer;

		[SerializeField]
		public GameObject pickupObject;

		[SerializeField]
		public GameObject pickupObjectSpawnFx;

		[SerializeField]
		[Header("Settings")]
		public float respawnDuration;

		[SerializeField]
		[Header("FX")]
		public Color ringColor;

		[SerializeField]
		public GameObject pickUpVfxPrefab;

		[SerializeField]
		public float pickUpVfxTtl;

		[NonSerialized]
		public bool isActive;

		[NonSerialized]
		public bool _enabled;

		[SyncVar(hook = "OnRespawnTimerChanged")]
		[NonSerialized]
		public float respawnTimer;

		public Action<float, float> _Mirror_SyncVarHookDelegate_respawnTimer;

		public float NetworkrespawnTimer
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

		public virtual void Awake()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		[ServerCallback]
		public virtual void Update()
		{
		}

		public virtual void OnEnter(EntityManager entity)
		{
		}

		public virtual void OnExit(EntityManager entity)
		{
		}

		[Server]
		public virtual bool CharGetPickup(EntityManager entityManager)
		{
			return false;
		}

		[Server]
		public void OnGetPickup()
		{
		}

		[Server]
		public void SetPickupEnabled(bool isEnabled)
		{
		}

		[ClientRpc]
		public void RpcOnPickupEnabled()
		{
		}

		[ClientRpc]
		public void RpcOnPickupDisabled()
		{
		}

		public void ClSetPickupObjEnabled(bool isEnabled)
		{
		}

		public void SetRingColor(Color color)
		{
		}

		public void SetProgressRing(float percentage)
		{
		}

		public void OnRespawnTimerChanged(float oldValue, float newValue)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnPickupEnabled()
		{
		}

		public static void InvokeUserCode_RpcOnPickupEnabled(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcOnPickupDisabled()
		{
		}

		public static void InvokeUserCode_RpcOnPickupDisabled(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PickupSpawner()
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

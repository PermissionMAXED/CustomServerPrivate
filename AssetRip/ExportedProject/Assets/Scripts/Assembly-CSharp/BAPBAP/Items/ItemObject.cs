using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Entities;
using BAPBAP.Local;
using BAPBAP.Pooling;
using Mirror;
using UnityEngine;

namespace BAPBAP.Items
{
	public class ItemObject : NetworkBehaviour, ICharInteractable, IPoolSpawnListener
	{
		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public ItemObjectAnim itemAnim;

		[NonSerialized]
		public ItemObjectHighlight itemHighlight;

		[NonSerialized]
		public ItemObjectPrevOwner itemPrevOwner;

		[NonSerialized]
		public ItemObjectDestroyDelay itemDestroyDelay;

		[NonSerialized]
		public NetworkTransform networkTransform;

		[NonSerialized]
		public SphereCollider sphereCol;

		[NonSerialized]
		public ItemIdleAnim itemIdleAnim;

		[SerializeField]
		[Header("References")]
		public Collider obstacleCollider;

		[SerializeField]
		public GameObject itemTransform;

		[SerializeField]
		public GameObject itemEnable;

		[SerializeField]
		public ItemObjectVisualizer itemVisualizer;

		[Header("Settings")]
		[SerializeField]
		public float enableDuration;

		[SerializeField]
		public int interactablePriority;

		[Header("VFX")]
		[NonSerialized]
		public GameObject spawnedVFX;

		[NonSerialized]
		public GameObject loopVFX;

		[NonSerialized]
		public GameObject pickupVFX;

		[SyncVar]
		[NonSerialized]
		public int itemId;

		[SyncVar]
		[NonSerialized]
		public int amount;

		[NonSerialized]
		public float originalEnableDuration;

		[NonSerialized]
		public float enableTimer;

		[NonSerialized]
		public bool isDestroyed;

		[NonSerialized]
		public List<CharItems> currentHoveringChars;

		public ItemObjectPrevOwner ItemPrevOwner => null;

		public ItemObjectHighlight ItemHighlight => null;

		public ItemObjectVisualizer ItemVisualizer => null;

		public ItemObjectAnim ItemAnim => null;

		public bool IsDestroyed => false;

		public int ItemId => 0;

		public int Amount => 0;

		public float EnableDuration
		{
			set
			{
			}
		}

		public int NetworkitemId
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

		public int Networkamount
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

		public void Awake()
		{
		}

		public void SvOnLockedChanged()
		{
		}

		public void OnSpawn()
		{
		}

		public void Update()
		{
		}

		[Server]
		public void Initialize(int _itemId, CharItems prevOwnerChar = null)
		{
		}

		[Server]
		public void Initialize(int _itemId, int _amount, CharItems prevOwnerChar = null)
		{
		}

		[ClientRpc]
		public void RpcOnItemSpawnedFX(Vector3 startingLerpPos)
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopServer()
		{
		}

		public override void OnStopClient()
		{
		}

		public void DestroyItemObject()
		{
		}

		public void OnItemDestroy()
		{
		}

		public void AddHoveringChar(CharItems charItems)
		{
		}

		public void RemoveHoveringChar(CharItems charItems)
		{
		}

		public void OnInteractableTriggerEnter(EntityManager entityManager)
		{
		}

		public void OnStartHovering(EntityManager entityManager)
		{
		}

		public void OnEnter(EntityManager entityManager)
		{
		}

		public void OnExit(EntityManager entityManager)
		{
		}

		public void OnInteract(EntityManager entityManager)
		{
		}

		public int GetPriority()
		{
			return 0;
		}

		public bool IsSelectable(EntityManager entityManager)
		{
			return false;
		}

		public bool InteruptableOnDamaged()
		{
			return false;
		}

		public bool InterruptableOnCasting()
		{
			return false;
		}

		public EntityManager GetEntityManager()
		{
			return null;
		}

		public Transform GetTransform()
		{
			return null;
		}

		public GameObject GetGameObject()
		{
			return null;
		}

		public void DebugToggleRendering(bool isEnabled)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcOnItemSpawnedFX__Vector3(Vector3 startingLerpPos)
		{
		}

		public static void InvokeUserCode_RpcOnItemSpawnedFX__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static ItemObject()
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

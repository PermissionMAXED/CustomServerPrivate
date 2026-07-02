using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using BAPBAP.Items;
using BAPBAP.Local;
using Mirror;
using TMPro;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TileCooldown : Tile
	{
		[NonSerialized]
		public List<EntityManager> currentChars;

		[SerializeField]
		public EntityTriggerboxListener entityDetectCollidersHolder;

		[SerializeField]
		public TMP_Text timerMesh;

		[SerializeField]
		public float cooldownTime;

		[SerializeField]
		public float activateTime;

		[SerializeField]
		public bool onlyPlayers;

		[SerializeField]
		public float healPercentAmount;

		[SerializeField]
		public bool destroyEquipment;

		[ConditionalHide("destroyEquipment")]
		[SerializeField]
		public LootDropEntry.GearDrop[] gearTable;

		[SerializeField]
		public GameObject jumpPad;

		[SerializeField]
		public GameObject jumpPadArrow;

		[SerializeField]
		public float despawnJumpPadTime;

		[SerializeField]
		public GameObject vfxDespawn;

		[SerializeField]
		public PassiveSO passiveToActivate;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SyncVar(hook = "OnCurrentCooldownTimerSyncChanged")]
		[NonSerialized]
		public int currentCooldownTimerSync;

		[SyncVar(hook = "OnArrowRotationAmountChanged")]
		[NonSerialized]
		public int arrowRotationAmount;

		[NonSerialized]
		public float currentCooldownTimer;

		[NonSerialized]
		public bool onCooldown;

		[NonSerialized]
		public EntityManager target;

		[NonSerialized]
		public float activateTimer;

		[NonSerialized]
		public float despawnJumpPadTimer;

		[NonSerialized]
		public GameObject currentJumpPad;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public int slotDeleted;

		public Action<int, int> _Mirror_SyncVarHookDelegate_currentCooldownTimerSync;

		public Action<int, int> _Mirror_SyncVarHookDelegate_arrowRotationAmount;

		public int NetworkcurrentCooldownTimerSync
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

		public int NetworkarrowRotationAmount
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

		public void Start()
		{
		}

		public void OnEntityEnter(EntityManager entity)
		{
		}

		public void OnEntityExit(EntityManager entity)
		{
		}

		public void TryActivate()
		{
		}

		public void SetTarget(EntityManager entity)
		{
		}

		public void Activate()
		{
		}

		public override void SvTick(float fixedDt)
		{
		}

		[ClientRpc]
		public void RpcPlayDespawnVfx()
		{
		}

		public void OnCurrentCooldownTimerSyncChanged(int oldValue, int newValue)
		{
		}

		public void OnArrowRotationAmountChanged(int oldValue, int newValue)
		{
		}

		public void SpawnRandomItems(LootDropEntry.GearDrop[] randomItemDrops, Vector3 spawnWorldPosition, float spawnRadius)
		{
		}

		public int[] GetRandomItemIds(LootDropEntry.GearDrop[] randomItemDrops)
		{
			return null;
		}

		public int GetRandomItemId(LootDropEntry.GearDrop randomItemDrop)
		{
			return 0;
		}

		public int GetRandomType()
		{
			return 0;
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayDespawnVfx()
		{
		}

		public static void InvokeUserCode_RpcPlayDespawnVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static TileCooldown()
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

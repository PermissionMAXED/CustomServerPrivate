using System;
using System.Collections.Generic;
using BAPBAP.Game;
using BAPBAP.Local;
using Mirror;
using UnityEngine;

namespace BAPBAP.Items
{
	public class ItemDrops : NetworkBehaviour
	{
		[Serializable]
		public class DropListWrapper
		{
			public LootTable[] lootData;
		}

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public ItemManager itemManager;

		[SerializeField]
		[ContextMenuItem("↺ Reset", "ResetItemDropData")]
		public LootTable lootTable;

		[SerializeField]
		public LootTableSO lootTableSO;

		[SerializeField]
		public DropListWrapper dropsPerRounds;

		[SerializeField]
		[Header("Settings")]
		[Tooltip("Provide a loot table object instead of a serialized class in this component.")]
		public bool fromSriptableObject;

		[Tooltip("If enabled, set up multiple loot tables per round. Specified rounds will try to match the current map rounds, i.e: if provided 3 rounds, but the map has 6 rounds, rounds will be spread to a 2/1 ratio of the map rounds")]
		[SerializeField]
		public bool doDropsPerRounds;

		[Tooltip("Should this instance apply the existing gamemode item drop chances? If not, it will always get the existing chances without modifying them.")]
		[SerializeField]
		public bool applyDropChanceMultiplier;

		[SerializeField]
		[Header("Spawn Settings")]
		public bool spawnOnStart;

		[SerializeField]
		public bool spawnOnDestroy;

		[SerializeField]
		public float spawnRadius;

		[SerializeField]
		[Tooltip("Custom transform from where the items will be spawned. If null, will default to this transform")]
		public Transform customSpawnPoint;

		[SerializeField]
		[Tooltip("Sets the item spawning starting direction to the transform forward of the spawn point")]
		public bool alignToSpawnDirection;

		[NonSerialized]
		public List<LootTable> customLootTables;

		[NonSerialized]
		public Action<GameObject> onInstanceSpawned;

		[NonSerialized]
		public float[] tiersProbabilityCache;

		public LootTable ItemLootTable => null;

		public float SpawnRadius => 0f;

		public void ResetItemDropData()
		{
		}

		public void Awake()
		{
		}

		[ServerCallback]
		public void Start()
		{
		}

		[Server]
		public void OnDestroyed()
		{
		}

		[Server]
		public void OnSpawnDrops()
		{
		}

		[Server]
		public void OnSpawnDrops(Action<GameObject> _onInstanceSpawned)
		{
		}

		[Server]
		public void SpawnItems(LootTable lootTable)
		{
		}

		[Server]
		public void SpawnLootTable(LootTable lootTable)
		{
		}

		public void SpawnAnyItems(LootDropEntry lootDrop)
		{
		}

		public void SpawnGear(LootDropEntry lootDrop)
		{
		}

		public void SpawnConsumables(LootDropEntry lootDrop)
		{
		}

		public void SpawnCurrency(LootDropEntry lootDrop)
		{
		}

		public void SpawnHax(LootDropEntry lootDrop)
		{
		}

		public GameObject SpawnItemId(int itemId, int amount = 1)
		{
			return null;
		}

		public int GetRandomGearTypeItemId(LootDropEntry.GearDrop gearDrop)
		{
			return 0;
		}

		public void IncreaseDropRate(LootDropEntry.GearDrop additiveChances)
		{
		}

		public int GetRemapedRoundDropsToCurrentMap()
		{
			return 0;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

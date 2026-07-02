using System;
using BAPBAP.Maps;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Local
{
	public class EntityAssetsManager : MonoBehaviour
	{
		public enum EntityTypeEnum
		{
			Character = 0,
			Item = 1,
			Interactable = 2
		}

		[Serializable]
		public class EntityAsset
		{
			[Serializable]
			public class Settings
			{
				[Serializable]
				public class RandomSpawns
				{
					[Serializable]
					public class RandomEntity
					{
						[Range(0f, 1f)]
						public float spawnChance;

						public GameObject entityPrefab;
					}

					public RandomEntity[] entities;

					public GameObject GetRandomEntity()
					{
						return null;
					}
				}

				[Tooltip("Should this object be ommited from spawning in the map?")]
				public bool isVaulted;

				[Tooltip("If set to true, only the given percentage of all these prefabs in the map will spawn")]
				[Space(10f)]
				public bool doSpawnPercentage;

				[Tooltip("How many of the total prefabs will spawn in the map. 0 = none, 1 = all")]
				[Range(0f, 1f)]
				public float spawnPercentage;

				[Tooltip("Random chance of this entity to be spawned. 0 = 0% spawn chance, 1 = 100% spawn chance")]
				[Range(0f, 1f)]
				public float spawnChance;

				[Space(10f)]
				[Tooltip("If set to true, one of these random prefabs will be spawned. This spawnable asset settings might not persist")]
				public bool spawnRandomPrefabs;

				public RandomSpawns randomPrefabs;
			}

			[Serializable]
			public class Config
			{
				public string nameTranslationKey;

				[NonSerialized]
				public string nameLocalized;

				[SpriteVisualizer]
				[Header("UI Config")]
				public Sprite uiIcon;

				public Color iconColor;

				[Tooltip("Should apply current ui config (icon and color) to the spawned icons instances, even if overriden?")]
				public bool applyConfigToInstances;

				[Tooltip("Should create a minimap icon when spawned in the map? It will be sent to all clients, regardless of aoi.")]
				public bool createMinimapIcon;

				[Header("UI Override Config")]
				public GameObject minimapIconPrefab;

				public GameObject pingWorldPrefab;

				public GameObject pingUiPrefab;

				public GameObject pingMinimapPrefab;

				public GameObject GetMinimapPrefab()
				{
					return null;
				}

				public void InitializeMinimapInstance(UIMinimapIcon iconInstance)
				{
				}

				public GameObject GetPingWorldPrefab()
				{
					return null;
				}

				public void InitializePingWorldInstance(GameObject worldPingInstance)
				{
				}

				public GameObject GetPingUiPrefab()
				{
					return null;
				}

				public void InitializePingUIInstance(UIPingElement iconInstance)
				{
				}

				public GameObject GetPingMinimapPrefab()
				{
					return null;
				}

				public void InitializePingMinimapInstance(UIMinimapIcon iconInstance)
				{
				}
			}

			[Tooltip("The Entity Type for this entity")]
			public EntityTypeEnum entityType;

			[ExHeader("Asset Config", 1f, 1f, 0f)]
			[Space(5f)]
			public Config config;

			[Space(5f)]
			[ExHeader("Game Settings", 0f, 1f, 1f)]
			public Settings settings;
		}

		[Header("Custom Entity References")]
		[SerializeField]
		public GameObject spawnPointPrefab;

		[SerializeField]
		public GameObject dimensionSpawnPointPrefab;

		[SerializeField]
		public GameObject tombstonePrefab;

		[SerializeField]
		public PrefabConfig supplyDropEntityPrefab;

		[SerializeField]
		public PrefabConfig reviveAltarEntityPrefab;

		[SerializeField]
		public PrefabConfig reviveAltarDesertEntityPrefab;

		[SerializeField]
		public PrefabConfig itemEntityPrefab;

		[SerializeField]
		public PrefabConfig shopItemPingEntityPrefab;

		[SerializeField]
		public PrefabConfig territoryZonePrefab;

		[SerializeField]
		public PrefabConfig slimeBossEntityPrefab;

		[NonSerialized]
		public int itemEntityPrefabId;

		[NonSerialized]
		public int shopItemPingEntityPrefabId;

		[NonSerialized]
		public int supplyDropEntityPrefabId;

		[NonSerialized]
		public int reviveAltarEntityPrefabId;

		[NonSerialized]
		public int reviveAltarDesertEntityPrefabId;

		[NonSerialized]
		public int territoryZonePrefabId;

		public void PreAwake()
		{
		}

		public GameObject GetEntityPrefabFromPrefabId(int prefabId)
		{
			return null;
		}

		public bool TryGetConfigFromPrefabId(int prefabId, out PrefabConfig config)
		{
			config = null;
			return false;
		}
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Maps
{
	[ExecuteInEditMode]
	public class SerializedLevelHolder : MonoBehaviour
	{
		[Serializable]
		public class SerializedLevel
		{
			[Serializable]
			public class TilemapLayer
			{
				[Serializable]
				public struct SerializedTile
				{
					public int gridIndex;

					public int rotPrefabId;
				}

				public List<SerializedTile> tiles;
			}

			[SerializeField]
			[FormerlySerializedAs("serializedMapSettings")]
			public MapSettings mapSettings;

			[HideInInspector]
			public TilemapLayer serializedMapTiles;

			[HideInInspector]
			[FormerlySerializedAs("hideAreaGroups")]
			public TilemapLayer[] hideAreaTileGroups;

			[HideInInspector]
			[FormerlySerializedAs("ceilingGroups")]
			public TilemapLayer[] ceilingTileGroups;

			public void Reset()
			{
			}
		}

		[Serializable]
		public struct PrefabToId
		{
			public int prefabId;

			public GameObject prefab;
		}

		[SerializeField]
		public SerializedLevel _serializedLevel;

		[HideInInspector]
		public GameObject[] spawnPoints;

		[HideInInspector]
		public GameObject[] dimensionSpawnPoints;

		[HideInInspector]
		public Transform entityHolder;

		[HideInInspector]
		public Transform bakedCollidersHolder;

		[HideInInspector]
		public Transform objectHolder;

		[HideInInspector]
		public LevelHideAreaHolder[] hideAreaHolders;

		[HideInInspector]
		public Transform[] ceilingGroupObjHolders;

		[HideInInspector]
		[SerializeField]
		public PrefabToId[] prefabIdLibrary;

		public SerializedLevel serializedLevel => null;

		public void NewSerializedLevel()
		{
		}

		public void Serialize(LevelData levelData, AssetPalette assetPalette)
		{
		}

		public SerializedLevel.TilemapLayer.SerializedTile MapTileToSerializedTile(MapTile tile, Vector2Int pos, int width, AssetPalette assetPalette, Dictionary<int, GameObject> library)
		{
			return default(SerializedLevel.TilemapLayer.SerializedTile);
		}

		public SerializedLevel.TilemapLayer.SerializedTile SetSerializedTile(SerializedLevel.TilemapLayer.SerializedTile tile, AssetPalette assetPalette, Dictionary<int, GameObject> library)
		{
			return default(SerializedLevel.TilemapLayer.SerializedTile);
		}

		public void Deserialize(out LevelData levelTilemap, AssetPalette assetPalette)
		{
			levelTilemap = null;
		}
	}
}

using System;
using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public class MapVisualizer : MonoBehaviour
	{
		[Serializable]
		public class VisConfiguration
		{
			public int bakedChunkSize;

			public float fowUpdateRate;

			public Vector2Int fowUpdateSize;
		}

		public class LevelVisualizeData
		{
			public class VisObj
			{
				public GameObject instance;

				public ObjDataHolder data;
			}

			public class Layer
			{
				public VisObj[,] tilemap;

				public bool isBakedLayer;

				public BakedChunkTilemap bakedChunkTilemap;

				public void ForEachTile(Action<VisObj, Vector2Int> action)
				{
				}
			}

			public struct ObjDataHolder
			{
				public GameObject pivotVisualizer;

				public GameObject objCollider;

				public GameObject walkableVisualizer;
			}

			public class BakedChunkTilemap
			{
				public class BakedChunk
				{
					[NonSerialized]
					public Vector2Int tilemapStartPos;

					[NonSerialized]
					public MapLayer mapLayer;

					[NonSerialized]
					public List<Mesh> bakedMeshes;

					[NonSerialized]
					public GameObject currentBakedInstance;

					[NonSerialized]
					public Vector3 chunkWorldPos;

					public GameObject soloBakeResultObj;

					public BakedChunk(Vector2Int levelDataTilemapStartPos, MapLayer mapLayer)
					{
					}

					public void SetVisible(bool isVisible)
					{
					}

					public void Rebuild()
					{
					}

					public void BuildSoloViewObjIsolate(int soloPrefabId)
					{
					}

					public void ClearData()
					{
					}

					public LevelData BuildVisLevelData()
					{
						return null;
					}

					public GameObject BakeVisLevelData(LevelData chunkLevelData)
					{
						return null;
					}
				}

				public BakedChunk[,] bakedChunks;

				[NonSerialized]
				public List<Vector2Int> dirtyChunks;

				[NonSerialized]
				public Action setDirtyAction;

				public BakedChunkTilemap(int sizeX, int sizeY, MapLayer mapLayer, Action setDirtyAction)
				{
				}

				public BakedChunk GetChunk(Vector2Int tilemapPos)
				{
					return null;
				}

				public void SetVisible(bool isVisible)
				{
				}

				public void ClearAll()
				{
				}

				public void MarkAsDirtyOnPosition(Vector2Int tilemapPos)
				{
				}

				public void MarkChunkAsDirty(Vector2Int chunkId)
				{
				}

				public void TriggerRebuildDirty()
				{
				}

				public void TriggerRebuild()
				{
				}

				public void BuildSoloViewObjIsolate(int soloPrefabId)
				{
				}

				public void ClearSoloViewObjIsolate()
				{
				}
			}

			public Layer[] layers;

			public Vector2Int size;

			public HashSet<EditorEntityDataObjectHelper> entityDataObjHelperTrackingList;

			public LevelVisualizeData(int sizeX, int sizeY)
			{
			}

			public void ClearAll()
			{
			}
		}

		public static Dictionary<MapLayer, bool> BakeableLayers;

		public static LevelVisualizeData levelVisualizeData;

		public static bool tilemapBakeDirty;

		public static bool collidersEnabled;

		public static bool visualizePivots;

		public static bool visualizeWalkable;

		public static bool detailedView;

		public static bool hideGridInSimpleView;

		public static bool showVisibilitySettings;

		public static bool isSoloingObject;

		public static Transform visualizerRoot;

		public static Transform collidersRoot;

		public const int detailedViewLayer = 1;

		public static float fowUpdateTimer;

		public static Dictionary<MapLayer, bool> VisibleTilemapLayers;

		public static bool navMeshBaked;

		public static bool fowEnabled => false;

		public static Configuration Config => null;

		public static VisConfiguration visConfig => null;

		public static void InitializeVisualizer(Vector2Int size)
		{
		}

		public static void LoadVisualizer()
		{
		}

		public static void LoadlevelDataIntoVisualizer(LevelData levelData)
		{
		}

		public static void Update()
		{
		}

		public static void CleanUp()
		{
		}

		public static void SpawnTilePrefab(int prefabId, GameObject prefab, Vector2Int tilemapPos, int angle, MapLayer mapLayer, bool doPlaceAnim = true)
		{
		}

		public static void DeleteTilePrefab(int prefabId, Vector2Int tilemapPos, MapLayer mapLayer)
		{
		}

		public static GameObject SpawnPrefabGameObject(GameObject prefab, Vector3 worldPos, Vector3 angle, Vector3 scale)
		{
			return null;
		}

		public static void EnableVisualizePivots()
		{
		}

		public static void DisableVisualizePivots()
		{
		}

		public static void CreateVisualizerPivot(LevelVisualizeData.VisObj visObj, Vector3 worldPos, MapLayer mapLayer)
		{
		}

		public static void DeleteVisualizerPivot(LevelVisualizeData.VisObj visObj)
		{
		}

		public static void EnableVisualizeWalkable()
		{
		}

		public static void DisableVisualizeWalkable()
		{
		}

		public static GameObject CreateWalkableVisualizer(int tilemapX, int tilemapY, MapLayer mapLayer)
		{
			return null;
		}

		public static void DeleteWalkableVisualizerOnPos(Vector2Int tilemapPos, MapLayer mapLayer)
		{
		}

		public static void ToggleDetailedView()
		{
		}

		public static void EnableDetailedView()
		{
		}

		public static void DisableDetailedView()
		{
		}

		public static void CreateCollisionOnMapVisualizerObstacles()
		{
		}

		public static void CreateCollisionOnLayer(LevelData.Layer layer, LevelVisualizeData.Layer visLayer)
		{
		}

		public static GameObject InstantiateColliders(GameObject prefab, Vector3 worldPos, Vector3 angle, Vector3 scale, Transform parent)
		{
			return null;
		}

		public static void CopyBoxColliderProperties(BoxCollider sourceCollider, BoxCollider targetCollider)
		{
		}

		public static void CopyCapsuleColliderProperties(CapsuleCollider sourceCollider, CapsuleCollider targetCollider)
		{
		}

		public static void TryCreateFoWOnMapGameObject(GameObject objInstance, AssetPalette.PrefabData prefabData)
		{
		}

		public static void UpdateFoW()
		{
		}

		public static void SetEnabled(bool isEnabled)
		{
		}

		public static void DrawVisibilitySettingsGUI(bool onDock = false)
		{
		}

		public static void ResetVisibility(bool visibilityChanged = false)
		{
		}

		public static void SetMapLayersVisibility()
		{
		}

		public static void ShowAllInstancesOfObject(GameObject soloPrefab)
		{
		}

		public static void BakeNavMeshPreview()
		{
		}

		public static void ClearNavmesh()
		{
		}

		public static void ToggleCollidersStatic(bool isStatic)
		{
		}
	}
}

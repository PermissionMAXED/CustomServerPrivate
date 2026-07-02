using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using BAPBAP.Entities.HideArea;
using BAPBAP.Local;
using BAPBAP.Local.Rendering;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace BAPBAP.Maps
{
	public class LevelRuntimeManager : MonoBehaviour
	{
		public class CombineMeshesMat
		{
			public Material mat;

			public int renderingLayerMask;

			public List<CombineInstance> combineInstances;

			public CombineMeshesMat(Material mat, int renderingLayerMask, List<CombineInstance> combineInstances)
			{
			}
		}

		public class CombineInstanceData
		{
			public GameObject instance;

			public Matrix4x4 matrix;

			public int renderingLayerMask;

			public ShadowCastingMode shadowCastingMode;

			public CombineInstanceData(GameObject instance, Matrix4x4 meshMatrix, int renderingLayerMask, ShadowCastingMode shadowCastingMode)
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CLoadLevelCoroutine_003Ed__77 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public LevelRuntimeManager _003C_003E4__this;

			public string levelName;

			public bool isServerOnly;

			public bool isClientOnly;

			[NonSerialized]
			public SerializedLevelHolder _003CsvData_003E5__2;

			[NonSerialized]
			public SerializedLevelHolder _003CclData_003E5__3;

			[NonSerialized]
			public string _003CdirPath_003E5__4;

			[NonSerialized]
			public ResourceRequest _003CsvRequest_003E5__5;

			[NonSerialized]
			public ResourceRequest _003CclRequest_003E5__6;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLoadLevelCoroutine_003Ed__77(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public LevelDynamicLoadProcess levelDynamicLoad;

		[NonSerialized]
		public CeilingGroupManager ceilingGroupManager;

		[SerializeField]
		public NavMeshSurface navMeshSurface;

		[Header("Settings")]
		[SerializeField]
		public bool loadMapDynamic;

		[ConditionalHide("loadMapDynamic", true)]
		[SerializeField]
		public bool loadDynamicOnHost;

		[Min(4f)]
		[SerializeField]
		public int chunkSize;

		[SerializeField]
		[Tooltip("The maximum chunk levels to allow. Any objects larger than this level will be spawned in the map as is.")]
		[Min(1f)]
		public int maxChunkLevels;

		[Tooltip("A constant world unit margin for all map objects to allow to exceed their corresponding chunk bounds.")]
		[SerializeField]
		public Vector2 chunkObjBoundsMargin;

		[Header("Hide Areas")]
		[SerializeField]
		public float simplifiedColHeight;

		[Tooltip("Shrink hide area group compound colliders by this absolute amount")]
		[SerializeField]
		[Range(0f, 0.4f)]
		public float tileHideAreaColliderShrinkAmount;

		[Header("Rendering")]
		[SerializeField]
		[RenderingLayersMaskProperty]
		public int defaultRenderingLayerMask;

		[SerializeField]
		public ShadowCastingMode defaultShadowCastingMode;

		[SerializeField]
		[Header("General references")]
		public AssetPalette assetPalette;

		[SerializeField]
		public Material distortMaterial;

		[SerializeField]
		public GameObject hideAreaGroupPrefab;

		[SerializeField]
		public GameObject tallBushPrefab;

		[SerializeField]
		[Header("Instancing references")]
		public MeshInstanceRenderer instanceRenderer;

		[SerializeField]
		[Header("Fog Of War references")]
		public GameObject fowContainerPrefab;

		[SerializeField]
		public Mesh fowBoxMesh;

		[SerializeField]
		public Mesh fowCylinderMesh;

		[NonSerialized]
		public MapSettings levelSettings;

		[NonSerialized]
		public Vector2Int mapSize;

		[NonSerialized]
		public Vector2Int mapSizeHalf;

		[NonSerialized]
		public HideAreaGroup[] mapHideAreas;

		[NonSerialized]
		public PrefabConfig[] mapEntities;

		[NonSerialized]
		public Vector3[] spawnPoints;

		[NonSerialized]
		public Vector3[] dimensionSpawnPoints;

		[NonSerialized]
		public int chunkLevelCount;

		[NonSerialized]
		public Vector2Int chunkFirstLvlGridSize;

		[NonSerialized]
		public MapChunkLevels[] chunkLevels;

		[NonSerialized]
		public float biomeMapToMapUnitFactor;

		[NonSerialized]
		public Vector2Int biomeMapSize;

		[NonSerialized]
		public float ambienceMapToMapUnitFactor;

		[NonSerialized]
		public Vector2Int ambienceMapSize;

		[NonSerialized]
		public byte[][] biomeMap;

		[NonSerialized]
		public byte[][] surfaceMap;

		[NonSerialized]
		public byte[][] ambienceMap;

		[NonSerialized]
		public int[][] ceilingGroupMap;

		[NonSerialized]
		public LayerMask obstacleMask;

		[NonSerialized]
		public int obstaclesLayer;

		[NonSerialized]
		public int obstaclesNoFOWLayer;

		[NonSerialized]
		public int lowObstaclesLayer;

		[NonSerialized]
		public float halfsimplifiedColHeight;

		[NonSerialized]
		public List<Mesh> bakedMeshes;

		[NonSerialized]
		public bool isLoading;

		public static Action<bool, Vector2Int> OnLevelRuntimeManagerLoaded;

		[NonSerialized]
		public Stopwatch stopwatch;

		[NonSerialized]
		public Stopwatch stopwatchAll;

		[NonSerialized]
		public int step;

		[NonSerialized]
		public StringBuilder buildMapData;

		[NonSerialized]
		public StringBuilder chunkDebugData;

		[NonSerialized]
		public StringBuilder chunkDebugData2;

		[NonSerialized]
		public bool loadingLogs;

		[NonSerialized]
		public bool loadingMeshesLogs;

		public static LevelRuntimeManager LocalInstance;

		[NonSerialized]
		public StringBuilder combineDebugData;

		public bool IsLoading => false;

		public bool LoadMapDynamic => false;

		public int BaseChunkSize => 0;

		[Tooltip("The size of the first chunk grid level")]
		public Vector2Int ChunkFirstLvlGridSize => default(Vector2Int);

		public int ChunkLevelCount => 0;

		public MapChunkLevels[] ChunkLevels => null;

		public byte[][] SurfaceMap => null;

		public byte[][] AmbienceMap => null;

		public MapSettings MapSettings => null;

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public static bool GetLevelMMCache(string levelName, int levelId, out LevelMMCache levelMMCache)
		{
			levelMMCache = null;
			return false;
		}

		public void LoadLevel(string levelName, int levelId, bool isServerOnly, bool isClientOnly)
		{
		}

		[IteratorStateMachine(typeof(_003CLoadLevelCoroutine_003Ed__77))]
		public IEnumerator LoadLevelCoroutine(string levelName, int levelId, bool isServerOnly, bool isClientOnly)
		{
			return null;
		}

		public void SpawnLevel(string levelName, bool isServerOnly, bool isClientOnly, SerializedLevelHolder svData, SerializedLevelHolder clData)
		{
		}

		public void InitializeNavMeshPreBake(MapSettings mapSettings)
		{
		}

		public GameObject PreBakeMapChunksColliders(SerializedLevelHolder level)
		{
			return null;
		}

		public void BakeStaticChunkColliders(MapChunk mapChunk, Transform bakedChunk, bool createFoWOcclusion)
		{
		}

		public void ProcessMapEntities(SerializedLevelHolder levelData)
		{
		}

		public void InitializeMapData(SerializedLevelHolder levelData)
		{
		}

		public void BuildMapData(SerializedLevelHolder svData, SerializedLevelHolder clData)
		{
		}

		public void ProcessLevelTiles(SerializedLevelHolder clData)
		{
		}

		public void ProcessLevelGameObjects(SerializedLevelHolder svData, SerializedLevelHolder clData)
		{
		}

		public void ProcessMapRootTransform(Transform rootTr, Action<int, Vector2Int, CombineInstanceData> addStaticAction, Action<int, Vector2Int, GameObject> addInstantiatedAction)
		{
		}

		public void RecursiveProcessStaticTransform(Transform tr, Action<int, Vector2Int, CombineInstanceData> addAction)
		{
		}

		public void ProcessStaticTransform(Transform instance, Action<int, Vector2Int, CombineInstanceData> addAction)
		{
		}

		public void BuildHideAreaData(SerializedLevelHolder loadedMap)
		{
		}

		public void GetBakedColliders(SerializedLevelHolder mapData)
		{
		}

		public List<CombineInstanceData> GetPrefabCombineInstances(PrefabConfig prefabConfig, Vector3 worldPos, Vector3 euler, Vector3 scale)
		{
			return null;
		}

		public int GetChunkGridLevel(Transform transform)
		{
			return 0;
		}

		public bool ContainsNonStaticChildren(Transform tr)
		{
			return false;
		}

		public static bool IsStatic(Transform tr)
		{
			return false;
		}

		public void BuildSurfaceMap(SerializedLevelHolder loadedMap, Texture2D splatTexture = null)
		{
		}

		public void BuildCeilingGroupMap(SerializedLevelHolder loadedMap)
		{
		}

		public void BuildAmbienceMap(SerializedLevelHolder loadedMap)
		{
		}

		public Texture2D BuildBiomeAndSplatMap(SerializedLevelHolder levelHolder)
		{
			return null;
		}

		public static Vector2[] GetSpawnPointArrayV2(GameObject[] spawnPoints)
		{
			return null;
		}

		public static Vector3[] GetSpawnPointArray(GameObject[] spawnPoints)
		{
			return null;
		}

		public static Vector2[] GetDimensionSpawnPointArrayV2(GameObject[] dimensionSpawnPoints)
		{
			return null;
		}

		public static Vector3[] GetDimensionSpawnPointArray(GameObject[] dimensionSpawnPoints)
		{
			return null;
		}

		public void AssignEntityData(GameObject spawnedEntity, GameObject sourceEntity)
		{
		}

		public void AssignEntityData(GameObject spawnedEntity, IEntityDataProperty property)
		{
		}

		public void BakeAllMapChunks(MapChunkLevels[] chunkLevels, bool createMeshes)
		{
		}

		public GameObject LoadChunk(int chunkLevel, Vector2Int cPos, bool createMeshes)
		{
			return null;
		}

		public bool TryGetCIListByMatAndMask(List<CombineMeshesMat> combineMeshesMatList, Material mat, int renderingLayerMask, out List<CombineInstance> ciList)
		{
			ciList = null;
			return false;
		}

		public void BakeChunkMeshes(MapChunk mapChunk, Transform parentChunk)
		{
		}

		public CombineMeshesMat[] GetCombineMeshMatList(List<CombineInstanceData> combinePrefabInstanceList)
		{
			return null;
		}

		public GameObject CombineMeshes(CombineMeshesMat[] matMeshList, ShadowCastingMode shadowCastingMode = ShadowCastingMode.On)
		{
			return null;
		}

		public void OptimizeMesh(Mesh mesh)
		{
		}

		public void InstantiateStaticChunkColliders(MapChunk mapChunk, Transform bakedChunk, bool createFoWOcclusion)
		{
		}

		public bool CreateStaticLayerColliders(List<CombineInstanceData> obstacles, List<TiledColliderInstance> tiledColliders, LayerMask layer, out GameObject colObj)
		{
			colObj = null;
			return false;
		}

		public void CreateStaticCollidersFromInstance(GameObject instance, Vector3 worldPos, Vector3 rot, Vector3 scale, Transform rootColObj)
		{
		}

		public void CreateSimplifiedCollider(BoundsData col, GameObject colObj)
		{
		}

		public Transform GetRotatedColliderObj(int colObjRot, Transform rootColObj)
		{
			return null;
		}

		public Transform GetNewColliderObj(Vector3 euler, Transform parent)
		{
			return null;
		}

		public void CreateCapsuleCollider(CapsuleCollider sourceCollider, Vector2 worldPos, Quaternion rotation, Vector3 scale, GameObject colObj)
		{
		}

		public void InstantiateCeilingGroups(MapChunk mapChunk, Transform parentChunk)
		{
		}

		public void CreateInstantiatedObjects(MapChunk mapChunk, Transform parentChunk)
		{
		}

		public GameObject CreateInstantiatedObject(GameObject instanceObj, Transform parentTr)
		{
			return null;
		}

		public void CreateFloorCollider(Vector2 mapSize)
		{
		}

		public void InitializeNavMesh(string levelName, bool isClientOnly)
		{
		}

		public NavMeshData BakeNavMesh()
		{
			return null;
		}

		public void ClearNavMeshes()
		{
		}

		public void InitializeInstanceRenderer(string levelName, bool isClientOnly)
		{
		}

		public void CreateAllHideAreaGroups(HideAreaGroup[] hideAreas, bool generateMeshes)
		{
		}

		public Transform CreateHideArea(HideAreaGroup hideAreaGroup, bool generateMeshes, int id)
		{
			return null;
		}

		public void CreateTileHideArea(HideArea hideArea, TilePrefabInstance[] hideAreaTiles, bool generateMeshes)
		{
		}

		public Mesh GenerateHideAreaMesh(TilePrefabInstance[] tiles, Transform parent)
		{
			return null;
		}

		public void GenerateHideAreaColliders(TilePrefabInstance[] tiles, HideArea hideArea)
		{
		}

		public void CreateHolderHideArea(HideArea hideArea, LevelHideAreaHolder holder, bool generateMeshes)
		{
		}

		public void OnDestroy()
		{
		}

		public void CleanUpLevel()
		{
		}

		public void BuildNavMeshWithinBounds(Bounds bounds)
		{
		}

		public void UpdateNavMeshBounds(Bounds bounds)
		{
		}

		public void TriggerDinamicMapFullLoad()
		{
		}

		public int SampleBiomeMap(Vector2 worldPosition)
		{
			return 0;
		}

		public byte SampleSurfaceMap(Vector2 worldPosition)
		{
			return 0;
		}

		public int SampleCeilingGroupMap(Vector2 worldPosition)
		{
			return 0;
		}

		public AmbienceId SampleAmbience(Vector3 worldPosition)
		{
			return default(AmbienceId);
		}

		public AmbienceId SampleAmbience(int x, int y)
		{
			return default(AmbienceId);
		}

		public int GetSurfaceId(Vector3 worldPosition)
		{
			return 0;
		}

		public int GetCurrentBiomeId(Vector3 worldPosition)
		{
			return 0;
		}

		public string GetCurrentBiomeName(int currentBiomeId)
		{
			return null;
		}

		public int GetCeilingGroupId(Vector3 worldPosition)
		{
			return 0;
		}

		public int GetGroundSurfaceIdFromBiomeId(int biomeId)
		{
			return 0;
		}

		public int GetBushSurfaceIdFromBiomeId(int biomeId)
		{
			return 0;
		}

		public Vector3 GetMapNavMeshPosition(Vector3 position, float distance = 10f)
		{
			return default(Vector3);
		}

		public Vector3 GetMapNavMeshClosestEdge(Vector3 position)
		{
			return default(Vector3);
		}

		public Vector3 GetMapNavMeshPositionRadius(Vector3 position, float distance = 10f, float radius = 1f)
		{
			return default(Vector3);
		}

		public void OnCeilingGroupEnter(int ceilingGroupId)
		{
		}

		public void OnCeilingGroupExit(int ceilingGroupId)
		{
		}

		public void CreateMapWaterOuterEdgesObjects(SerializedLevelHolder levelData)
		{
		}
	}
}

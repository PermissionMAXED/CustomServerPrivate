using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Pooling;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Maps
{
	[CreateAssetMenu(fileName = "AssetPalette", menuName = "BAPBAP/Maps/AssetPalette", order = 1)]
	public class AssetPalette : ScriptableObject
	{
		[Serializable]
		public struct AssetEditorPrefab
		{
			public GameObject sourcePrefab;

			public GameObject editorVersion;
		}

		[Serializable]
		public class PrefabData
		{
			[Serializable]
			public class StaticMeshBakingCache
			{
				public MeshFilter meshFilter;

				public MeshRenderer meshRenderer;

				public int minSubmeshCount;
			}

			public StaticMeshBakingCache[] staticMeshCache;

			public PrefabConfig config;

			public PrefabData(GameObject prefab)
			{
			}
		}

		[Serializable]
		public class ElementGroup
		{
			public string name;

			public GameObject[] assets;

			public VariationAsset[] variationAssets;
		}

		[Serializable]
		public class Group
		{
			public string name;

			public AssetGroup[] groups;
		}

		[Serializable]
		public class AssetGroup
		{
			public string name;

			[Header("Ground Layer")]
			public AssetPaletteLayer assetListLayerGround;

			[Header("Obstacle Layer")]
			public AssetPaletteLayer assetListLayerObstacles;

			[Header("Decoration Layer")]
			public AssetPaletteLayer assetListLayerDecoration;

			[Header("Ceiling Layer")]
			public AssetPaletteLayer assetListLayerCeiling;

			public int LayerLength => 0;

			public AssetPaletteLayer Layer(int index)
			{
				return null;
			}

			public string LayerName(int index)
			{
				return null;
			}
		}

		[Serializable]
		public class AssetPaletteLayer
		{
			[FormerlySerializedAs("assetList")]
			public GameObject[] assetList;

			public VariationAsset[] variationAssets;

			[FormerlySerializedAs("tileableAssetList")]
			public AutotileAsset[] tileableAssetList;
		}

		public enum AssetType
		{
			Objects = 0,
			VariationAsset = 1,
			TilesetAsset = 2
		}

		[Serializable]
		public class AutotileAsset
		{
			public string name;

			public VariationAsset center;

			public VariationAsset sideTop;

			public VariationAsset sideRight;

			public VariationAsset sideBottom;

			public VariationAsset sideLeft;

			public VariationAsset innerTop;

			public VariationAsset innerRight;

			public VariationAsset innerBottom;

			public VariationAsset innerLeft;

			public VariationAsset outerTop;

			public VariationAsset outerRight;

			public VariationAsset outerBottom;

			public VariationAsset outerLeft;

			public VariationAsset outerJoin1;

			public VariationAsset outerJoin2;

			public GameObject[] compatibleAssets;

			public string[] compatibleAutotileAssetNames;

			[Min(0f)]
			public int minBushSizeIdAllowed;

			public List<GameObject> GetAllObjects()
			{
				return null;
			}

			public bool ContainsPrefab(GameObject prefab)
			{
				return false;
			}

			public VariationAsset GetVariationAssetFromPrefab(GameObject prefab)
			{
				return null;
			}
		}

		[Serializable]
		public class VariationAsset
		{
			[Serializable]
			public class ProceduralDecorationAsset
			{
				public bool randomizeRotation;

				[Range(0f, 1f)]
				[Tooltip("How likely the decoration is to appear. 0 mean none, 1 means always")]
				public float frequency;

				public GameObject[] assets;

				public GameObject GetProceduralDecorationTile()
				{
					return null;
				}
			}

			public enum VariationRuleType
			{
				None = 0,
				Contains4VarNeighbours = 1,
				DoesntContain4VarNeighbours = 2,
				Sequential = 3
			}

			[ObjectReferencesToString("assets", true, true)]
			public string name;

			[Tooltip("The asset variations will be automatically randomized when placing them")]
			public bool autoRandomizeVariation;

			[Tooltip("The assets will be automatically rotated randomly when placing them")]
			public bool autoRandomizeRotation;

			[Range(0f, 1f)]
			[Tooltip("The lesser the value, the less variation tiles will appear")]
			public float variationInfluence;

			[Tooltip("Decide to variate assets if the given rules are meet")]
			public VariationRuleType variationRuleType;

			public GameObject[] assets;

			public ProceduralDecorationAsset proceduralDecoration;

			public GameObject SelectObjectByVariationRule(MapTile[,] tilemapLayer, Vector2Int pos, AssetPalette assetPalette)
			{
				return null;
			}

			public Func<GameObject> ExecuteVariationRule(MapTile[,] tilemapLayer, Vector2Int pos, AssetPalette assetPalette)
			{
				return null;
			}

			public int Validate_ContainsPrevious(MapTile[,] tLayer, Vector2Int pos, AssetPalette assetPalette)
			{
				return 0;
			}

			public int ContainsPrevious(int rotPrefabId, AssetPalette assetPalette)
			{
				return 0;
			}

			public bool Validate_IfContains(MapTile[,] tLayer, Vector2Int pos, AssetPalette assetPalette)
			{
				return false;
			}

			public bool Validate_IfDoesntContain(MapTile[,] tilemapLayer, Vector2Int pos, AssetPalette assetPalette)
			{
				return false;
			}

			public bool ContainsVariation(int rotPrefabId, AssetPalette assetPalette)
			{
				return false;
			}

			public GameObject GetObjFromMapUtility()
			{
				return null;
			}

			public GameObject GetFirstObject()
			{
				return null;
			}

			public GameObject GetNextObject(int previousIndex)
			{
				return null;
			}
		}

		public const string StaticTag = "IsStatic";

		public const string DefaultTag = "Untagged";

		[Header("Content")]
		[Tooltip("Any entities or other elements used only for editor palette purposes. Entities are assigned automatically, so no need to assign all here.")]
		public ElementGroup[] assetElements;

		[Tooltip("All environment assets used for both editor palette and game. All environment assets need to be tracked in this list.")]
		public Group[] assetGroups;

		[Header("Level Editor")]
		public AssetEditorPrefab[] editorAssetVersion;

		[Header("References")]
		public BiomeData biomeData;

		public AmbienceData ambienceData;

		[Header("Other References")]
		public GameObject spawnPointPrefab;

		public GameObject dimensionSpawnPointPrefab;

		public NetworkPrefabLibrary networkPrefabLibrary;

		[Header("Data")]
		[BeginReadOnlyGroup]
		[ReadOnly]
		[SerializeField]
		public PrefabConfig[] entities;

		[SerializeField]
		[ReadOnly]
		public GameObject[] prefabIds;

		[ReadOnly]
		[SerializeField]
		public PrefabData[] prefabDatabyPrefabIds;

		[EndReadOnlyGroup]
		public Dictionary<GameObject, int> prefabToPrefabId;

		public Dictionary<string, MonoBehaviour> entityDataPropertyTypeByPropertyId;

		[NonSerialized]
		public bool initialized;

		[NonSerialized]
		public int spawnPointPrefabId;

		[NonSerialized]
		public int dimensionSpawnPointPrefabId;

		public bool TryGetEntityDataTypeByPropertyId(string propertyName, out MonoBehaviour type)
		{
			type = null;
			return false;
		}

		public void Initialize()
		{
		}

		public static void SetStaticState(GameObject gameObject, bool isStatic)
		{
		}

		public void BuildEntityDataTypeByIds()
		{
		}
	}
}

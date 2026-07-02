using System;
using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class LoadSave
	{
		public struct MapCombineData
		{
			public PrefabConfig prefabConfig;

			public GameObject prefabObj;

			public Vector3 pos;

			public Vector3 rot;

			public Vector3 scale;
		}

		public struct CombineMeshesInfo
		{
			public Material mat;

			public int renderingLayerMask;

			public CombineMeshesInfo(Material mat, int renderingLayerMask)
			{
				this.mat = null;
				this.renderingLayerMask = 0;
			}
		}

		public static Configuration Config => null;

		public static void LoadLevel(bool isMap, string levelFileName, string modulePath = "")
		{
		}

		public static void SaveLevel(bool isMap, string levelFilename, bool doQuickSave, int modBiomeId = -1, int modCategory = -1, int subModule = -1)
		{
		}

		public static void LoadSavedLevel(string levelName, string path, Action<SerializedLevelHolder> completed, bool unloadAfterComplete = true)
		{
		}

		public static void LoadLevelDataIntoLevelEditor(LevelData levelData)
		{
		}

		public static GameObject SpawnLevelDataIntoGameObject(LevelData levelData, bool combineInSingleSubmesh, string name = "", bool skipDetailedView = true)
		{
			return null;
		}

		public static List<MapCombineData> GetMapCombineDataFromLevelLayer(LevelData.Layer layer, Vector2Int levelSize)
		{
			return null;
		}

		public static GameObject SpawnSerializedLevelIntoGameObject(SerializedLevelHolder levelHolder, bool combineInSingleSubmesh, string name = "", bool skipDetailedView = true)
		{
			return null;
		}

		public static void GetMeshesFromMapCombineData(List<MapCombineData> mapCombineData, Dictionary<CombineMeshesInfo, List<CombineInstance>> matMeshes, bool skipDetailedView = true)
		{
		}

		public static GameObject CombineMapCombineDataMeshes(Dictionary<CombineMeshesInfo, List<CombineInstance>> matMeshes, string name, bool combineInSingleSubmesh)
		{
			return null;
		}
	}
}

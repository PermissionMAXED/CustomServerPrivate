using System.Diagnostics;
using System.Text;
using LevelEditor;
using UnityEngine;

namespace BAPBAP.Maps
{
	public static class LevelTextureMapUtility
	{
		public static Stopwatch stopwatch;

		public static StringBuilder debugData;

		public static bool showLogs;

		public static Configuration Config => null;

		public static Texture2D CreateAndSetBiomeMapTexOnShader(BiomeData biomeData, int[,] biomeMap, Vector2Int mapSize)
		{
			return null;
		}

		public static int[,] ForceSquare2DGrid(int[,] gridArray, int size)
		{
			return null;
		}

		public static void SetMapSplatMapOnShader(Texture2D splatMap)
		{
		}

		public static Texture2D GenerateBiomeMapTexSquare(int[,] biomeMap, int texMapSize, BiomeData biomeData)
		{
			return null;
		}

		public static int[,] GetBiomeMapFromGroundTexMap(Texture2D groundTex, BiomeData biomeData)
		{
			return null;
		}

		public static Texture2D GenerateBiomeTextureMapFromBiomePoints(Material distortMat, Vector2[] biomePointsNorm, Color[] colorsByBiome, Vector2 flowMapOffset, float flowMapIntensity, float flowMapScale, int texResolution, BiomeData biomeData)
		{
			return null;
		}

		public static void GenerateIslandTextureMap(Texture2D textureMap, AssetPalette assetPalette, Material distortMat, Vector2 flowMapOffset, int texResolution)
		{
		}

		public static void InvertSpatialHash(ref bool[,] spatialHash)
		{
		}

		public static void AddSpatialHashes(ref bool[,] hashA, bool[,] hashB)
		{
		}

		public static void SubstractSpatialHashes(ref bool[,] hashA, bool[,] hashB)
		{
		}

		public static void ExpandHashByAmount(bool[,] spatialHash, int amount)
		{
		}

		public static void ContractHashByAmount(bool[,] spatialHash, int amount)
		{
		}

		public static bool[,] TextureMapIntoSpatialHash(Texture2D textureMap, float threshold = 0.5f)
		{
			return null;
		}

		public static Texture2D SpatialHashIntoTextureMap(bool[,] spatialHash)
		{
			return null;
		}

		public static Texture2D SpatialHashIntoTextureMap(bool[,] spatialHash, Color emptyColor, Color fillColor)
		{
			return null;
		}

		public static Texture2D GridIntIntoTextureMap(int[,] grid, Color[] colorsByIndex = null)
		{
			return null;
		}

		public static GameObject DebugGridIntOnScene(int unitSize, int[,] grid, string name = "debug_tex", GameObject testObj = null, Color[] colorsByIndex = null)
		{
			return null;
		}

		public static GameObject DebugGridByteOnScene(int unitSize, byte[,] grid, string name = "debug_tex", GameObject testObj = null, Color[] colorsByIndex = null)
		{
			return null;
		}

		public static GameObject DebugSpatialHashOnScene(int unitSize, bool[,] hash, string name = "debug_tex", GameObject testObj = null)
		{
			return null;
		}

		public static GameObject DebugSpatialHashColorOnScene(int unitSize, bool[,] hash, Color emptyColor, Color filledColor, string name = "debug_tex", GameObject testObj = null)
		{
			return null;
		}

		public static GameObject DebugTextureMapOnScene(int unitSize, Texture2D tex, string name = "debug_tex", GameObject testObj = null)
		{
			return null;
		}

		public static bool IsAreaOnHash(ProceduralLevelGeneration.AreaPoint candidate, Vector2Int hashSize, bool[,] spatialHash)
		{
			return false;
		}

		public static void ApplyDistortionPass(bool[,] grid, Texture2D flowMapTex, float flowMapFrequency, float flowMapAmplitude, Vector2 flowTexOffset)
		{
		}

		public static void RepairIsolatedPixels(Texture2D biomeMap, int texResolution)
		{
		}

		public static void RepairIsolatedGridIds(int[,] idMap)
		{
		}

		public static void RepairIsolatedHashCells(bool[,] hashMap, Vector2Int size)
		{
		}

		public static void CreateWaterEdges(Texture2D tex, int unitSize, Color colorMaskValue)
		{
		}

		public static void GetEdgePixels(Color[] pixels, Color edgeColor, int edgeWidth, int unitSize)
		{
		}

		public static void GetFalloffEdgePixels(Color[] pixels, int edgeWidth, int unitSize)
		{
		}

		public static void BlitShaderToTexture(Texture2D tex, Material mat, int pass = 0)
		{
		}

		public static void SetDistortMaterialSettings(Material distortMat, Vector2 flowMapOffset, float flowMapIntensity = -1f, float flowMapScale = -1f)
		{
		}

		public static void SetBiomeGroundShaderSettings(Texture2D biomeColorMaskMap, BiomeData biomeData, int mapSize, bool doTransition)
		{
		}

		public static void SetBiomeGroundColorMapValuesToShader(int valueId, BiomeData.ColorMapValues colorMapValues)
		{
		}
	}
}

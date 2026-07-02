using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Maps
{
	public static class AreaTilemapSampling
	{
		public static bool SamplePoint(out Vector2Int sampledPos, ProceduralLevelGeneration.AreaPoint spawnPoint, ProceduralLevelGeneration.AreaPoint candidate, int minDensity, int maxDensity, bool[,] spatialHash, Vector2Int hashSize, int iterations = 10)
		{
			sampledPos = default(Vector2Int);
			return false;
		}

		public static bool IsValid(ProceduralLevelGeneration.AreaPoint candidate, Vector2Int hashSize, bool[,] spatialHash)
		{
			return false;
		}

		public static void BuildHashAllModulePoints(List<ProceduralLevelGeneration.ModulePoint> modulePoints, bool[,] spatialHash, int paddingAmount, Vector2Int tilemapSize)
		{
		}

		public static void BuildHashAllPoints(List<ProceduralLevelGeneration.AreaPoint> points, bool[,] spatialHash, int paddingAmount, Vector2Int tilemapSize)
		{
		}

		public static void BuildAreaHash(Vector2Int pointPos, Vector2Int pointSize, int paddingAmount, bool[,] spatialHash, Vector2Int tilemapSize)
		{
		}

		public static void BuildHashIsolateBiomeFill(int[,] biomeIdGrid, bool[,] spatialHash, int biomeIdToIsolate, int paddingAmount = 0)
		{
		}

		public static void BuildHashBiomeFill(int[,] biomeIdGrid, bool[,] spatialHash, int biomeIdToFill, int paddingAmount = 0)
		{
		}
	}
}

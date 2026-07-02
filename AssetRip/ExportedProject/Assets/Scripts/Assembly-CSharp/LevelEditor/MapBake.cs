using System;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class MapBake
	{
		public static Configuration Config => null;

		public static void PreBakeLevel(SerializedLevelHolder lvlHolder, Action onPrebakeFinished = null)
		{
		}

		public static void PreBakeData(SerializedLevelHolder lvlHolder)
		{
		}

		public static void PreBakeNavMesh(string fileName, SerializedLevelHolder lvlHolder)
		{
		}

		public static void SaveLevelMapScreenshot(string levelName, SerializedLevelHolder lvlHolder)
		{
		}

		public static LevelData GetMinimapWaterLevelData(SerializedLevelHolder levelHolder)
		{
			return null;
		}

		public static Texture2D RenderMapTexture(Camera cam, Vector2Int mapSize, int width, int height)
		{
			return null;
		}
	}
}

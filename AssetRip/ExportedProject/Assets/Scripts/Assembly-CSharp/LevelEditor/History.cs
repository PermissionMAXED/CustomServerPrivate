using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class History
	{
		public interface Step
		{
			void Execute(bool revert);
		}

		public class ActionSetTile : Step
		{
			public int prevRotatedTileId;

			public int rotatedTileId;

			public Vector2Int tilemapPos;

			public MapLayer layer;

			public ActionSetTile(int _prevRotatedTileId, int _rotatedTileId, Vector2Int _tilemapPos, MapLayer _layer)
			{
			}

			public void Execute(bool revert)
			{
			}
		}

		public class ActionMultipleSteps : Step
		{
			public Step[] steps;

			public ActionMultipleSteps(Step[] _steps)
			{
			}

			public void Execute(bool revert)
			{
			}
		}

		public class ActionBiomeMap : Step
		{
			public int[,] prevBm;

			public int[,] newBm;

			public ActionBiomeMap(int[,] prevBm, int[,] newBm)
			{
			}

			public void Execute(bool revert)
			{
			}
		}

		public class ActionAmbienceMap : Step
		{
			public byte[,] prevAm;

			public byte[,] newAm;

			public ActionAmbienceMap(byte[,] prevAm, byte[,] newAm)
			{
			}

			public void Execute(bool revert)
			{
			}
		}

		public static int maxSteps;

		public static int maxStepsAllowed;

		public static bool showHistorySettings;

		public static List<Step> history;

		public static int currentPosInHistory;

		public static bool multipleStepCacheEnabled;

		public static List<Step> multipleStepCache;

		public static void Initialize()
		{
		}

		public static void TryUndo()
		{
		}

		public static void TryRedo()
		{
		}

		public static void AddStepAddTileToHistory(int prevRotatedTileId, int newRotatedTileId, Vector2Int tilemapPos, MapLayer layer)
		{
		}

		public static void AddStepRemoveTileToHistory(int prevRotatedTileId, Vector2Int tilemapPos, MapLayer layer)
		{
		}

		public static void AddStepSplatPaint(Color[] prevPixels, Color[] newPixels, Texture2D texture)
		{
		}

		public static void AddStepBiomeMap(int[,] prevBm, int[,] newBm)
		{
		}

		public static void AddStepAmbienceMap(byte[,] prevAm, byte[,] newAm)
		{
		}

		public static void AddStepToHistory(Step step)
		{
		}

		public static void RevertStep(Step step)
		{
		}

		public static void RecreateStep(Step step)
		{
		}

		public static void ClearAllHistoryFromPos(int historyPos)
		{
		}

		public static void ClearOlderHistoryStep()
		{
		}

		public static void ClearHistory()
		{
		}

		public static void EnableMultipleStepCache(int cacheCapacity = 0)
		{
		}

		public static void DisableAndClearMultipleStepCache()
		{
		}

		public static void AddAndClearMultipleStepCacheToHistory()
		{
		}

		public static void HistoryGUI()
		{
		}
	}
}

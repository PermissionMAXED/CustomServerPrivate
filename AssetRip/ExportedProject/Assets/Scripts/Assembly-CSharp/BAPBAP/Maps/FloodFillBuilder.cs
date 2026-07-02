using System.Collections.Generic;

namespace BAPBAP.Maps
{
	public static class FloodFillBuilder
	{
		public delegate bool IsValid(Point p);

		public struct Point
		{
			public int x;

			public int y;

			public Point(int x, int y)
			{
				this.x = 0;
				this.y = 0;
			}
		}

		public static SerializedLevelHolder.SerializedLevel.TilemapLayer.SerializedTile[][] CreateFloodFillTileGroups(MapTile[,] tilemapLayer, IsValid validateAction)
		{
			return null;
		}

		public static List<Point> GetTilesFloodFill(int xStart, int yStart, int searchWidth, int searchHeight, IsValid validateAction)
		{
			return null;
		}
	}
}

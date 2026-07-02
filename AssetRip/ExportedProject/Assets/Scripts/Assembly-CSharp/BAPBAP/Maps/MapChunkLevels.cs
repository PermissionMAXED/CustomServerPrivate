using System;
using UnityEngine;

namespace BAPBAP.Maps
{
	[Serializable]
	public struct MapChunkLevels
	{
		public int chunkSize;

		public int halfChunkSize;

		public Vector2Int gridSize;

		public MapChunk[][] chunks;
	}
}

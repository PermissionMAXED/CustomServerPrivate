using UnityEngine;

namespace BAPBAP.Maps
{
	public struct HideAreaGroup
	{
		public TilePrefabInstance[] tilePrefabs;

		public LevelHideAreaHolder objHolder;

		public Vector2 worldPos;

		public Bounds bounds;
	}
}

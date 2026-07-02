using UnityEngine;

namespace PathCreation.Examples
{
	[ExecuteInEditMode]
	public class PathPlacer : PathSceneTool
	{
		public GameObject prefab;

		public GameObject holder;

		public float spacing;

		public const float minSpacing = 0.1f;

		public void Generate()
		{
		}

		public void DestroyObjects()
		{
		}

		public override void PathUpdated()
		{
		}
	}
}

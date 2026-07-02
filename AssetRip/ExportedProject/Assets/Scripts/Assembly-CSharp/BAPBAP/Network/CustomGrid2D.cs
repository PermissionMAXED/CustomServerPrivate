using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Network
{
	public struct CustomGrid2D<T>
	{
		public readonly Dictionary<Vector2Int, HashSet<T>> grid;

		[NonSerialized]
		public float resolution;

		public CustomGrid2D(int initialCapacity, float resolution)
		{
			grid = null;
			this.resolution = 0f;
		}

		public Vector2Int ProjectToGrid(Vector3 position)
		{
			return default(Vector2Int);
		}

		public void Add(Vector3 position3, T value)
		{
		}

		public void AddWithBounds(Vector3 position3, Vector3 halfBounds, T value)
		{
		}

		public void GetAt(Vector3 position3, HashSet<T> result)
		{
		}

		public void ClearNonAlloc()
		{
		}
	}
}

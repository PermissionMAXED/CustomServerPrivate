using UnityEngine;

namespace BAPBAP.Maps
{
	public struct BoundsData
	{
		public Vector3 center;

		public Vector3 size;

		public BoundsData(Vector3 center, Vector3 size)
		{
			this.center = default(Vector3);
			this.size = default(Vector3);
		}
	}
}

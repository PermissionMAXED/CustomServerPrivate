using UnityEngine;

namespace RuntimeGizmos
{
	public struct IntersectPoints
	{
		public Vector3 first;

		public Vector3 second;

		public IntersectPoints(Vector3 first, Vector3 second)
		{
			this.first = default(Vector3);
			this.second = default(Vector3);
		}
	}
}

using UnityEngine;

namespace RuntimeGizmos
{
	public static class ExtVector3
	{
		public static float MagnitudeInDirection(Vector3 vector, Vector3 direction, bool normalizeParameters = true)
		{
			return 0f;
		}

		public static Vector3 Abs(this Vector3 vector)
		{
			return default(Vector3);
		}

		public static bool IsParallel(Vector3 direction, Vector3 otherDirection, float precision = 0.0001f)
		{
			return false;
		}

		public static bool IsInDirection(Vector3 direction, Vector3 otherDirection)
		{
			return false;
		}
	}
}

using UnityEngine;

namespace RuntimeGizmos
{
	public static class ExtTransform
	{
		public static void SetScaleFrom(this Transform target, Vector3 worldPivot, Vector3 newScale)
		{
		}

		public static void SetScaleFromOffset(this Transform target, Vector3 worldPivot, Vector3 newScale)
		{
		}

		public static Vector3 GetCenter(this Transform transform, CenterType centerType)
		{
			return default(Vector3);
		}

		public static void GetCenterAll(this Transform transform, ref Bounds currentTotalBounds)
		{
		}
	}
}

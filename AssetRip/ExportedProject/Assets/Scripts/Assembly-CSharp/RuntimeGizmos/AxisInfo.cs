using UnityEngine;

namespace RuntimeGizmos
{
	public struct AxisInfo
	{
		public Vector3 pivot;

		public Vector3 xDirection;

		public Vector3 yDirection;

		public Vector3 zDirection;

		public void Set(Transform target, Vector3 pivot, TransformSpace space)
		{
		}

		public Vector3 GetXAxisEnd(float size)
		{
			return default(Vector3);
		}

		public Vector3 GetYAxisEnd(float size)
		{
			return default(Vector3);
		}

		public Vector3 GetZAxisEnd(float size)
		{
			return default(Vector3);
		}

		public Vector3 GetAxisEnd(Vector3 direction, float size)
		{
			return default(Vector3);
		}
	}
}

using UnityEngine;

namespace Highlighters
{
	public static class RenderingBounds
	{
		public static bool CloseEnughToRenderFullScreen(Camera camera, Vector3 center, float maxDistance, float minDistance)
		{
			return false;
		}

		public static Vector4 CalculateBounds(Camera camera, Vector3 extents, Vector3 center, Vector4 renderingBounds, float sizeIncrease)
		{
			return default(Vector4);
		}
	}
}

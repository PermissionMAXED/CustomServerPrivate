using UnityEngine;

namespace CatlikeCoding.SDFToolkit
{
	public static class SDFTextureGenerator
	{
		public class Pixel
		{
			public float alpha;

			public float distance;

			public Vector2 gradient;

			public int dX;

			public int dY;
		}

		public static int width;

		public static int height;

		public static Pixel[,] pixels;

		public static void Generate(Texture2D source, Texture2D destination, float maxInside, float maxOutside, float postProcessDistance, RGBFillMode rgbMode)
		{
		}

		public static void ComputeEdgeGradients()
		{
		}

		public static float ApproximateEdgeDelta(float gx, float gy, float a)
		{
			return 0f;
		}

		public static void UpdateDistance(Pixel p, int x, int y, int oX, int oY)
		{
		}

		public static void GenerateDistanceTransform()
		{
		}

		public static void PostProcess(float maxDistance)
		{
		}
	}
}

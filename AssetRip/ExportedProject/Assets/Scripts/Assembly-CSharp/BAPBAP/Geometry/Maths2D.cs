using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace BAPBAP.Geometry
{
	public static class Maths2D
	{
		[BurstCompile]
		public struct PointInTriangleJob : IJobParallelFor
		{
			public NativeArray<float3>.ReadOnly vertices;

			public NativeArray<int>.ReadOnly triangles;

			public float2 point;

			public NativeArray<bool> result;

			public void Execute(int index)
			{
			}
		}

		public static Vector2 ToXZ(this Vector3 v3)
		{
			return default(Vector2);
		}

		public static float PseudoDistanceFromPointToLine(Vector2 a, Vector2 b, Vector2 c)
		{
			return 0f;
		}

		public static int SideOfLine(Vector2 a, Vector2 b, Vector2 c)
		{
			return 0;
		}

		public static int SideOfLine(float ax, float ay, float bx, float by, float cx, float cy)
		{
			return 0;
		}

		public static bool LineSegmentsIntersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
		{
			return false;
		}

		public static bool PointInTriangle(Vector2 a, Vector2 b, Vector2 c, Vector2 p)
		{
			return false;
		}

		public static void Swap<T>(ref T lhs, ref T rhs)
		{
		}

		public static bool Approximately(float a, float b, float tolerance = 1E-05f)
		{
			return false;
		}

		public static float CrossProduct2D(Vector2 a, Vector2 b)
		{
			return 0f;
		}

		public static bool IntersectLineSegments2D(Vector2 p1start, Vector2 p1end, Vector2 p2start, Vector2 p2end, out Vector2 intersection)
		{
			intersection = default(Vector2);
			return false;
		}

		public static bool PlanarMeshContainsPoint(float3[] vertices, int[] triangles, Vector2 point)
		{
			return false;
		}
	}
}

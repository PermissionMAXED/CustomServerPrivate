using System;
using System.Collections.Generic;
using BAPBAP.Geometry;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class ShapeUtils
{
	public struct ShapesToMeshSettings
	{
		public bool RestoreBoundary;

		public bool FillVertexColors;

		public Color FillColor;

		public bool BoundaryVertexColors;

		public Color BoundaryColor;

		public int UVSize;

		public bool RefineMesh;

		public float Area;

		public float Radians;

		public string MeshName;

		public bool XY;

		public bool OffsetUpByPointOffset;

		public ShapesToMeshSettings(bool restoreBoundary, bool refineMesh, bool fillVertexColors, Color fillColor, bool boundaryVertexColors, Color boundaryColor, int uvSize, float area, float radians, string meshName, bool offsetUpByPointOffset, bool xy = false)
		{
			RestoreBoundary = false;
			FillVertexColors = false;
			FillColor = default(Color);
			BoundaryVertexColors = false;
			BoundaryColor = default(Color);
			UVSize = 0;
			RefineMesh = false;
			Area = 0f;
			Radians = 0f;
			MeshName = null;
			XY = false;
			OffsetUpByPointOffset = false;
		}
	}

	[BurstCompile]
	public struct MergeCloseVerticesJob : IJobParallelFor
	{
		public NativeArray<float3>.ReadOnly SourceVerticesReadOnly;

		public NativeArray<float3> MergedVertices;

		public float Tolerance;

		public void Execute(int index)
		{
		}
	}

	[BurstCompile]
	public struct ProjectOntoMeshFilter : IJobParallelFor
	{
		public NativeArray<float3>.ReadOnly SourceVerticesReadOnly;

		public NativeArray<int>.ReadOnly SourceTrianglesReadOnly;

		public NativeArray<float3>.ReadOnly TargetVerticesReadOnly;

		public NativeArray<Color> TargetVertexColors;

		public Color VertexColor;

		public float Strength;

		public void Execute(int index)
		{
		}

		public static bool PointInsideTriangle(float2 p, float2 a, float2 b, float2 c)
		{
			return false;
		}

		public static float3 Barycentric(float2 a, float2 b, float2 c, float2 p)
		{
			return default(float3);
		}

		public static float Cross(float2 a, float2 b)
		{
			return 0f;
		}
	}

	[Serializable]
	public class VertexColorSource
	{
		public Color color;

		public MeshFilter meshFilter;

		public float strength;
	}

	public static NativeArray<float2> positions;

	public static NativeArray<float2> holeSeeds;

	public static NativeArray<int> constraints;

	public static Mesh ShapesToMesh(List<Shape> shapesToProcess, ShapesToMeshSettings settings)
	{
		return null;
	}

	public static Mesh OffsetUpByPointOffset(List<Shape> shapes, Mesh mesh)
	{
		return null;
	}

	public static float Angle(float2 a, float2 b)
	{
		return 0f;
	}

	public static float Cross(float2 a, float2 b)
	{
		return 0f;
	}

	public static bool ShapesToPositions(List<Shape> shapesToProcess)
	{
		return false;
	}

	public static Mesh TriangulateShape(ShapesToMeshSettings settings)
	{
		return null;
	}

	public static Mesh ExtrudeMesh(List<Shape> shapes, float height, ShapesToMeshSettings settings)
	{
		return null;
	}

	public static Mesh ExtrudeShape(Shape shape, float height, ShapesToMeshSettings settings)
	{
		return null;
	}

	public static bool GetClipRanges(List<Shape.PointData> points, List<(int, int)> ranges, out List<List<Shape.PointData>> clipPositions)
	{
		clipPositions = null;
		return false;
	}

	public static Mesh OffsetMeshUp(Mesh mesh, Vector3 up, float offset)
	{
		return null;
	}

	public static float2[] TriangulatorOutput(float longestEdgeAngle, ShapesToMeshSettings settings, out int[] tri, out Vector2[] uv, out Vector3[] normals)
	{
		tri = null;
		uv = null;
		normals = null;
		return null;
	}

	public static List<ShapeCreator.Edge> FindBoundaryEdges(int[] triangles)
	{
		return null;
	}

	public static void MergeCloseVertices(Mesh mesh, float tolerance)
	{
	}

	public static Color[] GetVertexColors(MeshFilter meshFilter, List<VertexColorSource> sources)
	{
		return null;
	}
}

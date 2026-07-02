using System.Collections.Generic;
using UnityEngine;

public static class OutlineNormalsCalculator
{
	public class CospatialVertex
	{
		public Vector3 position;

		public Vector3 accumulatedNormal;
	}

	public static float cospatialVertexDistance;

	public static void CalculateOutlineNormals(Mesh sourceMesh, float _cospatialVertexDistance = 0.01f)
	{
	}

	public static void FindCospatialVertices(Vector3[] vertices, int[] indices, List<CospatialVertex> registry)
	{
	}

	public static bool SearchForPreviouslyRegisteredCV(Vector3 position, List<CospatialVertex> registry, out int index)
	{
		index = default(int);
		return false;
	}

	public static void ComputeNormalAndWeights(Vector3 a, Vector3 b, Vector3 c, out Vector3 normal, out Vector3 weights)
	{
		normal = default(Vector3);
		weights = default(Vector3);
	}

	public static void AddWeightedNormal(Vector3 weightedNormal, int vertexIndex, int[] cvIndices, List<CospatialVertex> cvRegistry)
	{
	}
}

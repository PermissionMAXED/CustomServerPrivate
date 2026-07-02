using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Geometry
{
	public class SpawnAreaShapeCreator : ShapeCreator
	{
		public enum PointGenerationType
		{
			VertexBased = 0,
			CirclePacking = 1,
			GridBased = 2
		}

		public bool generate;

		public GameObject[] prefabs;

		public PointGenerationType pointGenerationType;

		[Range(0.25f, 50f)]
		public float area;

		[Range(7.5f, 50f)]
		public float radians;

		[Min(0f)]
		public float circlePackMaxRadius;

		[Min(0f)]
		public float circlePackMinRadius;

		public float circlePackMinDistance;

		public float gridOffsetX;

		public float gridOffsetZ;

		public float gridSpacing;

		public bool includeBoundary;

		[Range(-1f, 256f)]
		public int maxInstances;

		public bool randomizeRotation;

		public Vector3 rotationRange;

		public bool randomizeScale;

		public Vector2 scaleRange;

		public bool randomizeOffset;

		public Vector2 offsetRange;

		[Range(0f, 1f)]
		public float chanceToSpawn;

		[NonSerialized]
		public List<Vector3> spawnLocations;

		[NonSerialized]
		public List<float> spawnRadii;

		public override void UpdateShapeDisplay(bool fullRefresh = true)
		{
		}

		public void DestroyAllChildren()
		{
		}

		public void SpawnOnMesh(Mesh mesh)
		{
		}

		public void CirclePack(List<Vector3> candidatePositions, int circlePackMaxAttempts, int circlePackMaxInstances, List<float> prefabBounds, out List<int> prefabIndices)
		{
			prefabIndices = null;
		}

		public void SpawnOnGrid()
		{
		}

		public void SpawnInstance(GameObject prefab, Vector3 position, float radii, float bounds)
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}

using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.Geometry
{
	public class AreaFillShapeCreator : MeshShapeCreator
	{
		public bool generate;

		public GameObject[] prefabs;

		public bool randomizeRotation;

		public Vector2 rotationRange;

		public bool randomizeScale;

		public Vector2 scaleRange;

		[Range(1f, 256f)]
		public int maxInstances;

		public bool checkForCollisions;

		[FormerlySerializedAs("collisionCheckRadius")]
		public float collisionCheckBoundsMultiplier;

		[Min(0.1f)]
		public float collisionIterationRadius;

		[Min(1f)]
		public int collisionIterations;

		public LayerMask layersMask;

		[NonSerialized]
		public Collider[] colliderBuffer;

		public override void UpdateShapeDisplay(bool fullRefresh = true)
		{
		}
	}
}

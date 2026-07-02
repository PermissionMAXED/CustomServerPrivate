using System;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP
{
	public class PathMeshGenerate : PathSceneTool
	{
		[SerializeField]
		[Header("References")]
		public GameObject meshHolder;

		[Header("Road Settings")]
		[SerializeField]
		public float roadWidth;

		[SerializeField]
		public bool createSides;

		[ConditionalHide("createSides", true)]
		[SerializeField]
		[Range(0f, 0.5f)]
		public float thickness;

		[SerializeField]
		[ConditionalHide("createSides", true)]
		public bool createUnder;

		[SerializeField]
		public bool flattenSurface;

		[SerializeField]
		public UnityEvent onRebuild;

		[NonSerialized]
		public MeshFilter meshFilter;

		[NonSerialized]
		public Mesh mesh;

		[NonSerialized]
		public int[] triangleMap;

		[NonSerialized]
		public int[] sidesTriangleMap;

		public override void PathUpdated()
		{
		}

		public void CreateAndAssignPath(VertexPath path)
		{
		}

		public void SetUpMeshObject()
		{
		}

		public Mesh GenerateMesh(VertexPath path, Mesh mesh = null)
		{
			return null;
		}
	}
}

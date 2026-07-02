using System;
using UnityEngine;

namespace PathCreation.Examples
{
	public class RoadMeshCreator : PathSceneTool
	{
		[Header("Road settings")]
		public float roadWidth;

		[Range(0f, 0.5f)]
		public float thickness;

		public bool flattenSurface;

		[Header("Material settings")]
		public Material roadMaterial;

		public Material undersideMaterial;

		public float textureTiling;

		[SerializeField]
		[HideInInspector]
		public GameObject meshHolder;

		[NonSerialized]
		public MeshFilter meshFilter;

		[NonSerialized]
		public MeshRenderer meshRenderer;

		[NonSerialized]
		public Mesh mesh;

		public override void PathUpdated()
		{
		}

		public void CreateRoadMesh()
		{
		}

		public void AssignMeshComponents()
		{
		}

		public void AssignMaterials()
		{
		}
	}
}

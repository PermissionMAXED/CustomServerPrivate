using System;
using System.Collections.Generic;
using BAPBAP.AssetContainer;
using UnityEngine;

namespace BAPBAP.Geometry
{
	[RequireComponent(typeof(MeshRenderer))]
	[RequireComponent(typeof(MeshFilter))]
	[ExecuteInEditMode]
	public class MeshShapeCreator : ShapeCreator, IGeneratedLevelAsset
	{
		[Serializable]
		public class CustomUVPosition
		{
			public Vector2 customUVPosition;
		}

		[HideInInspector]
		[SerializeField]
		public bool bakeable;

		[HideInInspector]
		[SerializeField]
		public MeshFilter meshFilter;

		[HideInInspector]
		[SerializeField]
		public bool restoreBoundary;

		[HideInInspector]
		[SerializeField]
		public bool refineMesh;

		[SerializeField]
		[HideInInspector]
		public float area;

		[HideInInspector]
		[SerializeField]
		public float radians;

		[HideInInspector]
		[SerializeField]
		public bool boundaryVertexColors;

		[HideInInspector]
		[SerializeField]
		public Color boundaryColor;

		[HideInInspector]
		[SerializeField]
		public bool fillVertexColors;

		[SerializeField]
		[HideInInspector]
		public Color fillColor;

		[HideInInspector]
		[SerializeField]
		public float allExtrude;

		[HideInInspector]
		[SerializeField]
		public bool offsetToExtrusion;

		[HideInInspector]
		[SerializeField]
		public bool useCustomUVPosition;

		[HideInInspector]
		[SerializeField]
		public CustomUVPosition customUVPosition;

		[HideInInspector]
		[SerializeField]
		public Vector2 customUVSize;

		[HideInInspector]
		[SerializeField]
		public bool offsetUpByPointOffset;

		[HideInInspector]
		[SerializeField]
		public bool bakeToNavMesh;

		[HideInInspector]
		[SerializeField]
		public bool bakeToNavMeshNonWalkable;

		[SerializeField]
		[HideInInspector]
		public int uvSize;

		[HideInInspector]
		public List<ShapeUtils.VertexColorSource> vertexColorSources;

		[NonSerialized]
		[NonSerialized]
		public Owner owner;

		[NonSerialized]
		[NonSerialized]
		public MeshAssetContainer container;

		public Owner Owner => null;

		public MeshAssetContainer Container => null;

		public virtual bool IsBaked => false;

		public override void OnEnable()
		{
		}

		public override void Start()
		{
		}

		public virtual void OnRequestBakeProcesses(Dictionary<MeshAssetContainer, List<MeshFilter>> bakeProcesses)
		{
		}

		public override void OnDisable()
		{
		}

		public virtual void Unbake(bool deleteAsset = true)
		{
		}

		public void BakeToNavMesh(int layer, int area)
		{
		}

		public void OnNavMeshBuildStart()
		{
		}

		public void OnNavMeshBuildEnd()
		{
		}

		public override void UpdateShapeDisplay(bool fullRefresh = true)
		{
		}

		public List<Shape> ResampleSplines(List<Shape> allShapes)
		{
			return null;
		}

		public ShapeUtils.ShapesToMeshSettings GetShapesToMeshSettings()
		{
			return default(ShapeUtils.ShapesToMeshSettings);
		}

		public List<Shape> GetValidShapes()
		{
			return null;
		}
	}
}

using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Geometry
{
	[ExecuteInEditMode]
	public class ConnectedGraphShapeCreator : MeshShapeCreator
	{
		public Color AsphaltVertexColor;

		public Color DirtVertexColor;

		public Color SandVertexColor;

		[Range(0.01f, 1f)]
		public float vScale;

		[Range(0f, 1f)]
		public float intersectionHalf;

		public int intersectionUVScale;

		public Color GroundBlendVertexColor;

		public bool GenerateMesh;

		public override void UpdateShapeDisplay(bool fullRefresh = true)
		{
		}

		public void CreateRoadMesh(Shape shape, out Mesh mesh)
		{
			mesh = null;
		}

		public void CreateIntersectionMesh(List<Vector3> hull, List<Shape.GraphType> types, out Mesh mesh)
		{
			mesh = null;
		}
	}
}

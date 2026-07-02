using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Geometry
{
	[ExecuteInEditMode]
	public class StructureCreator : MonoBehaviour
	{
		public MeshShapeCreator baseShape;

		[Min(1f)]
		public float wallHeight;

		public List<MeshShapeCreator> walls;

		public List<MeshShapeCreator> roofs;

		[SerializeField]
		[InspectorButton("UpdateStructure")]
		public bool updateStructure;

		public void UpdateStructure()
		{
		}

		public void CreateWalls()
		{
		}

		public void CreateRoofs()
		{
		}

		public void DeleteAllRoofs()
		{
		}

		public void DeleteAllWalls()
		{
		}
	}
}

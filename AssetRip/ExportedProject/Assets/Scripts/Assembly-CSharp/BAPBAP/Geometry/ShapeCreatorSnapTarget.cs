using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Geometry
{
	[ExecuteInEditMode]
	public class ShapeCreatorSnapTarget : MonoBehaviour
	{
		[NonSerialized]
		public MeshFilter meshFilter;

		public bool maskSnapPointsByVertexColor;

		public Color snapPointColor;

		[NonSerialized]
		[NonSerialized]
		public List<Vector3> snapPoints;

		public List<Vector3> GetSnapPoints()
		{
			return null;
		}
	}
}

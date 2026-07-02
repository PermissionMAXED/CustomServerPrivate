using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class MultiQuadImage : Image
	{
		[NonSerialized]
		public Vector2 _quadSize;

		[NonSerialized]
		public List<Vector3> _positions;

		[NonSerialized]
		public List<float> _rotations;

		[NonSerialized]
		public List<Vector4> _uvs;

		[NonSerialized]
		public List<Color> _colours;

		[NonSerialized]
		public List<float> _scales;

		public void SetQuadSize(Vector2 size)
		{
		}

		public void SetQuadBuffers(List<Vector3> positions, List<float> rotations = null, List<Vector4> uvs = null, List<Color> colours = null, List<float> scales = null)
		{
		}

		public override void OnPopulateMesh(VertexHelper vh)
		{
		}
	}
}

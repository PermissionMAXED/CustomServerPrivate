using System;
using Dreamteck.Splines;
using UnityEngine;

public class SplineVertexPainter : SplineUser
{
	[SerializeField]
	[HideInInspector]
	public float radius;

	[HideInInspector]
	[SerializeField]
	public Color vertexColor;

	[SerializeField]
	[HideInInspector]
	public bool invert;

	[SerializeField]
	[HideInInspector]
	public bool fillMode;

	[NonSerialized]
	public SplineSample _result;

	public void ProjectOntoMeshFilterVertexColors(MeshFilter[] meshFilters)
	{
	}
}

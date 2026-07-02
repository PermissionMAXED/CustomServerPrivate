using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class SplineColliderCreator : SplineUser
{
	[SerializeField]
	[HideInInspector]
	public Vector3 Offset;

	[SerializeField]
	[HideInInspector]
	public float Expand;

	[SerializeField]
	[HideInInspector]
	public float WallWidth;

	[HideInInspector]
	[SerializeField]
	public float WallHeight;

	[SerializeField]
	[HideInInspector]
	public int Layer;

	[SerializeField]
	[HideInInspector]
	public bool GenerateMeshOnNavBake;

	[SerializeField]
	[HideInInspector]
	public List<Collider> _colliders;

	[NonSerialized]
	public Vector3 _trsRight;

	[NonSerialized]
	public Vector3 _trsUp;

	[NonSerialized]
	public Vector3 _trsForward;

	[NonSerialized]
	public Vector3[] _vertices;

	public Vector3 OffsetWithHeight => default(Vector3);

	public override void OnEnable()
	{
	}

	public void SetHideFlags()
	{
	}

	public override void OnDisable()
	{
	}

	public void SetShowMesh()
	{
	}

	public void Generate()
	{
	}

	public void GenerateColliders(Vector3[] vertices)
	{
	}

	public bool IsClockwise(Vector2[] points2D)
	{
		return false;
	}

	public override void Build()
	{
	}

	public void OnDrawGizmos()
	{
	}

	public void DrawConnectingLines(Vector3 startSphere, Vector3 endSphere, Vector3 offset1, Vector3 offset2, float radius)
	{
	}
}

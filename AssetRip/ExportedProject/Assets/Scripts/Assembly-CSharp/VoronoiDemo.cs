using System;
using System.Collections.Generic;
using Delaunay.Geo;
using UnityEngine;

public class VoronoiDemo : MonoBehaviour
{
	[SerializeField]
	public int m_pointCount;

	[NonSerialized]
	public List<Vector2> m_points;

	[NonSerialized]
	public float m_mapWidth;

	[NonSerialized]
	public float m_mapHeight;

	[NonSerialized]
	public List<LineSegment> m_edges;

	[NonSerialized]
	public List<LineSegment> m_spanningTree;

	[NonSerialized]
	public List<LineSegment> m_delaunayTriangulation;

	public void Awake()
	{
	}

	public void Update()
	{
	}

	public void Demo()
	{
	}

	public void OnDrawGizmos()
	{
	}
}

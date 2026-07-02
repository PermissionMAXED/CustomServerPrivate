using System;
using System.Collections.Generic;
using Delaunay.Geo;
using Delaunay.LR;
using UnityEngine;

namespace Delaunay
{
	public sealed class Edge
	{
		public static Stack<Edge> _pool;

		public static int _nedges;

		public static readonly Edge DELETED;

		public float a;

		public float b;

		public float c;

		[NonSerialized]
		public Vertex _leftVertex;

		[NonSerialized]
		public Vertex _rightVertex;

		[NonSerialized]
		public Dictionary<Side, Vector2?> _clippedVertices;

		[NonSerialized]
		public Dictionary<Side, Site> _sites;

		[NonSerialized]
		public int _edgeIndex;

		public Vertex leftVertex => null;

		public Vertex rightVertex => null;

		public Dictionary<Side, Vector2?> clippedEnds => null;

		public bool visible => false;

		public Site leftSite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Site rightSite
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public static Edge CreateBisectingEdge(Site site0, Site site1)
		{
			return null;
		}

		public static Edge Create()
		{
			return null;
		}

		public LineSegment DelaunayLine()
		{
			return null;
		}

		public LineSegment VoronoiEdge()
		{
			return null;
		}

		public Vertex Vertex(Side leftRight)
		{
			return null;
		}

		public void SetVertex(Side leftRight, Vertex v)
		{
		}

		public bool IsPartOfConvexHull()
		{
			return false;
		}

		public float SitesDistance()
		{
			return 0f;
		}

		public static int CompareSitesDistances_MAX(Edge edge0, Edge edge1)
		{
			return 0;
		}

		public static int CompareSitesDistances(Edge edge0, Edge edge1)
		{
			return 0;
		}

		public Site Site(Side leftRight)
		{
			return null;
		}

		public void Dispose()
		{
		}

		public void Init()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public void ClipVertices(Rect bounds)
		{
		}
	}
}

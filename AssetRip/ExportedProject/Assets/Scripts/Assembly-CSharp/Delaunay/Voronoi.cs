using System;
using System.Collections.Generic;
using Delaunay.Geo;
using Delaunay.Utils;
using UnityEngine;

namespace Delaunay
{
	public sealed class Voronoi : Delaunay.Utils.IDisposable
	{
		[NonSerialized]
		public SiteList _sites;

		[NonSerialized]
		public Dictionary<Vector2, Site> _sitesIndexedByLocation;

		[NonSerialized]
		public List<Triangle> _triangles;

		[NonSerialized]
		public List<Edge> _edges;

		[NonSerialized]
		public Rect _plotBounds;

		[NonSerialized]
		public Site fortunesAlgorithm_bottomMostSite;

		public Rect plotBounds => default(Rect);

		public void Dispose()
		{
		}

		public Voronoi(List<Vector2> points, List<uint> colors, Rect plotBounds)
		{
		}

		public void Init(List<Vector2> points, Rect plotBounds)
		{
		}

		public void LloydRelaxation(int nbIterations, Rect plotBounds)
		{
		}

		public void AddSites(List<Vector2> points, List<uint> colors)
		{
		}

		public void AddSite(Vector2 p, uint color, int index)
		{
		}

		public List<Edge> Edges()
		{
			return null;
		}

		public List<Vector2> Region(Vector2 p)
		{
			return null;
		}

		public List<Vector2> NeighborSitesForSite(Vector2 coord)
		{
			return null;
		}

		public List<Circle> Circles()
		{
			return null;
		}

		public List<LineSegment> VoronoiBoundaryForSite(Vector2 coord)
		{
			return null;
		}

		public List<LineSegment> DelaunayLinesForSite(Vector2 coord)
		{
			return null;
		}

		public List<LineSegment> VoronoiDiagram()
		{
			return null;
		}

		public List<LineSegment> DelaunayTriangulation()
		{
			return null;
		}

		public List<LineSegment> Hull()
		{
			return null;
		}

		public List<Edge> HullEdges()
		{
			return null;
		}

		public List<Vector2> HullPointsInOrder()
		{
			return null;
		}

		public List<LineSegment> SpanningTree(KruskalType type = KruskalType.MINIMUM)
		{
			return null;
		}

		public List<List<Vector2>> Regions()
		{
			return null;
		}

		public List<uint> SiteColors()
		{
			return null;
		}

		public Vector2? NearestSitePoint(float x, float y)
		{
			return null;
		}

		public List<Vector2> SiteCoords()
		{
			return null;
		}

		public void FortunesAlgorithm()
		{
		}

		public Site FortunesAlgorithm_leftRegion(Halfedge he)
		{
			return null;
		}

		public Site FortunesAlgorithm_rightRegion(Halfedge he)
		{
			return null;
		}

		public static int CompareByYThenX(Site s1, Site s2)
		{
			return 0;
		}

		public static int CompareByYThenX(Site s1, Vector2 s2)
		{
			return 0;
		}
	}
}

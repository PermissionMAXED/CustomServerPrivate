using System;
using System.Collections.Generic;
using Delaunay.LR;
using UnityEngine;

namespace Delaunay
{
	public sealed class Site : ICoord, IComparable
	{
		public static Stack<Site> _pool;

		public static readonly float EPSILON;

		[NonSerialized]
		public Vector2 _coord;

		public uint color;

		public float weight;

		[NonSerialized]
		public uint _siteIndex;

		[NonSerialized]
		public List<Edge> _edges;

		[NonSerialized]
		public List<Side> _edgeOrientations;

		[NonSerialized]
		public List<Vector2> _region;

		public Vector2 Coord => default(Vector2);

		public List<Edge> edges => null;

		public float x => 0f;

		public float y => 0f;

		public static Site Create(Vector2 p, uint index, float weight, uint color)
		{
			return null;
		}

		public static void SortSites(List<Site> sites)
		{
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public static bool CloseEnough(Vector2 p0, Vector2 p1)
		{
			return false;
		}

		public Site(Vector2 p, uint index, float weight, uint color)
		{
		}

		public Site Init(Vector2 p, uint index, float weight, uint color)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public void Move(Vector2 p)
		{
		}

		public void Dispose()
		{
		}

		public void Clear()
		{
		}

		public void AddEdge(Edge edge)
		{
		}

		public Edge NearestEdge()
		{
			return null;
		}

		public List<Site> NeighborSites()
		{
			return null;
		}

		public Site NeighborSite(Edge edge)
		{
			return null;
		}

		public List<Vector2> Region(Rect clippingBounds)
		{
			return null;
		}

		public void ReorderEdges()
		{
		}

		public List<Vector2> ClipToBounds(Rect bounds)
		{
			return null;
		}

		public void Connect(List<Vector2> points, int j, Rect bounds, bool closingUp = false)
		{
		}

		public float Dist(ICoord p)
		{
			return 0f;
		}
	}
}

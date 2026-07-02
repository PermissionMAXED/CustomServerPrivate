using System.Collections.Generic;
using Delaunay.LR;
using Delaunay.Utils;
using UnityEngine;

namespace Delaunay
{
	public sealed class Halfedge : IDisposable
	{
		public static Stack<Halfedge> _pool;

		public Halfedge edgeListLeftNeighbor;

		public Halfedge edgeListRightNeighbor;

		public Halfedge nextInPriorityQueue;

		public Edge edge;

		public Side? leftRight;

		public Vertex vertex;

		public float ystar;

		public static Halfedge Create(Edge edge, Side? lr)
		{
			return null;
		}

		public static Halfedge CreateDummy()
		{
			return null;
		}

		public Halfedge(Edge edge = null, Side? lr = null)
		{
		}

		public Halfedge Init(Edge edge, Side? lr)
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		public void Dispose()
		{
		}

		public void ReallyDispose()
		{
		}

		public bool IsLeftOf(Vector2 p)
		{
			return false;
		}
	}
}

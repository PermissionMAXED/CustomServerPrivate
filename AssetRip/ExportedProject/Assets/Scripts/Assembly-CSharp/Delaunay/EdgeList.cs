using System;
using Delaunay.Utils;
using UnityEngine;

namespace Delaunay
{
	public sealed class EdgeList : Delaunay.Utils.IDisposable
	{
		[NonSerialized]
		public float _deltax;

		[NonSerialized]
		public float _xmin;

		[NonSerialized]
		public int _hashsize;

		[NonSerialized]
		public Halfedge[] _hash;

		[NonSerialized]
		public Halfedge _leftEnd;

		[NonSerialized]
		public Halfedge _rightEnd;

		public Halfedge leftEnd => null;

		public Halfedge rightEnd => null;

		public void Dispose()
		{
		}

		public EdgeList(float xmin, float deltax, int sqrt_nsites)
		{
		}

		public void Insert(Halfedge lb, Halfedge newHalfedge)
		{
		}

		public void Remove(Halfedge halfEdge)
		{
		}

		public Halfedge EdgeListLeftNeighbor(Vector2 p)
		{
			return null;
		}

		public Halfedge GetHash(int b)
		{
			return null;
		}
	}
}

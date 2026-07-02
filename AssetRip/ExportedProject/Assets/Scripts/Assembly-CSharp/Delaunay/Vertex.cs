using System;
using System.Collections.Generic;
using UnityEngine;

namespace Delaunay
{
	public sealed class Vertex : ICoord
	{
		public static readonly Vertex VERTEX_AT_INFINITY;

		public static Stack<Vertex> _pool;

		public static int _nvertices;

		[NonSerialized]
		public Vector2 _coord;

		[NonSerialized]
		public int _vertexIndex;

		public Vector2 Coord => default(Vector2);

		public int vertexIndex => 0;

		public float x => 0f;

		public float y => 0f;

		public static Vertex Create(float x, float y)
		{
			return null;
		}

		public Vertex(float x, float y)
		{
		}

		public Vertex Init(float x, float y)
		{
			return null;
		}

		public void Dispose()
		{
		}

		public void SetIndex()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static Vertex Intersect(Halfedge halfedge0, Halfedge halfedge1)
		{
			return null;
		}
	}
}

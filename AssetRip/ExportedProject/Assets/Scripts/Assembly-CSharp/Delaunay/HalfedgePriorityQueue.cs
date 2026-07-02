using System;
using Delaunay.Utils;
using UnityEngine;

namespace Delaunay
{
	public sealed class HalfedgePriorityQueue : Delaunay.Utils.IDisposable
	{
		[NonSerialized]
		public Halfedge[] _hash;

		[NonSerialized]
		public int _count;

		[NonSerialized]
		public int _minBucket;

		[NonSerialized]
		public int _hashsize;

		[NonSerialized]
		public float _ymin;

		[NonSerialized]
		public float _deltay;

		public HalfedgePriorityQueue(float ymin, float deltay, int sqrt_nsites)
		{
		}

		public void Dispose()
		{
		}

		public void Initialize()
		{
		}

		public void Insert(Halfedge halfEdge)
		{
		}

		public void Remove(Halfedge halfEdge)
		{
		}

		public int Bucket(Halfedge halfEdge)
		{
			return 0;
		}

		public bool IsEmpty(int bucket)
		{
			return false;
		}

		public void AdjustMinBucket()
		{
		}

		public bool Empty()
		{
			return false;
		}

		public Vector2 Min()
		{
			return default(Vector2);
		}

		public Halfedge ExtractMin()
		{
			return null;
		}
	}
}

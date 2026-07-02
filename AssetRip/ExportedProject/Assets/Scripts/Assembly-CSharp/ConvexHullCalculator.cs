using System.Collections.Generic;
using UnityEngine;

public static class ConvexHullCalculator
{
	public class CircularList<T> : List<T>
	{
		public T Last
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public T First
		{
			get
			{
				return default(T);
			}
			set
			{
			}
		}

		public void PushLast(T obj)
		{
		}

		public T PopLast()
		{
			return default(T);
		}

		public void PushFirst(T obj)
		{
		}

		public T PopFirst()
		{
			return default(T);
		}
	}

	public static IList<Vector2> ComputeConvexHull(List<Vector2> points, bool sortInPlace = false)
	{
		return null;
	}

	public static Vector2 Sub(this Vector2 a, Vector2 b)
	{
		return default(Vector2);
	}

	public static float Cross(this Vector2 a, Vector2 b)
	{
		return 0f;
	}
}

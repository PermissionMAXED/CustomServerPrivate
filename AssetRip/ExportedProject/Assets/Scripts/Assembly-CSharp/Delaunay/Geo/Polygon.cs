using System;
using System.Collections.Generic;
using UnityEngine;

namespace Delaunay.Geo
{
	public sealed class Polygon
	{
		[NonSerialized]
		public List<Vector2> _vertices;

		public Polygon(List<Vector2> vertices)
		{
		}

		public float Area()
		{
			return 0f;
		}

		public Winding Winding()
		{
			return default(Winding);
		}

		public float SignedDoubleArea()
		{
			return 0f;
		}
	}
}

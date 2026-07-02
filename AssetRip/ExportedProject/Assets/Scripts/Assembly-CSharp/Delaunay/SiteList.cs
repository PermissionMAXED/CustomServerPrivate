using System;
using System.Collections.Generic;
using Delaunay.Geo;
using Delaunay.Utils;
using UnityEngine;

namespace Delaunay
{
	public sealed class SiteList : Delaunay.Utils.IDisposable
	{
		[NonSerialized]
		public List<Site> _sites;

		[NonSerialized]
		public int _currentIndex;

		[NonSerialized]
		public bool _sorted;

		public int Count => 0;

		public void Dispose()
		{
		}

		public int Add(Site site)
		{
			return 0;
		}

		public Site Next()
		{
			return null;
		}

		public void ResetListIndex()
		{
		}

		public Rect GetSitesBounds()
		{
			return default(Rect);
		}

		public List<uint> SiteColors()
		{
			return null;
		}

		public List<Vector2> SiteCoords()
		{
			return null;
		}

		public List<Circle> Circles()
		{
			return null;
		}

		public List<List<Vector2>> Regions(Rect plotBounds)
		{
			return null;
		}

		public Vector2? NearestSitePoint(float x, float y)
		{
			return null;
		}
	}
}

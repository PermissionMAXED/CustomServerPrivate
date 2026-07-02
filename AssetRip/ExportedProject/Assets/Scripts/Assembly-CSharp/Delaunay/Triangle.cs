using System;
using System.Collections.Generic;
using Delaunay.Utils;

namespace Delaunay
{
	public sealed class Triangle : Delaunay.Utils.IDisposable
	{
		[NonSerialized]
		public List<Site> _sites;

		public List<Site> sites => null;

		public Triangle(Site a, Site b, Site c)
		{
		}

		public void Dispose()
		{
		}
	}
}

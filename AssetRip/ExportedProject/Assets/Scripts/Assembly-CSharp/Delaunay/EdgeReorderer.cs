using System;
using System.Collections.Generic;
using Delaunay.LR;
using Delaunay.Utils;

namespace Delaunay
{
	public sealed class EdgeReorderer : Delaunay.Utils.IDisposable
	{
		[NonSerialized]
		public List<Edge> _edges;

		[NonSerialized]
		public List<Side> _edgeOrientations;

		public List<Edge> edges => null;

		public List<Side> edgeOrientations => null;

		public EdgeReorderer(List<Edge> origEdges, VertexOrSite criterion)
		{
		}

		public void Dispose()
		{
		}

		public List<Edge> ReorderEdges(List<Edge> origEdges, VertexOrSite criterion)
		{
			return null;
		}
	}
}

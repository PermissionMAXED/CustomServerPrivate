using System.Collections.Generic;

namespace Delaunay
{
	public class Node
	{
		public static Stack<Node> pool;

		public Node parent;

		public int treeSize;
	}
}

using System.Collections.Generic;
using UnityEngine;

public class CullingTreeNode
{
	public Bounds m_bounds;

	public List<CullingTreeNode> children;

	public List<int> idHeld;

	public CullingTreeNode(Bounds bounds, int depth)
	{
	}

	public void RetrieveLeaves(Plane[] frustum, List<Bounds> list, List<int> visibleIDList)
	{
	}

	public bool FindLeaf(Vector3 point, int index)
	{
		return false;
	}

	public void RetrieveAllLeaves(List<CullingTreeNode> target)
	{
	}

	public bool ClearEmpty()
	{
		return false;
	}
}

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local.Rendering
{
	public class OctreeFrustumCulling
	{
		public bool AutoUpdate;

		public int DrawDistance;

		[NonSerialized]
		public List<Vector3> _allPositions;

		[NonSerialized]
		public List<int> _allRandomIDs;

		[NonSerialized]
		public List<int> _visibleIDList;

		[NonSerialized]
		public ComputeBuffer _visibleIDBuffer;

		[NonSerialized]
		public ComputeBuffer _allBuffer;

		[NonSerialized]
		public ComputeBuffer _randomIDBuffer;

		[NonSerialized]
		public Bounds _bounds;

		[NonSerialized]
		public CullingTreeNode _cullingTree;

		[NonSerialized]
		public List<Bounds> _boundsListVis;

		[NonSerialized]
		public List<CullingTreeNode> _leaves;

		[NonSerialized]
		public Plane[] _frustumPlanes;

		[NonSerialized]
		public float _originalFarPlane;

		[NonSerialized]
		public List<int> _emptyList;

		[NonSerialized]
		public Vector3 _cachedCamPos;

		[NonSerialized]
		public Quaternion _cachedCamRot;

		[NonSerialized]
		public bool _initialized;

		public ComputeBuffer AllBuffer => null;

		public ComputeBuffer VisibleIDBuffer => null;

		public ComputeBuffer RandomIDBuffer => null;

		public Bounds Bounds => default(Bounds);

		public void SetPositions(List<Vector3> positions)
		{
		}

		public void OnEnable()
		{
		}

		public void MainSetup()
		{
		}

		public void UpdateBounds()
		{
		}

		public void SetupQuadTree()
		{
		}

		public void PopulateEmptyList(int count)
		{
		}

		public void GetFrustumData(Camera camera)
		{
		}

		public void OnDisable()
		{
		}

		public void Update(Camera camera)
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}

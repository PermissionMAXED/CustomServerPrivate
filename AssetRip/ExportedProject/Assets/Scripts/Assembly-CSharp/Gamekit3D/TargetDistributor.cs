using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit3D
{
	[DefaultExecutionOrder(-1)]
	public class TargetDistributor : MonoBehaviour
	{
		public class TargetFollower
		{
			public bool requireSlot;

			public int assignedSlot;

			public Vector3 requiredPoint;

			public TargetDistributor distributor;

			public TargetFollower(TargetDistributor owner)
			{
			}
		}

		public int arcsCount;

		[NonSerialized]
		public Vector3[] m_WorldDirection;

		[NonSerialized]
		public bool[] m_FreeArcs;

		[NonSerialized]
		public float arcDegree;

		[NonSerialized]
		public List<TargetFollower> m_Followers;

		public void OnEnable()
		{
		}

		public TargetFollower RegisterNewFollower()
		{
			return null;
		}

		public void UnregisterFollower(TargetFollower follower)
		{
		}

		public void LateUpdate()
		{
		}

		public Vector3 GetDirection(int index)
		{
			return default(Vector3);
		}

		public int GetFreeArcIndex(TargetFollower follower)
		{
			return 0;
		}

		public void FreeIndex(int index)
		{
		}
	}
}

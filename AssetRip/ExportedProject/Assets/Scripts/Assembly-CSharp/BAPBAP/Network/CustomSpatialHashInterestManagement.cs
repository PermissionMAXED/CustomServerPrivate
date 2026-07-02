using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Network
{
	public class CustomSpatialHashInterestManagement : InterestManagement
	{
		[Tooltip("The maximum half range that objects will be visible at (rectangular shape)")]
		public Vector3 visHalfRange;

		[NonSerialized]
		public float visRangeSqrMag;

		[Tooltip("Resolution of the spatial hash grid")]
		public int resolution;

		[Tooltip("Full rebuild every X seconds (Partial rebuilds every X/groups seconds)")]
		public float fullRebuildInterval;

		[Tooltip("Number of groups to alternate on partial rebuilds")]
		public int rebuildGroups;

		[NonSerialized]
		public double partialRebuildInterval;

		[NonSerialized]
		public double lastRebuildTime;

		[NonSerialized]
		public int rebuildGroupId;

		[NonSerialized]
		public bool shouldRepopulateSpatialHash;

		public CustomGrid2D<NetworkConnectionToClient> grid;

		public void Awake()
		{
		}

		public override void SetHostVisibility(NetworkIdentity identity, bool visible)
		{
		}

		public override bool OnCheckObserver(NetworkIdentity identity, NetworkConnectionToClient newObserver)
		{
			return false;
		}

		public override void OnRebuildObservers(NetworkIdentity identity, HashSet<NetworkConnectionToClient> newObservers)
		{
		}

		[ServerCallback]
		public override void ResetState()
		{
		}

		[ServerCallback]
		public void FixedUpdate()
		{
		}

		[ServerCallback]
		public void Update()
		{
		}

		[ServerCallback]
		public void RepopulateSpatialHash()
		{
		}

		[ServerCallback]
		public void RebuildPartial()
		{
		}

		public void ForceRefresh()
		{
		}
	}
}

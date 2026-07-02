using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class EntityInterpolator
	{
		public const int MAX_GAP_SEARCH = 5;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public TransformLerpData[] timeline;

		[NonSerialized]
		public int timelineCapacity;

		[NonSerialized]
		public List<SnapLerpData> snapTicks;

		[NonSerialized]
		public AdaptivePlaybackBuffer playbackBuffer;

		[NonSerialized]
		public bool isLog;

		public EntityInterpolator(int timelineCapacity, int timingStatsWindowSize)
		{
		}

		public void AddData(TransformLerpData data, GameObject lol, bool isLog = false)
		{
		}

		public TransformLerpData CalculateLerpedData()
		{
			return default(TransformLerpData);
		}

		public bool GetTickPair(double tickFraction, out TransformLerpData startData, out TransformLerpData goalData)
		{
			startData = default(TransformLerpData);
			goalData = default(TransformLerpData);
			return false;
		}

		public void AddSnap(int tickNum)
		{
		}

		public void RemoveSnap(int tickNum)
		{
		}

		public bool GetAndPruneSnapTicks(int playbackTickNum)
		{
			return false;
		}
	}
}

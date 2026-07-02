using System;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Network
{
	public class AdaptivePlaybackBuffer
	{
		public const double ERR_THRESOLD = 0.005;

		public const double CONFIDENCE_INTERVAL_MULTIPLIER = 3.0;

		[NonSerialized]
		public ExpMovingAverageDouble delayMA;

		[NonSerialized]
		public bool initialized;

		[NonSerialized]
		public double playbackTime;

		[NonSerialized]
		public double timeSinceLastSnapshotReceived;

		[NonSerialized]
		public double latestSnapshotServerTime;

		[NonSerialized]
		public double targetDelay;

		public AdaptivePlaybackBuffer(int timingStatsWindowSize)
		{
		}

		public void UpdateAdaptiveDelay(int tickNum, double simFixedDt, GameObject lol, bool isLog)
		{
		}

		public double CalculatePlaybackTime(float deltaTime, bool isLog)
		{
			return 0.0;
		}
	}
}

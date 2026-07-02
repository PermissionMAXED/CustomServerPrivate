using System;
using System.Collections.Generic;
using BAPBAP.Debugging;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class PredictedInterpolator
	{
		[NonSerialized]
		public TransformLerpData[] timeline;

		[NonSerialized]
		public int timelineCapacity;

		[NonSerialized]
		public int timelineLatestIndex;

		[NonSerialized]
		public List<SnapLerpData> snapTicks;

		[NonSerialized]
		public TransformLerpData prevRenderedLerpData;

		[NonSerialized]
		public double prevPlaybackTickFraction;

		public const float MAX_ERR_SQ = 9f;

		[NonSerialized]
		public float errorSmoothFactor;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public DebugNetcodeManager debugNetManager;

		public PredictedInterpolator(TransformLerpData initialData, int timelineCapacity, float errorSmoothFactor)
		{
		}

		public void ModifyData(TransformLerpData newData)
		{
		}

		public void AddData(TransformLerpData newData)
		{
		}

		public void AddSnap(int tickNum)
		{
		}

		public void RemoveSnap(int tickNum)
		{
		}

		public TransformLerpData GetLatestAddedData()
		{
			return default(TransformLerpData);
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

		public Vector3 GetReconciliationError()
		{
			return default(Vector3);
		}

		public TransformLerpData AdjustReconciliationError(Vector3 posError, TransformLerpData lerpedData, double playbackTickFraction)
		{
			return default(TransformLerpData);
		}

		public bool GetAndPruneSnapTicks(int playbackTickNum)
		{
			return false;
		}
	}
}

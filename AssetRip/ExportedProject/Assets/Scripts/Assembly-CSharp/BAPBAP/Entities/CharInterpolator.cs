using System;
using BAPBAP.Entities.View;
using BAPBAP.Systems;
using UnityEngine;

namespace BAPBAP.Entities
{
	[DisallowMultipleComponent]
	public class CharInterpolator : MonoBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public SystemManager systemManager;

		[Tooltip("[Predicted] How long do we want the mispredicted error to exponentially decay / smooth out? Value is a % error fraction after a full second. The higher, the longer (0 for instant)")]
		[SerializeField]
		public float predErrorSmoothFactor;

		[SerializeField]
		[Tooltip("[Predicted] How big should we keep past ticked data? (Default is 30, which is roughly 1000ms)")]
		public int predInterpBufferSize;

		[SerializeField]
		[Tooltip("[Non-Predicted] How big should we keep past ticked data? (Default is 100, which is roughly 2000ms)")]
		public int entityInterpBufferSize;

		[Tooltip("[Non-Predicted] How sensitive should the adaptive interp delay be? (Default is 60 samples, which is roughly 2s of exponential moving data)")]
		[SerializeField]
		public int timingStatsWindowSize;

		[NonSerialized]
		public EntityInterpolator entityInterp;

		[NonSerialized]
		public PredictedInterpolator predInterp;

		public void PreAwake(EntityManager e)
		{
		}

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		public void ResetForSimulation()
		{
		}

		public void ModifyTransformData(int predTickNum, Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		public void AddTransformData(int tickNum, Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		public void AddSnap(int tickNum)
		{
		}

		public void RemoveSnap(int tickNum)
		{
		}

		public void ManagedLateUpdate()
		{
		}

		public void SetTransform(TransformLerpData lerpData)
		{
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraProximityTarget : MonoBehaviour
	{
		[NonSerialized]
		public CameraController camController;

		[SerializeField]
		[Tooltip("If enabled, this gameobject active state will be set based if the current application is a client or not.")]
		public bool setClientGameObjectActive;

		[Tooltip("The max range for this target to be added to the main camera controller")]
		[Header("Range Settings")]
		[Min(0f)]
		[SerializeField]
		public float rangeMax;

		[Tooltip("The min range for this target, it will lerp its influence from the max range.")]
		[SerializeField]
		[Min(0f)]
		public float rangeMin;

		[Header("Other Settings")]
		[Tooltip("The general influence weight of this target.")]
		[SerializeField]
		[Range(0f, 1f)]
		public float weight;

		[Tooltip("The zoom amount to add for this target.")]
		[SerializeField]
		public float additiveZoom;

		[NonSerialized]
		public float rangeMaxSqr;

		[NonSerialized]
		public float rangeMinSqr;

		[NonSerialized]
		public float rangeLengthSqr;

		[NonSerialized]
		public float distanceSqr;

		[NonSerialized]
		public bool entered;

		public float ZoomMultiplier => 0f;

		public void OnValidate()
		{
		}

		public void Start()
		{
		}

		public void InitializeRange()
		{
		}

		public void Update()
		{
		}

		public void OnDisable()
		{
		}

		public float GetProximityInfluenceFactor()
		{
			return 0f;
		}

		public void OnDrawGizmosSelected()
		{
		}
	}
}

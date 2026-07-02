using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class WorldSimTransformFollow : MonoBehaviour
	{
		[SerializeField]
		public Transform target;

		[SerializeField]
		[Min(0.1f)]
		public float maxPosDistance;

		[SerializeField]
		public float posLerpSpeed;

		[SerializeField]
		public float rotLerpSpeed;

		[NonSerialized]
		public float _maxPosDistanceSqr;

		[NonSerialized]
		public Vector3 simWorldPos;

		[NonSerialized]
		public Quaternion simWorldRot;

		public void OnValidate()
		{
		}

		public void Awake()
		{
		}

		public void SetTarget(Transform t)
		{
		}

		public void UpdateWorldSim()
		{
		}

		public void OnEnable()
		{
		}

		public void LateUpdate()
		{
		}

		public void Follow(float posFactor, float rotFactor)
		{
		}
	}
}

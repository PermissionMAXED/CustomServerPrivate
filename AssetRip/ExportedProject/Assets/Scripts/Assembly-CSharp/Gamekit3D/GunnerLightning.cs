using System;
using UnityEngine;

namespace Gamekit3D
{
	public class GunnerLightning : MonoBehaviour
	{
		[NonSerialized]
		public LineRenderer LR;

		public Transform end;

		[NonSerialized]
		public Transform[] branch;

		public float updateInterval;

		[NonSerialized]
		public float updateTime;

		public int pointCount;

		public float randomOffset;

		[NonSerialized]
		public Vector3[] points;

		public void Start()
		{
		}

		public void Update()
		{
		}
	}
}

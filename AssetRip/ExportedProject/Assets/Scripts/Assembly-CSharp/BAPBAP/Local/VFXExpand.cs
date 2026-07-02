using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXExpand : MonoBehaviour
	{
		[NonSerialized]
		public Vector3 prevPos;

		[NonSerialized]
		public Vector3 originalSize;

		public float length;

		public float speed;

		[NonSerialized]
		public float factor;

		[HideInInspector]
		public float totalDistance;

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}
	}
}

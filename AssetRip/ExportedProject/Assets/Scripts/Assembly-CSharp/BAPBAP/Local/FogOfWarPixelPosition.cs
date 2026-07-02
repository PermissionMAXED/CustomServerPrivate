using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class FogOfWarPixelPosition : MonoBehaviour
	{
		[SerializeField]
		public Camera cam;

		[NonSerialized]
		public int textureResolution;

		[NonSerialized]
		public float radiusScale;

		[NonSerialized]
		public float rendererUnitSize;

		[NonSerialized]
		public float pixelSizeWorldSpace;

		public void Initialize()
		{
		}

		public void SetRadiusScale(float scale)
		{
		}

		public void LateUpdate()
		{
		}
	}
}

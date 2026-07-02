using System;
using UnityEngine;

namespace BAPBAP.Local
{
	[ExecuteInEditMode]
	public class ShadowCaster : MonoBehaviour
	{
		public int targetSize;

		public float shadowBias;

		[NonSerialized]
		public Camera cam;

		[NonSerialized]
		public RenderTexture depthTarget;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnPostRender()
		{
		}

		public void GenerateShadowMap()
		{
		}

		public void SetShadowMap()
		{
		}

		public void OnDisable()
		{
		}
	}
}

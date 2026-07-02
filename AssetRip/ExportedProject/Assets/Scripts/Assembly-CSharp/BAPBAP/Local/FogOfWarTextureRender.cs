using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace BAPBAP.Local
{
	public class FogOfWarTextureRender : MonoBehaviour
	{
		[Header("References")]
		public Material blurMaterial;

		[NonSerialized]
		public Camera fowCam;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void EndCameraRendering(ScriptableRenderContext src, Camera camera)
		{
		}
	}
}

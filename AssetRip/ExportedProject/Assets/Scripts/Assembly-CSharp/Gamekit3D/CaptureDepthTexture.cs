using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Gamekit3D
{
	[ExecuteInEditMode]
	public class CaptureDepthTexture : MonoBehaviour
	{
		public Shader depthOnlyShader;

		[NonSerialized]
		public List<Camera> _cameraBufferAdded;

		[NonSerialized]
		public CommandBuffer cb;

		[NonSerialized]
		public Material m;

		public void OnEnable()
		{
		}

		public void CreateBuffer()
		{
		}

		public void PreRenderCamera(Camera cam)
		{
		}

		public void OnDisable()
		{
		}
	}
}

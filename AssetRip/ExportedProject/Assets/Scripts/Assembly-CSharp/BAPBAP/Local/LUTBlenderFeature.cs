using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.Local
{
	public class LUTBlenderFeature : ScriptableRendererFeature
	{
		[Serializable]
		public class LUTBlenderSettings
		{
			public string passTag;

			public RenderPassEvent Event;

			public Texture2D baseLUT;

			public Material lutBlendMaterial;
		}

		public LUTBlenderSettings settings;

		[NonSerialized]
		public LUTBlenderPass rtPass;

		[NonSerialized]
		public Dictionary<int, float> LUTIntensities;

		public static Action<int, float> OnLUTIntensityChange;

		[NonSerialized]
		public bool processNewIntensities;

		[NonSerialized]
		public Material lutBlendInstance;

		[NonSerialized]
		public RenderTexture blendedLUT;

		public override void Create()
		{
		}

		public RenderTextureDescriptor GetDescriptor()
		{
			return default(RenderTextureDescriptor);
		}

		public void OnLutIntensityChange(int slot, float intensity)
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public override void Dispose(bool disposing)
		{
		}
	}
}

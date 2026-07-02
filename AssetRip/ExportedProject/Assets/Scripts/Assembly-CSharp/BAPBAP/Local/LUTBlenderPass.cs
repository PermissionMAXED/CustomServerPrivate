using System;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.Local
{
	public class LUTBlenderPass : ScriptableRenderPass
	{
		[NonSerialized]
		public RenderQueueType renderQueueType;

		[NonSerialized]
		public string profilerTag;

		[NonSerialized]
		public ProfilingSampler profileSampler;

		[NonSerialized]
		public RenderTexture renderTexture;

		[NonSerialized]
		public Texture2D baseLUT;

		[NonSerialized]
		public Material lutBlendMaterial;

		public LUTBlenderPass(string profilerTag, RenderPassEvent renderPassEvent, RenderTexture renderTexture, Texture2D baseLUT, Material lutBlendMaterial)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}
	}
}

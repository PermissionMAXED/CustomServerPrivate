using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Highlighters_URP
{
	public class DepthMaskPass : ScriptableRenderPass
	{
		[NonSerialized]
		public readonly string profilingName;

		[NonSerialized]
		public readonly Material maskMaterial;

		[NonSerialized]
		public readonly List<ShaderTagId> shaderTagIdList;

		[NonSerialized]
		public FilteringSettings filteringSettings;

		public RTHandle sceneDepthMask;

		public DepthMaskPass(RenderPassEvent renderPassEvent, int layerMask, string profilingName)
		{
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public override void FrameCleanup(CommandBuffer cmd)
		{
		}
	}
}

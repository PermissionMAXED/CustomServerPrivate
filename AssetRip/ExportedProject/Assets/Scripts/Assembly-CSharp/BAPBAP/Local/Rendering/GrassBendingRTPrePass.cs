using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.Local.Rendering
{
	public class GrassBendingRTPrePass : ScriptableRendererFeature
	{
		public class CustomRenderPass : ScriptableRenderPass
		{
			public static readonly int _GrassBendingRT_pid;

			public static readonly RenderTargetIdentifier _GrassBendingRT_rti;

			[NonSerialized]
			public ShaderTagId GrassBending_stid;

			public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public override void FrameCleanup(CommandBuffer cmd)
			{
			}
		}

		[NonSerialized]
		public CustomRenderPass m_ScriptablePass;

		public override void Create()
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}
	}
}

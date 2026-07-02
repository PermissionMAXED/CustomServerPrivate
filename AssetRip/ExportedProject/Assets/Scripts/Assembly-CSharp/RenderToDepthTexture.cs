using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RenderToDepthTexture : ScriptableRendererFeature
{
	public class RenderToDepthTexturePass : ScriptableRenderPass
	{
		[NonSerialized]
		public ProfilingSampler m_ProfilingSampler;

		[NonSerialized]
		public FilteringSettings m_FilteringSettings;

		[NonSerialized]
		public List<ShaderTagId> m_ShaderTagIdList;

		[NonSerialized]
		public RenderTargetHandle depthTex;

		public RenderToDepthTexturePass(LayerMask layerMask)
		{
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public override void OnCameraCleanup(CommandBuffer cmd)
		{
		}
	}

	public LayerMask layerMask;

	public RenderPassEvent _event;

	[NonSerialized]
	public RenderToDepthTexturePass m_ScriptablePass;

	public override void Create()
	{
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
	}
}

using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CustomFullScreenRendererFeature : ScriptableRendererFeature
{
	public enum InjectionPoint
	{
		AfterRenderingPrePasses = 200,
		AfterRenderingSkybox = 400,
		BeforeRenderingOpaques = 250,
		BeforeRenderingTransparents = 450,
		BeforeRenderingPostProcessing = 550,
		AfterRenderingPostProcessing = 600
	}

	public class FullScreenRenderPass : ScriptableRenderPass
	{
		[NonSerialized]
		public Material _material;

		[NonSerialized]
		public int _passIndex;

		[NonSerialized]
		public bool _copyActiveColor;

		[NonSerialized]
		public bool _bindDepthStencilAttachment;

		[NonSerialized]
		public RTHandle _copiedColor;

		[NonSerialized]
		public RTHandle _freezeFrameColor;

		public static MaterialPropertyBlock _sharedPropertyBlock;

		public static readonly int blitTexture;

		public static readonly int blitScaleBias;

		[NonSerialized]
		public bool _freezeFrame;

		public FullScreenRenderPass(string passName)
		{
		}

		public void FreezeFrame()
		{
		}

		public void SetupMembers(Material material, int passIndex, bool copyActiveColor, bool bindDepthStencilAttachment)
		{
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public void ReAllocate(RenderTextureDescriptor desc)
		{
		}

		public void Dispose()
		{
		}

		public static void ExecuteCopyColorPass(CommandBuffer cmd, RTHandle sourceTexture)
		{
		}

		public static void ExecuteMainPass(CommandBuffer cmd, RTHandle sourceTexture, Material material, int passIndex)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}
	}

	public InjectionPoint injectionPoint;

	public bool fetchColorBuffer;

	public ScriptableRenderPassInput requirements;

	public Material passMaterial;

	public int passIndex;

	public bool bindDepthStencilAttachment;

	public FullScreenRenderPass FullScreenPass;

	public override void Create()
	{
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
	}

	public override void Dispose(bool disposing)
	{
	}
}

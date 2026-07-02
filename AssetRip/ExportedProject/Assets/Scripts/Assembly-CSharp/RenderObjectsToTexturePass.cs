using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;

public class RenderObjectsToTexturePass : ScriptableRenderPass
{
	public class RendererHolder
	{
		public int ElapsedFrames;

		public int ShaderPassIndex;

		public Renderer Renderer { get; }

		public int Frames { get; }

		public RendererHolder(Renderer renderer, int frames, int shaderPassIndex)
		{
		}

		public bool Render(CommandBuffer cmd, int sharedMaterial)
		{
			return false;
		}
	}

	[Serializable]
	public class Settings
	{
		public enum DepthAttachmentModes
		{
			DontAttach = 0,
			CopyAndAttachDepth = 1,
			UseExistingAndAttachDepth = 2
		}

		[Header("Geometry Settings")]
		public bool FullScreenQuadOnly;

		[Header("Texture Settings")]
		public string TextureName;

		public FilterMode TextureFilterMode;

		[FormerlySerializedAs("BlitFilterMode")]
		public FilterMode BlitTextureFilterMode;

		[Range(1f, 4f)]
		[SerializeField]
		public int _downsample;

		[Range(1f, 4f)]
		[SerializeField]
		public int _blitDownsample;

		public RenderTextureFormat TextureFormat;

		public RenderTextureFormat BlitTextureFormat;

		public ClearFlag ClearFlag;

		public Color ClearColor;

		[Header("Rendering Settings")]
		public bool IsLightModeTagBased;

		public List<string> LightModeShaderTags;

		public List<string> NonLightModeShaderPasses;

		public RenderPassEvent RenderPassEvent;

		[ConditionalHide("IsLightModeTagBased")]
		[Range(0f, 5000f)]
		[Header("Filtering & Sorting")]
		public int RenderQueueLowerBound;

		[ConditionalHide("IsLightModeTagBased")]
		[Range(0f, 5000f)]
		public int RenderQueueUpperBound;

		[ConditionalHide("IsLightModeTagBased")]
		public SortingCriteria SortingCriteria;

		[ConditionalHide("IsLightModeTagBased")]
		public LayerMask LayerMask;

		[Header("Material Settings")]
		[ConditionalHide("IsLightModeTagBased")]
		public Material Material;

		[ConditionalHide("IsLightModeTagBased")]
		public int MaterialPassIndex;

		[ConditionalHide("IsLightModeTagBased")]
		public Material BlitMaterial;

		[ConditionalHide("IsLightModeTagBased")]
		public int BlitMaterialPassIndex;

		[Header("Depth Settings")]
		public DepthAttachmentModes DepthAttachmentMode;

		public int DownSampling => 0;

		public int BlitDownSampling => 0;

		public RenderQueueRange RenderQueueRange => default(RenderQueueRange);
	}

	[NonSerialized]
	public readonly Settings _settings;

	[NonSerialized]
	public FilteringSettings _filteringSettings;

	[NonSerialized]
	public RTHandle _textureRTHandle;

	[NonSerialized]
	public RTHandle _tempTextureRTHandle;

	[NonSerialized]
	public RTHandle _depthTextureRTHandle;

	[NonSerialized]
	public List<ShaderTagId> _shaderTagIds;

	[NonSerialized]
	public int _globalId;

	[NonSerialized]
	public int _globalPreBlitId;

	[NonSerialized]
	public int _textureHandleId;

	[NonSerialized]
	public int _tempTextureHandleId;

	[NonSerialized]
	public List<RendererHolder> _renderers;

	[NonSerialized]
	public string _textureHandleName;

	[NonSerialized]
	public string _tempTextureHandleName;

	public RenderObjectsToTexturePass(Settings settings)
	{
	}

	public void Setup(RTHandle depthTextureHandle)
	{
	}

	public override void Configure(CommandBuffer cmd, RenderTextureDescriptor cameraTextureDescriptor)
	{
	}

	public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
	{
	}

	public override void FrameCleanup(CommandBuffer cmd)
	{
	}

	public void AddRenderer(Renderer renderer, int frames = -1)
	{
	}

	public void RemoveRenderer(Renderer renderer)
	{
	}

	public void Dispose()
	{
	}
}

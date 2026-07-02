using System;
using System.Collections.Generic;
using BAPBAP.Game.Dimensions;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[DisallowMultipleRendererFeature("Dimensions")]
public class DimensionRendererFeature : ScriptableRendererFeature
{
	public class DimensionFullscreenPass : ScriptableRenderPass
	{
		[NonSerialized]
		public Material _fullscreenMaterial;

		[NonSerialized]
		public bool _copyActiveColor;

		[NonSerialized]
		public bool _bindDepthStencilAttachment;

		[NonSerialized]
		public RTHandle _copiedColor;

		public static MaterialPropertyBlock propertyBlock;

		public static readonly int BlitTexture;

		public static readonly int BlitScaleBias;

		public DimensionFullscreenPass(string passName)
		{
		}

		public void Setup(Material material, bool copyActiveColor, bool bindDepthStencilAttachment)
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

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}
	}

	public class DimensionMaskPass : ScriptableRenderPass
	{
		[Serializable]
		public class DimensionObjectPassSettings
		{
			public ClearFlag clearFlag;

			public Color clearColor;

			public int depthBufferBits;
		}

		[NonSerialized]
		public RenderTextureDescriptor _descriptor;

		[NonSerialized]
		public RTHandle _textureHandle;

		[NonSerialized]
		public ComputeBuffer _dimensionDataBuffer;

		[NonSerialized]
		public ComputeBuffer _dimensionsCollisionBuffer;

		[NonSerialized]
		public DimensionBehaviourSO.DimensionData[] _dimensionData;

		[NonSerialized]
		public Dimension.DimensionCollisionData[] _dimensionCollisionData;

		public static readonly string DimensionsMaskPassTag;

		[NonSerialized]
		public DimensionObjectPassSettings _settings;

		[NonSerialized]
		public Plane[] frustumPlanes;

		public DimensionMaskPass(string profilingName, RenderPassEvent passEvent)
		{
		}

		public void Setup(RenderingData renderingData, DimensionObjectPassSettings settings)
		{
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}

		public void UpdateBuffers(List<Dimension> dimensions)
		{
		}

		public void Dispose()
		{
		}
	}

	[Header("Fullscreen Settings")]
	public RenderPassEvent FullscreenInjectionPoint;

	public bool FullscreenFetchColorBuffer;

	public ScriptableRenderPassInput FullscreenRequirements;

	public Material FullscreenMaterial;

	[Header("Object / Mask Settings")]
	public RenderPassEvent ObjectInjectionPoint;

	public ScriptableRenderPassInput ObjectRequirements;

	public DimensionMaskPass.DimensionObjectPassSettings MaskSettings;

	public bool BindDepthStencilAttachment;

	[NonSerialized]
	public DimensionFullscreenPass _dimensionFullscreenPass;

	[NonSerialized]
	public DimensionMaskPass _dimensionsMaskPass;

	public static readonly int CountID;

	public static readonly int DimensionsDataID;

	public static readonly int CollisionCountID;

	public static readonly int CollisionID;

	public const int MAX_DIMENSIONS_ARRAY_SIZE = 16;

	public const int MAX_DIMENSION_COLLISIONS_ARRAY_SIZE = 16;

	public override void Create()
	{
	}

	public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
	{
	}

	public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
	{
	}

	public override void Dispose(bool disposing)
	{
	}
}

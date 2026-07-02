using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class RenderObjectsMirroredToTexturePass : ScriptableRenderPass
{
	[Serializable]
	public class Settings
	{
		[Flags]
		public enum LightModeTags
		{
			None = 0,
			SRPDefaultUnlit = 1,
			UniversalForward = 2,
			UniversalForwardOnly = 4,
			LightweightForward = 8,
			DepthNormals = 0x10,
			DepthOnly = 0x20,
			SimpleReflection = 0x40,
			Standard = 0xF
		}

		[Serializable]
		public struct GlobalKeyword
		{
			public enum Mode
			{
				None = 0,
				Enable = 1,
				Disable = 2
			}

			public string Name;

			public bool Disabled;

			public Mode BeforeRenderMode;

			public Mode AfterRenderMode;
		}

		[Serializable]
		public struct GlobalFloat
		{
			public float Value;

			public string Name;
		}

		public bool AllowInSceneView;

		public Material Material;

		public int MaterialPassIndex;

		public Material BlitMaterial;

		public int BlitMaterialPassIndex;

		public RenderPassEvent RenderPassEvent;

		public ScriptableRenderPassInput RenderPassInput;

		[Range(0f, 5000f)]
		public int RenderQueueLowerBound;

		[Range(0f, 5000f)]
		public int RenderQueueUpperBound;

		public int DepthBufferBits;

		public RenderTextureFormat ColorFormat;

		public RenderBufferStoreAction StoreAction;

		public RenderBufferLoadAction LoadAction;

		public SortingCriteria SortingCriteria;

		public ClearFlag ClearFlag;

		public LayerMask LayerMask;

		public string TextureName;

		public LightModeTags LightMode;

		public GlobalKeyword[] GlobalShaderKeywords;

		public GlobalFloat[] GlobalShaderFloats;

		public bool mirror;

		public bool orthographic;

		public float orthographicSize;

		public float offset;

		public float cullOffsetAdd;

		public float nearClipPlane;

		public float farClipPlane;

		public bool renderPostProcessing;

		public bool renderShadows;

		public bool allowHDROutput;

		[ConditionalHide("mirror", true)]
		public Vector3 planeRotation;

		[ConditionalHide("mirror", true)]
		public Vector3 matrixRotation;

		public bool useRenderScale;

		[Range(0.05f, 1f)]
		[ConditionalHide("useRenderScale", true)]
		public float renderScale;

		[ConditionalInverseHide("useRenderScale", true)]
		public Vector2 textureDimensions;

		[Range(0f, 0.05f)]
		[Header("Blur")]
		public float blur;

		[Range(0f, 2f)]
		public float contrast;

		[Header("Debug")]
		public bool invertCulling;

		[ConditionalHide("mirror", true)]
		public bool cullWithMirrorPlane;

		[ConditionalHide("orthographic", true)]
		public bool cullWithOrthographicPlane;

		public FilterMode reflectionTextureFilterMode;

		[NonSerialized]
		public Material _cachedBlitMaterial;

		public StencilStateData StencilSettings;

		public RenderQueueRange RenderQueueRange => default(RenderQueueRange);

		public List<ShaderTagId> LightModeShaderTags => null;

		public Material GetBlitMaterial()
		{
			return null;
		}
	}

	[NonSerialized]
	public readonly Settings _settings;

	[NonSerialized]
	public RenderTextureDescriptor _descriptor;

	[NonSerialized]
	public FilteringSettings _filteringSettings;

	[NonSerialized]
	public RenderTargetHandle _tempTextureHandle;

	[NonSerialized]
	public RenderTargetHandle _textureHandle;

	[NonSerialized]
	public RenderStateBlock _renderStateBlock;

	public RenderObjectsMirroredToTexturePass(string profilingName, Settings settings)
	{
	}

	public void Setup(RenderTextureDescriptor baseDescriptor)
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

	public void UpdateKeywordsBeforeRender(CommandBuffer cmd)
	{
	}

	public void UpdateKeywordsAfterRender(CommandBuffer cmd)
	{
	}

	public void UpdateFloatsBeforeRender(CommandBuffer cmd)
	{
	}

	public void SetStencilState(int reference, CompareFunction compareFunction, StencilOp passOp, StencilOp failOp, StencilOp zFailOp)
	{
	}

	public Matrix4x4 GetMirrorMatrix(float offset)
	{
		return default(Matrix4x4);
	}

	public Vector4 GetMirrorPlane(Matrix4x4 worldToCameraMatrix, float offset)
	{
		return default(Vector4);
	}
}

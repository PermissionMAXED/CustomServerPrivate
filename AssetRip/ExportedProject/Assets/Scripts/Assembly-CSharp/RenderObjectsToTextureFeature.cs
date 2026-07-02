using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.Rendering.Universal.Internal;

public class RenderObjectsToTextureFeature : ScriptableRendererFeature
{
	public RenderPassEvent DepthEvent;

	public RenderObjectsToTexturePass.Settings Settings;

	[NonSerialized]
	public RenderObjectsToTexturePass _renderPass;

	[NonSerialized]
	public CopyDepthPass _copyDepthPass;

	[NonSerialized]
	public Material _copyDepthMaterial;

	[NonSerialized]
	public RTHandle _dstDepthTextureHandle;

	[NonSerialized]
	public RTHandle _srcDepthTextureHandle;

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

	public void AddRenderer(Renderer renderer, int frames = -1)
	{
	}

	public void RemoveRenderer(Renderer renderer)
	{
	}
}

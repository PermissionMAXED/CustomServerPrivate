using System;
using UnityEngine.Rendering.Universal;

public class RenderObjectsMirroredToTextureFeature : ScriptableRendererFeature
{
	public RenderObjectsMirroredToTexturePass.Settings Settings;

	[NonSerialized]
	public RenderObjectsMirroredToTexturePass _renderPass;

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

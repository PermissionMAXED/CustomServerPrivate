using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable]
[CreateAssetMenu(menuName = "Rendering/RenderPassInjectGaussianSamples")]
public class RenderPassInjectGaussianSamples : RenderPassInjectFunctionSO
{
	public int OutlineWidth;

	[NonSerialized]
	public float[][] _gaussSamples;

	public const int MinWidth = 1;

	public const int MaxWidth = 32;

	public const string GaussSamplesName = "_GaussSamples";

	public readonly int GaussSamplesId;

	public override void InjectCameraSetupFunction(CommandBuffer cmd, ref RenderingData renderingData, ScriptableRenderPass pass)
	{
	}

	public override void InjectExecuteBeforeFunction(ScriptableRenderContext context, ref RenderingData renderingData, ScriptableRenderPass pass)
	{
	}

	public override void InjectExecuteDuringFunction(CommandBuffer cmd, ScriptableRenderContext context, ref RenderingData renderingData, ScriptableRenderPass pass)
	{
	}

	public override void InjectExecuteAfterFunction(ScriptableRenderContext context, ref RenderingData renderingData, ScriptableRenderPass pass)
	{
	}

	public override void InjectCameraCleanupFunction(CommandBuffer cmd, ScriptableRenderPass pass)
	{
	}

	public override void InjectCreateFunction(ScriptableRenderPass pass)
	{
	}

	public override void InjectAddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData, ScriptableRenderPass pass)
	{
	}

	public float[] GetGaussSamples(int width)
	{
		return null;
	}

	public static float Gauss(float x, float stdDev)
	{
		return 0f;
	}

	public static float[] GetGaussSamples(int width, float[] samples)
	{
		return null;
	}
}

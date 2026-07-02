using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

[Serializable]
public abstract class RenderPassInjectFunctionSO : ScriptableObject
{
	public abstract void InjectCameraSetupFunction(CommandBuffer cmd, ref RenderingData renderingData, ScriptableRenderPass pass);

	public abstract void InjectExecuteBeforeFunction(ScriptableRenderContext context, ref RenderingData renderingData, ScriptableRenderPass pass);

	public abstract void InjectExecuteDuringFunction(CommandBuffer cmd, ScriptableRenderContext context, ref RenderingData renderingData, ScriptableRenderPass pass);

	public abstract void InjectExecuteAfterFunction(ScriptableRenderContext context, ref RenderingData renderingData, ScriptableRenderPass pass);

	public abstract void InjectCameraCleanupFunction(CommandBuffer cmd, ScriptableRenderPass pass);

	public abstract void InjectCreateFunction(ScriptableRenderPass pass);

	public abstract void InjectAddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData, ScriptableRenderPass pass);

	public RenderPassInjectFunctionSO()
	{
	}
}

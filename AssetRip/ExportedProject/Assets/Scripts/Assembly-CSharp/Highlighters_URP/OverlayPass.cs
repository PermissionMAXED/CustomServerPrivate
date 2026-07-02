using System;
using Highlighters;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Highlighters_URP
{
	public class OverlayPass : ScriptableRenderPass
	{
		[NonSerialized]
		public readonly Material material;

		[NonSerialized]
		public RTHandle cameraColorTarget;

		[NonSerialized]
		public string profilingName;

		[NonSerialized]
		public RenderTargetIdentifier objectsInfoIdentifier;

		public OverlayPass(RenderPassEvent renderPassEvent, HighlighterSettings highlighterSettings, string profilingName)
		{
		}

		public void SetupObjectsTarget(RenderTargetIdentifier objectsInfoIdentifier)
		{
		}

		public void SetCameraTarget(RTHandle cameraColorTarget)
		{
		}

		public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
		{
		}

		public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
		{
		}
	}
}

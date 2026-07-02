using System;
using System.Collections.Generic;
using Highlighters;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace Highlighters_URP
{
	public class ObjectsPass : ScriptableRenderPass
	{
		[NonSerialized]
		public readonly string profilingName;

		[NonSerialized]
		public List<HighlighterRenderer> renderersToDraw;

		[NonSerialized]
		public List<Material> materialsToDraw;

		[NonSerialized]
		public List<int> materialsPassIndexes;

		[NonSerialized]
		public HighlighterSettings highlighterSettings;

		[NonSerialized]
		public bool useSceneDepth;

		public RTHandle objectsInfo;

		[NonSerialized]
		public RTHandle sceneDepthMaskHandle;

		[NonSerialized]
		public Vector4 renderingBounds;

		public ObjectsPass(RenderPassEvent renderPassEvent, HighlighterSettings highlighterSettings, int ID, string profilingName, List<HighlighterRenderer> renderers)
		{
		}

		public void SetupSceneDepthTarget(RTHandle sceneDepthMaskHandle)
		{
		}

		public void UpdateMaterialsToDraw()
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
	}
}

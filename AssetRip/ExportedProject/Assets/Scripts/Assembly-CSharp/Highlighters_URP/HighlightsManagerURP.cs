using System;
using System.Collections.Generic;
using Highlighters;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace Highlighters_URP
{
	public class HighlightsManagerURP : ScriptableRendererFeature
	{
		public enum RenderEvent
		{
			BeforeRenderingTransparents = 0,
			AfterRenderingTransparents = 1
		}

		[SerializeField]
		public LayerMask DepthLayerMask;

		[SerializeField]
		public RenderEvent renderingEvent;

		public static Dictionary<int, Highlighter> highlightersInScene;

		[NonSerialized]
		public DepthMaskPass depthMaskPass;

		[NonSerialized]
		public bool renderSceneDepth;

		[NonSerialized]
		public Dictionary<int, ObjectsPass> objectsPasses;

		[NonSerialized]
		public Dictionary<int, OverlayPass> overlayPasses;

		[NonSerialized]
		public bool isWorking;

		public RenderPassEvent renderPassEvent => default(RenderPassEvent);

		public new void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void HighlighterDataUpdate(int ID)
		{
		}

		public void HighlightersReset()
		{
		}

		public void ValidateHighlighters()
		{
		}

		public override void Create()
		{
		}

		public override void SetupRenderPasses(ScriptableRenderer renderer, in RenderingData renderingData)
		{
		}

		public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
		{
		}

		public override void Dispose(bool disposing)
		{
		}

		public static void RegisterHighlighter(Highlighter highlighter)
		{
		}

		public static void UnregisterHighlighter(Highlighter highlight)
		{
		}
	}
}

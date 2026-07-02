using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace Highlighters
{
	[Serializable]
	public class HighlighterRenderer
	{
		public enum ClippingSource
		{
			Albedo = 0,
			Texture = 1
		}

		[ObjectReferencesToString("renderer", true, true)]
		public string name;

		public Renderer renderer;

		public bool useCutout;

		[ConditionalHide("useCutout")]
		public float clippingThreshold;

		[ConditionalHide("useCutout")]
		public ClippingSource clippingSource;

		[ConditionalHide("useCutout")]
		public Texture clipTexture;

		public List<int> submeshIndexes;

		public CullMode cullMode;

		public HighlighterRenderer(Renderer renderer, int numberOfSubmeshes)
		{
		}

		public Texture GetClipTexture()
		{
			return null;
		}
	}
}

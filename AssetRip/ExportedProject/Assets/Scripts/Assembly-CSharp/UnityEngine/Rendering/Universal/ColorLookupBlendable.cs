using System;

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[VolumeComponentMenuForRenderPipeline("Post-processing/Color Lookup Blendable", new Type[] { typeof(UniversalRenderPipeline) })]
	public class ColorLookupBlendable : VolumeComponent, IPostProcessComponent
	{
		public const int LUT_SLOTS_MAX = 3;

		[Header("-1 For Base Global Volume")]
		[Range(-1f, 2f)]
		public int lutSlot;

		public ClampedFloatParameter lutIntensity;

		public bool IsActive()
		{
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}

		public override void OnDisable()
		{
		}

		public override void Override(VolumeComponent state, float interpFactor)
		{
		}
	}
}

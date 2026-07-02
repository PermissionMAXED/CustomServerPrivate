using System;

namespace UnityEngine.Rendering.Universal
{
	[Serializable]
	[VolumeComponentMenuForRenderPipeline("Post-processing/Height Fog", new Type[] { typeof(UniversalRenderPipeline) })]
	public class HeightFogVolumeComponent : VolumeComponent, IPostProcessComponent
	{
		public BoolParameter enabled;

		public ClampedFloatParameter fogIntensity;

		public ColorParameter fogColorStart;

		public ColorParameter fogColorEnd;

		public ClampedFloatParameter fogColorDuo;

		public FloatParameter fogDistanceStart;

		public FloatParameter fogDistanceEnd;

		public ClampedFloatParameter fogDistanceFalloff;

		public FloatParameter fogHeightStart;

		public FloatParameter fogHeightEnd;

		public ClampedFloatParameter fogHeightFalloff;

		[Space(10f)]
		public FloatParameter farDistanceHeight;

		public FloatParameter farDistanceOffset;

		[Range(0f, 1f)]
		[Header("Skybox Settings")]
		public ClampedFloatParameter skyboxFogIntensity;

		[Range(0f, 1f)]
		public ClampedFloatParameter skyboxFogHeight;

		[Range(1f, 8f)]
		public ClampedFloatParameter skyboxFogFalloff;

		[Range(-1f, 1f)]
		public ClampedFloatParameter skyboxFogOffset;

		[Range(0f, 1f)]
		public ClampedFloatParameter skyboxFogBottom;

		[Range(0f, 1f)]
		public ClampedFloatParameter skyboxFogFill;

		public ClampedFloatParameter directionalIntensity;

		public ClampedFloatParameter directionalFalloff;

		public ColorParameter directionalColor;

		public ClampedFloatParameter noiseIntensity;

		public ClampedFloatParameter noiseMin;

		public ClampedFloatParameter noiseMax;

		public FloatParameter noiseScale;

		public Vector3Parameter noiseSpeed;

		public FloatParameter noiseDistanceEnd;

		public FloatParameter jitterIntensity;

		public bool IsActive()
		{
			return false;
		}

		public bool IsTileCompatible()
		{
			return false;
		}
	}
}

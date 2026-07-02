using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.Local.Rendering
{
	public class HeightFogRendererFeature : ScriptableRendererFeature
	{
		public class HeightFogRenderPass : ScriptableRenderPass
		{
			public enum FogAxisMode
			{
				XAxis = 0,
				YAxis = 1,
				ZAxis = 2
			}

			public enum FogCameraMode
			{
				Perspective = 0,
				Orthographic = 1,
				Both = 2
			}

			public enum FogLayersMode
			{
				MultiplyDistanceAndHeight = 10,
				AdditiveDistanceAndHeight = 20
			}

			[Serializable]
			public class HeightFogSettings
			{
				public FogAxisMode FogAxisMode;

				public FogLayersMode FogLayersMode;

				public FogCameraMode FogCameraMode;

				public bool RenderInPrefabContext;
			}

			[NonSerialized]
			public HeightFogSettings _settings;

			[NonSerialized]
			public Mesh _sphereMesh;

			[NonSerialized]
			public Material _fogMaterial;

			[NonSerialized]
			public Light _mainDirectional;

			[NonSerialized]
			public HeightFogVolumeComponent _volumeComponent;

			public static readonly int _DirectionalDir;

			public static readonly int _FogIntensity;

			public static readonly int _FogColorStart;

			public static readonly int _FogColorEnd;

			public static readonly int _FogColorDuo;

			public static readonly int _FogDistanceStart;

			public static readonly int _FogDistanceEnd;

			public static readonly int _FogDistanceFalloff;

			public static readonly int _FogHeightStart;

			public static readonly int _FogHeightEnd;

			public static readonly int _FogHeightFalloff;

			public static readonly int _FarDistanceHeight;

			public static readonly int _FarDistanceOffset;

			public static readonly int _SkyboxFogIntensity;

			public static readonly int _SkyboxFogHeight;

			public static readonly int _SkyboxFogFalloff;

			public static readonly int _SkyboxFogOffset;

			public static readonly int _SkyboxFogBottom;

			public static readonly int _SkyboxFogFill;

			public static readonly int _DirectionalIntensity;

			public static readonly int _DirectionalFalloff;

			public static readonly int _DirectionalColor;

			public static readonly int _NoiseIntensity;

			public static readonly int _NoiseMin;

			public static readonly int _NoiseMax;

			public static readonly int _NoiseScale;

			public static readonly int _NoiseSpeed;

			public static readonly int _NoiseDistanceEnd;

			public static readonly int _JitterIntensity;

			public static readonly int _FogAxisOption;

			public static readonly int _FogLayersMode;

			public static readonly int _FogCameraMode;

			public static readonly int AHF_DirectionalDir;

			public static readonly int AHF_FogIntensity;

			public static readonly int AHF_FogColorStart;

			public static readonly int AHF_FogColorEnd;

			public static readonly int AHF_FogColorDuo;

			public static readonly int AHF_FogDistanceStart;

			public static readonly int AHF_FogDistanceEnd;

			public static readonly int AHF_FogDistanceFalloff;

			public static readonly int AHF_FogHeightStart;

			public static readonly int AHF_FogHeightEnd;

			public static readonly int AHF_FogHeightFalloff;

			public static readonly int AHF_FarDistanceHeight;

			public static readonly int AHF_FarDistanceOffset;

			public static readonly int AHF_SkyboxFogIntensity;

			public static readonly int AHF_SkyboxFogHeight;

			public static readonly int AHF_SkyboxFogFalloff;

			public static readonly int AHF_SkyboxFogOffset;

			public static readonly int AHF_SkyboxFogBottom;

			public static readonly int AHF_SkyboxFogFill;

			public static readonly int AHF_DirectionalIntensity;

			public static readonly int AHF_DirectionalFalloff;

			public static readonly int AHF_DirectionalColor;

			public static readonly int AHF_NoiseIntensity;

			public static readonly int AHF_NoiseMin;

			public static readonly int AHF_NoiseMax;

			public static readonly int AHF_NoiseScale;

			public static readonly int AHF_NoiseSpeed;

			public static readonly int AHF_NoiseDistanceEnd;

			public static readonly int AHF_JitterIntensity;

			public static readonly int AHF_FogAxisOption;

			public static readonly int AHF_FogLayersMode;

			public static readonly int AHF_FogCameraMode;

			public static readonly string _fogCameraModePerspective;

			public static readonly string _fogCameraModeOrthographic;

			public static readonly string _fogCameraModeBoth;

			public HeightFogRenderPass(HeightFogSettings settings, Mesh sphereMesh, Light mainDirectional, Material fogMaterial)
			{
			}

			public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
			{
			}

			public void SetShaderVariables(CommandBuffer cmd)
			{
			}

			public void SetFogFloat(CommandBuffer cmd, int id, int ahfId, float value)
			{
			}

			public void SetFogVector(CommandBuffer cmd, int id, int ahfId, Vector4 value)
			{
			}

			public void SetFogColor(CommandBuffer cmd, int id, int ahfId, Color value)
			{
			}

			public float GetFogSphereSize(Camera camera)
			{
				return 0f;
			}

			public Vector3 GetFogSpherePosition(Camera camera)
			{
				return default(Vector3);
			}

			public void Dispose()
			{
			}
		}

		public RenderPassEvent Event;

		[SerializeField]
		public Mesh _sphereMesh;

		[SerializeField]
		public Shader _fogShader;

		[NonSerialized]
		public Light _mainDirectional;

		[NonSerialized]
		public HeightFogRenderPass _heightFogPass;

		[NonSerialized]
		public Material _fogMaterial;

		[SerializeField]
		public HeightFogRenderPass.HeightFogSettings _settings;

		public Mesh GetSphereMesh()
		{
			return null;
		}

		public Light GetDirectional()
		{
			return null;
		}

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
}

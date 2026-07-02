Shader "Toon_Atlantis_Waterfall" {
	Properties {
		_Centered ("[Centered]", Float) = 0
		_AmplifyProperties ("#Amplify Properties", Float) = 0
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		_WaterColor2 ("Water Color 2", Vector) = (0.008143453,0.5217425,0.5754717,0)
		_WaterColorErosionAmount ("Water Color Erosion Amount", Range(0, 1)) = 0.9021739
		_WaterColorErosionSoftness ("Water Color Erosion Softness", Range(0, 1)) = 0.1562712
		_WaterErosionAmount ("Water Erosion Amount", Range(0, 1)) = 0.9021739
		_WaterErosionSoftness ("Water Erosion Softness", Range(0, 1)) = 0.1562712
		_AlphaAdd ("Alpha Add", Float) = 0
		_Panner1Speed ("Panner 1 Speed", Float) = 0.5
		_VoronoiScale ("Voronoi Scale", Float) = 0
		_BottomNoisePower ("Bottom Noise Power", Float) = 0
		_BottomNoiseScale ("Bottom Noise Scale", Float) = 0
		_LocalCharSphereHeight ("Local Char Sphere Height", Float) = 0
		_LocalCharSphereRadius ("Local Char Sphere Radius", Float) = 0
		_LocalCharSphereIntensity ("Local Char Sphere Intensity", Float) = 0
		_LocalCharSphereMaxWidth ("Local Char Sphere Max Width", Float) = 0
		[Gradient] _WaterGradient ("Water Gradient", 2D) = "white" {}
		_2Tiling ("2~Tiling", Vector) = (1,1,0,0)
		_#1 ("#", Float) = 0
		[Space] _BaseSurfaceProperties ("#Base Surface Properties", Float) = 0
		_Unlit ("!Unlit", Range(0, 1)) = 1
		[Header(Lighting Parameters)] [Toggle(_RAMP_SHADING)] _RampShading ("Ramp Shading", Float) = 0
		[KeywordHide(_RAMP_SHADING, 0)] [NoScaleOffset] _Ramp ("Ramp", 2D) = "white" {}
		[KeywordHide(_RAMP_SHADING, 1)] _ShadowColor ("Shadow Color", Vector) = (0.6711962,0.690205,0.84,1)
		[KeywordEnum(None, SmoothStep, FWidth)] _AA ("Antialiasing Mode", Float) = 1
		_ShadingThreshold ("Shading Threshold", Range(-1, 1)) = 0.26
		[KeywordHide(_RAMP_SHADING, 1)] _ShadingSmooth ("Shading Smooth", Range(0.0001, 0.1)) = 0.01
		[Header(Lighting Settings)] _AmbientContribution ("Ambient Contribution", Range(0, 1)) = 0.2
		_LightingIntensity ("Lighting Intensity", Float) = 2
		_#2 ("#", Float) = 0
		[Space] _ShaderProperties ("#Shader Properties", Float) = 0
		_OpaqueTransparentPopup ("OpaqueTransparentPopup", Float) = 0
		[Header(Render Face)] [Enum(Front,2,Back,1,Both,0)] _Cull ("Render Face", Float) = 2
		[Space] [Header(Depth)] [Enum(Off,0,On,1)] _ZWriteMode ("ZWrite Mode", Float) = 0
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTestMode ("ZTest Mode", Float) = 4
		_DepthOffsetFactor ("Depth Offset Factor", Float) = 0
		_DepthOffsetUnits ("Depth Offset Units", Float) = 0
		[Space] [Header(Assorted)] [Enum(UnityEngine.Rendering.ColorWriteMask)] _ColorMask ("Color Mask", Float) = 15
		[Enum(Off,0,On,1)] _AlphatoCoverage ("Alpha to Coverage", Float) = 0
		[Space] _BlendInfo ("@Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency \n Blend One OneMinusSrcAlpha // Premultiplied transparency \n Blend One One // Additive \n Blend OneMinusDstColor One // Soft additive \n Blend DstColor Zero // Multiplicative \n Blend DstColor SrcColor // 2x multiplicative", Float) = 0
		[Header(Blend RGB)] [Enum(UnityEngine.Rendering.BlendMode)] _SourceBlendRGB ("Source Blend RGB", Float) = 5
		[Enum(UnityEngine.Rendering.BlendMode)] _DestinationBlendRGB ("Destination Blend RGB", Float) = 10
		[Space] [Header(Blend Alpha)] [Enum(UnityEngine.Rendering.BlendMode)] _SourceBlendAlpha ("Source Blend Alpha", Float) = 1
		[Enum(UnityEngine.Rendering.BlendMode)] _DestinationBlendAlpha ("Destination Blend Alpha", Float) = 10
		[Space] [Header(Stencil)] _StencilBufferReference ("Stencil Buffer Reference", Range(0, 255)) = 0
		_StencilBufferWriteMask ("Stencil Buffer Write Mask", Range(0, 255)) = 255
		_StencilBufferReadMask ("Stencil Buffer Read Mask", Range(0, 255)) = 255
		[Enum(UnityEngine.Rendering.CompareFunction)] _StencilBufferComparison ("Stencil Buffer Comparison", Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilBufferPassFront ("Stencil Buffer Pass Front", Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilBufferFailFront ("Stencil Buffer Fail Front", Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilBufferZFailFront ("Stencil Buffer ZFail Front", Float) = 0
		_#5 ("#", Float) = 0
		_RightBound ("[RightBound]", Float) = 0
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
		[ToggleOff] [HideInInspector] _ReceiveShadows ("Receive Shadows", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType" = "Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
			};

			struct Vertex_Stage_Output
			{
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return float4(1.0, 1.0, 1.0, 1.0); // RGBA
			}

			ENDHLSL
		}
	}
	Fallback "Hidden/InternalErrorShader"
	//CustomEditor "ToonMaterialInspector"
}
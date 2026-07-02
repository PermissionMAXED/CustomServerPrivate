Shader "Toon4ColorHeightBlend_Amplify" {
	Properties {
		_Centered ("[Centered]", Float) = 0
		_AmplifyProperties ("#Amplify Properties", Float) = 0
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		_PackedHeightTextureR ("Packed Height Texture (R)", 2D) = "white" {}
		[HDR] _Tex1Tint ("Tex 1 Tint", Vector) = (1,1,1,1)
		_ScaleAddR ("Scale Add R", Float) = 0
		_LocalRStrength ("Local R Strength", Range(0, 1)) = 1
		_PackedHeightTexture2G ("Packed Height Texture 2 (G)", 2D) = "white" {}
		[HDR] _Tex2Tint ("Tex 2 Tint", Vector) = (1,1,1,1)
		_ScaleAddG ("Scale Add G", Float) = 0
		_LocalGStrength ("Local G Strength", Range(0, 1)) = 1
		_PackedHeightTexture3B ("Packed Height Texture 3 (B)", 2D) = "white" {}
		[HDR] _Tex3Tint ("Tex 3 Tint", Vector) = (1,1,1,1)
		_ScaleAddB ("Scale Add B", Float) = 0
		_LocalBStrength ("Local B Strength", Range(0, 1)) = 1
		_PackedHeightTexture4A ("Packed Height Texture 4 (A)", 2D) = "white" {}
		[HDR] _Tex4Tint ("Tex 4 Tint", Vector) = (1,1,1,1)
		_ScaleAddA ("Scale Add A", Float) = 0
		_LocalAStrength ("Local A Strength", Range(0, 1)) = 1
		_TextureTilingScale ("Texture Tiling Scale", Float) = 0
		_AlphaClipThreshold ("Alpha Clip Threshold", Float) = 0.5
		_PHPower ("PH Power", Float) = 1
		_BlendAmount ("Blend Amount", Float) = 0
		_RContributeAlpha ("!R Contribute Alpha", Float) = 1
		_GContributeAlpha ("!G Contribute Alpha", Float) = 1
		_BContributeAlpha ("!B Contribute Alpha", Float) = 1
		_AContributeAlpha ("!A Contribute Alpha", Float) = 1
		[Toggle(_SAMPLEGLOBALSPLATMAP_ON)] _SampleGlobalSplatMap ("Sample Global Splat Map", Float) = 1
		[Header(Global Splat Settings)] _RedChannelStrength1 ("Red Channel Strength", Range(0, 1)) = 0
		_RedMin1 ("Red Min", Float) = 0.5
		_RedAdd1 ("Red Add", Float) = 0.3
		_GreenChannelStrength1 ("Green Channel Strength", Range(0, 1)) = 0
		_GreenMin1 ("Green Min", Float) = 0.5
		_GreenAdd1 ("Green Add", Float) = 0.3
		_BlueChannelStrength1 ("Blue Channel Strength", Range(0, 1)) = 0
		_BlueMin1 ("Blue Min", Float) = 0.5
		_BlueAdd1 ("Blue Add", Float) = 0.3
		_AlphaChannelStrength1 ("Alpha Channel Strength", Range(0, 1)) = 0
		_AlphaMin1 ("Alpha Min", Float) = 0.5
		_AlphaAdd1 ("Alpha Add", Float) = 0.3
		_DebugVertexColor ("!Debug Vertex Color", Float) = 0
		_#1 ("#", Float) = 0
		[Space] _BaseSurfaceProperties ("#Base Surface Properties", Float) = 0
		[Header(Base Parameters)] _Color ("Tint", Vector) = (0,0,0,1)
		_MainTex ("Texture", 2D) = "white" {}
		[Header(Lighting Parameters)] _Unlit ("!Unlit", Float) = 0
		_RampShading ("!Ramp Shading", Float) = 0
		_Ramp ("%Ramp", 2D) = "white" {}
		_ShadowColor ("Shadow Color", Vector) = (0.6711962,0.690205,0.84,1)
		[Enum(None,0,SmoothStep,1,FWidth,2)] _AA ("Antialiasing Mode", Float) = 1
		_ShadingThreshold ("Shading Threshold", Range(-1, 1)) = 0.26
		_ShadingSmooth ("Shading Smooth", Range(0.0001, 0.1)) = 0.01
		[Header(Lighting Settings)] _AmbientContribution ("Ambient Contribution", Range(0, 1)) = 0.2
		_LightingIntensity ("Lighting Intensity", Float) = 2
		_#2 ("#", Float) = 0
		[Space] _AdditionalSurfaceProperties ("#Additional Surface Properties", Float) = 0
		[HDR] _EmissionTint ("Emission Tint", Vector) = (0,0,0,1)
		[NoScaleOffset] [Normal] _NormalTex ("Normal Map", 2D) = "bump" {}
		_NormalScale ("Normal Scale", Float) = 1
		_Smoothness ("Smoothness", Float) = 0.5
		_SpecularSize ("Specular Size", Float) = 1
		_SpecularTint ("Specular Tint", Vector) = (0,0,0,1)
		_#3 ("#", Float) = 0
		[Space] _UberProperties ("#Uber Properties", Float) = 0
		[Header(Overlay)] _OverlayInfo ("@Enabling / disabling overlay, and FoW occluding is done by CharMaterial. Color channel is set by CharMaterial unless overriden.", Float) = 0
		[Toggle(_DEPTHMASKOVERLAY_OVERRIDECHANNEL)] _OverrideDepthMaskColorChannel ("Override Color Channel", Float) = 0
		[IntRange] _OverlayColorChannel ("Overlay Color Channel", Range(1, 16)) = 1
		_ShowBack ("Show Back Overlay", Float) = 1
		_ShowFront ("Show Front Overlay", Float) = 0
		[Header(Variation Noise)] [Toggle(_VARIATION_NOISE)] _VariationNoise ("Variation Noise", Float) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] [NoScaleOffset] _VariationTex ("Variation Texture", 2D) = "white" {}
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationScale ("Variation Scale", Range(0, 512)) = 20
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationOffset ("Variation Offset", Float) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationStep ("Variation Step", Range(0, 1)) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationStepOffset ("Variation Step Offset", Range(0, 1)) = 1
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationExponent ("Variation Exponent", Float) = 1
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationBlendMode ("Variation Blend Mode", Int) = 0
		_VariationInfo ("@Mask skips at specified Hue Value i.e. Red @ ~0.5 \n Channel params specify which Noise Tex channel to use", Float) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] _SkipVariationValueMask ("Skip Variation Value Mask", Int) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationMask ("Variation Mask", Range(0, 1)) = 0.225
		_VariationOverlayInfo ("@Settings for Overlay Variation", Float) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationAltBlendAmount ("Variation Alt Blend Amount", Range(0, 1)) = 0
		_VariationHSVInfo ("@Settings for HSV Variation", Float) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationValue ("Variation Value", Range(0, 1)) = 0.2
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationValueChannel ("Variation Value Channel", Range(0, 2)) = 0
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationHue ("Variation Hue", Range(0, 1)) = 0.2
		[KeywordHide(_VARIATION_NOISE, 0)] _VariationHueChannel ("Variation Hue Channel", Range(0, 2)) = 0
		[Space] [Header(Fog of War)] _MultiplyFoWToAlpha ("!Multiply FoW To Alpha", Float) = 0
		_MultiplyFoWToColor ("!Multiply FoW To Color", Float) = 0
		[Space] [Header(Ground Height Blend)] [Toggle(_GROUNDBIOME_HEIGHTBLEND)] _GroundBiomeHeightBlend ("GroundBiome Height Blend", Float) = 0
		[KeywordHide(_GROUNDBIOME_HEIGHTBLEND, 0)] _BlendMinHeight ("Blend Min Height", Float) = 0
		[KeywordHide(_GROUNDBIOME_HEIGHTBLEND, 0)] _BlendMaxHeight ("Blend Max Height", Float) = 1
		[Space] [Header(Coverage Layer)] [Toggle(_COVERAGE_LAYER)] _CoverageLayer ("Coverage Layer", Float) = 0
		[KeywordHide(_COVERAGE_LAYER, 0)] _CoverageColor ("Coverage Tint", Vector) = (1,1,1,1)
		[KeywordHide(_COVERAGE_LAYER, 0)] [NoScaleOffset] _CoverageRamp ("Coverage Ramp", 2D) = "white" {}
		[KeywordHide(_COVERAGE_LAYER, 0)] [NoScaleOffset] _CoverageNoise ("Coverage Noise", 2D) = "white" {}
		[KeywordHide(_COVERAGE_LAYER, 0)] _CoverageNoiseTiling ("Coverage Noise Tiling", Range(0, 50)) = 50
		[KeywordHide(_COVERAGE_LAYER, 0)] _CoverageEdgeWidth ("Coverage Edge Width", Range(0, 1)) = 0
		[KeywordHide(_COVERAGE_LAYER, 0)] _CoverageEdgeModStrength ("Coverage Edge Mod Strength", Range(0, 5)) = 0
		[KeywordHide(_COVERAGE_LAYER, 0)] _CoverageSize ("Coverage Size", Float) = 0.89
		[KeywordHide(_COVERAGE_LAYER, 0)] _CoverageAngle ("Coverage Angle", Vector) = (-0.03,1,1.36,0)
		_#4 ("#", Float) = 0
		[PerRendererData] _PerRendererColor ("Per Renderer Color", Vector) = (0,0,0,0)
		[Space] _ShaderProperties ("#Shader Properties", Float) = 0
		[Header(Render Face)] [Enum(Front,2,Back,1,Both,0)] _Cull ("Render Face", Float) = 2
		[Space] [Header(Depth)] [Enum(Off,0,On,1)] _ZWriteMode ("ZWrite Mode", Float) = 1
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
		Tags { "RenderType"="Opaque" }
		LOD 200

		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			float4x4 unity_ObjectToWorld;
			float4x4 unity_MatrixVP;
			float4 _MainTex_ST;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Vertex_Stage_Output
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.uv = (input.uv.xy * _MainTex_ST.xy) + _MainTex_ST.zw;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			Texture2D<float4> _MainTex;
			SamplerState sampler_MainTex;
			float4 _Color;

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy) * _Color;
			}

			ENDHLSL
		}
	}
	Fallback "Hidden/InternalErrorShader"
	//CustomEditor "ToonMaterialInspector"
}
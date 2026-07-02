Shader "MobileDrawMeshInstancedIndirect/SingleGrass" {
	Properties {
		_BaseColor ("BaseColor", Vector) = (1,1,1,1)
		_BaseColorTexture ("_BaseColorTexture", 2D) = "white" {}
		_AlphaTexture ("_AlphaTexture", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0.15, 0.85)) = 0.4
		_MipScale ("Mip Level Alpha Scale", Range(0, 1)) = 0.25
		_GroundColor ("_GroundColor", Vector) = (0.5,0.5,0.5,1)
		_LerpGroundToColorOffset ("Lerp Ground To Color Offset", Float) = 0
		_LerpGroundToColorPower ("Lerp Ground To Color Power", Float) = 1
		[Toggle(_SAMPLEBIOME)] _SampleBiomeForGround ("Sample Biome For Ground", Float) = 1
		[Header(Lighting Parameters)] _ShadowColor ("Shadow Color", Vector) = (0.6711962,0.690205,0.84,1)
		[KeywordEnum(None, SmoothStep, FWidth)] _AA ("Antialiasing Mode", Float) = 1
		_ShadingThreshold ("Shading Threshold", Range(-1, 1)) = 0.26
		_ShadingSmooth ("Shading Smooth", Range(0.0001, 0.1)) = 0.01
		[Header(Lighting Settings)] _AmbientContribution ("Ambient Contribution", Range(0, 1)) = 0.2
		_LightingIntensity ("Lighting Intensity", Float) = 2
		[Header(Grass Shape)] _GrassWidth ("_GrassWidth", Float) = 1
		_GrassHeight ("_GrassHeight", Float) = 1
		_RandomOffset ("_RandomOffset", Float) = 0.1
		_HeightRandomOffsetMin ("_HeightRandomOffsetMin", Float) = 0.45
		_HeightRandomOffsetMax ("_HeightRandomOffsetMax", Float) = 0.55
		_BendStrength ("_BendStrength", Float) = 0.1
		[Header(Wind)] _WindAIntensity ("_WindAIntensity", Float) = 1.77
		_WindAFrequency ("_WindAFrequency", Float) = 4
		_WindATiling ("_WindATiling", Vector) = (0.1,0.1,0,1)
		_WindAWrap ("_WindAWrap", Vector) = (0.5,0.5,0,1)
		_WindBIntensity ("_WindBIntensity", Float) = 0.25
		_WindBFrequency ("_WindBFrequency", Float) = 7.7
		_WindBTiling ("_WindBTiling", Vector) = (0.37,3,0,1)
		_WindBWrap ("_WindBWrap", Vector) = (0.5,0.5,0,1)
		_WindCIntensity ("_WindCIntensity", Float) = 0.125
		_WindCFrequency ("_WindCFrequency", Float) = 11.7
		_WindCTiling ("_WindCTiling", Vector) = (0.77,3,0,1)
		_WindCWrap ("_WindCWrap", Vector) = (0.5,0.5,0,1)
		[Header(Lighting)] _RandomNormal ("_RandomNormal", Float) = 0.15
		[Header(Flow Tex Parameters)] _FlowTexXOffset ("Flow Map Texture X Offset", Float) = 0
		_FlowTexYOffset ("Flow Map Texture Y Offset", Float) = 0
		[NoScaleOffset] _FlowMap ("Flow (RG)", 2D) = "black" {}
		[Header(Main Flow)] _FlowTexScaleMain ("FlowMap Main Scale", Float) = 1
		_DistortionMainAmount ("Distortion Main Amount", Range(0, 1)) = 1
		[Header(Detail Flow)] _FlowTexScaleDetails ("FlowMap Details Scale", Float) = 1
		_DistortionDetailsAmount ("Distortion Details Amount", Range(0, 1)) = 0.5
		[Header(General Intensity Multiplier)] _DistortionMultiplier ("Distortion Multiplier", Range(0, 1)) = 1
		_DistortionScale ("Distortion Scale", Float) = 200
		[Header(Biome Color Mask Settings)] _ColorMaskRange ("Color Mask Range", Range(0, 1)) = 0.1
		[HideInInspector] _PivotPosWS ("_PivotPosWS", Vector) = (0,0,0,0)
		[HideInInspector] _BoundSize ("_BoundSize", Vector) = (1,1,0,1)
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
}
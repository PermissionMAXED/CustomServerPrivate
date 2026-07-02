Shader "Custom/ABDistortionScrollCircularErosion" {
	Properties {
		_TintColor ("Color", Vector) = (1,0.6235296,0.1470588,1)
		_ColorMultiplier ("Color Multiplier", Range(0, 100)) = 1
		_MainTex ("MainTex", 2D) = "white" {}
		[MaterialToggle] _DistortMainTexture ("Distort Main Texture", Float) = 0
		_NoiseAmount ("Noise Amount", Range(-1, 1)) = 0.1
		_DistortionUSpeed ("Distortion U Speed", Float) = 0.1
		_DistortionVSpeed ("Distortion V Speed", Float) = 0.1
		_Distortion ("Distortion", 2D) = "white" {}
		_ErodeAmount ("Erode Amount", Range(0, 2)) = 0.5
		_FeatherAmount ("Feather Amount", Range(0, 1)) = 0.5
		_PulseSpeed ("Pulse Speed", Range(0, 10)) = 1
		_PulseStrength ("Pulse Strength", Range(0, 1)) = 0.5
		_OuterRingPulseOffset ("Outer Ring Pulse Offset", Range(-2, 2)) = 0.5
		_OuterRingWidth ("Outer Ring Width", Range(0, 1)) = 0.1
		_OuterRingErosionMultiplier ("Outer Ring Erosion Multiplier", Range(0, 1)) = 0.5
		[Toggle(_HALFTONE)] _Halftone ("Is Halftone", Float) = 0
		_HalftoneFrequency ("Halftone Frequency", Float) = 0.1
		_HalftoneRadius ("Halftone Radius", Float) = 0.1
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
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

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy);
			}

			ENDHLSL
		}
	}
}
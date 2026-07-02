Shader "Custom/ABDistortionScroll" {
	Properties {
		_TintColor ("Color", Vector) = (1,0.6235296,0.1470588,1)
		_ColorMultiplier ("Color Multiplier", Range(0, 100)) = 1
		_MainTextUSpeed ("MainText U Speed", Float) = 0
		_MainTextVSpeed ("MainText V Speed", Float) = 0
		_MainTex ("MainTex", 2D) = "white" {}
		[MaterialToggle] _DistortMainTexture ("Distort Main Texture", Float) = 0
		_GradientPower ("Gradient Power", Range(0, 50)) = 0
		_GradientUSpeed ("Gradient U Speed", Float) = 0.1
		_GradientVSpeed ("Gradient V Speed", Float) = 0.1
		_Gradient ("Gradient", 2D) = "white" {}
		_NoiseAmount ("Noise Amount", Range(-1, 1)) = 0.1
		_DistortionUSpeed ("Distortion U Speed", Float) = 0.1
		_DistortionVSpeed ("Distortion V Speed", Float) = 0.1
		_Distortion ("Distortion", 2D) = "white" {}
		_MainTexMask ("MainTexMask", 2D) = "white" {}
		_DoubleSided ("DoubleSided", Float) = 1
		[Toggle(_HALFTONE)] _Halftone ("Is Halftone", Float) = 0
		_HalftoneFrequency ("Halftone Frequency", Float) = 0.1
		_HalftoneRadius ("Halftone Radius", Float) = 0.1
		[HideInInspector] _Cutoff ("Alpha cutoff", Range(0, 1)) = 0.5
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
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
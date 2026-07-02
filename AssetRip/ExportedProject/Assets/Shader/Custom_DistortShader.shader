Shader "Custom/DistortShader" {
	Properties {
		_MainTex ("Main texture", 2D) = "white" {}
		_FlowTexXOffset ("Flow Map Texture X Offset", Float) = 0
		_FlowTexYOffset ("Flow Map Texture Y Offset", Float) = 0
		[NoScaleOffset] _FlowMap ("Flow (RG)", 2D) = "black" {}
		[Header(Main Flow)] _FlowTexScaleMain ("FlowMap Main Scale", Float) = 1
		_DistortionMainAmount ("Distortion Main Amount", Range(0, 1)) = 1
		[Header(Detail Flow)] _FlowTexScaleDetails ("FlowMap Details Scale", Float) = 1
		_DistortionDetailsAmount ("Distortion Details Amount", Range(0, 1)) = 0.5
		[Header(General Intensity Multiplier)] _DistortionMultiplier ("Distortion Multiplier", Range(0, 1)) = 1
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
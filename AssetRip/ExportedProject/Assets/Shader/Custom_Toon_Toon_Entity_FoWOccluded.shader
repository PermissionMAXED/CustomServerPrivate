Shader "Custom/Toon/Toon_Entity_FoWOccluded" {
	Properties {
		[Header(Base Parameters)] _Color ("Color", Vector) = (0,0,0,1)
		_MainTex ("Texture", 2D) = "white" {}
		[Header(Lighting Parameters)] _ShadowColor ("Shadow Color", Vector) = (0.5,0.5,0.5,1)
		[KeywordEnum(None, SmoothStep, FWidth)] _AA ("Antialiasing Mode", Float) = 1
		_ShadingThreshold ("Shading Threshold", Range(-1, 1)) = 0
		_ShadingSmooth ("Shading Smooth", Range(0.0001, 0.1)) = 0.01
		[Header(Lighting Settings)] _AmbientContribution ("Ambient Contribution", Range(0, 1)) = 0
		_LightingIntensity ("Lighting Intensity", Float) = 1
		[Header(Hit Blink)] _HitBlinkColor ("Hit Blink Color", Vector) = (1,1,1,1)
		_HitBlinkAmount ("Hit Blink Amount", Range(0, 1)) = 0
		[Header(Ground Height Blend)] [Toggle(_GROUNDBIOME_HEIGHTBLEND)] _GroundBiomeHeightBlend ("GroundBiome Height Blend", Float) = 0
		_BlendMinHeight ("Blend Min Height", Float) = 0
		_BlendMaxHeight ("Blend Max Height", Float) = 1
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
}
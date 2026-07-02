Shader "Custom/Foliage/Toon_Foliage_Height" {
	Properties {
		_MainTex ("_MainTex", 2D) = "white" {}
		_Tint ("Tint", Vector) = (0.5750993,0.6886792,0.4006467,0)
		_Bias ("Bias", Range(0, 1)) = 0.5
		_Shadow_tint ("Shadow_tint", Vector) = (0,0,0,0)
		_ambientContribution ("ambientContribution", Range(0, 1)) = 0.2
		_windintensity ("wind intensity", Range(0, 300)) = 0.5
		_windDirection ("windDirection", Vector) = (1,0,0,0)
		_windSpeed ("windSpeed", Float) = 1
		_windTurbulence ("windTurbulence", Range(0, 1)) = 0
		_windScale ("windScale", Range(0, 2)) = 1
		_WindEndHeight ("WindEndHeight", Float) = 1.5
		_WindStartHeight ("WindStartHeight", Float) = 0.5
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[Header(Lighting Parameters)] _ShadowColor ("Shadow Color", Vector) = (0.5,0.5,0.5,1)
		[Header(Ground Height Blend)] [Toggle(_GROUNDBIOME_HEIGHTBLEND)] _GroundBiomeHeightBlend ("GroundBiome Height Blend", Float) = 0
		_BlendMinHeight ("Blend Min Height", Float) = 0
		_BlendMaxHeight ("Blend Max Height", Float) = 1
		[Toggle] _ZWrite ("ZWrite", Float) = 1
		[Toggle] _FadeFoWHeight ("FadeFoWHeight", Float) = 1
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
	//CustomEditor "ASEMaterialInspector"
}
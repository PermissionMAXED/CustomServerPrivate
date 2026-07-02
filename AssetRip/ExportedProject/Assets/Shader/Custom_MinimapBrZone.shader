Shader "Custom/MinimapBrZone" {
	Properties {
		[PerRendererData] _MainTex ("Texture", 2D) = "white" {}
		_Color ("Tint", Vector) = (1,1,1,1)
		_TextureBrightness ("Texture Brightness", Range(0, 1)) = 0
		[Header(Tex Alpha Clip Settings)] _AlphaCutoutValue ("AlphaCutoutVaule", Range(0, 1)) = 0.5
		[Header(Outline)] [Toggle] Outline ("Outline", Float) = 0
		_Width ("Outline Width", Range(0, 0.05)) = 0.003
		_OutlineColor ("OutlineColor", Vector) = (1,1,1,1)
		[Header(Battle Royale Zone Parameters)] _ZoneColor ("Zone Color", Vector) = (1,1,1,1)
		_ZoneEdgeColor ("Zone Edge Color", Vector) = (1,1,1,1)
		_ZoneGlowColor ("Zone Glow Color", Vector) = (1,1,1,1)
		_ZonePreviewRingColor ("Zone Preview Ring Color", Vector) = (1,1,1,1)
		_ZonePreviewRingColorClosing ("Zone Preview Ring Color Closing", Vector) = (1,1,1,1)
		_ZonePreviewRingWidth ("Zone Preview Ring Width", Float) = 1
		_ZoneGlowSize ("Zone Glow Size", Float) = 10
		_ZoneEdgeWidth ("Zone Edge Width", Float) = 1
		_ZoneSharpness ("Zone Sharpness", Float) = 0
		[Toggle] _RingClosing ("Ring Closing", Float) = 0
		[Header(Stencil)] _StencilComp ("Stencil Comparison", Float) = 8
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
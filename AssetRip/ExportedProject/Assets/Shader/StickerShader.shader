Shader "StickerShader" {
	Properties {
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Vector) = (1,1,1,1)
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
		[Space(15)] [Header(Base Alpha Cutout)] [Space(5)] _ColorAlphaCutout ("ColorAlphaCutout", Range(0, 1)) = 0.5
		[Space(15)] [Header(Outline)] [Space(5)] _OutlineSmoothFactor ("OutlineSmoothFactor", Range(0, 0.1)) = 0.5
		_OutlineThickness ("OutlineThickness", Range(0, 1)) = 0.5
		_OutlineColor ("OutlineColor", Vector) = (1,1,1,1)
		[Header(Outline Overlay Fx)] [Space(5)] [Toggle(_OUTLINEOVERLAYFX_ON)] _OutlineOverlayFx ("OutlineOverlayFx", Float) = 0
		[Toggle(_OUTLINEFLOWMAPDIRECTIONAL_ON)] _OutlineFlowmapDirectional ("OutlineFlowmapDirectional", Float) = 0
		[NoScaleOffset] _OutlineFxLUT ("OutlineFxLUT", 2D) = "white" {}
		_OutlineFxTexture ("OutlineFxTexture", 2D) = "white" {}
		_OutlineFxIntensity ("OutlineFxIntensity", Range(0, 1)) = 0.5
		_OutlineTexScale ("OutlineTexScale", Float) = 0.5
		[Space(15)] [Header(Overlay Fx)] [Space(5)] [Toggle(_OVERLAYFX_ON)] _OverlayFx ("OverlayFx", Float) = 0
		_OverlayFxSpeed ("OverlayFxSpeed", Float) = 1
		_twist ("twist", Float) = 0
		_OverlayFxIntensity ("OverlayFxIntensity", Range(0, 1)) = 0.5
		_OverlayFxTexture ("OverlayFxTexture", 2D) = "white" {}
		[NoScaleOffset] _OverlayFxLUT ("OverlayFxLUT", 2D) = "white" {}
		_OutlineFxSpeed ("_OutlineFxSpeed", Vector) = (0,0,0,0)
		[HideInInspector] _texcoord ("", 2D) = "white" {}
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
	//CustomEditor "ASEMaterialInspector"
}
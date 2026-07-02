Shader "Uber_Particles_Trails_UI" {
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
		[Space(13)] [Header(Main Texture)] [Space(33)] _MainTexture1 ("Main Texture", 2D) = "white" {}
		[HDR] _ColorTip1 ("Color Tip", Vector) = (1,0.2538287,0,0)
		[HDR] _ColorTail1 ("Color Tail", Vector) = (0.01886791,0.01886791,0.01886791,0)
		_UVPan1 ("UV Pan", Vector) = (-1,0,0,0)
		_UVScale1 ("UV Scale", Vector) = (1,1,0,0)
		_ErosionSmoothness1 ("Erosion Smoothness", Float) = 0.17
		[Space(33)] [Header(Distortion Texture)] [Space(33)] _UVDTex1 ("UVD Tex", 2D) = "white" {}
		_UVDPan1 ("UVD Pan", Vector) = (-1.3,-0.1,0,0)
		_UVDScale1 ("UVD Scale", Vector) = (0.5,0.7,0,0)
		_UVDLerp1 ("UVD Lerp", Float) = 0.05
		_Erosion1 ("Erosion", Float) = 0.1
		[Space(33)] [Header(Cutout)] [Space(33)] _CutoutTexture1 ("Cutout Texture", 2D) = "white" {}
		_CutoutPower1 ("Cutout Power", Float) = 1
		_CutoutMult1 ("Cutout Mult", Float) = 1
		_EmissionMult1 ("Emission Mult", Float) = 1
		_TextureTint1 ("Texture Tint", Float) = 0
		_EroLerpMult1 ("Ero Lerp Mult", Float) = 3
		_ColorLerpPow1 ("Color Lerp Pow", Float) = 22
		_ColorLerpMult1 ("Color Lerp Mult", Float) = 13
		_EroLerpPow1 ("Ero Lerp Pow", Float) = 5
		[Space(33)] [Header(AR)] [Space(33)] _Cull1 ("Cull", Float) = 2
		_Src1 ("Src", Float) = 5
		_Dst1 ("Dst", Float) = 10
		_ZWrite1 ("ZWrite", Float) = 0
		_ZTest1 ("ZTest", Float) = 2
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
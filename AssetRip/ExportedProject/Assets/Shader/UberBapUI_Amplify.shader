Shader "UberBapUI_Amplify" {
	Properties {
		_Centered ("[Centered]", Float) = 0
		_AmplifyProperties ("#Amplify Properties", Float) = 0
		_UVTilingAndOffset ("UV Tiling And Offset", Vector) = (1,1,0,0)
		_2UVScrollSpeed ("2~UV Scroll Speed", Vector) = (0,0,0,0)
		_RotateUVBase ("Rotate UV Base", Float) = 0
		_RotateUVSpeed ("Rotate UV Speed", Float) = 0
		[Toggle(_DISTORTUV_ON)] _DistortUV ("Distort UV", Float) = 0
		_DistortionTexture ("Distortion Texture", 2D) = "white" {}
		_UVDistortionScrollSpeed ("UV Distortion Scroll Speed", Vector) = (0,0,0,0)
		_DistortionStrength ("Distortion Strength", Range(0, 1)) = 0
		[Toggle(_DITHER_ON)] _Dither ("Dither", Float) = 0
		_DitherTexture ("Dither Texture", 2D) = "white" {}
		_DitherPanSpeed ("Dither Pan Speed", Vector) = (0,0,0,0)
		_DitherAlphaMultiplier ("Dither Alpha Multiplier", Float) = 1
		_DitherSoftness ("Dither Softness", Float) = 0
		_DitherTiling ("Dither Tiling", Range(0, 8)) = 0
		_DitherRotation ("Dither Rotation", Range(0, 1)) = 0.15
		_DitherAlphaClip ("Dither Alpha Clip", Float) = 0
		[Toggle(_GRAYSCALECLIPALPHA_ON)] _GrayscaleClipAlpha ("Grayscale Clip Alpha", Float) = 0
		_GrayscaleClipAlphaSoftnessAmount ("Grayscale Clip Alpha Softness Amount", Vector) = (0,0,0,0)
		_#1 ("#", Float) = 0
		[Space] _BaseSurfaceProperties ("#Base UI Properties", Float) = 0
		[Header(Base Parameters)] [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Vector) = (1,1,1,1)
		[Toggle(_SDF)] _AllowSDF ("Allow SDF", Float) = 0
		[Space] _#2 ("#", Float) = 0
		_ShaderProperties ("#Shader Properties", Float) = 0
		[Space] [Header(Assorted)] [Enum(UnityEngine.Rendering.ColorWriteMask)] _ColorMask ("Color Mask", Float) = 15
		[Space] _BlendInfo ("@Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency \n Blend One OneMinusSrcAlpha // Premultiplied transparency \n Blend One One // Additive \n Blend OneMinusDstColor One // Soft additive \n Blend DstColor Zero // Multiplicative \n Blend DstColor SrcColor // 2x multiplicative", Float) = 0
		[Header(Blend RGB)] [Enum(UnityEngine.Rendering.BlendMode)] _SourceBlendRGB ("Source Blend RGB", Float) = 1
		[Enum(UnityEngine.Rendering.BlendMode)] _DestinationBlendRGB ("Destination Blend RGB", Float) = 10
		[Space] [Header(Blend Alpha)] [Enum(UnityEngine.Rendering.BlendMode)] _SourceBlendAlpha ("Source Blend Alpha", Float) = 1
		[Enum(UnityEngine.Rendering.BlendMode)] _DestinationBlendAlpha ("Destination Blend Alpha", Float) = 10
		[Space] [Header(Stencil)] _Stencil ("Stencil Buffer Reference", Range(0, 255)) = 0
		_StencilWriteMask ("Stencil Buffer Write Mask", Range(0, 255)) = 255
		_StencilReadMask ("Stencil Buffer Read Mask", Range(0, 255)) = 255
		[Enum(UnityEngine.Rendering.CompareFunction)] _StencilComp ("Stencil Buffer Comparison", Float) = 8
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilOp ("Stencil Buffer Pass Front", Float) = 0
		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
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
	//CustomEditor "ToonMaterialInspector"
}
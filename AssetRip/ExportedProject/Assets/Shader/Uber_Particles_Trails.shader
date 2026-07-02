Shader "Uber_Particles_Trails" {
	Properties {
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
	//CustomEditor "ASEMaterialInspector"
}
Shader "/Lush/Uber_Particles_Advanced_Xtra" {
	Properties {
		[Space(33)] [Header(Texture)] [Space(33)] _Tex ("Tex", 2D) = "white" {}
		_Tint ("Tint", Vector) = (0.7176471,0.7137255,0.7058824,1)
		_TextureUVScale ("Texture UV Scale", Vector) = (1,1,0,0)
		_TexturePan ("Texture Pan", Vector) = (0,0,0,0)
		[Space(33)] [Header(Distortion)] [Space(33)] _TexDist ("Tex Dist", 2D) = "white" {}
		_TextureDUVScale ("Texture D UV Scale", Vector) = (1,1,0,0)
		_TextureDPan ("Texture D Pan", Vector) = (0,0,0,0)
		_TextureDistortion ("Texture Distortion", Float) = 0
		[Space(33)] [Header(LUT)] [Space(33)] _LUT ("LUT", 2D) = "white" {}
		_LUTOffset ("LUT Offset", Float) = 0
		_TextureMult ("Texture Mult", Float) = 0
		_ErosionSoftness ("Erosion Softness", Float) = 0.05
		_EmissionMult ("Emission Mult", Float) = 1
		[Space(20)] [Toggle(_MASKED_ON)] _Masked ("Masked", Float) = 0
		_Round_Mask_Size ("Round_Mask_Size", Float) = 2.46
		_Round_Mask_Power ("Round_Mask_Power", Float) = 1
		_MaskEdgeAlphaFade ("Mask Edge Alpha Fade", Float) = 0
		_insidemask ("inside mask", Range(0, 1)) = 0
		[Space(20)] [Toggle(_GROUNDDEPTHFADE_ON)] _GroundDepthFade ("GroundDepthFade", Float) = 0
		_DepthFadeDistance ("Depth Fade Distance", Float) = 1
		_DepthFadeSharpness ("Depth Fade Sharpness", Float) = 1
		[Space(33)] [Header(AR)] [Space(33)] _Cull ("Cull", Float) = 2
		_Src ("Src", Float) = 5
		_Dst ("Dst", Float) = 10
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
		[Toggle(_FACECOLORSWITCH_ON)] _FaceColorSwitch ("FaceColorSwitch", Float) = 0
		_ColorFront ("Color Front", Vector) = (0.7176471,0.7137255,0.7058824,1)
		_ColorBack ("Color Back", Vector) = (0.5921569,0.5568628,0.5843138,1)
		[Toggle(_POLAR_COORDINATES_ON)] _Polar_Coordinates ("Polar_Coordinates", Float) = 0
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
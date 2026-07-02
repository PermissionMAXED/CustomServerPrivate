Shader "/Lush/Vefects_Skinny_Head_Flame" {
	Properties {
		_ChromaticAberrationMax ("Chromatic Aberration Max", Float) = 0.05
		_ChromaticAberrationPreMult ("Chromatic Aberration Pre Mult", Float) = 0.3
		_Texture ("Texture", 2D) = "white" {}
		_TextureUVScale ("Texture UV Scale", Vector) = (1,1,0,0)
		_TexturePan ("Texture Pan", Vector) = (0,0,0,0)
		[Space(33)] [Header(Distortion)] [Space(33)] _TexDist ("Tex Dist", 2D) = "white" {}
		[Space(33)] [Header(Distortion)] [Space(33)] _TexDistSecond ("Tex Dist Second", 2D) = "white" {}
		_TextureDUVScale ("Texture D UV Scale", Vector) = (1,1,0,0)
		_TextureDSUVScale ("Texture D S UV Scale", Vector) = (1,1,0,0)
		_TextureDPan ("Texture D Pan", Vector) = (0,0,0,0)
		_TextureDSPan ("Texture D S Pan", Vector) = (0,0,0,0)
		_TextureDistortionSecond ("Texture Distortion Second", Float) = 0.03
		_TextureDistortion ("Texture Distortion", Float) = 0.03
		_ErosionDebug ("Erosion Debug", Float) = 0.05
		_ErosionSoftness ("Erosion Softness", Float) = 0.05
		[Toggle(_EROSIONREVERSE_ON)] _ErosionReverse ("Erosion Reverse", Float) = 0
		_EmissionMult ("Emission Mult", Float) = 1
		[Space(33)] [Header(Clip Mask)] [Space(33)] _ClipMask ("Clip Mask", 2D) = "white" {}
		_ClipMaskPower ("Clip Mask Power", Float) = 1
		_ClipMaskMultiply ("Clip Mask Multiply", Float) = 1
		[Space(33)] [Header(AR)] [Space(33)] _Cull ("Cull", Float) = 2
		_Src ("Src", Float) = 5
		_Dst ("Dst", Float) = 10
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
		_ColorBottom ("Color Bottom", Vector) = (0.4941177,0.8078432,0.9647059,1)
		_ColorTop ("Color Top", Vector) = (0.6392157,0.5882353,0.9568628,1)
		_ColorTertiary ("Color Tertiary", Vector) = (0.1490196,0.1058824,0.4039216,1)
		_GradientPow ("Gradient Pow", Float) = 1
		_GradientMult ("Gradient Mult", Float) = 1
		_GradientDir ("Gradient Dir", Float) = 0
		[HideInInspector] _texcoord ("", 2D) = "white" {}
		[HideInInspector] _tex4coord2 ("", 2D) = "white" {}
		[HideInInspector] _tex4coord ("", 2D) = "white" {}
		[HideInInspector] __dirty ("", Float) = 1
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
Shader "/Lush/Uber_Particles_Advanced_Medusa_Walls" {
	Properties {
		[Space(33)] [Header(Texture)] [Space(33)] _TextureErosion ("Texture Erosion", 2D) = "white" {}
		[Space(33)] [Header(Texture)] [Space(33)] _TexTop ("Tex Top", 2D) = "white" {}
		_TextureUVScale ("Texture UV Scale", Vector) = (1,1,0,0)
		_TextureEUVScale ("Texture E UV Scale", Vector) = (1,1,0,0)
		_TexturePan ("Texture Pan", Vector) = (0,0,0,0)
		_TextureEPan ("Texture E Pan", Vector) = (0,0,0,0)
		[Space(33)] [Header(Distortion)] [Space(33)] _TexDist ("Tex Dist", 2D) = "white" {}
		[Space(33)] [Header(Distortion)] [Space(33)] _TexEDist ("Tex E Dist", 2D) = "white" {}
		_TextureDUVScale ("Texture D UV Scale", Vector) = (1,1,0,0)
		_TextureEDUVScale ("Texture E D UV Scale", Vector) = (1,1,0,0)
		_TextureDPan ("Texture D Pan", Vector) = (0,0,0,0)
		_TextureEDPan ("Texture E D Pan", Vector) = (0,0,0,0)
		_TextureEDistortion ("Texture E Distortion", Float) = 0
		_TextureDistortion ("Texture Distortion", Float) = 0
		_ErosionSoftness ("Erosion Softness", Float) = 0.05
		_EmissionMult ("Emission Mult", Float) = 1
		[Space(33)] [Header(AR)] [Space(33)] _Cull ("Cull", Float) = 2
		_Src ("Src", Float) = 5
		_Dst ("Dst", Float) = 10
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
		_ErosionCutHeightMult ("Erosion Cut Height Mult", Float) = 15
		_ErosionCutHeightPow ("Erosion Cut Height Pow", Float) = 15
		_GradientPow ("Gradient Pow", Float) = 3
		_GradientMult ("Gradient Mult", Float) = 1
		_Color01 ("Color 01", Vector) = (0.4117647,0.7647059,0.2745098,0)
		_Color03 ("Color 03", Vector) = (0.4196079,0.9137256,0.454902,1)
		_Color02 ("Color 02", Vector) = (0.03921569,0.3215686,0.2627451,0)
		_TopTextureEro ("Top Texture Ero", Float) = 0.7
		_TopTextureEroPow ("Top Texture Ero Pow", Float) = 0.7
		_TopTextureEroMult ("Top Texture Ero Mult", Float) = 1.5
		_TopTextureEroSmooth ("Top Texture Ero Smooth", Float) = 0.1
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
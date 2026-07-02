Shader "/Lush/Uber_Particles_Advanced_Chromatic_Aberration" {
	Properties {
		_ChromaticAberrationMax ("Chromatic Aberration Max", Float) = 0.05
		_ChromaticAberrationPreMult ("Chromatic Aberration Pre Mult", Float) = 0.3
		_Texture ("Texture", 2D) = "white" {}
		_TextureUVScale ("Texture UV Scale", Vector) = (1,1,0,0)
		_TexturePan ("Texture Pan", Vector) = (0,0,0,0)
		[Space(33)] [Header(Distortion)] [Space(33)] _TexDist ("Tex Dist", 2D) = "white" {}
		_TextureDUVScale ("Texture D UV Scale", Vector) = (1,1,0,0)
		_TextureDPan ("Texture D Pan", Vector) = (0,0,0,0)
		_ErosionSoftness ("Erosion Softness", Float) = 0.05
		_EmissionMult ("Emission Mult", Float) = 1
		[Space(33)] [Header(AR)] [Space(33)] _Cull ("Cull", Float) = 2
		_Src ("Src", Float) = 5
		_Dst ("Dst", Float) = 10
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
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
Shader "/Lush/Uber_Particles_Advanced" {
	Properties {
		[Space(33)] [Header(Texture)] [Space(33)] _Tex ("Tex", 2D) = "white" {}
		_LUT ("LUT", 2D) = "white" {}
		[Header(MatCap Parameters)] _Matcap ("Matcap", 2D) = "white" {}
		_LUTOffset ("LUT Offset", Float) = 0
		_TextureMult ("Texture Mult", Float) = 0
		_ErosionSoftness ("Erosion Softness", Float) = 0.05
		_EmissionMult ("Emission Mult", Float) = 1
		[Space(33)] [Header(AR)] [Space(33)] _Cull ("Cull", Float) = 2
		_Src ("Src", Float) = 5
		_Dst ("Dst", Float) = 10
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
		[Toggle(_FACECOLORSWITCH_ON)] _FaceColorSwitch ("FaceColorSwitch", Float) = 0
		[Toggle] _IsMatcap ("Is Matcap", Float) = 1
		_Matcap_Amount ("Matcap_Amount", Range(0, 1)) = 0.5
		_Normal ("Normal", 2D) = "bump" {}
		_ColorFront ("Color Front", Vector) = (0.7176471,0.7137255,0.7058824,1)
		_ColorBack ("Color Back", Vector) = (0.5921569,0.5568628,0.5843138,1)
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
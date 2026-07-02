Shader "/Lush/Uber_Particles_Advanced_scroll" {
	Properties {
		[Space(33)] [Header(Texture)] [Space(33)] _Tex ("Tex", 2D) = "white" {}
		_LUT ("LUT", 2D) = "white" {}
		_LUTOffset ("LUT Offset", Float) = 0
		_TextureMult ("Texture Mult", Float) = 0
		_ErosionSoftness ("Erosion Softness", Float) = 0.05
		_EmissionMult ("Emission Mult", Float) = 1
		_twist ("twist", Float) = 0
		[Space(33)] [Header(AR)] [Space(33)] _Cull ("Cull", Float) = 2
		_Src ("Src", Float) = 5
		_Dst ("Dst", Float) = 10
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
		[Toggle(_FACECOLORSWITCH_ON)] _FaceColorSwitch ("FaceColorSwitch", Float) = 0
		_ColorFront ("Color Front", Vector) = (0.7176471,0.7137255,0.7058824,1)
		_ColorBack ("Color Back", Vector) = (0.5921569,0.5568628,0.5843138,1)
		_USpeed ("U Speed", Float) = 0
		_VSpeed ("V Speed", Float) = 0
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
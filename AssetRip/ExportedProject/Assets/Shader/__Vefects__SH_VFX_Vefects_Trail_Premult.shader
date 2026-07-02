Shader "/_Vefects_/SH_VFX_Vefects_Trail_Premult" {
	Properties {
		_Texture ("Texture", 2D) = "white" {}
		_TextureChannel ("Texture Channel", Vector) = (0,1,0,0)
		_TextureRotation ("Texture Rotation", Float) = 0
		_TextureSpeed ("Texture Speed", Vector) = (0.5,0.5,0,0)
		_SecondaryTexture ("Secondary Texture", 2D) = "white" {}
		_SecTextureChannel ("Sec Texture Channel", Vector) = (0,1,0,0)
		_SecTextureRotation ("Sec Texture Rotation", Float) = 0
		_SecTextureSpeed ("Sec Texture Speed", Vector) = (0.5,0.5,0,0)
		_DistortTexture ("Distort Texture", 2D) = "white" {}
		_DistortTextureChannel ("Distort Texture Channel", Vector) = (0,1,0,0)
		_DistortTextureRotation ("Distort Texture Rotation", Float) = 0
		_DistortSpeed ("Distort Speed", Vector) = (0.5,0.5,0,0)
		_DistortPower ("Distort Power", Float) = 0
		[Space(33)] [Header(AR)] [Space(33)] _Cull1 ("Cull", Float) = 2
		_Src1 ("Src", Float) = 5
		_DistortCorrection ("Distort Correction", Vector) = (0,0,0,0)
		_DissolveMask ("Dissolve Mask", 2D) = "white" {}
		_Dst1 ("Dst", Float) = 10
		_DissolveMaskChannel ("Dissolve Mask Channel", Vector) = (0,1,0,0)
		_ZWrite1 ("ZWrite", Float) = 0
		_ZTest1 ("ZTest", Float) = 2
		_DissolveMaskRotation ("Dissolve Mask Rotation", Float) = 0
		_DissolveMaskInvert ("Dissolve Mask Invert", Range(0, 1)) = 0
		_GradientMap ("Gradient Map", 2D) = "white" {}
		_GradientMapDisplacement ("Gradient Map Displacement", Float) = 0.1
		_InvertGradient ("Invert Gradient", Float) = 0
		_AlphaBoldness ("Alpha Boldness", Float) = 1
		_Brightness ("Brightness", Float) = 1
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
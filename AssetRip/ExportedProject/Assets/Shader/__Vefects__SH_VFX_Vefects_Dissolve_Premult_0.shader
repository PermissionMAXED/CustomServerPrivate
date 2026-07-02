Shader "/_Vefects_/SH_VFX_Vefects_Dissolve_Premult" {
	Properties {
		_Texture ("Texture", 2D) = "white" {}
		_TextureChannel ("Texture Channel", Vector) = (0,1,0,0)
		_TextureRotation ("Texture Rotation", Float) = 0
		_GradientShape ("Gradient Shape", 2D) = "white" {}
		_GradientShapeChannel ("Gradient Shape Channel", Vector) = (0,1,0,0)
		_GradientShapeRotation ("Gradient Shape Rotation", Float) = 0
		_DissolveMask ("Dissolve Mask", 2D) = "white" {}
		_DissolveMaskChannel ("Dissolve Mask Channel", Vector) = (0,1,0,0)
		_DissolveMaskRotation ("Dissolve Mask Rotation", Float) = 0
		_DissolveMaskInvert ("Dissolve Mask Invert", Range(0, 1)) = 0
		_GradientMap ("Gradient Map", 2D) = "white" {}
		_GradientMapDisplacement ("Gradient Map Displacement", Float) = 0.1
		_InvertGradient ("Invert Gradient", Float) = 0
		_CorrossionAffectsGradient ("Corrossion Affects Gradient", Range(0, 1)) = 1
		_Brightness ("Brightness", Float) = 1
		_AlphaBoldness ("Alpha Boldness", Float) = 1
		_FrontColor ("Front Color", Vector) = (1,1,1,0)
		_BackColor ("Back Color", Vector) = (0.3207547,0.3207547,0.3207547,0)
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
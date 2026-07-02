Shader "/_Vefects_/SH_VFX_Vefects_Toon_Boom_Premult" {
	Properties {
		_HeatDissolveTexture ("Heat Dissolve Texture", 2D) = "white" {}
		_HeatDissolveChannel ("Heat Dissolve Channel", Vector) = (0,1,0,0)
		_HeatDissolveRotation ("Heat Dissolve Rotation", Float) = 0
		_HeatDissolveMaskInvert ("Heat Dissolve Mask Invert", Range(0, 1)) = 0
		_DissolveMask ("Dissolve Mask", 2D) = "white" {}
		_DissolveMaskChannel ("Dissolve Mask Channel", Vector) = (0,1,0,0)
		_DissolveMaskRotation ("Dissolve Mask Rotation", Float) = 0
		_DissolveMaskInvert ("Dissolve Mask Invert", Range(0, 1)) = 0
		_DissolveShape ("Dissolve Shape", 2D) = "white" {}
		_DissolveShapeChannel ("Dissolve Shape Channel", Vector) = (0,1,0,0)
		_DissolveShapeRotation ("Dissolve Shape Rotation", Float) = 0
		_SmokeGradient ("Smoke Gradient", 2D) = "white" {}
		_SmokeTint ("Smoke Tint", Vector) = (0,0,0,0)
		_SmokeGradientDisplacement ("Smoke Gradient Displacement", Float) = 0.1
		_InvertSmokeGradient ("Invert Smoke Gradient", Float) = 0
		_HeatGradient ("Heat Gradient", 2D) = "white" {}
		_HeatGradientDisplacement ("Heat Gradient Displacement", Float) = 0.1
		_HeatTint ("Heat Tint", Vector) = (0,0,0,0)
		_InvertHeatGradient ("Invert Heat Gradient", Float) = 0
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
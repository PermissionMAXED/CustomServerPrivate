Shader "/Lush/Slash" {
	Properties {
		_TextureSample0 ("Texture Sample 0", 2D) = "white" {}
		[HDR] _Color01 ("Color 01", Vector) = (1,1,1,0)
		[HDR] _Color02 ("Color 02", Vector) = (1,0,0.3212681,0)
		[HDR] _Color03 ("Color 03", Vector) = (1,0.6134583,0,0)
		_Src ("Src", Float) = 5
		_Cull ("Cull", Float) = 2
		_Dst ("Dst", Float) = 10
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
		_SmoothStepSoftness ("SmoothStep Softness", Float) = 0.05
		_GradientContrast ("Gradient Contrast", Float) = 2
		_GradientContrastMult ("Gradient Contrast Mult", Float) = 2
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
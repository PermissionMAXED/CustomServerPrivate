Shader "Hidden/SamplerNode" {
	Properties {
		_B ("_UVs", 2D) = "white" {}
		_C ("_Level", 2D) = "white" {}
		_F ("_NormalScale", 2D) = "white" {}
		_G ("Index", 2D) = "white" {}
		_CustomUVs ("_CustomUVs", Float) = 0
		_Unpack ("_Unpack", Float) = 0
		_LodType ("_LodType", Float) = 0
		_Sampler ("_Sampler", 2D) = "white" {}
		_Sampler3D ("_Sampler3D", 3D) = "white" {}
		_Array ("_Array", 2DArray) = "white" {}
		_Cube ("_Cube", Cube) = "white" {}
		_Default ("_Default", Float) = 0
		_Type ("_Type", Float) = 0
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
}
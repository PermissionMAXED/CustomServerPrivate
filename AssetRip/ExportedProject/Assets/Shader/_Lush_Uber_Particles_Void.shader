Shader "/Lush/Uber_Particles_Void" {
	Properties {
		[Space(33)] [Header(AR)] [Space(33)] _Cull ("Cull", Float) = 2
		_ZWrite ("ZWrite", Float) = 0
		_ZTest ("ZTest", Float) = 2
		_Src ("Src", Float) = 5
		_Dst ("Dst", Float) = 10
		_Void_Color ("Void_Color", Vector) = (0,0,0,1)
		_Stars_Color ("Stars_Color", Vector) = (1,0,0,1)
		_Start_Pos ("Start_Pos", Float) = 1
		_Distance ("Distance", Float) = 0.1
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
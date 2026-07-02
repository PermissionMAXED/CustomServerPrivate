Shader "Hidden/App UI/CanvasBackground" {
	Properties {
		_TexSize ("TexSize", Vector) = (1,1,1,1)
		_Thickness ("Thickness", Float) = 2
		_Spacing ("Spacing", Float) = 24
		_Color ("Color", Vector) = (1,1,1,1)
		_Opacity ("Opacity", Range(0, 1)) = 1
		_Scale ("Scale", Float) = 1
		[Toggle(DRAW_POINTS_ON)] _DrawPoints ("Draw Points", Float) = 1
	}
	//DummyShaderTextExporter
	SubShader{
		Tags { "RenderType"="Opaque" }
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

			float4 _Color;

			float4 frag(Vertex_Stage_Output input) : SV_TARGET
			{
				return _Color; // RGBA
			}

			ENDHLSL
		}
	}
}
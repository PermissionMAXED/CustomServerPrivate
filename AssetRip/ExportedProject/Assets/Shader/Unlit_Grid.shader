Shader "Unlit/Grid" {
	Properties {
		_GridColour ("Grid Colour", Vector) = (1,1,1,1)
		_BaseColour ("Base Colour", Vector) = (1,1,1,0)
		_GridSpacing ("Grid Spacing", Float) = 1
		_GridOffsetX ("Grid Offset X", Float) = 0
		_GridOffsetZ ("Grid Offset Z", Float) = 0
		_LineThickness ("Line Thickness", Float) = 0.1
		_ODistance ("Start Transparency Distance", Float) = 5
		_TDistance ("Full Transparency Distance", Float) = 10
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
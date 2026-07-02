Shader "Custom/SpriteCircleConeIndicator" {
	Properties {
		_Color ("Color", Vector) = (1,1,1,1)
		[Header(Circle Settings)] _EdgeSize ("Edge Size", Float) = 0.1
		_EdgeAlpha ("Edge Alpha", Range(0, 1)) = 1
		_BaseAlpha ("Base Alpha", Range(0, 1)) = 0.1
		[Header(Cone Settings)] _Frac ("ConeAngle", Float) = 0.1
		[Toggle(SMOOTHSTEP)] _Smoothstep ("Use Smoothstep", Float) = 0
		[Toggle(_FOW_OCCLUSION)] _FoWOcclusion ("FoW Occlusion", Float) = 0
		_ZTest ("ZTest", Float) = 0
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
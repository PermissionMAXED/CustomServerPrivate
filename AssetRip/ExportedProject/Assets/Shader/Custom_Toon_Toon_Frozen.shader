Shader "Custom/Toon/Toon_Frozen" {
	Properties {
		_TColor ("Top Color", Vector) = (0.64,0.77,0.94,1)
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		_BottomColor ("Bottom Color", Vector) = (0.23,0,0.95,1)
		_BotColorIntensity ("Bot Color Intensity", Float) = 1
		_NormalExpandSize ("Normal Expand Size", Range(0, 0.1)) = 0.01
		_NormalBottomAmplitude ("Normal Bottom Amplitude", Float) = 4
		_NormalBottomFrequency ("Normal Bottom Frequency", Float) = 500
		_Alpha ("Alpha", Range(0, 1)) = 1
		[HideInInspector] _Color ("Color", Vector) = (1,1,1,1)
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
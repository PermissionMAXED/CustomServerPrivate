Shader "Hidden/Buto/VolumeNoiseShader" {
	Properties {
		[IntRange] _Frequency ("Frequency", Range(1, 32)) = 2
		[IntRange] _Octaves ("Octaves", Range(1, 8)) = 3
		[IntRange] _Lacunarity ("Lacunarity", Range(1, 8)) = 2
		_Gain ("Gain", Range(0, 1)) = 0.3
		_Height ("Height", Range(0, 1)) = 0
		_Seed ("Seed", Float) = 0
		[KeywordEnum(Perlin, Worley, PerlinWorley, Billow, Curl)] _Type ("Noise Type", Float) = 0
		[Toggle(_INVERT_ON)] _Invert ("Invert", Float) = 0
		[Toggle(_GRAYSCALE_ON)] _Grayscale ("Grayscale", Float) = 1
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
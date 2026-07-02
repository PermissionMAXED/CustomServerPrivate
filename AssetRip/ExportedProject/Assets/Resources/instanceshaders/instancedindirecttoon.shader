Shader "MobileDrawMeshInstancedIndirect/SingleToon" {
	Properties {
		_Scale ("Scale", Range(0, 1)) = 0.2
		_BlendVariation ("Blend Variation", Range(0, 1)) = 0.2
		_BaseColor ("BaseColor", Vector) = (1,1,1,1)
		_BaseColorTexture ("_BaseColorTexture", 2D) = "white" {}
		_VariationTexture ("_VariationTexture", 2D) = "white" {}
		[Header(Lighting Parameters)] _ShadowColor ("Shadow Color", Vector) = (0.6711962,0.690205,0.84,1)
		[KeywordEnum(None, SmoothStep, FWidth)] _AA ("Antialiasing Mode", Float) = 1
		_ShadingThreshold ("Shading Threshold", Range(-1, 1)) = 0.26
		_ShadingSmooth ("Shading Smooth", Range(0.0001, 0.1)) = 0.01
		[Header(Lighting Settings)] _AmbientContribution ("Ambient Contribution", Range(0, 1)) = 0.2
		_LightingIntensity ("Lighting Intensity", Float) = 2
		[Header(Debug)] _Debug ("Debug", Range(0, 1)) = 0
		[HideInInspector] _PivotPosWS ("_PivotPosWS", Vector) = (0,0,0,0)
		[HideInInspector] _BoundSize ("_BoundSize", Vector) = (1,1,0,1)
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
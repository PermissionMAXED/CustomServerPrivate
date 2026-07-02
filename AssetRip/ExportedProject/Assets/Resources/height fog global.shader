Shader "Hidden/BOXOPHOBIC/Atmospherics/Height Fog Global" {
	Properties {
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[StyledCategory(Fog)] _FogCat ("[ Fog Cat]", Float) = 1
		[Enum(X Axis,0,Y Axis,1,Z Axis,2)] [Space(10)] _FogAxisMode ("Fog Axis Mode", Float) = 1
		[StyledCategory(Skybox)] _SkyboxCat ("[ Skybox Cat ]", Float) = 1
		[StyledCategory(Directional)] _DirectionalCat ("[ Directional Cat ]", Float) = 1
		[StyledCategory(Noise)] _NoiseCat ("[ Noise Cat ]", Float) = 1
		[StyledCategory(Advanced)] _AdvancedCat ("[ Advanced Cat ]", Float) = 1
		[HideInInspector] _HeightFogGlobal ("_HeightFogGlobal", Float) = 1
		[HideInInspector] _IsHeightFogShader ("_IsHeightFogShader", Float) = 1
		[ASEEnd] [StyledBanner(Height Fog Global)] _Banner ("[ Banner ]", Float) = 1
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
	Fallback "Hidden/InternalErrorShader"
	//CustomEditor "HeightFogShaderGUI"
}
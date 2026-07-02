Shader "Custom/SimpleDepth" {
	Properties {
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		_Distance ("Distance", Float) = 0
		[StyledCategory(Fog Settings, false, _HeightFogStandalone, 10, 10)] _FogCat ("[ Fog Cat]", Float) = 1
		[StyledCategory(Skybox Settings, false, _HeightFogStandalone, 10, 10)] _SkyboxCat ("[ Skybox Cat ]", Float) = 1
		[StyledCategory(Directional Settings, false, _HeightFogStandalone, 10, 10)] _DirectionalCat ("[ Directional Cat ]", Float) = 1
		[StyledCategory(Noise Settings, false, _HeightFogStandalone, 10, 10)] _NoiseCat ("[ Noise Cat ]", Float) = 1
		[StyledCategory(Advanced Settings, false, _HeightFogStandalone, 10, 10)] _AdvancedCat ("[ Advanced Cat ]", Float) = 1
		_Falloff ("Falloff", Float) = 0
		_Shallowcolor ("Shallow color", Vector) = (0.3930817,0.7821063,1,0)
		_Deepcolor ("Deep color", Vector) = (0,0.06447315,1,0)
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
		[ToggleOff] [HideInInspector] _ReceiveShadows ("Receive Shadows", Float) = 1
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
	//CustomEditor "UnityEditor.ShaderGraphUnlitGUI"
}
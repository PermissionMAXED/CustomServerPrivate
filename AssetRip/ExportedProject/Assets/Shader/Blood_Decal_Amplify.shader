Shader "Blood_Decal_Amplify" {
	Properties {
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		_DarkMaskStartSize ("Dark Mask Start Size", Float) = 1
		_BloodNoiseTiling ("Blood Noise Tiling", Float) = 0
		_BloodNormalTiling1 ("Blood Normal Tiling", Float) = 0
		_BloodWorldNoise ("Blood World Noise", 2D) = "white" {}
		_BloodEdgeFeather ("Blood Edge Feather", Range(0, 1)) = 0
		_BloodEdgeFeather2 ("Blood Edge Feather 2", Range(0, 1)) = 0
		_BloodEdgeOffset ("Blood Edge Offset", Range(-1, 1)) = 0
		_NoiseValueSharpness ("Noise Value Sharpness", Range(0.001, 1)) = 0.01
		_TextureSample1 ("Texture Sample 1", 2D) = "white" {}
		_ReflectionAmount ("Reflection Amount", Float) = 0
		_NormalStrength ("Normal Strength", Float) = 1
		_BloodTint ("Blood Tint", Vector) = (0.6132076,0,0,0)
		_TextureSample2 ("Texture Sample 2", 2D) = "white" {}
		[HideInInspector] _DrawOrder ("Draw Order", Range(-50, 50)) = 0
		[Enum(Depth Bias, 0, View Bias, 1)] [HideInInspector] _DecalMeshBiasType ("DecalMesh BiasType", Float) = 0
		[HideInInspector] _DecalMeshDepthBias ("DecalMesh DepthBias", Float) = 0
		[HideInInspector] _DecalMeshViewBias ("DecalMesh ViewBias", Float) = 0
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
		[HideInInspector] _DecalAngleFadeSupported ("Decal Angle Fade Supported", Float) = 1
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
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "UnityEditor.Rendering.Universal.DecalShaderGraphGUI"
}
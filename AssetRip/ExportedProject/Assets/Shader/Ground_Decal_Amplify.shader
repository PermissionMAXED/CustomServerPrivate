Shader "Ground_Decal_Amplify" {
	Properties {
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		_Tint ("Tint", Vector) = (1,1,1,0)
		_DarkMaskStartSize ("Dark Mask Start Size", Float) = 0.55
		_NoiseTiling ("Noise Tiling", Float) = 20.08
		_WorldNoise ("World Noise", 2D) = "white" {}
		_EdgeFeather ("Edge Feather", Range(0, 5)) = 5
		_NoiseValueSharpness ("Noise Value Sharpness", Range(0.001, 1)) = 0.5550684
		_MainTexture ("Main Texture", 2D) = "white" {}
		_BiomeHeightPower ("Biome Height Power", Float) = 1
		_SplatHeightPower ("Splat Height Power", Float) = 1
		_GHardness ("G Hardness", Float) = 0
		_DebugBlendFactor ("Debug Blend Factor", Float) = 0
		_LocalDenominator ("Local Denominator", Float) = 0
		_LocalTilingSize ("Local Tiling Size", Vector) = (0,0,0,0)
		_BlendSmoothstep ("Blend Smoothstep", Vector) = (0,0,0,0)
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
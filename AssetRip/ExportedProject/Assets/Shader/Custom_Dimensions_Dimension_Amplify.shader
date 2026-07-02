Shader "Custom/Dimensions/Dimension_Amplify" {
	Properties {
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		_ParallaxTiling ("Parallax Tiling", Float) = 0
		_DimensionEdgeTiling ("DimensionEdgeTiling", Float) = 0
		_DimensionEdgePattern ("Dimension Edge Pattern", 2D) = "white" {}
		_EdgeErosionAmount ("Edge Erosion Amount", Range(0, 1)) = 0
		_EdgeErosionSoftness ("Edge Erosion Softness", Range(0, 1)) = 0
		_EdgeErosionAmount2 ("Edge Erosion Amount 2", Range(0, 1)) = 0
		_EdgeErosionSoftness2 ("Edge Erosion Softness 2", Range(0, 1)) = 0
		[HDR] _InnerColor ("Inner Color", Vector) = (0,0,0,0)
		[HDR] _OuterColor ("Outer Color", Vector) = (0,0,0,0)
		[HDR] _OuterColor2 ("Outer Color 2", Vector) = (0,0,0,0)
		_OuterColorLerpMultiplier ("Outer Color Lerp Multiplier", Float) = 1
		_ScrollSpeedU ("Scroll Speed U", Float) = 0
		_ScrollSpeedV ("Scroll Speed V", Float) = 0
		_HalftoneFrequency ("Halftone Frequency", Float) = 0
		_HalftoneRadius ("Halftone Radius", Float) = 0
		_EdgeMaskPower ("Edge Mask Power", Float) = 0
		_EdgeMaskOuterPower ("Edge Mask Outer Power", Float) = 0
		_ParallaxAmount ("Parallax Amount", Float) = 0
		[HDR] _ParallaxColor ("Parallax Color", Vector) = (0,0,0,0)
		_HalftoneIntensityPower ("Halftone Intensity Power", Float) = 0
		_AlphaClip ("Alpha Clip", Float) = 0
		_Float0 ("Float 0", Float) = 0
		_ParallaxTexture ("Parallax Texture", 2D) = "white" {}
		_ParallaxErosionSoftness ("Parallax Erosion Softness", Range(0, 1)) = 0
		_ParallaxErosionAmount ("Parallax Erosion Amount", Range(0, 1)) = 0
		_ParallaxOffsetSpeed ("Parallax Offset Speed", Vector) = (0,0,0,0)
		_ParallaxOffsetTiling ("Parallax Offset Tiling", Float) = 0
		_OuterBlendMultiplier ("Outer Blend Multiplier", Float) = 0
		_OuterErodedFinalStep ("Outer Eroded Final Step", Float) = 0
		_OuterErodedFinalWidth ("Outer Eroded Final Width", Float) = 0
		[HDR] _OuterColorEdge ("Outer Color Edge", Vector) = (0,0,0,0)
		_Float1 ("Float 1", Float) = 0
		_Float2 ("Float 2", Float) = 0
		_LocalCharSphereMaxWidth ("Local Char Sphere Max Width", Float) = 0
		_LocalCharSphereHeight ("Local Char Sphere Height", Float) = 0
		_LocalCharSphereRadius ("Local Char Sphere Radius", Float) = 0
		_LocalCharSphereIntensity ("Local Char Sphere Intensity", Float) = 0
		_LocalCharSphereMoveIntensity ("Local Char Sphere Move Intensity", Float) = 0
		_CollisionRadius ("Collision Radius", Float) = 0
		_CollisionSphereIntensity ("CollisionSphereIntensity", Float) = 0
		_CollisionSphereHeight ("Collision Sphere Height", Float) = 0
		_CollisionMoveIntensity ("CollisionMoveIntensity", Float) = 0
		[PerRendererData] _DimensionType ("_DimensionType", Float) = 0
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
	Fallback "Hidden/Shader Graph/FallbackError"
	//CustomEditor "ASEMaterialInspector"
}
Shader "SuperSystems/Wireframe-Transparent" {
	Properties {
		_WireThickness ("Wire Thickness", Range(0, 800)) = 100
		_WireSmoothness ("Wire Smoothness", Range(0, 20)) = 3
		_WireColor ("Wire Color", Vector) = (0,1,0,1)
		_BaseColor ("Base Color", Vector) = (0,0,0,0)
		_MaxTriSize ("Max Tri Size", Range(0, 200)) = 25
		[Toggle] _UseVertexColor ("Use Vertex Color", Float) = 0
		[Space] _BaseSurfaceProperties ("#Base Surface Properties", Float) = 0
		[Header(Base Parameters)] _Color ("Tint", Vector) = (0,0,0,1)
		[NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
		[Header(Lighting Parameters)] _Unlit ("!Unlit", Float) = 0
		_RampShading ("!Ramp Shading", Float) = 0
		_Ramp ("%Ramp", 2D) = "white" {}
		_ShadowColor ("Shadow Color", Vector) = (0.6711962,0.690205,0.84,1)
		[Enum(None,0,SmoothStep,1,FWidth,2)] _AA ("Antialiasing Mode", Float) = 1
		_ShadingThreshold ("Shading Threshold", Range(-1, 1)) = 0.26
		_ShadingSmooth ("Shading Smooth", Range(0.0001, 0.1)) = 0.01
		[Header(Lighting Settings)] _AmbientContribution ("Ambient Contribution", Range(0, 1)) = 0.2
		_LightingIntensity ("Lighting Intensity", Float) = 2
		[Space] _ShaderProperties ("#Shader Properties", Float) = 0
		[Header(Render Face)] [Enum(Front,2,Back,1,Both,0)] _Cull ("Render Face", Float) = 2
		[Space] [Header(Depth)] [Enum(Off,0,On,1)] _ZWriteMode ("ZWrite Mode", Float) = 1
		[Enum(UnityEngine.Rendering.CompareFunction)] _ZTestMode ("ZTest Mode", Float) = 4
		_DepthOffsetFactor ("Depth Offset Factor", Float) = 0
		_DepthOffsetUnits ("Depth Offset Units", Float) = 0
		[Space] [Header(Assorted)] [Enum(UnityEngine.Rendering.ColorWriteMask)] _ColorMask ("Color Mask", Float) = 15
		[Enum(Off,0,On,1)] _AlphatoCoverage ("Alpha to Coverage", Float) = 0
		[Space] _BlendInfo ("@Blend SrcAlpha OneMinusSrcAlpha // Traditional transparency \n Blend One OneMinusSrcAlpha // Premultiplied transparency \n Blend One One // Additive \n Blend OneMinusDstColor One // Soft additive \n Blend DstColor Zero // Multiplicative \n Blend DstColor SrcColor // 2x multiplicative", Float) = 0
		[Header(Blend RGB)] [Enum(UnityEngine.Rendering.BlendMode)] _SourceBlendRGB ("Source Blend RGB", Float) = 5
		[Enum(UnityEngine.Rendering.BlendMode)] _DestinationBlendRGB ("Destination Blend RGB", Float) = 10
		[Space] [Header(Blend Alpha)] [Enum(UnityEngine.Rendering.BlendMode)] _SourceBlendAlpha ("Source Blend Alpha", Float) = 1
		[Enum(UnityEngine.Rendering.BlendMode)] _DestinationBlendAlpha ("Destination Blend Alpha", Float) = 10
		[Space] [Header(Stencil)] _StencilBufferReference ("Stencil Buffer Reference", Range(0, 255)) = 0
		_StencilBufferWriteMask ("Stencil Buffer Write Mask", Range(0, 255)) = 255
		_StencilBufferReadMask ("Stencil Buffer Read Mask", Range(0, 255)) = 255
		[Enum(UnityEngine.Rendering.CompareFunction)] _StencilBufferComparison ("Stencil Buffer Comparison", Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilBufferPassFront ("Stencil Buffer Pass Front", Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilBufferFailFront ("Stencil Buffer Fail Front", Float) = 0
		[Enum(UnityEngine.Rendering.StencilOp)] _StencilBufferZFailFront ("Stencil Buffer ZFail Front", Float) = 0
		_#5 ("#", Float) = 0
		_RightBound ("[RightBound]", Float) = 0
		[HideInInspector] _QueueOffset ("_QueueOffset", Float) = 0
		[HideInInspector] _QueueControl ("_QueueControl", Float) = -1
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
		[ToggleOff] [HideInInspector] _ReceiveShadows ("Receive Shadows", Float) = 1
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
			float4 _MainTex_ST;

			struct Vertex_Stage_Input
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct Vertex_Stage_Output
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;
			};

			Vertex_Stage_Output vert(Vertex_Stage_Input input)
			{
				Vertex_Stage_Output output;
				output.uv = (input.uv.xy * _MainTex_ST.xy) + _MainTex_ST.zw;
				output.pos = mul(unity_MatrixVP, mul(unity_ObjectToWorld, input.pos));
				return output;
			}

			Texture2D<float4> _MainTex;
			SamplerState sampler_MainTex;
			float4 _Color;

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy) * _Color;
			}

			ENDHLSL
		}
	}
	//CustomEditor "ToonMaterialInspector"
}
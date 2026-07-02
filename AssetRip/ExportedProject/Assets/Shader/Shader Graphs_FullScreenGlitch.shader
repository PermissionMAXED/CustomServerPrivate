Shader "Shader Graphs/FullScreenGlitch" {
	Properties {
		_GlitchVoronoi ("GlitchVoronoi", 2D) = "white" {}
		_VoronoiOffset ("VoronoiOffset", Float) = 0.5
		_Shape_Movement_Interval ("Shape Movement Interval", Float) = 2
		_Wiggle_Speed ("Wiggle Speed", Float) = 1
		_Glitch_Color_Multiplier ("Glitch Color Multiplier", Float) = 2
		_Smoothstep ("Smoothstep", Float) = 0
		_Smoothstep_Width ("Smoothstep Width", Float) = 0
		_Back_Offset ("Back Offset", Float) = 0.01
		_Detail ("Detail", Range(0, 1)) = 0
		[NoScaleOffset] _SampleTexture2D_a7c7cca9ef5647029099c605db5461f1_Texture_1_Texture2D ("Texture2D", 2D) = "white" {}
		[HideInInspector] [NoScaleOffset] unity_Lightmaps ("unity_Lightmaps", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_LightmapsInd ("unity_LightmapsInd", 2DArray) = "" {}
		[HideInInspector] [NoScaleOffset] unity_ShadowMasks ("unity_ShadowMasks", 2DArray) = "" {}
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
	//CustomEditor "UnityEditor.Rendering.Fullscreen.ShaderGraph.FullscreenShaderGUI"
}
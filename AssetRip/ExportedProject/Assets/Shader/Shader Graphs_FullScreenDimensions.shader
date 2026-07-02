Shader "Shader Graphs/FullScreenDimensions" {
	Properties {
		_Ripple_Focal_Point ("Ripple Focal Point", Vector) = (0.5,0.5,0,0)
		_Ripple_Size ("Ripple Size", Float) = 0.1
		_Ripple_Magnification ("Ripple Magnification", Float) = -0.1
		_Ripple_Speed ("Ripple Speed", Float) = 1
		_Ripple_Frequency ("Ripple Frequency", Float) = 25
		_Ripple_2_Frequency ("Ripple 2 Frequency", Float) = 15
		_Ripple_2_Phase_Offset ("Ripple 2 Phase Offset", Float) = 3.14
		_Ripple_Mask_Bounds ("Ripple Mask Bounds", Vector) = (0.55,0.55,0,0)
		_Ripple_Mask_Falloff ("Ripple Mask Falloff", Float) = 0.4
		_Ripple_Aberration_Separation ("Ripple Aberration Separation", Float) = 0
		_Red ("Red", Vector) = (1,0,0,0)
		_Green ("Green", Vector) = (0,1,0,0)
		_Blue ("Blue", Vector) = (0,0,1,0)
		_Ripple_Aberration_Separation_2 ("Ripple Aberration Separation 2", Float) = 0.01
		[NoScaleOffset] _Ripple_Texture ("Ripple Texture", 2D) = "white" {}
		_Ripple_Polar_Intensity ("Ripple Polar Intensity", Float) = 0.2
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
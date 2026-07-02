Shader "Custom/SpriteSheetAB_FoWOccluded" {
	Properties {
		[Header(Texture Sheet)] _MainTex ("Texture", 2D) = "white" {}
		_Tint ("Tint", Vector) = (1,1,1,1)
		_LUT ("LUT", 2D) = "white" {}
		_LUTOffset ("LUT Offset", Float) = 0
		_TextureMult ("Texture Mult", Float) = 0
		_ErosionSoftness ("Erosion Softness", Float) = 0.05
		_EmissionMult ("Emission Mult", Float) = 1
		[Header(Billboard Settings)] _BillboardScale ("Billboard Scale", Vector) = (1,1,1,1)
		_Pivot ("Pivot", Vector) = (1,1,1,1)
		_DirectionX ("Direction X", Float) = 1
		[Header(Settings)] _ColumnsX ("Columns (X)", Float) = 1
		_RowsY ("Rows (Y)", Float) = 1
		_AnimationSpeed ("Frames Per Seconds", Float) = 10
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

			struct Fragment_Stage_Input
			{
				float2 uv : TEXCOORD0;
			};

			float4 frag(Fragment_Stage_Input input) : SV_TARGET
			{
				return _MainTex.Sample(sampler_MainTex, input.uv.xy);
			}

			ENDHLSL
		}
	}
}
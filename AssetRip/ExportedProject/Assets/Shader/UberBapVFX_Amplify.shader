Shader "UberBapVFX_Amplify" {
	Properties {
		_Centered ("[Centered]", Float) = 0
		_AmplifyProperties ("#Amplify Properties", Float) = 0
		[HideInInspector] _EmissionColor ("Emission Color", Vector) = (1,1,1,1)
		[HideInInspector] _AlphaCutoff ("Alpha Cutoff ", Range(0, 1)) = 0.5
		_CustomDataStreamsUV1TErosionSoftnessUV1WErosionAmountUV0TMasksUV0WUVOffset ("@Custom Data Streams: UV1T => Erosion Softness, UV1W => Erosion Amount, UV0T => Masks, UV0W => UV Offset", Float) = 0
		[Header(Color Settings)] [Space] [HDR] _ColorFront ("Color Front", Vector) = (1,1,1,1)
		[HDR] _ColorBack ("Color Back", Vector) = (1,1,1,1)
		_SwitchColorByFace ("!Switch Color By Face", Float) = 0
		[Header(Texture Settings)] [Space] _Tex ("Main Tex", 2D) = "white" {}
		[Enum(None,0,U,1,V,2)] _CustomDataUVOffset ("Custom Data UV Offset", Float) = 0
		_TextureMult ("Multiply Texture To Vertex Color", Range(-2, 2)) = 0
		[Toggle(_USEEROSIONFORMAINTEX_ON)] _UseErosionForMainTex ("Use Erosion For Main Tex", Float) = 0
		[KeywordHide(_USEEROSIONFORMAINTEX_ON, 0)] _MainTexErosionColor1 ("Main Tex Erosion Color 1", Vector) = (0,0,0,0)
		[KeywordHide(_USEEROSIONFORMAINTEX_ON, 0)] _MainTexErosionColor2 ("Main Tex Erosion Color 2", Vector) = (1,1,1,0)
		[KeywordHide(_USEEROSIONFORMAINTEX_ON, 0)] _MainTexErosionAmount ("Main Tex Erosion Amount", Range(0, 1)) = 0
		[KeywordHide(_USEEROSIONFORMAINTEX_ON, 0)] _MainTexErosionSoftness ("Main Tex Erosion Softness", Range(0, 1)) = 0
		[Toggle(_CHROMATICABBERATERGB_ON)] _ChromaticAbberateRGB ("Chromatic Abberate RGB", Float) = 0
		[KeywordHide(_CHROMATICABBERATERGB_ON, 0)] _AberrationPreMultiply ("Aberration Pre Multiply", Float) = 1
		[KeywordHide(_CHROMATICABBERATERGB_ON, 0)] _AberrationSeparation ("Aberration Separation", Float) = 0
		[Enum(RGB,0,OnlyR,1,OnlyG,2,OnlyB,3)] _TextureColorSourceChannels ("Texture Color Source Channels", Float) = 0
		[Enum(AlphaChannel,0,RedChannel,1,GreenChannel,2,BlueChannel,3,MultiplyAltRGB,4)] [Header(Alpha Settings)] [Space] _TextureAlphaSourceChannel ("Texture Alpha Source Channel", Float) = 0
		[Toggle(_USEALTTEXTUREFORALPHAMASK_ON)] _UseAltTextureForAlphaMask ("Use Alt Texture For Alpha Mask", Float) = 0
		[KeywordHide(_USEALTTEXTUREFORALPHAMASK_ON, 0)] [NoScaleOffset] _AltAlphaTex ("Alt Alpha Tex", 2D) = "white" {}
		_IsAdditive ("!Is Additive", Float) = 0
		[Header(LUT Settings)] [Space] [Toggle(_APPLYLUTTOMAINTEX_ON)] _ApplyLUTToMainTex ("Apply LUT To MainTex", Float) = 0
		[KeywordHide(_APPLYLUTTOMAINTEX_ON, 0)] _LUT ("LUT Texture", 2D) = "white" {}
		[KeywordHide(_APPLYLUTTOMAINTEX_ON, 0)] _LUTOffset ("LUT Offset", Float) = 0
		[Header(Emission Settings)] [Space] _EmissionMult ("Emission Multiplier", Float) = 1
		[Header(UV Settings)] [Space] [Toggle(_UV0ISPOLARCOORDINATES_ON)] _UV0IsPolarCoordinates ("UV0 Is Polar Coordinates", Float) = 0
		[KeywordHide(_UV0ISPOLARCOORDINATES_ON, 0)] _PolarCoordinatesRadialScale ("Polar Coordinates Radial Scale", Float) = 1
		[KeywordHide(_UV0ISPOLARCOORDINATES_ON, 0)] _PolarCoordinatesLengthScale ("Polar Coordinates Length Scale", Float) = 1
		_UVTwist ("UV Twist", Float) = 0
		_2UVPanSpeed ("2~UV Pan Speed", Vector) = (0,0,0,0)
		[Toggle(_WARPUVSBYTEXTURE_ON)] _WarpUVsByTexture ("Warp UVs By Texture", Float) = 0
		[KeywordHide(_WARPUVSBYTEXTURE_ON, 0)] _WarpUVStrength ("Warp UV Strength", Range(0, 1)) = 1
		[KeywordHide(_WARPUVSBYTEXTURE_ON, 0)] [NoScaleOffset] _WarpUVNoise ("Warp UV Noise", 2D) = "white" {}
		[KeywordHide(_WARPUVSBYTEXTURE_ON, 0)] _WarpScale ("Warp Scale", Vector) = (1,1,0,0)
		[KeywordHide(_WARPUVSBYTEXTURE_ON, 0)] _WarpSpeed ("Warp Speed", Vector) = (0.1,-0.1,0,0)
		[KeywordHide(_WARPUVSBYTEXTURE_ON, 0)] _WarpSecondaryOffset ("Warp Secondary Offset", Vector) = (0,0,0,0)
		[KeywordHide(_WARPUVSBYTEXTURE_ON, 0)] _WarpSecondaryScale ("Warp Secondary Scale", Vector) = (0,0,0,0)
		[KeywordHide(_WARPUVSBYTEXTURE_ON, 0)] _WarpSecondaryInvertDirection ("Warp Secondary Invert Direction", Range(0, 1)) = 1
		[Toggle(_ABILITYFLIPBOOK_ON)] _AbilityFlipbook ("Ability Flipbook", Float) = 0
		[KeywordHide(_ABILITYFLIPBOOK_ON, 0)] _AbilityFlipbookFrequency ("Ability Flipbook Frequency", Float) = 1
		[Header(Mask Settings)] [Space] [Toggle(_APPLYUVBASEDMASK_ON)] _ApplyUVBasedMask ("Apply UV Based Mask", Float) = 0
		[Toggle(_USEUV1FORUVMASK_ON)] _UseUV1ForUVMask ("Use UV1 For UV Mask", Float) = 0
		[KeywordHide(_APPLYUVBASEDMASK_ON, 0)] _MaskBounds ("Mask Bounds", Vector) = (0.55,0.55,0,0)
		[KeywordHide(_APPLYUVBASEDMASK_ON, 0)] _MaskPivot ("Mask Pivot", Vector) = (0.5,0.5,0,0)
		[KeywordHide(_APPLYUVBASEDMASK_ON, 0)] _MaskRoundedness ("Mask Roundedness", Range(0, 1)) = 0
		[KeywordHide(_APPLYUVBASEDMASK_ON, 0)] _MaskFalloff ("Mask Falloff", Range(0, 1)) = 0.1
		[KeywordHide(_APPLYUVBASEDMASK_ON, 0)] _MaskCustomDataUStrength ("Mask Custom Data U Strength", Range(0, 1)) = 0
		[KeywordHide(_APPLYUVBASEDMASK_ON, 0)] _MaskCustomDataVStrength ("Mask Custom Data V Strength", Range(0, 1)) = 0
		[Header(Additional Alpha Settings)] [Toggle(_USEEROSION_ON)] _UseErosion ("Use Erosion", Float) = 0
		[KeywordHide(_USEEROSION_ON, 0)] _ErosionAmount ("Erosion Amount", Range(-2, 2)) = 0
		[KeywordHide(_USEEROSION_ON, 0)] _ErosionSoftness ("Erosion Softness", Range(0, 1)) = 0.05
		[Toggle(_DEPTHFADE_ON)] _DepthFade ("Depth Fade", Float) = 0
		[KeywordHide(_DEPTHFADE_ON, 0)] _DepthFadeDistance ("Depth Fade Distance", Range(0, 10)) = 0.1
		[KeywordHide(_DEPTHFADE_ON, 0)] _DepthFadeInvert ("Depth Fade Invert", Range(0, 1)) = 0.1
		[KeywordHide(_DEPTHFADE_ON, 0)] _DepthFadePower ("Depth Fade Power", Float) = 1
		[Header(Gameplay Settings)] [Space] [Toggle(_ISFOGOFWAROCCLUDED_ON)] _IsFogOfWarOccluded ("Is Fog Of War Occluded", Float) = 0
		[Toggle(_ISLOCALCHAROCCLUDED_ON)] _IsLocalCharOccluded ("Is Local Char Occluded", Float) = 0
		[KeywordHide(_ISLOCALCHAROCCLUDED_ON, 0)] _LocalCharSphereHeight ("Local Char Sphere Height", Float) = 0
		[KeywordHide(_ISLOCALCHAROCCLUDED_ON, 0)] _LocalCharSphereRadius ("Local Char Sphere Radius", Float) = 0
		[KeywordHide(_ISLOCALCHAROCCLUDED_ON, 0)] _LocalCharSphereIntensity ("Local Char Sphere Intensity", Float) = 0
		[KeywordHide(_ISLOCALCHAROCCLUDED_ON, 0)] _LocalCharSphereMaxWidth ("Local Char Sphere Max Width", Float) = 0
		[Toggle(_MASKBYDIMENSION_ON)] _MaskByDimension ("Mask By Dimension", Float) = 0
		[Enum(Dimension0,0,Dimension1,1,Dimension2,2,Dimension3,3)] _DimensionMask ("Dimension Mask", Float) = 0
		[Toggle(_OFFSETVERTICESBYTEXTURE_ON)] _OffsetVerticesByTexture ("Offset Vertices By Texture", Float) = 0
		_VertexSpeed ("Vertex Speed", Range(0, 10)) = 0.9957457
		_VertexNoiseScale ("Vertex Noise Scale", Range(0, 5)) = 0.4750722
		_VertexScale ("Vertex Scale", Range(0, 1)) = 0.6819206
		[Header(Other Settings)] [Space] _AlphaClipThreshold ("Alpha Clip Threshold", Range(0, 1)) = 0.5
		_FresnelPower ("Fresnel Power", Range(0, 1)) = 1
		_FresnelScale ("Fresnel Scale", Range(0, 1)) = 0.1631564
		[Toggle(_FRESNELON_ON)] _FresnelOn ("Fresnel On", Float) = 0
		_FresnelBias ("Fresnel Bias", Float) = 0
		_OuterFresnelIntensity ("Outer Fresnel Intensity", Range(0, 1)) = 0.2844636
		_InnerFresnelIntensity ("Inner Fresnel Intensity", Range(0, 1)) = 0.2844636
		_FresnelColors ("FresnelColor", Vector) = (1,1,1,0)
		_FresnelEmissive ("Fresnel Emissive", Float) = 0
		_#1 ("#", Float) = 0
		[Space] _BaseSurfaceProperties ("#Base Surface Properties", Float) = 0
		_Unlit ("!Unlit", Range(0, 1)) = 1
		[Header(Lighting Parameters)] [Toggle(_RAMP_SHADING)] _RampShading ("Ramp Shading", Float) = 0
		[KeywordHide(_RAMP_SHADING, 0)] [NoScaleOffset] _Ramp ("Ramp", 2D) = "white" {}
		[KeywordHide(_RAMP_SHADING, 1)] _ShadowColor ("Shadow Color", Vector) = (0.6711962,0.690205,0.84,1)
		[KeywordEnum(None, SmoothStep, FWidth)] _AA ("Antialiasing Mode", Float) = 1
		_ShadingThreshold ("Shading Threshold", Range(-1, 1)) = 0.26
		[KeywordHide(_RAMP_SHADING, 1)] _ShadingSmooth ("Shading Smooth", Range(0.0001, 0.1)) = 0.01
		[Header(Lighting Settings)] _AmbientContribution ("Ambient Contribution", Range(0, 1)) = 0.2
		_LightingIntensity ("Lighting Intensity", Float) = 2
		_#2 ("#", Float) = 0
		[Space] _ShaderProperties ("#Shader Properties", Float) = 0
		_OpaqueTransparentPopup ("OpaqueTransparentPopup", Float) = 0
		[Header(Render Face)] [Enum(Front,2,Back,1,Both,0)] _Cull ("Render Face", Float) = 2
		[Space] [Header(Depth)] [Enum(Off,0,On,1)] _ZWriteMode ("ZWrite Mode", Float) = 0
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
	//CustomEditor "ToonMaterialInspector"
}
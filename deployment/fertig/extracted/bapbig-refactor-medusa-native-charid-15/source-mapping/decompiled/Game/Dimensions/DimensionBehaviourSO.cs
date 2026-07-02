using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Entities;
using Il2CppBAPBAP.Items;
using Il2CppBAPBAP.UI;
using Il2CppBAPBAP.Utilities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Game.Dimensions;

public class DimensionBehaviourSO : ScriptableObject
{
	[System.Serializable]
	public class DimensionMaskColor : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Enabled;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskTargetColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskRange;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskFuzziness;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskMultiplier;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe bool Enabled
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Enabled);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Enabled)) = flag;
			}
		}

		public unsafe Color MaskColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor)) = color;
			}
		}

		public unsafe Color MaskTargetColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskTargetColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskTargetColor)) = color;
			}
		}

		public unsafe float MaskRange
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskRange);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskRange)) = num;
			}
		}

		public unsafe float MaskFuzziness
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskFuzziness);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskFuzziness)) = num;
			}
		}

		public unsafe float MaskMultiplier
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskMultiplier);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskMultiplier)) = num;
			}
		}

		static DimensionMaskColor()
		{
			Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "DimensionMaskColor");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr);
			NativeFieldInfoPtr_Enabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr, "Enabled");
			NativeFieldInfoPtr_MaskColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr, "MaskColor");
			NativeFieldInfoPtr_MaskTargetColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr, "MaskTargetColor");
			NativeFieldInfoPtr_MaskRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr, "MaskRange");
			NativeFieldInfoPtr_MaskFuzziness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr, "MaskFuzziness");
			NativeFieldInfoPtr_MaskMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr, "MaskMultiplier");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr, 100672917);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121410, XrefRangeEnd = 121411, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe DimensionMaskColor()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DimensionMaskColor>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public DimensionMaskColor(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct DimensionData
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Position;

		private static readonly System.IntPtr NativeFieldInfoPtr_Radius;

		private static readonly System.IntPtr NativeFieldInfoPtr_Type;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad0;

		private static readonly System.IntPtr NativeFieldInfoPtr_pad1;

		[FieldOffset(0)]
		public Vector4 Position;

		[FieldOffset(16)]
		public float Radius;

		[FieldOffset(20)]
		public float Type;

		[FieldOffset(24)]
		public float pad0;

		[FieldOffset(28)]
		public float pad1;

		static DimensionData()
		{
			Il2CppClassPointerStore<DimensionData>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "DimensionData");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionData>.NativeClassPtr);
			NativeFieldInfoPtr_Position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionData>.NativeClassPtr, "Position");
			NativeFieldInfoPtr_Radius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionData>.NativeClassPtr, "Radius");
			NativeFieldInfoPtr_Type = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionData>.NativeClassPtr, "Type");
			NativeFieldInfoPtr_pad0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionData>.NativeClassPtr, "pad0");
			NativeFieldInfoPtr_pad1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionData>.NativeClassPtr, "pad1");
		}

		public unsafe Il2CppSystem.Object BoxIl2CppObject()
		{
			return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<DimensionData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct DimensionRenderingData
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Type;

		private static readonly System.IntPtr NativeFieldInfoPtr_ApplyLUT;

		private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentLUTIndex;

		private static readonly System.IntPtr NativeFieldInfoPtr_EntityLUTIndex;

		private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentMultiplier;

		private static readonly System.IntPtr NativeFieldInfoPtr_EntityMultiplier;

		private static readonly System.IntPtr NativeFieldInfoPtr_LuminanceExponent;

		private static readonly System.IntPtr NativeFieldInfoPtr_IsHalftoneShading;

		private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneFrequency;

		private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneRadius;

		private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneLowerBound;

		private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneUpperBound;

		private static readonly System.IntPtr NativeFieldInfoPtr_IsCrossHatchShading;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchTextureIndex;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchTiling;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchingErosionSoftness;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchingErosionAmount;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchShadowOffset;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchShadowSharpness;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchHighlightOffset;

		private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchHighlightSharpness;

		private static readonly System.IntPtr NativeFieldInfoPtr_IsRimlit;

		private static readonly System.IntPtr NativeFieldInfoPtr_RimPower;

		private static readonly System.IntPtr NativeFieldInfoPtr_RimIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_RimColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_IsCaustics;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsTextureIndex;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsSpeed;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsTiling;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsAbsorptionRate;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsPower;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalTextureIndex;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalIntensity;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalSpeed;

		private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalTiling;

		private static readonly System.IntPtr NativeFieldInfoPtr_IsOffsetShadingThreshold;

		private static readonly System.IntPtr NativeFieldInfoPtr_OffsetShadingThreshold;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor1Enabled;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor1;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskTargetColor1;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskRange1;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskFuzziness1;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskMultiplier1;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor2Enabled;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor2;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskTargetColor2;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskRange2;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskFuzziness2;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskMultiplier2;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor3Enabled;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor3;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskTargetColor3;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskRange3;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskFuzziness3;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskMultiplier3;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor4Enabled;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor4;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskTargetColor4;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskRange4;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskFuzziness4;

		private static readonly System.IntPtr NativeFieldInfoPtr_MaskMultiplier4;

		private static readonly System.IntPtr NativeFieldInfoPtr_OverrideOutlineColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_OutlineColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_OverrideOutlineWidth;

		private static readonly System.IntPtr NativeFieldInfoPtr_OutlineWidthMultiplier;

		private static readonly System.IntPtr NativeFieldInfoPtr_IsSpecular;

		private static readonly System.IntPtr NativeFieldInfoPtr_SpecularSize;

		private static readonly System.IntPtr NativeFieldInfoPtr_SpecularSmoothness;

		private static readonly System.IntPtr NativeFieldInfoPtr_SpecularFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr_SpecularColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_EntityIsPerRendererColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentIsPerRendererColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentPerRendererColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_DimensionSkipEntity;

		private static readonly System.IntPtr NativeFieldInfoPtr_DimensionSkipCharacter;

		private static readonly System.IntPtr NativeFieldInfoPtr_DimensionSkipGradientHeight;

		[FieldOffset(0)]
		public float Type;

		[FieldOffset(4)]
		public float ApplyLUT;

		[FieldOffset(8)]
		public float EnvironmentLUTIndex;

		[FieldOffset(12)]
		public float EntityLUTIndex;

		[FieldOffset(16)]
		public float EnvironmentMultiplier;

		[FieldOffset(20)]
		public float EntityMultiplier;

		[FieldOffset(24)]
		public float LuminanceExponent;

		[FieldOffset(28)]
		public float IsHalftoneShading;

		[FieldOffset(32)]
		public float HalftoneFrequency;

		[FieldOffset(36)]
		public float HalftoneRadius;

		[FieldOffset(40)]
		public float HalftoneLowerBound;

		[FieldOffset(44)]
		public float HalftoneUpperBound;

		[FieldOffset(48)]
		public float IsCrossHatchShading;

		[FieldOffset(52)]
		public float CrossHatchTextureIndex;

		[FieldOffset(56)]
		public float CrossHatchTiling;

		[FieldOffset(60)]
		public float CrossHatchFalloff;

		[FieldOffset(64)]
		public float CrossHatchingErosionSoftness;

		[FieldOffset(68)]
		public float CrossHatchingErosionAmount;

		[FieldOffset(72)]
		public float CrossHatchShadowOffset;

		[FieldOffset(76)]
		public float CrossHatchShadowSharpness;

		[FieldOffset(80)]
		public float CrossHatchHighlightOffset;

		[FieldOffset(84)]
		public float CrossHatchHighlightSharpness;

		[FieldOffset(88)]
		public float IsRimlit;

		[FieldOffset(92)]
		public float RimPower;

		[FieldOffset(96)]
		public float RimIntensity;

		[FieldOffset(100)]
		public Vector4 RimColor;

		[FieldOffset(116)]
		public float IsCaustics;

		[FieldOffset(120)]
		public float CausticsTextureIndex;

		[FieldOffset(124)]
		public float CausticsIntensity;

		[FieldOffset(128)]
		public Vector4 CausticsSpeed;

		[FieldOffset(144)]
		public float CausticsTiling;

		[FieldOffset(148)]
		public float CausticsAbsorptionRate;

		[FieldOffset(152)]
		public float CausticsPower;

		[FieldOffset(156)]
		public float CausticsNormalTextureIndex;

		[FieldOffset(160)]
		public float CausticsNormalIntensity;

		[FieldOffset(164)]
		public Vector4 CausticsNormalSpeed;

		[FieldOffset(180)]
		public float CausticsNormalTiling;

		[FieldOffset(184)]
		public float IsOffsetShadingThreshold;

		[FieldOffset(188)]
		public float OffsetShadingThreshold;

		[FieldOffset(192)]
		public float MaskColor1Enabled;

		[FieldOffset(196)]
		public Vector4 MaskColor1;

		[FieldOffset(212)]
		public Vector4 MaskTargetColor1;

		[FieldOffset(228)]
		public float MaskRange1;

		[FieldOffset(232)]
		public float MaskFuzziness1;

		[FieldOffset(236)]
		public float MaskMultiplier1;

		[FieldOffset(240)]
		public float MaskColor2Enabled;

		[FieldOffset(244)]
		public Vector4 MaskColor2;

		[FieldOffset(260)]
		public Vector4 MaskTargetColor2;

		[FieldOffset(276)]
		public float MaskRange2;

		[FieldOffset(280)]
		public float MaskFuzziness2;

		[FieldOffset(284)]
		public float MaskMultiplier2;

		[FieldOffset(288)]
		public float MaskColor3Enabled;

		[FieldOffset(292)]
		public Vector4 MaskColor3;

		[FieldOffset(308)]
		public Vector4 MaskTargetColor3;

		[FieldOffset(324)]
		public float MaskRange3;

		[FieldOffset(328)]
		public float MaskFuzziness3;

		[FieldOffset(332)]
		public float MaskMultiplier3;

		[FieldOffset(336)]
		public float MaskColor4Enabled;

		[FieldOffset(340)]
		public Vector4 MaskColor4;

		[FieldOffset(356)]
		public Vector4 MaskTargetColor4;

		[FieldOffset(372)]
		public float MaskRange4;

		[FieldOffset(376)]
		public float MaskFuzziness4;

		[FieldOffset(380)]
		public float MaskMultiplier4;

		[FieldOffset(384)]
		public float OverrideOutlineColor;

		[FieldOffset(388)]
		public Vector4 OutlineColor;

		[FieldOffset(404)]
		public float OverrideOutlineWidth;

		[FieldOffset(408)]
		public float OutlineWidthMultiplier;

		[FieldOffset(412)]
		public float IsSpecular;

		[FieldOffset(416)]
		public float SpecularSize;

		[FieldOffset(420)]
		public float SpecularSmoothness;

		[FieldOffset(424)]
		public float SpecularFalloff;

		[FieldOffset(428)]
		public Vector4 SpecularColor;

		[FieldOffset(444)]
		public float EntityIsPerRendererColor;

		[FieldOffset(448)]
		public float EnvironmentIsPerRendererColor;

		[FieldOffset(452)]
		public Vector4 EnvironmentPerRendererColor;

		[FieldOffset(468)]
		public float DimensionSkipEntity;

		[FieldOffset(472)]
		public float DimensionSkipCharacter;

		[FieldOffset(476)]
		public float DimensionSkipGradientHeight;

		static DimensionRenderingData()
		{
			Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "DimensionRenderingData");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr);
			NativeFieldInfoPtr_Type = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "Type");
			NativeFieldInfoPtr_ApplyLUT = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "ApplyLUT");
			NativeFieldInfoPtr_EnvironmentLUTIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "EnvironmentLUTIndex");
			NativeFieldInfoPtr_EntityLUTIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "EntityLUTIndex");
			NativeFieldInfoPtr_EnvironmentMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "EnvironmentMultiplier");
			NativeFieldInfoPtr_EntityMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "EntityMultiplier");
			NativeFieldInfoPtr_LuminanceExponent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "LuminanceExponent");
			NativeFieldInfoPtr_IsHalftoneShading = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "IsHalftoneShading");
			NativeFieldInfoPtr_HalftoneFrequency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "HalftoneFrequency");
			NativeFieldInfoPtr_HalftoneRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "HalftoneRadius");
			NativeFieldInfoPtr_HalftoneLowerBound = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "HalftoneLowerBound");
			NativeFieldInfoPtr_HalftoneUpperBound = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "HalftoneUpperBound");
			NativeFieldInfoPtr_IsCrossHatchShading = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "IsCrossHatchShading");
			NativeFieldInfoPtr_CrossHatchTextureIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchTextureIndex");
			NativeFieldInfoPtr_CrossHatchTiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchTiling");
			NativeFieldInfoPtr_CrossHatchFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchFalloff");
			NativeFieldInfoPtr_CrossHatchingErosionSoftness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchingErosionSoftness");
			NativeFieldInfoPtr_CrossHatchingErosionAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchingErosionAmount");
			NativeFieldInfoPtr_CrossHatchShadowOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchShadowOffset");
			NativeFieldInfoPtr_CrossHatchShadowSharpness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchShadowSharpness");
			NativeFieldInfoPtr_CrossHatchHighlightOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchHighlightOffset");
			NativeFieldInfoPtr_CrossHatchHighlightSharpness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CrossHatchHighlightSharpness");
			NativeFieldInfoPtr_IsRimlit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "IsRimlit");
			NativeFieldInfoPtr_RimPower = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "RimPower");
			NativeFieldInfoPtr_RimIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "RimIntensity");
			NativeFieldInfoPtr_RimColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "RimColor");
			NativeFieldInfoPtr_IsCaustics = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "IsCaustics");
			NativeFieldInfoPtr_CausticsTextureIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsTextureIndex");
			NativeFieldInfoPtr_CausticsIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsIntensity");
			NativeFieldInfoPtr_CausticsSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsSpeed");
			NativeFieldInfoPtr_CausticsTiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsTiling");
			NativeFieldInfoPtr_CausticsAbsorptionRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsAbsorptionRate");
			NativeFieldInfoPtr_CausticsPower = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsPower");
			NativeFieldInfoPtr_CausticsNormalTextureIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsNormalTextureIndex");
			NativeFieldInfoPtr_CausticsNormalIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsNormalIntensity");
			NativeFieldInfoPtr_CausticsNormalSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsNormalSpeed");
			NativeFieldInfoPtr_CausticsNormalTiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "CausticsNormalTiling");
			NativeFieldInfoPtr_IsOffsetShadingThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "IsOffsetShadingThreshold");
			NativeFieldInfoPtr_OffsetShadingThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "OffsetShadingThreshold");
			NativeFieldInfoPtr_MaskColor1Enabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor1Enabled");
			NativeFieldInfoPtr_MaskColor1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor1");
			NativeFieldInfoPtr_MaskTargetColor1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskTargetColor1");
			NativeFieldInfoPtr_MaskRange1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskRange1");
			NativeFieldInfoPtr_MaskFuzziness1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskFuzziness1");
			NativeFieldInfoPtr_MaskMultiplier1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskMultiplier1");
			NativeFieldInfoPtr_MaskColor2Enabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor2Enabled");
			NativeFieldInfoPtr_MaskColor2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor2");
			NativeFieldInfoPtr_MaskTargetColor2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskTargetColor2");
			NativeFieldInfoPtr_MaskRange2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskRange2");
			NativeFieldInfoPtr_MaskFuzziness2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskFuzziness2");
			NativeFieldInfoPtr_MaskMultiplier2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskMultiplier2");
			NativeFieldInfoPtr_MaskColor3Enabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor3Enabled");
			NativeFieldInfoPtr_MaskColor3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor3");
			NativeFieldInfoPtr_MaskTargetColor3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskTargetColor3");
			NativeFieldInfoPtr_MaskRange3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskRange3");
			NativeFieldInfoPtr_MaskFuzziness3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskFuzziness3");
			NativeFieldInfoPtr_MaskMultiplier3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskMultiplier3");
			NativeFieldInfoPtr_MaskColor4Enabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor4Enabled");
			NativeFieldInfoPtr_MaskColor4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskColor4");
			NativeFieldInfoPtr_MaskTargetColor4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskTargetColor4");
			NativeFieldInfoPtr_MaskRange4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskRange4");
			NativeFieldInfoPtr_MaskFuzziness4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskFuzziness4");
			NativeFieldInfoPtr_MaskMultiplier4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "MaskMultiplier4");
			NativeFieldInfoPtr_OverrideOutlineColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "OverrideOutlineColor");
			NativeFieldInfoPtr_OutlineColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "OutlineColor");
			NativeFieldInfoPtr_OverrideOutlineWidth = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "OverrideOutlineWidth");
			NativeFieldInfoPtr_OutlineWidthMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "OutlineWidthMultiplier");
			NativeFieldInfoPtr_IsSpecular = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "IsSpecular");
			NativeFieldInfoPtr_SpecularSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "SpecularSize");
			NativeFieldInfoPtr_SpecularSmoothness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "SpecularSmoothness");
			NativeFieldInfoPtr_SpecularFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "SpecularFalloff");
			NativeFieldInfoPtr_SpecularColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "SpecularColor");
			NativeFieldInfoPtr_EntityIsPerRendererColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "EntityIsPerRendererColor");
			NativeFieldInfoPtr_EnvironmentIsPerRendererColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "EnvironmentIsPerRendererColor");
			NativeFieldInfoPtr_EnvironmentPerRendererColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "EnvironmentPerRendererColor");
			NativeFieldInfoPtr_DimensionSkipEntity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "DimensionSkipEntity");
			NativeFieldInfoPtr_DimensionSkipCharacter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "DimensionSkipCharacter");
			NativeFieldInfoPtr_DimensionSkipGradientHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, "DimensionSkipGradientHeight");
		}

		public unsafe Il2CppSystem.Object BoxIl2CppObject()
		{
			return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<DimensionRenderingData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_dimensionId;

	private static readonly System.IntPtr NativeFieldInfoPtr_DimensionSkipEntity;

	private static readonly System.IntPtr NativeFieldInfoPtr_DimensionSkipCharacter;

	private static readonly System.IntPtr NativeFieldInfoPtr_DimensionSkipGradientHeight;

	private static readonly System.IntPtr NativeFieldInfoPtr_ApplyLUT;

	private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentLUTIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_EntityLUTIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_EntityMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_EntityIsPerRendererColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentIsPerRendererColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_EnvironmentPerRendererColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_LuminanceExponent;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsHalftoneShading;

	private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneFrequency;

	private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneLowerBound;

	private static readonly System.IntPtr NativeFieldInfoPtr_HalftoneUpperBound;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsCrossHatchShading;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchTextureIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchTiling;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchFalloff;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchingErosionSoftness;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchingErosionAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchShadowOffset;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchShadowSharpness;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchHighlightOffset;

	private static readonly System.IntPtr NativeFieldInfoPtr_CrossHatchHighlightSharpness;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsRimlit;

	private static readonly System.IntPtr NativeFieldInfoPtr_RimIntensity;

	private static readonly System.IntPtr NativeFieldInfoPtr_RimPower;

	private static readonly System.IntPtr NativeFieldInfoPtr_RimColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsSpecular;

	private static readonly System.IntPtr NativeFieldInfoPtr_SpecularSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_SpecularSmoothness;

	private static readonly System.IntPtr NativeFieldInfoPtr_SpecularFalloff;

	private static readonly System.IntPtr NativeFieldInfoPtr_SpecularColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsCaustics;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsTextureIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsIntensity;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsSpeed;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsTiling;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsAbsorptionRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsPower;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalTextureIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalIntensity;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalSpeed;

	private static readonly System.IntPtr NativeFieldInfoPtr_CausticsNormalTiling;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsOffsetShadingThreshold;

	private static readonly System.IntPtr NativeFieldInfoPtr_OffsetShadingThreshold;

	private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor1;

	private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor2;

	private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor3;

	private static readonly System.IntPtr NativeFieldInfoPtr_MaskColor4;

	private static readonly System.IntPtr NativeFieldInfoPtr_OverrideOutlineColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_OutlineColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_OverrideOutlineWidth;

	private static readonly System.IntPtr NativeFieldInfoPtr_OutlineWidthMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_dimensionPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_objsToSpawn;

	private static readonly System.IntPtr NativeFieldInfoPtr_passives;

	private static readonly System.IntPtr NativeFieldInfoPtr_customLootTables;

	private static readonly System.IntPtr NativeFieldInfoPtr_behaviourStartDelay;

	private static readonly System.IntPtr NativeFieldInfoPtr_minTransitions;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxTransitions;

	private static readonly System.IntPtr NativeFieldInfoPtr_behaviourTransitionTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_behaviourDelayTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_canMove;

	private static readonly System.IntPtr NativeFieldInfoPtr_chanceToMove;

	private static readonly System.IntPtr NativeFieldInfoPtr_minMaxDistanceMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_canResize;

	private static readonly System.IntPtr NativeFieldInfoPtr_chanceToResize;

	private static readonly System.IntPtr NativeFieldInfoPtr_minMaxResize;

	private static readonly System.IntPtr NativeFieldInfoPtr_minMaxSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_nameTranslationKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_minimapPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_displayIcon;

	private static readonly System.IntPtr NativeFieldInfoPtr_descTranslationKey;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetMaskColorValues_Private_Void_DimensionMaskColor_byref_Single_byref_Vector4_byref_Vector4_byref_Single_byref_Single_byref_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRenderingData_Public_DimensionRenderingData_byref_DimensionRenderingData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Dimension.DimensionType dimensionId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionId);
			return *(Dimension.DimensionType*)num;
		}
		set
		{
			*(Dimension.DimensionType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionId)) = dimensionType;
		}
	}

	public unsafe bool DimensionSkipEntity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionSkipEntity);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionSkipEntity)) = flag;
		}
	}

	public unsafe bool DimensionSkipCharacter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionSkipCharacter);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionSkipCharacter)) = flag;
		}
	}

	public unsafe float DimensionSkipGradientHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionSkipGradientHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DimensionSkipGradientHeight)) = num;
		}
	}

	public unsafe bool ApplyLUT
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ApplyLUT);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ApplyLUT)) = flag;
		}
	}

	public unsafe int EnvironmentLUTIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentLUTIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentLUTIndex)) = num;
		}
	}

	public unsafe int EntityLUTIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntityLUTIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntityLUTIndex)) = num;
		}
	}

	public unsafe float EnvironmentMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentMultiplier)) = num;
		}
	}

	public unsafe float EntityMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntityMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntityMultiplier)) = num;
		}
	}

	public unsafe bool EntityIsPerRendererColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntityIsPerRendererColor);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntityIsPerRendererColor)) = flag;
		}
	}

	public unsafe bool EnvironmentIsPerRendererColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentIsPerRendererColor);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentIsPerRendererColor)) = flag;
		}
	}

	public unsafe Color EnvironmentPerRendererColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentPerRendererColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EnvironmentPerRendererColor)) = color;
		}
	}

	public unsafe float LuminanceExponent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LuminanceExponent);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LuminanceExponent)) = num;
		}
	}

	public unsafe bool IsHalftoneShading
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsHalftoneShading);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsHalftoneShading)) = flag;
		}
	}

	public unsafe float HalftoneFrequency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneFrequency);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneFrequency)) = num;
		}
	}

	public unsafe float HalftoneRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneRadius)) = num;
		}
	}

	public unsafe float HalftoneLowerBound
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneLowerBound);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneLowerBound)) = num;
		}
	}

	public unsafe float HalftoneUpperBound
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneUpperBound);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HalftoneUpperBound)) = num;
		}
	}

	public unsafe bool IsCrossHatchShading
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsCrossHatchShading);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsCrossHatchShading)) = flag;
		}
	}

	public unsafe int CrossHatchTextureIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchTextureIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchTextureIndex)) = num;
		}
	}

	public unsafe float CrossHatchTiling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchTiling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchTiling)) = num;
		}
	}

	public unsafe float CrossHatchFalloff
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchFalloff);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchFalloff)) = num;
		}
	}

	public unsafe float CrossHatchingErosionSoftness
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchingErosionSoftness);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchingErosionSoftness)) = num;
		}
	}

	public unsafe float CrossHatchingErosionAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchingErosionAmount);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchingErosionAmount)) = num;
		}
	}

	public unsafe float CrossHatchShadowOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchShadowOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchShadowOffset)) = num;
		}
	}

	public unsafe float CrossHatchShadowSharpness
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchShadowSharpness);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchShadowSharpness)) = num;
		}
	}

	public unsafe float CrossHatchHighlightOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchHighlightOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchHighlightOffset)) = num;
		}
	}

	public unsafe float CrossHatchHighlightSharpness
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchHighlightSharpness);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CrossHatchHighlightSharpness)) = num;
		}
	}

	public unsafe bool IsRimlit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsRimlit);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsRimlit)) = flag;
		}
	}

	public unsafe float RimIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RimIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RimIntensity)) = num;
		}
	}

	public unsafe float RimPower
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RimPower);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RimPower)) = num;
		}
	}

	public unsafe Color RimColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RimColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RimColor)) = color;
		}
	}

	public unsafe bool IsSpecular
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsSpecular);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsSpecular)) = flag;
		}
	}

	public unsafe float SpecularSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularSize);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularSize)) = num;
		}
	}

	public unsafe float SpecularSmoothness
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularSmoothness);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularSmoothness)) = num;
		}
	}

	public unsafe float SpecularFalloff
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularFalloff);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularFalloff)) = num;
		}
	}

	public unsafe Color SpecularColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SpecularColor)) = color;
		}
	}

	public unsafe bool IsCaustics
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsCaustics);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsCaustics)) = flag;
		}
	}

	public unsafe int CausticsTextureIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsTextureIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsTextureIndex)) = num;
		}
	}

	public unsafe float CausticsIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsIntensity)) = num;
		}
	}

	public unsafe Vector2 CausticsSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsSpeed);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsSpeed)) = vector;
		}
	}

	public unsafe float CausticsTiling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsTiling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsTiling)) = num;
		}
	}

	public unsafe float CausticsAbsorptionRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsAbsorptionRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsAbsorptionRate)) = num;
		}
	}

	public unsafe float CausticsPower
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsPower);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsPower)) = num;
		}
	}

	public unsafe int CausticsNormalTextureIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalTextureIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalTextureIndex)) = num;
		}
	}

	public unsafe float CausticsNormalIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalIntensity)) = num;
		}
	}

	public unsafe Vector2 CausticsNormalSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalSpeed);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalSpeed)) = vector;
		}
	}

	public unsafe float CausticsNormalTiling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalTiling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CausticsNormalTiling)) = num;
		}
	}

	public unsafe bool IsOffsetShadingThreshold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsOffsetShadingThreshold);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsOffsetShadingThreshold)) = flag;
		}
	}

	public unsafe float OffsetShadingThreshold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OffsetShadingThreshold);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OffsetShadingThreshold)) = num;
		}
	}

	public unsafe DimensionMaskColor MaskColor1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor1);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DimensionMaskColor>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor1)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionMaskColor));
		}
	}

	public unsafe DimensionMaskColor MaskColor2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor2);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DimensionMaskColor>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor2)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionMaskColor));
		}
	}

	public unsafe DimensionMaskColor MaskColor3
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor3);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DimensionMaskColor>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor3)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionMaskColor));
		}
	}

	public unsafe DimensionMaskColor MaskColor4
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor4);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DimensionMaskColor>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MaskColor4)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionMaskColor));
		}
	}

	public unsafe bool OverrideOutlineColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OverrideOutlineColor);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OverrideOutlineColor)) = flag;
		}
	}

	public unsafe Color OutlineColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OutlineColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OutlineColor)) = color;
		}
	}

	public unsafe bool OverrideOutlineWidth
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OverrideOutlineWidth);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OverrideOutlineWidth)) = flag;
		}
	}

	public unsafe float OutlineWidthMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OutlineWidthMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OutlineWidthMultiplier)) = num;
		}
	}

	public unsafe GameObject dimensionPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Il2CppReferenceArray<D_Obj_SO> objsToSpawn
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objsToSpawn);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<D_Obj_SO>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objsToSpawn)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe List<PassiveSO> passives
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passives);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<PassiveSO>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passives)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe Il2CppReferenceArray<LootTable> customLootTables
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customLootTables);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<LootTable>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customLootTables)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe float behaviourStartDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourStartDelay);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourStartDelay)) = num;
		}
	}

	public unsafe int minTransitions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minTransitions);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minTransitions)) = num;
		}
	}

	public unsafe int maxTransitions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxTransitions);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxTransitions)) = num;
		}
	}

	public unsafe RangeFloat behaviourTransitionTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourTransitionTime);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RangeFloat>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourTransitionTime)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rangeFloat));
		}
	}

	public unsafe RangeFloat behaviourDelayTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourDelayTime);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RangeFloat>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviourDelayTime)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rangeFloat));
		}
	}

	public unsafe bool canMove
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canMove);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canMove)) = flag;
		}
	}

	public unsafe float chanceToMove
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceToMove);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceToMove)) = num;
		}
	}

	public unsafe RangeFloat minMaxDistanceMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minMaxDistanceMultiplier);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RangeFloat>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minMaxDistanceMultiplier)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rangeFloat));
		}
	}

	public unsafe bool canResize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canResize);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canResize)) = flag;
		}
	}

	public unsafe float chanceToResize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceToResize);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceToResize)) = num;
		}
	}

	public unsafe RangeFloat minMaxResize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minMaxResize);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RangeFloat>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minMaxResize)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rangeFloat));
		}
	}

	public unsafe RangeFloat minMaxSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minMaxSize);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RangeFloat>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minMaxSize)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rangeFloat));
		}
	}

	public unsafe string nameTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe UIMinimapDimension minimapPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIMinimapDimension>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIMinimapDimension));
		}
	}

	public unsafe Sprite displayIcon
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_displayIcon);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_displayIcon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
		}
	}

	public unsafe string descTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_descTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_descTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static DimensionBehaviourSO()
	{
		Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Game.Dimensions", "DimensionBehaviourSO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr);
		NativeFieldInfoPtr_dimensionId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "dimensionId");
		NativeFieldInfoPtr_DimensionSkipEntity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "DimensionSkipEntity");
		NativeFieldInfoPtr_DimensionSkipCharacter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "DimensionSkipCharacter");
		NativeFieldInfoPtr_DimensionSkipGradientHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "DimensionSkipGradientHeight");
		NativeFieldInfoPtr_ApplyLUT = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "ApplyLUT");
		NativeFieldInfoPtr_EnvironmentLUTIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "EnvironmentLUTIndex");
		NativeFieldInfoPtr_EntityLUTIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "EntityLUTIndex");
		NativeFieldInfoPtr_EnvironmentMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "EnvironmentMultiplier");
		NativeFieldInfoPtr_EntityMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "EntityMultiplier");
		NativeFieldInfoPtr_EntityIsPerRendererColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "EntityIsPerRendererColor");
		NativeFieldInfoPtr_EnvironmentIsPerRendererColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "EnvironmentIsPerRendererColor");
		NativeFieldInfoPtr_EnvironmentPerRendererColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "EnvironmentPerRendererColor");
		NativeFieldInfoPtr_LuminanceExponent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "LuminanceExponent");
		NativeFieldInfoPtr_IsHalftoneShading = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "IsHalftoneShading");
		NativeFieldInfoPtr_HalftoneFrequency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "HalftoneFrequency");
		NativeFieldInfoPtr_HalftoneRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "HalftoneRadius");
		NativeFieldInfoPtr_HalftoneLowerBound = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "HalftoneLowerBound");
		NativeFieldInfoPtr_HalftoneUpperBound = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "HalftoneUpperBound");
		NativeFieldInfoPtr_IsCrossHatchShading = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "IsCrossHatchShading");
		NativeFieldInfoPtr_CrossHatchTextureIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchTextureIndex");
		NativeFieldInfoPtr_CrossHatchTiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchTiling");
		NativeFieldInfoPtr_CrossHatchFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchFalloff");
		NativeFieldInfoPtr_CrossHatchingErosionSoftness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchingErosionSoftness");
		NativeFieldInfoPtr_CrossHatchingErosionAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchingErosionAmount");
		NativeFieldInfoPtr_CrossHatchShadowOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchShadowOffset");
		NativeFieldInfoPtr_CrossHatchShadowSharpness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchShadowSharpness");
		NativeFieldInfoPtr_CrossHatchHighlightOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchHighlightOffset");
		NativeFieldInfoPtr_CrossHatchHighlightSharpness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CrossHatchHighlightSharpness");
		NativeFieldInfoPtr_IsRimlit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "IsRimlit");
		NativeFieldInfoPtr_RimIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "RimIntensity");
		NativeFieldInfoPtr_RimPower = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "RimPower");
		NativeFieldInfoPtr_RimColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "RimColor");
		NativeFieldInfoPtr_IsSpecular = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "IsSpecular");
		NativeFieldInfoPtr_SpecularSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "SpecularSize");
		NativeFieldInfoPtr_SpecularSmoothness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "SpecularSmoothness");
		NativeFieldInfoPtr_SpecularFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "SpecularFalloff");
		NativeFieldInfoPtr_SpecularColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "SpecularColor");
		NativeFieldInfoPtr_IsCaustics = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "IsCaustics");
		NativeFieldInfoPtr_CausticsTextureIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsTextureIndex");
		NativeFieldInfoPtr_CausticsIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsIntensity");
		NativeFieldInfoPtr_CausticsSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsSpeed");
		NativeFieldInfoPtr_CausticsTiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsTiling");
		NativeFieldInfoPtr_CausticsAbsorptionRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsAbsorptionRate");
		NativeFieldInfoPtr_CausticsPower = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsPower");
		NativeFieldInfoPtr_CausticsNormalTextureIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsNormalTextureIndex");
		NativeFieldInfoPtr_CausticsNormalIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsNormalIntensity");
		NativeFieldInfoPtr_CausticsNormalSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsNormalSpeed");
		NativeFieldInfoPtr_CausticsNormalTiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "CausticsNormalTiling");
		NativeFieldInfoPtr_IsOffsetShadingThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "IsOffsetShadingThreshold");
		NativeFieldInfoPtr_OffsetShadingThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "OffsetShadingThreshold");
		NativeFieldInfoPtr_MaskColor1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "MaskColor1");
		NativeFieldInfoPtr_MaskColor2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "MaskColor2");
		NativeFieldInfoPtr_MaskColor3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "MaskColor3");
		NativeFieldInfoPtr_MaskColor4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "MaskColor4");
		NativeFieldInfoPtr_OverrideOutlineColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "OverrideOutlineColor");
		NativeFieldInfoPtr_OutlineColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "OutlineColor");
		NativeFieldInfoPtr_OverrideOutlineWidth = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "OverrideOutlineWidth");
		NativeFieldInfoPtr_OutlineWidthMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "OutlineWidthMultiplier");
		NativeFieldInfoPtr_dimensionPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "dimensionPrefab");
		NativeFieldInfoPtr_objsToSpawn = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "objsToSpawn");
		NativeFieldInfoPtr_passives = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "passives");
		NativeFieldInfoPtr_customLootTables = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "customLootTables");
		NativeFieldInfoPtr_behaviourStartDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "behaviourStartDelay");
		NativeFieldInfoPtr_minTransitions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "minTransitions");
		NativeFieldInfoPtr_maxTransitions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "maxTransitions");
		NativeFieldInfoPtr_behaviourTransitionTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "behaviourTransitionTime");
		NativeFieldInfoPtr_behaviourDelayTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "behaviourDelayTime");
		NativeFieldInfoPtr_canMove = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "canMove");
		NativeFieldInfoPtr_chanceToMove = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "chanceToMove");
		NativeFieldInfoPtr_minMaxDistanceMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "minMaxDistanceMultiplier");
		NativeFieldInfoPtr_canResize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "canResize");
		NativeFieldInfoPtr_chanceToResize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "chanceToResize");
		NativeFieldInfoPtr_minMaxResize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "minMaxResize");
		NativeFieldInfoPtr_minMaxSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "minMaxSize");
		NativeFieldInfoPtr_nameTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "nameTranslationKey");
		NativeFieldInfoPtr_minimapPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "minimapPrefab");
		NativeFieldInfoPtr_displayIcon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "displayIcon");
		NativeFieldInfoPtr_descTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, "descTranslationKey");
		NativeMethodInfoPtr_SetMaskColorValues_Private_Void_DimensionMaskColor_byref_Single_byref_Vector4_byref_Vector4_byref_Single_byref_Single_byref_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, 100672914);
		NativeMethodInfoPtr_GetRenderingData_Public_DimensionRenderingData_byref_DimensionRenderingData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, 100672915);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr, 100672916);
	}

	[CallerCount(0)]
	public unsafe void SetMaskColorValues(DimensionMaskColor mask, ref float enabled, ref Vector4 maskColor, ref Vector4 maskTargetColor, ref float maskRange, ref float maskFuzziness, ref float maskMultiplier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[7];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mask);
		*(void**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref enabled);
		*(void**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref maskColor);
		*(void**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref maskTargetColor);
		*(void**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref maskRange);
		*(void**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref maskFuzziness);
		*(void**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref maskMultiplier);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetMaskColorValues_Private_Void_DimensionMaskColor_byref_Single_byref_Vector4_byref_Vector4_byref_Single_byref_Single_byref_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 121411, RefRangeEnd = 121412, XrefRangeStart = 121411, XrefRangeEnd = 121411, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe DimensionRenderingData GetRenderingData(ref DimensionRenderingData renderingData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)Unsafe.AsPointer(ref renderingData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRenderingData_Public_DimensionRenderingData_byref_DimensionRenderingData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(DimensionRenderingData*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121412, XrefRangeEnd = 121424, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe DimensionBehaviourSO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DimensionBehaviourSO>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public DimensionBehaviourSO(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

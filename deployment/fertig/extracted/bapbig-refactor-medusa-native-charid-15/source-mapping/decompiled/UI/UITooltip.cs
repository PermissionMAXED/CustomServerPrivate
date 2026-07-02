using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UITooltip : MonoBehaviour
{
	[OriginalName("Assembly-CSharp.dll", "", "TooltipAnchor")]
	public enum TooltipAnchor
	{
		Top,
		Bottom,
		Left,
		Right
	}

	private static readonly IntPtr NativeFieldInfoPtr_tooltipParent;

	private static readonly IntPtr NativeFieldInfoPtr_tooltipPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_tooltipOffset;

	private static readonly IntPtr NativeFieldInfoPtr_horScreenMargin;

	private static readonly IntPtr NativeFieldInfoPtr_verScreenMargin;

	private static readonly IntPtr NativeFieldInfoPtr_currentTooltipTr;

	private static readonly IntPtr NativeFieldInfoPtr_currentTooltipElement;

	private static readonly IntPtr NativeFieldInfoPtr_expandInputBinding;

	private static readonly IntPtr NativeMethodInfoPtr_CreateTooltipObj_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_Vector3_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_RectTransform_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_String_String_RectTransform_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_String_String_String_String_RectTransform_Boolean_Boolean_Color_Boolean_String_Color_Sprite_Int32_TooltipAnchor_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_DoScreenBoundsClamp_Public_Static_Void_RectTransform_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetAnchorPivot_Private_Vector2_TooltipAnchor_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetAnchorVector_Private_Vector2_TooltipAnchor_0;

	private static readonly IntPtr NativeMethodInfoPtr_HideTooltip_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Transform tooltipParent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipParent);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe GameObject tooltipPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Vector2 tooltipOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipOffset);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipOffset)) = vector;
		}
	}

	public unsafe float horScreenMargin
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_horScreenMargin);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_horScreenMargin)) = num;
		}
	}

	public unsafe float verScreenMargin
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_verScreenMargin);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_verScreenMargin)) = num;
		}
	}

	public unsafe RectTransform currentTooltipTr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTooltipTr);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTooltipTr)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
		}
	}

	public unsafe UITooltipElement currentTooltipElement
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTooltipElement);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UITooltipElement>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentTooltipElement)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uITooltipElement));
		}
	}

	public unsafe InputBinding expandInputBinding
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expandInputBinding);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expandInputBinding)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBinding));
		}
	}

	static UITooltip()
	{
		Il2CppClassPointerStore<UITooltip>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UITooltip");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UITooltip>.NativeClassPtr);
		NativeFieldInfoPtr_tooltipParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "tooltipParent");
		NativeFieldInfoPtr_tooltipPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "tooltipPrefab");
		NativeFieldInfoPtr_tooltipOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "tooltipOffset");
		NativeFieldInfoPtr_horScreenMargin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "horScreenMargin");
		NativeFieldInfoPtr_verScreenMargin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "verScreenMargin");
		NativeFieldInfoPtr_currentTooltipTr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "currentTooltipTr");
		NativeFieldInfoPtr_currentTooltipElement = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "currentTooltipElement");
		NativeFieldInfoPtr_expandInputBinding = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, "expandInputBinding");
		NativeMethodInfoPtr_CreateTooltipObj_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668085);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668086);
		NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_Vector3_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668087);
		NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_RectTransform_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668088);
		NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_String_String_RectTransform_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668089);
		NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_String_String_String_String_RectTransform_Boolean_Boolean_Color_Boolean_String_Color_Sprite_Int32_TooltipAnchor_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668090);
		NativeMethodInfoPtr_DoScreenBoundsClamp_Public_Static_Void_RectTransform_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668091);
		NativeMethodInfoPtr_GetAnchorPivot_Private_Vector2_TooltipAnchor_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668092);
		NativeMethodInfoPtr_GetAnchorVector_Private_Vector2_TooltipAnchor_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668093);
		NativeMethodInfoPtr_HideTooltip_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668094);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UITooltip>.NativeClassPtr, 100668095);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 86395, XrefRangeEnd = 86411, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateTooltipObj()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateTooltipObj_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 86411, XrefRangeEnd = 86423, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 86425, RefRangeEnd = 86428, XrefRangeStart = 86423, XrefRangeEnd = 86425, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowTooltip(Color titleColor, string title, string desc, Vector3 screenPos, bool fadeIn = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = (nint)(&titleColor);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(title);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(desc);
		*(Vector3**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &screenPos;
		*(bool**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &fadeIn;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_Vector3_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 86428, XrefRangeEnd = 86430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowTooltip(Color titleColor, string title, string desc, RectTransform rectTr, bool fadeIn = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = (nint)(&titleColor);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(title);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(desc);
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTr);
		*(bool**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &fadeIn;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_RectTransform_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 86430, XrefRangeEnd = 86432, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowTooltip(Color titleColor, string title, string subTitle, string desc, string bottomText, RectTransform rectTr, bool fadeIn = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[7];
		*ptr = (nint)(&titleColor);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(title);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(subTitle);
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(desc);
		*(IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(bottomText);
		*(IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTr);
		*(bool**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = &fadeIn;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_String_String_RectTransform_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 86485, RefRangeEnd = 86495, XrefRangeStart = 86432, XrefRangeEnd = 86485, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowTooltip(Color titleColor, string title, string subTitle, string desc, string extraDesc, string expandDesc, string bottomText, RectTransform rectTr, bool fadeIn = true, bool bgColorEnabled = false, Color bgColor = default(Color), bool isHeaderEnabled = false, string headerStr = "", Color headerColor = default(Color), Sprite headerIcon = null, int rarityStars = 0, TooltipAnchor anchor = TooltipAnchor.Bottom, Vector3 screenPos = default(Vector3))
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[18];
		*ptr = (nint)(&titleColor);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(title);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(subTitle);
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(desc);
		*(IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(extraDesc);
		*(IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(expandDesc);
		*(IntPtr*)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(bottomText);
		*(IntPtr*)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTr);
		*(bool**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(IntPtr)))) = &fadeIn;
		*(bool**)((byte*)ptr + checked((nuint)9u * unchecked((nuint)sizeof(IntPtr)))) = &bgColorEnabled;
		*(Color**)((byte*)ptr + checked((nuint)10u * unchecked((nuint)sizeof(IntPtr)))) = &bgColor;
		*(bool**)((byte*)ptr + checked((nuint)11u * unchecked((nuint)sizeof(IntPtr)))) = &isHeaderEnabled;
		*(IntPtr*)((byte*)ptr + checked((nuint)12u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(headerStr);
		*(Color**)((byte*)ptr + checked((nuint)13u * unchecked((nuint)sizeof(IntPtr)))) = &headerColor;
		*(IntPtr*)((byte*)ptr + checked((nuint)14u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)headerIcon);
		*(int**)((byte*)ptr + checked((nuint)15u * unchecked((nuint)sizeof(IntPtr)))) = &rarityStars;
		*(TooltipAnchor**)((byte*)ptr + checked((nuint)16u * unchecked((nuint)sizeof(IntPtr)))) = &anchor;
		*(Vector3**)((byte*)ptr + checked((nuint)17u * unchecked((nuint)sizeof(IntPtr)))) = &screenPos;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowTooltip_Public_Void_Color_String_String_String_String_String_String_RectTransform_Boolean_Boolean_Color_Boolean_String_Color_Sprite_Int32_TooltipAnchor_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 86504, RefRangeEnd = 86507, XrefRangeStart = 86495, XrefRangeEnd = 86504, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void DoScreenBoundsClamp(RectTransform tooltipRect, float horScreenMargin, float verScreenMargin)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tooltipRect);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &horScreenMargin;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &verScreenMargin;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DoScreenBoundsClamp_Public_Static_Void_RectTransform_Single_Single_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe Vector2 GetAnchorPivot(TooltipAnchor anchor)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&anchor);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAnchorPivot_Private_Vector2_TooltipAnchor_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe Vector2 GetAnchorVector(TooltipAnchor anchor)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&anchor);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAnchorVector_Private_Vector2_TooltipAnchor_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(19)]
	[CachedScanResults(RefRangeStart = 86511, RefRangeEnd = 86530, XrefRangeStart = 86507, XrefRangeEnd = 86511, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HideTooltip()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HideTooltip_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UITooltip()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UITooltip>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UITooltip(IntPtr pointer)
		: base(pointer)
	{
	}
}

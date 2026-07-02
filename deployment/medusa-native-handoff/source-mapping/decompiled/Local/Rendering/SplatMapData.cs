using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local.Rendering;

[Serializable]
public class SplatMapData : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_levelName;

	private static readonly IntPtr NativeFieldInfoPtr_splatMap;

	private static readonly IntPtr NativeMethodInfoPtr_NewSplatMapTex_Public_Static_Texture2D_Il2CppObjectBase_0;

	private static readonly IntPtr NativeMethodInfoPtr_NewSplatMapTex_Public_Static_Texture2D_Vector2Int_Il2CppStructArray_1_Color_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetSplatMap_Public_Void_String_Texture2D_0;

	private static readonly IntPtr NativeMethodInfoPtr_ClearSplatMap_Public_Static_Void_Texture2D_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPixelRectFromLevelRect_Public_Static_Rect_Vector2Int_Vector2Int_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPixelRectFromLevelRect_Public_Static_Rect_Rect_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPixelsFromLevelRect_Public_Il2CppStructArray_1_Color_Rect_0;

	private static readonly IntPtr NativeMethodInfoPtr_CopyPixels_Public_Void_Rect_Rect_0;

	private static readonly IntPtr NativeMethodInfoPtr_CopyPixels_Public_Void_Il2CppStructArray_1_Color_Rect_0;

	private static readonly IntPtr NativeMethodInfoPtr_Resize_Private_Texture2D_Texture2D_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string levelName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelName);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe Texture2D splatMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splatMap);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splatMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
		}
	}

	static SplatMapData()
	{
		Il2CppClassPointerStore<SplatMapData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local.Rendering", "SplatMapData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr);
		NativeFieldInfoPtr_levelName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, "levelName");
		NativeFieldInfoPtr_splatMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, "splatMap");
		NativeMethodInfoPtr_NewSplatMapTex_Public_Static_Texture2D_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685142);
		NativeMethodInfoPtr_NewSplatMapTex_Public_Static_Texture2D_Vector2Int_Il2CppStructArray_1_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685143);
		NativeMethodInfoPtr_SetSplatMap_Public_Void_String_Texture2D_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685144);
		NativeMethodInfoPtr_ClearSplatMap_Public_Static_Void_Texture2D_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685145);
		NativeMethodInfoPtr_GetPixelRectFromLevelRect_Public_Static_Rect_Vector2Int_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685146);
		NativeMethodInfoPtr_GetPixelRectFromLevelRect_Public_Static_Rect_Rect_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685147);
		NativeMethodInfoPtr_GetPixelsFromLevelRect_Public_Il2CppStructArray_1_Color_Rect_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685148);
		NativeMethodInfoPtr_CopyPixels_Public_Void_Rect_Rect_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685149);
		NativeMethodInfoPtr_CopyPixels_Public_Void_Il2CppStructArray_1_Color_Rect_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685150);
		NativeMethodInfoPtr_Resize_Private_Texture2D_Texture2D_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685151);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr, 100685152);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 233080, RefRangeEnd = 233082, XrefRangeStart = 233066, XrefRangeEnd = 233080, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D NewSplatMapTex(Il2CppObjectBase colors)
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(colors);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_NewSplatMapTex_Public_Static_Texture2D_Il2CppObjectBase_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233082, XrefRangeEnd = 233090, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D NewSplatMapTex(Vector2Int size, Il2CppStructArray<Color> colors = null)
	{
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&size);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colors);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_NewSplatMapTex_Public_Static_Texture2D_Vector2Int_Il2CppStructArray_1_Color_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetSplatMap(string levelName, Texture2D existingData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelName);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)existingData);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetSplatMap_Public_Void_String_Texture2D_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ClearSplatMap(Texture2D splatMapTex)
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)splatMapTex);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClearSplatMap_Public_Static_Void_Texture2D_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe static Rect GetPixelRectFromLevelRect(Vector2Int centerPos, Vector2Int size)
	{
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&centerPos);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &size;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPixelRectFromLevelRect_Public_Static_Rect_Vector2Int_Vector2Int_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Rect*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe static Rect GetPixelRectFromLevelRect(Rect levelRect)
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&levelRect);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPixelRectFromLevelRect_Public_Static_Rect_Rect_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Rect*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233090, XrefRangeEnd = 233095, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Il2CppStructArray<Color> GetPixelsFromLevelRect(Rect sourceRect)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&sourceRect);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPixelsFromLevelRect_Public_Il2CppStructArray_1_Color_Rect_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233095, XrefRangeEnd = 233130, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CopyPixels(Rect sourceRect, Rect destinationRect)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&sourceRect);
		*(Rect**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &destinationRect;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CopyPixels_Public_Void_Rect_Rect_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233130, XrefRangeEnd = 233132, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CopyPixels(Il2CppStructArray<Color> sourcePixels, Rect destinationRect)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sourcePixels);
		*(Rect**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &destinationRect;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CopyPixels_Public_Void_Il2CppStructArray_1_Color_Rect_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233132, XrefRangeEnd = 233145, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Texture2D Resize(Texture2D source, int newWidth, int newHeight)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)source);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &newWidth;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &newHeight;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Resize_Private_Texture2D_Texture2D_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SplatMapData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SplatMapData>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SplatMapData(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Content;

public class CurrencyData : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_defaultDisplayScale;

	private static readonly IntPtr NativeFieldInfoPtr_vis3DSettings;

	private static readonly IntPtr NativeFieldInfoPtr_gold;

	private static readonly IntPtr NativeFieldInfoPtr_fractals;

	private static readonly IntPtr NativeFieldInfoPtr_charTokens;

	private static readonly IntPtr NativeFieldInfoPtr_challengeLive;

	private static readonly IntPtr NativeMethodInfoPtr_GetCurrencyContentByAssetId_Public_Content_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetChallengeContentByAssetId_Public_Content_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float defaultDisplayScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultDisplayScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultDisplayScale)) = num;
		}
	}

	public unsafe ContentVisualizer3D.VisualizerSettings vis3DSettings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vis3DSettings);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ContentVisualizer3D.VisualizerSettings>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vis3DSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)visualizerSettings));
		}
	}

	public unsafe CurrencySO gold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gold);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CurrencySO>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gold)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)currencySO));
		}
	}

	public unsafe CurrencySO fractals
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractals);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CurrencySO>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractals)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)currencySO));
		}
	}

	public unsafe CurrencySO charTokens
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokens);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CurrencySO>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokens)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)currencySO));
		}
	}

	public unsafe CurrencySO challengeLive
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeLive);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CurrencySO>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_challengeLive)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)currencySO));
		}
	}

	static CurrencyData()
	{
		Il2CppClassPointerStore<CurrencyData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "CurrencyData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr);
		NativeFieldInfoPtr_defaultDisplayScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, "defaultDisplayScale");
		NativeFieldInfoPtr_vis3DSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, "vis3DSettings");
		NativeFieldInfoPtr_gold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, "gold");
		NativeFieldInfoPtr_fractals = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, "fractals");
		NativeFieldInfoPtr_charTokens = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, "charTokens");
		NativeFieldInfoPtr_challengeLive = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, "challengeLive");
		NativeMethodInfoPtr_GetCurrencyContentByAssetId_Public_Content_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, 100682879);
		NativeMethodInfoPtr_GetChallengeContentByAssetId_Public_Content_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, 100682880);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr, 100682881);
	}

	[CallerCount(0)]
	public unsafe Content GetCurrencyContentByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrencyContentByAssetId_Public_Content_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Content>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 216894, RefRangeEnd = 216895, XrefRangeStart = 216894, XrefRangeEnd = 216894, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Content GetChallengeContentByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetChallengeContentByAssetId_Public_Content_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Content>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216895, XrefRangeEnd = 216896, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CurrencyData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CurrencyData>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CurrencyData(IntPtr pointer)
		: base(pointer)
	{
	}
}

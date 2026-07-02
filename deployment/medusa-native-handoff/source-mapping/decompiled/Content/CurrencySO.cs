using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Content;

public class CurrencySO : ContentSO
{
	private static readonly IntPtr NativeFieldInfoPtr_currency;

	private static readonly IntPtr NativeMethodInfoPtr_get_content_Public_Virtual_get_Content_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Currency currency
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currency);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Currency>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currency)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)currency));
		}
	}

	public unsafe override Content content
	{
		[CallerCount(140)]
		[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_content_Public_Virtual_get_Content_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Content>(intPtr) : null;
		}
	}

	static CurrencySO()
	{
		Il2CppClassPointerStore<CurrencySO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "CurrencySO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CurrencySO>.NativeClassPtr);
		NativeFieldInfoPtr_currency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CurrencySO>.NativeClassPtr, "currency");
		NativeMethodInfoPtr_get_content_Public_Virtual_get_Content_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CurrencySO>.NativeClassPtr, 100682882);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CurrencySO>.NativeClassPtr, 100682883);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 45124, RefRangeEnd = 45125, XrefRangeStart = 45124, XrefRangeEnd = 45125, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CurrencySO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CurrencySO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CurrencySO(IntPtr pointer)
		: base(pointer)
	{
	}
}

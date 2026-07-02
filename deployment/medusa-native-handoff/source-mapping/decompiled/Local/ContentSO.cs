using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Content;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class ContentSO : ScriptableObject
{
	private static readonly IntPtr NativeMethodInfoPtr_get_content_Public_Virtual_New_get_Content_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe virtual Il2CppBAPBAP.Content.Content content
	{
		[CallerCount(87)]
		[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_content_Public_Virtual_New_get_Content_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppBAPBAP.Content.Content>(intPtr) : null;
		}
	}

	static ContentSO()
	{
		Il2CppClassPointerStore<ContentSO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "ContentSO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ContentSO>.NativeClassPtr);
		NativeMethodInfoPtr_get_content_Public_Virtual_New_get_Content_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentSO>.NativeClassPtr, 100684215);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentSO>.NativeClassPtr, 100684216);
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ContentSO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ContentSO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ContentSO(IntPtr pointer)
		: base(pointer)
	{
	}
}

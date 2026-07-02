using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public class LevelMMCacheData : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_levelMMCache;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe LevelMMCache levelMMCache
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelMMCache);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<LevelMMCache>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelMMCache)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelMMCache));
		}
	}

	static LevelMMCacheData()
	{
		Il2CppClassPointerStore<LevelMMCacheData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "LevelMMCacheData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LevelMMCacheData>.NativeClassPtr);
		NativeFieldInfoPtr_levelMMCache = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelMMCacheData>.NativeClassPtr, "levelMMCache");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelMMCacheData>.NativeClassPtr, 100685455);
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LevelMMCacheData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LevelMMCacheData>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LevelMMCacheData(IntPtr pointer)
		: base(pointer)
	{
	}
}

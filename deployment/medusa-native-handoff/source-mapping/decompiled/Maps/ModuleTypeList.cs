using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace Il2CppBAPBAP.Maps;

public sealed class ModuleTypeList : Il2CppSystem.ValueType
{
	private static readonly System.IntPtr NativeFieldInfoPtr_poiModules;

	private static readonly System.IntPtr NativeFieldInfoPtr_poiThemedModules;

	private static readonly System.IntPtr NativeFieldInfoPtr_landmarkModules;

	private static readonly System.IntPtr NativeFieldInfoPtr_reviveModules;

	private static readonly System.IntPtr NativeFieldInfoPtr_genericLargeModules;

	private static readonly System.IntPtr NativeFieldInfoPtr_genericMediumModules;

	private static readonly System.IntPtr NativeFieldInfoPtr_genericSmallModules;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_ModuleTypeList_0;

	public unsafe List<string> poiModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<string>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe Dictionary<string, List<string>> poiThemedModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiThemedModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<string, List<string>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiThemedModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe List<string> landmarkModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_landmarkModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<string>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_landmarkModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<string> reviveModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<string>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<string> genericLargeModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericLargeModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<string>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericLargeModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<string> genericMediumModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericMediumModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<string>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericMediumModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<string> genericSmallModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericSmallModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<string>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericSmallModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static ModuleTypeList()
	{
		Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "ModuleTypeList");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr);
		NativeFieldInfoPtr_poiModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, "poiModules");
		NativeFieldInfoPtr_poiThemedModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, "poiThemedModules");
		NativeFieldInfoPtr_landmarkModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, "landmarkModules");
		NativeFieldInfoPtr_reviveModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, "reviveModules");
		NativeFieldInfoPtr_genericLargeModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, "genericLargeModules");
		NativeFieldInfoPtr_genericMediumModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, "genericMediumModules");
		NativeFieldInfoPtr_genericSmallModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, "genericSmallModules");
		NativeMethodInfoPtr__ctor_Public_Void_ModuleTypeList_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr, 100685810);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242577, RefRangeEnd = 242578, XrefRangeStart = 242559, XrefRangeEnd = 242577, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ModuleTypeList(ModuleTypeList moduleTypeList)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)moduleTypeList));
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_ModuleTypeList_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ModuleTypeList(System.IntPtr pointer)
		: base(pointer)
	{
	}

	public ModuleTypeList()
		: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ModuleTypeList>.NativeClassPtr))
	{
	}
}

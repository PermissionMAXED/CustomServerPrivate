using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class PassiveLibrary : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_LIBRARY_PATH;

	private static readonly IntPtr NativeFieldInfoPtr_LOCAL_PASSIVES_PATH;

	private static readonly IntPtr NativeFieldInfoPtr_IGNORE_PREFIX;

	private static readonly IntPtr NativeFieldInfoPtr_passives;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe static string LIBRARY_PATH
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LIBRARY_PATH, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LIBRARY_PATH, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string LOCAL_PASSIVES_PATH
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LOCAL_PASSIVES_PATH, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LOCAL_PASSIVES_PATH, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string IGNORE_PREFIX
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_IGNORE_PREFIX, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_IGNORE_PREFIX, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe Il2CppReferenceArray<PassiveSO> passives
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passives);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<PassiveSO>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passives)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static PassiveLibrary()
	{
		Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "PassiveLibrary");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr);
		NativeFieldInfoPtr_LIBRARY_PATH = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr, "LIBRARY_PATH");
		NativeFieldInfoPtr_LOCAL_PASSIVES_PATH = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr, "LOCAL_PASSIVES_PATH");
		NativeFieldInfoPtr_IGNORE_PREFIX = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr, "IGNORE_PREFIX");
		NativeFieldInfoPtr_passives = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr, "passives");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr, 100678178);
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PassiveLibrary()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PassiveLibrary>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PassiveLibrary(IntPtr pointer)
		: base(pointer)
	{
	}
}

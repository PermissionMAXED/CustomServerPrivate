using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class Z_Obj_SO : ScriptableObject
{
	private static readonly IntPtr NativeMethodInfoPtr_get_config_Public_Virtual_New_get_Z_ObjConfiguration_0;

	private static readonly IntPtr NativeMethodInfoPtr_NewInstance_Public_Virtual_New_Z_Obj_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe virtual Z_Obj.Z_ObjConfiguration config
	{
		[CallerCount(87)]
		[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_config_Public_Virtual_New_get_Z_ObjConfiguration_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Z_Obj.Z_ObjConfiguration>(intPtr) : null;
		}
	}

	static Z_Obj_SO()
	{
		Il2CppClassPointerStore<Z_Obj_SO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "Z_Obj_SO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Z_Obj_SO>.NativeClassPtr);
		NativeMethodInfoPtr_get_config_Public_Virtual_New_get_Z_ObjConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Z_Obj_SO>.NativeClassPtr, 100682170);
		NativeMethodInfoPtr_NewInstance_Public_Virtual_New_Z_Obj_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Z_Obj_SO>.NativeClassPtr, 100682171);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Z_Obj_SO>.NativeClassPtr, 100682172);
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual Z_Obj NewInstance()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_NewInstance_Public_Virtual_New_Z_Obj_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Z_Obj>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Z_Obj_SO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Z_Obj_SO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public Z_Obj_SO(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Entities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Systems;

public class EntityHiddenSystem : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_components;

	private static readonly IntPtr NativeMethodInfoPtr_Register_Public_Void_CharHidden_0;

	private static readonly IntPtr NativeMethodInfoPtr_Unregister_Public_Void_CharHidden_0;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe List<CharHidden> components
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_components);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<CharHidden>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_components)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static EntityHiddenSystem()
	{
		Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Systems", "EntityHiddenSystem");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr);
		NativeFieldInfoPtr_components = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr, "components");
		NativeMethodInfoPtr_Register_Public_Void_CharHidden_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr, 100665322);
		NativeMethodInfoPtr_Unregister_Public_Void_CharHidden_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr, 100665323);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr, 100665324);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr, 100665325);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 55253, RefRangeEnd = 55254, XrefRangeStart = 55251, XrefRangeEnd = 55253, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Register(CharHidden charHidden)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charHidden);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Register_Public_Void_CharHidden_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 55256, RefRangeEnd = 55257, XrefRangeStart = 55254, XrefRangeEnd = 55256, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Unregister(CharHidden charHidden)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charHidden);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Unregister_Public_Void_CharHidden_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 55257, XrefRangeEnd = 55265, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 55265, XrefRangeEnd = 55270, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EntityHiddenSystem()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EntityHiddenSystem>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public EntityHiddenSystem(IntPtr pointer)
		: base(pointer)
	{
	}
}

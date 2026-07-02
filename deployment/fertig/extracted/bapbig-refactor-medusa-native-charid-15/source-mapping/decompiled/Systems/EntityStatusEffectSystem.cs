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

public class EntityStatusEffectSystem : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_components;

	private static readonly IntPtr NativeMethodInfoPtr_Register_Public_Void_CharStatusEffects_0;

	private static readonly IntPtr NativeMethodInfoPtr_Unregister_Public_Void_CharStatusEffects_0;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe List<CharStatusEffects> components
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_components);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<CharStatusEffects>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_components)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static EntityStatusEffectSystem()
	{
		Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Systems", "EntityStatusEffectSystem");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr);
		NativeFieldInfoPtr_components = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr, "components");
		NativeMethodInfoPtr_Register_Public_Void_CharStatusEffects_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr, 100665350);
		NativeMethodInfoPtr_Unregister_Public_Void_CharStatusEffects_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr, 100665351);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr, 100665352);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr, 100665353);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 55522, RefRangeEnd = 55523, XrefRangeStart = 55520, XrefRangeEnd = 55522, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Register(CharStatusEffects charWorldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charWorldPosition);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Register_Public_Void_CharStatusEffects_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 55525, RefRangeEnd = 55526, XrefRangeStart = 55523, XrefRangeEnd = 55525, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Unregister(CharStatusEffects charWorldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charWorldPosition);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Unregister_Public_Void_CharStatusEffects_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 55526, XrefRangeEnd = 55534, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 55534, XrefRangeEnd = 55539, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EntityStatusEffectSystem()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EntityStatusEffectSystem>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public EntityStatusEffectSystem(IntPtr pointer)
		: base(pointer)
	{
	}
}

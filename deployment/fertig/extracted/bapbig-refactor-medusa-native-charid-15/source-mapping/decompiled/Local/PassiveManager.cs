using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Entities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class PassiveManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_library;

	private static readonly IntPtr NativeFieldInfoPtr_pagePassive;

	private static readonly IntPtr NativeFieldInfoPtr_extraPercentDmg;

	private static readonly IntPtr NativeFieldInfoPtr_tooltipPassiveHeader;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetVfxId_Public_Int32_GameObject_0;

	private static readonly IntPtr NativeMethodInfoPtr_NewPassiveInstance_Public_Passive_Int32_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPassiveId_Public_Int32_PassiveSO_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPassiveConfig_Public_PassiveConfiguration_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe PassiveLibrary library
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_library);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PassiveLibrary>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_library)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)passiveLibrary));
		}
	}

	public unsafe PassiveSO pagePassive
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pagePassive);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PassiveSO>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pagePassive)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)passiveSO));
		}
	}

	public unsafe P_OnUse_ExtraPercentDmg_SO extraPercentDmg
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraPercentDmg);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<P_OnUse_ExtraPercentDmg_SO>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraPercentDmg)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)p_OnUse_ExtraPercentDmg_SO));
		}
	}

	public unsafe string tooltipPassiveHeader
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipPassiveHeader);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tooltipPassiveHeader)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static PassiveManager()
	{
		Il2CppClassPointerStore<PassiveManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "PassiveManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr);
		NativeFieldInfoPtr_library = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, "library");
		NativeFieldInfoPtr_pagePassive = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, "pagePassive");
		NativeFieldInfoPtr_extraPercentDmg = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, "extraPercentDmg");
		NativeFieldInfoPtr_tooltipPassiveHeader = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, "tooltipPassiveHeader");
		NativeMethodInfoPtr_PreAwake_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, 100684479);
		NativeMethodInfoPtr_GetVfxId_Public_Int32_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, 100684480);
		NativeMethodInfoPtr_NewPassiveInstance_Public_Passive_Int32_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, 100684481);
		NativeMethodInfoPtr_GetPassiveId_Public_Int32_PassiveSO_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, 100684482);
		NativeMethodInfoPtr_GetPassiveConfig_Public_PassiveConfiguration_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, 100684483);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr, 100684484);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 228099, RefRangeEnd = 228100, XrefRangeStart = 228079, XrefRangeEnd = 228099, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PreAwake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(56)]
	[CachedScanResults(RefRangeStart = 228110, RefRangeEnd = 228166, XrefRangeStart = 228100, XrefRangeEnd = 228110, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetVfxId(GameObject prefab)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefab);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetVfxId_Public_Int32_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 228172, RefRangeEnd = 228173, XrefRangeStart = 228166, XrefRangeEnd = 228172, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Passive NewPassiveInstance(int passiveId, EntityManager entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&passiveId);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_NewPassiveInstance_Public_Passive_Int32_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Passive>(intPtr) : null;
	}

	[CallerCount(29)]
	[CachedScanResults(RefRangeStart = 228176, RefRangeEnd = 228205, XrefRangeStart = 228173, XrefRangeEnd = 228176, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetPassiveId(PassiveSO passive)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)passive);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPassiveId_Public_Int32_PassiveSO_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 228205, RefRangeEnd = 228215, XrefRangeStart = 228205, XrefRangeEnd = 228205, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Passive.PassiveConfiguration GetPassiveConfig(int passiveId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&passiveId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPassiveConfig_Public_PassiveConfiguration_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Passive.PassiveConfiguration>(intPtr) : null;
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PassiveManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PassiveManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PassiveManager(IntPtr pointer)
		: base(pointer)
	{
	}
}

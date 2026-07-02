using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Entities;
using Il2CppBAPBAP.Localisation;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class StatusEffectManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_statusEffects;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Localise_Public_Void_Translator_0;

	private static readonly IntPtr NativeMethodInfoPtr_NewStatusEffectInstance_Public_StatusEffect_Int32_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetStatusEffectId_Public_Int32_StatusEffectSO_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetStatusEffectConfig_Public_StatusEffectConfiguration_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<StatusEffectSO> statusEffects
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<StatusEffectSO>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static StatusEffectManager()
	{
		Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "StatusEffectManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr);
		NativeFieldInfoPtr_statusEffects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr, "statusEffects");
		NativeMethodInfoPtr_PreAwake_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr, 100684498);
		NativeMethodInfoPtr_Localise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr, 100684499);
		NativeMethodInfoPtr_NewStatusEffectInstance_Public_StatusEffect_Int32_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr, 100684500);
		NativeMethodInfoPtr_GetStatusEffectId_Public_Int32_StatusEffectSO_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr, 100684501);
		NativeMethodInfoPtr_GetStatusEffectConfig_Public_StatusEffectConfiguration_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr, 100684502);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr, 100684503);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 228633, RefRangeEnd = 228634, XrefRangeStart = 228378, XrefRangeEnd = 228633, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PreAwake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 228640, RefRangeEnd = 228641, XrefRangeStart = 228634, XrefRangeEnd = 228640, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Localise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 228647, RefRangeEnd = 228648, XrefRangeStart = 228641, XrefRangeEnd = 228647, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe StatusEffect NewStatusEffectInstance(int statusEffectId, EntityManager entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&statusEffectId);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_NewStatusEffectInstance_Public_StatusEffect_Int32_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<StatusEffect>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 228651, RefRangeEnd = 228653, XrefRangeStart = 228648, XrefRangeEnd = 228651, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetStatusEffectId(StatusEffectSO statusEffect)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)statusEffect);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetStatusEffectId_Public_Int32_StatusEffectSO_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(13)]
	[CachedScanResults(RefRangeStart = 228653, RefRangeEnd = 228666, XrefRangeStart = 228653, XrefRangeEnd = 228653, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe StatusEffect.StatusEffectConfiguration GetStatusEffectConfig(int statusEffectId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&statusEffectId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetStatusEffectConfig_Public_StatusEffectConfiguration_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<StatusEffect.StatusEffectConfiguration>(intPtr) : null;
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe StatusEffectManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<StatusEffectManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public StatusEffectManager(IntPtr pointer)
		: base(pointer)
	{
	}
}

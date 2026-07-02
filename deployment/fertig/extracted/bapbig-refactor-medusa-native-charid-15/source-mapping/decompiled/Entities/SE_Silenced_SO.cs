using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class SE_Silenced_SO : StatusEffectSO
{
	private static readonly IntPtr NativeFieldInfoPtr_configuration;

	private static readonly IntPtr NativeMethodInfoPtr_get_config_Public_Virtual_get_StatusEffectConfiguration_0;

	private static readonly IntPtr NativeMethodInfoPtr_NewInstance_Public_Virtual_StatusEffect_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe SE_Silenced.Config configuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<SE_Silenced.Config>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
		}
	}

	public unsafe override StatusEffect.StatusEffectConfiguration config
	{
		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 30135, RefRangeEnd = 30170, XrefRangeStart = 30135, XrefRangeEnd = 30170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_config_Public_Virtual_get_StatusEffectConfiguration_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<StatusEffect.StatusEffectConfiguration>(intPtr) : null;
		}
	}

	static SE_Silenced_SO()
	{
		Il2CppClassPointerStore<SE_Silenced_SO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "SE_Silenced_SO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SE_Silenced_SO>.NativeClassPtr);
		NativeFieldInfoPtr_configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SE_Silenced_SO>.NativeClassPtr, "configuration");
		NativeMethodInfoPtr_get_config_Public_Virtual_get_StatusEffectConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SE_Silenced_SO>.NativeClassPtr, 100678635);
		NativeMethodInfoPtr_NewInstance_Public_Virtual_StatusEffect_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SE_Silenced_SO>.NativeClassPtr, 100678636);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SE_Silenced_SO>.NativeClassPtr, 100678637);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 182106, XrefRangeEnd = 182109, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override StatusEffect NewInstance(EntityManager em)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)em);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_NewInstance_Public_Virtual_StatusEffect_EntityManager_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<StatusEffect>(intPtr) : null;
	}

	[CallerCount(35)]
	[CachedScanResults(RefRangeStart = 181887, RefRangeEnd = 181922, XrefRangeStart = 181887, XrefRangeEnd = 181922, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SE_Silenced_SO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SE_Silenced_SO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SE_Silenced_SO(IntPtr pointer)
		: base(pointer)
	{
	}
}

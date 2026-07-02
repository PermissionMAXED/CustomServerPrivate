using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Local;

public class GM_XCOM_SO : GameModifierSO
{
	private static readonly IntPtr NativeFieldInfoPtr_configuration;

	private static readonly IntPtr NativeMethodInfoPtr_get_config_Public_Virtual_get_GameModifierConfiguration_0;

	private static readonly IntPtr NativeMethodInfoPtr_NewInstance_Public_Virtual_GameModifier_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe GM_XCOM.Config configuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GM_XCOM.Config>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
		}
	}

	public unsafe override GameModifier.GameModifierConfiguration config
	{
		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 30135, RefRangeEnd = 30170, XrefRangeStart = 30135, XrefRangeEnd = 30170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_config_Public_Virtual_get_GameModifierConfiguration_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameModifier.GameModifierConfiguration>(intPtr) : null;
		}
	}

	static GM_XCOM_SO()
	{
		Il2CppClassPointerStore<GM_XCOM_SO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "GM_XCOM_SO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GM_XCOM_SO>.NativeClassPtr);
		NativeFieldInfoPtr_configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GM_XCOM_SO>.NativeClassPtr, "configuration");
		NativeMethodInfoPtr_get_config_Public_Virtual_get_GameModifierConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GM_XCOM_SO>.NativeClassPtr, 100683553);
		NativeMethodInfoPtr_NewInstance_Public_Virtual_GameModifier_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GM_XCOM_SO>.NativeClassPtr, 100683554);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GM_XCOM_SO>.NativeClassPtr, 100683555);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 221360, XrefRangeEnd = 221363, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override GameModifier NewInstance()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_NewInstance_Public_Virtual_GameModifier_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameModifier>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GM_XCOM_SO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GM_XCOM_SO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public GM_XCOM_SO(IntPtr pointer)
		: base(pointer)
	{
	}
}

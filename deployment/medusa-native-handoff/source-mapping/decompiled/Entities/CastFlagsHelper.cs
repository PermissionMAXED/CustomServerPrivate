using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Entities;

public static class CastFlagsHelper : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_castFlagsAll;

	private static readonly System.IntPtr NativeFieldInfoPtr_castFlagsAllNoConsumable;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCastFlagByAbility_Public_Static_CastFlags_CommandId_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsAnyActive_Public_Static_Boolean_CastFlags_CastFlags_0;

	public unsafe static CastFlags castFlagsAll
	{
		get
		{
			Unsafe.SkipInit(out CastFlags result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_castFlagsAll, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_castFlagsAll, (void*)(&castFlags));
		}
	}

	public unsafe static CastFlags castFlagsAllNoConsumable
	{
		get
		{
			Unsafe.SkipInit(out CastFlags result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_castFlagsAllNoConsumable, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_castFlagsAllNoConsumable, (void*)(&castFlags));
		}
	}

	static CastFlagsHelper()
	{
		Il2CppClassPointerStore<CastFlagsHelper>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CastFlagsHelper");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CastFlagsHelper>.NativeClassPtr);
		NativeFieldInfoPtr_castFlagsAll = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastFlagsHelper>.NativeClassPtr, "castFlagsAll");
		NativeFieldInfoPtr_castFlagsAllNoConsumable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastFlagsHelper>.NativeClassPtr, "castFlagsAllNoConsumable");
		NativeMethodInfoPtr_GetCastFlagByAbility_Public_Static_CastFlags_CommandId_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastFlagsHelper>.NativeClassPtr, 100678759);
		NativeMethodInfoPtr_IsAnyActive_Public_Static_Boolean_CastFlags_CastFlags_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastFlagsHelper>.NativeClassPtr, 100678760);
	}

	[CallerCount(67)]
	[CachedScanResults(RefRangeStart = 182754, RefRangeEnd = 182821, XrefRangeStart = 182754, XrefRangeEnd = 182754, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static CastFlags GetCastFlagByAbility(CommandId cmdId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&cmdId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCastFlagByAbility_Public_Static_CastFlags_CommandId_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(CastFlags*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(35)]
	[CachedScanResults(RefRangeStart = 182821, RefRangeEnd = 182856, XrefRangeStart = 182821, XrefRangeEnd = 182821, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsAnyActive(CastFlags flags, CastFlags flagMask)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&flags);
		*(CastFlags**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &flagMask;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsAnyActive_Public_Static_Boolean_CastFlags_CastFlags_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public CastFlagsHelper(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class CastingInterruptSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_ability;

	private static readonly IntPtr NativeFieldInfoPtr_trigger;

	private static readonly IntPtr NativeFieldInfoPtr_interruptOnDamaged;

	private static readonly IntPtr NativeFieldInfoPtr_castFlags;

	private static readonly IntPtr NativeFieldInfoPtr_interruptOnTeleportLocks;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_Boolean_CastFlags_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

	public unsafe Ability ability
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Ability>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability));
		}
	}

	public unsafe byte trigger
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trigger);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trigger)) = b;
		}
	}

	public unsafe bool interruptOnDamaged
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_interruptOnDamaged);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_interruptOnDamaged)) = flag;
		}
	}

	public unsafe CastFlags castFlags
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castFlags);
			return *(CastFlags*)num;
		}
		set
		{
			*(CastFlags*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castFlags)) = castFlags;
		}
	}

	public unsafe bool interruptOnTeleportLocks
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_interruptOnTeleportLocks);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_interruptOnTeleportLocks)) = flag;
		}
	}

	static CastingInterruptSubroutine()
	{
		Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CastingInterruptSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr, "ability");
		NativeFieldInfoPtr_trigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr, "trigger");
		NativeFieldInfoPtr_interruptOnDamaged = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr, "interruptOnDamaged");
		NativeFieldInfoPtr_castFlags = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr, "castFlags");
		NativeFieldInfoPtr_interruptOnTeleportLocks = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr, "interruptOnTeleportLocks");
		NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_Boolean_CastFlags_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr, 100674968);
		NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr, 100674969);
	}

	[CallerCount(25)]
	[CachedScanResults(RefRangeStart = 155424, RefRangeEnd = 155449, XrefRangeStart = 155423, XrefRangeEnd = 155424, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CastingInterruptSubroutine(Ability _ability, byte _trigger, bool _interruptOnDamaged, CastFlags _castFlags, bool _interruptOnTeleportLocks = false)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CastingInterruptSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
		*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_trigger;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &_interruptOnDamaged;
		*(CastFlags**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &_castFlags;
		*(bool**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &_interruptOnTeleportLocks;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_Boolean_CastFlags_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 155449, XrefRangeEnd = 155457, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public CastingInterruptSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}

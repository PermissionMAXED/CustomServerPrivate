using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class FullbodyAnimLockSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_entityManager;

	private static readonly IntPtr NativeFieldInfoPtr_action;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_EntityManager_FullbodyAnimLockAction_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_FullbodyAnimLockAction_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	public unsafe EntityManager entityManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager));
		}
	}

	public unsafe FullbodyAnimLockAction action
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_action);
			return *(FullbodyAnimLockAction*)num;
		}
		set
		{
			*(FullbodyAnimLockAction*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_action)) = fullbodyAnimLockAction;
		}
	}

	static FullbodyAnimLockSubroutine()
	{
		Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "FullbodyAnimLockSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_entityManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr, "entityManager");
		NativeFieldInfoPtr_action = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr, "action");
		NativeMethodInfoPtr__ctor_Public_Void_EntityManager_FullbodyAnimLockAction_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr, 100675039);
		NativeMethodInfoPtr__ctor_Public_Void_Ability_FullbodyAnimLockAction_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr, 100675040);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr, 100675041);
	}

	[CallerCount(110)]
	[CachedScanResults(RefRangeStart = 129576, RefRangeEnd = 129686, XrefRangeStart = 129576, XrefRangeEnd = 129686, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FullbodyAnimLockSubroutine(EntityManager entityManager, FullbodyAnimLockAction action)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		*(FullbodyAnimLockAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &action;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_EntityManager_FullbodyAnimLockAction_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(231)]
	[CachedScanResults(RefRangeStart = 156000, RefRangeEnd = 156231, XrefRangeStart = 155999, XrefRangeEnd = 156000, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FullbodyAnimLockSubroutine(Ability ability, FullbodyAnimLockAction action)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FullbodyAnimLockSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(FullbodyAnimLockAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &action;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_FullbodyAnimLockAction_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 156231, XrefRangeEnd = 156232, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public FullbodyAnimLockSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}

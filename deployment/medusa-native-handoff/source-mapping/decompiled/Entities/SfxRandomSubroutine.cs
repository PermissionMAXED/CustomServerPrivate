using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class SfxRandomSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_entityManager;

	private static readonly IntPtr NativeFieldInfoPtr_sfxTarget;

	private static readonly IntPtr NativeFieldInfoPtr_clipPool;

	private static readonly IntPtr NativeFieldInfoPtr_poolLength;

	private static readonly IntPtr NativeFieldInfoPtr_sfxIdByIndex;

	private static readonly IntPtr NativeFieldInfoPtr_lastIndex;

	private static readonly IntPtr NativeFieldInfoPtr_anyCooldownActive;

	private static readonly IntPtr NativeFieldInfoPtr_lastFixedTime;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxTarget_RandomAudioClipPool_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxTarget_RandomAudioClipPool_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_TickCd_Private_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetClipDataIndex_Private_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetRandomIndex_Private_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetCurrentSfxId_Public_Int32_0;

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

	public unsafe SfxTarget sfxTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxTarget);
			return *(SfxTarget*)num;
		}
		set
		{
			*(SfxTarget*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxTarget)) = sfxTarget;
		}
	}

	public unsafe RandomAudioClipPool clipPool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clipPool);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RandomAudioClipPool>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clipPool)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)randomAudioClipPool));
		}
	}

	public unsafe int poolLength
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poolLength);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poolLength)) = num;
		}
	}

	public unsafe Il2CppStructArray<int> sfxIdByIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxIdByIndex);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxIdByIndex)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe int lastIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastIndex)) = num;
		}
	}

	public unsafe bool anyCooldownActive
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_anyCooldownActive);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_anyCooldownActive)) = flag;
		}
	}

	public unsafe double lastFixedTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastFixedTime);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastFixedTime)) = num;
		}
	}

	static SfxRandomSubroutine()
	{
		Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "SfxRandomSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_entityManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "entityManager");
		NativeFieldInfoPtr_sfxTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "sfxTarget");
		NativeFieldInfoPtr_clipPool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "clipPool");
		NativeFieldInfoPtr_poolLength = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "poolLength");
		NativeFieldInfoPtr_sfxIdByIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "sfxIdByIndex");
		NativeFieldInfoPtr_lastIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "lastIndex");
		NativeFieldInfoPtr_anyCooldownActive = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "anyCooldownActive");
		NativeFieldInfoPtr_lastFixedTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, "lastFixedTime");
		NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxTarget_RandomAudioClipPool_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, 100675119);
		NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxTarget_RandomAudioClipPool_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, 100675120);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, 100675121);
		NativeMethodInfoPtr_TickCd_Private_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, 100675122);
		NativeMethodInfoPtr_GetClipDataIndex_Private_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, 100675123);
		NativeMethodInfoPtr_GetRandomIndex_Private_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, 100675124);
		NativeMethodInfoPtr_GetCurrentSfxId_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr, 100675125);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 157113, XrefRangeEnd = 157123, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SfxRandomSubroutine(EntityManager entityManager, SfxTarget sfxTarget, RandomAudioClipPool clipPool)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		*(SfxTarget**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clipPool);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxTarget_RandomAudioClipPool_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 157133, RefRangeEnd = 157135, XrefRangeStart = 157123, XrefRangeEnd = 157133, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SfxRandomSubroutine(Ability ability, SfxTarget sfxTarget, RandomAudioClipPool randomClipPool)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SfxRandomSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(SfxTarget**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)randomClipPool);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxTarget_RandomAudioClipPool_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 157135, XrefRangeEnd = 157142, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	[CallerCount(0)]
	public unsafe void TickCd(float fixedDt)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&fixedDt);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TickCd_Private_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 157143, RefRangeEnd = 157144, XrefRangeStart = 157142, XrefRangeEnd = 157143, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetClipDataIndex(int predTickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&predTickNum);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetClipDataIndex_Private_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetRandomIndex(int predTickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&predTickNum);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomIndex_Private_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetCurrentSfxId()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentSfxId_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public SfxRandomSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}

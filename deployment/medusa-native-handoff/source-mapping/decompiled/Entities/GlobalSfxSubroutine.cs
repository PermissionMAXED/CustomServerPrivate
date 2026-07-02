using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppBAPBAP.Network.EventData;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class GlobalSfxSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_ability;

	private static readonly IntPtr NativeFieldInfoPtr_sfxAction;

	private static readonly IntPtr NativeFieldInfoPtr_sfxTarget;

	private static readonly IntPtr NativeFieldInfoPtr_sfxId;

	private static readonly IntPtr NativeFieldInfoPtr_volume;

	private static readonly IntPtr NativeFieldInfoPtr_randomPitch;

	private static readonly IntPtr NativeFieldInfoPtr_distanceMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_minDistAmount;

	private static readonly IntPtr NativeFieldInfoPtr_teamTarget;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_Int32_Single_Single_Single_Single_SfxTeamTarget_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClip_Single_Single_Single_Single_SfxTeamTarget_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClipData_Single_Single_SfxTeamTarget_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

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

	public unsafe SfxEventAction sfxAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxAction);
			return *(SfxEventAction*)num;
		}
		set
		{
			*(SfxEventAction*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxAction)) = sfxEventAction;
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

	public unsafe int sfxId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxId)) = num;
		}
	}

	public unsafe float volume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_volume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_volume)) = num;
		}
	}

	public unsafe float randomPitch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPitch);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPitch)) = num;
		}
	}

	public unsafe float distanceMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distanceMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distanceMultiplier)) = num;
		}
	}

	public unsafe float minDistAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistAmount);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistAmount)) = num;
		}
	}

	public unsafe SfxTeamTarget teamTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamTarget);
			return *(SfxTeamTarget*)num;
		}
		set
		{
			*(SfxTeamTarget*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teamTarget)) = sfxTeamTarget;
		}
	}

	static GlobalSfxSubroutine()
	{
		Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "GlobalSfxSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "ability");
		NativeFieldInfoPtr_sfxAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "sfxAction");
		NativeFieldInfoPtr_sfxTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "sfxTarget");
		NativeFieldInfoPtr_sfxId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "sfxId");
		NativeFieldInfoPtr_volume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "volume");
		NativeFieldInfoPtr_randomPitch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "randomPitch");
		NativeFieldInfoPtr_distanceMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "distanceMultiplier");
		NativeFieldInfoPtr_minDistAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "minDistAmount");
		NativeFieldInfoPtr_teamTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, "teamTarget");
		NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_Int32_Single_Single_Single_Single_SfxTeamTarget_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, 100675042);
		NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClip_Single_Single_Single_Single_SfxTeamTarget_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, 100675043);
		NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClipData_Single_Single_SfxTeamTarget_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, 100675044);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr, 100675045);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 156233, RefRangeEnd = 156234, XrefRangeStart = 156232, XrefRangeEnd = 156233, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GlobalSfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float randomPitch, float distanceMultiplier, float minDistAmount, SfxTeamTarget teamTarget = SfxTeamTarget.All)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[9];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &sfxId;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &volume;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &randomPitch;
		*(float**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = &distanceMultiplier;
		*(float**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(IntPtr)))) = &minDistAmount;
		*(SfxTeamTarget**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(IntPtr)))) = &teamTarget;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_Int32_Single_Single_Single_Single_SfxTeamTarget_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 156240, RefRangeEnd = 156244, XrefRangeStart = 156234, XrefRangeEnd = 156240, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GlobalSfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClip clip, float volume, float randomPitch, float distanceMultiplier, float minDistAmount, SfxTeamTarget teamTarget = SfxTeamTarget.All)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[9];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clip);
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &volume;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &randomPitch;
		*(float**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = &distanceMultiplier;
		*(float**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(IntPtr)))) = &minDistAmount;
		*(SfxTeamTarget**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(IntPtr)))) = &teamTarget;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClip_Single_Single_Single_Single_SfxTeamTarget_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 156250, RefRangeEnd = 156252, XrefRangeStart = 156244, XrefRangeEnd = 156250, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GlobalSfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClipData audioData, float distanceMultiplier, float minDistAmount, SfxTeamTarget teamTarget = SfxTeamTarget.All)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GlobalSfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[7];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioData);
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &distanceMultiplier;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &minDistAmount;
		*(SfxTeamTarget**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = &teamTarget;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClipData_Single_Single_SfxTeamTarget_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 156252, XrefRangeEnd = 156257, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	public GlobalSfxSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}

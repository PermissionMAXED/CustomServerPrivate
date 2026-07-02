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

public class SfxSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_entityManager;

	private static readonly IntPtr NativeFieldInfoPtr_sfxAction;

	private static readonly IntPtr NativeFieldInfoPtr_sfxTarget;

	private static readonly IntPtr NativeFieldInfoPtr_sfxId;

	private static readonly IntPtr NativeFieldInfoPtr_volume;

	private static readonly IntPtr NativeFieldInfoPtr_pitchSpread;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxEventAction_SfxTarget_Int32_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxEventAction_SfxTarget_AudioClipData_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_Int32_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClip_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClipData_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnAudio_Protected_Void_Int32_Boolean_0;

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

	public unsafe float pitchSpread
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pitchSpread);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pitchSpread)) = num;
		}
	}

	static SfxSubroutine()
	{
		Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "SfxSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_entityManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, "entityManager");
		NativeFieldInfoPtr_sfxAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, "sfxAction");
		NativeFieldInfoPtr_sfxTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, "sfxTarget");
		NativeFieldInfoPtr_sfxId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, "sfxId");
		NativeFieldInfoPtr_volume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, "volume");
		NativeFieldInfoPtr_pitchSpread = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, "pitchSpread");
		NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxEventAction_SfxTarget_Int32_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, 100675126);
		NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxEventAction_SfxTarget_AudioClipData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, 100675127);
		NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_Int32_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, 100675128);
		NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClip_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, 100675129);
		NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClipData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, 100675130);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, 100675131);
		NativeMethodInfoPtr_SpawnAudio_Protected_Void_Int32_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr, 100675132);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 157144, XrefRangeEnd = 157145, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SfxSubroutine(EntityManager entityManager, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float pitchSpread)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[6];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &sfxId;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &volume;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &pitchSpread;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxEventAction_SfxTarget_Int32_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 157148, RefRangeEnd = 157156, XrefRangeStart = 157145, XrefRangeEnd = 157148, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SfxSubroutine(EntityManager entityManager, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClipData audioData)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioData);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_EntityManager_SfxEventAction_SfxTarget_AudioClipData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(22)]
	[CachedScanResults(RefRangeStart = 157157, RefRangeEnd = 157179, XrefRangeStart = 157156, XrefRangeEnd = 157157, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, int sfxId, float volume, float pitchSpread)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[6];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &sfxId;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &volume;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &pitchSpread;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_Int32_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(179)]
	[CachedScanResults(RefRangeStart = 157182, RefRangeEnd = 157361, XrefRangeStart = 157179, XrefRangeEnd = 157182, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClip clip, float volume, float pitchSpread)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[6];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clip);
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &volume;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &pitchSpread;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClip_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(78)]
	[CachedScanResults(RefRangeStart = 157364, RefRangeEnd = 157442, XrefRangeStart = 157361, XrefRangeEnd = 157364, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SfxSubroutine(Ability ability, SfxEventAction sfxAction, SfxTarget sfxTarget, AudioClipData audioData)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SfxSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(SfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &sfxAction;
		*(SfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &sfxTarget;
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioData);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_SfxEventAction_SfxTarget_AudioClipData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 157442, XrefRangeEnd = 157443, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 157447, RefRangeEnd = 157449, XrefRangeStart = 157443, XrefRangeEnd = 157447, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnAudio(int predTickNum, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&predTickNum);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnAudio_Protected_Void_Int32_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SfxSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}

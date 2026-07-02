using System;
using System.Runtime.CompilerServices;
using Il2CppFMOD.Studio;
using Il2CppFMODUnity;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class FMODManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr__lobbyMusicEvent;

	private static readonly IntPtr NativeFieldInfoPtr__downedSnapshot;

	private static readonly IntPtr NativeFieldInfoPtr__instanceList;

	private static readonly IntPtr NativeFieldInfoPtr__uniqueLookup;

	private static readonly IntPtr NativeFieldInfoPtr__uniqueSet;

	private static readonly IntPtr NativeFieldInfoPtr__lobbyMusicInstance;

	private static readonly IntPtr NativeFieldInfoPtr__snapshotInstance;

	private static readonly IntPtr NativeMethodInfoPtr_get_DownedSnapshot_Public_get_EventReference_0;

	private static readonly IntPtr NativeMethodInfoPtr_Play_Public_Void_EventDescription_GameObject_Boolean_Boolean_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_PlayLobbyMusic_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_StopLobbyMusic_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetSnapshot_Public_Void_EventReference_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetBusVolume_Public_Void_String_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe EventReference _lobbyMusicEvent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyMusicEvent);
			return *(EventReference*)num;
		}
		set
		{
			*(EventReference*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyMusicEvent)) = eventReference;
		}
	}

	public unsafe EventReference _downedSnapshot
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__downedSnapshot);
			return *(EventReference*)num;
		}
		set
		{
			*(EventReference*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__downedSnapshot)) = eventReference;
		}
	}

	public unsafe List<EventInstance> _instanceList
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__instanceList);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<EventInstance>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__instanceList)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe Dictionary<IntPtr, int> _uniqueLookup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uniqueLookup);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<IntPtr, int>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uniqueLookup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe Dictionary<int, EventInstance> _uniqueSet
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uniqueSet);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<int, EventInstance>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uniqueSet)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe EventInstance _lobbyMusicInstance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyMusicInstance);
			return *(EventInstance*)num;
		}
		set
		{
			*(EventInstance*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyMusicInstance)) = eventInstance;
		}
	}

	public unsafe EventInstance _snapshotInstance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__snapshotInstance);
			return *(EventInstance*)num;
		}
		set
		{
			*(EventInstance*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__snapshotInstance)) = eventInstance;
		}
	}

	public unsafe EventReference DownedSnapshot
	{
		[CallerCount(22)]
		[CachedScanResults(RefRangeStart = 226225, RefRangeEnd = 226247, XrefRangeStart = 226225, XrefRangeEnd = 226225, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DownedSnapshot_Public_get_EventReference_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(EventReference*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static FMODManager()
	{
		Il2CppClassPointerStore<FMODManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "FMODManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FMODManager>.NativeClassPtr);
		NativeFieldInfoPtr__lobbyMusicEvent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, "_lobbyMusicEvent");
		NativeFieldInfoPtr__downedSnapshot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, "_downedSnapshot");
		NativeFieldInfoPtr__instanceList = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, "_instanceList");
		NativeFieldInfoPtr__uniqueLookup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, "_uniqueLookup");
		NativeFieldInfoPtr__uniqueSet = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, "_uniqueSet");
		NativeFieldInfoPtr__lobbyMusicInstance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, "_lobbyMusicInstance");
		NativeFieldInfoPtr__snapshotInstance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, "_snapshotInstance");
		NativeMethodInfoPtr_get_DownedSnapshot_Public_get_EventReference_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684275);
		NativeMethodInfoPtr_Play_Public_Void_EventDescription_GameObject_Boolean_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684276);
		NativeMethodInfoPtr_PlayLobbyMusic_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684277);
		NativeMethodInfoPtr_StopLobbyMusic_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684278);
		NativeMethodInfoPtr_SetSnapshot_Public_Void_EventReference_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684279);
		NativeMethodInfoPtr_SetBusVolume_Public_Void_String_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684280);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684281);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FMODManager>.NativeClassPtr, 100684282);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 226286, RefRangeEnd = 226291, XrefRangeStart = 226247, XrefRangeEnd = 226286, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Play(EventDescription @event, GameObject obj = null, bool attached = true, bool unique = false, bool @override = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = (nint)(&@event);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &attached;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &unique;
		*(bool**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &@override;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Play_Public_Void_EventDescription_GameObject_Boolean_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226299, RefRangeEnd = 226301, XrefRangeStart = 226291, XrefRangeEnd = 226299, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayLobbyMusic()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayLobbyMusic_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226304, RefRangeEnd = 226307, XrefRangeStart = 226301, XrefRangeEnd = 226304, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void StopLobbyMusic()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StopLobbyMusic_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 226315, RefRangeEnd = 226319, XrefRangeStart = 226307, XrefRangeEnd = 226315, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetSnapshot(EventReference eventReference)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&eventReference);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetSnapshot_Public_Void_EventReference_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 226326, RefRangeEnd = 226335, XrefRangeStart = 226319, XrefRangeEnd = 226326, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetBusVolume(string name, float volume)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(name);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &volume;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetBusVolume_Public_Void_String_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226335, XrefRangeEnd = 226349, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226349, XrefRangeEnd = 226362, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FMODManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FMODManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public FMODManager(IntPtr pointer)
		: base(pointer)
	{
	}
}

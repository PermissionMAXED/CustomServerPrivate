using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class ChangeSpawnLocationSuccessMessage : Il2CppSystem.Object
{
	[System.Serializable]
	public class Payload : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_spawnLocation;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Vector2 spawnLocation
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnLocation);
				return *(Vector2*)num;
			}
			set
			{
				*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnLocation)) = vector;
			}
		}

		static Payload()
		{
			Il2CppClassPointerStore<Payload>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ChangeSpawnLocationSuccessMessage>.NativeClassPtr, "Payload");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Payload>.NativeClassPtr);
			NativeFieldInfoPtr_spawnLocation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Payload>.NativeClassPtr, "spawnLocation");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Payload>.NativeClassPtr, 100666352);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Payload()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Payload>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Payload(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_event;

	private static readonly System.IntPtr NativeFieldInfoPtr_payload;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string @event
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_event);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_event)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe Payload payload
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_payload);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Payload>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_payload)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)payload));
		}
	}

	static ChangeSpawnLocationSuccessMessage()
	{
		Il2CppClassPointerStore<ChangeSpawnLocationSuccessMessage>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "ChangeSpawnLocationSuccessMessage");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ChangeSpawnLocationSuccessMessage>.NativeClassPtr);
		NativeFieldInfoPtr_event = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChangeSpawnLocationSuccessMessage>.NativeClassPtr, "event");
		NativeFieldInfoPtr_payload = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChangeSpawnLocationSuccessMessage>.NativeClassPtr, "payload");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ChangeSpawnLocationSuccessMessage>.NativeClassPtr, 100666351);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ChangeSpawnLocationSuccessMessage()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ChangeSpawnLocationSuccessMessage>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ChangeSpawnLocationSuccessMessage(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

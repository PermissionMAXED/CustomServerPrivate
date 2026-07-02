using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class CharacterUpdatedMessage : Il2CppSystem.Object
{
	[System.Serializable]
	public class Payload : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeFieldInfoPtr_charId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int charId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charId)) = num;
			}
		}

		static Payload()
		{
			Il2CppClassPointerStore<Payload>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterUpdatedMessage>.NativeClassPtr, "Payload");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Payload>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Payload>.NativeClassPtr, "accountId");
			NativeFieldInfoPtr_charId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Payload>.NativeClassPtr, "charId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Payload>.NativeClassPtr, 100666342);
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

	static CharacterUpdatedMessage()
	{
		Il2CppClassPointerStore<CharacterUpdatedMessage>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "CharacterUpdatedMessage");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharacterUpdatedMessage>.NativeClassPtr);
		NativeFieldInfoPtr_event = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterUpdatedMessage>.NativeClassPtr, "event");
		NativeFieldInfoPtr_payload = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterUpdatedMessage>.NativeClassPtr, "payload");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterUpdatedMessage>.NativeClassPtr, 100666341);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CharacterUpdatedMessage()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharacterUpdatedMessage>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CharacterUpdatedMessage(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

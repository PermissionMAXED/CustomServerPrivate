using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Content;
using Il2CppBAPBAP.Localisation;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class TombstoneManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_tombstoneData;

	private static readonly IntPtr NativeFieldInfoPtr_tombstoneRektByTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_tombstoneGotRektTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_tombstoneRektByStr;

	private static readonly IntPtr NativeFieldInfoPtr_tombstoneGotRektStr;

	private static readonly IntPtr NativeMethodInfoPtr_Localise_Public_Void_Translator_0;

	private static readonly IntPtr NativeMethodInfoPtr_BuildTombstoneMessage_Public_String_String_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTombstoneByAssetId_Public_Tombstone_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe TombstoneData tombstoneData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneData);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<TombstoneData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tombstoneData));
		}
	}

	public unsafe string tombstoneRektByTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneRektByTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneRektByTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string tombstoneGotRektTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneGotRektTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneGotRektTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string tombstoneRektByStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneRektByStr);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneRektByStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string tombstoneGotRektStr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneGotRektStr);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneGotRektStr)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static TombstoneManager()
	{
		Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "TombstoneManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr);
		NativeFieldInfoPtr_tombstoneData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, "tombstoneData");
		NativeFieldInfoPtr_tombstoneRektByTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, "tombstoneRektByTranslationKey");
		NativeFieldInfoPtr_tombstoneGotRektTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, "tombstoneGotRektTranslationKey");
		NativeFieldInfoPtr_tombstoneRektByStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, "tombstoneRektByStr");
		NativeFieldInfoPtr_tombstoneGotRektStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, "tombstoneGotRektStr");
		NativeMethodInfoPtr_Localise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, 100684504);
		NativeMethodInfoPtr_BuildTombstoneMessage_Public_String_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, 100684505);
		NativeMethodInfoPtr_GetTombstoneByAssetId_Public_Tombstone_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, 100684506);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr, 100684507);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 228668, RefRangeEnd = 228669, XrefRangeStart = 228666, XrefRangeEnd = 228668, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Localise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 228675, RefRangeEnd = 228677, XrefRangeStart = 228669, XrefRangeEnd = 228675, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string BuildTombstoneMessage(string killedName, string killerName)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(killedName);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(killerName);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildTombstoneMessage_Public_String_String_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 228679, RefRangeEnd = 228681, XrefRangeStart = 228677, XrefRangeEnd = 228679, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Tombstone GetTombstoneByAssetId(int tombstoneAssetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&tombstoneAssetId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTombstoneByAssetId_Public_Tombstone_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Tombstone>(intPtr) : null;
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TombstoneManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TombstoneManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public TombstoneManager(IntPtr pointer)
		: base(pointer)
	{
	}
}

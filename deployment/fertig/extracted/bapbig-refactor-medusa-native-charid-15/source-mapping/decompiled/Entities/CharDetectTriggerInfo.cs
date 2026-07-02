using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class CharDetectTriggerInfo : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_ownerTeamId;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int ownerTeamId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerTeamId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerTeamId)) = num;
		}
	}

	static CharDetectTriggerInfo()
	{
		Il2CppClassPointerStore<CharDetectTriggerInfo>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CharDetectTriggerInfo");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharDetectTriggerInfo>.NativeClassPtr);
		NativeFieldInfoPtr_ownerTeamId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharDetectTriggerInfo>.NativeClassPtr, "ownerTeamId");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharDetectTriggerInfo>.NativeClassPtr, 100678783);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CharDetectTriggerInfo()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharDetectTriggerInfo>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CharDetectTriggerInfo(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class ChallengePreviewResponse : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_prizePool;

	private static readonly System.IntPtr NativeFieldInfoPtr_numSignUps;

	private static readonly System.IntPtr NativeFieldInfoPtr_numSignUpsNeeded;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int prizePool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prizePool);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prizePool)) = num;
		}
	}

	public unsafe int numSignUps
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numSignUps);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numSignUps)) = num;
		}
	}

	public unsafe int numSignUpsNeeded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numSignUpsNeeded);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numSignUpsNeeded)) = num;
		}
	}

	static ChallengePreviewResponse()
	{
		Il2CppClassPointerStore<ChallengePreviewResponse>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "ChallengePreviewResponse");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ChallengePreviewResponse>.NativeClassPtr);
		NativeFieldInfoPtr_prizePool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengePreviewResponse>.NativeClassPtr, "prizePool");
		NativeFieldInfoPtr_numSignUps = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengePreviewResponse>.NativeClassPtr, "numSignUps");
		NativeFieldInfoPtr_numSignUpsNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ChallengePreviewResponse>.NativeClassPtr, "numSignUpsNeeded");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ChallengePreviewResponse>.NativeClassPtr, 100666501);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ChallengePreviewResponse()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ChallengePreviewResponse>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ChallengePreviewResponse(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

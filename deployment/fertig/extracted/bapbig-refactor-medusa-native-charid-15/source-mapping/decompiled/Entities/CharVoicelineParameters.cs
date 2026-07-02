using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Entities;

[System.Serializable]
public class CharVoicelineParameters : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_AttachToCharacter;

	private static readonly System.IntPtr NativeFieldInfoPtr_UniquePerCharacter;

	private static readonly System.IntPtr NativeFieldInfoPtr_OverrideUnique;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe bool AttachToCharacter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AttachToCharacter);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_AttachToCharacter)) = flag;
		}
	}

	public unsafe bool UniquePerCharacter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UniquePerCharacter);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UniquePerCharacter)) = flag;
		}
	}

	public unsafe bool OverrideUnique
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OverrideUnique);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OverrideUnique)) = flag;
		}
	}

	static CharVoicelineParameters()
	{
		Il2CppClassPointerStore<CharVoicelineParameters>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CharVoicelineParameters");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharVoicelineParameters>.NativeClassPtr);
		NativeFieldInfoPtr_AttachToCharacter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineParameters>.NativeClassPtr, "AttachToCharacter");
		NativeFieldInfoPtr_UniquePerCharacter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineParameters>.NativeClassPtr, "UniquePerCharacter");
		NativeFieldInfoPtr_OverrideUnique = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineParameters>.NativeClassPtr, "OverrideUnique");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineParameters>.NativeClassPtr, 100673063);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 122679, XrefRangeEnd = 122680, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CharVoicelineParameters()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharVoicelineParameters>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CharVoicelineParameters(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

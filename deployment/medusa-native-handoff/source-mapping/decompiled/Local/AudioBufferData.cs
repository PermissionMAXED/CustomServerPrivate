using System;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public sealed class AudioBufferData : Il2CppSystem.ValueType
{
	private static readonly System.IntPtr NativeFieldInfoPtr_clip;

	public unsafe AudioClip clip
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clip);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClip>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clip)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClip));
		}
	}

	static AudioBufferData()
	{
		Il2CppClassPointerStore<AudioBufferData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "AudioBufferData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AudioBufferData>.NativeClassPtr);
		NativeFieldInfoPtr_clip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AudioBufferData>.NativeClassPtr, "clip");
	}

	public AudioBufferData(System.IntPtr pointer)
		: base(pointer)
	{
	}

	public AudioBufferData()
		: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AudioBufferData>.NativeClassPtr))
	{
	}
}

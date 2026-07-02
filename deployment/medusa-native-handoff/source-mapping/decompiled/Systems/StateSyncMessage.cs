using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Systems;

public sealed class StateSyncMessage : Il2CppSystem.ValueType
{
	private static readonly System.IntPtr NativeFieldInfoPtr_svState;

	private static readonly System.IntPtr NativeFieldInfoPtr_svEvents;

	public unsafe Il2CppSystem.ArraySegment<byte> svState
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svState);
			return new Il2CppSystem.ArraySegment<byte>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<Il2CppSystem.ArraySegment<byte>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svState), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)arraySegment)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<Il2CppSystem.ArraySegment<byte>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	public unsafe Il2CppSystem.ArraySegment<byte> svEvents
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svEvents);
			return new Il2CppSystem.ArraySegment<byte>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<Il2CppSystem.ArraySegment<byte>>.NativeClassPtr, (System.IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svEvents), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)arraySegment)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<Il2CppSystem.ArraySegment<byte>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	static StateSyncMessage()
	{
		Il2CppClassPointerStore<StateSyncMessage>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Systems", "StateSyncMessage");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<StateSyncMessage>.NativeClassPtr);
		NativeFieldInfoPtr_svState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StateSyncMessage>.NativeClassPtr, "svState");
		NativeFieldInfoPtr_svEvents = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StateSyncMessage>.NativeClassPtr, "svEvents");
	}

	public StateSyncMessage(System.IntPtr pointer)
		: base(pointer)
	{
	}

	public StateSyncMessage()
		: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<StateSyncMessage>.NativeClassPtr))
	{
	}
}

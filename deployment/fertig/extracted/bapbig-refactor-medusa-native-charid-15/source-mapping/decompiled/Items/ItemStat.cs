using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Items;

[System.Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct ItemStat
{
	private static readonly System.IntPtr NativeFieldInfoPtr_stat;

	private static readonly System.IntPtr NativeFieldInfoPtr_value;

	[FieldOffset(0)]
	public Stats stat;

	[FieldOffset(4)]
	public float value;

	static ItemStat()
	{
		Il2CppClassPointerStore<ItemStat>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Items", "ItemStat");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ItemStat>.NativeClassPtr);
		NativeFieldInfoPtr_stat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemStat>.NativeClassPtr, "stat");
		NativeFieldInfoPtr_value = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemStat>.NativeClassPtr, "value");
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<ItemStat>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}

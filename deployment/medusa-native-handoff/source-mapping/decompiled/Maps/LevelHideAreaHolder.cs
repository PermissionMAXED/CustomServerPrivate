using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public class LevelHideAreaHolder : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_isTallGrassBush;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe bool isTallGrassBush
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isTallGrassBush);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isTallGrassBush)) = flag;
		}
	}

	static LevelHideAreaHolder()
	{
		Il2CppClassPointerStore<LevelHideAreaHolder>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "LevelHideAreaHolder");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LevelHideAreaHolder>.NativeClassPtr);
		NativeFieldInfoPtr_isTallGrassBush = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelHideAreaHolder>.NativeClassPtr, "isTallGrassBush");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelHideAreaHolder>.NativeClassPtr, 100685454);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LevelHideAreaHolder()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LevelHideAreaHolder>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LevelHideAreaHolder(IntPtr pointer)
		: base(pointer)
	{
	}
}

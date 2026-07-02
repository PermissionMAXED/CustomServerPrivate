using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UIUberGraphicSO : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_outlineSize;

	private static readonly IntPtr NativeFieldInfoPtr_color1;

	private static readonly IntPtr NativeFieldInfoPtr_color2;

	private static readonly IntPtr NativeFieldInfoPtr_gradientAngle;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float outlineSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outlineSize);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outlineSize)) = num;
		}
	}

	public unsafe Color color1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_color1);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_color1)) = color;
		}
	}

	public unsafe Color color2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_color2);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_color2)) = color;
		}
	}

	public unsafe float gradientAngle
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gradientAngle);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gradientAngle)) = num;
		}
	}

	static UIUberGraphicSO()
	{
		Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UIUberGraphicSO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr);
		NativeFieldInfoPtr_outlineSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr, "outlineSize");
		NativeFieldInfoPtr_color1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr, "color1");
		NativeFieldInfoPtr_color2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr, "color2");
		NativeFieldInfoPtr_gradientAngle = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr, "gradientAngle");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr, 100671204);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107962, XrefRangeEnd = 107963, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UIUberGraphicSO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UIUberGraphicSO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UIUberGraphicSO(IntPtr pointer)
		: base(pointer)
	{
	}
}

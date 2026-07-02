using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class IShape : Il2CppObjectBase
{
	private static readonly IntPtr NativeMethodInfoPtr_SetSize_Public_Abstract_Virtual_New_Void_Vector2_Single_0;

	static IShape()
	{
		Il2CppClassPointerStore<IShape>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "IShape");
		NativeMethodInfoPtr_SetSize_Public_Abstract_Virtual_New_Void_Vector2_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IShape>.NativeClassPtr, 100667538);
	}

	[CallerCount(0)]
	public unsafe virtual void SetSize(Vector2 halfScale, float halfAngle = 0f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&halfScale);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &halfAngle;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SetSize_Public_Abstract_Virtual_New_Void_Vector2_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public IShape(IntPtr pointer)
		: base(pointer)
	{
	}
}

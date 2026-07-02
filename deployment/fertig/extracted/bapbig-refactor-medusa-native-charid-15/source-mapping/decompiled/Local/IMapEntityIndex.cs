using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.Local;

public class IMapEntityIndex : Il2CppObjectBase
{
	private static readonly IntPtr NativeMethodInfoPtr_SetMapEntityIndex_Public_Abstract_Virtual_New_Void_Int32_0;

	static IMapEntityIndex()
	{
		Il2CppClassPointerStore<IMapEntityIndex>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "IMapEntityIndex");
		NativeMethodInfoPtr_SetMapEntityIndex_Public_Abstract_Virtual_New_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IMapEntityIndex>.NativeClassPtr, 100684253);
	}

	[CallerCount(0)]
	public unsafe virtual void SetMapEntityIndex(int index)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&index);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SetMapEntityIndex_Public_Abstract_Virtual_New_Void_Int32_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public IMapEntityIndex(IntPtr pointer)
		: base(pointer)
	{
	}
}

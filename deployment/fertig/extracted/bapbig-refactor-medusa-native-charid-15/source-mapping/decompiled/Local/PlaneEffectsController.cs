using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class PlaneEffectsController : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_planeEffectsFeature;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe RenderObjectsMirroredToTextureFeature planeEffectsFeature
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_planeEffectsFeature);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RenderObjectsMirroredToTextureFeature>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_planeEffectsFeature)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)renderObjectsMirroredToTextureFeature));
		}
	}

	static PlaneEffectsController()
	{
		Il2CppClassPointerStore<PlaneEffectsController>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "PlaneEffectsController");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlaneEffectsController>.NativeClassPtr);
		NativeFieldInfoPtr_planeEffectsFeature = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlaneEffectsController>.NativeClassPtr, "planeEffectsFeature");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlaneEffectsController>.NativeClassPtr, 100684006);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlaneEffectsController()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlaneEffectsController>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PlaneEffectsController(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Game.Dimensions;

public class D_Obj_Bubble_SO : D_Obj_SO
{
	private static readonly IntPtr NativeFieldInfoPtr_configuration;

	private static readonly IntPtr NativeMethodInfoPtr_get_config_Public_Virtual_get_D_ObjConfiguration_0;

	private static readonly IntPtr NativeMethodInfoPtr_NewInstance_Public_Virtual_D_Obj_Dimension_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe D_Obj_Bubble.Config configuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<D_Obj_Bubble.Config>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
		}
	}

	public unsafe override D_Obj.D_ObjConfiguration config
	{
		[CallerCount(140)]
		[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_config_Public_Virtual_get_D_ObjConfiguration_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<D_Obj.D_ObjConfiguration>(intPtr) : null;
		}
	}

	static D_Obj_Bubble_SO()
	{
		Il2CppClassPointerStore<D_Obj_Bubble_SO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Game.Dimensions", "D_Obj_Bubble_SO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<D_Obj_Bubble_SO>.NativeClassPtr);
		NativeFieldInfoPtr_configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_Obj_Bubble_SO>.NativeClassPtr, "configuration");
		NativeMethodInfoPtr_get_config_Public_Virtual_get_D_ObjConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Bubble_SO>.NativeClassPtr, 100672927);
		NativeMethodInfoPtr_NewInstance_Public_Virtual_D_Obj_Dimension_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Bubble_SO>.NativeClassPtr, 100672928);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Bubble_SO>.NativeClassPtr, 100672929);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121451, XrefRangeEnd = 121464, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override D_Obj NewInstance(Dimension d)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)d);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_NewInstance_Public_Virtual_D_Obj_Dimension_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<D_Obj>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe D_Obj_Bubble_SO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<D_Obj_Bubble_SO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public D_Obj_Bubble_SO(IntPtr pointer)
		: base(pointer)
	{
	}
}

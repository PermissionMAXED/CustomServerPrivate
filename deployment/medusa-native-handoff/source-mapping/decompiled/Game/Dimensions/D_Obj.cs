using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Game.Dimensions;

public class D_Obj : Il2CppSystem.Object
{
	[System.Serializable]
	public class D_ObjConfiguration : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_obj;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe GameObject obj
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obj);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		static D_ObjConfiguration()
		{
			Il2CppClassPointerStore<D_ObjConfiguration>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<D_Obj>.NativeClassPtr, "D_ObjConfiguration");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<D_ObjConfiguration>.NativeClassPtr);
			NativeFieldInfoPtr_obj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_ObjConfiguration>.NativeClassPtr, "obj");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_ObjConfiguration>.NativeClassPtr, 100672926);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe D_ObjConfiguration()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<D_ObjConfiguration>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public D_ObjConfiguration(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_dimension;

	private static readonly System.IntPtr NativeFieldInfoPtr_singleObject;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_dObjConfig_Public_Virtual_New_get_D_ObjConfiguration_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Dimension_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SvTick_Public_Virtual_New_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SvOnObjectExit_Public_Virtual_New_Void_GameObject_0;

	public unsafe Dimension dimension
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimension);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dimension>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimension)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimension));
		}
	}

	public unsafe GameObject singleObject
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_singleObject);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_singleObject)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe virtual D_ObjConfiguration dObjConfig
	{
		[CallerCount(87)]
		[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_dObjConfig_Public_Virtual_New_get_D_ObjConfiguration_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<D_ObjConfiguration>(intPtr) : null;
		}
	}

	static D_Obj()
	{
		Il2CppClassPointerStore<D_Obj>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Game.Dimensions", "D_Obj");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<D_Obj>.NativeClassPtr);
		NativeFieldInfoPtr_dimension = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_Obj>.NativeClassPtr, "dimension");
		NativeFieldInfoPtr_singleObject = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_Obj>.NativeClassPtr, "singleObject");
		NativeMethodInfoPtr_get_dObjConfig_Public_Virtual_New_get_D_ObjConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj>.NativeClassPtr, 100672922);
		NativeMethodInfoPtr__ctor_Public_Void_Dimension_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj>.NativeClassPtr, 100672923);
		NativeMethodInfoPtr_SvTick_Public_Virtual_New_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj>.NativeClassPtr, 100672924);
		NativeMethodInfoPtr_SvOnObjectExit_Public_Virtual_New_Void_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj>.NativeClassPtr, 100672925);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 121444, RefRangeEnd = 121451, XrefRangeStart = 121443, XrefRangeEnd = 121444, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe D_Obj(Dimension dimension)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<D_Obj>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimension);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Dimension_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void SvTick(float fixedDt)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&fixedDt);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SvTick_Public_Virtual_New_Void_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void SvOnObjectExit(GameObject g)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)g);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SvOnObjectExit_Public_Virtual_New_Void_GameObject_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public D_Obj(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

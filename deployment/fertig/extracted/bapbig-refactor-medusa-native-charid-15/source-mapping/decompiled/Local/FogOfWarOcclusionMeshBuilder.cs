using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class FogOfWarOcclusionMeshBuilder : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_container;

	private static readonly IntPtr NativeFieldInfoPtr_generatedMesh;

	private static readonly IntPtr NativeFieldInfoPtr_meshHeight;

	private static readonly IntPtr NativeFieldInfoPtr_getCollidersInChildren;

	private static readonly IntPtr NativeFieldInfoPtr_ignoreTriggerColliders;

	private static readonly IntPtr NativeFieldInfoPtr_spawnedInLocalSpace;

	private static readonly IntPtr NativeFieldInfoPtr_setEnabled;

	private static readonly IntPtr NativeMethodInfoPtr_Start_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetFowObjectEnabled_Public_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetOcclusionCombineInstances_Private_Il2CppStructArray_1_CombineInstance_0;

	private static readonly IntPtr NativeMethodInfoPtr_GenerateCombinedMesh_Private_Void_Il2CppStructArray_1_CombineInstance_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDestroy_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe GameObject container
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_container);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_container)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Mesh generatedMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generatedMesh);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generatedMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe static float meshHeight
	{
		get
		{
			Unsafe.SkipInit(out float result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_meshHeight, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_meshHeight, (void*)(&num));
		}
	}

	public unsafe bool getCollidersInChildren
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getCollidersInChildren);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_getCollidersInChildren)) = flag;
		}
	}

	public unsafe bool ignoreTriggerColliders
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ignoreTriggerColliders);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ignoreTriggerColliders)) = flag;
		}
	}

	public unsafe bool spawnedInLocalSpace
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnedInLocalSpace);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnedInLocalSpace)) = flag;
		}
	}

	public unsafe bool setEnabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled)) = flag;
		}
	}

	static FogOfWarOcclusionMeshBuilder()
	{
		Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "FogOfWarOcclusionMeshBuilder");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr);
		NativeFieldInfoPtr_container = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, "container");
		NativeFieldInfoPtr_generatedMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, "generatedMesh");
		NativeFieldInfoPtr_meshHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, "meshHeight");
		NativeFieldInfoPtr_getCollidersInChildren = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, "getCollidersInChildren");
		NativeFieldInfoPtr_ignoreTriggerColliders = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, "ignoreTriggerColliders");
		NativeFieldInfoPtr_spawnedInLocalSpace = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, "spawnedInLocalSpace");
		NativeFieldInfoPtr_setEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, "setEnabled");
		NativeMethodInfoPtr_Start_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, 100683918);
		NativeMethodInfoPtr_SetFowObjectEnabled_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, 100683919);
		NativeMethodInfoPtr_GetOcclusionCombineInstances_Private_Il2CppStructArray_1_CombineInstance_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, 100683920);
		NativeMethodInfoPtr_GenerateCombinedMesh_Private_Void_Il2CppStructArray_1_CombineInstance_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, 100683921);
		NativeMethodInfoPtr_OnDestroy_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, 100683922);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr, 100683923);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223640, XrefRangeEnd = 223655, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Start()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Start_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 223659, RefRangeEnd = 223660, XrefRangeStart = 223655, XrefRangeEnd = 223659, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetFowObjectEnabled(bool e)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&e);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetFowObjectEnabled_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 223722, RefRangeEnd = 223723, XrefRangeStart = 223660, XrefRangeEnd = 223722, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Il2CppStructArray<CombineInstance> GetOcclusionCombineInstances()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetOcclusionCombineInstances_Private_Il2CppStructArray_1_CombineInstance_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<CombineInstance>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223723, XrefRangeEnd = 223737, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void GenerateCombinedMesh(Il2CppStructArray<CombineInstance> ci)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ci);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GenerateCombinedMesh_Private_Void_Il2CppStructArray_1_CombineInstance_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223737, XrefRangeEnd = 223742, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDestroy()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDestroy_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223742, XrefRangeEnd = 223743, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FogOfWarOcclusionMeshBuilder()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FogOfWarOcclusionMeshBuilder>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public FogOfWarOcclusionMeshBuilder(IntPtr pointer)
		: base(pointer)
	{
	}
}

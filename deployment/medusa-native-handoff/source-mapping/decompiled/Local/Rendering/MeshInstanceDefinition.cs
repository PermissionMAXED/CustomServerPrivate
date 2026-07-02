using System;
using System.Runtime.CompilerServices;
using Il2CppAYellowpaper.SerializedCollections;
using Il2CppBAPBAP.Game.Dimensions;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local.Rendering;

[Serializable]
public class MeshInstanceDefinition : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_dimensionMeshes;

	private static readonly IntPtr NativeFieldInfoPtr_instanceMesh;

	private static readonly IntPtr NativeFieldInfoPtr_instanceMaterial;

	private static readonly IntPtr NativeFieldInfoPtr_submeshIndex;

	private static readonly IntPtr NativeFieldInfoPtr_gpuCullMultiMesh;

	private static readonly IntPtr NativeFieldInfoPtr_castShadows;

	private static readonly IntPtr NativeMethodInfoPtr_GetDefaultMesh_Private_Mesh_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetMesh_Public_Mesh_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetMesh_Public_Mesh_DimensionType_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetMaterial_Public_Material_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetSubMeshIndex_Public_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe SerializedDictionary<Dimension.DimensionType, Mesh> dimensionMeshes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionMeshes);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<SerializedDictionary<Dimension.DimensionType, Mesh>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionMeshes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedDictionary));
		}
	}

	public unsafe Mesh instanceMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instanceMesh);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instanceMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe Material instanceMaterial
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instanceMaterial);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instanceMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
		}
	}

	public unsafe int submeshIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_submeshIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_submeshIndex)) = num;
		}
	}

	public unsafe bool gpuCullMultiMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gpuCullMultiMesh);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gpuCullMultiMesh)) = flag;
		}
	}

	public unsafe bool castShadows
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castShadows);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castShadows)) = flag;
		}
	}

	static MeshInstanceDefinition()
	{
		Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local.Rendering", "MeshInstanceDefinition");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr);
		NativeFieldInfoPtr_dimensionMeshes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, "dimensionMeshes");
		NativeFieldInfoPtr_instanceMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, "instanceMesh");
		NativeFieldInfoPtr_instanceMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, "instanceMaterial");
		NativeFieldInfoPtr_submeshIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, "submeshIndex");
		NativeFieldInfoPtr_gpuCullMultiMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, "gpuCullMultiMesh");
		NativeFieldInfoPtr_castShadows = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, "castShadows");
		NativeMethodInfoPtr_GetDefaultMesh_Private_Mesh_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, 100685090);
		NativeMethodInfoPtr_GetMesh_Public_Mesh_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, 100685091);
		NativeMethodInfoPtr_GetMesh_Public_Mesh_DimensionType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, 100685092);
		NativeMethodInfoPtr_GetMaterial_Public_Material_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, 100685093);
		NativeMethodInfoPtr_GetSubMeshIndex_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, 100685094);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr, 100685095);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232487, XrefRangeEnd = 232496, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Mesh GetDefaultMesh()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDefaultMesh_Private_Mesh_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232496, XrefRangeEnd = 232498, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Mesh GetMesh()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMesh_Public_Mesh_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232498, XrefRangeEnd = 232500, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Mesh GetMesh(Dimension.DimensionType dimensionType)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&dimensionType);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMesh_Public_Mesh_DimensionType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
	}

	[CallerCount(48)]
	[CachedScanResults(RefRangeStart = 33131, RefRangeEnd = 33179, XrefRangeStart = 33131, XrefRangeEnd = 33179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Material GetMaterial()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMaterial_Public_Material_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
	}

	[CallerCount(43)]
	[CachedScanResults(RefRangeStart = 45979, RefRangeEnd = 46022, XrefRangeStart = 45979, XrefRangeEnd = 46022, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetSubMeshIndex()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSubMeshIndex_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232500, XrefRangeEnd = 232505, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MeshInstanceDefinition()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MeshInstanceDefinition>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MeshInstanceDefinition(IntPtr pointer)
		: base(pointer)
	{
	}
}

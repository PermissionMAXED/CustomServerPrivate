using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppBAPBAP.AssetContainer;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Geometry;

public class MeshShapeCreator : ShapeCreator
{
	[System.Serializable]
	public class CustomUVPosition : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_customUVPosition;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Vector2 customUVPosition
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customUVPosition);
				return *(Vector2*)num;
			}
			set
			{
				*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customUVPosition)) = vector;
			}
		}

		static CustomUVPosition()
		{
			Il2CppClassPointerStore<CustomUVPosition>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "CustomUVPosition");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomUVPosition>.NativeClassPtr);
			NativeFieldInfoPtr_customUVPosition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomUVPosition>.NativeClassPtr, "customUVPosition");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomUVPosition>.NativeClassPtr, 100685202);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomUVPosition()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomUVPosition>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CustomUVPosition(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_bakeable;

	private static readonly System.IntPtr NativeFieldInfoPtr_meshFilter;

	private static readonly System.IntPtr NativeFieldInfoPtr_restoreBoundary;

	private static readonly System.IntPtr NativeFieldInfoPtr_refineMesh;

	private static readonly System.IntPtr NativeFieldInfoPtr_area;

	private static readonly System.IntPtr NativeFieldInfoPtr_radians;

	private static readonly System.IntPtr NativeFieldInfoPtr_boundaryVertexColors;

	private static readonly System.IntPtr NativeFieldInfoPtr_boundaryColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_fillVertexColors;

	private static readonly System.IntPtr NativeFieldInfoPtr_fillColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_allExtrude;

	private static readonly System.IntPtr NativeFieldInfoPtr_offsetToExtrusion;

	private static readonly System.IntPtr NativeFieldInfoPtr_useCustomUVPosition;

	private static readonly System.IntPtr NativeFieldInfoPtr_customUVPosition;

	private static readonly System.IntPtr NativeFieldInfoPtr_customUVSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_offsetUpByPointOffset;

	private static readonly System.IntPtr NativeFieldInfoPtr_bakeToNavMesh;

	private static readonly System.IntPtr NativeFieldInfoPtr_bakeToNavMeshNonWalkable;

	private static readonly System.IntPtr NativeFieldInfoPtr_uvSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_vertexColorSources;

	private static readonly System.IntPtr NativeFieldInfoPtr_owner;

	private static readonly System.IntPtr NativeFieldInfoPtr_container;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Owner_Public_get_Owner_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Container_Public_get_MeshAssetContainer_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_IsBaked_Public_Virtual_New_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnEnable_Protected_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Start_Protected_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnRequestBakeProcesses_Protected_Virtual_New_Void_Dictionary_2_MeshAssetContainer_List_1_MeshFilter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDisable_Protected_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Unbake_Public_Virtual_New_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BakeToNavMesh_Private_Void_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNavMeshBuildStart_Public_Virtual_Final_New_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNavMeshBuildEnd_Public_Virtual_Final_New_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ResampleSplines_Private_List_1_Shape_List_1_Shape_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetShapesToMeshSettings_Private_ShapesToMeshSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetValidShapes_Private_List_1_Shape_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe bool bakeable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeable);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeable)) = flag;
		}
	}

	public unsafe MeshFilter meshFilter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_meshFilter);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshFilter>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_meshFilter)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)meshFilter));
		}
	}

	public unsafe bool restoreBoundary
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_restoreBoundary);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_restoreBoundary)) = flag;
		}
	}

	public unsafe bool refineMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_refineMesh);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_refineMesh)) = flag;
		}
	}

	public unsafe float area
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_area);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_area)) = num;
		}
	}

	public unsafe float radians
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_radians);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_radians)) = num;
		}
	}

	public unsafe bool boundaryVertexColors
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_boundaryVertexColors);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_boundaryVertexColors)) = flag;
		}
	}

	public unsafe Color boundaryColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_boundaryColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_boundaryColor)) = color;
		}
	}

	public unsafe bool fillVertexColors
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillVertexColors);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillVertexColors)) = flag;
		}
	}

	public unsafe Color fillColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fillColor)) = color;
		}
	}

	public unsafe float allExtrude
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allExtrude);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allExtrude)) = num;
		}
	}

	public unsafe bool offsetToExtrusion
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offsetToExtrusion);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offsetToExtrusion)) = flag;
		}
	}

	public unsafe bool useCustomUVPosition
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_useCustomUVPosition);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_useCustomUVPosition)) = flag;
		}
	}

	public unsafe CustomUVPosition customUVPosition
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customUVPosition);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CustomUVPosition>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customUVPosition)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customUVPosition));
		}
	}

	public unsafe Vector2 customUVSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customUVSize);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customUVSize)) = vector;
		}
	}

	public unsafe bool offsetUpByPointOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offsetUpByPointOffset);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offsetUpByPointOffset)) = flag;
		}
	}

	public unsafe bool bakeToNavMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeToNavMesh);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeToNavMesh)) = flag;
		}
	}

	public unsafe bool bakeToNavMeshNonWalkable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeToNavMeshNonWalkable);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeToNavMeshNonWalkable)) = flag;
		}
	}

	public unsafe int uvSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uvSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uvSize)) = num;
		}
	}

	public unsafe List<ShapeUtils.VertexColorSource> vertexColorSources
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vertexColorSources);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<ShapeUtils.VertexColorSource>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vertexColorSources)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe Owner owner
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_owner);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Owner>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_owner)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)owner));
		}
	}

	public unsafe MeshAssetContainer container
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_container);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshAssetContainer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_container)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)meshAssetContainer));
		}
	}

	public unsafe Owner Owner
	{
		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 233851, RefRangeEnd = 233854, XrefRangeStart = 233847, XrefRangeEnd = 233851, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Owner_Public_get_Owner_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Owner>(intPtr) : null;
		}
	}

	public unsafe MeshAssetContainer Container
	{
		[CallerCount(15)]
		[CachedScanResults(RefRangeStart = 233861, RefRangeEnd = 233876, XrefRangeStart = 233854, XrefRangeEnd = 233861, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Container_Public_get_MeshAssetContainer_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshAssetContainer>(intPtr) : null;
		}
	}

	public unsafe virtual bool IsBaked
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233876, XrefRangeEnd = 233890, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_IsBaked_Public_Virtual_New_get_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static MeshShapeCreator()
	{
		Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Geometry", "MeshShapeCreator");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr);
		NativeFieldInfoPtr_bakeable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "bakeable");
		NativeFieldInfoPtr_meshFilter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "meshFilter");
		NativeFieldInfoPtr_restoreBoundary = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "restoreBoundary");
		NativeFieldInfoPtr_refineMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "refineMesh");
		NativeFieldInfoPtr_area = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "area");
		NativeFieldInfoPtr_radians = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "radians");
		NativeFieldInfoPtr_boundaryVertexColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "boundaryVertexColors");
		NativeFieldInfoPtr_boundaryColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "boundaryColor");
		NativeFieldInfoPtr_fillVertexColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "fillVertexColors");
		NativeFieldInfoPtr_fillColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "fillColor");
		NativeFieldInfoPtr_allExtrude = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "allExtrude");
		NativeFieldInfoPtr_offsetToExtrusion = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "offsetToExtrusion");
		NativeFieldInfoPtr_useCustomUVPosition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "useCustomUVPosition");
		NativeFieldInfoPtr_customUVPosition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "customUVPosition");
		NativeFieldInfoPtr_customUVSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "customUVSize");
		NativeFieldInfoPtr_offsetUpByPointOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "offsetUpByPointOffset");
		NativeFieldInfoPtr_bakeToNavMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "bakeToNavMesh");
		NativeFieldInfoPtr_bakeToNavMeshNonWalkable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "bakeToNavMeshNonWalkable");
		NativeFieldInfoPtr_uvSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "uvSize");
		NativeFieldInfoPtr_vertexColorSources = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "vertexColorSources");
		NativeFieldInfoPtr_owner = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "owner");
		NativeFieldInfoPtr_container = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, "container");
		NativeMethodInfoPtr_get_Owner_Public_get_Owner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685186);
		NativeMethodInfoPtr_get_Container_Public_get_MeshAssetContainer_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685187);
		NativeMethodInfoPtr_get_IsBaked_Public_Virtual_New_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685188);
		NativeMethodInfoPtr_OnEnable_Protected_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685189);
		NativeMethodInfoPtr_Start_Protected_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685190);
		NativeMethodInfoPtr_OnRequestBakeProcesses_Protected_Virtual_New_Void_Dictionary_2_MeshAssetContainer_List_1_MeshFilter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685191);
		NativeMethodInfoPtr_OnDisable_Protected_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685192);
		NativeMethodInfoPtr_Unbake_Public_Virtual_New_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685193);
		NativeMethodInfoPtr_BakeToNavMesh_Private_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685194);
		NativeMethodInfoPtr_OnNavMeshBuildStart_Public_Virtual_Final_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685195);
		NativeMethodInfoPtr_OnNavMeshBuildEnd_Public_Virtual_Final_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685196);
		NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685197);
		NativeMethodInfoPtr_ResampleSplines_Private_List_1_Shape_List_1_Shape_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685198);
		NativeMethodInfoPtr_GetShapesToMeshSettings_Private_ShapesToMeshSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685199);
		NativeMethodInfoPtr_GetValidShapes_Private_List_1_Shape_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685200);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr, 100685201);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233890, XrefRangeEnd = 233898, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnEnable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnable_Protected_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233898, XrefRangeEnd = 233899, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Start()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Start_Protected_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 233929, RefRangeEnd = 233930, XrefRangeStart = 233899, XrefRangeEnd = 233929, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnRequestBakeProcesses(Dictionary<MeshAssetContainer, List<MeshFilter>> bakeProcesses)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)bakeProcesses);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnRequestBakeProcesses_Protected_Virtual_New_Void_Dictionary_2_MeshAssetContainer_List_1_MeshFilter_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233930, XrefRangeEnd = 233936, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnDisable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnDisable_Protected_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233936, XrefRangeEnd = 233944, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void Unbake(bool deleteAsset = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&deleteAsset);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Unbake_Public_Virtual_New_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 233963, RefRangeEnd = 233965, XrefRangeStart = 233944, XrefRangeEnd = 233963, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BakeToNavMesh(int layer, int area)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&layer);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &area;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BakeToNavMesh_Private_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233965, XrefRangeEnd = 233970, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnNavMeshBuildStart()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnNavMeshBuildStart_Public_Virtual_Final_New_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233970, XrefRangeEnd = 233987, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnNavMeshBuildEnd()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnNavMeshBuildEnd_Public_Virtual_Final_New_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 234056, RefRangeEnd = 234059, XrefRangeStart = 233987, XrefRangeEnd = 234056, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void UpdateShapeDisplay(bool fullRefresh = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&fullRefresh);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 234104, RefRangeEnd = 234106, XrefRangeStart = 234059, XrefRangeEnd = 234104, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe List<Shape> ResampleSplines(List<Shape> allShapes)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)allShapes);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResampleSplines_Private_List_1_Shape_List_1_Shape_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Shape>>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 234110, RefRangeEnd = 234112, XrefRangeStart = 234106, XrefRangeEnd = 234110, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ShapeUtils.ShapesToMeshSettings GetShapesToMeshSettings()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr);
		System.IntPtr pointer = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetShapesToMeshSettings_Private_ShapesToMeshSettings_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr);
		Il2CppException.RaiseExceptionIfNecessary(intPtr);
		return new ShapeUtils.ShapesToMeshSettings(pointer);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 234133, RefRangeEnd = 234135, XrefRangeStart = 234112, XrefRangeEnd = 234133, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe List<Shape> GetValidShapes()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetValidShapes_Private_List_1_Shape_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Shape>>(intPtr) : null;
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 234140, RefRangeEnd = 234144, XrefRangeStart = 234135, XrefRangeEnd = 234140, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MeshShapeCreator()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MeshShapeCreator>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MeshShapeCreator(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

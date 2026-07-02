using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Game.Dimensions;

public class D_Obj_Oxygen : D_Obj
{
	[Serializable]
	public class Config : D_ObjConfiguration
	{
		private static readonly IntPtr NativeFieldInfoPtr_cellSize;

		private static readonly IntPtr NativeFieldInfoPtr_maxAmount;

		private static readonly IntPtr NativeFieldInfoPtr_spawnEdgeAdjustMaxDistance;

		private static readonly IntPtr NativeFieldInfoPtr_navCheckRadius;

		private static readonly IntPtr NativeFieldInfoPtr_edgeDistance;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe float cellSize
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellSize);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellSize)) = num;
			}
		}

		public unsafe int maxAmount
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxAmount);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxAmount)) = num;
			}
		}

		public unsafe float spawnEdgeAdjustMaxDistance
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnEdgeAdjustMaxDistance);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnEdgeAdjustMaxDistance)) = num;
			}
		}

		public unsafe float navCheckRadius
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_navCheckRadius);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_navCheckRadius)) = num;
			}
		}

		public unsafe float edgeDistance
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeDistance);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeDistance)) = num;
			}
		}

		static Config()
		{
			Il2CppClassPointerStore<Config>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, "Config");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Config>.NativeClassPtr);
			NativeFieldInfoPtr_cellSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "cellSize");
			NativeFieldInfoPtr_maxAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "maxAmount");
			NativeFieldInfoPtr_spawnEdgeAdjustMaxDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "spawnEdgeAdjustMaxDistance");
			NativeFieldInfoPtr_navCheckRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "navCheckRadius");
			NativeFieldInfoPtr_edgeDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "edgeDistance");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100672962);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121703, XrefRangeEnd = 121704, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Config()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Config>.NativeClassPtr))
		{
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Config(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly IntPtr NativeFieldInfoPtr_config;

	private static readonly IntPtr NativeFieldInfoPtr_objects;

	private static readonly IntPtr NativeFieldInfoPtr_spawnPoints;

	private static readonly IntPtr NativeFieldInfoPtr_startRadius;

	private static readonly IntPtr NativeMethodInfoPtr_get_dObjConfig_Public_Virtual_get_D_ObjConfiguration_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Dimension_Config_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetNavMeshBounds_Private_Bounds_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetSpawnPointsOnNavMesh_Public_List_1_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_TrySpawnObjects_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_IsPositionValid_Private_Boolean_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_SvOnObjectExit_Public_Virtual_Void_GameObject_0;

	private static readonly IntPtr NativeMethodInfoPtr_SvTick_Public_Virtual_Void_Single_0;

	public unsafe Config config
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_config);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Config>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_config)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
		}
	}

	public unsafe List<GameObject> objects
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objects);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<GameObject>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objects)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<Vector3> spawnPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<Vector3>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe float startRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startRadius)) = num;
		}
	}

	public unsafe override D_ObjConfiguration dObjConfig
	{
		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 30135, RefRangeEnd = 30170, XrefRangeStart = 30135, XrefRangeEnd = 30170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_dObjConfig_Public_Virtual_get_D_ObjConfiguration_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<D_ObjConfiguration>(intPtr) : null;
		}
	}

	static D_Obj_Oxygen()
	{
		Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Game.Dimensions", "D_Obj_Oxygen");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr);
		NativeFieldInfoPtr_config = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, "config");
		NativeFieldInfoPtr_objects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, "objects");
		NativeFieldInfoPtr_spawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, "spawnPoints");
		NativeFieldInfoPtr_startRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, "startRadius");
		NativeMethodInfoPtr_get_dObjConfig_Public_Virtual_get_D_ObjConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672954);
		NativeMethodInfoPtr__ctor_Public_Void_Dimension_Config_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672955);
		NativeMethodInfoPtr_GetNavMeshBounds_Private_Bounds_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672956);
		NativeMethodInfoPtr_GetSpawnPointsOnNavMesh_Public_List_1_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672957);
		NativeMethodInfoPtr_TrySpawnObjects_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672958);
		NativeMethodInfoPtr_IsPositionValid_Private_Boolean_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672959);
		NativeMethodInfoPtr_SvOnObjectExit_Public_Virtual_Void_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672960);
		NativeMethodInfoPtr_SvTick_Public_Virtual_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr, 100672961);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121704, XrefRangeEnd = 121716, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe D_Obj_Oxygen(Dimension d, Config config)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<D_Obj_Oxygen>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)d);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Dimension_Config_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121716, XrefRangeEnd = 121719, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Bounds GetNavMeshBounds()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetNavMeshBounds_Private_Bounds_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Bounds*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 121740, RefRangeEnd = 121742, XrefRangeStart = 121719, XrefRangeEnd = 121740, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe List<Vector3> GetSpawnPointsOnNavMesh()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSpawnPointsOnNavMesh_Public_List_1_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<Vector3>>(intPtr) : null;
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 121757, RefRangeEnd = 121761, XrefRangeStart = 121742, XrefRangeEnd = 121757, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TrySpawnObjects()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TrySpawnObjects_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 121772, RefRangeEnd = 121773, XrefRangeStart = 121761, XrefRangeEnd = 121772, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsPositionValid(Vector3 position)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&position);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsPositionValid_Private_Boolean_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121773, XrefRangeEnd = 121781, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SvOnObjectExit(GameObject g)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)g);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SvOnObjectExit_Public_Virtual_Void_GameObject_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121781, XrefRangeEnd = 121794, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SvTick(float fixedDt)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&fixedDt);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SvTick_Public_Virtual_Void_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public D_Obj_Oxygen(IntPtr pointer)
		: base(pointer)
	{
	}
}

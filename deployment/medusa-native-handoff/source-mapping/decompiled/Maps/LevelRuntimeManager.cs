using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppBAPBAP.Entities.HideArea;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Local.Rendering;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Diagnostics;
using Il2CppSystem.Text;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace Il2CppBAPBAP.Maps;

public class LevelRuntimeManager : MonoBehaviour
{
	public class CombineMeshesMat : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_mat;

		private static readonly System.IntPtr NativeFieldInfoPtr_renderingLayerMask;

		private static readonly System.IntPtr NativeFieldInfoPtr_combineInstances;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Material_Int32_List_1_CombineInstance_0;

		public unsafe Material mat
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mat);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mat)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		public unsafe int renderingLayerMask
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderingLayerMask);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderingLayerMask)) = num;
			}
		}

		public unsafe List<CombineInstance> combineInstances
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_combineInstances);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<CombineInstance>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_combineInstances)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		static CombineMeshesMat()
		{
			Il2CppClassPointerStore<CombineMeshesMat>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "CombineMeshesMat");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CombineMeshesMat>.NativeClassPtr);
			NativeFieldInfoPtr_mat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CombineMeshesMat>.NativeClassPtr, "mat");
			NativeFieldInfoPtr_renderingLayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CombineMeshesMat>.NativeClassPtr, "renderingLayerMask");
			NativeFieldInfoPtr_combineInstances = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CombineMeshesMat>.NativeClassPtr, "combineInstances");
			NativeMethodInfoPtr__ctor_Public_Void_Material_Int32_List_1_CombineInstance_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CombineMeshesMat>.NativeClassPtr, 100685606);
		}

		[CallerCount(365)]
		[CachedScanResults(RefRangeStart = 43192, RefRangeEnd = 43557, XrefRangeStart = 43192, XrefRangeEnd = 43557, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CombineMeshesMat(Material mat, int renderingLayerMask, List<CombineInstance> combineInstances)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CombineMeshesMat>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mat);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &renderingLayerMask;
			*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)combineInstances);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Material_Int32_List_1_CombineInstance_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CombineMeshesMat(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CombineInstanceData : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_instance;

		private static readonly System.IntPtr NativeFieldInfoPtr_matrix;

		private static readonly System.IntPtr NativeFieldInfoPtr_renderingLayerMask;

		private static readonly System.IntPtr NativeFieldInfoPtr_shadowCastingMode;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_GameObject_Matrix4x4_Int32_ShadowCastingMode_0;

		public unsafe GameObject instance
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instance);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instance)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe Matrix4x4 matrix
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matrix);
				return *(Matrix4x4*)num;
			}
			set
			{
				*(Matrix4x4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matrix)) = matrix4x;
			}
		}

		public unsafe int renderingLayerMask
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderingLayerMask);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderingLayerMask)) = num;
			}
		}

		public unsafe ShadowCastingMode shadowCastingMode
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shadowCastingMode);
				return *(ShadowCastingMode*)num;
			}
			set
			{
				*(ShadowCastingMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shadowCastingMode)) = shadowCastingMode;
			}
		}

		static CombineInstanceData()
		{
			Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "CombineInstanceData");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr);
			NativeFieldInfoPtr_instance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr, "instance");
			NativeFieldInfoPtr_matrix = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr, "matrix");
			NativeFieldInfoPtr_renderingLayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr, "renderingLayerMask");
			NativeFieldInfoPtr_shadowCastingMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr, "shadowCastingMode");
			NativeMethodInfoPtr__ctor_Public_Void_GameObject_Matrix4x4_Int32_ShadowCastingMode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr, 100685607);
		}

		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 237179, RefRangeEnd = 237182, XrefRangeStart = 237178, XrefRangeEnd = 237179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CombineInstanceData(GameObject instance, Matrix4x4 meshMatrix, int renderingLayerMask, ShadowCastingMode shadowCastingMode)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CombineInstanceData>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[4];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instance);
			*(Matrix4x4**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &meshMatrix;
			*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &renderingLayerMask;
			*(ShadowCastingMode**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &shadowCastingMode;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_GameObject_Matrix4x4_Int32_ShadowCastingMode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CombineInstanceData(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	[ObfuscatedName("BAPBAP.Maps.LevelRuntimeManager+<>c")]
	public sealed class __c : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___9;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__128_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__BakeNavMesh_b__128_0_Internal_IEnumerable_1_IGeneratedLevelAsset_GameObject_0;

		public unsafe static __c __9
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c));
			}
		}

		public unsafe static Il2CppSystem.Func<GameObject, IEnumerable<IGeneratedLevelAsset>> __9__128_0
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__128_0, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<GameObject, IEnumerable<IGeneratedLevelAsset>>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__128_0, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		static __c()
		{
			Il2CppClassPointerStore<__c>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "<>c");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c>.NativeClassPtr);
			NativeFieldInfoPtr___9 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9");
			NativeFieldInfoPtr___9__128_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__128_0");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685609);
			NativeMethodInfoPtr__BakeNavMesh_b__128_0_Internal_IEnumerable_1_IGeneratedLevelAsset_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685610);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237182, XrefRangeEnd = 237184, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe IEnumerable<IGeneratedLevelAsset> _BakeNavMesh_b__128_0(GameObject go)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)go);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__BakeNavMesh_b__128_0_Internal_IEnumerable_1_IGeneratedLevelAsset_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<IEnumerable<IGeneratedLevelAsset>>(intPtr) : null;
		}

		public __c(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Maps.LevelRuntimeManager+<>c__DisplayClass136_0")]
	public sealed class __c__DisplayClass136_0 : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_meshes;

		public unsafe List<CombineInstanceData> meshes
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_meshes);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<CombineInstanceData>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_meshes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		static __c__DisplayClass136_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass136_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "<>c__DisplayClass136_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass136_0>.NativeClassPtr);
			NativeFieldInfoPtr_meshes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass136_0>.NativeClassPtr, "meshes");
		}

		public __c__DisplayClass136_0(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public __c__DisplayClass136_0()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass136_0>.NativeClassPtr))
		{
		}
	}

	[ObfuscatedName("BAPBAP.Maps.LevelRuntimeManager+<>c__DisplayClass86_0")]
	public sealed class __c__DisplayClass86_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_groupId;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ProcessLevelGameObjects_b__3_Internal_Void_Int32_Vector2Int_CombineInstanceData_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ProcessLevelGameObjects_b__4_Internal_Void_Int32_Vector2Int_GameObject_0;

		public unsafe int groupId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groupId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groupId)) = num;
			}
		}

		public unsafe LevelRuntimeManager __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelRuntimeManager>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelRuntimeManager));
			}
		}

		static __c__DisplayClass86_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "<>c__DisplayClass86_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr);
			NativeFieldInfoPtr_groupId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr, "groupId");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr, "<>4__this");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr, 100685611);
			NativeMethodInfoPtr__ProcessLevelGameObjects_b__3_Internal_Void_Int32_Vector2Int_CombineInstanceData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr, 100685612);
			NativeMethodInfoPtr__ProcessLevelGameObjects_b__4_Internal_Void_Int32_Vector2Int_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr, 100685613);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass86_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass86_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237184, XrefRangeEnd = 237194, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _ProcessLevelGameObjects_b__3(int lvl, Vector2Int cPos, CombineInstanceData ci)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&lvl);
			*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &cPos;
			*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ci);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ProcessLevelGameObjects_b__3_Internal_Void_Int32_Vector2Int_CombineInstanceData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237194, XrefRangeEnd = 237204, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _ProcessLevelGameObjects_b__4(int lvl, Vector2Int cPos, GameObject obj)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&lvl);
			*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &cPos;
			*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ProcessLevelGameObjects_b__4_Internal_Void_Int32_Vector2Int_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass86_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Maps.LevelRuntimeManager+<LoadLevelCoroutine>d__77")]
	public sealed class _LoadLevelCoroutine_d__77 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___1__state;

		private static readonly System.IntPtr NativeFieldInfoPtr___2__current;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		private static readonly System.IntPtr NativeFieldInfoPtr_levelName;

		private static readonly System.IntPtr NativeFieldInfoPtr_isServerOnly;

		private static readonly System.IntPtr NativeFieldInfoPtr_isClientOnly;

		private static readonly System.IntPtr NativeFieldInfoPtr__svData_5__2;

		private static readonly System.IntPtr NativeFieldInfoPtr__clData_5__3;

		private static readonly System.IntPtr NativeFieldInfoPtr__dirPath_5__4;

		private static readonly System.IntPtr NativeFieldInfoPtr__svRequest_5__5;

		private static readonly System.IntPtr NativeFieldInfoPtr__clRequest_5__6;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Int32_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_IDisposable_Dispose_Private_Virtual_Final_New_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_MoveNext_Private_Virtual_Final_New_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_Collections_Generic_IEnumerator_System_Object__get_Current_Private_Virtual_Final_New_get_Object_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_Collections_IEnumerator_Reset_Private_Virtual_Final_New_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_System_Collections_IEnumerator_get_Current_Private_Virtual_Final_New_get_Object_0;

		public unsafe int __1__state
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___1__state);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___1__state)) = num;
			}
		}

		public unsafe Il2CppSystem.Object __2__current
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___2__current);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Object>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___2__current)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj));
			}
		}

		public unsafe LevelRuntimeManager __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelRuntimeManager>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelRuntimeManager));
			}
		}

		public unsafe string levelName
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelName);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelName)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe bool isServerOnly
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isServerOnly);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isServerOnly)) = flag;
			}
		}

		public unsafe bool isClientOnly
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isClientOnly);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isClientOnly)) = flag;
			}
		}

		public unsafe SerializedLevelHolder _svData_5__2
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__svData_5__2);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SerializedLevelHolder>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__svData_5__2)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedLevelHolder));
			}
		}

		public unsafe SerializedLevelHolder _clData_5__3
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clData_5__3);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SerializedLevelHolder>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clData_5__3)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedLevelHolder));
			}
		}

		public unsafe string _dirPath_5__4
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dirPath_5__4);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dirPath_5__4)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe ResourceRequest _svRequest_5__5
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__svRequest_5__5);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ResourceRequest>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__svRequest_5__5)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)resourceRequest));
			}
		}

		public unsafe ResourceRequest _clRequest_5__6
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clRequest_5__6);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ResourceRequest>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clRequest_5__6)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)resourceRequest));
			}
		}

		public unsafe virtual Il2CppSystem.Object System_002ECollections_002EGeneric_002EIEnumerator_003CSystem_002EObject_003E_002ECurrent
		{
			[CallerCount(140)]
			[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			get
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_Collections_Generic_IEnumerator_System_Object__get_Current_Private_Virtual_Final_New_get_Object_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Object>(intPtr) : null;
			}
		}

		public unsafe virtual Il2CppSystem.Object System_002ECollections_002EIEnumerator_002ECurrent
		{
			[CallerCount(140)]
			[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			get
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_Collections_IEnumerator_get_Current_Private_Virtual_Final_New_get_Object_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Object>(intPtr) : null;
			}
		}

		static _LoadLevelCoroutine_d__77()
		{
			Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "<LoadLevelCoroutine>d__77");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr);
			NativeFieldInfoPtr___1__state = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<>1__state");
			NativeFieldInfoPtr___2__current = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<>2__current");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<>4__this");
			NativeFieldInfoPtr_levelName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "levelName");
			NativeFieldInfoPtr_isServerOnly = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "isServerOnly");
			NativeFieldInfoPtr_isClientOnly = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "isClientOnly");
			NativeFieldInfoPtr__svData_5__2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<svData>5__2");
			NativeFieldInfoPtr__clData_5__3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<clData>5__3");
			NativeFieldInfoPtr__dirPath_5__4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<dirPath>5__4");
			NativeFieldInfoPtr__svRequest_5__5 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<svRequest>5__5");
			NativeFieldInfoPtr__clRequest_5__6 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, "<clRequest>5__6");
			NativeMethodInfoPtr__ctor_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, 100685614);
			NativeMethodInfoPtr_System_IDisposable_Dispose_Private_Virtual_Final_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, 100685615);
			NativeMethodInfoPtr_MoveNext_Private_Virtual_Final_New_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, 100685616);
			NativeMethodInfoPtr_System_Collections_Generic_IEnumerator_System_Object__get_Current_Private_Virtual_Final_New_get_Object_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, 100685617);
			NativeMethodInfoPtr_System_Collections_IEnumerator_Reset_Private_Virtual_Final_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, 100685618);
			NativeMethodInfoPtr_System_Collections_IEnumerator_get_Current_Private_Virtual_Final_New_get_Object_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr, 100685619);
		}

		[CallerCount(224)]
		[CachedScanResults(RefRangeStart = 23334, RefRangeEnd = 23558, XrefRangeStart = 23334, XrefRangeEnd = 23558, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe _LoadLevelCoroutine_d__77(int _003C_003E1__state)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<_LoadLevelCoroutine_d__77>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&_003C_003E1__state);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(17738)]
		[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual void System_IDisposable_Dispose()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_IDisposable_Dispose_Private_Virtual_Final_New_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237204, XrefRangeEnd = 237239, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual bool MoveNext()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_MoveNext_Private_Virtual_Final_New_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237239, XrefRangeEnd = 237244, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe virtual void System_Collections_IEnumerator_Reset()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_System_Collections_IEnumerator_Reset_Private_Virtual_Final_New_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public _LoadLevelCoroutine_d__77(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_levelDynamicLoad;

	private static readonly System.IntPtr NativeFieldInfoPtr_ceilingGroupManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_navMeshSurface;

	private static readonly System.IntPtr NativeFieldInfoPtr_loadMapDynamic;

	private static readonly System.IntPtr NativeFieldInfoPtr_loadDynamicOnHost;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunkSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxChunkLevels;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunkObjBoundsMargin;

	private static readonly System.IntPtr NativeFieldInfoPtr_simplifiedColHeight;

	private static readonly System.IntPtr NativeFieldInfoPtr_tileHideAreaColliderShrinkAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultRenderingLayerMask;

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultShadowCastingMode;

	private static readonly System.IntPtr NativeFieldInfoPtr_assetPalette;

	private static readonly System.IntPtr NativeFieldInfoPtr_distortMaterial;

	private static readonly System.IntPtr NativeFieldInfoPtr_hideAreaGroupPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_tallBushPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_instanceRenderer;

	private static readonly System.IntPtr NativeFieldInfoPtr_fowContainerPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_fowBoxMesh;

	private static readonly System.IntPtr NativeFieldInfoPtr_fowCylinderMesh;

	private static readonly System.IntPtr NativeFieldInfoPtr_levelSettings;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapSizeHalf;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapHideAreas;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapEntities;

	private static readonly System.IntPtr NativeFieldInfoPtr_spawnPoints;

	private static readonly System.IntPtr NativeFieldInfoPtr_dimensionSpawnPoints;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunkLevelCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunkFirstLvlGridSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunkLevels;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeMapToMapUnitFactor;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeMapSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_ambienceMapToMapUnitFactor;

	private static readonly System.IntPtr NativeFieldInfoPtr_ambienceMapSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_surfaceMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_ambienceMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_ceilingGroupMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_obstacleMask;

	private static readonly System.IntPtr NativeFieldInfoPtr_obstaclesLayer;

	private static readonly System.IntPtr NativeFieldInfoPtr_obstaclesNoFOWLayer;

	private static readonly System.IntPtr NativeFieldInfoPtr_lowObstaclesLayer;

	private static readonly System.IntPtr NativeFieldInfoPtr_halfsimplifiedColHeight;

	private static readonly System.IntPtr NativeFieldInfoPtr_bakedMeshes;

	private static readonly System.IntPtr NativeFieldInfoPtr_isLoading;

	private static readonly System.IntPtr NativeFieldInfoPtr_OnLevelRuntimeManagerLoaded;

	private static readonly System.IntPtr NativeFieldInfoPtr_stopwatch;

	private static readonly System.IntPtr NativeFieldInfoPtr_stopwatchAll;

	private static readonly System.IntPtr NativeFieldInfoPtr_step;

	private static readonly System.IntPtr NativeFieldInfoPtr_buildMapData;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunkDebugData;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunkDebugData2;

	private static readonly System.IntPtr NativeFieldInfoPtr_loadingLogs;

	private static readonly System.IntPtr NativeFieldInfoPtr_loadingMeshesLogs;

	private static readonly System.IntPtr NativeFieldInfoPtr_LocalInstance;

	private static readonly System.IntPtr NativeFieldInfoPtr_combineDebugData;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_IsLoading_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_LoadMapDynamic_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_BaseChunkSize_Public_get_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_ChunkFirstLvlGridSize_Public_get_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_ChunkLevelCount_Public_get_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_ChunkLevels_Public_get_Il2CppReferenceArray_1_MapChunkLevels_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_SurfaceMap_Public_get_Il2CppReferenceArray_1_Il2CppStructArray_1_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_AmbienceMap_Public_get_Il2CppReferenceArray_1_Il2CppStructArray_1_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_MapSettings_Public_get_MapSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Initialize_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLevelMMCache_Public_Static_Boolean_String_Int32_byref_LevelMMCache_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadLevel_Public_Void_String_Int32_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadLevelCoroutine_Private_IEnumerator_String_Int32_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnLevel_Private_Void_String_Boolean_Boolean_SerializedLevelHolder_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeNavMeshPreBake_Public_Void_MapSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PreBakeMapChunksColliders_Public_GameObject_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BakeStaticChunkColliders_Private_Void_MapChunk_Transform_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ProcessMapEntities_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeMapData_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildMapData_Private_Void_SerializedLevelHolder_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ProcessLevelTiles_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ProcessLevelGameObjects_Private_Void_SerializedLevelHolder_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ProcessMapRootTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_Action_3_Int32_Vector2Int_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RecursiveProcessStaticTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ProcessStaticTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildHideAreaData_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBakedColliders_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabCombineInstances_Private_List_1_CombineInstanceData_PrefabConfig_Vector3_Vector3_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetChunkGridLevel_Private_Int32_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ContainsNonStaticChildren_Private_Boolean_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsStatic_Public_Static_Boolean_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildSurfaceMap_Private_Void_SerializedLevelHolder_Texture2D_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildCeilingGroupMap_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildAmbienceMap_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildBiomeAndSplatMap_Private_Texture2D_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetSpawnPointArrayV2_Public_Static_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetSpawnPointArray_Public_Static_Il2CppStructArray_1_Vector3_Il2CppReferenceArray_1_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDimensionSpawnPointArrayV2_Public_Static_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDimensionSpawnPointArray_Public_Static_Il2CppStructArray_1_Vector3_Il2CppReferenceArray_1_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AssignEntityData_Public_Void_GameObject_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AssignEntityData_Public_Void_GameObject_IEntityDataProperty_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BakeAllMapChunks_Private_Void_Il2CppReferenceArray_1_MapChunkLevels_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadChunk_Public_GameObject_Int32_Vector2Int_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TryGetCIListByMatAndMask_Private_Boolean_List_1_CombineMeshesMat_Material_Int32_byref_List_1_CombineInstance_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BakeChunkMeshes_Private_Void_MapChunk_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCombineMeshMatList_Private_Il2CppReferenceArray_1_CombineMeshesMat_List_1_CombineInstanceData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CombineMeshes_Private_GameObject_Il2CppReferenceArray_1_CombineMeshesMat_ShadowCastingMode_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OptimizeMesh_Private_Void_Mesh_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InstantiateStaticChunkColliders_Private_Void_MapChunk_Transform_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateStaticLayerColliders_Private_Boolean_List_1_CombineInstanceData_List_1_TiledColliderInstance_LayerMask_byref_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateStaticCollidersFromInstance_Private_Void_GameObject_Vector3_Vector3_Vector3_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateSimplifiedCollider_Private_Void_BoundsData_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedColliderObj_Private_Transform_Int32_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetNewColliderObj_Private_Transform_Vector3_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateCapsuleCollider_Private_Void_CapsuleCollider_Vector2_Quaternion_Vector3_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InstantiateCeilingGroups_Private_Void_MapChunk_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateInstantiatedObjects_Private_Void_MapChunk_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateInstantiatedObject_Private_GameObject_GameObject_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateFloorCollider_Public_Void_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeNavMesh_Private_Void_String_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BakeNavMesh_Public_NavMeshData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClearNavMeshes_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeInstanceRenderer_Private_Void_String_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateAllHideAreaGroups_Private_Void_Il2CppReferenceArray_1_HideAreaGroup_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateHideArea_Public_Transform_HideAreaGroup_Boolean_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateTileHideArea_Private_Void_HideArea_Il2CppReferenceArray_1_TilePrefabInstance_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GenerateHideAreaMesh_Private_Mesh_Il2CppReferenceArray_1_TilePrefabInstance_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GenerateHideAreaColliders_Private_Void_Il2CppReferenceArray_1_TilePrefabInstance_HideArea_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateHolderHideArea_Private_Void_HideArea_LevelHideAreaHolder_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDestroy_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CleanUpLevel_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildNavMeshWithinBounds_Public_Void_Bounds_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateNavMeshBounds_Public_Void_Bounds_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TriggerDinamicMapFullLoad_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleBiomeMap_Private_Int32_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleSurfaceMap_Private_Byte_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleCeilingGroupMap_Private_Int32_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleAmbience_Public_AmbienceId_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleAmbience_Public_AmbienceId_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetSurfaceId_Public_Int32_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentBiomeId_Public_Int32_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentBiomeName_Public_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCeilingGroupId_Public_Int32_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetGroundSurfaceIdFromBiomeId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBushSurfaceIdFromBiomeId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMapNavMeshPosition_Public_Vector3_Vector3_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMapNavMeshClosestEdge_Public_Vector3_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMapNavMeshPositionRadius_Public_Vector3_Vector3_Single_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnCeilingGroupEnter_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnCeilingGroupExit_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateMapWaterOuterEdgesObjects_Private_Void_SerializedLevelHolder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_2_Private_Void_Int32_Vector2Int_CombineInstanceData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_0_Private_Void_Int32_Vector2Int_CombineInstanceData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_1_Private_Void_Int32_Vector2Int_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Method_Private_Void_Transform_byref___c__DisplayClass136_0_PDM_0;

	public unsafe LevelDynamicLoadProcess levelDynamicLoad
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelDynamicLoad);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelDynamicLoadProcess>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelDynamicLoad)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelDynamicLoadProcess));
		}
	}

	public unsafe CeilingGroupManager ceilingGroupManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingGroupManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CeilingGroupManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingGroupManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ceilingGroupManager));
		}
	}

	public unsafe NavMeshSurface navMeshSurface
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_navMeshSurface);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NavMeshSurface>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_navMeshSurface)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)navMeshSurface));
		}
	}

	public unsafe bool loadMapDynamic
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadMapDynamic);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadMapDynamic)) = flag;
		}
	}

	public unsafe bool loadDynamicOnHost
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadDynamicOnHost);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadDynamicOnHost)) = flag;
		}
	}

	public unsafe int chunkSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkSize)) = num;
		}
	}

	public unsafe int maxChunkLevels
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxChunkLevels);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxChunkLevels)) = num;
		}
	}

	public unsafe Vector2 chunkObjBoundsMargin
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkObjBoundsMargin);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkObjBoundsMargin)) = vector;
		}
	}

	public unsafe float simplifiedColHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_simplifiedColHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_simplifiedColHeight)) = num;
		}
	}

	public unsafe float tileHideAreaColliderShrinkAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tileHideAreaColliderShrinkAmount);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tileHideAreaColliderShrinkAmount)) = num;
		}
	}

	public unsafe int defaultRenderingLayerMask
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultRenderingLayerMask);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultRenderingLayerMask)) = num;
		}
	}

	public unsafe ShadowCastingMode defaultShadowCastingMode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultShadowCastingMode);
			return *(ShadowCastingMode*)num;
		}
		set
		{
			*(ShadowCastingMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultShadowCastingMode)) = shadowCastingMode;
		}
	}

	public unsafe AssetPalette assetPalette
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assetPalette);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assetPalette)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette));
		}
	}

	public unsafe Material distortMaterial
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distortMaterial);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distortMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
		}
	}

	public unsafe GameObject hideAreaGroupPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideAreaGroupPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideAreaGroupPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject tallBushPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tallBushPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tallBushPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe MeshInstanceRenderer instanceRenderer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instanceRenderer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshInstanceRenderer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instanceRenderer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)meshInstanceRenderer));
		}
	}

	public unsafe GameObject fowContainerPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowContainerPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowContainerPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Mesh fowBoxMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowBoxMesh);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowBoxMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe Mesh fowCylinderMesh
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowCylinderMesh);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowCylinderMesh)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh));
		}
	}

	public unsafe MapSettings levelSettings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelSettings);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MapSettings>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mapSettings));
		}
	}

	public unsafe Vector2Int mapSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapSize);
			return *(Vector2Int*)num;
		}
		set
		{
			*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapSize)) = vector2Int;
		}
	}

	public unsafe Vector2Int mapSizeHalf
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapSizeHalf);
			return *(Vector2Int*)num;
		}
		set
		{
			*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapSizeHalf)) = vector2Int;
		}
	}

	public unsafe Il2CppReferenceArray<HideAreaGroup> mapHideAreas
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapHideAreas);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<HideAreaGroup>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapHideAreas)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<PrefabConfig> mapEntities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapEntities);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<PrefabConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapEntities)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Vector3> spawnPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector3>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Vector3> dimensionSpawnPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPoints);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector3>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe int chunkLevelCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkLevelCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkLevelCount)) = num;
		}
	}

	public unsafe Vector2Int chunkFirstLvlGridSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkFirstLvlGridSize);
			return *(Vector2Int*)num;
		}
		set
		{
			*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkFirstLvlGridSize)) = vector2Int;
		}
	}

	public unsafe Il2CppReferenceArray<MapChunkLevels> chunkLevels
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkLevels);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<MapChunkLevels>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkLevels)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe float biomeMapToMapUnitFactor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapToMapUnitFactor);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapToMapUnitFactor)) = num;
		}
	}

	public unsafe Vector2Int biomeMapSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapSize);
			return *(Vector2Int*)num;
		}
		set
		{
			*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapSize)) = vector2Int;
		}
	}

	public unsafe float ambienceMapToMapUnitFactor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMapToMapUnitFactor);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMapToMapUnitFactor)) = num;
		}
	}

	public unsafe Vector2Int ambienceMapSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMapSize);
			return *(Vector2Int*)num;
		}
		set
		{
			*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMapSize)) = vector2Int;
		}
	}

	public unsafe Il2CppReferenceArray<Il2CppStructArray<byte>> biomeMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppStructArray<byte>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Il2CppStructArray<byte>> surfaceMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppStructArray<byte>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Il2CppStructArray<byte>> ambienceMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppStructArray<byte>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Il2CppStructArray<int>> ceilingGroupMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingGroupMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppStructArray<int>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingGroupMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe LayerMask obstacleMask
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleMask);
			return *(LayerMask*)num;
		}
		set
		{
			*(LayerMask*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleMask)) = layerMask;
		}
	}

	public unsafe int obstaclesLayer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesLayer);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesLayer)) = num;
		}
	}

	public unsafe int obstaclesNoFOWLayer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesNoFOWLayer);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesNoFOWLayer)) = num;
		}
	}

	public unsafe int lowObstaclesLayer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lowObstaclesLayer);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lowObstaclesLayer)) = num;
		}
	}

	public unsafe float halfsimplifiedColHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_halfsimplifiedColHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_halfsimplifiedColHeight)) = num;
		}
	}

	public unsafe List<Mesh> bakedMeshes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakedMeshes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Mesh>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakedMeshes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe bool isLoading
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLoading);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLoading)) = flag;
		}
	}

	public unsafe static Il2CppSystem.Action<bool, Vector2Int> OnLevelRuntimeManagerLoaded
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OnLevelRuntimeManagerLoaded, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<bool, Vector2Int>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OnLevelRuntimeManagerLoaded, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe Stopwatch stopwatch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stopwatch);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Stopwatch>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stopwatch)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stopwatch));
		}
	}

	public unsafe Stopwatch stopwatchAll
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stopwatchAll);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Stopwatch>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stopwatchAll)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stopwatch));
		}
	}

	public unsafe int step
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_step);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_step)) = num;
		}
	}

	public unsafe StringBuilder buildMapData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buildMapData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<StringBuilder>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buildMapData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stringBuilder));
		}
	}

	public unsafe StringBuilder chunkDebugData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkDebugData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<StringBuilder>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkDebugData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stringBuilder));
		}
	}

	public unsafe StringBuilder chunkDebugData2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkDebugData2);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<StringBuilder>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkDebugData2)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stringBuilder));
		}
	}

	public unsafe bool loadingLogs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadingLogs);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadingLogs)) = flag;
		}
	}

	public unsafe bool loadingMeshesLogs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadingMeshesLogs);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadingMeshesLogs)) = flag;
		}
	}

	public unsafe static LevelRuntimeManager LocalInstance
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalInstance, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelRuntimeManager>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalInstance, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelRuntimeManager));
		}
	}

	public unsafe StringBuilder combineDebugData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_combineDebugData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<StringBuilder>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_combineDebugData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stringBuilder));
		}
	}

	public unsafe bool IsLoading
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_IsLoading_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool LoadMapDynamic
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_LoadMapDynamic_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe int BaseChunkSize
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 37701, RefRangeEnd = 37703, XrefRangeStart = 37701, XrefRangeEnd = 37703, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_BaseChunkSize_Public_get_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe Vector2Int ChunkFirstLvlGridSize
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_ChunkFirstLvlGridSize_Public_get_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe int ChunkLevelCount
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_ChunkLevelCount_Public_get_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe Il2CppReferenceArray<MapChunkLevels> ChunkLevels
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_ChunkLevels_Public_get_Il2CppReferenceArray_1_MapChunkLevels_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<MapChunkLevels>>(intPtr) : null;
		}
	}

	public unsafe Il2CppReferenceArray<Il2CppStructArray<byte>> SurfaceMap
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_SurfaceMap_Public_get_Il2CppReferenceArray_1_Il2CppStructArray_1_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppStructArray<byte>>>(intPtr) : null;
		}
	}

	public unsafe Il2CppReferenceArray<Il2CppStructArray<byte>> AmbienceMap
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AmbienceMap_Public_get_Il2CppReferenceArray_1_Il2CppStructArray_1_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppStructArray<byte>>>(intPtr) : null;
		}
	}

	public unsafe MapSettings MapSettings
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 100379, RefRangeEnd = 100380, XrefRangeStart = 100379, XrefRangeEnd = 100380, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_MapSettings_Public_get_MapSettings_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MapSettings>(intPtr) : null;
		}
	}

	static LevelRuntimeManager()
	{
		Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "LevelRuntimeManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr);
		NativeFieldInfoPtr_levelDynamicLoad = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "levelDynamicLoad");
		NativeFieldInfoPtr_ceilingGroupManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "ceilingGroupManager");
		NativeFieldInfoPtr_navMeshSurface = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "navMeshSurface");
		NativeFieldInfoPtr_loadMapDynamic = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "loadMapDynamic");
		NativeFieldInfoPtr_loadDynamicOnHost = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "loadDynamicOnHost");
		NativeFieldInfoPtr_chunkSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "chunkSize");
		NativeFieldInfoPtr_maxChunkLevels = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "maxChunkLevels");
		NativeFieldInfoPtr_chunkObjBoundsMargin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "chunkObjBoundsMargin");
		NativeFieldInfoPtr_simplifiedColHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "simplifiedColHeight");
		NativeFieldInfoPtr_tileHideAreaColliderShrinkAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "tileHideAreaColliderShrinkAmount");
		NativeFieldInfoPtr_defaultRenderingLayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "defaultRenderingLayerMask");
		NativeFieldInfoPtr_defaultShadowCastingMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "defaultShadowCastingMode");
		NativeFieldInfoPtr_assetPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "assetPalette");
		NativeFieldInfoPtr_distortMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "distortMaterial");
		NativeFieldInfoPtr_hideAreaGroupPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "hideAreaGroupPrefab");
		NativeFieldInfoPtr_tallBushPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "tallBushPrefab");
		NativeFieldInfoPtr_instanceRenderer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "instanceRenderer");
		NativeFieldInfoPtr_fowContainerPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "fowContainerPrefab");
		NativeFieldInfoPtr_fowBoxMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "fowBoxMesh");
		NativeFieldInfoPtr_fowCylinderMesh = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "fowCylinderMesh");
		NativeFieldInfoPtr_levelSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "levelSettings");
		NativeFieldInfoPtr_mapSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "mapSize");
		NativeFieldInfoPtr_mapSizeHalf = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "mapSizeHalf");
		NativeFieldInfoPtr_mapHideAreas = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "mapHideAreas");
		NativeFieldInfoPtr_mapEntities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "mapEntities");
		NativeFieldInfoPtr_spawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "spawnPoints");
		NativeFieldInfoPtr_dimensionSpawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "dimensionSpawnPoints");
		NativeFieldInfoPtr_chunkLevelCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "chunkLevelCount");
		NativeFieldInfoPtr_chunkFirstLvlGridSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "chunkFirstLvlGridSize");
		NativeFieldInfoPtr_chunkLevels = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "chunkLevels");
		NativeFieldInfoPtr_biomeMapToMapUnitFactor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "biomeMapToMapUnitFactor");
		NativeFieldInfoPtr_biomeMapSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "biomeMapSize");
		NativeFieldInfoPtr_ambienceMapToMapUnitFactor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "ambienceMapToMapUnitFactor");
		NativeFieldInfoPtr_ambienceMapSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "ambienceMapSize");
		NativeFieldInfoPtr_biomeMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "biomeMap");
		NativeFieldInfoPtr_surfaceMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "surfaceMap");
		NativeFieldInfoPtr_ambienceMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "ambienceMap");
		NativeFieldInfoPtr_ceilingGroupMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "ceilingGroupMap");
		NativeFieldInfoPtr_obstacleMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "obstacleMask");
		NativeFieldInfoPtr_obstaclesLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "obstaclesLayer");
		NativeFieldInfoPtr_obstaclesNoFOWLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "obstaclesNoFOWLayer");
		NativeFieldInfoPtr_lowObstaclesLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "lowObstaclesLayer");
		NativeFieldInfoPtr_halfsimplifiedColHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "halfsimplifiedColHeight");
		NativeFieldInfoPtr_bakedMeshes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "bakedMeshes");
		NativeFieldInfoPtr_isLoading = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "isLoading");
		NativeFieldInfoPtr_OnLevelRuntimeManagerLoaded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "OnLevelRuntimeManagerLoaded");
		NativeFieldInfoPtr_stopwatch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "stopwatch");
		NativeFieldInfoPtr_stopwatchAll = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "stopwatchAll");
		NativeFieldInfoPtr_step = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "step");
		NativeFieldInfoPtr_buildMapData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "buildMapData");
		NativeFieldInfoPtr_chunkDebugData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "chunkDebugData");
		NativeFieldInfoPtr_chunkDebugData2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "chunkDebugData2");
		NativeFieldInfoPtr_loadingLogs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "loadingLogs");
		NativeFieldInfoPtr_loadingMeshesLogs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "loadingMeshesLogs");
		NativeFieldInfoPtr_LocalInstance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "LocalInstance");
		NativeFieldInfoPtr_combineDebugData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, "combineDebugData");
		NativeMethodInfoPtr_get_IsLoading_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685509);
		NativeMethodInfoPtr_get_LoadMapDynamic_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685510);
		NativeMethodInfoPtr_get_BaseChunkSize_Public_get_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685511);
		NativeMethodInfoPtr_get_ChunkFirstLvlGridSize_Public_get_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685512);
		NativeMethodInfoPtr_get_ChunkLevelCount_Public_get_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685513);
		NativeMethodInfoPtr_get_ChunkLevels_Public_get_Il2CppReferenceArray_1_MapChunkLevels_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685514);
		NativeMethodInfoPtr_get_SurfaceMap_Public_get_Il2CppReferenceArray_1_Il2CppStructArray_1_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685515);
		NativeMethodInfoPtr_get_AmbienceMap_Public_get_Il2CppReferenceArray_1_Il2CppStructArray_1_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685516);
		NativeMethodInfoPtr_get_MapSettings_Public_get_MapSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685517);
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685518);
		NativeMethodInfoPtr_Initialize_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685519);
		NativeMethodInfoPtr_GetLevelMMCache_Public_Static_Boolean_String_Int32_byref_LevelMMCache_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685520);
		NativeMethodInfoPtr_LoadLevel_Public_Void_String_Int32_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685521);
		NativeMethodInfoPtr_LoadLevelCoroutine_Private_IEnumerator_String_Int32_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685522);
		NativeMethodInfoPtr_SpawnLevel_Private_Void_String_Boolean_Boolean_SerializedLevelHolder_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685523);
		NativeMethodInfoPtr_InitializeNavMeshPreBake_Public_Void_MapSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685524);
		NativeMethodInfoPtr_PreBakeMapChunksColliders_Public_GameObject_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685525);
		NativeMethodInfoPtr_BakeStaticChunkColliders_Private_Void_MapChunk_Transform_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685526);
		NativeMethodInfoPtr_ProcessMapEntities_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685527);
		NativeMethodInfoPtr_InitializeMapData_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685528);
		NativeMethodInfoPtr_BuildMapData_Private_Void_SerializedLevelHolder_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685529);
		NativeMethodInfoPtr_ProcessLevelTiles_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685530);
		NativeMethodInfoPtr_ProcessLevelGameObjects_Private_Void_SerializedLevelHolder_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685531);
		NativeMethodInfoPtr_ProcessMapRootTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_Action_3_Int32_Vector2Int_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685532);
		NativeMethodInfoPtr_RecursiveProcessStaticTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685533);
		NativeMethodInfoPtr_ProcessStaticTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685534);
		NativeMethodInfoPtr_BuildHideAreaData_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685535);
		NativeMethodInfoPtr_GetBakedColliders_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685536);
		NativeMethodInfoPtr_GetPrefabCombineInstances_Private_List_1_CombineInstanceData_PrefabConfig_Vector3_Vector3_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685537);
		NativeMethodInfoPtr_GetChunkGridLevel_Private_Int32_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685538);
		NativeMethodInfoPtr_ContainsNonStaticChildren_Private_Boolean_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685539);
		NativeMethodInfoPtr_IsStatic_Public_Static_Boolean_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685540);
		NativeMethodInfoPtr_BuildSurfaceMap_Private_Void_SerializedLevelHolder_Texture2D_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685541);
		NativeMethodInfoPtr_BuildCeilingGroupMap_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685542);
		NativeMethodInfoPtr_BuildAmbienceMap_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685543);
		NativeMethodInfoPtr_BuildBiomeAndSplatMap_Private_Texture2D_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685544);
		NativeMethodInfoPtr_GetSpawnPointArrayV2_Public_Static_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685545);
		NativeMethodInfoPtr_GetSpawnPointArray_Public_Static_Il2CppStructArray_1_Vector3_Il2CppReferenceArray_1_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685546);
		NativeMethodInfoPtr_GetDimensionSpawnPointArrayV2_Public_Static_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685547);
		NativeMethodInfoPtr_GetDimensionSpawnPointArray_Public_Static_Il2CppStructArray_1_Vector3_Il2CppReferenceArray_1_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685548);
		NativeMethodInfoPtr_AssignEntityData_Public_Void_GameObject_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685549);
		NativeMethodInfoPtr_AssignEntityData_Public_Void_GameObject_IEntityDataProperty_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685550);
		NativeMethodInfoPtr_BakeAllMapChunks_Private_Void_Il2CppReferenceArray_1_MapChunkLevels_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685551);
		NativeMethodInfoPtr_LoadChunk_Public_GameObject_Int32_Vector2Int_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685552);
		NativeMethodInfoPtr_TryGetCIListByMatAndMask_Private_Boolean_List_1_CombineMeshesMat_Material_Int32_byref_List_1_CombineInstance_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685553);
		NativeMethodInfoPtr_BakeChunkMeshes_Private_Void_MapChunk_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685554);
		NativeMethodInfoPtr_GetCombineMeshMatList_Private_Il2CppReferenceArray_1_CombineMeshesMat_List_1_CombineInstanceData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685555);
		NativeMethodInfoPtr_CombineMeshes_Private_GameObject_Il2CppReferenceArray_1_CombineMeshesMat_ShadowCastingMode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685556);
		NativeMethodInfoPtr_OptimizeMesh_Private_Void_Mesh_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685557);
		NativeMethodInfoPtr_InstantiateStaticChunkColliders_Private_Void_MapChunk_Transform_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685558);
		NativeMethodInfoPtr_CreateStaticLayerColliders_Private_Boolean_List_1_CombineInstanceData_List_1_TiledColliderInstance_LayerMask_byref_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685559);
		NativeMethodInfoPtr_CreateStaticCollidersFromInstance_Private_Void_GameObject_Vector3_Vector3_Vector3_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685560);
		NativeMethodInfoPtr_CreateSimplifiedCollider_Private_Void_BoundsData_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685561);
		NativeMethodInfoPtr_GetRotatedColliderObj_Private_Transform_Int32_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685562);
		NativeMethodInfoPtr_GetNewColliderObj_Private_Transform_Vector3_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685563);
		NativeMethodInfoPtr_CreateCapsuleCollider_Private_Void_CapsuleCollider_Vector2_Quaternion_Vector3_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685564);
		NativeMethodInfoPtr_InstantiateCeilingGroups_Private_Void_MapChunk_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685565);
		NativeMethodInfoPtr_CreateInstantiatedObjects_Private_Void_MapChunk_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685566);
		NativeMethodInfoPtr_CreateInstantiatedObject_Private_GameObject_GameObject_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685567);
		NativeMethodInfoPtr_CreateFloorCollider_Public_Void_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685568);
		NativeMethodInfoPtr_InitializeNavMesh_Private_Void_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685569);
		NativeMethodInfoPtr_BakeNavMesh_Public_NavMeshData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685570);
		NativeMethodInfoPtr_ClearNavMeshes_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685571);
		NativeMethodInfoPtr_InitializeInstanceRenderer_Private_Void_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685572);
		NativeMethodInfoPtr_CreateAllHideAreaGroups_Private_Void_Il2CppReferenceArray_1_HideAreaGroup_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685573);
		NativeMethodInfoPtr_CreateHideArea_Public_Transform_HideAreaGroup_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685574);
		NativeMethodInfoPtr_CreateTileHideArea_Private_Void_HideArea_Il2CppReferenceArray_1_TilePrefabInstance_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685575);
		NativeMethodInfoPtr_GenerateHideAreaMesh_Private_Mesh_Il2CppReferenceArray_1_TilePrefabInstance_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685576);
		NativeMethodInfoPtr_GenerateHideAreaColliders_Private_Void_Il2CppReferenceArray_1_TilePrefabInstance_HideArea_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685577);
		NativeMethodInfoPtr_CreateHolderHideArea_Private_Void_HideArea_LevelHideAreaHolder_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685578);
		NativeMethodInfoPtr_OnDestroy_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685579);
		NativeMethodInfoPtr_CleanUpLevel_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685580);
		NativeMethodInfoPtr_BuildNavMeshWithinBounds_Public_Void_Bounds_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685581);
		NativeMethodInfoPtr_UpdateNavMeshBounds_Public_Void_Bounds_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685582);
		NativeMethodInfoPtr_TriggerDinamicMapFullLoad_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685583);
		NativeMethodInfoPtr_SampleBiomeMap_Private_Int32_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685584);
		NativeMethodInfoPtr_SampleSurfaceMap_Private_Byte_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685585);
		NativeMethodInfoPtr_SampleCeilingGroupMap_Private_Int32_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685586);
		NativeMethodInfoPtr_SampleAmbience_Public_AmbienceId_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685587);
		NativeMethodInfoPtr_SampleAmbience_Public_AmbienceId_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685588);
		NativeMethodInfoPtr_GetSurfaceId_Public_Int32_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685589);
		NativeMethodInfoPtr_GetCurrentBiomeId_Public_Int32_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685590);
		NativeMethodInfoPtr_GetCurrentBiomeName_Public_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685591);
		NativeMethodInfoPtr_GetCeilingGroupId_Public_Int32_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685592);
		NativeMethodInfoPtr_GetGroundSurfaceIdFromBiomeId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685593);
		NativeMethodInfoPtr_GetBushSurfaceIdFromBiomeId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685594);
		NativeMethodInfoPtr_GetMapNavMeshPosition_Public_Vector3_Vector3_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685595);
		NativeMethodInfoPtr_GetMapNavMeshClosestEdge_Public_Vector3_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685596);
		NativeMethodInfoPtr_GetMapNavMeshPositionRadius_Public_Vector3_Vector3_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685597);
		NativeMethodInfoPtr_OnCeilingGroupEnter_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685598);
		NativeMethodInfoPtr_OnCeilingGroupExit_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685599);
		NativeMethodInfoPtr_CreateMapWaterOuterEdgesObjects_Private_Void_SerializedLevelHolder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685600);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685601);
		NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_2_Private_Void_Int32_Vector2Int_CombineInstanceData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685602);
		NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_0_Private_Void_Int32_Vector2Int_CombineInstanceData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685603);
		NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_1_Private_Void_Int32_Vector2Int_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685604);
		NativeMethodInfoPtr_Method_Private_Void_Transform_byref___c__DisplayClass136_0_PDM_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr, 100685605);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237244, XrefRangeEnd = 237257, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 237260, RefRangeEnd = 237263, XrefRangeStart = 237257, XrefRangeEnd = 237260, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialize()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialize_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237275, RefRangeEnd = 237276, XrefRangeStart = 237263, XrefRangeEnd = 237275, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool GetLevelMMCache(string levelName, int levelId, out LevelMMCache levelMMCache)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelName);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelId;
		byte* num = (byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)));
		nint num2 = 0;
		*(nint**)num = &num2;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLevelMMCache_Public_Static_Boolean_String_Int32_byref_LevelMMCache_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		nint num3 = num2;
		levelMMCache = ((num3 == 0) ? null : new LevelMMCache(num3));
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237296, RefRangeEnd = 237297, XrefRangeStart = 237276, XrefRangeEnd = 237296, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadLevel(string levelName, int levelId, bool isServerOnly, bool isClientOnly)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelName);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelId;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isServerOnly;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &isClientOnly;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadLevel_Public_Void_String_Int32_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237297, XrefRangeEnd = 237300, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe IEnumerator LoadLevelCoroutine(string levelName, int levelId, bool isServerOnly, bool isClientOnly)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelName);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelId;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isServerOnly;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &isClientOnly;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadLevelCoroutine_Private_IEnumerator_String_Int32_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<IEnumerator>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237300, XrefRangeEnd = 237537, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnLevel(string levelName, bool isServerOnly, bool isClientOnly, SerializedLevelHolder svData, SerializedLevelHolder clData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelName);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isServerOnly;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isClientOnly;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)svData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnLevel_Private_Void_String_Boolean_Boolean_SerializedLevelHolder_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237539, RefRangeEnd = 237540, XrefRangeStart = 237537, XrefRangeEnd = 237539, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeNavMeshPreBake(MapSettings mapSettings)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mapSettings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeNavMeshPreBake_Public_Void_MapSettings_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237540, XrefRangeEnd = 237590, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GameObject PreBakeMapChunksColliders(SerializedLevelHolder level)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)level);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreBakeMapChunksColliders_Public_GameObject_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237620, RefRangeEnd = 237621, XrefRangeStart = 237590, XrefRangeEnd = 237620, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BakeStaticChunkColliders(MapChunk mapChunk, Transform bakedChunk, bool createFoWOcclusion)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)mapChunk));
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)bakedChunk);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &createFoWOcclusion;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BakeStaticChunkColliders_Private_Void_MapChunk_Transform_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237640, RefRangeEnd = 237641, XrefRangeStart = 237621, XrefRangeEnd = 237640, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ProcessMapEntities(SerializedLevelHolder levelData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ProcessMapEntities_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 237663, RefRangeEnd = 237665, XrefRangeStart = 237641, XrefRangeEnd = 237663, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeMapData(SerializedLevelHolder levelData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeMapData_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 237691, RefRangeEnd = 237693, XrefRangeStart = 237665, XrefRangeEnd = 237691, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BuildMapData(SerializedLevelHolder svData, SerializedLevelHolder clData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)svData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildMapData_Private_Void_SerializedLevelHolder_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237747, RefRangeEnd = 237748, XrefRangeStart = 237693, XrefRangeEnd = 237747, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ProcessLevelTiles(SerializedLevelHolder clData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ProcessLevelTiles_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237780, RefRangeEnd = 237781, XrefRangeStart = 237748, XrefRangeEnd = 237780, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ProcessLevelGameObjects(SerializedLevelHolder svData, SerializedLevelHolder clData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)svData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ProcessLevelGameObjects_Private_Void_SerializedLevelHolder_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237781, XrefRangeEnd = 237804, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ProcessMapRootTransform(Transform rootTr, Il2CppSystem.Action<int, Vector2Int, CombineInstanceData> addStaticAction, Il2CppSystem.Action<int, Vector2Int, GameObject> addInstantiatedAction)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rootTr);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addStaticAction);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addInstantiatedAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ProcessMapRootTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_Action_3_Int32_Vector2Int_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 237817, RefRangeEnd = 237820, XrefRangeStart = 237804, XrefRangeEnd = 237817, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RecursiveProcessStaticTransform(Transform tr, Il2CppSystem.Action<int, Vector2Int, CombineInstanceData> addAction)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tr);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RecursiveProcessStaticTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237835, RefRangeEnd = 237836, XrefRangeStart = 237820, XrefRangeEnd = 237835, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ProcessStaticTransform(Transform instance, Il2CppSystem.Action<int, Vector2Int, CombineInstanceData> addAction)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instance);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ProcessStaticTransform_Private_Void_Transform_Action_3_Int32_Vector2Int_CombineInstanceData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237887, RefRangeEnd = 237888, XrefRangeStart = 237836, XrefRangeEnd = 237887, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BuildHideAreaData(SerializedLevelHolder loadedMap)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loadedMap);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildHideAreaData_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237908, RefRangeEnd = 237909, XrefRangeStart = 237888, XrefRangeEnd = 237908, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void GetBakedColliders(SerializedLevelHolder mapData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mapData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBakedColliders_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 237930, RefRangeEnd = 237932, XrefRangeStart = 237909, XrefRangeEnd = 237930, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe List<CombineInstanceData> GetPrefabCombineInstances(PrefabConfig prefabConfig, Vector3 worldPos, Vector3 euler, Vector3 scale)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefabConfig);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &worldPos;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &euler;
		*(Vector3**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &scale;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabCombineInstances_Private_List_1_CombineInstanceData_PrefabConfig_Vector3_Vector3_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<CombineInstanceData>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 237951, RefRangeEnd = 237952, XrefRangeStart = 237932, XrefRangeEnd = 237951, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetChunkGridLevel(Transform transform)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetChunkGridLevel_Private_Int32_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237952, XrefRangeEnd = 237964, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool ContainsNonStaticChildren(Transform tr)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tr);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ContainsNonStaticChildren_Private_Boolean_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 237964, XrefRangeEnd = 237966, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsStatic(Transform tr)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tr);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsStatic_Public_Static_Boolean_Transform_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238000, RefRangeEnd = 238001, XrefRangeStart = 237966, XrefRangeEnd = 238000, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BuildSurfaceMap(SerializedLevelHolder loadedMap, Texture2D splatTexture = null)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loadedMap);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)splatTexture);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildSurfaceMap_Private_Void_SerializedLevelHolder_Texture2D_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238013, RefRangeEnd = 238014, XrefRangeStart = 238001, XrefRangeEnd = 238013, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BuildCeilingGroupMap(SerializedLevelHolder loadedMap)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loadedMap);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildCeilingGroupMap_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238031, RefRangeEnd = 238032, XrefRangeStart = 238014, XrefRangeEnd = 238031, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BuildAmbienceMap(SerializedLevelHolder loadedMap)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loadedMap);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildAmbienceMap_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238059, RefRangeEnd = 238060, XrefRangeStart = 238032, XrefRangeEnd = 238059, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Texture2D BuildBiomeAndSplatMap(SerializedLevelHolder levelHolder)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelHolder);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildBiomeAndSplatMap_Private_Texture2D_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238060, XrefRangeEnd = 238074, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<Vector2> GetSpawnPointArrayV2(Il2CppReferenceArray<GameObject> spawnPoints)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnPoints);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSpawnPointArrayV2_Public_Static_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector2>>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238092, RefRangeEnd = 238094, XrefRangeStart = 238074, XrefRangeEnd = 238092, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<Vector3> GetSpawnPointArray(Il2CppReferenceArray<GameObject> spawnPoints)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnPoints);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSpawnPointArray_Public_Static_Il2CppStructArray_1_Vector3_Il2CppReferenceArray_1_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector3>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238094, XrefRangeEnd = 238108, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<Vector2> GetDimensionSpawnPointArrayV2(Il2CppReferenceArray<GameObject> dimensionSpawnPoints)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionSpawnPoints);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDimensionSpawnPointArrayV2_Public_Static_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector2>>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238126, RefRangeEnd = 238128, XrefRangeStart = 238108, XrefRangeEnd = 238126, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<Vector3> GetDimensionSpawnPointArray(Il2CppReferenceArray<GameObject> dimensionSpawnPoints)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionSpawnPoints);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDimensionSpawnPointArray_Public_Static_Il2CppStructArray_1_Vector3_Il2CppReferenceArray_1_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector3>>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238132, RefRangeEnd = 238134, XrefRangeStart = 238128, XrefRangeEnd = 238132, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AssignEntityData(GameObject spawnedEntity, GameObject sourceEntity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnedEntity);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sourceEntity);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AssignEntityData_Public_Void_GameObject_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238146, RefRangeEnd = 238147, XrefRangeStart = 238134, XrefRangeEnd = 238146, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AssignEntityData(GameObject spawnedEntity, IEntityDataProperty property)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnedEntity);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)property);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AssignEntityData_Public_Void_GameObject_IEntityDataProperty_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238181, RefRangeEnd = 238182, XrefRangeStart = 238147, XrefRangeEnd = 238181, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BakeAllMapChunks(Il2CppReferenceArray<MapChunkLevels> chunkLevels, bool createMeshes)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)chunkLevels);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &createMeshes;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BakeAllMapChunks_Private_Void_Il2CppReferenceArray_1_MapChunkLevels_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238255, RefRangeEnd = 238257, XrefRangeStart = 238182, XrefRangeEnd = 238255, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GameObject LoadChunk(int chunkLevel, Vector2Int cPos, bool createMeshes)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&chunkLevel);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &cPos;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &createMeshes;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadChunk_Public_GameObject_Int32_Vector2Int_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238268, RefRangeEnd = 238269, XrefRangeStart = 238257, XrefRangeEnd = 238268, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool TryGetCIListByMatAndMask(List<CombineMeshesMat> combineMeshesMatList, Material mat, int renderingLayerMask, out List<CombineInstance> ciList)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)combineMeshesMatList);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mat);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &renderingLayerMask;
		byte* num = (byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)));
		nint num2 = 0;
		*(nint**)num = &num2;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryGetCIListByMatAndMask_Private_Boolean_List_1_CombineMeshesMat_Material_Int32_byref_List_1_CombineInstance_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		nint num3 = num2;
		ciList = ((num3 == 0) ? null : new List<CombineInstance>(num3));
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238312, RefRangeEnd = 238313, XrefRangeStart = 238269, XrefRangeEnd = 238312, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BakeChunkMeshes(MapChunk mapChunk, Transform parentChunk)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)mapChunk));
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parentChunk);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BakeChunkMeshes_Private_Void_MapChunk_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238407, RefRangeEnd = 238409, XrefRangeStart = 238313, XrefRangeEnd = 238407, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Il2CppReferenceArray<CombineMeshesMat> GetCombineMeshMatList(List<CombineInstanceData> combinePrefabInstanceList)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)combinePrefabInstanceList);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCombineMeshMatList_Private_Il2CppReferenceArray_1_CombineMeshesMat_List_1_CombineInstanceData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<CombineMeshesMat>>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238439, RefRangeEnd = 238441, XrefRangeStart = 238409, XrefRangeEnd = 238439, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GameObject CombineMeshes(Il2CppReferenceArray<CombineMeshesMat> matMeshList, ShadowCastingMode shadowCastingMode = ShadowCastingMode.On)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)matMeshList);
		*(ShadowCastingMode**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &shadowCastingMode;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CombineMeshes_Private_GameObject_Il2CppReferenceArray_1_CombineMeshesMat_ShadowCastingMode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238441, XrefRangeEnd = 238443, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OptimizeMesh(Mesh mesh)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mesh);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OptimizeMesh_Private_Void_Mesh_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238485, RefRangeEnd = 238486, XrefRangeStart = 238443, XrefRangeEnd = 238485, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InstantiateStaticChunkColliders(MapChunk mapChunk, Transform bakedChunk, bool createFoWOcclusion)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)mapChunk));
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)bakedChunk);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &createFoWOcclusion;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InstantiateStaticChunkColliders_Private_Void_MapChunk_Transform_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 238502, RefRangeEnd = 238505, XrefRangeStart = 238486, XrefRangeEnd = 238502, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool CreateStaticLayerColliders(List<CombineInstanceData> obstacles, List<TiledColliderInstance> tiledColliders, LayerMask layer, out GameObject colObj)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obstacles);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tiledColliders);
		*(LayerMask**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &layer;
		byte* num = (byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)));
		nint num2 = 0;
		*(nint**)num = &num2;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateStaticLayerColliders_Private_Boolean_List_1_CombineInstanceData_List_1_TiledColliderInstance_LayerMask_byref_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		nint num3 = num2;
		colObj = ((num3 == 0) ? null : new GameObject(num3));
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238505, XrefRangeEnd = 238570, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateStaticCollidersFromInstance(GameObject instance, Vector3 worldPos, Vector3 rot, Vector3 scale, Transform rootColObj)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instance);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &worldPos;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &rot;
		*(Vector3**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &scale;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rootColObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateStaticCollidersFromInstance_Private_Void_GameObject_Vector3_Vector3_Vector3_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238570, XrefRangeEnd = 238574, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateSimplifiedCollider(BoundsData col, GameObject colObj)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&col);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateSimplifiedCollider_Private_Void_BoundsData_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238574, XrefRangeEnd = 238583, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Transform GetRotatedColliderObj(int colObjRot, Transform rootColObj)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&colObjRot);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rootColObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotatedColliderObj_Private_Transform_Int32_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238595, RefRangeEnd = 238597, XrefRangeStart = 238583, XrefRangeEnd = 238595, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Transform GetNewColliderObj(Vector3 euler, Transform parent)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&euler);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parent);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetNewColliderObj_Private_Transform_Vector3_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238597, XrefRangeEnd = 238606, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateCapsuleCollider(CapsuleCollider sourceCollider, Vector2 worldPos, Quaternion rotation, Vector3 scale, GameObject colObj)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sourceCollider);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &worldPos;
		*(Quaternion**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotation;
		*(Vector3**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &scale;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateCapsuleCollider_Private_Void_CapsuleCollider_Vector2_Quaternion_Vector3_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238644, RefRangeEnd = 238645, XrefRangeStart = 238606, XrefRangeEnd = 238644, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InstantiateCeilingGroups(MapChunk mapChunk, Transform parentChunk)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)mapChunk));
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parentChunk);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InstantiateCeilingGroups_Private_Void_MapChunk_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238645, XrefRangeEnd = 238656, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateInstantiatedObjects(MapChunk mapChunk, Transform parentChunk)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)mapChunk));
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parentChunk);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateInstantiatedObjects_Private_Void_MapChunk_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 238670, RefRangeEnd = 238673, XrefRangeStart = 238656, XrefRangeEnd = 238670, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GameObject CreateInstantiatedObject(GameObject instanceObj, Transform parentTr)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instanceObj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parentTr);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateInstantiatedObject_Private_GameObject_GameObject_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 238693, RefRangeEnd = 238696, XrefRangeStart = 238673, XrefRangeEnd = 238693, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateFloorCollider(Vector2 mapSize)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&mapSize);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateFloorCollider_Public_Void_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238696, XrefRangeEnd = 238711, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeNavMesh(string levelName, bool isClientOnly)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelName);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isClientOnly;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeNavMesh_Private_Void_String_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 238747, RefRangeEnd = 238751, XrefRangeStart = 238711, XrefRangeEnd = 238747, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NavMeshData BakeNavMesh()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BakeNavMesh_Public_NavMeshData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NavMeshData>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238753, RefRangeEnd = 238754, XrefRangeStart = 238751, XrefRangeEnd = 238753, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClearNavMeshes()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClearNavMeshes_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238754, XrefRangeEnd = 238766, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeInstanceRenderer(string levelName, bool isClientOnly)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelName);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isClientOnly;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeInstanceRenderer_Private_Void_String_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238794, RefRangeEnd = 238795, XrefRangeStart = 238766, XrefRangeEnd = 238794, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateAllHideAreaGroups(Il2CppReferenceArray<HideAreaGroup> hideAreas, bool generateMeshes)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hideAreas);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &generateMeshes;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateAllHideAreaGroups_Private_Void_Il2CppReferenceArray_1_HideAreaGroup_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 238806, RefRangeEnd = 238808, XrefRangeStart = 238795, XrefRangeEnd = 238806, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Transform CreateHideArea(HideAreaGroup hideAreaGroup, bool generateMeshes, int id)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)hideAreaGroup));
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &generateMeshes;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &id;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateHideArea_Public_Transform_HideAreaGroup_Boolean_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238853, RefRangeEnd = 238854, XrefRangeStart = 238808, XrefRangeEnd = 238853, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateTileHideArea(HideArea hideArea, Il2CppReferenceArray<TilePrefabInstance> hideAreaTiles, bool generateMeshes)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hideArea);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hideAreaTiles);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &generateMeshes;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateTileHideArea_Private_Void_HideArea_Il2CppReferenceArray_1_TilePrefabInstance_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238897, RefRangeEnd = 238898, XrefRangeStart = 238854, XrefRangeEnd = 238897, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Mesh GenerateHideAreaMesh(Il2CppReferenceArray<TilePrefabInstance> tiles, Transform parent)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tiles);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parent);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GenerateHideAreaMesh_Private_Mesh_Il2CppReferenceArray_1_TilePrefabInstance_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238928, RefRangeEnd = 238929, XrefRangeStart = 238898, XrefRangeEnd = 238928, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void GenerateHideAreaColliders(Il2CppReferenceArray<TilePrefabInstance> tiles, HideArea hideArea)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tiles);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hideArea);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GenerateHideAreaColliders_Private_Void_Il2CppReferenceArray_1_TilePrefabInstance_HideArea_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 238963, RefRangeEnd = 238964, XrefRangeStart = 238929, XrefRangeEnd = 238963, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateHolderHideArea(HideArea hideArea, LevelHideAreaHolder holder, bool generateMeshes)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hideArea);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)holder);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &generateMeshes;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateHolderHideArea_Private_Void_HideArea_LevelHideAreaHolder_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 238964, XrefRangeEnd = 238968, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDestroy()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDestroy_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239003, RefRangeEnd = 239004, XrefRangeStart = 238968, XrefRangeEnd = 239003, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CleanUpLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CleanUpLevel_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239015, RefRangeEnd = 239016, XrefRangeStart = 239004, XrefRangeEnd = 239015, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void BuildNavMeshWithinBounds(Bounds bounds)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&bounds);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildNavMeshWithinBounds_Public_Void_Bounds_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239016, XrefRangeEnd = 239027, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateNavMeshBounds(Bounds bounds)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&bounds);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateNavMeshBounds_Public_Void_Bounds_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239036, RefRangeEnd = 239037, XrefRangeStart = 239027, XrefRangeEnd = 239036, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TriggerDinamicMapFullLoad()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TriggerDinamicMapFullLoad_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239037, XrefRangeEnd = 239046, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int SampleBiomeMap(Vector2 worldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&worldPosition);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleBiomeMap_Private_Int32_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239046, XrefRangeEnd = 239053, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe byte SampleSurfaceMap(Vector2 worldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&worldPosition);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleSurfaceMap_Private_Byte_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239053, XrefRangeEnd = 239060, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int SampleCeilingGroupMap(Vector2 worldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&worldPosition);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleCeilingGroupMap_Private_Int32_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239060, XrefRangeEnd = 239063, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AmbienceId SampleAmbience(Vector3 worldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&worldPosition);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleAmbience_Public_AmbienceId_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(AmbienceId*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239063, RefRangeEnd = 239064, XrefRangeStart = 239063, XrefRangeEnd = 239063, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AmbienceId SampleAmbience(int x, int y)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&x);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &y;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleAmbience_Public_AmbienceId_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(AmbienceId*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239071, RefRangeEnd = 239072, XrefRangeStart = 239064, XrefRangeEnd = 239071, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetSurfaceId(Vector3 worldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&worldPosition);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSurfaceId_Public_Int32_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 239081, RefRangeEnd = 239084, XrefRangeStart = 239072, XrefRangeEnd = 239081, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetCurrentBiomeId(Vector3 worldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&worldPosition);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentBiomeId_Public_Int32_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239085, RefRangeEnd = 239086, XrefRangeStart = 239084, XrefRangeEnd = 239085, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetCurrentBiomeName(int currentBiomeId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&currentBiomeId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentBiomeName_Public_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239093, RefRangeEnd = 239094, XrefRangeStart = 239086, XrefRangeEnd = 239093, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetCeilingGroupId(Vector3 worldPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&worldPosition);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCeilingGroupId_Public_Int32_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe int GetGroundSurfaceIdFromBiomeId(int biomeId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&biomeId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetGroundSurfaceIdFromBiomeId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239094, RefRangeEnd = 239095, XrefRangeStart = 239094, XrefRangeEnd = 239094, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetBushSurfaceIdFromBiomeId(int biomeId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&biomeId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBushSurfaceIdFromBiomeId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 239096, RefRangeEnd = 239104, XrefRangeStart = 239095, XrefRangeEnd = 239096, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetMapNavMeshPosition(Vector3 position, float distance = 10f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&position);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &distance;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMapNavMeshPosition_Public_Vector3_Vector3_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239104, XrefRangeEnd = 239105, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetMapNavMeshClosestEdge(Vector3 position)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&position);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMapNavMeshClosestEdge_Public_Vector3_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 239112, RefRangeEnd = 239116, XrefRangeStart = 239105, XrefRangeEnd = 239112, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetMapNavMeshPositionRadius(Vector3 position, float distance = 10f, float radius = 1f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&position);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &distance;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &radius;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMapNavMeshPositionRadius_Public_Vector3_Vector3_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239124, RefRangeEnd = 239125, XrefRangeStart = 239116, XrefRangeEnd = 239124, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnCeilingGroupEnter(int ceilingGroupId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&ceilingGroupId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnCeilingGroupEnter_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239133, RefRangeEnd = 239134, XrefRangeStart = 239125, XrefRangeEnd = 239133, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnCeilingGroupExit(int ceilingGroupId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&ceilingGroupId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnCeilingGroupExit_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239166, RefRangeEnd = 239167, XrefRangeStart = 239134, XrefRangeEnd = 239166, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateMapWaterOuterEdgesObjects(SerializedLevelHolder levelData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateMapWaterOuterEdgesObjects_Private_Void_SerializedLevelHolder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239167, XrefRangeEnd = 239186, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LevelRuntimeManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LevelRuntimeManager>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239186, XrefRangeEnd = 239189, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void _ProcessLevelGameObjects_b__86_2(int lvl, Vector2Int cPos, CombineInstanceData ci)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&lvl);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &cPos;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ci);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_2_Private_Void_Int32_Vector2Int_CombineInstanceData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239189, XrefRangeEnd = 239192, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void _ProcessLevelGameObjects_b__86_0(int lvl, Vector2Int cPos, CombineInstanceData ci)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&lvl);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &cPos;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ci);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_0_Private_Void_Int32_Vector2Int_CombineInstanceData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239192, XrefRangeEnd = 239195, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void _ProcessLevelGameObjects_b__86_1(int lvl, Vector2Int cPos, GameObject obj)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&lvl);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &cPos;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ProcessLevelGameObjects_b__86_1_Private_Void_Int32_Vector2Int_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239218, RefRangeEnd = 239219, XrefRangeStart = 239195, XrefRangeEnd = 239218, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Method_Private_Void_Transform_byref___c__DisplayClass136_0_PDM_0(Transform tr, ref __c__DisplayClass136_0 A_2)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tr);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)A_2);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Method_Private_Void_Transform_byref___c__DisplayClass136_0_PDM_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LevelRuntimeManager(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

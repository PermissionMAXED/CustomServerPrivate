using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;
using UnityEngine.Rendering;

namespace Il2CppBAPBAP.Maps;

public class PrefabConfig : MonoBehaviour
{
	[System.Serializable]
	public class SurfaceConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_surfaceId;

		private static readonly System.IntPtr NativeFieldInfoPtr_useGroundPaintSurface;

		private static readonly System.IntPtr NativeFieldInfoPtr_surfaceArea;

		private static readonly System.IntPtr NativeFieldInfoPtr_surfaceAreaCenter;

		private static readonly System.IntPtr NativeFieldInfoPtr_surfaceAreaSize;

		private static readonly System.IntPtr NativeFieldInfoPtr_orderInLayer;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe SurfaceId surfaceId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceId);
				return *(SurfaceId*)num;
			}
			set
			{
				*(SurfaceId*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceId)) = surfaceId;
			}
		}

		public unsafe bool useGroundPaintSurface
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_useGroundPaintSurface);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_useGroundPaintSurface)) = flag;
			}
		}

		public unsafe bool surfaceArea
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceArea);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceArea)) = flag;
			}
		}

		public unsafe Vector2Int surfaceAreaCenter
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceAreaCenter);
				return *(Vector2Int*)num;
			}
			set
			{
				*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceAreaCenter)) = vector2Int;
			}
		}

		public unsafe Vector2Int surfaceAreaSize
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceAreaSize);
				return *(Vector2Int*)num;
			}
			set
			{
				*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceAreaSize)) = vector2Int;
			}
		}

		public unsafe float orderInLayer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_orderInLayer);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_orderInLayer)) = num;
			}
		}

		static SurfaceConfig()
		{
			Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "SurfaceConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr);
			NativeFieldInfoPtr_surfaceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr, "surfaceId");
			NativeFieldInfoPtr_useGroundPaintSurface = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr, "useGroundPaintSurface");
			NativeFieldInfoPtr_surfaceArea = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr, "surfaceArea");
			NativeFieldInfoPtr_surfaceAreaCenter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr, "surfaceAreaCenter");
			NativeFieldInfoPtr_surfaceAreaSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr, "surfaceAreaSize");
			NativeFieldInfoPtr_orderInLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr, "orderInLayer");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr, 100685626);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239219, XrefRangeEnd = 239221, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe SurfaceConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SurfaceConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public SurfaceConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_DefaultRenderMask;

	private static readonly System.IntPtr NativeFieldInfoPtr__isStatic;

	private static readonly System.IntPtr NativeFieldInfoPtr__prefabId;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapLayer;

	private static readonly System.IntPtr NativeFieldInfoPtr_entityConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr_surfaceConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultAmbienceId;

	private static readonly System.IntPtr NativeFieldInfoPtr_isNoRotation;

	private static readonly System.IntPtr NativeFieldInfoPtr_shadowCastingMode;

	private static readonly System.IntPtr NativeFieldInfoPtr_renderingLayerMask;

	private static readonly System.IntPtr NativeFieldInfoPtr_bakeIntoMinimap;

	private static readonly System.IntPtr NativeFieldInfoPtr_isTiledCollider;

	private static readonly System.IntPtr NativeFieldInfoPtr_isWalkable;

	private static readonly System.IntPtr NativeFieldInfoPtr_isWaterTile;

	private static readonly System.IntPtr NativeMethodInfoPtr_Validate_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_IsStatic_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PrefabId_Public_get_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_PrefabId_Public_set_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnDrawGizmosSelected_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe static int DefaultRenderMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_DefaultRenderMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_DefaultRenderMask, (void*)(&num));
		}
	}

	public unsafe bool _isStatic
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isStatic);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isStatic)) = flag;
		}
	}

	public unsafe int _prefabId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__prefabId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__prefabId)) = num;
		}
	}

	public unsafe MapLayer mapLayer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapLayer);
			return *(MapLayer*)num;
		}
		set
		{
			*(MapLayer*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapLayer)) = mapLayer;
		}
	}

	public unsafe EntityAssetsManager.EntityAsset entityConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityAssetsManager.EntityAsset>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityAsset));
		}
	}

	public unsafe SurfaceConfig surfaceConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SurfaceConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_surfaceConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)surfaceConfig));
		}
	}

	public unsafe AmbienceId defaultAmbienceId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultAmbienceId);
			return *(AmbienceId*)num;
		}
		set
		{
			*(AmbienceId*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultAmbienceId)) = ambienceId;
		}
	}

	public unsafe bool isNoRotation
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isNoRotation);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isNoRotation)) = flag;
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

	public unsafe bool bakeIntoMinimap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeIntoMinimap);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakeIntoMinimap)) = flag;
		}
	}

	public unsafe bool isTiledCollider
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isTiledCollider);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isTiledCollider)) = flag;
		}
	}

	public unsafe bool isWalkable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isWalkable);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isWalkable)) = flag;
		}
	}

	public unsafe bool isWaterTile
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isWaterTile);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isWaterTile)) = flag;
		}
	}

	public unsafe bool IsStatic
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 33130, RefRangeEnd = 33131, XrefRangeStart = 33130, XrefRangeEnd = 33131, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_IsStatic_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe int PrefabId
	{
		[CallerCount(48)]
		[CachedScanResults(RefRangeStart = 33131, RefRangeEnd = 33179, XrefRangeStart = 33131, XrefRangeEnd = 33179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PrefabId_Public_get_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(16)]
		[CachedScanResults(RefRangeStart = 33179, RefRangeEnd = 33195, XrefRangeStart = 33179, XrefRangeEnd = 33195, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_PrefabId_Public_set_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	static PrefabConfig()
	{
		Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "PrefabConfig");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr);
		NativeFieldInfoPtr_DefaultRenderMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "DefaultRenderMask");
		NativeFieldInfoPtr__isStatic = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "_isStatic");
		NativeFieldInfoPtr__prefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "_prefabId");
		NativeFieldInfoPtr_mapLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "mapLayer");
		NativeFieldInfoPtr_entityConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "entityConfig");
		NativeFieldInfoPtr_surfaceConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "surfaceConfig");
		NativeFieldInfoPtr_defaultAmbienceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "defaultAmbienceId");
		NativeFieldInfoPtr_isNoRotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "isNoRotation");
		NativeFieldInfoPtr_shadowCastingMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "shadowCastingMode");
		NativeFieldInfoPtr_renderingLayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "renderingLayerMask");
		NativeFieldInfoPtr_bakeIntoMinimap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "bakeIntoMinimap");
		NativeFieldInfoPtr_isTiledCollider = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "isTiledCollider");
		NativeFieldInfoPtr_isWalkable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "isWalkable");
		NativeFieldInfoPtr_isWaterTile = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, "isWaterTile");
		NativeMethodInfoPtr_Validate_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, 100685620);
		NativeMethodInfoPtr_get_IsStatic_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, 100685621);
		NativeMethodInfoPtr_get_PrefabId_Public_get_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, 100685622);
		NativeMethodInfoPtr_set_PrefabId_Public_set_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, 100685623);
		NativeMethodInfoPtr_OnDrawGizmosSelected_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, 100685624);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr, 100685625);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239230, RefRangeEnd = 239231, XrefRangeStart = 239221, XrefRangeEnd = 239230, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Validate(bool fullValidate = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&fullValidate);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Validate_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239231, XrefRangeEnd = 239237, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDrawGizmosSelected()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDrawGizmosSelected_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239237, XrefRangeEnd = 239238, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PrefabConfig()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PrefabConfig>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PrefabConfig(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

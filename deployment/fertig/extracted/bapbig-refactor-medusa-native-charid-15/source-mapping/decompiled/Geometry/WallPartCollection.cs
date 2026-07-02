using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Geometry;

[Serializable]
public class WallPartCollection : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_levelHeight;

	private static readonly IntPtr NativeFieldInfoPtr_pivotOffset;

	private static readonly IntPtr NativeFieldInfoPtr_segmentWidth;

	private static readonly IntPtr NativeFieldInfoPtr_scaleByWidthMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_segmentHeightMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_segmentDepthMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_randomPositionOffset;

	private static readonly IntPtr NativeFieldInfoPtr_cornerScaleMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_cornerAngleThreshold;

	private static readonly IntPtr NativeFieldInfoPtr_cornerSize;

	private static readonly IntPtr NativeFieldInfoPtr_clipsAsCorners;

	private static readonly IntPtr NativeFieldInfoPtr_averageDirection;

	private static readonly IntPtr NativeFieldInfoPtr_lookDirectionOffset;

	private static readonly IntPtr NativeFieldInfoPtr_lookAtPivot;

	private static readonly IntPtr NativeFieldInfoPtr_chanceToSkip;

	private static readonly IntPtr NativeFieldInfoPtr_placementMode;

	private static readonly IntPtr NativeFieldInfoPtr_autoValidateColliders;

	private static readonly IntPtr NativeFieldInfoPtr_slack;

	private static readonly IntPtr NativeFieldInfoPtr_slackDensity;

	private static readonly IntPtr NativeFieldInfoPtr_wallPrefabs;

	private static readonly IntPtr NativeFieldInfoPtr_edgeCustomDataPrefabs;

	private static readonly IntPtr NativeFieldInfoPtr_wallEndPrefab1;

	private static readonly IntPtr NativeFieldInfoPtr_wallEndPrefab2;

	private static readonly IntPtr NativeFieldInfoPtr_cornerPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_innerCornerPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_pointCustomDataPrefabs;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float levelHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelHeight)) = num;
		}
	}

	public unsafe Vector3 pivotOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pivotOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pivotOffset)) = vector;
		}
	}

	public unsafe float segmentWidth
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_segmentWidth);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_segmentWidth)) = num;
		}
	}

	public unsafe bool scaleByWidthMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_scaleByWidthMultiplier);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_scaleByWidthMultiplier)) = flag;
		}
	}

	public unsafe float segmentHeightMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_segmentHeightMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_segmentHeightMultiplier)) = num;
		}
	}

	public unsafe float segmentDepthMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_segmentDepthMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_segmentDepthMultiplier)) = num;
		}
	}

	public unsafe Vector3 randomPositionOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPositionOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPositionOffset)) = vector;
		}
	}

	public unsafe Vector3 cornerScaleMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerScaleMultiplier);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerScaleMultiplier)) = vector;
		}
	}

	public unsafe float cornerAngleThreshold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerAngleThreshold);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerAngleThreshold)) = num;
		}
	}

	public unsafe float cornerSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerSize);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerSize)) = num;
		}
	}

	public unsafe bool clipsAsCorners
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clipsAsCorners);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clipsAsCorners)) = flag;
		}
	}

	public unsafe bool averageDirection
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_averageDirection);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_averageDirection)) = flag;
		}
	}

	public unsafe float lookDirectionOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lookDirectionOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lookDirectionOffset)) = num;
		}
	}

	public unsafe bool lookAtPivot
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lookAtPivot);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lookAtPivot)) = flag;
		}
	}

	public unsafe float chanceToSkip
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceToSkip);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceToSkip)) = num;
		}
	}

	public unsafe WallShapeCreator.PlacementMode placementMode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placementMode);
			return *(WallShapeCreator.PlacementMode*)num;
		}
		set
		{
			*(WallShapeCreator.PlacementMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placementMode)) = placementMode;
		}
	}

	public unsafe bool autoValidateColliders
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoValidateColliders);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoValidateColliders)) = flag;
		}
	}

	public unsafe float slack
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slack);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slack)) = num;
		}
	}

	public unsafe int slackDensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slackDensity);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slackDensity)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<GameObject> wallPrefabs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallPrefabs);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallPrefabs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<GameObject> edgeCustomDataPrefabs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeCustomDataPrefabs);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeCustomDataPrefabs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe GameObject wallEndPrefab1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallEndPrefab1);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallEndPrefab1)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject wallEndPrefab2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallEndPrefab2);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallEndPrefab2)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject cornerPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cornerPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject innerCornerPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_innerCornerPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_innerCornerPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Il2CppReferenceArray<GameObject> pointCustomDataPrefabs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointCustomDataPrefabs);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointCustomDataPrefabs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static WallPartCollection()
	{
		Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Geometry", "WallPartCollection");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr);
		NativeFieldInfoPtr_levelHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "levelHeight");
		NativeFieldInfoPtr_pivotOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "pivotOffset");
		NativeFieldInfoPtr_segmentWidth = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "segmentWidth");
		NativeFieldInfoPtr_scaleByWidthMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "scaleByWidthMultiplier");
		NativeFieldInfoPtr_segmentHeightMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "segmentHeightMultiplier");
		NativeFieldInfoPtr_segmentDepthMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "segmentDepthMultiplier");
		NativeFieldInfoPtr_randomPositionOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "randomPositionOffset");
		NativeFieldInfoPtr_cornerScaleMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "cornerScaleMultiplier");
		NativeFieldInfoPtr_cornerAngleThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "cornerAngleThreshold");
		NativeFieldInfoPtr_cornerSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "cornerSize");
		NativeFieldInfoPtr_clipsAsCorners = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "clipsAsCorners");
		NativeFieldInfoPtr_averageDirection = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "averageDirection");
		NativeFieldInfoPtr_lookDirectionOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "lookDirectionOffset");
		NativeFieldInfoPtr_lookAtPivot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "lookAtPivot");
		NativeFieldInfoPtr_chanceToSkip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "chanceToSkip");
		NativeFieldInfoPtr_placementMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "placementMode");
		NativeFieldInfoPtr_autoValidateColliders = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "autoValidateColliders");
		NativeFieldInfoPtr_slack = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "slack");
		NativeFieldInfoPtr_slackDensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "slackDensity");
		NativeFieldInfoPtr_wallPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "wallPrefabs");
		NativeFieldInfoPtr_edgeCustomDataPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "edgeCustomDataPrefabs");
		NativeFieldInfoPtr_wallEndPrefab1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "wallEndPrefab1");
		NativeFieldInfoPtr_wallEndPrefab2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "wallEndPrefab2");
		NativeFieldInfoPtr_cornerPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "cornerPrefab");
		NativeFieldInfoPtr_innerCornerPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "innerCornerPrefab");
		NativeFieldInfoPtr_pointCustomDataPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, "pointCustomDataPrefabs");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr, 100685265);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 234990, XrefRangeEnd = 234992, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe WallPartCollection()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<WallPartCollection>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public WallPartCollection(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Geometry;

public class WallShapeCreator : ShapeCreator
{
	[OriginalName("Assembly-CSharp.dll", "", "PlacementMode")]
	public enum PlacementMode
	{
		Stretch,
		Repeat
	}

	private static readonly IntPtr NativeFieldInfoPtr_generate;

	private static readonly IntPtr NativeFieldInfoPtr_hideChildrenInHierarchy;

	private static readonly IntPtr NativeFieldInfoPtr_floorShapeCreator;

	private static readonly IntPtr NativeFieldInfoPtr_floorHeight;

	private static readonly IntPtr NativeFieldInfoPtr_generateFloor;

	private static readonly IntPtr NativeFieldInfoPtr_ceilingShapeCreator;

	private static readonly IntPtr NativeFieldInfoPtr_ceilingHeight;

	private static readonly IntPtr NativeFieldInfoPtr_generateCeiling;

	private static readonly IntPtr NativeFieldInfoPtr_levelRange;

	private static readonly IntPtr NativeFieldInfoPtr_wallParts;

	private static readonly IntPtr NativeFieldInfoPtr_autoConvert;

	private static readonly IntPtr NativeFieldInfoPtr_chanceToSkip;

	private static readonly IntPtr NativeFieldInfoPtr_placementMode;

	private static readonly IntPtr NativeFieldInfoPtr_slack;

	private static readonly IntPtr NativeFieldInfoPtr_slackDensity;

	private static readonly IntPtr NativeFieldInfoPtr_lookDirectionOffset;

	private static readonly IntPtr NativeFieldInfoPtr_lookAtPivot;

	private static readonly IntPtr NativeFieldInfoPtr_cornerScaleMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_cornerAngleThreshold;

	private static readonly IntPtr NativeFieldInfoPtr_cornerSize;

	private static readonly IntPtr NativeFieldInfoPtr_clipsAsCorners;

	private static readonly IntPtr NativeFieldInfoPtr_segmentWidth;

	private static readonly IntPtr NativeFieldInfoPtr_segmentHeightMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_segmentDepthMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_wallPrefabs;

	private static readonly IntPtr NativeFieldInfoPtr_edgeCustomDataPrefabs;

	private static readonly IntPtr NativeFieldInfoPtr_wallEndPrefab1;

	private static readonly IntPtr NativeFieldInfoPtr_wallEndPrefab2;

	private static readonly IntPtr NativeFieldInfoPtr_cornerPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_innerCornerPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_pointCustomDataPrefabs;

	private static readonly IntPtr NativeFieldInfoPtr_edgeCustomDataTextures;

	private static readonly IntPtr NativeFieldInfoPtr_pointCustomDataTextures;

	private static readonly IntPtr NativeFieldInfoPtr_linePoints;

	private static readonly IntPtr NativeMethodInfoPtr_ConvertLegacyParts_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_DestroyAllChildren_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnLevel_Private_Void_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnOnConnection_Private_Void_Int32_Shape_WallPartCollection_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnOnPoints_Private_Void_Int32_WallPartCollection_Shape_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnOnEdges_Private_Void_Int32_Shape_WallPartCollection_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetLevelOffset_Private_Vector3_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetWallPartCollection_Private_WallPartCollection_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_PlaceStretched_Private_Void_WallPartCollection_Vector3_Vector3_Int32_Int32_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_CalculateScale_Private_Static_Vector3_Vector3_WallPartCollection_Single_Vector3_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateCatenary_Public_Void_Vector3_Vector3_Int32_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_Cosh_Private_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_Sinh_Private_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_Coth_Private_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_CreateCatenary_Private_Void_List_1_Vector3_byref_Vector3_byref_Vector3_Int32_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetEdgeCustomDataOptions_Public_Virtual_Dictionary_2_GUIContent_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPointCustomDataOptions_Public_Virtual_Dictionary_2_GUIContent_String_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe bool generate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generate);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generate)) = flag;
		}
	}

	public unsafe bool hideChildrenInHierarchy
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideChildrenInHierarchy);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideChildrenInHierarchy)) = flag;
		}
	}

	public unsafe MeshShapeCreator floorShapeCreator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_floorShapeCreator);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<MeshShapeCreator>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_floorShapeCreator)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)meshShapeCreator));
		}
	}

	public unsafe float floorHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_floorHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_floorHeight)) = num;
		}
	}

	public unsafe bool generateFloor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generateFloor);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generateFloor)) = flag;
		}
	}

	public unsafe MeshShapeCreator ceilingShapeCreator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingShapeCreator);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<MeshShapeCreator>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingShapeCreator)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)meshShapeCreator));
		}
	}

	public unsafe float ceilingHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingHeight)) = num;
		}
	}

	public unsafe bool generateCeiling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generateCeiling);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generateCeiling)) = flag;
		}
	}

	public unsafe Vector2Int levelRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelRange);
			return *(Vector2Int*)num;
		}
		set
		{
			*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelRange)) = vector2Int;
		}
	}

	public unsafe Il2CppReferenceArray<WallPartCollection> wallParts
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallParts);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<WallPartCollection>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wallParts)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe bool autoConvert
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoConvert);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoConvert)) = flag;
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

	public unsafe PlacementMode placementMode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placementMode);
			return *(PlacementMode*)num;
		}
		set
		{
			*(PlacementMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placementMode)) = placementMode;
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

	public unsafe List<Texture2D> edgeCustomDataTextures
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeCustomDataTextures);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<Texture2D>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeCustomDataTextures)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<Texture2D> pointCustomDataTextures
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointCustomDataTextures);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<Texture2D>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pointCustomDataTextures)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<Vector3> linePoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_linePoints);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<Vector3>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_linePoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static WallShapeCreator()
	{
		Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Geometry", "WallShapeCreator");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr);
		NativeFieldInfoPtr_generate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "generate");
		NativeFieldInfoPtr_hideChildrenInHierarchy = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "hideChildrenInHierarchy");
		NativeFieldInfoPtr_floorShapeCreator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "floorShapeCreator");
		NativeFieldInfoPtr_floorHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "floorHeight");
		NativeFieldInfoPtr_generateFloor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "generateFloor");
		NativeFieldInfoPtr_ceilingShapeCreator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "ceilingShapeCreator");
		NativeFieldInfoPtr_ceilingHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "ceilingHeight");
		NativeFieldInfoPtr_generateCeiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "generateCeiling");
		NativeFieldInfoPtr_levelRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "levelRange");
		NativeFieldInfoPtr_wallParts = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "wallParts");
		NativeFieldInfoPtr_autoConvert = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "autoConvert");
		NativeFieldInfoPtr_chanceToSkip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "chanceToSkip");
		NativeFieldInfoPtr_placementMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "placementMode");
		NativeFieldInfoPtr_slack = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "slack");
		NativeFieldInfoPtr_slackDensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "slackDensity");
		NativeFieldInfoPtr_lookDirectionOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "lookDirectionOffset");
		NativeFieldInfoPtr_lookAtPivot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "lookAtPivot");
		NativeFieldInfoPtr_cornerScaleMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "cornerScaleMultiplier");
		NativeFieldInfoPtr_cornerAngleThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "cornerAngleThreshold");
		NativeFieldInfoPtr_cornerSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "cornerSize");
		NativeFieldInfoPtr_clipsAsCorners = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "clipsAsCorners");
		NativeFieldInfoPtr_segmentWidth = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "segmentWidth");
		NativeFieldInfoPtr_segmentHeightMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "segmentHeightMultiplier");
		NativeFieldInfoPtr_segmentDepthMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "segmentDepthMultiplier");
		NativeFieldInfoPtr_wallPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "wallPrefabs");
		NativeFieldInfoPtr_edgeCustomDataPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "edgeCustomDataPrefabs");
		NativeFieldInfoPtr_wallEndPrefab1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "wallEndPrefab1");
		NativeFieldInfoPtr_wallEndPrefab2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "wallEndPrefab2");
		NativeFieldInfoPtr_cornerPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "cornerPrefab");
		NativeFieldInfoPtr_innerCornerPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "innerCornerPrefab");
		NativeFieldInfoPtr_pointCustomDataPrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "pointCustomDataPrefabs");
		NativeFieldInfoPtr_edgeCustomDataTextures = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "edgeCustomDataTextures");
		NativeFieldInfoPtr_pointCustomDataTextures = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "pointCustomDataTextures");
		NativeFieldInfoPtr_linePoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, "linePoints");
		NativeMethodInfoPtr_ConvertLegacyParts_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685266);
		NativeMethodInfoPtr_DestroyAllChildren_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685267);
		NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685268);
		NativeMethodInfoPtr_SpawnLevel_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685269);
		NativeMethodInfoPtr_SpawnOnConnection_Private_Void_Int32_Shape_WallPartCollection_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685270);
		NativeMethodInfoPtr_SpawnOnPoints_Private_Void_Int32_WallPartCollection_Shape_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685271);
		NativeMethodInfoPtr_SpawnOnEdges_Private_Void_Int32_Shape_WallPartCollection_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685272);
		NativeMethodInfoPtr_GetLevelOffset_Private_Vector3_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685273);
		NativeMethodInfoPtr_GetWallPartCollection_Private_WallPartCollection_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685274);
		NativeMethodInfoPtr_PlaceStretched_Private_Void_WallPartCollection_Vector3_Vector3_Int32_Int32_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685275);
		NativeMethodInfoPtr_CalculateScale_Private_Static_Vector3_Vector3_WallPartCollection_Single_Vector3_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685276);
		NativeMethodInfoPtr_UpdateCatenary_Public_Void_Vector3_Vector3_Int32_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685277);
		NativeMethodInfoPtr_Cosh_Private_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685278);
		NativeMethodInfoPtr_Sinh_Private_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685279);
		NativeMethodInfoPtr_Coth_Private_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685280);
		NativeMethodInfoPtr_CreateCatenary_Private_Void_List_1_Vector3_byref_Vector3_byref_Vector3_Int32_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685281);
		NativeMethodInfoPtr_GetEdgeCustomDataOptions_Public_Virtual_Dictionary_2_GUIContent_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685282);
		NativeMethodInfoPtr_GetPointCustomDataOptions_Public_Virtual_Dictionary_2_GUIContent_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685283);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr, 100685284);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 234998, RefRangeEnd = 234999, XrefRangeStart = 234992, XrefRangeEnd = 234998, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ConvertLegacyParts()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ConvertLegacyParts_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 235015, RefRangeEnd = 235016, XrefRangeStart = 234999, XrefRangeEnd = 235015, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DestroyAllChildren()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DestroyAllChildren_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235016, XrefRangeEnd = 235067, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void UpdateShapeDisplay(bool fullRefresh = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&fullRefresh);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 235166, RefRangeEnd = 235168, XrefRangeStart = 235067, XrefRangeEnd = 235166, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnLevel(int level)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&level);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnLevel_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 235187, RefRangeEnd = 235188, XrefRangeStart = 235168, XrefRangeEnd = 235187, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnOnConnection(int level, Shape shape, WallPartCollection wpc)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&level);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)shape);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)wpc);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnOnConnection_Private_Void_Int32_Shape_WallPartCollection_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 235230, RefRangeEnd = 235231, XrefRangeStart = 235188, XrefRangeEnd = 235230, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnOnPoints(int level, WallPartCollection wpc, Shape shape)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&level);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)wpc);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)shape);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnOnPoints_Private_Void_Int32_WallPartCollection_Shape_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 235277, RefRangeEnd = 235278, XrefRangeStart = 235231, XrefRangeEnd = 235277, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnOnEdges(int level, Shape shape, WallPartCollection wpc)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&level);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)shape);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)wpc);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnOnEdges_Private_Void_Int32_Shape_WallPartCollection_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 235279, RefRangeEnd = 235282, XrefRangeStart = 235278, XrefRangeEnd = 235279, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetLevelOffset(int level)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&level);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLevelOffset_Private_Vector3_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 235282, RefRangeEnd = 235284, XrefRangeStart = 235282, XrefRangeEnd = 235282, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe WallPartCollection GetWallPartCollection(int level)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&level);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetWallPartCollection_Private_WallPartCollection_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<WallPartCollection>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 235292, RefRangeEnd = 235293, XrefRangeStart = 235284, XrefRangeEnd = 235292, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlaceStretched(WallPartCollection wpc, Vector3 startPosition, Vector3 edgeDirection, int k, int max, float width)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[6];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)wpc);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &startPosition;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &edgeDirection;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &k;
		*(int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &max;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &width;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlaceStretched_Private_Void_WallPartCollection_Vector3_Vector3_Int32_Int32_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235293, XrefRangeEnd = 235300, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector3 CalculateScale(Vector3 scale, WallPartCollection wpc, float adjustedWallWidth, Vector3 forward, float widthMultiplier)
	{
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = (nint)(&scale);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)wpc);
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &adjustedWallWidth;
		*(Vector3**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &forward;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &widthMultiplier;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScale_Private_Static_Vector3_Vector3_WallPartCollection_Single_Vector3_Single_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 235305, RefRangeEnd = 235306, XrefRangeStart = 235300, XrefRangeEnd = 235305, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateCatenary(Vector3 endPosition, Vector3 startPosition, int segments, float slack)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[4];
		*ptr = (nint)(&endPosition);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &startPosition;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &segments;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &slack;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateCatenary_Public_Void_Vector3_Vector3_Int32_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235306, XrefRangeEnd = 235309, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float Cosh(float f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&f);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Cosh_Private_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235309, XrefRangeEnd = 235312, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float Sinh(float f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&f);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Sinh_Private_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235312, XrefRangeEnd = 235318, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float Coth(float f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&f);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Coth_Private_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 235339, RefRangeEnd = 235340, XrefRangeStart = 235318, XrefRangeEnd = 235339, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CreateCatenary(List<Vector3> points, [In] ref Vector3 p1, [In] ref Vector3 p2, int segments, float targetLength)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)points);
		*(void**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = Unsafe.AsPointer(ref p1);
		*(void**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = Unsafe.AsPointer(ref p2);
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &segments;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &targetLength;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateCatenary_Private_Void_List_1_Vector3_byref_Vector3_byref_Vector3_Int32_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235340, XrefRangeEnd = 235357, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override Dictionary<GUIContent, string> GetEdgeCustomDataOptions()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetEdgeCustomDataOptions_Public_Virtual_Dictionary_2_GUIContent_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GUIContent, string>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235357, XrefRangeEnd = 235374, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override Dictionary<GUIContent, string> GetPointCustomDataOptions()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetPointCustomDataOptions_Public_Virtual_Dictionary_2_GUIContent_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GUIContent, string>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 235374, XrefRangeEnd = 235386, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe WallShapeCreator()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<WallShapeCreator>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public WallShapeCreator(IntPtr pointer)
		: base(pointer)
	{
	}
}

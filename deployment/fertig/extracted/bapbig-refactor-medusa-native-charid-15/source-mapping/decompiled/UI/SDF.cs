using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public static class SDF : Il2CppSystem.Object
{
	[OriginalName("Assembly-CSharp.dll", "", "Type")]
	public enum Type
	{
		Polygon,
		Parallelogram,
		BlobbyCross,
		Rhombus,
		Segment,
		RoundedBox,
		Circle,
		RoundedCross,
		EquilateralTriangle,
		Polygon10
	}

	[OriginalName("Assembly-CSharp.dll", "", "Operation")]
	public enum Operation
	{
		Union,
		Intersection,
		Subtraction
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_OutlineSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_OutlineColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_OutlineKnockout;

	private static readonly System.IntPtr NativeFieldInfoPtr_SDFDataCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_SDFData0;

	private static readonly System.IntPtr NativeFieldInfoPtr_Polygons0;

	private static readonly System.IntPtr NativeFieldInfoPtr_PolygonCount0;

	private static readonly System.IntPtr NativeFieldInfoPtr_SDFData1;

	private static readonly System.IntPtr NativeFieldInfoPtr_Polygons1;

	private static readonly System.IntPtr NativeFieldInfoPtr_PolygonCount1;

	private static readonly System.IntPtr NativeFieldInfoPtr_SDFData2;

	private static readonly System.IntPtr NativeFieldInfoPtr_Polygons2;

	private static readonly System.IntPtr NativeFieldInfoPtr_PolygonCount2;

	private static readonly System.IntPtr NativeFieldInfoPtr_SDFData3;

	private static readonly System.IntPtr NativeFieldInfoPtr_Polygons3;

	private static readonly System.IntPtr NativeFieldInfoPtr_PolygonCount3;

	private static readonly System.IntPtr NativeFieldInfoPtr_SampleSDFSoft;

	private static readonly System.IntPtr NativeFieldInfoPtr_Softness;

	private static readonly System.IntPtr NativeFieldInfoPtr_SampleOutlineSoft;

	private static readonly System.IntPtr NativeFieldInfoPtr_OutlineSoftness;

	private static readonly System.IntPtr NativeMethodInfoPtr_ConvertToMatrixArray_Public_Static_Matrix4x4_UberSDF_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ConvertToMatrixArray_Public_Static_Matrix4x4_UberSDFSO_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CopyTo_Public_Static_Void_UberSDF_UberSDF_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CopyTo_Public_Static_Void_UberSDFSO_UberSDF_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BlendToSO_Public_Static_Void_UberSDF_UberSDFSO_Single_0;

	public unsafe static int OutlineSize
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OutlineSize, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OutlineSize, (void*)(&num));
		}
	}

	public unsafe static int OutlineColor
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OutlineColor, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OutlineColor, (void*)(&num));
		}
	}

	public unsafe static int OutlineKnockout
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OutlineKnockout, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OutlineKnockout, (void*)(&num));
		}
	}

	public unsafe static int SDFDataCount
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SDFDataCount, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SDFDataCount, (void*)(&num));
		}
	}

	public unsafe static int SDFData0
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SDFData0, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SDFData0, (void*)(&num));
		}
	}

	public unsafe static int Polygons0
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Polygons0, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Polygons0, (void*)(&num));
		}
	}

	public unsafe static int PolygonCount0
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PolygonCount0, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PolygonCount0, (void*)(&num));
		}
	}

	public unsafe static int SDFData1
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SDFData1, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SDFData1, (void*)(&num));
		}
	}

	public unsafe static int Polygons1
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Polygons1, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Polygons1, (void*)(&num));
		}
	}

	public unsafe static int PolygonCount1
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PolygonCount1, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PolygonCount1, (void*)(&num));
		}
	}

	public unsafe static int SDFData2
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SDFData2, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SDFData2, (void*)(&num));
		}
	}

	public unsafe static int Polygons2
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Polygons2, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Polygons2, (void*)(&num));
		}
	}

	public unsafe static int PolygonCount2
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PolygonCount2, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PolygonCount2, (void*)(&num));
		}
	}

	public unsafe static int SDFData3
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SDFData3, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SDFData3, (void*)(&num));
		}
	}

	public unsafe static int Polygons3
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Polygons3, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Polygons3, (void*)(&num));
		}
	}

	public unsafe static int PolygonCount3
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PolygonCount3, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PolygonCount3, (void*)(&num));
		}
	}

	public unsafe static int SampleSDFSoft
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SampleSDFSoft, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SampleSDFSoft, (void*)(&num));
		}
	}

	public unsafe static int Softness
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Softness, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Softness, (void*)(&num));
		}
	}

	public unsafe static int SampleOutlineSoft
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SampleOutlineSoft, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SampleOutlineSoft, (void*)(&num));
		}
	}

	public unsafe static int OutlineSoftness
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OutlineSoftness, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OutlineSoftness, (void*)(&num));
		}
	}

	static SDF()
	{
		Il2CppClassPointerStore<SDF>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "SDF");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SDF>.NativeClassPtr);
		NativeFieldInfoPtr_OutlineSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "OutlineSize");
		NativeFieldInfoPtr_OutlineColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "OutlineColor");
		NativeFieldInfoPtr_OutlineKnockout = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "OutlineKnockout");
		NativeFieldInfoPtr_SDFDataCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "SDFDataCount");
		NativeFieldInfoPtr_SDFData0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "SDFData0");
		NativeFieldInfoPtr_Polygons0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "Polygons0");
		NativeFieldInfoPtr_PolygonCount0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "PolygonCount0");
		NativeFieldInfoPtr_SDFData1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "SDFData1");
		NativeFieldInfoPtr_Polygons1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "Polygons1");
		NativeFieldInfoPtr_PolygonCount1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "PolygonCount1");
		NativeFieldInfoPtr_SDFData2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "SDFData2");
		NativeFieldInfoPtr_Polygons2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "Polygons2");
		NativeFieldInfoPtr_PolygonCount2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "PolygonCount2");
		NativeFieldInfoPtr_SDFData3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "SDFData3");
		NativeFieldInfoPtr_Polygons3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "Polygons3");
		NativeFieldInfoPtr_PolygonCount3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "PolygonCount3");
		NativeFieldInfoPtr_SampleSDFSoft = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "SampleSDFSoft");
		NativeFieldInfoPtr_Softness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "Softness");
		NativeFieldInfoPtr_SampleOutlineSoft = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "SampleOutlineSoft");
		NativeFieldInfoPtr_OutlineSoftness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SDF>.NativeClassPtr, "OutlineSoftness");
		NativeMethodInfoPtr_ConvertToMatrixArray_Public_Static_Matrix4x4_UberSDF_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SDF>.NativeClassPtr, 100671118);
		NativeMethodInfoPtr_ConvertToMatrixArray_Public_Static_Matrix4x4_UberSDFSO_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SDF>.NativeClassPtr, 100671119);
		NativeMethodInfoPtr_CopyTo_Public_Static_Void_UberSDF_UberSDF_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SDF>.NativeClassPtr, 100671120);
		NativeMethodInfoPtr_CopyTo_Public_Static_Void_UberSDFSO_UberSDF_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SDF>.NativeClassPtr, 100671121);
		NativeMethodInfoPtr_BlendToSO_Public_Static_Void_UberSDF_UberSDFSO_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SDF>.NativeClassPtr, 100671122);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107586, XrefRangeEnd = 107587, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Matrix4x4 ConvertToMatrixArray(this UberSDF sdf)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sdf);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ConvertToMatrixArray_Public_Static_Matrix4x4_UberSDF_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Matrix4x4*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107587, XrefRangeEnd = 107588, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Matrix4x4 ConvertToMatrixArray(this UberSDFSO sdfso)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sdfso);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ConvertToMatrixArray_Public_Static_Matrix4x4_UberSDFSO_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Matrix4x4*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107588, XrefRangeEnd = 107591, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CopyTo(this UberSDF source, UberSDF target)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)source);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CopyTo_Public_Static_Void_UberSDF_UberSDF_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107591, XrefRangeEnd = 107594, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CopyTo(this UberSDFSO source, UberSDF target)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)source);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CopyTo_Public_Static_Void_UberSDFSO_UberSDF_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 107634, RefRangeEnd = 107635, XrefRangeStart = 107594, XrefRangeEnd = 107634, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void BlendToSO(this UberSDF target, UberSDFSO source, float blend)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)source);
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &blend;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BlendToSO_Public_Static_Void_UberSDF_UberSDFSO_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SDF(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

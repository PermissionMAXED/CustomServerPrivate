using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UberSDFSO : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_Type;

	private static readonly IntPtr NativeFieldInfoPtr_OpType;

	private static readonly IntPtr NativeFieldInfoPtr_Roundness;

	private static readonly IntPtr NativeFieldInfoPtr_ShapeInfo1;

	private static readonly IntPtr NativeFieldInfoPtr_ShapeInfo2;

	private static readonly IntPtr NativeFieldInfoPtr_ShapeInfo3;

	private static readonly IntPtr NativeFieldInfoPtr_ShapeInfo4;

	private static readonly IntPtr NativeFieldInfoPtr_OffsetX;

	private static readonly IntPtr NativeFieldInfoPtr_OffsetY;

	private static readonly IntPtr NativeFieldInfoPtr_Rotation;

	private static readonly IntPtr NativeFieldInfoPtr_Scale;

	private static readonly IntPtr NativeFieldInfoPtr_PolygonPointCount;

	private static readonly IntPtr NativeFieldInfoPtr_Point0;

	private static readonly IntPtr NativeFieldInfoPtr_Point1;

	private static readonly IntPtr NativeFieldInfoPtr_Point2;

	private static readonly IntPtr NativeFieldInfoPtr_Point3;

	private static readonly IntPtr NativeFieldInfoPtr_Point4;

	private static readonly IntPtr NativeFieldInfoPtr_Point5;

	private static readonly IntPtr NativeFieldInfoPtr_Point6;

	private static readonly IntPtr NativeFieldInfoPtr_Point7;

	private static readonly IntPtr NativeFieldInfoPtr_Point8;

	private static readonly IntPtr NativeFieldInfoPtr_Point9;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe SDF.Type Type
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Type);
			return *(SDF.Type*)num;
		}
		set
		{
			*(SDF.Type*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Type)) = type;
		}
	}

	public unsafe SDF.Operation OpType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OpType);
			return *(SDF.Operation*)num;
		}
		set
		{
			*(SDF.Operation*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OpType)) = operation;
		}
	}

	public unsafe float Roundness
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Roundness);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Roundness)) = num;
		}
	}

	public unsafe float ShapeInfo1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo1);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo1)) = num;
		}
	}

	public unsafe float ShapeInfo2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo2);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo2)) = num;
		}
	}

	public unsafe float ShapeInfo3
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo3);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo3)) = num;
		}
	}

	public unsafe float ShapeInfo4
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo4);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ShapeInfo4)) = num;
		}
	}

	public unsafe float OffsetX
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OffsetX);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OffsetX)) = num;
		}
	}

	public unsafe float OffsetY
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OffsetY);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OffsetY)) = num;
		}
	}

	public unsafe float Rotation
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Rotation);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Rotation)) = num;
		}
	}

	public unsafe float Scale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Scale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Scale)) = num;
		}
	}

	public unsafe int PolygonPointCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PolygonPointCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PolygonPointCount)) = num;
		}
	}

	public unsafe Vector4 Point0
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point0);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point0)) = vector;
		}
	}

	public unsafe Vector4 Point1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point1);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point1)) = vector;
		}
	}

	public unsafe Vector4 Point2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point2);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point2)) = vector;
		}
	}

	public unsafe Vector4 Point3
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point3);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point3)) = vector;
		}
	}

	public unsafe Vector4 Point4
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point4);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point4)) = vector;
		}
	}

	public unsafe Vector4 Point5
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point5);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point5)) = vector;
		}
	}

	public unsafe Vector4 Point6
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point6);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point6)) = vector;
		}
	}

	public unsafe Vector4 Point7
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point7);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point7)) = vector;
		}
	}

	public unsafe Vector4 Point8
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point8);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point8)) = vector;
		}
	}

	public unsafe Vector4 Point9
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point9);
			return *(Vector4*)num;
		}
		set
		{
			*(Vector4*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Point9)) = vector;
		}
	}

	static UberSDFSO()
	{
		Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UberSDFSO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr);
		NativeFieldInfoPtr_Type = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Type");
		NativeFieldInfoPtr_OpType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "OpType");
		NativeFieldInfoPtr_Roundness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Roundness");
		NativeFieldInfoPtr_ShapeInfo1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "ShapeInfo1");
		NativeFieldInfoPtr_ShapeInfo2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "ShapeInfo2");
		NativeFieldInfoPtr_ShapeInfo3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "ShapeInfo3");
		NativeFieldInfoPtr_ShapeInfo4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "ShapeInfo4");
		NativeFieldInfoPtr_OffsetX = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "OffsetX");
		NativeFieldInfoPtr_OffsetY = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "OffsetY");
		NativeFieldInfoPtr_Rotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Rotation");
		NativeFieldInfoPtr_Scale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Scale");
		NativeFieldInfoPtr_PolygonPointCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "PolygonPointCount");
		NativeFieldInfoPtr_Point0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point0");
		NativeFieldInfoPtr_Point1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point1");
		NativeFieldInfoPtr_Point2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point2");
		NativeFieldInfoPtr_Point3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point3");
		NativeFieldInfoPtr_Point4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point4");
		NativeFieldInfoPtr_Point5 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point5");
		NativeFieldInfoPtr_Point6 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point6");
		NativeFieldInfoPtr_Point7 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point7");
		NativeFieldInfoPtr_Point8 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point8");
		NativeFieldInfoPtr_Point9 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, "Point9");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr, 100671158);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107713, XrefRangeEnd = 107714, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UberSDFSO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UberSDFSO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UberSDFSO(IntPtr pointer)
		: base(pointer)
	{
	}
}

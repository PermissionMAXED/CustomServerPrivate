using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Geometry;

public class AreaFillShapeCreator : MeshShapeCreator
{
	private static readonly IntPtr NativeFieldInfoPtr_generate;

	private static readonly IntPtr NativeFieldInfoPtr_prefabs;

	private static readonly IntPtr NativeFieldInfoPtr_randomizeRotation;

	private static readonly IntPtr NativeFieldInfoPtr_rotationRange;

	private static readonly IntPtr NativeFieldInfoPtr_randomizeScale;

	private static readonly IntPtr NativeFieldInfoPtr_scaleRange;

	private static readonly IntPtr NativeFieldInfoPtr_maxInstances;

	private static readonly IntPtr NativeFieldInfoPtr_checkForCollisions;

	private static readonly IntPtr NativeFieldInfoPtr_collisionCheckBoundsMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_collisionIterationRadius;

	private static readonly IntPtr NativeFieldInfoPtr_collisionIterations;

	private static readonly IntPtr NativeFieldInfoPtr_layersMask;

	private static readonly IntPtr NativeFieldInfoPtr_colliderBuffer;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0;

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

	public unsafe Il2CppReferenceArray<GameObject> prefabs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabs);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe bool randomizeRotation
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomizeRotation);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomizeRotation)) = flag;
		}
	}

	public unsafe Vector2 rotationRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationRange);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationRange)) = vector;
		}
	}

	public unsafe bool randomizeScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomizeScale);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomizeScale)) = flag;
		}
	}

	public unsafe Vector2 scaleRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_scaleRange);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_scaleRange)) = vector;
		}
	}

	public unsafe int maxInstances
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxInstances);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxInstances)) = num;
		}
	}

	public unsafe bool checkForCollisions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForCollisions);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForCollisions)) = flag;
		}
	}

	public unsafe float collisionCheckBoundsMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionCheckBoundsMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionCheckBoundsMultiplier)) = num;
		}
	}

	public unsafe float collisionIterationRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionIterationRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionIterationRadius)) = num;
		}
	}

	public unsafe int collisionIterations
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionIterations);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collisionIterations)) = num;
		}
	}

	public unsafe LayerMask layersMask
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layersMask);
			return *(LayerMask*)num;
		}
		set
		{
			*(LayerMask*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layersMask)) = layerMask;
		}
	}

	public unsafe Il2CppReferenceArray<Collider> colliderBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colliderBuffer);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Collider>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colliderBuffer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static AreaFillShapeCreator()
	{
		Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Geometry", "AreaFillShapeCreator");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr);
		NativeFieldInfoPtr_generate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "generate");
		NativeFieldInfoPtr_prefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "prefabs");
		NativeFieldInfoPtr_randomizeRotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "randomizeRotation");
		NativeFieldInfoPtr_rotationRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "rotationRange");
		NativeFieldInfoPtr_randomizeScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "randomizeScale");
		NativeFieldInfoPtr_scaleRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "scaleRange");
		NativeFieldInfoPtr_maxInstances = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "maxInstances");
		NativeFieldInfoPtr_checkForCollisions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "checkForCollisions");
		NativeFieldInfoPtr_collisionCheckBoundsMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "collisionCheckBoundsMultiplier");
		NativeFieldInfoPtr_collisionIterationRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "collisionIterationRadius");
		NativeFieldInfoPtr_collisionIterations = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "collisionIterations");
		NativeFieldInfoPtr_layersMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "layersMask");
		NativeFieldInfoPtr_colliderBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, "colliderBuffer");
		NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, 100685174);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr, 100685175);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233419, XrefRangeEnd = 233521, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void UpdateShapeDisplay(bool fullRefresh = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&fullRefresh);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 233521, XrefRangeEnd = 233524, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AreaFillShapeCreator()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AreaFillShapeCreator>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public AreaFillShapeCreator(IntPtr pointer)
		: base(pointer)
	{
	}
}

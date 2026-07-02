using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class CameraFPS : CameraDriver
{
	private static readonly IntPtr NativeFieldInfoPtr_baseFov;

	private static readonly IntPtr NativeFieldInfoPtr_yHeight;

	private static readonly IntPtr NativeFieldInfoPtr_posOffset;

	private static readonly IntPtr NativeFieldInfoPtr_dynamicLoaderAreaConfig;

	private static readonly IntPtr NativeFieldInfoPtr_sensitivity;

	private static readonly IntPtr NativeFieldInfoPtr_forwardOffset;

	private static readonly IntPtr NativeFieldInfoPtr_rotOffset;

	private static readonly IntPtr NativeFieldInfoPtr_headBobYPosCurve;

	private static readonly IntPtr NativeFieldInfoPtr_headBobRotCurve;

	private static readonly IntPtr NativeFieldInfoPtr_movingSpeedMult;

	private static readonly IntPtr NativeFieldInfoPtr_headBobAnimSpeed;

	private static readonly IntPtr NativeFieldInfoPtr_headBobPosIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_headBobRotIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_lateralRotationLimit;

	private static readonly IntPtr NativeFieldInfoPtr_lateralRotationSpeed;

	private static readonly IntPtr NativeFieldInfoPtr_lateralRotationAimIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_lateralRotationMoveIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_lookRot;

	private static readonly IntPtr NativeFieldInfoPtr_headBobAnimTimer;

	private static readonly IntPtr NativeFieldInfoPtr_bobMovingFactor;

	private static readonly IntPtr NativeFieldInfoPtr_lateralRotLerped;

	private static readonly IntPtr NativeMethodInfoPtr_Initialize_Public_Virtual_Void_CameraController_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDriverEnable_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDriverDisable_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnCamLockInputPressed_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnLateUpdate_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Snap_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetCameraPosition_Public_Virtual_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float baseFov
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseFov);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseFov)) = num;
		}
	}

	public unsafe float yHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_yHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_yHeight)) = num;
		}
	}

	public unsafe Vector3 posOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posOffset)) = vector;
		}
	}

	public unsafe DynamicChunkLoader.AreaConfig dynamicLoaderAreaConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dynamicLoaderAreaConfig);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DynamicChunkLoader.AreaConfig>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dynamicLoaderAreaConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)areaConfig));
		}
	}

	public unsafe float sensitivity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sensitivity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sensitivity)) = num;
		}
	}

	public unsafe float forwardOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_forwardOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_forwardOffset)) = num;
		}
	}

	public unsafe float rotOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotOffset)) = num;
		}
	}

	public unsafe AnimationCurve headBobYPosCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobYPosCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobYPosCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe AnimationCurve headBobRotCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobRotCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobRotCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float movingSpeedMult
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_movingSpeedMult);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_movingSpeedMult)) = num;
		}
	}

	public unsafe float headBobAnimSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobAnimSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobAnimSpeed)) = num;
		}
	}

	public unsafe float headBobPosIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobPosIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobPosIntensity)) = num;
		}
	}

	public unsafe float headBobRotIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobRotIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobRotIntensity)) = num;
		}
	}

	public unsafe float lateralRotationLimit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationLimit);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationLimit)) = num;
		}
	}

	public unsafe float lateralRotationSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationSpeed)) = num;
		}
	}

	public unsafe float lateralRotationAimIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationAimIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationAimIntensity)) = num;
		}
	}

	public unsafe float lateralRotationMoveIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationMoveIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotationMoveIntensity)) = num;
		}
	}

	public unsafe Vector2 lookRot
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lookRot);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lookRot)) = vector;
		}
	}

	public unsafe float headBobAnimTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobAnimTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_headBobAnimTimer)) = num;
		}
	}

	public unsafe float bobMovingFactor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bobMovingFactor);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bobMovingFactor)) = num;
		}
	}

	public unsafe float lateralRotLerped
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotLerped);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lateralRotLerped)) = num;
		}
	}

	static CameraFPS()
	{
		Il2CppClassPointerStore<CameraFPS>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "CameraFPS");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr);
		NativeFieldInfoPtr_baseFov = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "baseFov");
		NativeFieldInfoPtr_yHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "yHeight");
		NativeFieldInfoPtr_posOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "posOffset");
		NativeFieldInfoPtr_dynamicLoaderAreaConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "dynamicLoaderAreaConfig");
		NativeFieldInfoPtr_sensitivity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "sensitivity");
		NativeFieldInfoPtr_forwardOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "forwardOffset");
		NativeFieldInfoPtr_rotOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "rotOffset");
		NativeFieldInfoPtr_headBobYPosCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "headBobYPosCurve");
		NativeFieldInfoPtr_headBobRotCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "headBobRotCurve");
		NativeFieldInfoPtr_movingSpeedMult = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "movingSpeedMult");
		NativeFieldInfoPtr_headBobAnimSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "headBobAnimSpeed");
		NativeFieldInfoPtr_headBobPosIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "headBobPosIntensity");
		NativeFieldInfoPtr_headBobRotIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "headBobRotIntensity");
		NativeFieldInfoPtr_lateralRotationLimit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "lateralRotationLimit");
		NativeFieldInfoPtr_lateralRotationSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "lateralRotationSpeed");
		NativeFieldInfoPtr_lateralRotationAimIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "lateralRotationAimIntensity");
		NativeFieldInfoPtr_lateralRotationMoveIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "lateralRotationMoveIntensity");
		NativeFieldInfoPtr_lookRot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "lookRot");
		NativeFieldInfoPtr_headBobAnimTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "headBobAnimTimer");
		NativeFieldInfoPtr_bobMovingFactor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "bobMovingFactor");
		NativeFieldInfoPtr_lateralRotLerped = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, "lateralRotLerped");
		NativeMethodInfoPtr_Initialize_Public_Virtual_Void_CameraController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683809);
		NativeMethodInfoPtr_OnDriverEnable_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683810);
		NativeMethodInfoPtr_OnDriverDisable_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683811);
		NativeMethodInfoPtr_OnCamLockInputPressed_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683812);
		NativeMethodInfoPtr_OnLateUpdate_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683813);
		NativeMethodInfoPtr_Snap_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683814);
		NativeMethodInfoPtr_GetCameraPosition_Public_Virtual_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683815);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr, 100683816);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 33834, RefRangeEnd = 33842, XrefRangeStart = 33834, XrefRangeEnd = 33842, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Initialize(CameraController _controller)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_controller);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Initialize_Public_Virtual_Void_CameraController_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 222965, XrefRangeEnd = 222970, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnDriverEnable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnDriverEnable_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 222970, XrefRangeEnd = 222971, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnDriverDisable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnDriverDisable_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 222971, XrefRangeEnd = 222972, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnCamLockInputPressed()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnCamLockInputPressed_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 222972, XrefRangeEnd = 222990, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnLateUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnLateUpdate_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 222990, XrefRangeEnd = 222992, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Snap()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Snap_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 222992, XrefRangeEnd = 223015, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override Vector3 GetCameraPosition()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetCameraPosition_Public_Virtual_Vector3_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223015, XrefRangeEnd = 223018, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CameraFPS()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CameraFPS>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CameraFPS(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class CameraShake : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_maxShakeOffset;

	private static readonly IntPtr NativeFieldInfoPtr_shakeSpeed;

	private static readonly IntPtr NativeFieldInfoPtr_traumaDecay;

	private static readonly IntPtr NativeFieldInfoPtr_trauma;

	private static readonly IntPtr NativeFieldInfoPtr_perlinNoiseOffset;

	private static readonly IntPtr NativeFieldInfoPtr_shakeOffset;

	private static readonly IntPtr NativeFieldInfoPtr_intensityMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_kickPowerCurve;

	private static readonly IntPtr NativeFieldInfoPtr_kickDuration;

	private static readonly IntPtr NativeFieldInfoPtr_maxKickOffset;

	private static readonly IntPtr NativeFieldInfoPtr_kickPower;

	private static readonly IntPtr NativeFieldInfoPtr_kickOffset;

	private static readonly IntPtr NativeFieldInfoPtr_kickElapsed;

	private static readonly IntPtr NativeFieldInfoPtr_kickDirection;

	private static readonly IntPtr NativeMethodInfoPtr_LateUpdate_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ResetAllShakes_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ResetShake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ResetKick_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_AddShakeTrauma_Public_Void_Single_Boolean_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_DoKick_Public_Void_Single_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float maxShakeOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxShakeOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxShakeOffset)) = num;
		}
	}

	public unsafe float shakeSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shakeSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shakeSpeed)) = num;
		}
	}

	public unsafe float traumaDecay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_traumaDecay);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_traumaDecay)) = num;
		}
	}

	public unsafe float trauma
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trauma);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trauma)) = num;
		}
	}

	public unsafe float perlinNoiseOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_perlinNoiseOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_perlinNoiseOffset)) = num;
		}
	}

	public unsafe Vector3 shakeOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shakeOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shakeOffset)) = vector;
		}
	}

	public unsafe float intensityMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_intensityMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_intensityMultiplier)) = num;
		}
	}

	public unsafe AnimationCurve kickPowerCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickPowerCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickPowerCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float kickDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickDuration)) = num;
		}
	}

	public unsafe float maxKickOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxKickOffset);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxKickOffset)) = num;
		}
	}

	public unsafe float kickPower
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickPower);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickPower)) = num;
		}
	}

	public unsafe Vector3 kickOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickOffset)) = vector;
		}
	}

	public unsafe float kickElapsed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickElapsed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickElapsed)) = num;
		}
	}

	public unsafe Vector3 kickDirection
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickDirection);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kickDirection)) = vector;
		}
	}

	static CameraShake()
	{
		Il2CppClassPointerStore<CameraShake>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "CameraShake");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CameraShake>.NativeClassPtr);
		NativeFieldInfoPtr_maxShakeOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "maxShakeOffset");
		NativeFieldInfoPtr_shakeSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "shakeSpeed");
		NativeFieldInfoPtr_traumaDecay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "traumaDecay");
		NativeFieldInfoPtr_trauma = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "trauma");
		NativeFieldInfoPtr_perlinNoiseOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "perlinNoiseOffset");
		NativeFieldInfoPtr_shakeOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "shakeOffset");
		NativeFieldInfoPtr_intensityMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "intensityMultiplier");
		NativeFieldInfoPtr_kickPowerCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "kickPowerCurve");
		NativeFieldInfoPtr_kickDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "kickDuration");
		NativeFieldInfoPtr_maxKickOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "maxKickOffset");
		NativeFieldInfoPtr_kickPower = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "kickPower");
		NativeFieldInfoPtr_kickOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "kickOffset");
		NativeFieldInfoPtr_kickElapsed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "kickElapsed");
		NativeFieldInfoPtr_kickDirection = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, "kickDirection");
		NativeMethodInfoPtr_LateUpdate_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, 100683878);
		NativeMethodInfoPtr_ResetAllShakes_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, 100683879);
		NativeMethodInfoPtr_ResetShake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, 100683880);
		NativeMethodInfoPtr_ResetKick_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, 100683881);
		NativeMethodInfoPtr_AddShakeTrauma_Public_Void_Single_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, 100683882);
		NativeMethodInfoPtr_DoKick_Public_Void_Single_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, 100683883);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraShake>.NativeClassPtr, 100683884);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223297, XrefRangeEnd = 223314, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LateUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LateUpdate_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223314, XrefRangeEnd = 223316, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ResetAllShakes()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResetAllShakes_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 223320, RefRangeEnd = 223323, XrefRangeStart = 223316, XrefRangeEnd = 223320, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ResetShake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResetShake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 223327, RefRangeEnd = 223331, XrefRangeStart = 223323, XrefRangeEnd = 223327, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ResetKick()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResetKick_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(21)]
	[CachedScanResults(RefRangeStart = 223333, RefRangeEnd = 223354, XrefRangeStart = 223331, XrefRangeEnd = 223333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddShakeTrauma(float _trauma, bool isTranslation = true, bool isRotational = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&_trauma);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &isTranslation;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isRotational;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddShakeTrauma_Public_Void_Single_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(18)]
	[CachedScanResults(RefRangeStart = 223357, RefRangeEnd = 223375, XrefRangeStart = 223354, XrefRangeEnd = 223357, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DoKick(float power, Vector3 normDir)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&power);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &normDir;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DoKick_Public_Void_Single_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223375, XrefRangeEnd = 223376, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CameraShake()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CameraShake>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CameraShake(IntPtr pointer)
		: base(pointer)
	{
	}
}

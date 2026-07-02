using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.UI;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class CameraTopDown : CameraDriver
{
	private static readonly IntPtr NativeFieldInfoPtr_uiManager;

	private static readonly IntPtr NativeFieldInfoPtr_baseFov;

	private static readonly IntPtr NativeFieldInfoPtr_pitch;

	private static readonly IntPtr NativeFieldInfoPtr_yHeight;

	private static readonly IntPtr NativeFieldInfoPtr_posOffset;

	private static readonly IntPtr NativeFieldInfoPtr_smoothTime;

	private static readonly IntPtr NativeFieldInfoPtr_mouseOffsetDistance;

	private static readonly IntPtr NativeFieldInfoPtr_checkObscurance;

	private static readonly IntPtr NativeFieldInfoPtr_obscuredPitch;

	private static readonly IntPtr NativeFieldInfoPtr_obscuredPitchTime;

	private static readonly IntPtr NativeFieldInfoPtr_checkObscuranceTickRate;

	private static readonly IntPtr NativeFieldInfoPtr_doScrollWheel;

	private static readonly IntPtr NativeFieldInfoPtr_outBaseFov;

	private static readonly IntPtr NativeFieldInfoPtr_outPitch;

	private static readonly IntPtr NativeFieldInfoPtr_outYHeight;

	private static readonly IntPtr NativeFieldInfoPtr_outPosOffset;

	private static readonly IntPtr NativeFieldInfoPtr_proximityZoomWorldRange;

	private static readonly IntPtr NativeFieldInfoPtr_minBaseFov;

	private static readonly IntPtr NativeFieldInfoPtr_minPitch;

	private static readonly IntPtr NativeFieldInfoPtr_minYHeight;

	private static readonly IntPtr NativeFieldInfoPtr_minPosOffset;

	private static readonly IntPtr NativeFieldInfoPtr_dampVelocity1;

	private static readonly IntPtr NativeFieldInfoPtr_dampVelocity2;

	private static readonly IntPtr NativeFieldInfoPtr_currentYHeight;

	private static readonly IntPtr NativeFieldInfoPtr_currentPosOffset;

	private static readonly IntPtr NativeFieldInfoPtr_mouseOffset;

	private static readonly IntPtr NativeFieldInfoPtr_posDampVelocity;

	private static readonly IntPtr NativeFieldInfoPtr_camPos;

	private static readonly IntPtr NativeFieldInfoPtr_zoomMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_fovMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_baseOffset;

	private static readonly IntPtr NativeFieldInfoPtr_invPitch;

	private static readonly IntPtr NativeFieldInfoPtr_baseOffsetZ;

	private static readonly IntPtr NativeFieldInfoPtr_currentCamLerpValue;

	private static readonly IntPtr NativeFieldInfoPtr_obscured;

	private static readonly IntPtr NativeFieldInfoPtr_obscuredCurrentTime;

	private static readonly IntPtr NativeFieldInfoPtr_obscuredLerp;

	private static readonly IntPtr NativeFieldInfoPtr_lastObscuredCheckTime;

	private static readonly IntPtr NativeMethodInfoPtr_get_Pitch_Public_get_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_BaseFov_Public_get_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Initialize_Public_Virtual_Void_CameraController_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDriverEnable_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ResetCameraLerp_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleCheckObscurance_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateObscured_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnLateUpdate_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Snap_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Zoom_Public_Virtual_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_ResetZoom_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetFoVMultiplier_Public_Virtual_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetCameraPosition_Public_Virtual_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetProximityTargetAvgOffset_Private_Void_Vector3_byref_Vector3_byref_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetCameraFov_Private_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_CalculateBaseOffset_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_CalculateFairCenterMultiplier_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_CalculateMouseOffset_Protected_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe UIManager uiManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UIManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIManager));
		}
	}

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

	public unsafe float pitch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pitch);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pitch)) = num;
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

	public unsafe float smoothTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_smoothTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_smoothTime)) = num;
		}
	}

	public unsafe float mouseOffsetDistance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mouseOffsetDistance);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mouseOffsetDistance)) = num;
		}
	}

	public unsafe bool checkObscurance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkObscurance);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkObscurance)) = flag;
		}
	}

	public unsafe float obscuredPitch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredPitch);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredPitch)) = num;
		}
	}

	public unsafe float obscuredPitchTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredPitchTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredPitchTime)) = num;
		}
	}

	public unsafe float checkObscuranceTickRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkObscuranceTickRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkObscuranceTickRate)) = num;
		}
	}

	public unsafe bool doScrollWheel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doScrollWheel);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doScrollWheel)) = flag;
		}
	}

	public unsafe float outBaseFov
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outBaseFov);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outBaseFov)) = num;
		}
	}

	public unsafe float outPitch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outPitch);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outPitch)) = num;
		}
	}

	public unsafe float outYHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outYHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outYHeight)) = num;
		}
	}

	public unsafe Vector3 outPosOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outPosOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outPosOffset)) = vector;
		}
	}

	public unsafe float proximityZoomWorldRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_proximityZoomWorldRange);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_proximityZoomWorldRange)) = num;
		}
	}

	public unsafe float minBaseFov
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minBaseFov);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minBaseFov)) = num;
		}
	}

	public unsafe float minPitch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minPitch);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minPitch)) = num;
		}
	}

	public unsafe float minYHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minYHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minYHeight)) = num;
		}
	}

	public unsafe Vector3 minPosOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minPosOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minPosOffset)) = vector;
		}
	}

	public unsafe float dampVelocity1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dampVelocity1);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dampVelocity1)) = num;
		}
	}

	public unsafe Vector3 dampVelocity2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dampVelocity2);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dampVelocity2)) = vector;
		}
	}

	public unsafe float currentYHeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentYHeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentYHeight)) = num;
		}
	}

	public unsafe Vector3 currentPosOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentPosOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentPosOffset)) = vector;
		}
	}

	public unsafe Vector3 mouseOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mouseOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mouseOffset)) = vector;
		}
	}

	public unsafe Vector3 posDampVelocity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posDampVelocity);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posDampVelocity)) = vector;
		}
	}

	public unsafe Vector3 camPos
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_camPos);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_camPos)) = vector;
		}
	}

	public unsafe float zoomMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoomMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoomMultiplier)) = num;
		}
	}

	public unsafe float fovMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fovMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fovMultiplier)) = num;
		}
	}

	public unsafe Vector3 baseOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseOffset)) = vector;
		}
	}

	public unsafe float invPitch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invPitch);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invPitch)) = num;
		}
	}

	public unsafe float baseOffsetZ
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseOffsetZ);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseOffsetZ)) = num;
		}
	}

	public unsafe float currentCamLerpValue
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentCamLerpValue);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentCamLerpValue)) = num;
		}
	}

	public unsafe bool obscured
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscured);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscured)) = flag;
		}
	}

	public unsafe float obscuredCurrentTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredCurrentTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredCurrentTime)) = num;
		}
	}

	public unsafe float obscuredLerp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredLerp);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obscuredLerp)) = num;
		}
	}

	public unsafe float lastObscuredCheckTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastObscuredCheckTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastObscuredCheckTime)) = num;
		}
	}

	public unsafe float Pitch
	{
		[CallerCount(11)]
		[CachedScanResults(RefRangeStart = 42308, RefRangeEnd = 42319, XrefRangeStart = 42308, XrefRangeEnd = 42319, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Pitch_Public_get_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe float BaseFov
	{
		[CallerCount(54)]
		[CachedScanResults(RefRangeStart = 107425, RefRangeEnd = 107479, XrefRangeStart = 107425, XrefRangeEnd = 107479, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_BaseFov_Public_get_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static CameraTopDown()
	{
		Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "CameraTopDown");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr);
		NativeFieldInfoPtr_uiManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "uiManager");
		NativeFieldInfoPtr_baseFov = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "baseFov");
		NativeFieldInfoPtr_pitch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "pitch");
		NativeFieldInfoPtr_yHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "yHeight");
		NativeFieldInfoPtr_posOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "posOffset");
		NativeFieldInfoPtr_smoothTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "smoothTime");
		NativeFieldInfoPtr_mouseOffsetDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "mouseOffsetDistance");
		NativeFieldInfoPtr_checkObscurance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "checkObscurance");
		NativeFieldInfoPtr_obscuredPitch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "obscuredPitch");
		NativeFieldInfoPtr_obscuredPitchTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "obscuredPitchTime");
		NativeFieldInfoPtr_checkObscuranceTickRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "checkObscuranceTickRate");
		NativeFieldInfoPtr_doScrollWheel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "doScrollWheel");
		NativeFieldInfoPtr_outBaseFov = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "outBaseFov");
		NativeFieldInfoPtr_outPitch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "outPitch");
		NativeFieldInfoPtr_outYHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "outYHeight");
		NativeFieldInfoPtr_outPosOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "outPosOffset");
		NativeFieldInfoPtr_proximityZoomWorldRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "proximityZoomWorldRange");
		NativeFieldInfoPtr_minBaseFov = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "minBaseFov");
		NativeFieldInfoPtr_minPitch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "minPitch");
		NativeFieldInfoPtr_minYHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "minYHeight");
		NativeFieldInfoPtr_minPosOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "minPosOffset");
		NativeFieldInfoPtr_dampVelocity1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "dampVelocity1");
		NativeFieldInfoPtr_dampVelocity2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "dampVelocity2");
		NativeFieldInfoPtr_currentYHeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "currentYHeight");
		NativeFieldInfoPtr_currentPosOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "currentPosOffset");
		NativeFieldInfoPtr_mouseOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "mouseOffset");
		NativeFieldInfoPtr_posDampVelocity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "posDampVelocity");
		NativeFieldInfoPtr_camPos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "camPos");
		NativeFieldInfoPtr_zoomMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "zoomMultiplier");
		NativeFieldInfoPtr_fovMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "fovMultiplier");
		NativeFieldInfoPtr_baseOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "baseOffset");
		NativeFieldInfoPtr_invPitch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "invPitch");
		NativeFieldInfoPtr_baseOffsetZ = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "baseOffsetZ");
		NativeFieldInfoPtr_currentCamLerpValue = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "currentCamLerpValue");
		NativeFieldInfoPtr_obscured = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "obscured");
		NativeFieldInfoPtr_obscuredCurrentTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "obscuredCurrentTime");
		NativeFieldInfoPtr_obscuredLerp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "obscuredLerp");
		NativeFieldInfoPtr_lastObscuredCheckTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, "lastObscuredCheckTime");
		NativeMethodInfoPtr_get_Pitch_Public_get_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683831);
		NativeMethodInfoPtr_get_BaseFov_Public_get_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683832);
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683833);
		NativeMethodInfoPtr_Initialize_Public_Virtual_Void_CameraController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683834);
		NativeMethodInfoPtr_OnDriverEnable_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683835);
		NativeMethodInfoPtr_ResetCameraLerp_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683836);
		NativeMethodInfoPtr_ToggleCheckObscurance_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683837);
		NativeMethodInfoPtr_UpdateObscured_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683838);
		NativeMethodInfoPtr_OnLateUpdate_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683839);
		NativeMethodInfoPtr_Snap_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683840);
		NativeMethodInfoPtr_Zoom_Public_Virtual_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683841);
		NativeMethodInfoPtr_ResetZoom_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683842);
		NativeMethodInfoPtr_SetFoVMultiplier_Public_Virtual_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683843);
		NativeMethodInfoPtr_GetCameraPosition_Public_Virtual_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683844);
		NativeMethodInfoPtr_GetProximityTargetAvgOffset_Private_Void_Vector3_byref_Vector3_byref_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683845);
		NativeMethodInfoPtr_GetCameraFov_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683846);
		NativeMethodInfoPtr_CalculateBaseOffset_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683847);
		NativeMethodInfoPtr_CalculateFairCenterMultiplier_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683848);
		NativeMethodInfoPtr_CalculateMouseOffset_Protected_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683849);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr, 100683850);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223068, XrefRangeEnd = 223069, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223069, XrefRangeEnd = 223070, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223070, XrefRangeEnd = 223076, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnDriverEnable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnDriverEnable_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void ResetCameraLerp()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResetCameraLerp_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 223076, RefRangeEnd = 223077, XrefRangeStart = 223076, XrefRangeEnd = 223076, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleCheckObscurance()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleCheckObscurance_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223077, XrefRangeEnd = 223083, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateObscured()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateObscured_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223083, XrefRangeEnd = 223128, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnLateUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnLateUpdate_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223128, XrefRangeEnd = 223131, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Snap()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Snap_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe override void Zoom(float _zoomMultiplier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&_zoomMultiplier);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Zoom_Public_Virtual_Void_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe override void ResetZoom()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_ResetZoom_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223131, XrefRangeEnd = 223132, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SetFoVMultiplier(float _fovMultiplier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&_fovMultiplier);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SetFoVMultiplier_Public_Virtual_Void_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223132, XrefRangeEnd = 223146, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override Vector3 GetCameraPosition()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetCameraPosition_Public_Virtual_Vector3_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 223164, RefRangeEnd = 223165, XrefRangeStart = 223146, XrefRangeEnd = 223164, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void GetProximityTargetAvgOffset(Vector3 sourceWorldPos, out Vector3 avgOffset, out float additiveZoom)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&sourceWorldPos);
		*(void**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = Unsafe.AsPointer(ref avgOffset);
		*(void**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = Unsafe.AsPointer(ref additiveZoom);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetProximityTargetAvgOffset_Private_Void_Vector3_byref_Vector3_byref_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223165, XrefRangeEnd = 223169, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float GetCameraFov()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCameraFov_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 223171, RefRangeEnd = 223173, XrefRangeStart = 223169, XrefRangeEnd = 223171, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CalculateBaseOffset()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateBaseOffset_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 223176, RefRangeEnd = 223178, XrefRangeStart = 223173, XrefRangeEnd = 223176, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CalculateFairCenterMultiplier()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateFairCenterMultiplier_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 223186, RefRangeEnd = 223187, XrefRangeStart = 223178, XrefRangeEnd = 223186, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 CalculateMouseOffset()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateMouseOffset_Protected_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 223187, XrefRangeEnd = 223190, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CameraTopDown()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CameraTopDown>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CameraTopDown(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Il2CppBAPBAP.UI;

public class UIHpBarCasting : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_castingBarFill;

	private static readonly IntPtr NativeFieldInfoPtr_castingResultBarFill;

	private static readonly IntPtr NativeFieldInfoPtr_castingBarGroup;

	private static readonly IntPtr NativeFieldInfoPtr_castingResultBarGroup;

	private static readonly IntPtr NativeFieldInfoPtr_castingColor;

	private static readonly IntPtr NativeFieldInfoPtr_channelingColor;

	private static readonly IntPtr NativeFieldInfoPtr_ultimateColor;

	private static readonly IntPtr NativeFieldInfoPtr_successColor;

	private static readonly IntPtr NativeFieldInfoPtr_failColor;

	private static readonly IntPtr NativeFieldInfoPtr_castResultDuration;

	private static readonly IntPtr NativeFieldInfoPtr_castResultFadeDuration;

	private static readonly IntPtr NativeFieldInfoPtr_castResultFadeCurve;

	private static readonly IntPtr NativeFieldInfoPtr_inactiveFadeDuration;

	private static readonly IntPtr NativeFieldInfoPtr_inactiveFadeCurve;

	private static readonly IntPtr NativeFieldInfoPtr_castResultTimeElapsed;

	private static readonly IntPtr NativeFieldInfoPtr_isCastResultDone;

	private static readonly IntPtr NativeFieldInfoPtr_prevTickNum;

	private static readonly IntPtr NativeFieldInfoPtr_barTimeElapsed;

	private static readonly IntPtr NativeFieldInfoPtr_isLerpingDone;

	private static readonly IntPtr NativeFieldInfoPtr_barTimeCache;

	private static readonly IntPtr NativeFieldInfoPtr_barDurationCache;

	private static readonly IntPtr NativeFieldInfoPtr_isChannelingCache;

	private static readonly IntPtr NativeFieldInfoPtr_doCastingFadeOut;

	private static readonly IntPtr NativeFieldInfoPtr_castingFadeStartTime;

	private static readonly IntPtr NativeFieldInfoPtr_castResultFadeStartTime;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Initialize_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Reset_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_TriggerCastingSuccess_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_TriggerCastingFail_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ToggleCastingTime_Public_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateCastingBar_Public_Void_Int32_Single_Single_Boolean_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_ManagedLateUpdate_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Image castingBarFill
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingBarFill);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingBarFill)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image castingResultBarFill
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingResultBarFill);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingResultBarFill)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe CanvasGroup castingBarGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingBarGroup);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingBarGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe CanvasGroup castingResultBarGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingResultBarGroup);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingResultBarGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe Color castingColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingColor)) = color;
		}
	}

	public unsafe Color channelingColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_channelingColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_channelingColor)) = color;
		}
	}

	public unsafe Color ultimateColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ultimateColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ultimateColor)) = color;
		}
	}

	public unsafe Color successColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_successColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_successColor)) = color;
		}
	}

	public unsafe Color failColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_failColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_failColor)) = color;
		}
	}

	public unsafe float castResultDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultDuration)) = num;
		}
	}

	public unsafe float castResultFadeDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultFadeDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultFadeDuration)) = num;
		}
	}

	public unsafe AnimationCurve castResultFadeCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultFadeCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultFadeCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float inactiveFadeDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inactiveFadeDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inactiveFadeDuration)) = num;
		}
	}

	public unsafe AnimationCurve inactiveFadeCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inactiveFadeCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inactiveFadeCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float castResultTimeElapsed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultTimeElapsed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultTimeElapsed)) = num;
		}
	}

	public unsafe bool isCastResultDone
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCastResultDone);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCastResultDone)) = flag;
		}
	}

	public unsafe int prevTickNum
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevTickNum);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevTickNum)) = num;
		}
	}

	public unsafe float barTimeElapsed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_barTimeElapsed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_barTimeElapsed)) = num;
		}
	}

	public unsafe bool isLerpingDone
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLerpingDone);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLerpingDone)) = flag;
		}
	}

	public unsafe float barTimeCache
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_barTimeCache);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_barTimeCache)) = num;
		}
	}

	public unsafe float barDurationCache
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_barDurationCache);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_barDurationCache)) = num;
		}
	}

	public unsafe bool isChannelingCache
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isChannelingCache);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isChannelingCache)) = flag;
		}
	}

	public unsafe bool doCastingFadeOut
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doCastingFadeOut);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doCastingFadeOut)) = flag;
		}
	}

	public unsafe float castingFadeStartTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingFadeStartTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingFadeStartTime)) = num;
		}
	}

	public unsafe float castResultFadeStartTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultFadeStartTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castResultFadeStartTime)) = num;
		}
	}

	static UIHpBarCasting()
	{
		Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UIHpBarCasting");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr);
		NativeFieldInfoPtr_castingBarFill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castingBarFill");
		NativeFieldInfoPtr_castingResultBarFill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castingResultBarFill");
		NativeFieldInfoPtr_castingBarGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castingBarGroup");
		NativeFieldInfoPtr_castingResultBarGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castingResultBarGroup");
		NativeFieldInfoPtr_castingColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castingColor");
		NativeFieldInfoPtr_channelingColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "channelingColor");
		NativeFieldInfoPtr_ultimateColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "ultimateColor");
		NativeFieldInfoPtr_successColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "successColor");
		NativeFieldInfoPtr_failColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "failColor");
		NativeFieldInfoPtr_castResultDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castResultDuration");
		NativeFieldInfoPtr_castResultFadeDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castResultFadeDuration");
		NativeFieldInfoPtr_castResultFadeCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castResultFadeCurve");
		NativeFieldInfoPtr_inactiveFadeDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "inactiveFadeDuration");
		NativeFieldInfoPtr_inactiveFadeCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "inactiveFadeCurve");
		NativeFieldInfoPtr_castResultTimeElapsed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castResultTimeElapsed");
		NativeFieldInfoPtr_isCastResultDone = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "isCastResultDone");
		NativeFieldInfoPtr_prevTickNum = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "prevTickNum");
		NativeFieldInfoPtr_barTimeElapsed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "barTimeElapsed");
		NativeFieldInfoPtr_isLerpingDone = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "isLerpingDone");
		NativeFieldInfoPtr_barTimeCache = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "barTimeCache");
		NativeFieldInfoPtr_barDurationCache = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "barDurationCache");
		NativeFieldInfoPtr_isChannelingCache = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "isChannelingCache");
		NativeFieldInfoPtr_doCastingFadeOut = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "doCastingFadeOut");
		NativeFieldInfoPtr_castingFadeStartTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castingFadeStartTime");
		NativeFieldInfoPtr_castResultFadeStartTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, "castResultFadeStartTime");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667448);
		NativeMethodInfoPtr_Initialize_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667449);
		NativeMethodInfoPtr_Reset_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667450);
		NativeMethodInfoPtr_TriggerCastingSuccess_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667451);
		NativeMethodInfoPtr_TriggerCastingFail_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667452);
		NativeMethodInfoPtr_ToggleCastingTime_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667453);
		NativeMethodInfoPtr_UpdateCastingBar_Public_Void_Int32_Single_Single_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667454);
		NativeMethodInfoPtr_ManagedLateUpdate_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667455);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr, 100667456);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 81391, XrefRangeEnd = 81393, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialize()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialize_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 81393, XrefRangeEnd = 81395, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Reset()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Reset_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 81395, XrefRangeEnd = 81400, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TriggerCastingSuccess()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TriggerCastingSuccess_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 81400, XrefRangeEnd = 81405, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TriggerCastingFail()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TriggerCastingFail_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 81405, XrefRangeEnd = 81407, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ToggleCastingTime(bool shown)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&shown);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToggleCastingTime_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 81415, RefRangeEnd = 81417, XrefRangeStart = 81407, XrefRangeEnd = 81415, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateCastingBar(int tickNum, float progress, float duration, bool isChanneling, bool isUltimate)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = (nint)(&tickNum);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &progress;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &duration;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &isChanneling;
		*(bool**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &isUltimate;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateCastingBar_Public_Void_Int32_Single_Single_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 81436, RefRangeEnd = 81437, XrefRangeStart = 81417, XrefRangeEnd = 81436, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ManagedLateUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManagedLateUpdate_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UIHpBarCasting()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UIHpBarCasting>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UIHpBarCasting(IntPtr pointer)
		: base(pointer)
	{
	}
}

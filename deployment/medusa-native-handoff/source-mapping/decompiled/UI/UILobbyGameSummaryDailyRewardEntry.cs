using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Il2CppBAPBAP.UI;

public class UILobbyGameSummaryDailyRewardEntry : MonoBehaviour
{
	[System.Serializable]
	public class Configuration : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_enabledAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_disabledAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_animateObtainDuration;

		private static readonly System.IntPtr NativeFieldInfoPtr_animateCompleteDuration;

		private static readonly System.IntPtr NativeFieldInfoPtr_animateObtainFlashCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_animateObtainScaleCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_animateCompleteFlashCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_animateCompleteYPosCurve;

		private static readonly System.IntPtr NativeFieldInfoPtr_obtainSfxData;

		private static readonly System.IntPtr NativeFieldInfoPtr_Prefab;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe float enabledAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledAlpha);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledAlpha)) = num;
			}
		}

		public unsafe float disabledAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disabledAlpha);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disabledAlpha)) = num;
			}
		}

		public unsafe float animateObtainDuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainDuration);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainDuration)) = num;
			}
		}

		public unsafe float animateCompleteDuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteDuration);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteDuration)) = num;
			}
		}

		public unsafe AnimationCurve animateObtainFlashCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainFlashCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainFlashCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe AnimationCurve animateObtainScaleCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainScaleCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainScaleCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe AnimationCurve animateCompleteFlashCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteFlashCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteFlashCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe AnimationCurve animateCompleteYPosCurve
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteYPosCurve);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteYPosCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
			}
		}

		public unsafe SFXData obtainSfxData
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obtainSfxData);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SFXData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obtainSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sFXData));
			}
		}

		public unsafe UILobbyGameSummaryDailyRewardEntry Prefab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Prefab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyGameSummaryDailyRewardEntry>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Prefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyGameSummaryDailyRewardEntry));
			}
		}

		static Configuration()
		{
			Il2CppClassPointerStore<Configuration>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "Configuration");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Configuration>.NativeClassPtr);
			NativeFieldInfoPtr_enabledAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "enabledAlpha");
			NativeFieldInfoPtr_disabledAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "disabledAlpha");
			NativeFieldInfoPtr_animateObtainDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "animateObtainDuration");
			NativeFieldInfoPtr_animateCompleteDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "animateCompleteDuration");
			NativeFieldInfoPtr_animateObtainFlashCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "animateObtainFlashCurve");
			NativeFieldInfoPtr_animateObtainScaleCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "animateObtainScaleCurve");
			NativeFieldInfoPtr_animateCompleteFlashCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "animateCompleteFlashCurve");
			NativeFieldInfoPtr_animateCompleteYPosCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "animateCompleteYPosCurve");
			NativeFieldInfoPtr_obtainSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "obtainSfxData");
			NativeFieldInfoPtr_Prefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "Prefab");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Configuration>.NativeClassPtr, 100668437);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Configuration()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Configuration>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Configuration(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class Factory : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr__configuration;

		private static readonly System.IntPtr NativeFieldInfoPtr__parentTransform;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Configuration_Transform_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Create_Public_UILobbyGameSummaryDailyRewardEntry_0;

		public unsafe Configuration _configuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe Transform _parentTransform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__parentTransform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__parentTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		static Factory()
		{
			Il2CppClassPointerStore<Factory>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "Factory");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Factory>.NativeClassPtr);
			NativeFieldInfoPtr__configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Factory>.NativeClassPtr, "_configuration");
			NativeFieldInfoPtr__parentTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Factory>.NativeClassPtr, "_parentTransform");
			NativeMethodInfoPtr__ctor_Public_Void_Configuration_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Factory>.NativeClassPtr, 100668438);
			NativeMethodInfoPtr_Create_Public_UILobbyGameSummaryDailyRewardEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Factory>.NativeClassPtr, 100668439);
		}

		[CallerCount(102)]
		[CachedScanResults(RefRangeStart = 55864, RefRangeEnd = 55966, XrefRangeStart = 55864, XrefRangeEnd = 55966, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Factory(Configuration configuration, Transform parentTransform)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Factory>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parentTransform);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Configuration_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 88247, RefRangeEnd = 88248, XrefRangeStart = 88243, XrefRangeEnd = 88247, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe UILobbyGameSummaryDailyRewardEntry Create()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Create_Public_UILobbyGameSummaryDailyRewardEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyGameSummaryDailyRewardEntry>(intPtr) : null;
		}

		public Factory(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_rectTransform;

	private static readonly System.IntPtr NativeFieldInfoPtr_completePivTransform;

	private static readonly System.IntPtr NativeFieldInfoPtr_iconImage;

	private static readonly System.IntPtr NativeFieldInfoPtr_canvasGroup;

	private static readonly System.IntPtr NativeFieldInfoPtr_uiAlphaFade;

	private static readonly System.IntPtr NativeFieldInfoPtr_posLerpFade;

	private static readonly System.IntPtr NativeFieldInfoPtr__configuration;

	private static readonly System.IntPtr NativeFieldInfoPtr_isObtained;

	private static readonly System.IntPtr NativeFieldInfoPtr_waitStartDelay;

	private static readonly System.IntPtr NativeFieldInfoPtr_delayTimeElapsed;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateObtain;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateObtainTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateComplete;

	private static readonly System.IntPtr NativeFieldInfoPtr_animateCompleteTime;

	private static readonly System.IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Initialise_Public_Void_Configuration_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StartFadeIn_Public_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DoFadeIn_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayObtain_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayCompleteAnim_Public_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetObtained_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetUnobtained_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe RectTransform rectTransform
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rectTransform);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rectTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
		}
	}

	public unsafe RectTransform completePivTransform
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_completePivTransform);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_completePivTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
		}
	}

	public unsafe Image iconImage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconImage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconImage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe CanvasGroup canvasGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe UIAlphaFade uiAlphaFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiAlphaFade);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiAlphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
		}
	}

	public unsafe UIPosLerpFade posLerpFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
		}
	}

	public unsafe Configuration _configuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
		}
	}

	public unsafe bool isObtained
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isObtained);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isObtained)) = flag;
		}
	}

	public unsafe float waitStartDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_waitStartDelay);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_waitStartDelay)) = num;
		}
	}

	public unsafe float delayTimeElapsed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_delayTimeElapsed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_delayTimeElapsed)) = num;
		}
	}

	public unsafe bool animateObtain
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtain);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtain)) = flag;
		}
	}

	public unsafe float animateObtainTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateObtainTime)) = num;
		}
	}

	public unsafe bool animateComplete
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateComplete);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateComplete)) = flag;
		}
	}

	public unsafe float animateCompleteTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animateCompleteTime)) = num;
		}
	}

	static UILobbyGameSummaryDailyRewardEntry()
	{
		Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UILobbyGameSummaryDailyRewardEntry");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr);
		NativeFieldInfoPtr_rectTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "rectTransform");
		NativeFieldInfoPtr_completePivTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "completePivTransform");
		NativeFieldInfoPtr_iconImage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "iconImage");
		NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "canvasGroup");
		NativeFieldInfoPtr_uiAlphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "uiAlphaFade");
		NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "posLerpFade");
		NativeFieldInfoPtr__configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "_configuration");
		NativeFieldInfoPtr_isObtained = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "isObtained");
		NativeFieldInfoPtr_waitStartDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "waitStartDelay");
		NativeFieldInfoPtr_delayTimeElapsed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "delayTimeElapsed");
		NativeFieldInfoPtr_animateObtain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "animateObtain");
		NativeFieldInfoPtr_animateObtainTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "animateObtainTime");
		NativeFieldInfoPtr_animateComplete = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "animateComplete");
		NativeFieldInfoPtr_animateCompleteTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, "animateCompleteTime");
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668428);
		NativeMethodInfoPtr_Initialise_Public_Void_Configuration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668429);
		NativeMethodInfoPtr_StartFadeIn_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668430);
		NativeMethodInfoPtr_DoFadeIn_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668431);
		NativeMethodInfoPtr_PlayObtain_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668432);
		NativeMethodInfoPtr_PlayCompleteAnim_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668433);
		NativeMethodInfoPtr_SetObtained_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668434);
		NativeMethodInfoPtr_SetUnobtained_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668435);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr, 100668436);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 88248, XrefRangeEnd = 88263, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 88263, RefRangeEnd = 88267, XrefRangeStart = 88263, XrefRangeEnd = 88263, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialise(Configuration configuration)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialise_Public_Void_Configuration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 88277, RefRangeEnd = 88278, XrefRangeStart = 88267, XrefRangeEnd = 88277, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void StartFadeIn(float delay = 0f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&delay);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StartFadeIn_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 88278, XrefRangeEnd = 88280, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DoFadeIn()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DoFadeIn_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 88283, RefRangeEnd = 88284, XrefRangeStart = 88280, XrefRangeEnd = 88283, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayObtain(bool playSfx = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&playSfx);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayObtain_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 88285, RefRangeEnd = 88286, XrefRangeStart = 88284, XrefRangeEnd = 88285, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayCompleteAnim(float delay = 0f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&delay);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayCompleteAnim_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 88286, RefRangeEnd = 88288, XrefRangeStart = 88286, XrefRangeEnd = 88286, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetObtained()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetObtained_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 88288, RefRangeEnd = 88289, XrefRangeStart = 88288, XrefRangeEnd = 88288, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetUnobtained()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetUnobtained_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UILobbyGameSummaryDailyRewardEntry()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UILobbyGameSummaryDailyRewardEntry>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UILobbyGameSummaryDailyRewardEntry(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

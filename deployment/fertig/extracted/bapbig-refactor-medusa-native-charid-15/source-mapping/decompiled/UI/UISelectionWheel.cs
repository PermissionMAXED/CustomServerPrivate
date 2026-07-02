using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UISelectionWheel : MonoBehaviour
{
	public class OptionData : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_title;

		private static readonly System.IntPtr NativeFieldInfoPtr_icon;

		private static readonly System.IntPtr NativeFieldInfoPtr_iconColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_iconMaterial;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_String_Sprite_Color_Material_0;

		public unsafe string title
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_title);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_title)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe Sprite icon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_icon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_icon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Color iconColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconColor)) = color;
			}
		}

		public unsafe Material iconMaterial
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconMaterial);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iconMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		static OptionData()
		{
			Il2CppClassPointerStore<OptionData>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "OptionData");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<OptionData>.NativeClassPtr);
			NativeFieldInfoPtr_title = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OptionData>.NativeClassPtr, "title");
			NativeFieldInfoPtr_icon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OptionData>.NativeClassPtr, "icon");
			NativeFieldInfoPtr_iconColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OptionData>.NativeClassPtr, "iconColor");
			NativeFieldInfoPtr_iconMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OptionData>.NativeClassPtr, "iconMaterial");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OptionData>.NativeClassPtr, 100668003);
			NativeMethodInfoPtr__ctor_Public_Void_String_Sprite_Color_Material_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OptionData>.NativeClassPtr, 100668004);
		}

		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 85625, RefRangeEnd = 85627, XrefRangeStart = 85624, XrefRangeEnd = 85625, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe OptionData()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<OptionData>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 85628, RefRangeEnd = 85631, XrefRangeStart = 85627, XrefRangeEnd = 85628, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe OptionData(string title, Sprite icon, Color iconColor, Material iconMaterial)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<OptionData>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[4];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(title);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)icon);
			*(Color**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &iconColor;
			*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)iconMaterial);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_String_Sprite_Color_Material_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public OptionData(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_uiManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_audioManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_inputSystem;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectWheelCanvas;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectWheelCanvasGroup;

	private static readonly System.IntPtr NativeFieldInfoPtr_startAnimation;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelDisabledGroup;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelOptionElementPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelOptionMat;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelPivot;

	private static readonly System.IntPtr NativeFieldInfoPtr_centerOption;

	private static readonly System.IntPtr NativeFieldInfoPtr_cancelDeadzone;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelOptionsParent;

	private static readonly System.IntPtr NativeFieldInfoPtr_inputHoldTimerToOpen;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelQuickOpenDist;

	private static readonly System.IntPtr NativeFieldInfoPtr_placeAtMousePos;

	private static readonly System.IntPtr NativeFieldInfoPtr_centerOptionEnabled;

	private static readonly System.IntPtr NativeFieldInfoPtr_centerOptionInteractable;

	private static readonly System.IntPtr NativeFieldInfoPtr_enableCancelDeadzoneOnCenterExit;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectMoveThreshold;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelDistLimit;

	private static readonly System.IntPtr NativeFieldInfoPtr_openAudioClip;

	private static readonly System.IntPtr NativeFieldInfoPtr_openSfxVolume;

	private static readonly System.IntPtr NativeFieldInfoPtr_hoverAudioClip;

	private static readonly System.IntPtr NativeFieldInfoPtr_hoverSfxVolume;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectAudioClip;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectSfxVolume;

	private static readonly System.IntPtr NativeFieldInfoPtr_removeAudioClip;

	private static readonly System.IntPtr NativeFieldInfoPtr_removeSfxVolume;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelOptionCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelElement;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelOptionMatInstance;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelElementRadius;

	private static readonly System.IntPtr NativeFieldInfoPtr_centerDeadzoneEnabled;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectMoveThresholdSqr;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelQuickOpenDistSqr;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelDistLimitSqr;

	private static readonly System.IntPtr NativeFieldInfoPtr_holdTimer;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelIsActive;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectedElementId;

	private static readonly System.IntPtr NativeFieldInfoPtr_wheelMoveDir;

	private static readonly System.IntPtr NativeFieldInfoPtr_startMousePos;

	private static readonly System.IntPtr NativeFieldInfoPtr_input;

	private static readonly System.IntPtr NativeFieldInfoPtr_inputDisabled;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectAction;

	private static readonly System.IntPtr NativeFieldInfoPtr_hoverOptionAction;

	private static readonly System.IntPtr NativeFieldInfoPtr_unhoverOptionAction;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_WheelIsActive_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_InputDisabled_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Awake_Protected_Virtual_New_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeWheel_Public_Void_Int32_InputBinding_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadOptions_Public_Void_Il2CppReferenceArray_1_OptionData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadOption_Public_Void_Int32_OptionData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetInputDisabled_Protected_Virtual_New_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnUpdate_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExternalOpenWheel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StartWheelSelect_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnBeginHold_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HoldUpdateTryStart_Private_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateMoveWheelDist_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateWheelHover_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_EndWheelSelect_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_EndPingSelect_Protected_Virtual_New_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TryInvokeCurrentSelection_Public_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InvokeSelection_Private_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetClosestWheelElementAngle_Private_Int32_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetWheelOnCooldown_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowWheel_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HoverOptionElement_Private_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UnHoverOptionElement_Private_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HoverSelectableElement_Private_Void_UISelectableLerpElement_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayOptionSelectAnim_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayOptionSelectAnim_Private_Void_UISelectionWheelOptionElement_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayOptionRemoveAnim_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlayOptionRemoveAnim_Private_Void_UISelectionWheelOptionElement_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe UIManager uiManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIManager));
		}
	}

	public unsafe AudioManager audioManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioManager));
		}
	}

	public unsafe InputSystem inputSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputSystem);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<InputSystem>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputSystem));
		}
	}

	public unsafe Canvas selectWheelCanvas
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectWheelCanvas);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Canvas>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectWheelCanvas)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvas));
		}
	}

	public unsafe CanvasGroup selectWheelCanvasGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectWheelCanvasGroup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectWheelCanvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe MonoBehaviour startAnimation
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startAnimation);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MonoBehaviour>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startAnimation)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)monoBehaviour));
		}
	}

	public unsafe CanvasGroup wheelDisabledGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelDisabledGroup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelDisabledGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe GameObject wheelOptionElementPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionElementPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionElementPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Material wheelOptionMat
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionMat);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionMat)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
		}
	}

	public unsafe RectTransform wheelPivot
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelPivot);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelPivot)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
		}
	}

	public unsafe UISelectionWheelOptionElement centerOption
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerOption);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UISelectionWheelOptionElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerOption)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uISelectionWheelOptionElement));
		}
	}

	public unsafe UISelectableLerpElement cancelDeadzone
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cancelDeadzone);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UISelectableLerpElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cancelDeadzone)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uISelectableLerpElement));
		}
	}

	public unsafe Transform wheelOptionsParent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionsParent);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionsParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe float inputHoldTimerToOpen
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputHoldTimerToOpen);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputHoldTimerToOpen)) = num;
		}
	}

	public unsafe float wheelQuickOpenDist
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelQuickOpenDist);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelQuickOpenDist)) = num;
		}
	}

	public unsafe bool placeAtMousePos
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placeAtMousePos);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placeAtMousePos)) = flag;
		}
	}

	public unsafe bool centerOptionEnabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerOptionEnabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerOptionEnabled)) = flag;
		}
	}

	public unsafe bool centerOptionInteractable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerOptionInteractable);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerOptionInteractable)) = flag;
		}
	}

	public unsafe bool enableCancelDeadzoneOnCenterExit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enableCancelDeadzoneOnCenterExit);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enableCancelDeadzoneOnCenterExit)) = flag;
		}
	}

	public unsafe float selectMoveThreshold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectMoveThreshold);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectMoveThreshold)) = num;
		}
	}

	public unsafe float wheelDistLimit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelDistLimit);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelDistLimit)) = num;
		}
	}

	public unsafe AudioManager.SFX openAudioClip
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openAudioClip);
			return *(AudioManager.SFX*)num;
		}
		set
		{
			*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openAudioClip)) = sFX;
		}
	}

	public unsafe float openSfxVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openSfxVolume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_openSfxVolume)) = num;
		}
	}

	public unsafe AudioManager.SFX hoverAudioClip
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverAudioClip);
			return *(AudioManager.SFX*)num;
		}
		set
		{
			*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverAudioClip)) = sFX;
		}
	}

	public unsafe float hoverSfxVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverSfxVolume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverSfxVolume)) = num;
		}
	}

	public unsafe AudioManager.SFX selectAudioClip
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectAudioClip);
			return *(AudioManager.SFX*)num;
		}
		set
		{
			*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectAudioClip)) = sFX;
		}
	}

	public unsafe float selectSfxVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectSfxVolume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectSfxVolume)) = num;
		}
	}

	public unsafe AudioManager.SFX removeAudioClip
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_removeAudioClip);
			return *(AudioManager.SFX*)num;
		}
		set
		{
			*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_removeAudioClip)) = sFX;
		}
	}

	public unsafe float removeSfxVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_removeSfxVolume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_removeSfxVolume)) = num;
		}
	}

	public unsafe int wheelOptionCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionCount)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<UISelectionWheelOptionElement> wheelElement
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelElement);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<UISelectionWheelOptionElement>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelElement)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Material wheelOptionMatInstance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionMatInstance);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelOptionMatInstance)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
		}
	}

	public unsafe float wheelElementRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelElementRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelElementRadius)) = num;
		}
	}

	public unsafe bool centerDeadzoneEnabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerDeadzoneEnabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_centerDeadzoneEnabled)) = flag;
		}
	}

	public unsafe float selectMoveThresholdSqr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectMoveThresholdSqr);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectMoveThresholdSqr)) = num;
		}
	}

	public unsafe float wheelQuickOpenDistSqr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelQuickOpenDistSqr);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelQuickOpenDistSqr)) = num;
		}
	}

	public unsafe float wheelDistLimitSqr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelDistLimitSqr);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelDistLimitSqr)) = num;
		}
	}

	public unsafe float holdTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_holdTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_holdTimer)) = num;
		}
	}

	public unsafe bool wheelIsActive
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelIsActive);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelIsActive)) = flag;
		}
	}

	public unsafe int selectedElementId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedElementId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedElementId)) = num;
		}
	}

	public unsafe Vector2 wheelMoveDir
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelMoveDir);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wheelMoveDir)) = vector;
		}
	}

	public unsafe Vector2 startMousePos
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startMousePos);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startMousePos)) = vector;
		}
	}

	public unsafe InputBinding input
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_input);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_input)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBinding));
		}
	}

	public unsafe bool inputDisabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputDisabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputDisabled)) = flag;
		}
	}

	public unsafe Il2CppSystem.Action<int> selectAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectAction);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe Il2CppSystem.Action<int> hoverOptionAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverOptionAction);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverOptionAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe Il2CppSystem.Action unhoverOptionAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unhoverOptionAction);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unhoverOptionAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe bool WheelIsActive
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_WheelIsActive_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool InputDisabled
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_InputDisabled_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static UISelectionWheel()
	{
		Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UISelectionWheel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr);
		NativeFieldInfoPtr_uiManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "uiManager");
		NativeFieldInfoPtr_audioManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "audioManager");
		NativeFieldInfoPtr_inputSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "inputSystem");
		NativeFieldInfoPtr_selectWheelCanvas = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectWheelCanvas");
		NativeFieldInfoPtr_selectWheelCanvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectWheelCanvasGroup");
		NativeFieldInfoPtr_startAnimation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "startAnimation");
		NativeFieldInfoPtr_wheelDisabledGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelDisabledGroup");
		NativeFieldInfoPtr_wheelOptionElementPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelOptionElementPrefab");
		NativeFieldInfoPtr_wheelOptionMat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelOptionMat");
		NativeFieldInfoPtr_wheelPivot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelPivot");
		NativeFieldInfoPtr_centerOption = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "centerOption");
		NativeFieldInfoPtr_cancelDeadzone = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "cancelDeadzone");
		NativeFieldInfoPtr_wheelOptionsParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelOptionsParent");
		NativeFieldInfoPtr_inputHoldTimerToOpen = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "inputHoldTimerToOpen");
		NativeFieldInfoPtr_wheelQuickOpenDist = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelQuickOpenDist");
		NativeFieldInfoPtr_placeAtMousePos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "placeAtMousePos");
		NativeFieldInfoPtr_centerOptionEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "centerOptionEnabled");
		NativeFieldInfoPtr_centerOptionInteractable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "centerOptionInteractable");
		NativeFieldInfoPtr_enableCancelDeadzoneOnCenterExit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "enableCancelDeadzoneOnCenterExit");
		NativeFieldInfoPtr_selectMoveThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectMoveThreshold");
		NativeFieldInfoPtr_wheelDistLimit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelDistLimit");
		NativeFieldInfoPtr_openAudioClip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "openAudioClip");
		NativeFieldInfoPtr_openSfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "openSfxVolume");
		NativeFieldInfoPtr_hoverAudioClip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "hoverAudioClip");
		NativeFieldInfoPtr_hoverSfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "hoverSfxVolume");
		NativeFieldInfoPtr_selectAudioClip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectAudioClip");
		NativeFieldInfoPtr_selectSfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectSfxVolume");
		NativeFieldInfoPtr_removeAudioClip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "removeAudioClip");
		NativeFieldInfoPtr_removeSfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "removeSfxVolume");
		NativeFieldInfoPtr_wheelOptionCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelOptionCount");
		NativeFieldInfoPtr_wheelElement = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelElement");
		NativeFieldInfoPtr_wheelOptionMatInstance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelOptionMatInstance");
		NativeFieldInfoPtr_wheelElementRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelElementRadius");
		NativeFieldInfoPtr_centerDeadzoneEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "centerDeadzoneEnabled");
		NativeFieldInfoPtr_selectMoveThresholdSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectMoveThresholdSqr");
		NativeFieldInfoPtr_wheelQuickOpenDistSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelQuickOpenDistSqr");
		NativeFieldInfoPtr_wheelDistLimitSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelDistLimitSqr");
		NativeFieldInfoPtr_holdTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "holdTimer");
		NativeFieldInfoPtr_wheelIsActive = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelIsActive");
		NativeFieldInfoPtr_selectedElementId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectedElementId");
		NativeFieldInfoPtr_wheelMoveDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "wheelMoveDir");
		NativeFieldInfoPtr_startMousePos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "startMousePos");
		NativeFieldInfoPtr_input = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "input");
		NativeFieldInfoPtr_inputDisabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "inputDisabled");
		NativeFieldInfoPtr_selectAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "selectAction");
		NativeFieldInfoPtr_hoverOptionAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "hoverOptionAction");
		NativeFieldInfoPtr_unhoverOptionAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, "unhoverOptionAction");
		NativeMethodInfoPtr_get_WheelIsActive_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667973);
		NativeMethodInfoPtr_get_InputDisabled_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667974);
		NativeMethodInfoPtr_Awake_Protected_Virtual_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667975);
		NativeMethodInfoPtr_InitializeWheel_Public_Void_Int32_InputBinding_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667976);
		NativeMethodInfoPtr_LoadOptions_Public_Void_Il2CppReferenceArray_1_OptionData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667977);
		NativeMethodInfoPtr_LoadOption_Public_Void_Int32_OptionData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667978);
		NativeMethodInfoPtr_GetInputDisabled_Protected_Virtual_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667979);
		NativeMethodInfoPtr_OnUpdate_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667980);
		NativeMethodInfoPtr_ExternalOpenWheel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667981);
		NativeMethodInfoPtr_StartWheelSelect_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667982);
		NativeMethodInfoPtr_OnBeginHold_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667983);
		NativeMethodInfoPtr_HoldUpdateTryStart_Private_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667984);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667985);
		NativeMethodInfoPtr_CalculateMoveWheelDist_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667986);
		NativeMethodInfoPtr_UpdateWheelHover_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667987);
		NativeMethodInfoPtr_EndWheelSelect_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667988);
		NativeMethodInfoPtr_EndPingSelect_Protected_Virtual_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667989);
		NativeMethodInfoPtr_TryInvokeCurrentSelection_Public_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667990);
		NativeMethodInfoPtr_InvokeSelection_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667991);
		NativeMethodInfoPtr_GetClosestWheelElementAngle_Private_Int32_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667992);
		NativeMethodInfoPtr_SetWheelOnCooldown_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667993);
		NativeMethodInfoPtr_ShowWheel_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667994);
		NativeMethodInfoPtr_HoverOptionElement_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667995);
		NativeMethodInfoPtr_UnHoverOptionElement_Private_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667996);
		NativeMethodInfoPtr_HoverSelectableElement_Private_Void_UISelectableLerpElement_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667997);
		NativeMethodInfoPtr_PlayOptionSelectAnim_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667998);
		NativeMethodInfoPtr_PlayOptionSelectAnim_Private_Void_UISelectionWheelOptionElement_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100667999);
		NativeMethodInfoPtr_PlayOptionRemoveAnim_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100668000);
		NativeMethodInfoPtr_PlayOptionRemoveAnim_Private_Void_UISelectionWheelOptionElement_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100668001);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr, 100668002);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 85637, RefRangeEnd = 85640, XrefRangeStart = 85631, XrefRangeEnd = 85637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Awake_Protected_Virtual_New_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 85658, RefRangeEnd = 85662, XrefRangeStart = 85640, XrefRangeEnd = 85658, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeWheel(int optionCount, InputBinding input)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&optionCount);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)input);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeWheel_Public_Void_Int32_InputBinding_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 85665, RefRangeEnd = 85671, XrefRangeStart = 85662, XrefRangeEnd = 85665, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadOptions(Il2CppReferenceArray<OptionData> options)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)options);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadOptions_Public_Void_Il2CppReferenceArray_1_OptionData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 85672, RefRangeEnd = 85675, XrefRangeStart = 85671, XrefRangeEnd = 85672, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadOption(int optionId, OptionData option)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&optionId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)option);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadOption_Public_Void_Int32_OptionData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85675, XrefRangeEnd = 85679, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void GetInputDisabled()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetInputDisabled_Protected_Virtual_New_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 85687, RefRangeEnd = 85690, XrefRangeStart = 85679, XrefRangeEnd = 85687, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnUpdate_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 85692, RefRangeEnd = 85697, XrefRangeStart = 85690, XrefRangeEnd = 85692, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ExternalOpenWheel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExternalOpenWheel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 85715, RefRangeEnd = 85718, XrefRangeStart = 85697, XrefRangeEnd = 85715, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void StartWheelSelect()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StartWheelSelect_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 85723, RefRangeEnd = 85725, XrefRangeStart = 85718, XrefRangeEnd = 85723, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnBeginHold()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnBeginHold_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85725, XrefRangeEnd = 85728, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HoldUpdateTryStart(bool hold)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&hold);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HoldUpdateTryStart_Private_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85728, XrefRangeEnd = 85729, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 85733, RefRangeEnd = 85736, XrefRangeStart = 85729, XrefRangeEnd = 85733, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CalculateMoveWheelDist()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateMoveWheelDist_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85750, RefRangeEnd = 85751, XrefRangeStart = 85736, XrefRangeEnd = 85750, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateWheelHover()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateWheelHover_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 85757, RefRangeEnd = 85761, XrefRangeStart = 85751, XrefRangeEnd = 85757, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void EndWheelSelect(bool invokeSelection = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&invokeSelection);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_EndWheelSelect_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe virtual void EndPingSelect()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_EndPingSelect_Protected_Virtual_New_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 85762, RefRangeEnd = 85764, XrefRangeStart = 85761, XrefRangeEnd = 85762, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool TryInvokeCurrentSelection()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryInvokeCurrentSelection_Public_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 85764, RefRangeEnd = 85766, XrefRangeStart = 85764, XrefRangeEnd = 85764, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InvokeSelection(int optionId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&optionId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeSelection_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85777, RefRangeEnd = 85778, XrefRangeStart = 85766, XrefRangeEnd = 85777, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetClosestWheelElementAngle(Vector2 direction)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&direction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetClosestWheelElementAngle_Private_Int32_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 85783, RefRangeEnd = 85791, XrefRangeStart = 85778, XrefRangeEnd = 85783, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetWheelOnCooldown(bool isInCooldown)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&isInCooldown);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetWheelOnCooldown_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85791, XrefRangeEnd = 85795, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowWheel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowWheel_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85795, XrefRangeEnd = 85799, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HoverOptionElement(int id)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&id);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HoverOptionElement_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 85802, RefRangeEnd = 85804, XrefRangeStart = 85799, XrefRangeEnd = 85802, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UnHoverOptionElement(int id)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&id);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UnHoverOptionElement_Private_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85804, XrefRangeEnd = 85806, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HoverSelectableElement(UISelectableLerpElement element)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)element);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HoverSelectableElement_Private_Void_UISelectableLerpElement_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85807, RefRangeEnd = 85808, XrefRangeStart = 85806, XrefRangeEnd = 85807, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayOptionSelectAnim(int optionId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&optionId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayOptionSelectAnim_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85810, RefRangeEnd = 85811, XrefRangeStart = 85808, XrefRangeEnd = 85810, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayOptionSelectAnim(UISelectionWheelOptionElement optionElement)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)optionElement);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayOptionSelectAnim_Private_Void_UISelectionWheelOptionElement_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85812, RefRangeEnd = 85813, XrefRangeStart = 85811, XrefRangeEnd = 85812, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayOptionRemoveAnim(int optionId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&optionId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayOptionRemoveAnim_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85815, RefRangeEnd = 85816, XrefRangeStart = 85813, XrefRangeEnd = 85815, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PlayOptionRemoveAnim(UISelectionWheelOptionElement optionElement)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)optionElement);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlayOptionRemoveAnim_Private_Void_UISelectionWheelOptionElement_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 85817, RefRangeEnd = 85820, XrefRangeStart = 85816, XrefRangeEnd = 85817, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UISelectionWheel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UISelectionWheel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UISelectionWheel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

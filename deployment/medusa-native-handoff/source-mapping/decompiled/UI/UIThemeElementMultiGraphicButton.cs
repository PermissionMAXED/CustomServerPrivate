using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UIThemeElementMultiGraphicButton : UIThemeElement
{
	[System.Serializable]
	public class ButtonGraphicPalette : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_buttonPalettes;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Il2CppReferenceArray<ButtonPalette> buttonPalettes
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonPalettes);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ButtonPalette>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonPalettes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		static ButtonGraphicPalette()
		{
			Il2CppClassPointerStore<ButtonGraphicPalette>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, "ButtonGraphicPalette");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ButtonGraphicPalette>.NativeClassPtr);
			NativeFieldInfoPtr_buttonPalettes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonGraphicPalette>.NativeClassPtr, "buttonPalettes");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ButtonGraphicPalette>.NativeClassPtr, 100670101);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ButtonGraphicPalette()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ButtonGraphicPalette>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ButtonGraphicPalette(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ButtonPalette : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_customColors;

		private static readonly System.IntPtr NativeFieldInfoPtr_normalColorPalette;

		private static readonly System.IntPtr NativeFieldInfoPtr_highlightedColorPalette;

		private static readonly System.IntPtr NativeFieldInfoPtr_pressedColorPalette;

		private static readonly System.IntPtr NativeFieldInfoPtr_selectedColorPalette;

		private static readonly System.IntPtr NativeFieldInfoPtr_disabledColorPalette;

		private static readonly System.IntPtr NativeFieldInfoPtr_normalColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_highlightedColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_pressedColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_selectedColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_disabledColor;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_ColorPalette_ColorPalette_ColorPalette_ColorPalette_ColorPalette_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Color_Color_Color_Color_Color_0;

		public unsafe bool customColors
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customColors);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customColors)) = flag;
			}
		}

		public unsafe ColorPalette normalColorPalette
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_normalColorPalette);
				return *(ColorPalette*)num;
			}
			set
			{
				*(ColorPalette*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_normalColorPalette)) = colorPalette;
			}
		}

		public unsafe ColorPalette highlightedColorPalette
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_highlightedColorPalette);
				return *(ColorPalette*)num;
			}
			set
			{
				*(ColorPalette*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_highlightedColorPalette)) = colorPalette;
			}
		}

		public unsafe ColorPalette pressedColorPalette
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pressedColorPalette);
				return *(ColorPalette*)num;
			}
			set
			{
				*(ColorPalette*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pressedColorPalette)) = colorPalette;
			}
		}

		public unsafe ColorPalette selectedColorPalette
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedColorPalette);
				return *(ColorPalette*)num;
			}
			set
			{
				*(ColorPalette*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedColorPalette)) = colorPalette;
			}
		}

		public unsafe ColorPalette disabledColorPalette
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disabledColorPalette);
				return *(ColorPalette*)num;
			}
			set
			{
				*(ColorPalette*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disabledColorPalette)) = colorPalette;
			}
		}

		public unsafe Color normalColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_normalColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_normalColor)) = color;
			}
		}

		public unsafe Color highlightedColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_highlightedColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_highlightedColor)) = color;
			}
		}

		public unsafe Color pressedColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pressedColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pressedColor)) = color;
			}
		}

		public unsafe Color selectedColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedColor)) = color;
			}
		}

		public unsafe Color disabledColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disabledColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_disabledColor)) = color;
			}
		}

		static ButtonPalette()
		{
			Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, "ButtonPalette");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr);
			NativeFieldInfoPtr_customColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "customColors");
			NativeFieldInfoPtr_normalColorPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "normalColorPalette");
			NativeFieldInfoPtr_highlightedColorPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "highlightedColorPalette");
			NativeFieldInfoPtr_pressedColorPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "pressedColorPalette");
			NativeFieldInfoPtr_selectedColorPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "selectedColorPalette");
			NativeFieldInfoPtr_disabledColorPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "disabledColorPalette");
			NativeFieldInfoPtr_normalColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "normalColor");
			NativeFieldInfoPtr_highlightedColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "highlightedColor");
			NativeFieldInfoPtr_pressedColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "pressedColor");
			NativeFieldInfoPtr_selectedColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "selectedColor");
			NativeFieldInfoPtr_disabledColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, "disabledColor");
			NativeMethodInfoPtr__ctor_Public_Void_ColorPalette_ColorPalette_ColorPalette_ColorPalette_ColorPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, 100670102);
			NativeMethodInfoPtr__ctor_Public_Void_Color_Color_Color_Color_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, 100670103);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99390, XrefRangeEnd = 99391, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ButtonPalette(ColorPalette normalColorPalette, ColorPalette highlightedColorPalette, ColorPalette pressedColorPalette, ColorPalette selectedColorPalette, ColorPalette disabledColorPalette)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[5];
			*ptr = (nint)(&normalColorPalette);
			*(ColorPalette**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &highlightedColorPalette;
			*(ColorPalette**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &pressedColorPalette;
			*(ColorPalette**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &selectedColorPalette;
			*(ColorPalette**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &disabledColorPalette;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_ColorPalette_ColorPalette_ColorPalette_ColorPalette_ColorPalette_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99391, XrefRangeEnd = 99392, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ButtonPalette(Color normalColor, Color highlightedColor, Color pressedColor, Color selectedColor, Color disabledColor)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[5];
			*ptr = (nint)(&normalColor);
			*(Color**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &highlightedColor;
			*(Color**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &pressedColor;
			*(Color**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &selectedColor;
			*(Color**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &disabledColor;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Color_Color_Color_Color_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ButtonPalette(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_themeGraphicsPalette;

	private static readonly System.IntPtr NativeFieldInfoPtr_multiGraphicButton;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_targetColor;

	private static readonly System.IntPtr NativeMethodInfoPtr_Start_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetThemeMode_Public_Virtual_Void_ThemeMode_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetColorPaletteBlock_Private_Void_ButtonGraphicPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CrossFade_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetGraphicButtonColor_Private_Void_ButtonGraphicTransition_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnValidate_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<ButtonGraphicPalette> themeGraphicsPalette
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_themeGraphicsPalette);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ButtonGraphicPalette>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_themeGraphicsPalette)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe MultiGraphicButton multiGraphicButton
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_multiGraphicButton);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MultiGraphicButton>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_multiGraphicButton)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)multiGraphicButton));
		}
	}

	public unsafe Il2CppStructArray<Color> prevColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevColor);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevColor)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Color> targetColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetColor);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetColor)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static UIThemeElementMultiGraphicButton()
	{
		Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UIThemeElementMultiGraphicButton");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr);
		NativeFieldInfoPtr_themeGraphicsPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, "themeGraphicsPalette");
		NativeFieldInfoPtr_multiGraphicButton = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, "multiGraphicButton");
		NativeFieldInfoPtr_prevColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, "prevColor");
		NativeFieldInfoPtr_targetColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, "targetColor");
		NativeMethodInfoPtr_Start_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670093);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670094);
		NativeMethodInfoPtr_SetThemeMode_Public_Virtual_Void_ThemeMode_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670095);
		NativeMethodInfoPtr_SetColorPaletteBlock_Private_Void_ButtonGraphicPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670096);
		NativeMethodInfoPtr_CrossFade_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670097);
		NativeMethodInfoPtr_SetGraphicButtonColor_Private_Void_ButtonGraphicTransition_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670098);
		NativeMethodInfoPtr_OnValidate_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670099);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr, 100670100);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 40129, RefRangeEnd = 40130, XrefRangeStart = 40129, XrefRangeEnd = 40130, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Start()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Start_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99392, XrefRangeEnd = 99401, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99401, XrefRangeEnd = 99405, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SetThemeMode(ThemeMode mode, bool doFade)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&mode);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &doFade;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SetThemeMode_Public_Virtual_Void_ThemeMode_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 99422, RefRangeEnd = 99423, XrefRangeStart = 99405, XrefRangeEnd = 99422, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetColorPaletteBlock(ButtonGraphicPalette graphicPalette)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)graphicPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetColorPaletteBlock_Private_Void_ButtonGraphicPalette_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 99431, RefRangeEnd = 99432, XrefRangeStart = 99423, XrefRangeEnd = 99431, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CrossFade()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CrossFade_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99432, XrefRangeEnd = 99435, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetGraphicButtonColor(MultiGraphicButton.ButtonGraphicTransition graphicTransition, Color newCol)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)graphicTransition);
		*(Color**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &newCol;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetGraphicButtonColor_Private_Void_ButtonGraphicTransition_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99435, XrefRangeEnd = 99464, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnValidate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnValidate_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UIThemeElementMultiGraphicButton()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UIThemeElementMultiGraphicButton>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UIThemeElementMultiGraphicButton(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

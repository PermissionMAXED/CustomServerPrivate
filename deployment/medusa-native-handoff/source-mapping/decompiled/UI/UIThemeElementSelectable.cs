using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Il2CppBAPBAP.UI;

public class UIThemeElementSelectable : UIThemeElement
{
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
			Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, "ButtonPalette");
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
			NativeMethodInfoPtr__ctor_Public_Void_ColorPalette_ColorPalette_ColorPalette_ColorPalette_ColorPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, 100670111);
			NativeMethodInfoPtr__ctor_Public_Void_Color_Color_Color_Color_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ButtonPalette>.NativeClassPtr, 100670112);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	private static readonly System.IntPtr NativeFieldInfoPtr_themePaletteColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_selectable;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevColor;

	private static readonly System.IntPtr NativeFieldInfoPtr_targetColor;

	private static readonly System.IntPtr NativeMethodInfoPtr_Start_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetThemeMode_Public_Virtual_Void_ThemeMode_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetColorPaletteBlock_Private_Void_ButtonPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CrossFade_Private_Void_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnValidate_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<ButtonPalette> themePaletteColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_themePaletteColor);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ButtonPalette>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_themePaletteColor)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Selectable selectable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectable);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Selectable>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectable)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectable));
		}
	}

	public unsafe Color prevColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevColor)) = color;
		}
	}

	public unsafe Color targetColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetColor)) = color;
		}
	}

	static UIThemeElementSelectable()
	{
		Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UIThemeElementSelectable");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr);
		NativeFieldInfoPtr_themePaletteColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, "themePaletteColor");
		NativeFieldInfoPtr_selectable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, "selectable");
		NativeFieldInfoPtr_prevColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, "prevColor");
		NativeFieldInfoPtr_targetColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, "targetColor");
		NativeMethodInfoPtr_Start_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, 100670104);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, 100670105);
		NativeMethodInfoPtr_SetThemeMode_Public_Virtual_Void_ThemeMode_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, 100670106);
		NativeMethodInfoPtr_SetColorPaletteBlock_Private_Void_ButtonPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, 100670107);
		NativeMethodInfoPtr_CrossFade_Private_Void_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, 100670108);
		NativeMethodInfoPtr_OnValidate_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, 100670109);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr, 100670110);
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
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99464, XrefRangeEnd = 99474, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99474, XrefRangeEnd = 99481, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 99500, RefRangeEnd = 99501, XrefRangeStart = 99481, XrefRangeEnd = 99500, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetColorPaletteBlock(ButtonPalette buttonPalette)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)buttonPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetColorPaletteBlock_Private_Void_ButtonPalette_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99501, XrefRangeEnd = 99503, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CrossFade(Color _targetColor)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&_targetColor);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CrossFade_Private_Void_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 99503, XrefRangeEnd = 99522, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	public unsafe UIThemeElementSelectable()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UIThemeElementSelectable>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UIThemeElementSelectable(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

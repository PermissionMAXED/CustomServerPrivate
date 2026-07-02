using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UIMinimapTerritoryZoneIcon : UIMinimapDirIcon
{
	private static readonly IntPtr NativeFieldInfoPtr_allyColor;

	private static readonly IntPtr NativeFieldInfoPtr_enemyColor;

	private static readonly IntPtr NativeFieldInfoPtr_uncapturedColor;

	private static readonly IntPtr NativeFieldInfoPtr_inactiveColor;

	private static readonly IntPtr NativeMethodInfoPtr_SetColorByTeam_Public_Void_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Color allyColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allyColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allyColor)) = color;
		}
	}

	public unsafe Color enemyColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enemyColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enemyColor)) = color;
		}
	}

	public unsafe Color uncapturedColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uncapturedColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uncapturedColor)) = color;
		}
	}

	public unsafe Color inactiveColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inactiveColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inactiveColor)) = color;
		}
	}

	static UIMinimapTerritoryZoneIcon()
	{
		Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UIMinimapTerritoryZoneIcon");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr);
		NativeFieldInfoPtr_allyColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr, "allyColor");
		NativeFieldInfoPtr_enemyColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr, "enemyColor");
		NativeFieldInfoPtr_uncapturedColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr, "uncapturedColor");
		NativeFieldInfoPtr_inactiveColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr, "inactiveColor");
		NativeMethodInfoPtr_SetColorByTeam_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr, 100667723);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr, 100667724);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 83516, XrefRangeEnd = 83517, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetColorByTeam(int teamId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&teamId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetColorByTeam_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 83517, XrefRangeEnd = 83518, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UIMinimapTerritoryZoneIcon()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UIMinimapTerritoryZoneIcon>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UIMinimapTerritoryZoneIcon(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Content;

public class ContentConfiguration : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_rarityColors;

	private static readonly IntPtr NativeFieldInfoPtr_uiRarityColors;

	private static readonly IntPtr NativeFieldInfoPtr_rarityNames;

	private static readonly IntPtr NativeFieldInfoPtr_rarityTranslationKeys;

	private static readonly IntPtr NativeFieldInfoPtr_tierTypesTranslationKeys;

	private static readonly IntPtr NativeFieldInfoPtr_tierTypesColors;

	private static readonly IntPtr NativeFieldInfoPtr_emoteTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_stickerTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_animationTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_voicelineTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_playerBannerTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_tombstoneTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_currencyTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_masteryBadgeTranslationKey;

	private static readonly IntPtr NativeFieldInfoPtr_skinTranslationKey;

	private static readonly IntPtr NativeMethodInfoPtr_GetContentTypeTranslationKey_Public_String_Content_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetEmoteTypeNameTranslationKey_Public_String_Emote_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetRarityColorByRarity_Public_Color_Rarity_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetUIRarityColorByRarity_Public_Color_Rarity_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetRarityName_Public_String_Rarity_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetRarityTranslationKey_Public_String_Rarity_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTierTypeTranslationKey_Public_String_TierType_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTierTypeColor_Public_Color_TierType_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppStructArray<Color> rarityColors
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rarityColors);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rarityColors)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Color> uiRarityColors
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiRarityColors);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiRarityColors)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStringArray rarityNames
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rarityNames);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rarityNames)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStringArray rarityTranslationKeys
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rarityTranslationKeys);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rarityTranslationKeys)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStringArray tierTypesTranslationKeys
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierTypesTranslationKeys);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierTypesTranslationKeys)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Color> tierTypesColors
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierTypesColors);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierTypesColors)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe string emoteTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string stickerTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string animationTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animationTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animationTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string voicelineTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_voicelineTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_voicelineTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string playerBannerTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBannerTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBannerTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string tombstoneTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string currencyTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string masteryBadgeTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string skinTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_skinTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_skinTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static ContentConfiguration()
	{
		Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "ContentConfiguration");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr);
		NativeFieldInfoPtr_rarityColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "rarityColors");
		NativeFieldInfoPtr_uiRarityColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "uiRarityColors");
		NativeFieldInfoPtr_rarityNames = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "rarityNames");
		NativeFieldInfoPtr_rarityTranslationKeys = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "rarityTranslationKeys");
		NativeFieldInfoPtr_tierTypesTranslationKeys = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "tierTypesTranslationKeys");
		NativeFieldInfoPtr_tierTypesColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "tierTypesColors");
		NativeFieldInfoPtr_emoteTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "emoteTranslationKey");
		NativeFieldInfoPtr_stickerTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "stickerTranslationKey");
		NativeFieldInfoPtr_animationTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "animationTranslationKey");
		NativeFieldInfoPtr_voicelineTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "voicelineTranslationKey");
		NativeFieldInfoPtr_playerBannerTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "playerBannerTranslationKey");
		NativeFieldInfoPtr_tombstoneTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "tombstoneTranslationKey");
		NativeFieldInfoPtr_currencyTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "currencyTranslationKey");
		NativeFieldInfoPtr_masteryBadgeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "masteryBadgeTranslationKey");
		NativeFieldInfoPtr_skinTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, "skinTranslationKey");
		NativeMethodInfoPtr_GetContentTypeTranslationKey_Public_String_Content_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682862);
		NativeMethodInfoPtr_GetEmoteTypeNameTranslationKey_Public_String_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682863);
		NativeMethodInfoPtr_GetRarityColorByRarity_Public_Color_Rarity_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682864);
		NativeMethodInfoPtr_GetUIRarityColorByRarity_Public_Color_Rarity_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682865);
		NativeMethodInfoPtr_GetRarityName_Public_String_Rarity_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682866);
		NativeMethodInfoPtr_GetRarityTranslationKey_Public_String_Rarity_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682867);
		NativeMethodInfoPtr_GetTierTypeTranslationKey_Public_String_TierType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682868);
		NativeMethodInfoPtr_GetTierTypeColor_Public_Color_TierType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682869);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr, 100682870);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 216857, RefRangeEnd = 216860, XrefRangeStart = 216830, XrefRangeEnd = 216857, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetContentTypeTranslationKey(Content content)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetContentTypeTranslationKey_Public_String_Content_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 216860, XrefRangeEnd = 216875, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetEmoteTypeNameTranslationKey(Emote emote)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteTypeNameTranslationKey_Public_String_Emote_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 216875, RefRangeEnd = 216878, XrefRangeStart = 216875, XrefRangeEnd = 216875, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Color GetRarityColorByRarity(Rarity rarity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&rarity);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRarityColorByRarity_Public_Color_Rarity_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Color*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 216878, RefRangeEnd = 216882, XrefRangeStart = 216878, XrefRangeEnd = 216878, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Color GetUIRarityColorByRarity(Rarity rarity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&rarity);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetUIRarityColorByRarity_Public_Color_Rarity_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Color*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe string GetRarityName(Rarity rarity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&rarity);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRarityName_Public_String_Rarity_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 216882, RefRangeEnd = 216885, XrefRangeStart = 216882, XrefRangeEnd = 216882, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetRarityTranslationKey(Rarity rarity)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&rarity);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRarityTranslationKey_Public_String_Rarity_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	public unsafe string GetTierTypeTranslationKey(TierType tierType)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&tierType);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTierTypeTranslationKey_Public_String_TierType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	public unsafe Color GetTierTypeColor(TierType tierType)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&tierType);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTierTypeColor_Public_Color_TierType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Color*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ContentConfiguration()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ContentConfiguration>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ContentConfiguration(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Content;
using Il2CppBAPBAP.UI;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class EmoteManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_localSavedData;

	private static readonly IntPtr NativeFieldInfoPtr_emoteSelectionWheel;

	private static readonly IntPtr NativeFieldInfoPtr_emoteData;

	private static readonly IntPtr NativeFieldInfoPtr_charEmoteSfxPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_defaultEmotePrefab;

	private static readonly IntPtr NativeFieldInfoPtr_selectableEmoteCount;

	private static readonly IntPtr NativeFieldInfoPtr_defaultSelectedEmotes;

	private static readonly IntPtr NativeFieldInfoPtr_stickerEmoteDuration;

	private static readonly IntPtr NativeFieldInfoPtr_stickerEmoteCooldown;

	private static readonly IntPtr NativeFieldInfoPtr_masteryBadgeEmoteCooldown;

	private static readonly IntPtr NativeFieldInfoPtr_spamToStartCooldown;

	private static readonly IntPtr NativeFieldInfoPtr_spamCooldownDuration;

	private static readonly IntPtr NativeFieldInfoPtr_emoteCreateVolume;

	private static readonly IntPtr NativeFieldInfoPtr_masteryBadgeCreateVolume;

	private static readonly IntPtr NativeFieldInfoPtr_spamSfxId;

	private static readonly IntPtr NativeFieldInfoPtr_spamSfxVolume;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Start_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_LoadEmoteWheelOptions_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetEmoteWheelOptions_Public_Il2CppReferenceArray_1_OptionData_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetOptionDataFromEmote_Public_OptionData_Emote_0;

	private static readonly IntPtr NativeMethodInfoPtr_LoadEmoteWheelOptions_Private_Void_Il2CppReferenceArray_1_OptionData_0;

	private static readonly IntPtr NativeMethodInfoPtr_LoadEmoteWheelOption_Public_Void_Int32_OptionData_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetEmoteByAssetId_Public_Emote_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetEmoteIcon_Public_Sprite_Emote_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe LocalSavedData localSavedData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localSavedData);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<LocalSavedData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localSavedData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)localSavedData));
		}
	}

	public unsafe UISelectionWheelEmotes emoteSelectionWheel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteSelectionWheel);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UISelectionWheelEmotes>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteSelectionWheel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uISelectionWheelEmotes));
		}
	}

	public unsafe EmoteData emoteData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteData);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EmoteData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emoteData));
		}
	}

	public unsafe AudioSource charEmoteSfxPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charEmoteSfxPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioSource>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charEmoteSfxPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioSource));
		}
	}

	public unsafe GameObject defaultEmotePrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultEmotePrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultEmotePrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe int selectableEmoteCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectableEmoteCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectableEmoteCount)) = num;
		}
	}

	public unsafe Il2CppStructArray<int> defaultSelectedEmotes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultSelectedEmotes);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultSelectedEmotes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe float stickerEmoteDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerEmoteDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerEmoteDuration)) = num;
		}
	}

	public unsafe float stickerEmoteCooldown
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerEmoteCooldown);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerEmoteCooldown)) = num;
		}
	}

	public unsafe float masteryBadgeEmoteCooldown
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeEmoteCooldown);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeEmoteCooldown)) = num;
		}
	}

	public unsafe float spamToStartCooldown
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamToStartCooldown);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamToStartCooldown)) = num;
		}
	}

	public unsafe float spamCooldownDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamCooldownDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamCooldownDuration)) = num;
		}
	}

	public unsafe float emoteCreateVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteCreateVolume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteCreateVolume)) = num;
		}
	}

	public unsafe float masteryBadgeCreateVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeCreateVolume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeCreateVolume)) = num;
		}
	}

	public unsafe AudioManager.SFX spamSfxId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamSfxId);
			return *(AudioManager.SFX*)num;
		}
		set
		{
			*(AudioManager.SFX*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamSfxId)) = sFX;
		}
	}

	public unsafe float spamSfxVolume
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamSfxVolume);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spamSfxVolume)) = num;
		}
	}

	static EmoteManager()
	{
		Il2CppClassPointerStore<EmoteManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "EmoteManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr);
		NativeFieldInfoPtr_localSavedData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "localSavedData");
		NativeFieldInfoPtr_emoteSelectionWheel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "emoteSelectionWheel");
		NativeFieldInfoPtr_emoteData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "emoteData");
		NativeFieldInfoPtr_charEmoteSfxPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "charEmoteSfxPrefab");
		NativeFieldInfoPtr_defaultEmotePrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "defaultEmotePrefab");
		NativeFieldInfoPtr_selectableEmoteCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "selectableEmoteCount");
		NativeFieldInfoPtr_defaultSelectedEmotes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "defaultSelectedEmotes");
		NativeFieldInfoPtr_stickerEmoteDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "stickerEmoteDuration");
		NativeFieldInfoPtr_stickerEmoteCooldown = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "stickerEmoteCooldown");
		NativeFieldInfoPtr_masteryBadgeEmoteCooldown = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "masteryBadgeEmoteCooldown");
		NativeFieldInfoPtr_spamToStartCooldown = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "spamToStartCooldown");
		NativeFieldInfoPtr_spamCooldownDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "spamCooldownDuration");
		NativeFieldInfoPtr_emoteCreateVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "emoteCreateVolume");
		NativeFieldInfoPtr_masteryBadgeCreateVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "masteryBadgeCreateVolume");
		NativeFieldInfoPtr_spamSfxId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "spamSfxId");
		NativeFieldInfoPtr_spamSfxVolume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, "spamSfxVolume");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684243);
		NativeMethodInfoPtr_Start_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684244);
		NativeMethodInfoPtr_LoadEmoteWheelOptions_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684245);
		NativeMethodInfoPtr_GetEmoteWheelOptions_Public_Il2CppReferenceArray_1_OptionData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684246);
		NativeMethodInfoPtr_GetOptionDataFromEmote_Public_OptionData_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684247);
		NativeMethodInfoPtr_LoadEmoteWheelOptions_Private_Void_Il2CppReferenceArray_1_OptionData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684248);
		NativeMethodInfoPtr_LoadEmoteWheelOption_Public_Void_Int32_OptionData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684249);
		NativeMethodInfoPtr_GetEmoteByAssetId_Public_Emote_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684250);
		NativeMethodInfoPtr_GetEmoteIcon_Public_Sprite_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684251);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr, 100684252);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226059, XrefRangeEnd = 226064, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226064, XrefRangeEnd = 226065, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Start()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Start_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226077, RefRangeEnd = 226080, XrefRangeStart = 226065, XrefRangeEnd = 226077, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadEmoteWheelOptions()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadEmoteWheelOptions_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226091, RefRangeEnd = 226094, XrefRangeStart = 226080, XrefRangeEnd = 226091, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Il2CppReferenceArray<UISelectionWheel.OptionData> GetEmoteWheelOptions()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteWheelOptions_Public_Il2CppReferenceArray_1_OptionData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<UISelectionWheel.OptionData>>(intPtr) : null;
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 226109, RefRangeEnd = 226114, XrefRangeStart = 226094, XrefRangeEnd = 226109, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UISelectionWheel.OptionData GetOptionDataFromEmote(Emote emote)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetOptionDataFromEmote_Public_OptionData_Emote_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UISelectionWheel.OptionData>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226114, XrefRangeEnd = 226116, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadEmoteWheelOptions(Il2CppReferenceArray<UISelectionWheel.OptionData> optionsData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)optionsData);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadEmoteWheelOptions_Private_Void_Il2CppReferenceArray_1_OptionData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226118, RefRangeEnd = 226119, XrefRangeStart = 226116, XrefRangeEnd = 226118, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadEmoteWheelOption(int optionId, UISelectionWheel.OptionData optionData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&optionId);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)optionData);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadEmoteWheelOption_Public_Void_Int32_OptionData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 226121, RefRangeEnd = 226125, XrefRangeStart = 226119, XrefRangeEnd = 226121, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Emote GetEmoteByAssetId(int emoteAssetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&emoteAssetId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteByAssetId_Public_Emote_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Emote>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226147, RefRangeEnd = 226148, XrefRangeStart = 226125, XrefRangeEnd = 226147, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Sprite GetEmoteIcon(Emote emote)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteIcon_Public_Sprite_Emote_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226148, XrefRangeEnd = 226149, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EmoteManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EmoteManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public EmoteManager(IntPtr pointer)
		: base(pointer)
	{
	}
}

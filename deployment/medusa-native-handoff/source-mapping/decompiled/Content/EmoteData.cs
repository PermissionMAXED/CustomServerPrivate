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

namespace Il2CppBAPBAP.Content;

public class EmoteData : ScriptableObject
{
	[System.Serializable]
	public class TierConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_stickerMaterial;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Material stickerMaterial
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerMaterial);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stickerMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		static TierConfig()
		{
			Il2CppClassPointerStore<TierConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, "TierConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TierConfig>.NativeClassPtr);
			NativeFieldInfoPtr_stickerMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TierConfig>.NativeClassPtr, "stickerMaterial");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TierConfig>.NativeClassPtr, 100682925);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe TierConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TierConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public TierConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultStickerDisplayScale;

	private static readonly System.IntPtr NativeFieldInfoPtr_tierConfigs;

	private static readonly System.IntPtr NativeFieldInfoPtr_TriggerRebuild;

	private static readonly System.IntPtr NativeFieldInfoPtr_emotes;

	private static readonly System.IntPtr NativeFieldInfoPtr_emoteGroups;

	private static readonly System.IntPtr NativeFieldInfoPtr_assetEmoteOffset;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetEmoteByEmoteId_Public_Emote_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetEmoteIdByEmote_Public_Int32_Emote_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetEmoteByAssetId_Public_Emote_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetEmoteAssetIdByEmote_Public_Static_Int32_Emote_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetEmoteGroupIdByEmote_Public_Int32_Emote_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPreviousEmoteTierEmoteOnContentGroup_Public_Emote_Emote_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAssetIdOffsetByEmoteType_Public_Static_Int32_Emote_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float defaultStickerDisplayScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultStickerDisplayScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultStickerDisplayScale)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<TierConfig> tierConfigs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierConfigs);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<TierConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierConfigs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe bool TriggerRebuild
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TriggerRebuild);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TriggerRebuild)) = flag;
		}
	}

	public unsafe Il2CppReferenceArray<EmoteSO> emotes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emotes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<EmoteSO>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emotes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ContentManager.ContentGroup> emoteGroups
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteGroups);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ContentManager.ContentGroup>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteGroups)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static int assetEmoteOffset
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_assetEmoteOffset, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_assetEmoteOffset, (void*)(&num));
		}
	}

	static EmoteData()
	{
		Il2CppClassPointerStore<EmoteData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "EmoteData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EmoteData>.NativeClassPtr);
		NativeFieldInfoPtr_defaultStickerDisplayScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, "defaultStickerDisplayScale");
		NativeFieldInfoPtr_tierConfigs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, "tierConfigs");
		NativeFieldInfoPtr_TriggerRebuild = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, "TriggerRebuild");
		NativeFieldInfoPtr_emotes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, "emotes");
		NativeFieldInfoPtr_emoteGroups = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, "emoteGroups");
		NativeFieldInfoPtr_assetEmoteOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, "assetEmoteOffset");
		NativeMethodInfoPtr_GetEmoteByEmoteId_Public_Emote_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682917);
		NativeMethodInfoPtr_GetEmoteIdByEmote_Public_Int32_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682918);
		NativeMethodInfoPtr_GetEmoteByAssetId_Public_Emote_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682919);
		NativeMethodInfoPtr_GetEmoteAssetIdByEmote_Public_Static_Int32_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682920);
		NativeMethodInfoPtr_GetEmoteGroupIdByEmote_Public_Int32_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682921);
		NativeMethodInfoPtr_GetPreviousEmoteTierEmoteOnContentGroup_Public_Emote_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682922);
		NativeMethodInfoPtr_GetAssetIdOffsetByEmoteType_Public_Static_Int32_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682923);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EmoteData>.NativeClassPtr, 100682924);
	}

	[CallerCount(0)]
	public unsafe Emote GetEmoteByEmoteId(int emoteId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&emoteId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteByEmoteId_Public_Emote_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Emote>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe int GetEmoteIdByEmote(Emote emote)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteIdByEmote_Public_Int32_Emote_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 216998, RefRangeEnd = 217004, XrefRangeStart = 216994, XrefRangeEnd = 216998, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Emote GetEmoteByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteByAssetId_Public_Emote_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Emote>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 217022, RefRangeEnd = 217024, XrefRangeStart = 217004, XrefRangeEnd = 217022, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetEmoteAssetIdByEmote(Emote emote)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteAssetIdByEmote_Public_Static_Int32_Emote_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 217028, RefRangeEnd = 217030, XrefRangeStart = 217024, XrefRangeEnd = 217028, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetEmoteGroupIdByEmote(Emote emote)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEmoteGroupIdByEmote_Public_Int32_Emote_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 217036, RefRangeEnd = 217037, XrefRangeStart = 217030, XrefRangeEnd = 217036, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Emote GetPreviousEmoteTierEmoteOnContentGroup(Emote emote)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPreviousEmoteTierEmoteOnContentGroup_Public_Emote_Emote_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Emote>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 217037, XrefRangeEnd = 217055, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetAssetIdOffsetByEmoteType(Emote emote)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emote);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAssetIdOffsetByEmoteType_Public_Static_Int32_Emote_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EmoteData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EmoteData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public EmoteData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

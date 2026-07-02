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

public class PlayerBannerData : ScriptableObject
{
	[System.Serializable]
	public class PlayerBannerConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_bannerMaterial;

		private static readonly System.IntPtr NativeFieldInfoPtr_borderMaterial;

		private static readonly System.IntPtr NativeFieldInfoPtr_borderColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_shadowColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_textColor;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Material bannerMaterial
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bannerMaterial);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bannerMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		public unsafe Material borderMaterial
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_borderMaterial);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_borderMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		public unsafe Color borderColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_borderColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_borderColor)) = color;
			}
		}

		public unsafe Color shadowColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shadowColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shadowColor)) = color;
			}
		}

		public unsafe Color textColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_textColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_textColor)) = color;
			}
		}

		static PlayerBannerConfig()
		{
			Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "PlayerBannerConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr);
			NativeFieldInfoPtr_bannerMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr, "bannerMaterial");
			NativeFieldInfoPtr_borderMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr, "borderMaterial");
			NativeFieldInfoPtr_borderColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr, "borderColor");
			NativeFieldInfoPtr_shadowColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr, "shadowColor");
			NativeFieldInfoPtr_textColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr, "textColor");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr, 100682975);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe PlayerBannerConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayerBannerConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public PlayerBannerConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultDisplayScale;

	private static readonly System.IntPtr NativeFieldInfoPtr_tierConfigs;

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultPlayerBannerPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_TriggerRebuild;

	private static readonly System.IntPtr NativeFieldInfoPtr_playerBanners;

	private static readonly System.IntPtr NativeFieldInfoPtr_playerBannerGroups;

	private static readonly System.IntPtr NativeFieldInfoPtr_assetPlayerBannerOffset;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPlayerBannerByPlayerBannerId_Public_PlayerBanner_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPlayerBannerIdByPlayerBanner_Public_Int32_PlayerBanner_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPlayerBannerIdByAssetId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPlayerBannerByAssetId_Public_PlayerBanner_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPlayerBannerGroupIdByPlayerBanner_Public_Int32_PlayerBanner_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPreviousPlayerBannerTierPlayerBannerOnContentGroup_Public_PlayerBanner_PlayerBanner_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPlayerBannerAssetIdByPlayerBanner_Public_Static_Int32_PlayerBanner_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float defaultDisplayScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultDisplayScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultDisplayScale)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<PlayerBannerConfig> tierConfigs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierConfigs);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<PlayerBannerConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierConfigs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe GameObject defaultPlayerBannerPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultPlayerBannerPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultPlayerBannerPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
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

	public unsafe Il2CppReferenceArray<PlayerBannerSO> playerBanners
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBanners);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<PlayerBannerSO>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBanners)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ContentManager.ContentGroup> playerBannerGroups
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBannerGroups);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ContentManager.ContentGroup>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerBannerGroups)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static int assetPlayerBannerOffset
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_assetPlayerBannerOffset, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_assetPlayerBannerOffset, (void*)(&num));
		}
	}

	static PlayerBannerData()
	{
		Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "PlayerBannerData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr);
		NativeFieldInfoPtr_defaultDisplayScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "defaultDisplayScale");
		NativeFieldInfoPtr_tierConfigs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "tierConfigs");
		NativeFieldInfoPtr_defaultPlayerBannerPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "defaultPlayerBannerPrefab");
		NativeFieldInfoPtr_TriggerRebuild = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "TriggerRebuild");
		NativeFieldInfoPtr_playerBanners = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "playerBanners");
		NativeFieldInfoPtr_playerBannerGroups = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "playerBannerGroups");
		NativeFieldInfoPtr_assetPlayerBannerOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, "assetPlayerBannerOffset");
		NativeMethodInfoPtr_GetPlayerBannerByPlayerBannerId_Public_PlayerBanner_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682967);
		NativeMethodInfoPtr_GetPlayerBannerIdByPlayerBanner_Public_Int32_PlayerBanner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682968);
		NativeMethodInfoPtr_GetPlayerBannerIdByAssetId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682969);
		NativeMethodInfoPtr_GetPlayerBannerByAssetId_Public_PlayerBanner_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682970);
		NativeMethodInfoPtr_GetPlayerBannerGroupIdByPlayerBanner_Public_Int32_PlayerBanner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682971);
		NativeMethodInfoPtr_GetPreviousPlayerBannerTierPlayerBannerOnContentGroup_Public_PlayerBanner_PlayerBanner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682972);
		NativeMethodInfoPtr_GetPlayerBannerAssetIdByPlayerBanner_Public_Static_Int32_PlayerBanner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682973);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr, 100682974);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 217114, RefRangeEnd = 217116, XrefRangeStart = 217114, XrefRangeEnd = 217114, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerBanner GetPlayerBannerByPlayerBannerId(int playerBannerId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&playerBannerId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerBannerByPlayerBannerId_Public_PlayerBanner_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerBanner>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe int GetPlayerBannerIdByPlayerBanner(PlayerBanner playerBanner)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerBanner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerBannerIdByPlayerBanner_Public_Int32_PlayerBanner_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 217116, XrefRangeEnd = 217117, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetPlayerBannerIdByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerBannerIdByAssetId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 217118, RefRangeEnd = 217142, XrefRangeStart = 217117, XrefRangeEnd = 217118, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerBanner GetPlayerBannerByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerBannerByAssetId_Public_PlayerBanner_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerBanner>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 217146, RefRangeEnd = 217148, XrefRangeStart = 217142, XrefRangeEnd = 217146, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetPlayerBannerGroupIdByPlayerBanner(PlayerBanner playerBanner)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerBanner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerBannerGroupIdByPlayerBanner_Public_Int32_PlayerBanner_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 217154, RefRangeEnd = 217155, XrefRangeStart = 217148, XrefRangeEnd = 217154, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerBanner GetPreviousPlayerBannerTierPlayerBannerOnContentGroup(PlayerBanner playerBanner)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerBanner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPreviousPlayerBannerTierPlayerBannerOnContentGroup_Public_PlayerBanner_PlayerBanner_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerBanner>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 217155, RefRangeEnd = 217156, XrefRangeStart = 217155, XrefRangeEnd = 217155, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetPlayerBannerAssetIdByPlayerBanner(PlayerBanner playerBanner)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerBanner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPlayerBannerAssetIdByPlayerBanner_Public_Static_Int32_PlayerBanner_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerBannerData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayerBannerData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PlayerBannerData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

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

public class MasteryBadgeData : ScriptableObject
{
	[OriginalName("Assembly-CSharp.dll", "", "MasteryTierType")]
	public enum MasteryTierType
	{
		I,
		II,
		III
	}

	[System.Serializable]
	public class TierConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_tierColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_nameTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_badgeMaterial;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Color tierColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tierColor)) = color;
			}
		}

		public unsafe string nameTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe Material badgeMaterial
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_badgeMaterial);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_badgeMaterial)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		static TierConfig()
		{
			Il2CppClassPointerStore<TierConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, "TierConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TierConfig>.NativeClassPtr);
			NativeFieldInfoPtr_tierColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TierConfig>.NativeClassPtr, "tierColor");
			NativeFieldInfoPtr_nameTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TierConfig>.NativeClassPtr, "nameTranslationKey");
			NativeFieldInfoPtr_badgeMaterial = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TierConfig>.NativeClassPtr, "badgeMaterial");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TierConfig>.NativeClassPtr, 100682953);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 217071, XrefRangeEnd = 217072, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultDisplayScale;

	private static readonly System.IntPtr NativeFieldInfoPtr_tierConfigs;

	private static readonly System.IntPtr NativeFieldInfoPtr_TriggerRebuild;

	private static readonly System.IntPtr NativeFieldInfoPtr_masteryBadges;

	private static readonly System.IntPtr NativeFieldInfoPtr_masteryBadgeGroups;

	private static readonly System.IntPtr NativeFieldInfoPtr_assetMasteryBadgeOffset;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMasteryBadgeByMasteryBadgeId_Public_MasteryBadge_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMasteryBadgeIdByMasteryBadge_Public_Static_Int32_MasteryBadge_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMasteryBadgeIdByAssetId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMasteryBadgeByAssetId_Public_MasteryBadge_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMasteryBadgeGroupIdByMasteryBadge_Public_Int32_MasteryBadge_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPreviousMasteryBadgeTierMasteryBadgeOnContentGroup_Public_MasteryBadge_MasteryBadge_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMasteryBadgeAssetIdByMasteryBadge_Public_Static_Int32_MasteryBadge_0;

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

	public unsafe Il2CppReferenceArray<MasteryBadgeSO> masteryBadges
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadges);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<MasteryBadgeSO>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadges)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ContentManager.ContentGroup> masteryBadgeGroups
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeGroups);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ContentManager.ContentGroup>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_masteryBadgeGroups)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static int assetMasteryBadgeOffset
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_assetMasteryBadgeOffset, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_assetMasteryBadgeOffset, (void*)(&num));
		}
	}

	static MasteryBadgeData()
	{
		Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "MasteryBadgeData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr);
		NativeFieldInfoPtr_defaultDisplayScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, "defaultDisplayScale");
		NativeFieldInfoPtr_tierConfigs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, "tierConfigs");
		NativeFieldInfoPtr_TriggerRebuild = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, "TriggerRebuild");
		NativeFieldInfoPtr_masteryBadges = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, "masteryBadges");
		NativeFieldInfoPtr_masteryBadgeGroups = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, "masteryBadgeGroups");
		NativeFieldInfoPtr_assetMasteryBadgeOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, "assetMasteryBadgeOffset");
		NativeMethodInfoPtr_GetMasteryBadgeByMasteryBadgeId_Public_MasteryBadge_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682945);
		NativeMethodInfoPtr_GetMasteryBadgeIdByMasteryBadge_Public_Static_Int32_MasteryBadge_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682946);
		NativeMethodInfoPtr_GetMasteryBadgeIdByAssetId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682947);
		NativeMethodInfoPtr_GetMasteryBadgeByAssetId_Public_MasteryBadge_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682948);
		NativeMethodInfoPtr_GetMasteryBadgeGroupIdByMasteryBadge_Public_Int32_MasteryBadge_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682949);
		NativeMethodInfoPtr_GetPreviousMasteryBadgeTierMasteryBadgeOnContentGroup_Public_MasteryBadge_MasteryBadge_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682950);
		NativeMethodInfoPtr_GetMasteryBadgeAssetIdByMasteryBadge_Public_Static_Int32_MasteryBadge_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682951);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr, 100682952);
	}

	[CallerCount(0)]
	public unsafe MasteryBadge GetMasteryBadgeByMasteryBadgeId(int masteryBadgeId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&masteryBadgeId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMasteryBadgeByMasteryBadgeId_Public_MasteryBadge_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MasteryBadge>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe static int GetMasteryBadgeIdByMasteryBadge(MasteryBadge masteryBadge)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)masteryBadge);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMasteryBadgeIdByMasteryBadge_Public_Static_Int32_MasteryBadge_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 217072, XrefRangeEnd = 217073, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetMasteryBadgeIdByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMasteryBadgeIdByAssetId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 217074, RefRangeEnd = 217076, XrefRangeStart = 217073, XrefRangeEnd = 217074, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MasteryBadge GetMasteryBadgeByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMasteryBadgeByAssetId_Public_MasteryBadge_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MasteryBadge>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 217080, RefRangeEnd = 217081, XrefRangeStart = 217076, XrefRangeEnd = 217080, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetMasteryBadgeGroupIdByMasteryBadge(MasteryBadge masteryBadge)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)masteryBadge);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMasteryBadgeGroupIdByMasteryBadge_Public_Int32_MasteryBadge_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 217087, RefRangeEnd = 217088, XrefRangeStart = 217081, XrefRangeEnd = 217087, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MasteryBadge GetPreviousMasteryBadgeTierMasteryBadgeOnContentGroup(MasteryBadge masteryBadge)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)masteryBadge);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPreviousMasteryBadgeTierMasteryBadgeOnContentGroup_Public_MasteryBadge_MasteryBadge_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MasteryBadge>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 217088, RefRangeEnd = 217089, XrefRangeStart = 217088, XrefRangeEnd = 217088, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetMasteryBadgeAssetIdByMasteryBadge(MasteryBadge masteryBadge)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)masteryBadge);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMasteryBadgeAssetIdByMasteryBadge_Public_Static_Int32_MasteryBadge_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 217089, XrefRangeEnd = 217090, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MasteryBadgeData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MasteryBadgeData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MasteryBadgeData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

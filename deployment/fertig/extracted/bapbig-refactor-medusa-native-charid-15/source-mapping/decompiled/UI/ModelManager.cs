using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.UI;

public class ModelManager : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr__Characters_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__CharacterMastery_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__CharacterSelect_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Lobby_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Locker_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Profile_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Rankings_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Shop_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__FractalsPurchase_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__CommunityChallenge_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__BattlePass_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__CustomGameSettings_k__BackingField;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Characters_Public_get_CharacterPageModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CharacterMastery_Public_get_CharacterMasteryModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CharacterSelect_Public_get_CharacterSelectModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Lobby_Public_get_LobbyDataModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Locker_Public_get_LockerModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Profile_Public_get_ProfileModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Rankings_Public_get_RankingsModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Shop_Public_get_ShopModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_FractalsPurchase_Public_get_FractalsPurchaseModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CommunityChallenge_Public_get_CommunityChallengeModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_BattlePass_Public_get_BattlePassModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CustomGameSettings_Public_get_CustomGameSettingsModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe CharacterPageModel _Characters_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Characters_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterPageModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Characters_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterPageModel));
		}
	}

	public unsafe CharacterMasteryModel _CharacterMastery_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CharacterMastery_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterMasteryModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CharacterMastery_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterMasteryModel));
		}
	}

	public unsafe CharacterSelectModel _CharacterSelect_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CharacterSelect_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterSelectModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CharacterSelect_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterSelectModel));
		}
	}

	public unsafe LobbyDataModel _Lobby_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Lobby_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Lobby_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lobbyDataModel));
		}
	}

	public unsafe LockerModel _Locker_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Locker_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LockerModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Locker_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lockerModel));
		}
	}

	public unsafe ProfileModel _Profile_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Profile_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfileModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Profile_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)profileModel));
		}
	}

	public unsafe RankingsModel _Rankings_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Rankings_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RankingsModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Rankings_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rankingsModel));
		}
	}

	public unsafe ShopModel _Shop_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Shop_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ShopModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Shop_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)shopModel));
		}
	}

	public unsafe FractalsPurchaseModel _FractalsPurchase_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__FractalsPurchase_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FractalsPurchaseModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__FractalsPurchase_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)fractalsPurchaseModel));
		}
	}

	public unsafe CommunityChallengeModel _CommunityChallenge_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CommunityChallenge_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CommunityChallengeModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CommunityChallenge_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)communityChallengeModel));
		}
	}

	public unsafe BattlePassModel _BattlePass_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__BattlePass_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<BattlePassModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__BattlePass_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)battlePassModel));
		}
	}

	public unsafe CustomGameSettingsModel _CustomGameSettings_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CustomGameSettings_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CustomGameSettingsModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CustomGameSettings_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customGameSettingsModel));
		}
	}

	public unsafe CharacterPageModel Characters
	{
		[CallerCount(572)]
		[CachedScanResults(RefRangeStart = 33243, RefRangeEnd = 33815, XrefRangeStart = 33243, XrefRangeEnd = 33815, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Characters_Public_get_CharacterPageModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterPageModel>(intPtr) : null;
		}
	}

	public unsafe CharacterMasteryModel CharacterMastery
	{
		[CallerCount(140)]
		[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CharacterMastery_Public_get_CharacterMasteryModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterMasteryModel>(intPtr) : null;
		}
	}

	public unsafe CharacterSelectModel CharacterSelect
	{
		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 30135, RefRangeEnd = 30170, XrefRangeStart = 30135, XrefRangeEnd = 30170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CharacterSelect_Public_get_CharacterSelectModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterSelectModel>(intPtr) : null;
		}
	}

	public unsafe LobbyDataModel Lobby
	{
		[CallerCount(48)]
		[CachedScanResults(RefRangeStart = 33131, RefRangeEnd = 33179, XrefRangeStart = 33131, XrefRangeEnd = 33179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Lobby_Public_get_LobbyDataModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyDataModel>(intPtr) : null;
		}
	}

	public unsafe LockerModel Locker
	{
		[CallerCount(43)]
		[CachedScanResults(RefRangeStart = 45979, RefRangeEnd = 46022, XrefRangeStart = 45979, XrefRangeEnd = 46022, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Locker_Public_get_LockerModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LockerModel>(intPtr) : null;
		}
	}

	public unsafe ProfileModel Profile
	{
		[CallerCount(15)]
		[CachedScanResults(RefRangeStart = 33209, RefRangeEnd = 33224, XrefRangeStart = 33209, XrefRangeEnd = 33224, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Profile_Public_get_ProfileModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfileModel>(intPtr) : null;
		}
	}

	public unsafe RankingsModel Rankings
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 37701, RefRangeEnd = 37703, XrefRangeStart = 37701, XrefRangeEnd = 37703, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Rankings_Public_get_RankingsModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RankingsModel>(intPtr) : null;
		}
	}

	public unsafe ShopModel Shop
	{
		[CallerCount(34)]
		[CachedScanResults(RefRangeStart = 64384, RefRangeEnd = 64418, XrefRangeStart = 64384, XrefRangeEnd = 64418, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Shop_Public_get_ShopModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ShopModel>(intPtr) : null;
		}
	}

	public unsafe FractalsPurchaseModel FractalsPurchase
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 64418, RefRangeEnd = 64430, XrefRangeStart = 64418, XrefRangeEnd = 64430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FractalsPurchase_Public_get_FractalsPurchaseModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FractalsPurchaseModel>(intPtr) : null;
		}
	}

	public unsafe CommunityChallengeModel CommunityChallenge
	{
		[CallerCount(9)]
		[CachedScanResults(RefRangeStart = 89855, RefRangeEnd = 89864, XrefRangeStart = 89855, XrefRangeEnd = 89864, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CommunityChallenge_Public_get_CommunityChallengeModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CommunityChallengeModel>(intPtr) : null;
		}
	}

	public unsafe BattlePassModel BattlePass
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 89864, RefRangeEnd = 89876, XrefRangeStart = 89864, XrefRangeEnd = 89876, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_BattlePass_Public_get_BattlePassModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<BattlePassModel>(intPtr) : null;
		}
	}

	public unsafe CustomGameSettingsModel CustomGameSettings
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 89876, RefRangeEnd = 89888, XrefRangeStart = 89876, XrefRangeEnd = 89888, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CustomGameSettings_Public_get_CustomGameSettingsModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CustomGameSettingsModel>(intPtr) : null;
		}
	}

	static ModelManager()
	{
		Il2CppClassPointerStore<ModelManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "ModelManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ModelManager>.NativeClassPtr);
		NativeFieldInfoPtr__Characters_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<Characters>k__BackingField");
		NativeFieldInfoPtr__CharacterMastery_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<CharacterMastery>k__BackingField");
		NativeFieldInfoPtr__CharacterSelect_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<CharacterSelect>k__BackingField");
		NativeFieldInfoPtr__Lobby_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<Lobby>k__BackingField");
		NativeFieldInfoPtr__Locker_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<Locker>k__BackingField");
		NativeFieldInfoPtr__Profile_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<Profile>k__BackingField");
		NativeFieldInfoPtr__Rankings_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<Rankings>k__BackingField");
		NativeFieldInfoPtr__Shop_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<Shop>k__BackingField");
		NativeFieldInfoPtr__FractalsPurchase_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<FractalsPurchase>k__BackingField");
		NativeFieldInfoPtr__CommunityChallenge_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<CommunityChallenge>k__BackingField");
		NativeFieldInfoPtr__BattlePass_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<BattlePass>k__BackingField");
		NativeFieldInfoPtr__CustomGameSettings_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, "<CustomGameSettings>k__BackingField");
		NativeMethodInfoPtr_get_Characters_Public_get_CharacterPageModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670940);
		NativeMethodInfoPtr_get_CharacterMastery_Public_get_CharacterMasteryModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670941);
		NativeMethodInfoPtr_get_CharacterSelect_Public_get_CharacterSelectModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670942);
		NativeMethodInfoPtr_get_Lobby_Public_get_LobbyDataModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670943);
		NativeMethodInfoPtr_get_Locker_Public_get_LockerModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670944);
		NativeMethodInfoPtr_get_Profile_Public_get_ProfileModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670945);
		NativeMethodInfoPtr_get_Rankings_Public_get_RankingsModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670946);
		NativeMethodInfoPtr_get_Shop_Public_get_ShopModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670947);
		NativeMethodInfoPtr_get_FractalsPurchase_Public_get_FractalsPurchaseModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670948);
		NativeMethodInfoPtr_get_CommunityChallenge_Public_get_CommunityChallengeModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670949);
		NativeMethodInfoPtr_get_BattlePass_Public_get_BattlePassModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670950);
		NativeMethodInfoPtr_get_CustomGameSettings_Public_get_CustomGameSettingsModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670951);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelManager>.NativeClassPtr, 100670952);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 106581, RefRangeEnd = 106582, XrefRangeStart = 106487, XrefRangeEnd = 106581, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ModelManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ModelManager>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ModelManager(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

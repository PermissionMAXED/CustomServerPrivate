using System;
using System.Runtime.CompilerServices;
using Il2Cpp;
using Il2CppBAPBAP.Localisation;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UILobby : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr__lobbyConfiguration;

	private static readonly IntPtr NativeFieldInfoPtr__localisationConfiguration;

	private static readonly IntPtr NativeFieldInfoPtr__splashScreen;

	private static readonly IntPtr NativeFieldInfoPtr__uiLobbyTheme;

	private static readonly IntPtr NativeFieldInfoPtr__uiCustomLobby;

	private static readonly IntPtr NativeFieldInfoPtr_canvasGroup;

	private static readonly IntPtr NativeFieldInfoPtr__uiCompleteLoginWindow;

	private static readonly IntPtr NativeFieldInfoPtr__uiGameModePasswordWindow;

	private static readonly IntPtr NativeFieldInfoPtr__variant;

	private static readonly IntPtr NativeFieldInfoPtr__Initialized_k__BackingField;

	private static readonly IntPtr NativeMethodInfoPtr_get_Initialized_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_Initialized_Private_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DevLobby_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_Splash_Public_get_UILobbySplashScreen_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_Tabs_Public_get_UILobbyTabGroup_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_Theme_Public_get_UILobbyTheme_0;

	private static readonly IntPtr NativeMethodInfoPtr_Build_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetActions_Public_Void_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_0;

	private static readonly IntPtr NativeMethodInfoPtr_Initialise_Public_Void_ModelManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_Localise_Public_Void_Translator_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe UILobbyConfiguration _lobbyConfiguration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyConfiguration);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UILobbyConfiguration>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__lobbyConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyConfiguration));
		}
	}

	public unsafe LocalisationConfiguration _localisationConfiguration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__localisationConfiguration);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<LocalisationConfiguration>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__localisationConfiguration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)localisationConfiguration));
		}
	}

	public unsafe UILobbySplashScreen _splashScreen
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__splashScreen);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UILobbySplashScreen>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__splashScreen)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbySplashScreen));
		}
	}

	public unsafe UILobbyTheme _uiLobbyTheme
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiLobbyTheme);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UILobbyTheme>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiLobbyTheme)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyTheme));
		}
	}

	public unsafe View_Lobby_CustomGame _uiCustomLobby
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiCustomLobby);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<View_Lobby_CustomGame>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiCustomLobby)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view_Lobby_CustomGame));
		}
	}

	public unsafe CanvasGroup canvasGroup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CanvasGroup>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_canvasGroup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvasGroup));
		}
	}

	public unsafe UICompleteLoginWindow _uiCompleteLoginWindow
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiCompleteLoginWindow);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UICompleteLoginWindow>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiCompleteLoginWindow)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uICompleteLoginWindow));
		}
	}

	public unsafe UIGameModePasswordWindow _uiGameModePasswordWindow
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiGameModePasswordWindow);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UIGameModePasswordWindow>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiGameModePasswordWindow)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIGameModePasswordWindow));
		}
	}

	public unsafe UILobbyPlatformVariant _variant
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__variant);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UILobbyPlatformVariant>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__variant)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyPlatformVariant));
		}
	}

	public unsafe bool _Initialized_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Initialized_k__BackingField);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Initialized_k__BackingField)) = flag;
		}
	}

	public unsafe bool Initialized
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Initialized_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_Initialized_Private_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool DevLobby
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 99665, RefRangeEnd = 99666, XrefRangeStart = 99662, XrefRangeEnd = 99665, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DevLobby_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe UILobbySplashScreen Splash
	{
		[CallerCount(43)]
		[CachedScanResults(RefRangeStart = 45979, RefRangeEnd = 46022, XrefRangeStart = 45979, XrefRangeEnd = 46022, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Splash_Public_get_UILobbySplashScreen_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UILobbySplashScreen>(intPtr) : null;
		}
	}

	public unsafe UILobbyTabGroup Tabs
	{
		[CallerCount(291)]
		[CachedScanResults(RefRangeStart = 99666, RefRangeEnd = 99957, XrefRangeStart = 99666, XrefRangeEnd = 99666, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Tabs_Public_get_UILobbyTabGroup_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UILobbyTabGroup>(intPtr) : null;
		}
	}

	public unsafe UILobbyTheme Theme
	{
		[CallerCount(15)]
		[CachedScanResults(RefRangeStart = 33209, RefRangeEnd = 33224, XrefRangeStart = 33209, XrefRangeEnd = 33224, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Theme_Public_get_UILobbyTheme_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UILobbyTheme>(intPtr) : null;
		}
	}

	static UILobby()
	{
		Il2CppClassPointerStore<UILobby>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UILobby");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UILobby>.NativeClassPtr);
		NativeFieldInfoPtr__lobbyConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_lobbyConfiguration");
		NativeFieldInfoPtr__localisationConfiguration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_localisationConfiguration");
		NativeFieldInfoPtr__splashScreen = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_splashScreen");
		NativeFieldInfoPtr__uiLobbyTheme = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_uiLobbyTheme");
		NativeFieldInfoPtr__uiCustomLobby = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_uiCustomLobby");
		NativeFieldInfoPtr_canvasGroup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "canvasGroup");
		NativeFieldInfoPtr__uiCompleteLoginWindow = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_uiCompleteLoginWindow");
		NativeFieldInfoPtr__uiGameModePasswordWindow = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_uiGameModePasswordWindow");
		NativeFieldInfoPtr__variant = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "_variant");
		NativeFieldInfoPtr__Initialized_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobby>.NativeClassPtr, "<Initialized>k__BackingField");
		NativeMethodInfoPtr_get_Initialized_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670144);
		NativeMethodInfoPtr_set_Initialized_Private_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670145);
		NativeMethodInfoPtr_get_DevLobby_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670146);
		NativeMethodInfoPtr_get_Splash_Public_get_UILobbySplashScreen_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670147);
		NativeMethodInfoPtr_get_Tabs_Public_get_UILobbyTabGroup_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670148);
		NativeMethodInfoPtr_get_Theme_Public_get_UILobbyTheme_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670149);
		NativeMethodInfoPtr_Build_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670150);
		NativeMethodInfoPtr_SetActions_Public_Void_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670151);
		NativeMethodInfoPtr_Initialise_Public_Void_ModelManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670152);
		NativeMethodInfoPtr_Localise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670153);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobby>.NativeClassPtr, 100670154);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 99978, RefRangeEnd = 99979, XrefRangeStart = 99957, XrefRangeEnd = 99978, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Build()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Build_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 99982, RefRangeEnd = 99983, XrefRangeStart = 99979, XrefRangeEnd = 99982, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetActions(UILobbySplashScreen.Actions splashActions, UILobbyPlayTabPage.Actions playTabActions, View_Lobby_Developer.Actions developerViewActions, View_Lobby_OpenLobbyToggle.Actions partyStatusViewActions, UILobbyBattlePassTabPage.Actions battlePassTabActions, UILobbyShopTabPage.Actions storeTabActions, UILobbyProfileTabPage.Actions profileTabActions, UILobbyRankingsTabPage.Actions rankingsTabActions, View_Career_Leaderboard.Actions leaderboardActions, UILobbyLockerTabPage.Actions lockerTabActions, UILobbyCharacterSelectPage.Actions characterSelectPageActions, UILobbyCharacterCustomizePage.Actions characterCustomizePageActions, UILobbyFractalsPurchasePage.Actions fractalsPurchasePageActions, UILobbyCommunityChallengePage.Actions communityChallengePageActions, UILobbyMatchCharacterSelectPage.Actions matchCharacterSelectPageActions, View_Lobby_CustomGame.Actions customLobbyActions, View_Lobby_InviteCodePage.Actions inviteCodePageActions)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[17];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)splashActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playTabActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)developerViewActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)partyStatusViewActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)battlePassTabActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)storeTabActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)profileTabActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rankingsTabActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)leaderboardActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)9u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lockerTabActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)10u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterSelectPageActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)11u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterCustomizePageActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)12u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)fractalsPurchasePageActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)13u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)communityChallengePageActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)14u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)matchCharacterSelectPageActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)15u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customLobbyActions);
		*(IntPtr*)((byte*)ptr + checked((nuint)16u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inviteCodePageActions);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetActions_Public_Void_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_Actions_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 99996, RefRangeEnd = 99997, XrefRangeStart = 99983, XrefRangeEnd = 99996, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialise(ModelManager model)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)model);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialise_Public_Void_ModelManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 100007, RefRangeEnd = 100008, XrefRangeStart = 99997, XrefRangeEnd = 100007, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Localise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UILobby()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UILobby>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UILobby(IntPtr pointer)
		: base(pointer)
	{
	}
}

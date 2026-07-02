using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Localisation;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class ControllerManager : Il2CppSystem.Object
{
	[System.Serializable]
	public class Config : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_CharSelect;

		private static readonly System.IntPtr NativeFieldInfoPtr_Login;

		private static readonly System.IntPtr NativeFieldInfoPtr_Ping;

		private static readonly System.IntPtr NativeFieldInfoPtr_Region;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe CharSelectController.Config CharSelect
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharSelect);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharSelectController.Config>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharSelect)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
			}
		}

		public unsafe LoginController.Config Login
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Login);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LoginController.Config>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Login)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
			}
		}

		public unsafe PingController.Config Ping
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Ping);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PingController.Config>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Ping)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
			}
		}

		public unsafe RegionController.Config Region
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Region);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RegionController.Config>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Region)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
			}
		}

		static Config()
		{
			Il2CppClassPointerStore<Config>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "Config");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Config>.NativeClassPtr);
			NativeFieldInfoPtr_CharSelect = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "CharSelect");
			NativeFieldInfoPtr_Login = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "Login");
			NativeFieldInfoPtr_Ping = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "Ping");
			NativeFieldInfoPtr_Region = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "Region");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100670464);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Config()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Config>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Config(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__controllers;

	private static readonly System.IntPtr NativeFieldInfoPtr__Model_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__View_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Http_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Ws_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__NetworkConfig_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__BattlePass_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__CharSelect_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Chat_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__CommunityChallenge_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Debug_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Friends_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Iap_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Shop_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Lobby_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Locker_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Login_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Matchmaking_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Ping_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Profile_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Rankings_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__Region_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__SpawnSelect_k__BackingField;

	private static readonly System.IntPtr NativeFieldInfoPtr__CustomGames_k__BackingField;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Config_ModelManager_UILobby_HttpClient_WebSocketClient_NetworkConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Model_Public_get_ModelManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_View_Public_get_UILobby_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Http_Public_get_HttpClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Ws_Public_get_WebSocketClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworkConfig_Public_get_NetworkConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_BattlePass_Public_get_BattlePassController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CharSelect_Public_get_CharSelectController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Chat_Public_get_ChatController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CommunityChallenge_Public_get_CommunityChallengeController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Debug_Public_get_DebugController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Friends_Public_get_FriendsController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Iap_Public_get_IapController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Shop_Public_get_ShopController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Lobby_Public_get_LobbyController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Locker_Public_get_LockerController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Login_Public_get_LoginController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Matchmaking_Public_get_MatchmakingController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Ping_Public_get_PingController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Profile_Public_get_ProfileController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Rankings_Public_get_RankingsController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Region_Public_get_RegionController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_SpawnSelect_Public_get_SpawnSelectController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CustomGames_Public_get_CustomGameController_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddController_Public_Void_ControllerBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnLocalise_Public_Void_Translator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnLoginComplete_Public_Void_LoadResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Dispose_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StartCoroutine_Public_Coroutine_IEnumerator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StopCoroutine_Public_Void_IEnumerator_0;

	public unsafe List<ControllerBase> _controllers
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controllers);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<ControllerBase>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controllers)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe ModelManager _Model_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Model_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModelManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Model_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modelManager));
		}
	}

	public unsafe UILobby _View_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__View_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobby>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__View_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobby));
		}
	}

	public unsafe HttpClient _Http_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Http_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HttpClient>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Http_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)httpClient));
		}
	}

	public unsafe WebSocketClient _Ws_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Ws_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<WebSocketClient>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Ws_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)webSocketClient));
		}
	}

	public unsafe NetworkConfig _NetworkConfig_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__NetworkConfig_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__NetworkConfig_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkConfig));
		}
	}

	public unsafe BattlePassController _BattlePass_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__BattlePass_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<BattlePassController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__BattlePass_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)battlePassController));
		}
	}

	public unsafe CharSelectController _CharSelect_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CharSelect_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharSelectController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CharSelect_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charSelectController));
		}
	}

	public unsafe ChatController _Chat_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Chat_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ChatController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Chat_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)chatController));
		}
	}

	public unsafe CommunityChallengeController _CommunityChallenge_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CommunityChallenge_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CommunityChallengeController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CommunityChallenge_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)communityChallengeController));
		}
	}

	public unsafe DebugController _Debug_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Debug_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DebugController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Debug_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugController));
		}
	}

	public unsafe FriendsController _Friends_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Friends_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendsController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Friends_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendsController));
		}
	}

	public unsafe IapController _Iap_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Iap_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<IapController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Iap_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)iapController));
		}
	}

	public unsafe ShopController _Shop_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Shop_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ShopController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Shop_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)shopController));
		}
	}

	public unsafe LobbyController _Lobby_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Lobby_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Lobby_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lobbyController));
		}
	}

	public unsafe LockerController _Locker_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Locker_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LockerController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Locker_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lockerController));
		}
	}

	public unsafe LoginController _Login_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Login_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LoginController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Login_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loginController));
		}
	}

	public unsafe MatchmakingController _Matchmaking_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Matchmaking_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MatchmakingController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Matchmaking_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)matchmakingController));
		}
	}

	public unsafe PingController _Ping_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Ping_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PingController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Ping_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pingController));
		}
	}

	public unsafe ProfileController _Profile_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Profile_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfileController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Profile_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)profileController));
		}
	}

	public unsafe RankingsController _Rankings_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Rankings_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RankingsController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Rankings_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rankingsController));
		}
	}

	public unsafe RegionController _Region_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Region_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RegionController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Region_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)regionController));
		}
	}

	public unsafe SpawnSelectController _SpawnSelect_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__SpawnSelect_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SpawnSelectController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__SpawnSelect_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnSelectController));
		}
	}

	public unsafe CustomGameController _CustomGames_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CustomGames_k__BackingField);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CustomGameController>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__CustomGames_k__BackingField)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customGameController));
		}
	}

	public unsafe ModelManager Model
	{
		[CallerCount(140)]
		[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Model_Public_get_ModelManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModelManager>(intPtr) : null;
		}
	}

	public unsafe UILobby View
	{
		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 30135, RefRangeEnd = 30170, XrefRangeStart = 30135, XrefRangeEnd = 30170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_View_Public_get_UILobby_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobby>(intPtr) : null;
		}
	}

	public unsafe HttpClient Http
	{
		[CallerCount(48)]
		[CachedScanResults(RefRangeStart = 33131, RefRangeEnd = 33179, XrefRangeStart = 33131, XrefRangeEnd = 33179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Http_Public_get_HttpClient_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HttpClient>(intPtr) : null;
		}
	}

	public unsafe WebSocketClient Ws
	{
		[CallerCount(43)]
		[CachedScanResults(RefRangeStart = 45979, RefRangeEnd = 46022, XrefRangeStart = 45979, XrefRangeEnd = 46022, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Ws_Public_get_WebSocketClient_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<WebSocketClient>(intPtr) : null;
		}
	}

	public unsafe NetworkConfig NetworkConfig
	{
		[CallerCount(15)]
		[CachedScanResults(RefRangeStart = 33209, RefRangeEnd = 33224, XrefRangeStart = 33209, XrefRangeEnd = 33224, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworkConfig_Public_get_NetworkConfig_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkConfig>(intPtr) : null;
		}
	}

	public unsafe BattlePassController BattlePass
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 37701, RefRangeEnd = 37703, XrefRangeStart = 37701, XrefRangeEnd = 37703, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_BattlePass_Public_get_BattlePassController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<BattlePassController>(intPtr) : null;
		}
	}

	public unsafe CharSelectController CharSelect
	{
		[CallerCount(34)]
		[CachedScanResults(RefRangeStart = 64384, RefRangeEnd = 64418, XrefRangeStart = 64384, XrefRangeEnd = 64418, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CharSelect_Public_get_CharSelectController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharSelectController>(intPtr) : null;
		}
	}

	public unsafe ChatController Chat
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 64418, RefRangeEnd = 64430, XrefRangeStart = 64418, XrefRangeEnd = 64430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Chat_Public_get_ChatController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ChatController>(intPtr) : null;
		}
	}

	public unsafe CommunityChallengeController CommunityChallenge
	{
		[CallerCount(9)]
		[CachedScanResults(RefRangeStart = 89855, RefRangeEnd = 89864, XrefRangeStart = 89855, XrefRangeEnd = 89864, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CommunityChallenge_Public_get_CommunityChallengeController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CommunityChallengeController>(intPtr) : null;
		}
	}

	public unsafe DebugController Debug
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 89864, RefRangeEnd = 89876, XrefRangeStart = 89864, XrefRangeEnd = 89876, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Debug_Public_get_DebugController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DebugController>(intPtr) : null;
		}
	}

	public unsafe FriendsController Friends
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 89876, RefRangeEnd = 89888, XrefRangeStart = 89876, XrefRangeEnd = 89888, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Friends_Public_get_FriendsController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendsController>(intPtr) : null;
		}
	}

	public unsafe IapController Iap
	{
		[CallerCount(89)]
		[CachedScanResults(RefRangeStart = 81030, RefRangeEnd = 81119, XrefRangeStart = 81030, XrefRangeEnd = 81119, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Iap_Public_get_IapController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<IapController>(intPtr) : null;
		}
	}

	public unsafe ShopController Shop
	{
		[CallerCount(39)]
		[CachedScanResults(RefRangeStart = 98411, RefRangeEnd = 98450, XrefRangeStart = 98411, XrefRangeEnd = 98450, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Shop_Public_get_ShopController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ShopController>(intPtr) : null;
		}
	}

	public unsafe LobbyController Lobby
	{
		[CallerCount(18)]
		[CachedScanResults(RefRangeStart = 82347, RefRangeEnd = 82365, XrefRangeStart = 82347, XrefRangeEnd = 82365, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Lobby_Public_get_LobbyController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LobbyController>(intPtr) : null;
		}
	}

	public unsafe LockerController Locker
	{
		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 90106, RefRangeEnd = 90110, XrefRangeStart = 90106, XrefRangeEnd = 90110, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Locker_Public_get_LockerController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LockerController>(intPtr) : null;
		}
	}

	public unsafe LoginController Login
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 98450, RefRangeEnd = 98452, XrefRangeStart = 98450, XrefRangeEnd = 98452, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Login_Public_get_LoginController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LoginController>(intPtr) : null;
		}
	}

	public unsafe MatchmakingController Matchmaking
	{
		[CallerCount(8)]
		[CachedScanResults(RefRangeStart = 100358, RefRangeEnd = 100366, XrefRangeStart = 100358, XrefRangeEnd = 100366, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Matchmaking_Public_get_MatchmakingController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MatchmakingController>(intPtr) : null;
		}
	}

	public unsafe PingController Ping
	{
		[CallerCount(11)]
		[CachedScanResults(RefRangeStart = 100366, RefRangeEnd = 100377, XrefRangeStart = 100366, XrefRangeEnd = 100377, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Ping_Public_get_PingController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PingController>(intPtr) : null;
		}
	}

	public unsafe ProfileController Profile
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 100377, RefRangeEnd = 100378, XrefRangeStart = 100377, XrefRangeEnd = 100378, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Profile_Public_get_ProfileController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfileController>(intPtr) : null;
		}
	}

	public unsafe RankingsController Rankings
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Rankings_Public_get_RankingsController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RankingsController>(intPtr) : null;
		}
	}

	public unsafe RegionController Region
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 100378, RefRangeEnd = 100379, XrefRangeStart = 100378, XrefRangeEnd = 100379, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Region_Public_get_RegionController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RegionController>(intPtr) : null;
		}
	}

	public unsafe SpawnSelectController SpawnSelect
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 100379, RefRangeEnd = 100380, XrefRangeStart = 100379, XrefRangeEnd = 100380, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_SpawnSelect_Public_get_SpawnSelectController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SpawnSelectController>(intPtr) : null;
		}
	}

	public unsafe CustomGameController CustomGames
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 58940, RefRangeEnd = 58941, XrefRangeStart = 58940, XrefRangeEnd = 58941, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CustomGames_Public_get_CustomGameController_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CustomGameController>(intPtr) : null;
		}
	}

	static ControllerManager()
	{
		Il2CppClassPointerStore<ControllerManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "ControllerManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr);
		NativeFieldInfoPtr__controllers = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "_controllers");
		NativeFieldInfoPtr__Model_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Model>k__BackingField");
		NativeFieldInfoPtr__View_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<View>k__BackingField");
		NativeFieldInfoPtr__Http_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Http>k__BackingField");
		NativeFieldInfoPtr__Ws_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Ws>k__BackingField");
		NativeFieldInfoPtr__NetworkConfig_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<NetworkConfig>k__BackingField");
		NativeFieldInfoPtr__BattlePass_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<BattlePass>k__BackingField");
		NativeFieldInfoPtr__CharSelect_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<CharSelect>k__BackingField");
		NativeFieldInfoPtr__Chat_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Chat>k__BackingField");
		NativeFieldInfoPtr__CommunityChallenge_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<CommunityChallenge>k__BackingField");
		NativeFieldInfoPtr__Debug_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Debug>k__BackingField");
		NativeFieldInfoPtr__Friends_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Friends>k__BackingField");
		NativeFieldInfoPtr__Iap_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Iap>k__BackingField");
		NativeFieldInfoPtr__Shop_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Shop>k__BackingField");
		NativeFieldInfoPtr__Lobby_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Lobby>k__BackingField");
		NativeFieldInfoPtr__Locker_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Locker>k__BackingField");
		NativeFieldInfoPtr__Login_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Login>k__BackingField");
		NativeFieldInfoPtr__Matchmaking_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Matchmaking>k__BackingField");
		NativeFieldInfoPtr__Ping_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Ping>k__BackingField");
		NativeFieldInfoPtr__Profile_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Profile>k__BackingField");
		NativeFieldInfoPtr__Rankings_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Rankings>k__BackingField");
		NativeFieldInfoPtr__Region_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<Region>k__BackingField");
		NativeFieldInfoPtr__SpawnSelect_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<SpawnSelect>k__BackingField");
		NativeFieldInfoPtr__CustomGames_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, "<CustomGames>k__BackingField");
		NativeMethodInfoPtr__ctor_Public_Void_Config_ModelManager_UILobby_HttpClient_WebSocketClient_NetworkConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670434);
		NativeMethodInfoPtr_get_Model_Public_get_ModelManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670435);
		NativeMethodInfoPtr_get_View_Public_get_UILobby_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670436);
		NativeMethodInfoPtr_get_Http_Public_get_HttpClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670437);
		NativeMethodInfoPtr_get_Ws_Public_get_WebSocketClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670438);
		NativeMethodInfoPtr_get_NetworkConfig_Public_get_NetworkConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670439);
		NativeMethodInfoPtr_get_BattlePass_Public_get_BattlePassController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670440);
		NativeMethodInfoPtr_get_CharSelect_Public_get_CharSelectController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670441);
		NativeMethodInfoPtr_get_Chat_Public_get_ChatController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670442);
		NativeMethodInfoPtr_get_CommunityChallenge_Public_get_CommunityChallengeController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670443);
		NativeMethodInfoPtr_get_Debug_Public_get_DebugController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670444);
		NativeMethodInfoPtr_get_Friends_Public_get_FriendsController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670445);
		NativeMethodInfoPtr_get_Iap_Public_get_IapController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670446);
		NativeMethodInfoPtr_get_Shop_Public_get_ShopController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670447);
		NativeMethodInfoPtr_get_Lobby_Public_get_LobbyController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670448);
		NativeMethodInfoPtr_get_Locker_Public_get_LockerController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670449);
		NativeMethodInfoPtr_get_Login_Public_get_LoginController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670450);
		NativeMethodInfoPtr_get_Matchmaking_Public_get_MatchmakingController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670451);
		NativeMethodInfoPtr_get_Ping_Public_get_PingController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670452);
		NativeMethodInfoPtr_get_Profile_Public_get_ProfileController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670453);
		NativeMethodInfoPtr_get_Rankings_Public_get_RankingsController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670454);
		NativeMethodInfoPtr_get_Region_Public_get_RegionController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670455);
		NativeMethodInfoPtr_get_SpawnSelect_Public_get_SpawnSelectController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670456);
		NativeMethodInfoPtr_get_CustomGames_Public_get_CustomGameController_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670457);
		NativeMethodInfoPtr_AddController_Public_Void_ControllerBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670458);
		NativeMethodInfoPtr_OnLocalise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670459);
		NativeMethodInfoPtr_OnLoginComplete_Public_Void_LoadResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670460);
		NativeMethodInfoPtr_Dispose_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670461);
		NativeMethodInfoPtr_StartCoroutine_Public_Coroutine_IEnumerator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670462);
		NativeMethodInfoPtr_StopCoroutine_Public_Void_IEnumerator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr, 100670463);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 102270, RefRangeEnd = 102271, XrefRangeStart = 102171, XrefRangeEnd = 102270, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ControllerManager(Config config, ModelManager modelManager, UILobby view, HttpClient httpClient, WebSocketClient webSocketClient, NetworkConfig networkConfig)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ControllerManager>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[6];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modelManager);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)view);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)httpClient);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)webSocketClient);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkConfig);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Config_ModelManager_UILobby_HttpClient_WebSocketClient_NetworkConfig_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102271, XrefRangeEnd = 102273, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddController(ControllerBase controller)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controller);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddController_Public_Void_ControllerBase_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 102281, RefRangeEnd = 102282, XrefRangeStart = 102273, XrefRangeEnd = 102281, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnLocalise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnLocalise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 102293, RefRangeEnd = 102294, XrefRangeStart = 102282, XrefRangeEnd = 102293, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnLoginComplete(LoadResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnLoginComplete_Public_Void_LoadResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 102302, RefRangeEnd = 102303, XrefRangeStart = 102294, XrefRangeEnd = 102302, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Dispose()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Dispose_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102303, XrefRangeEnd = 102306, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Coroutine StartCoroutine(IEnumerator routine)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)routine);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StartCoroutine_Public_Coroutine_IEnumerator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Coroutine>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102306, XrefRangeEnd = 102309, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void StopCoroutine(IEnumerator routine)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)routine);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StopCoroutine_Public_Void_IEnumerator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ControllerManager(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

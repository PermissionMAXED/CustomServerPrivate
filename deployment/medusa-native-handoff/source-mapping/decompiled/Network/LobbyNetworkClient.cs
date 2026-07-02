using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.UI;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Network;

public class LobbyNetworkClient : MonoBehaviour
{
	[System.Serializable]
	public class Config : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_LogHttp;

		private static readonly System.IntPtr NativeFieldInfoPtr_LogWebsocket;

		private static readonly System.IntPtr NativeFieldInfoPtr_LobbyEnabled;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe bool LogHttp
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogHttp);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogHttp)) = flag;
			}
		}

		public unsafe bool LogWebsocket
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogWebsocket);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogWebsocket)) = flag;
			}
		}

		public unsafe bool LobbyEnabled
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LobbyEnabled);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LobbyEnabled)) = flag;
			}
		}

		static Config()
		{
			Il2CppClassPointerStore<Config>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "Config");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Config>.NativeClassPtr);
			NativeFieldInfoPtr_LogHttp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "LogHttp");
			NativeFieldInfoPtr_LogWebsocket = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "LogWebsocket");
			NativeFieldInfoPtr_LobbyEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "LobbyEnabled");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100666334);
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

	private static readonly System.IntPtr NativeFieldInfoPtr__controllerConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr__networkConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr__config;

	private static readonly System.IntPtr NativeFieldInfoPtr__httpClient;

	private static readonly System.IntPtr NativeFieldInfoPtr__websocketClient;

	private static readonly System.IntPtr NativeFieldInfoPtr__model;

	private static readonly System.IntPtr NativeFieldInfoPtr__controller;

	private static readonly System.IntPtr NativeFieldInfoPtr__view;

	private static readonly System.IntPtr NativeFieldInfoPtr_lobbyEnabled;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Model_Public_get_ModelManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Controller_Public_get_ControllerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Start_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnApplicationQuit_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetViewActions_Public_Void_ControllerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe ControllerManager.Config _controllerConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controllerConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ControllerManager.Config>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controllerConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
		}
	}

	public unsafe NetworkConfig _networkConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__networkConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__networkConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkConfig));
		}
	}

	public unsafe Config _config
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__config);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Config>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__config)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
		}
	}

	public unsafe HttpClient _httpClient
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__httpClient);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HttpClient>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__httpClient)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)httpClient));
		}
	}

	public unsafe WebSocketClient _websocketClient
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__websocketClient);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<WebSocketClient>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__websocketClient)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)webSocketClient));
		}
	}

	public unsafe ModelManager _model
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__model);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModelManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__model)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modelManager));
		}
	}

	public unsafe ControllerManager _controller
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controller);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ControllerManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controller)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager));
		}
	}

	public unsafe UILobby _view
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__view);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobby>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__view)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobby));
		}
	}

	public unsafe bool lobbyEnabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyEnabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyEnabled)) = flag;
		}
	}

	public unsafe ModelManager Model
	{
		[CallerCount(34)]
		[CachedScanResults(RefRangeStart = 64384, RefRangeEnd = 64418, XrefRangeStart = 64384, XrefRangeEnd = 64384, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	public unsafe ControllerManager Controller
	{
		[CallerCount(12)]
		[CachedScanResults(RefRangeStart = 64418, RefRangeEnd = 64430, XrefRangeStart = 64418, XrefRangeEnd = 64418, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Controller_Public_get_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ControllerManager>(intPtr) : null;
		}
	}

	static LobbyNetworkClient()
	{
		Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "LobbyNetworkClient");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr);
		NativeFieldInfoPtr__controllerConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_controllerConfig");
		NativeFieldInfoPtr__networkConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_networkConfig");
		NativeFieldInfoPtr__config = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_config");
		NativeFieldInfoPtr__httpClient = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_httpClient");
		NativeFieldInfoPtr__websocketClient = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_websocketClient");
		NativeFieldInfoPtr__model = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_model");
		NativeFieldInfoPtr__controller = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_controller");
		NativeFieldInfoPtr__view = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "_view");
		NativeFieldInfoPtr_lobbyEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, "lobbyEnabled");
		NativeMethodInfoPtr_get_Model_Public_get_ModelManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666326);
		NativeMethodInfoPtr_get_Controller_Public_get_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666327);
		NativeMethodInfoPtr_PreAwake_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666328);
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666329);
		NativeMethodInfoPtr_Start_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666330);
		NativeMethodInfoPtr_OnApplicationQuit_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666331);
		NativeMethodInfoPtr_SetViewActions_Public_Void_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666332);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr, 100666333);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PreAwake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 64430, XrefRangeEnd = 64452, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 64452, XrefRangeEnd = 64456, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Start()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Start_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 64456, XrefRangeEnd = 64458, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnApplicationQuit()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnApplicationQuit_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 64739, RefRangeEnd = 64740, XrefRangeStart = 64458, XrefRangeEnd = 64739, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetViewActions(ControllerManager controller)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controller);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetViewActions_Public_Void_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 64740, XrefRangeEnd = 64741, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LobbyNetworkClient()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LobbyNetworkClient>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LobbyNetworkClient(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

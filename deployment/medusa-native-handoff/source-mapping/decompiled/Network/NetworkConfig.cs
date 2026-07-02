using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Build;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Reflection;
using UnityEngine;

namespace Il2CppBAPBAP.Network;

public class NetworkConfig : ScriptableObject
{
	[System.Serializable]
	public class ServerConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_MatchmakingHost;

		private static readonly System.IntPtr NativeFieldInfoPtr_ListenPort;

		private static readonly System.IntPtr NativeFieldInfoPtr_HeaderSecretKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_HeaderSecret;

		private static readonly System.IntPtr NativeFieldInfoPtr_DebugPassword;

		private static readonly System.IntPtr NativeFieldInfoPtr_DebugSquadPassword;

		private static readonly System.IntPtr NativeFieldInfoPtr_DevGameAuthId;

		private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string MatchmakingHost
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MatchmakingHost);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MatchmakingHost)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int ListenPort
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ListenPort);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ListenPort)) = num;
			}
		}

		public unsafe string HeaderSecretKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HeaderSecretKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HeaderSecretKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string HeaderSecret
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HeaderSecret);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_HeaderSecret)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string DebugPassword
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DebugPassword);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DebugPassword)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string DebugSquadPassword
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DebugSquadPassword);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DebugSquadPassword)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string DevGameAuthId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DevGameAuthId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DevGameAuthId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static ServerConfig()
		{
			Il2CppClassPointerStore<ServerConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "ServerConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr);
			NativeFieldInfoPtr_MatchmakingHost = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, "MatchmakingHost");
			NativeFieldInfoPtr_ListenPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, "ListenPort");
			NativeFieldInfoPtr_HeaderSecretKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, "HeaderSecretKey");
			NativeFieldInfoPtr_HeaderSecret = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, "HeaderSecret");
			NativeFieldInfoPtr_DebugPassword = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, "DebugPassword");
			NativeFieldInfoPtr_DebugSquadPassword = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, "DebugSquadPassword");
			NativeFieldInfoPtr_DevGameAuthId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, "DevGameAuthId");
			NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, 100666636);
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr, 100666637);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 65089, XrefRangeEnd = 65120, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override string ToString()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_ToString_Public_Virtual_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ServerConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ServerConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ServerConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ClientConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_ApiHost;

		private static readonly System.IntPtr NativeFieldInfoPtr_CookieDomain;

		private static readonly System.IntPtr NativeFieldInfoPtr_CookieSessionKey;

		private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string ApiHost
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ApiHost);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ApiHost)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string CookieDomain
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CookieDomain);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CookieDomain)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string CookieSessionKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CookieSessionKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CookieSessionKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static ClientConfig()
		{
			Il2CppClassPointerStore<ClientConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "ClientConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ClientConfig>.NativeClassPtr);
			NativeFieldInfoPtr_ApiHost = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientConfig>.NativeClassPtr, "ApiHost");
			NativeFieldInfoPtr_CookieDomain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientConfig>.NativeClassPtr, "CookieDomain");
			NativeFieldInfoPtr_CookieSessionKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientConfig>.NativeClassPtr, "CookieSessionKey");
			NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientConfig>.NativeClassPtr, 100666638);
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientConfig>.NativeClassPtr, 100666639);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 65120, XrefRangeEnd = 65137, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override string ToString()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_ToString_Public_Virtual_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ClientConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ClientConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ClientConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private sealed class MethodInfoStoreGeneric_LoadJsonFromResources_Private_T_String_0<T>
	{
		internal static System.IntPtr Pointer = IL2CPP.il2cpp_method_get_from_reflection(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)new MethodInfo(IL2CPP.il2cpp_method_get_object(NativeMethodInfoPtr_LoadJsonFromResources_Private_T_String_0, Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr)).MakeGenericMethod(new Il2CppReferenceArray<Il2CppSystem.Type>(new Il2CppSystem.Type[1] { Il2CppSystem.Type.internal_from_handle(IL2CPP.il2cpp_class_get_type(Il2CppClassPointerStore<T>.NativeClassPtr)) }))));
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_SERVER_RESOURCE_PATH;

	private static readonly System.IntPtr NativeFieldInfoPtr_CLIENT_RESOURCE_PATH;

	private static readonly System.IntPtr NativeFieldInfoPtr__targetEnvironment;

	private static readonly System.IntPtr NativeFieldInfoPtr__serverList;

	private static readonly System.IntPtr NativeFieldInfoPtr__clientList;

	private static readonly System.IntPtr NativeFieldInfoPtr__server;

	private static readonly System.IntPtr NativeFieldInfoPtr__client;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_TargetEnvironment_Public_get_BuildEnvironment_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Server_Public_get_ServerConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Client_Public_get_ClientConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadJsonFromResources_Private_T_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetServer_Public_ServerConfig_BuildEnvironment_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetClient_Public_ClientConfig_BuildEnvironment_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe static string SERVER_RESOURCE_PATH
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SERVER_RESOURCE_PATH, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SERVER_RESOURCE_PATH, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string CLIENT_RESOURCE_PATH
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_CLIENT_RESOURCE_PATH, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_CLIENT_RESOURCE_PATH, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe BuildEnvironment _targetEnvironment
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetEnvironment);
			return *(BuildEnvironment*)num;
		}
		set
		{
			*(BuildEnvironment*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetEnvironment)) = buildEnvironment;
		}
	}

	public unsafe Il2CppReferenceArray<ServerConfig> _serverList
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__serverList);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ServerConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__serverList)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ClientConfig> _clientList
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clientList);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ClientConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__clientList)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe ServerConfig _server
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__server);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ServerConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__server)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serverConfig));
		}
	}

	public unsafe ClientConfig _client
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__client);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ClientConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__client)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)clientConfig));
		}
	}

	public unsafe BuildEnvironment TargetEnvironment
	{
		[CallerCount(140)]
		[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_TargetEnvironment_Public_get_BuildEnvironment_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(BuildEnvironment*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe ServerConfig Server
	{
		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 65140, RefRangeEnd = 65143, XrefRangeStart = 65137, XrefRangeEnd = 65140, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Server_Public_get_ServerConfig_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ServerConfig>(intPtr) : null;
		}
	}

	public unsafe ClientConfig Client
	{
		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 65146, RefRangeEnd = 65150, XrefRangeStart = 65143, XrefRangeEnd = 65146, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Client_Public_get_ClientConfig_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ClientConfig>(intPtr) : null;
		}
	}

	static NetworkConfig()
	{
		Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "NetworkConfig");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr);
		NativeFieldInfoPtr_SERVER_RESOURCE_PATH = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "SERVER_RESOURCE_PATH");
		NativeFieldInfoPtr_CLIENT_RESOURCE_PATH = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "CLIENT_RESOURCE_PATH");
		NativeFieldInfoPtr__targetEnvironment = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "_targetEnvironment");
		NativeFieldInfoPtr__serverList = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "_serverList");
		NativeFieldInfoPtr__clientList = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "_clientList");
		NativeFieldInfoPtr__server = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "_server");
		NativeFieldInfoPtr__client = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, "_client");
		NativeMethodInfoPtr_get_TargetEnvironment_Public_get_BuildEnvironment_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, 100666629);
		NativeMethodInfoPtr_get_Server_Public_get_ServerConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, 100666630);
		NativeMethodInfoPtr_get_Client_Public_get_ClientConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, 100666631);
		NativeMethodInfoPtr_LoadJsonFromResources_Private_T_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, 100666632);
		NativeMethodInfoPtr_GetServer_Public_ServerConfig_BuildEnvironment_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, 100666633);
		NativeMethodInfoPtr_GetClient_Public_ClientConfig_BuildEnvironment_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, 100666634);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr, 100666635);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 65156, RefRangeEnd = 65166, XrefRangeStart = 65150, XrefRangeEnd = 65156, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe T LoadJsonFromResources<T>(string path)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(path);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(MethodInfoStoreGeneric_LoadJsonFromResources_Private_T_String_0<T>.Pointer, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.PointerToValueGeneric<T>(intPtr, false, true);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 65166, RefRangeEnd = 65167, XrefRangeStart = 65166, XrefRangeEnd = 65166, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ServerConfig GetServer(BuildEnvironment environment)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&environment);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetServer_Public_ServerConfig_BuildEnvironment_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ServerConfig>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe ClientConfig GetClient(BuildEnvironment environment)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&environment);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetClient_Public_ClientConfig_BuildEnvironment_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ClientConfig>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NetworkConfig()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NetworkConfig>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public NetworkConfig(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

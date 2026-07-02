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
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class ControllerBase : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr__controllerManager;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Protected_Void_ControllerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnLocalise_Public_Virtual_New_Void_Translator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_New_Void_LoadResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Dispose_Public_Virtual_New_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Controller_Protected_get_ControllerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Model_Protected_get_ModelManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_View_Protected_get_UILobby_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Http_Protected_get_HttpClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_WS_Protected_get_WebSocketClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworkConfig_Protected_get_NetworkConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StartCoroutine_Protected_Coroutine_IEnumerator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StopCoroutine_Protected_Void_IEnumerator_0;

	public unsafe ControllerManager _controllerManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controllerManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ControllerManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controllerManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager));
		}
	}

	public unsafe ControllerManager Controller
	{
		[CallerCount(572)]
		[CachedScanResults(RefRangeStart = 33243, RefRangeEnd = 33815, XrefRangeStart = 33243, XrefRangeEnd = 33815, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Controller_Protected_get_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ControllerManager>(intPtr) : null;
		}
	}

	public unsafe ModelManager Model
	{
		[CallerCount(279)]
		[CachedScanResults(RefRangeStart = 101677, RefRangeEnd = 101956, XrefRangeStart = 101677, XrefRangeEnd = 101677, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Model_Protected_get_ModelManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModelManager>(intPtr) : null;
		}
	}

	public unsafe UILobby View
	{
		[CallerCount(192)]
		[CachedScanResults(RefRangeStart = 101956, RefRangeEnd = 102148, XrefRangeStart = 101956, XrefRangeEnd = 101956, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_View_Protected_get_UILobby_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobby>(intPtr) : null;
		}
	}

	public unsafe HttpClient Http
	{
		[CallerCount(61)]
		[CachedScanResults(RefRangeStart = 33874, RefRangeEnd = 33935, XrefRangeStart = 33874, XrefRangeEnd = 33935, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Http_Protected_get_HttpClient_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HttpClient>(intPtr) : null;
		}
	}

	public unsafe WebSocketClient WS
	{
		[CallerCount(69)]
		[CachedScanResults(RefRangeStart = 33935, RefRangeEnd = 34004, XrefRangeStart = 33935, XrefRangeEnd = 34004, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_WS_Protected_get_WebSocketClient_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<WebSocketClient>(intPtr) : null;
		}
	}

	public unsafe NetworkConfig NetworkConfig
	{
		[CallerCount(11)]
		[CachedScanResults(RefRangeStart = 34005, RefRangeEnd = 34016, XrefRangeStart = 34005, XrefRangeEnd = 34016, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworkConfig_Protected_get_NetworkConfig_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkConfig>(intPtr) : null;
		}
	}

	static ControllerBase()
	{
		Il2CppClassPointerStore<ControllerBase>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "ControllerBase");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr);
		NativeFieldInfoPtr__controllerManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, "_controllerManager");
		NativeMethodInfoPtr__ctor_Protected_Void_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670422);
		NativeMethodInfoPtr_OnLocalise_Public_Virtual_New_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670423);
		NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_New_Void_LoadResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670424);
		NativeMethodInfoPtr_Dispose_Public_Virtual_New_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670425);
		NativeMethodInfoPtr_get_Controller_Protected_get_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670426);
		NativeMethodInfoPtr_get_Model_Protected_get_ModelManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670427);
		NativeMethodInfoPtr_get_View_Protected_get_UILobby_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670428);
		NativeMethodInfoPtr_get_Http_Protected_get_HttpClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670429);
		NativeMethodInfoPtr_get_WS_Protected_get_WebSocketClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670430);
		NativeMethodInfoPtr_get_NetworkConfig_Protected_get_NetworkConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670431);
		NativeMethodInfoPtr_StartCoroutine_Protected_Coroutine_IEnumerator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670432);
		NativeMethodInfoPtr_StopCoroutine_Protected_Void_IEnumerator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr, 100670433);
	}

	[CallerCount(22)]
	[CachedScanResults(RefRangeStart = 101655, RefRangeEnd = 101677, XrefRangeStart = 101652, XrefRangeEnd = 101655, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ControllerBase(ControllerManager controllerManager)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ControllerBase>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Protected_Void_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnLocalise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnLocalise_Public_Virtual_New_Void_Translator_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void OnLoginComplete(LoadResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_New_Void_LoadResponse_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void Dispose()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Dispose_Public_Virtual_New_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(14)]
	[CachedScanResults(RefRangeStart = 102151, RefRangeEnd = 102165, XrefRangeStart = 102148, XrefRangeEnd = 102151, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Coroutine StartCoroutine(IEnumerator routine)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)routine);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StartCoroutine_Protected_Coroutine_IEnumerator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Coroutine>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 102168, RefRangeEnd = 102171, XrefRangeStart = 102165, XrefRangeEnd = 102168, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void StopCoroutine(IEnumerator routine)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)routine);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StopCoroutine_Protected_Void_IEnumerator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ControllerBase(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

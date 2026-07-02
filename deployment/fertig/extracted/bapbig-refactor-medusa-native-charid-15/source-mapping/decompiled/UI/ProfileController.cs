using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.UI;

public class ProfileController : ControllerBase
{
	private static readonly IntPtr NativeFieldInfoPtr_AUTO_LOGIN_KEY;

	private static readonly IntPtr NativeFieldInfoPtr_SESSION_ID_KEY;

	private static readonly IntPtr NativeMethodInfoPtr_get_AutoLogin_Private_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AutoLogin_Private_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_SessionId_Private_get_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_SessionId_Private_set_Void_String_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendProfileRequest_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendLogoutRequest_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleLogoutResponse_Private_Void_LogoutResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleProfileResponse_Private_Void_ProfileResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateProfileTabData_Private_Void_ProfileResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateProfileTabData_Private_Void_LoadResponse_0;

	public unsafe static string AUTO_LOGIN_KEY
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AUTO_LOGIN_KEY, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AUTO_LOGIN_KEY, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string SESSION_ID_KEY
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_SESSION_ID_KEY, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_SESSION_ID_KEY, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool AutoLogin
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105324, XrefRangeEnd = 105326, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AutoLogin_Private_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105326, XrefRangeEnd = 105328, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AutoLogin_Private_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe string SessionId
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105328, XrefRangeEnd = 105331, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_SessionId_Private_get_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105331, XrefRangeEnd = 105333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_SessionId_Private_set_Void_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	static ProfileController()
	{
		Il2CppClassPointerStore<ProfileController>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "ProfileController");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ProfileController>.NativeClassPtr);
		NativeFieldInfoPtr_AUTO_LOGIN_KEY = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, "AUTO_LOGIN_KEY");
		NativeFieldInfoPtr_SESSION_ID_KEY = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, "SESSION_ID_KEY");
		NativeMethodInfoPtr_get_AutoLogin_Private_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670784);
		NativeMethodInfoPtr_set_AutoLogin_Private_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670785);
		NativeMethodInfoPtr_get_SessionId_Private_get_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670786);
		NativeMethodInfoPtr_set_SessionId_Private_set_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670787);
		NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670788);
		NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670789);
		NativeMethodInfoPtr_SendProfileRequest_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670790);
		NativeMethodInfoPtr_SendLogoutRequest_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670791);
		NativeMethodInfoPtr_HandleLogoutResponse_Private_Void_LogoutResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670792);
		NativeMethodInfoPtr_HandleProfileResponse_Private_Void_ProfileResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670793);
		NativeMethodInfoPtr_UpdateProfileTabData_Private_Void_ProfileResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670794);
		NativeMethodInfoPtr_UpdateProfileTabData_Private_Void_LoadResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileController>.NativeClassPtr, 100670795);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 101291, RefRangeEnd = 101295, XrefRangeStart = 101291, XrefRangeEnd = 101295, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ProfileController(ControllerManager controllerManager)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ProfileController>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105333, XrefRangeEnd = 105337, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnLoginComplete(LoadResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105337, XrefRangeEnd = 105345, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendProfileRequest()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendProfileRequest_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105345, XrefRangeEnd = 105353, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendLogoutRequest()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendLogoutRequest_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleLogoutResponse(LogoutResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleLogoutResponse_Private_Void_LogoutResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105353, XrefRangeEnd = 105361, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleProfileResponse(ProfileResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleProfileResponse_Private_Void_ProfileResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 105395, RefRangeEnd = 105396, XrefRangeStart = 105361, XrefRangeEnd = 105395, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateProfileTabData(ProfileResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateProfileTabData_Private_Void_ProfileResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateProfileTabData(LoadResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateProfileTabData_Private_Void_LoadResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ProfileController(IntPtr pointer)
		: base(pointer)
	{
	}
}

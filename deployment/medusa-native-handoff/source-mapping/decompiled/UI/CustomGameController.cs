using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.UI;

public class CustomGameController : ControllerBase
{
	[System.Serializable]
	[ObfuscatedName("BAPBAP.UI.CustomGameController+<>c")]
	public sealed class __c : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___9;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__9_0;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__9_1;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__HandleUpdateSettingsSuccessResponse_b__9_0_Internal_Int32_MapMappingEntry_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__HandleUpdateSettingsSuccessResponse_b__9_1_Internal_Il2CppStructArray_1_Int32_MapMappingEntry_0;

		public unsafe static __c __9
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c));
			}
		}

		public unsafe static Il2CppSystem.Func<CustomUpdateSettingsResponse.MapMappingEntry, int> __9__9_0
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__9_0, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<CustomUpdateSettingsResponse.MapMappingEntry, int>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__9_0, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		public unsafe static Il2CppSystem.Func<CustomUpdateSettingsResponse.MapMappingEntry, Il2CppStructArray<int>> __9__9_1
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__9_1, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<CustomUpdateSettingsResponse.MapMappingEntry, Il2CppStructArray<int>>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__9_1, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		static __c()
		{
			Il2CppClassPointerStore<__c>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, "<>c");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c>.NativeClassPtr);
			NativeFieldInfoPtr___9 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9");
			NativeFieldInfoPtr___9__9_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__9_0");
			NativeFieldInfoPtr___9__9_1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__9_1");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100670479);
			NativeMethodInfoPtr__HandleUpdateSettingsSuccessResponse_b__9_0_Internal_Int32_MapMappingEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100670480);
			NativeMethodInfoPtr__HandleUpdateSettingsSuccessResponse_b__9_1_Internal_Il2CppStructArray_1_Int32_MapMappingEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100670481);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe int _HandleUpdateSettingsSuccessResponse_b__9_0(CustomUpdateSettingsResponse.MapMappingEntry mappingEntry)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mappingEntry);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__HandleUpdateSettingsSuccessResponse_b__9_0_Internal_Int32_MapMappingEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		public unsafe Il2CppStructArray<int> _HandleUpdateSettingsSuccessResponse_b__9_1(CustomUpdateSettingsResponse.MapMappingEntry mappingEntry)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mappingEntry);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__HandleUpdateSettingsSuccessResponse_b__9_1_Internal_Il2CppStructArray_1_Int32_MapMappingEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
		}

		public __c(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendJoinTeam_Public_Void_PlayerModel_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendSwitchReady_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendUpdateSettings_Public_Void_String_CustomGameSettingsModel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendStartCustomGame_Public_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleSetTeamSuccessResponse_Private_Void_CustomSetTeamResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleSetTeamFailResponse_Private_Void_CustomSetTeamResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleSwitchCustomReadyResponse_Private_Void_SwitchCustomReadySuccessResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleUpdateSettingsSuccessResponse_Private_Void_CustomUpdateSettingsResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleUpdateSettingsFailResponse_Private_Void_CustomUpdateSettingsResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleStartGameSuccess_Private_Void_StartCustomGameSuccessResponse_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_HandleStartGameFail_Private_Void_StartCustomGameFailResponse_0;

	static CustomGameController()
	{
		Il2CppClassPointerStore<CustomGameController>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "CustomGameController");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670465);
		NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670466);
		NativeMethodInfoPtr_SendJoinTeam_Public_Void_PlayerModel_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670467);
		NativeMethodInfoPtr_SendSwitchReady_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670468);
		NativeMethodInfoPtr_SendUpdateSettings_Public_Void_String_CustomGameSettingsModel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670469);
		NativeMethodInfoPtr_SendStartCustomGame_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670470);
		NativeMethodInfoPtr_HandleSetTeamSuccessResponse_Private_Void_CustomSetTeamResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670471);
		NativeMethodInfoPtr_HandleSetTeamFailResponse_Private_Void_CustomSetTeamResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670472);
		NativeMethodInfoPtr_HandleSwitchCustomReadyResponse_Private_Void_SwitchCustomReadySuccessResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670473);
		NativeMethodInfoPtr_HandleUpdateSettingsSuccessResponse_Private_Void_CustomUpdateSettingsResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670474);
		NativeMethodInfoPtr_HandleUpdateSettingsFailResponse_Private_Void_CustomUpdateSettingsResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670475);
		NativeMethodInfoPtr_HandleStartGameSuccess_Private_Void_StartCustomGameSuccessResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670476);
		NativeMethodInfoPtr_HandleStartGameFail_Private_Void_StartCustomGameFailResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr, 100670477);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 102355, RefRangeEnd = 102356, XrefRangeStart = 102309, XrefRangeEnd = 102355, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CustomGameController(ControllerManager controllerManager)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomGameController>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnLoginComplete(LoadResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102356, XrefRangeEnd = 102368, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendJoinTeam(PlayerModel playerModel, int teamId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerModel);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &teamId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendJoinTeam_Public_Void_PlayerModel_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102368, XrefRangeEnd = 102380, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendSwitchReady(bool isReady)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&isReady);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendSwitchReady_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102380, XrefRangeEnd = 102395, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendUpdateSettings(string accountId, CustomGameSettingsModel settingsModel)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(accountId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settingsModel);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendUpdateSettings_Public_Void_String_CustomGameSettingsModel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102395, XrefRangeEnd = 102407, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendStartCustomGame(bool forceStart = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&forceStart);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendStartCustomGame_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102407, XrefRangeEnd = 102424, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleSetTeamSuccessResponse(CustomSetTeamResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleSetTeamSuccessResponse_Private_Void_CustomSetTeamResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102424, XrefRangeEnd = 102428, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleSetTeamFailResponse(CustomSetTeamResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleSetTeamFailResponse_Private_Void_CustomSetTeamResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102428, XrefRangeEnd = 102436, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleSwitchCustomReadyResponse(SwitchCustomReadySuccessResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleSwitchCustomReadyResponse_Private_Void_SwitchCustomReadySuccessResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102436, XrefRangeEnd = 102461, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleUpdateSettingsSuccessResponse(CustomUpdateSettingsResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleUpdateSettingsSuccessResponse_Private_Void_CustomUpdateSettingsResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102461, XrefRangeEnd = 102466, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleUpdateSettingsFailResponse(CustomUpdateSettingsResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleUpdateSettingsFailResponse_Private_Void_CustomUpdateSettingsResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102466, XrefRangeEnd = 102472, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleStartGameSuccess(StartCustomGameSuccessResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleStartGameSuccess_Private_Void_StartCustomGameSuccessResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 102472, XrefRangeEnd = 102480, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleStartGameFail(StartCustomGameFailResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleStartGameFail_Private_Void_StartCustomGameFailResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CustomGameController(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

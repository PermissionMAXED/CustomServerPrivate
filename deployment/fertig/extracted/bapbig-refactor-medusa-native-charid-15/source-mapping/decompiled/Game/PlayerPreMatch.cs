using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Player;
using Il2CppBAPBAP.UI;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Game;

public class PlayerPreMatch : NetworkBehaviour
{
	private static readonly System.IntPtr NativeFieldInfoPtr__playerManager;

	private static readonly System.IntPtr NativeFieldInfoPtr__preMatchManager;

	private static readonly System.IntPtr NativeFieldInfoPtr__uiPreMatch;

	private static readonly System.IntPtr NativeFieldInfoPtr_LockedCharacter;

	private static readonly System.IntPtr NativeFieldInfoPtr_SelectedSpawnPoint;

	private static readonly System.IntPtr NativeFieldInfoPtr_IsSpawnLeader;

	private static readonly System.IntPtr NativeFieldInfoPtr_OnCharacterLockedEvent;

	private static readonly System.IntPtr NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_LockedCharacter;

	private static readonly System.IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Initialize_Public_Void_PlayerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetPlayerCharacter_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetTeammateCharacter_Public_Void_PlayerManager_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetPlayerCharacterLocked_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetTeammateCharacterLocked_Public_Void_PlayerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TargetSetSpawnSelection_Public_Void_NetworkConnection_Vector2_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TargetSetEnemySpawnSelection_Public_Void_NetworkConnection_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CmdTrySelectCharacter_Public_Void_PlayerManager_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CmdTryLockCharacter_Public_Void_PlayerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CmdTrySelectSpawnLocation_Public_Void_PlayerManager_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnLockStatusChanged_Public_Void_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworkLockedCharacter_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_NetworkLockedCharacter_Public_set_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworkSelectedSpawnPoint_Public_get_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_NetworkSelectedSpawnPoint_Public_set_Void_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_NetworkIsSpawnLeader_Public_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_NetworkIsSpawnLeader_Public_set_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean_Protected_Void_NetworkConnection_Vector2_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InvokeUserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2_Protected_Void_NetworkConnection_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InvokeUserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UserCode_CmdTrySelectCharacter__PlayerManager__Int32_Protected_Void_PlayerManager_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InvokeUserCode_CmdTrySelectCharacter__PlayerManager__Int32_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UserCode_CmdTryLockCharacter__PlayerManager_Protected_Void_PlayerManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InvokeUserCode_CmdTryLockCharacter__PlayerManager_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2_Protected_Void_PlayerManager_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InvokeUserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SerializeSyncVars_Public_Virtual_Void_NetworkWriter_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DeserializeSyncVars_Public_Virtual_Void_NetworkReader_Boolean_0;

	public unsafe PlayerManager _playerManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playerManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__playerManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerManager));
		}
	}

	public unsafe PreMatchManager _preMatchManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__preMatchManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PreMatchManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__preMatchManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)preMatchManager));
		}
	}

	public unsafe UIPreMatch _uiPreMatch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiPreMatch);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIPreMatch>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__uiPreMatch)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPreMatch));
		}
	}

	public unsafe bool LockedCharacter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LockedCharacter);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LockedCharacter)) = flag;
		}
	}

	public unsafe Vector2 SelectedSpawnPoint
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SelectedSpawnPoint);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SelectedSpawnPoint)) = vector;
		}
	}

	public unsafe bool IsSpawnLeader
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsSpawnLeader);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsSpawnLeader)) = flag;
		}
	}

	public unsafe Il2CppSystem.Action OnCharacterLockedEvent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnCharacterLockedEvent);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnCharacterLockedEvent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe Il2CppSystem.Action<bool, bool> _Mirror_SyncVarHookDelegate_LockedCharacter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_LockedCharacter);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<bool, bool>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_LockedCharacter)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe bool NetworkLockedCharacter
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 119576, RefRangeEnd = 119577, XrefRangeStart = 119576, XrefRangeEnd = 119576, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworkLockedCharacter_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 119579, RefRangeEnd = 119580, XrefRangeStart = 119577, XrefRangeEnd = 119579, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		[param: In]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_NetworkLockedCharacter_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe Vector2 NetworkSelectedSpawnPoint
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworkSelectedSpawnPoint_Public_get_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 119585, RefRangeEnd = 119589, XrefRangeStart = 119580, XrefRangeEnd = 119585, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		[param: In]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_NetworkSelectedSpawnPoint_Public_set_Void_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool NetworkIsSpawnLeader
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_NetworkIsSpawnLeader_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 119594, RefRangeEnd = 119596, XrefRangeStart = 119589, XrefRangeEnd = 119594, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		[param: In]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_NetworkIsSpawnLeader_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	static PlayerPreMatch()
	{
		Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Game", "PlayerPreMatch");
		NativeFieldInfoPtr__playerManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "_playerManager");
		NativeFieldInfoPtr__preMatchManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "_preMatchManager");
		NativeFieldInfoPtr__uiPreMatch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "_uiPreMatch");
		NativeFieldInfoPtr_LockedCharacter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "LockedCharacter");
		NativeFieldInfoPtr_SelectedSpawnPoint = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "SelectedSpawnPoint");
		NativeFieldInfoPtr_IsSpawnLeader = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "IsSpawnLeader");
		NativeFieldInfoPtr_OnCharacterLockedEvent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "OnCharacterLockedEvent");
		NativeFieldInfoPtr__Mirror_SyncVarHookDelegate_LockedCharacter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, "_Mirror_SyncVarHookDelegate_LockedCharacter");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672675);
		NativeMethodInfoPtr_Initialize_Public_Void_PlayerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672676);
		NativeMethodInfoPtr_SetPlayerCharacter_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672677);
		NativeMethodInfoPtr_SetTeammateCharacter_Public_Void_PlayerManager_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672678);
		NativeMethodInfoPtr_SetPlayerCharacterLocked_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672679);
		NativeMethodInfoPtr_SetTeammateCharacterLocked_Public_Void_PlayerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672680);
		NativeMethodInfoPtr_TargetSetSpawnSelection_Public_Void_NetworkConnection_Vector2_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672681);
		NativeMethodInfoPtr_TargetSetEnemySpawnSelection_Public_Void_NetworkConnection_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672682);
		NativeMethodInfoPtr_CmdTrySelectCharacter_Public_Void_PlayerManager_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672683);
		NativeMethodInfoPtr_CmdTryLockCharacter_Public_Void_PlayerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672684);
		NativeMethodInfoPtr_CmdTrySelectSpawnLocation_Public_Void_PlayerManager_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672685);
		NativeMethodInfoPtr_OnLockStatusChanged_Public_Void_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672686);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672687);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672688);
		NativeMethodInfoPtr_get_NetworkLockedCharacter_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672689);
		NativeMethodInfoPtr_set_NetworkLockedCharacter_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672690);
		NativeMethodInfoPtr_get_NetworkSelectedSpawnPoint_Public_get_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672691);
		NativeMethodInfoPtr_set_NetworkSelectedSpawnPoint_Public_set_Void_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672692);
		NativeMethodInfoPtr_get_NetworkIsSpawnLeader_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672693);
		NativeMethodInfoPtr_set_NetworkIsSpawnLeader_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672694);
		NativeMethodInfoPtr_UserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean_Protected_Void_NetworkConnection_Vector2_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672695);
		NativeMethodInfoPtr_InvokeUserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672696);
		NativeMethodInfoPtr_UserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2_Protected_Void_NetworkConnection_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672697);
		NativeMethodInfoPtr_InvokeUserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672698);
		NativeMethodInfoPtr_UserCode_CmdTrySelectCharacter__PlayerManager__Int32_Protected_Void_PlayerManager_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672699);
		NativeMethodInfoPtr_InvokeUserCode_CmdTrySelectCharacter__PlayerManager__Int32_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672700);
		NativeMethodInfoPtr_UserCode_CmdTryLockCharacter__PlayerManager_Protected_Void_PlayerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672701);
		NativeMethodInfoPtr_InvokeUserCode_CmdTryLockCharacter__PlayerManager_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672702);
		NativeMethodInfoPtr_UserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2_Protected_Void_PlayerManager_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672703);
		NativeMethodInfoPtr_InvokeUserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672704);
		NativeMethodInfoPtr_SerializeSyncVars_Public_Virtual_Void_NetworkWriter_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672706);
		NativeMethodInfoPtr_DeserializeSyncVars_Public_Virtual_Void_NetworkReader_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr, 100672707);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119502, XrefRangeEnd = 119505, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 62085, RefRangeEnd = 62088, XrefRangeStart = 62085, XrefRangeEnd = 62088, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialize(PlayerManager playerManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerManager);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialize_Public_Void_PlayerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119505, XrefRangeEnd = 119507, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetPlayerCharacter(int charId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&charId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetPlayerCharacter_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119507, XrefRangeEnd = 119509, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetTeammateCharacter(PlayerManager teammate, int charId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammate);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &charId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetTeammateCharacter_Public_Void_PlayerManager_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119509, XrefRangeEnd = 119511, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetPlayerCharacterLocked()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetPlayerCharacterLocked_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119511, XrefRangeEnd = 119513, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetTeammateCharacterLocked(PlayerManager teammate)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)teammate);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetTeammateCharacterLocked_Public_Void_PlayerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 119524, RefRangeEnd = 119526, XrefRangeStart = 119513, XrefRangeEnd = 119524, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TargetSetSpawnSelection(NetworkConnection conn, Vector2 spawnLocation, bool isLocked)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)conn);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnLocation;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isLocked;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TargetSetSpawnSelection_Public_Void_NetworkConnection_Vector2_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119526, XrefRangeEnd = 119536, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TargetSetEnemySpawnSelection(NetworkConnection conn, Vector2 spawnLocation)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)conn);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnLocation;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TargetSetEnemySpawnSelection_Public_Void_NetworkConnection_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 119547, RefRangeEnd = 119548, XrefRangeStart = 119536, XrefRangeEnd = 119547, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CmdTrySelectCharacter(PlayerManager player, int charId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &charId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CmdTrySelectCharacter_Public_Void_PlayerManager_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 119558, RefRangeEnd = 119559, XrefRangeStart = 119548, XrefRangeEnd = 119558, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CmdTryLockCharacter(PlayerManager player)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CmdTryLockCharacter_Public_Void_PlayerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119559, XrefRangeEnd = 119570, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CmdTrySelectSpawnLocation(PlayerManager player, Vector2 spawnLocation)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnLocation;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CmdTrySelectSpawnLocation_Public_Void_PlayerManager_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void OnLockStatusChanged(bool oldValue, bool newValue)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&oldValue);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &newValue;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnLockStatusChanged_Public_Void_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119570, XrefRangeEnd = 119576, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PlayerPreMatch()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PlayerPreMatch>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool Weaved()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119596, XrefRangeEnd = 119597, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean(NetworkConnection conn, Vector2 spawnLocation, bool isLocked)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)conn);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnLocation;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isLocked;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean_Protected_Void_NetworkConnection_Vector2_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119597, XrefRangeEnd = 119606, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_TargetSetSpawnSelection__NetworkConnection__Vector2__Boolean_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119606, XrefRangeEnd = 119607, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2(NetworkConnection conn, Vector2 spawnLocation)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)conn);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnLocation;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2_Protected_Void_NetworkConnection_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119607, XrefRangeEnd = 119615, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_TargetSetEnemySpawnSelection__NetworkConnection__Vector2_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119615, XrefRangeEnd = 119625, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_CmdTrySelectCharacter__PlayerManager__Int32(PlayerManager player, int charId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &charId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_CmdTrySelectCharacter__PlayerManager__Int32_Protected_Void_PlayerManager_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119625, XrefRangeEnd = 119645, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_CmdTrySelectCharacter__PlayerManager__Int32(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_CmdTrySelectCharacter__PlayerManager__Int32_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119645, XrefRangeEnd = 119657, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_CmdTryLockCharacter__PlayerManager(PlayerManager player)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_CmdTryLockCharacter__PlayerManager_Protected_Void_PlayerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119657, XrefRangeEnd = 119678, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_CmdTryLockCharacter__PlayerManager(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_CmdTryLockCharacter__PlayerManager_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119678, XrefRangeEnd = 119679, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2(PlayerManager player, Vector2 spawnLocation)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)player);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnLocation;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2_Protected_Void_PlayerManager_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119679, XrefRangeEnd = 119690, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_CmdTrySelectSpawnLocation__PlayerManager__Vector2_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119690, XrefRangeEnd = 119695, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)writer);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &forceAll;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SerializeSyncVars_Public_Virtual_Void_NetworkWriter_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 119695, XrefRangeEnd = 119705, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &initialState;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_DeserializeSyncVars_Public_Virtual_Void_NetworkReader_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PlayerPreMatch(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

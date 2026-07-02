using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class SpawnSelectController : ControllerBase
{
	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_SelectSpawn_Public_Void_Vector2_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendSelectSpawnMessage_Private_Void_Vector2_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleChangeSpawnLocationSuccessMessage_Private_Void_ChangeSpawnLocationSuccessMessage_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleSpawnLocationUpdatedMatchmakingMessage_Private_Void_SpawnLocationUpdatedMatchmakingMessage_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleSpawnLocationSuggestedMessage_Private_Void_SpawnLocationUpdatedMatchmakingMessage_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleSpawnSelectTransitionedMessage_Private_Void_SpawnSelectTransitionedMessage_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleSpawnSelectFinalizedMessage_Private_Void_SpawnSelectFinalizedMessage_0;

	static SpawnSelectController()
	{
		Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "SpawnSelectController");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670899);
		NativeMethodInfoPtr_SelectSpawn_Public_Void_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670900);
		NativeMethodInfoPtr_SendSelectSpawnMessage_Private_Void_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670901);
		NativeMethodInfoPtr_HandleChangeSpawnLocationSuccessMessage_Private_Void_ChangeSpawnLocationSuccessMessage_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670902);
		NativeMethodInfoPtr_HandleSpawnLocationUpdatedMatchmakingMessage_Private_Void_SpawnLocationUpdatedMatchmakingMessage_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670903);
		NativeMethodInfoPtr_HandleSpawnLocationSuggestedMessage_Private_Void_SpawnLocationUpdatedMatchmakingMessage_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670904);
		NativeMethodInfoPtr_HandleSpawnSelectTransitionedMessage_Private_Void_SpawnSelectTransitionedMessage_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670905);
		NativeMethodInfoPtr_HandleSpawnSelectFinalizedMessage_Private_Void_SpawnSelectFinalizedMessage_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr, 100670906);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 106374, RefRangeEnd = 106375, XrefRangeStart = 106335, XrefRangeEnd = 106374, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SpawnSelectController(ControllerManager controllerManager)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SpawnSelectController>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106375, XrefRangeEnd = 106384, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SelectSpawn(Vector2 spawnLocation)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&spawnLocation);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SelectSpawn_Public_Void_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendSelectSpawnMessage(Vector2 spawnLocation)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&spawnLocation);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendSelectSpawnMessage_Private_Void_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106384, XrefRangeEnd = 106385, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleChangeSpawnLocationSuccessMessage(ChangeSpawnLocationSuccessMessage message)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)message);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleChangeSpawnLocationSuccessMessage_Private_Void_ChangeSpawnLocationSuccessMessage_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106385, XrefRangeEnd = 106388, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleSpawnLocationUpdatedMatchmakingMessage(SpawnLocationUpdatedMatchmakingMessage message)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)message);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleSpawnLocationUpdatedMatchmakingMessage_Private_Void_SpawnLocationUpdatedMatchmakingMessage_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleSpawnLocationSuggestedMessage(SpawnLocationUpdatedMatchmakingMessage message)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)message);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleSpawnLocationSuggestedMessage_Private_Void_SpawnLocationUpdatedMatchmakingMessage_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106388, XrefRangeEnd = 106392, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleSpawnSelectTransitionedMessage(SpawnSelectTransitionedMessage msg)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)msg);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleSpawnSelectTransitionedMessage_Private_Void_SpawnSelectTransitionedMessage_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106392, XrefRangeEnd = 106402, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleSpawnSelectFinalizedMessage(SpawnSelectFinalizedMessage msg)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)msg);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleSpawnSelectFinalizedMessage_Private_Void_SpawnSelectFinalizedMessage_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SpawnSelectController(IntPtr pointer)
		: base(pointer)
	{
	}
}

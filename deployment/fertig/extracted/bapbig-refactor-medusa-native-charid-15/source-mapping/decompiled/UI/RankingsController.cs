using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.UI;

public class RankingsController : ControllerBase
{
	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendLeaderboardPreviewRequest_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendLeaderboardAllRequestRank_Public_Void_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendLeaderboardAllRequestPage_Public_Void_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendLeaderboardSelfRequest_Public_Void_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_SendLeaderboardFriendsRequestPage_Public_Void_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleLeaderboardPreviewResponse_Private_Void_LeaderboardPreviewResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleLeaderboardAllResponse_Private_Void_LeaderboardAllResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleLeaderboardSelfResponse_Private_Void_LeaderboardSelfResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_HandleLeaderboardFriendsResponse_Private_Void_LeaderboardAllResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateRankingsTabAllData_Private_Void_LeaderboardAllResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateRankingsTabSelfData_Private_Void_LeaderboardSelfResponse_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateRankingsTabFriendsData_Private_Void_LeaderboardAllResponse_0;

	static RankingsController()
	{
		Il2CppClassPointerStore<RankingsController>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "RankingsController");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<RankingsController>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670796);
		NativeMethodInfoPtr_OnLoginComplete_Public_Virtual_Void_LoadResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670797);
		NativeMethodInfoPtr_SendLeaderboardPreviewRequest_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670798);
		NativeMethodInfoPtr_SendLeaderboardAllRequestRank_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670799);
		NativeMethodInfoPtr_SendLeaderboardAllRequestPage_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670800);
		NativeMethodInfoPtr_SendLeaderboardSelfRequest_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670801);
		NativeMethodInfoPtr_SendLeaderboardFriendsRequestPage_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670802);
		NativeMethodInfoPtr_HandleLeaderboardPreviewResponse_Private_Void_LeaderboardPreviewResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670803);
		NativeMethodInfoPtr_HandleLeaderboardAllResponse_Private_Void_LeaderboardAllResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670804);
		NativeMethodInfoPtr_HandleLeaderboardSelfResponse_Private_Void_LeaderboardSelfResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670805);
		NativeMethodInfoPtr_HandleLeaderboardFriendsResponse_Private_Void_LeaderboardAllResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670806);
		NativeMethodInfoPtr_UpdateRankingsTabAllData_Private_Void_LeaderboardAllResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670807);
		NativeMethodInfoPtr_UpdateRankingsTabSelfData_Private_Void_LeaderboardSelfResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670808);
		NativeMethodInfoPtr_UpdateRankingsTabFriendsData_Private_Void_LeaderboardAllResponse_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsController>.NativeClassPtr, 100670809);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 101291, RefRangeEnd = 101295, XrefRangeStart = 101291, XrefRangeEnd = 101295, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe RankingsController(ControllerManager controllerManager)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RankingsController>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)controllerManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_ControllerManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105396, XrefRangeEnd = 105404, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendLeaderboardPreviewRequest()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendLeaderboardPreviewRequest_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105404, XrefRangeEnd = 105418, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendLeaderboardAllRequestRank(int mode, int rankHigh)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&mode);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &rankHigh;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendLeaderboardAllRequestRank_Public_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105418, XrefRangeEnd = 105432, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendLeaderboardAllRequestPage(int mode, int page)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&mode);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &page;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendLeaderboardAllRequestPage_Public_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105432, XrefRangeEnd = 105443, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendLeaderboardSelfRequest(int mode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&mode);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendLeaderboardSelfRequest_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105443, XrefRangeEnd = 105457, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendLeaderboardFriendsRequestPage(int mode, int page)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&mode);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &page;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SendLeaderboardFriendsRequestPage_Public_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105457, XrefRangeEnd = 105477, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleLeaderboardPreviewResponse(LeaderboardPreviewResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleLeaderboardPreviewResponse_Private_Void_LeaderboardPreviewResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105477, XrefRangeEnd = 105483, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleLeaderboardAllResponse(LeaderboardAllResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleLeaderboardAllResponse_Private_Void_LeaderboardAllResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105483, XrefRangeEnd = 105489, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleLeaderboardSelfResponse(LeaderboardSelfResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleLeaderboardSelfResponse_Private_Void_LeaderboardSelfResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 105489, XrefRangeEnd = 105495, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void HandleLeaderboardFriendsResponse(LeaderboardAllResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HandleLeaderboardFriendsResponse_Private_Void_LeaderboardAllResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 105507, RefRangeEnd = 105508, XrefRangeStart = 105495, XrefRangeEnd = 105507, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateRankingsTabAllData(LeaderboardAllResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateRankingsTabAllData_Private_Void_LeaderboardAllResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 105520, RefRangeEnd = 105521, XrefRangeStart = 105508, XrefRangeEnd = 105520, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateRankingsTabSelfData(LeaderboardSelfResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateRankingsTabSelfData_Private_Void_LeaderboardSelfResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 105533, RefRangeEnd = 105534, XrefRangeStart = 105521, XrefRangeEnd = 105533, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateRankingsTabFriendsData(LeaderboardAllResponse response)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)response);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateRankingsTabFriendsData_Private_Void_LeaderboardAllResponse_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public RankingsController(IntPtr pointer)
		: base(pointer)
	{
	}
}

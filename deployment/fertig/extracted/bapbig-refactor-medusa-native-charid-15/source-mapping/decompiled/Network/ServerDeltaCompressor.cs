using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace Il2CppBAPBAP.Network;

public class ServerDeltaCompressor : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_svUpdateNum;

	private static readonly System.IntPtr NativeFieldInfoPtr_currIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_svBaselineStateWriters;

	private static readonly System.IntPtr NativeFieldInfoPtr_svDeltaStateWriter;

	private static readonly System.IntPtr NativeFieldInfoPtr_svAlreadyBaselinedPlayersSets;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Rotate_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrBaselineWriter_Private_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrevBaselineWriter_Private_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrBaselinedPlayers_Private_HashSet_1_NetworkConnection_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrevBaselinedPlayers_Private_HashSet_1_NetworkConnection_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RotateAndClear_Public_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateDelta_Public_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsAlreadyBaselined_Public_Boolean_NetworkConnection_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddBaselinedPlayer_Public_Void_NetworkConnection_0;

	public unsafe int svUpdateNum
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svUpdateNum);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svUpdateNum)) = num;
		}
	}

	public unsafe int currIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currIndex)) = num;
		}
	}

	public unsafe int prevIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevIndex)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<NetworkWriter> svBaselineStateWriters
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svBaselineStateWriters);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<NetworkWriter>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svBaselineStateWriters)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe NetworkWriter svDeltaStateWriter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svDeltaStateWriter);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkWriter>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svDeltaStateWriter)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkWriter));
		}
	}

	public unsafe Il2CppReferenceArray<HashSet<NetworkConnection>> svAlreadyBaselinedPlayersSets
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svAlreadyBaselinedPlayersSets);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<HashSet<NetworkConnection>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_svAlreadyBaselinedPlayersSets)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static ServerDeltaCompressor()
	{
		Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "ServerDeltaCompressor");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr);
		NativeFieldInfoPtr_svUpdateNum = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, "svUpdateNum");
		NativeFieldInfoPtr_currIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, "currIndex");
		NativeFieldInfoPtr_prevIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, "prevIndex");
		NativeFieldInfoPtr_svBaselineStateWriters = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, "svBaselineStateWriters");
		NativeFieldInfoPtr_svDeltaStateWriter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, "svDeltaStateWriter");
		NativeFieldInfoPtr_svAlreadyBaselinedPlayersSets = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, "svAlreadyBaselinedPlayersSets");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666249);
		NativeMethodInfoPtr_Rotate_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666250);
		NativeMethodInfoPtr_GetCurrBaselineWriter_Private_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666251);
		NativeMethodInfoPtr_GetPrevBaselineWriter_Private_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666252);
		NativeMethodInfoPtr_GetCurrBaselinedPlayers_Private_HashSet_1_NetworkConnection_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666253);
		NativeMethodInfoPtr_GetPrevBaselinedPlayers_Private_HashSet_1_NetworkConnection_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666254);
		NativeMethodInfoPtr_RotateAndClear_Public_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666255);
		NativeMethodInfoPtr_CalculateDelta_Public_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666256);
		NativeMethodInfoPtr_IsAlreadyBaselined_Public_Boolean_NetworkConnection_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666257);
		NativeMethodInfoPtr_AddBaselinedPlayer_Public_Void_NetworkConnection_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr, 100666258);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63660, RefRangeEnd = 63661, XrefRangeStart = 63638, XrefRangeEnd = 63660, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ServerDeltaCompressor()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ServerDeltaCompressor>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 63635, RefRangeEnd = 63637, XrefRangeStart = 63635, XrefRangeEnd = 63637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Rotate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Rotate_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63637, RefRangeEnd = 63638, XrefRangeStart = 63637, XrefRangeEnd = 63638, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NetworkWriter GetCurrBaselineWriter()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrBaselineWriter_Private_NetworkWriter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkWriter>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe NetworkWriter GetPrevBaselineWriter()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrevBaselineWriter_Private_NetworkWriter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkWriter>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe HashSet<NetworkConnection> GetCurrBaselinedPlayers()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrBaselinedPlayers_Private_HashSet_1_NetworkConnection_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HashSet<NetworkConnection>>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe HashSet<NetworkConnection> GetPrevBaselinedPlayers()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrevBaselinedPlayers_Private_HashSet_1_NetworkConnection_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HashSet<NetworkConnection>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63663, RefRangeEnd = 63664, XrefRangeStart = 63661, XrefRangeEnd = 63663, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NetworkWriter RotateAndClear()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RotateAndClear_Public_NetworkWriter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkWriter>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63665, RefRangeEnd = 63666, XrefRangeStart = 63664, XrefRangeEnd = 63665, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NetworkWriter CalculateDelta()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateDelta_Public_NetworkWriter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkWriter>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63668, RefRangeEnd = 63669, XrefRangeStart = 63666, XrefRangeEnd = 63668, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsAlreadyBaselined(NetworkConnection conn)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)conn);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsAlreadyBaselined_Public_Boolean_NetworkConnection_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63671, RefRangeEnd = 63672, XrefRangeStart = 63669, XrefRangeEnd = 63671, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddBaselinedPlayer(NetworkConnection conn)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)conn);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddBaselinedPlayer_Public_Void_NetworkConnection_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ServerDeltaCompressor(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

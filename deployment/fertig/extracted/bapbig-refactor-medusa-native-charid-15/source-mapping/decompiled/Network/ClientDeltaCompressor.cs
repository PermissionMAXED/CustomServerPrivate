using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

public class ClientDeltaCompressor : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_rotateId;

	private static readonly System.IntPtr NativeFieldInfoPtr_currIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_baselineStateWriters;

	private static readonly System.IntPtr NativeFieldInfoPtr_deltaStateWriter;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StoreBaseline_Public_Void_ArraySegment_1_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ReconstructAndStoreBaseline_Public_ArraySegment_1_Byte_ArraySegment_1_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RotateWriters_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrBaselineWriter_Public_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrevBaselineWriter_Private_NetworkWriter_0;

	public unsafe int rotateId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotateId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotateId)) = num;
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

	public unsafe Il2CppReferenceArray<NetworkWriter> baselineStateWriters
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baselineStateWriters);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<NetworkWriter>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baselineStateWriters)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe NetworkWriter deltaStateWriter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deltaStateWriter);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NetworkWriter>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deltaStateWriter)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkWriter));
		}
	}

	static ClientDeltaCompressor()
	{
		Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "ClientDeltaCompressor");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr);
		NativeFieldInfoPtr_rotateId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, "rotateId");
		NativeFieldInfoPtr_currIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, "currIndex");
		NativeFieldInfoPtr_prevIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, "prevIndex");
		NativeFieldInfoPtr_baselineStateWriters = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, "baselineStateWriters");
		NativeFieldInfoPtr_deltaStateWriter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, "deltaStateWriter");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, 100666243);
		NativeMethodInfoPtr_StoreBaseline_Public_Void_ArraySegment_1_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, 100666244);
		NativeMethodInfoPtr_ReconstructAndStoreBaseline_Public_ArraySegment_1_Byte_ArraySegment_1_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, 100666245);
		NativeMethodInfoPtr_RotateWriters_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, 100666246);
		NativeMethodInfoPtr_GetCurrBaselineWriter_Public_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, 100666247);
		NativeMethodInfoPtr_GetPrevBaselineWriter_Private_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr, 100666248);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63618, RefRangeEnd = 63619, XrefRangeStart = 63606, XrefRangeEnd = 63618, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ClientDeltaCompressor()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ClientDeltaCompressor>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63625, RefRangeEnd = 63626, XrefRangeStart = 63619, XrefRangeEnd = 63625, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void StoreBaseline(Il2CppSystem.ArraySegment<byte> svBaselineState)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)svBaselineState));
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StoreBaseline_Public_Void_ArraySegment_1_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 63626, XrefRangeEnd = 63635, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Il2CppSystem.ArraySegment<byte> ReconstructAndStoreBaseline(Il2CppSystem.ArraySegment<byte> svDeltaState)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)svDeltaState));
		Unsafe.SkipInit(out System.IntPtr intPtr);
		System.IntPtr pointer = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ReconstructAndStoreBaseline_Public_ArraySegment_1_Byte_ArraySegment_1_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr);
		Il2CppException.RaiseExceptionIfNecessary(intPtr);
		return new Il2CppSystem.ArraySegment<byte>(pointer);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 63635, RefRangeEnd = 63637, XrefRangeStart = 63635, XrefRangeEnd = 63635, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RotateWriters()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RotateWriters_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 63637, RefRangeEnd = 63638, XrefRangeStart = 63637, XrefRangeEnd = 63637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NetworkWriter GetCurrBaselineWriter()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrBaselineWriter_Public_NetworkWriter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
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

	public ClientDeltaCompressor(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Entities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Game.Dimensions;

public class SinCityLivesTracker : MonoBehaviour
{
	[StructLayout(LayoutKind.Explicit)]
	public struct SinLives
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_playerId;

		private static readonly System.IntPtr NativeFieldInfoPtr_lives;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0;

		[FieldOffset(0)]
		public int playerId;

		[FieldOffset(4)]
		public int lives;

		static SinLives()
		{
			Il2CppClassPointerStore<SinLives>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr, "SinLives");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SinLives>.NativeClassPtr);
			NativeFieldInfoPtr_playerId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SinLives>.NativeClassPtr, "playerId");
			NativeFieldInfoPtr_lives = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SinLives>.NativeClassPtr, "lives");
			NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SinLives>.NativeClassPtr, 100672921);
		}

		[CallerCount(2853)]
		[CachedScanResults(RefRangeStart = 51511, RefRangeEnd = 54364, XrefRangeStart = 51511, XrefRangeEnd = 54364, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe SinLives(int playerId, int lives)
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&playerId);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &lives;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public unsafe Il2CppSystem.Object BoxIl2CppObject()
		{
			return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<SinLives>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_P_RespawnTracker_SO;

	private static readonly System.IntPtr NativeFieldInfoPtr_players;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLives_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveLife_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe P_SinCity_RespawnTracker_SO P_RespawnTracker_SO
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_P_RespawnTracker_SO);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<P_SinCity_RespawnTracker_SO>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_P_RespawnTracker_SO)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)p_SinCity_RespawnTracker_SO));
		}
	}

	public unsafe List<SinLives> players
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_players);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<SinLives>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_players)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static SinCityLivesTracker()
	{
		Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Game.Dimensions", "SinCityLivesTracker");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr);
		NativeFieldInfoPtr_P_RespawnTracker_SO = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr, "P_RespawnTracker_SO");
		NativeFieldInfoPtr_players = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr, "players");
		NativeMethodInfoPtr_GetLives_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr, 100672918);
		NativeMethodInfoPtr_RemoveLife_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr, 100672919);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr, 100672920);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121424, XrefRangeEnd = 121430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetLives(int playerId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&playerId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLives_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 121437, RefRangeEnd = 121438, XrefRangeStart = 121430, XrefRangeEnd = 121437, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RemoveLife(int playerId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&playerId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveLife_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 121438, XrefRangeEnd = 121443, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SinCityLivesTracker()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SinCityLivesTracker>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SinCityLivesTracker(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

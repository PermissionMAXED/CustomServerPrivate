using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class MatchmakingGameData : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_reqId;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueId;

	private static readonly System.IntPtr NativeFieldInfoPtr_matchmakingGameModeId;

	private static readonly System.IntPtr NativeFieldInfoPtr_unityGameModeId;

	private static readonly System.IntPtr NativeFieldInfoPtr_unityTeamSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_avgPoints;

	private static readonly System.IntPtr NativeFieldInfoPtr_scoreTable;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapId;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModifierId;

	private static readonly System.IntPtr NativeFieldInfoPtr_dimensionData;

	private static readonly System.IntPtr NativeFieldInfoPtr_charSelectMillis;

	private static readonly System.IntPtr NativeFieldInfoPtr_spawnSelectMillis;

	private static readonly System.IntPtr NativeFieldInfoPtr_spawnShowMillis;

	private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int reqId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reqId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reqId)) = num;
		}
	}

	public unsafe string queueId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe int matchmakingGameModeId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchmakingGameModeId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_matchmakingGameModeId)) = num;
		}
	}

	public unsafe int unityGameModeId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unityGameModeId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unityGameModeId)) = num;
		}
	}

	public unsafe int unityTeamSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unityTeamSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unityTeamSize)) = num;
		}
	}

	public unsafe float avgPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_avgPoints);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_avgPoints)) = num;
		}
	}

	public unsafe List<MatchmakingScoreSheetData> scoreTable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_scoreTable);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<MatchmakingScoreSheetData>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_scoreTable)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe int mapId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapId)) = num;
		}
	}

	public unsafe Il2CppStructArray<int> gameModifierId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModifierId);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModifierId)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe List<MatchmakingDimensionData> dimensionData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<MatchmakingDimensionData>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe int charSelectMillis
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charSelectMillis);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charSelectMillis)) = num;
		}
	}

	public unsafe int spawnSelectMillis
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnSelectMillis);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnSelectMillis)) = num;
		}
	}

	public unsafe int spawnShowMillis
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnShowMillis);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnShowMillis)) = num;
		}
	}

	static MatchmakingGameData()
	{
		Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "MatchmakingGameData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr);
		NativeFieldInfoPtr_reqId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "reqId");
		NativeFieldInfoPtr_queueId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "queueId");
		NativeFieldInfoPtr_matchmakingGameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "matchmakingGameModeId");
		NativeFieldInfoPtr_unityGameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "unityGameModeId");
		NativeFieldInfoPtr_unityTeamSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "unityTeamSize");
		NativeFieldInfoPtr_avgPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "avgPoints");
		NativeFieldInfoPtr_scoreTable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "scoreTable");
		NativeFieldInfoPtr_mapId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "mapId");
		NativeFieldInfoPtr_gameModifierId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "gameModifierId");
		NativeFieldInfoPtr_dimensionData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "dimensionData");
		NativeFieldInfoPtr_charSelectMillis = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "charSelectMillis");
		NativeFieldInfoPtr_spawnSelectMillis = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "spawnSelectMillis");
		NativeFieldInfoPtr_spawnShowMillis = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, "spawnShowMillis");
		NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, 100666613);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr, 100666614);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 64748, XrefRangeEnd = 64804, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string ToString()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_ToString_Public_Virtual_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 64804, XrefRangeEnd = 64810, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MatchmakingGameData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MatchmakingGameData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MatchmakingGameData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

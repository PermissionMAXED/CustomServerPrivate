using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.UI;

public class RankingsModel : Model
{
	public class GameModeEntry : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeId;

		private static readonly System.IntPtr NativeFieldInfoPtr_showRanks;

		private static readonly System.IntPtr NativeFieldInfoPtr_showPoints;

		private static readonly System.IntPtr NativeFieldInfoPtr_showCharacters;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe int gameModeId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeId)) = num;
			}
		}

		public unsafe bool showRanks
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_showRanks);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_showRanks)) = flag;
			}
		}

		public unsafe bool showPoints
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_showPoints);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_showPoints)) = flag;
			}
		}

		public unsafe bool showCharacters
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_showCharacters);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_showCharacters)) = flag;
			}
		}

		static GameModeEntry()
		{
			Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr, "GameModeEntry");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr);
			NativeFieldInfoPtr_gameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr, "gameModeId");
			NativeFieldInfoPtr_showRanks = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr, "showRanks");
			NativeFieldInfoPtr_showPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr, "showPoints");
			NativeFieldInfoPtr_showCharacters = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr, "showCharacters");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr, 100670960);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GameModeEntry()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GameModeEntry>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public GameModeEntry(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModes;

	private static readonly System.IntPtr NativeFieldInfoPtr_isEnd;

	private static readonly System.IntPtr NativeFieldInfoPtr_pageOffset;

	private static readonly System.IntPtr NativeFieldInfoPtr_leaderboard;

	private static readonly System.IntPtr NativeFieldInfoPtr_leaderboardSelf;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<GameModeEntry> gameModes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameModeEntry>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe bool isEnd
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isEnd);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isEnd)) = flag;
		}
	}

	public unsafe int pageOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pageOffset);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pageOffset)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<LeaderboardEntryModel> leaderboard
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaderboard);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<LeaderboardEntryModel>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaderboard)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe LeaderboardEntryModel leaderboardSelf
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaderboardSelf);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LeaderboardEntryModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaderboardSelf)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)leaderboardEntryModel));
		}
	}

	static RankingsModel()
	{
		Il2CppClassPointerStore<RankingsModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "RankingsModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr);
		NativeFieldInfoPtr_gameModes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr, "gameModes");
		NativeFieldInfoPtr_isEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr, "isEnd");
		NativeFieldInfoPtr_pageOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr, "pageOffset");
		NativeFieldInfoPtr_leaderboard = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr, "leaderboard");
		NativeFieldInfoPtr_leaderboardSelf = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr, "leaderboardSelf");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr, 100670959);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe RankingsModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RankingsModel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public RankingsModel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

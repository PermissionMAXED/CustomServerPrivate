using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;

namespace Il2CppBAPBAP.UI;

public class ProfileModel : Model
{
	public class Rank : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeId;

		private static readonly System.IntPtr NativeFieldInfoPtr_rankPoints;

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

		public unsafe int rankPoints
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rankPoints);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rankPoints)) = num;
			}
		}

		static Rank()
		{
			Il2CppClassPointerStore<Rank>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "Rank");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Rank>.NativeClassPtr);
			NativeFieldInfoPtr_gameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Rank>.NativeClassPtr, "gameModeId");
			NativeFieldInfoPtr_rankPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Rank>.NativeClassPtr, "rankPoints");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Rank>.NativeClassPtr, 100670955);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Rank()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Rank>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Rank(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class Stats : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeId;

		private static readonly System.IntPtr NativeFieldInfoPtr_totalAssists;

		private static readonly System.IntPtr NativeFieldInfoPtr_totalDeaths;

		private static readonly System.IntPtr NativeFieldInfoPtr_totalKills;

		private static readonly System.IntPtr NativeFieldInfoPtr_totalLosses;

		private static readonly System.IntPtr NativeFieldInfoPtr_totalWins;

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

		public unsafe int totalAssists
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalAssists);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalAssists)) = num;
			}
		}

		public unsafe int totalDeaths
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalDeaths);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalDeaths)) = num;
			}
		}

		public unsafe int totalKills
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalKills);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalKills)) = num;
			}
		}

		public unsafe int totalLosses
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalLosses);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalLosses)) = num;
			}
		}

		public unsafe int totalWins
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalWins);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalWins)) = num;
			}
		}

		static Stats()
		{
			Il2CppClassPointerStore<Stats>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "Stats");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Stats>.NativeClassPtr);
			NativeFieldInfoPtr_gameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Stats>.NativeClassPtr, "gameModeId");
			NativeFieldInfoPtr_totalAssists = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Stats>.NativeClassPtr, "totalAssists");
			NativeFieldInfoPtr_totalDeaths = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Stats>.NativeClassPtr, "totalDeaths");
			NativeFieldInfoPtr_totalKills = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Stats>.NativeClassPtr, "totalKills");
			NativeFieldInfoPtr_totalLosses = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Stats>.NativeClassPtr, "totalLosses");
			NativeFieldInfoPtr_totalWins = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Stats>.NativeClassPtr, "totalWins");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Stats>.NativeClassPtr, 100670956);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Stats()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Stats>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Stats(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class History : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_charId;

		private static readonly System.IntPtr NativeFieldInfoPtr_assists;

		private static readonly System.IntPtr NativeFieldInfoPtr_damageDealt;

		private static readonly System.IntPtr NativeFieldInfoPtr_damageReceived;

		private static readonly System.IntPtr NativeFieldInfoPtr_deaths;

		private static readonly System.IntPtr NativeFieldInfoPtr_gameId;

		private static readonly System.IntPtr NativeFieldInfoPtr_gameModeId;

		private static readonly System.IntPtr NativeFieldInfoPtr_healingReceived;

		private static readonly System.IntPtr NativeFieldInfoPtr_items;

		private static readonly System.IntPtr NativeFieldInfoPtr_kills;

		private static readonly System.IntPtr NativeFieldInfoPtr_placement;

		private static readonly System.IntPtr NativeFieldInfoPtr_isMvp;

		private static readonly System.IntPtr NativeFieldInfoPtr_rankedPointsDelta;

		private static readonly System.IntPtr NativeFieldInfoPtr_startedAt;

		private static readonly System.IntPtr NativeFieldInfoPtr_totalPlacements;

		private static readonly System.IntPtr NativeFieldInfoPtr_teammates;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe int charId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charId)) = num;
			}
		}

		public unsafe int assists
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assists);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assists)) = num;
			}
		}

		public unsafe int damageDealt
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageDealt);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageDealt)) = num;
			}
		}

		public unsafe int damageReceived
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageReceived);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageReceived)) = num;
			}
		}

		public unsafe int deaths
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deaths);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deaths)) = num;
			}
		}

		public unsafe string gameId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

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

		public unsafe int healingReceived
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_healingReceived);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_healingReceived)) = num;
			}
		}

		public unsafe Il2CppStructArray<int> items
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_items);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_items)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe int kills
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kills);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kills)) = num;
			}
		}

		public unsafe int placement
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placement);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_placement)) = num;
			}
		}

		public unsafe bool isMvp
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isMvp);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isMvp)) = flag;
			}
		}

		public unsafe int rankedPointsDelta
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rankedPointsDelta);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rankedPointsDelta)) = num;
			}
		}

		public unsafe string startedAt
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startedAt);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startedAt)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int totalPlacements
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalPlacements);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalPlacements)) = num;
			}
		}

		public unsafe List<TeammateHistory> teammates
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teammates);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<TeammateHistory>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_teammates)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		static History()
		{
			Il2CppClassPointerStore<History>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "History");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<History>.NativeClassPtr);
			NativeFieldInfoPtr_charId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "charId");
			NativeFieldInfoPtr_assists = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "assists");
			NativeFieldInfoPtr_damageDealt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "damageDealt");
			NativeFieldInfoPtr_damageReceived = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "damageReceived");
			NativeFieldInfoPtr_deaths = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "deaths");
			NativeFieldInfoPtr_gameId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "gameId");
			NativeFieldInfoPtr_gameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "gameModeId");
			NativeFieldInfoPtr_healingReceived = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "healingReceived");
			NativeFieldInfoPtr_items = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "items");
			NativeFieldInfoPtr_kills = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "kills");
			NativeFieldInfoPtr_placement = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "placement");
			NativeFieldInfoPtr_isMvp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "isMvp");
			NativeFieldInfoPtr_rankedPointsDelta = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "rankedPointsDelta");
			NativeFieldInfoPtr_startedAt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "startedAt");
			NativeFieldInfoPtr_totalPlacements = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "totalPlacements");
			NativeFieldInfoPtr_teammates = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<History>.NativeClassPtr, "teammates");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<History>.NativeClassPtr, 100670957);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe History()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<History>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public History(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class TeammateHistory : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeFieldInfoPtr_name;

		private static readonly System.IntPtr NativeFieldInfoPtr_charId;

		private static readonly System.IntPtr NativeFieldInfoPtr_isMvp;

		private static readonly System.IntPtr NativeFieldInfoPtr_damageDealt;

		private static readonly System.IntPtr NativeFieldInfoPtr_damageReceived;

		private static readonly System.IntPtr NativeFieldInfoPtr_kills;

		private static readonly System.IntPtr NativeFieldInfoPtr_deaths;

		private static readonly System.IntPtr NativeFieldInfoPtr_assists;

		private static readonly System.IntPtr NativeFieldInfoPtr_items;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string accountId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string name
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_name);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_name)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int charId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charId)) = num;
			}
		}

		public unsafe bool isMvp
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isMvp);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isMvp)) = flag;
			}
		}

		public unsafe int damageDealt
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageDealt);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageDealt)) = num;
			}
		}

		public unsafe int damageReceived
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageReceived);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageReceived)) = num;
			}
		}

		public unsafe int kills
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kills);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kills)) = num;
			}
		}

		public unsafe int deaths
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deaths);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_deaths)) = num;
			}
		}

		public unsafe int assists
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assists);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assists)) = num;
			}
		}

		public unsafe Il2CppStructArray<int> items
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_items);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_items)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		static TeammateHistory()
		{
			Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "TeammateHistory");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr);
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "accountId");
			NativeFieldInfoPtr_name = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "name");
			NativeFieldInfoPtr_charId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "charId");
			NativeFieldInfoPtr_isMvp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "isMvp");
			NativeFieldInfoPtr_damageDealt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "damageDealt");
			NativeFieldInfoPtr_damageReceived = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "damageReceived");
			NativeFieldInfoPtr_kills = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "kills");
			NativeFieldInfoPtr_deaths = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "deaths");
			NativeFieldInfoPtr_assists = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "assists");
			NativeFieldInfoPtr_items = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, "items");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr, 100670958);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe TeammateHistory()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TeammateHistory>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public TeammateHistory(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_profileName;

	private static readonly System.IntPtr NativeFieldInfoPtr_profileDiscriminator;

	private static readonly System.IntPtr NativeFieldInfoPtr_level;

	private static readonly System.IntPtr NativeFieldInfoPtr_loadout;

	private static readonly System.IntPtr NativeFieldInfoPtr_ranks;

	private static readonly System.IntPtr NativeFieldInfoPtr_history;

	private static readonly System.IntPtr NativeFieldInfoPtr_stats;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string profileName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profileName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profileName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe int profileDiscriminator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profileDiscriminator);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profileDiscriminator)) = num;
		}
	}

	public unsafe int level
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_level);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_level)) = num;
		}
	}

	public unsafe LoadoutModel loadout
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadout);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LoadoutModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_loadout)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)loadoutModel));
		}
	}

	public unsafe Il2CppReferenceArray<Rank> ranks
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ranks);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Rank>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ranks)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<History> history
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_history);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<History>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_history)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Stats> stats
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stats);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Stats>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stats)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static ProfileModel()
	{
		Il2CppClassPointerStore<ProfileModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "ProfileModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr);
		NativeFieldInfoPtr_profileName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "profileName");
		NativeFieldInfoPtr_profileDiscriminator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "profileDiscriminator");
		NativeFieldInfoPtr_level = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "level");
		NativeFieldInfoPtr_loadout = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "loadout");
		NativeFieldInfoPtr_ranks = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "ranks");
		NativeFieldInfoPtr_history = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "history");
		NativeFieldInfoPtr_stats = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, "stats");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr, 100670954);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106590, XrefRangeEnd = 106600, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ProfileModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ProfileModel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ProfileModel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

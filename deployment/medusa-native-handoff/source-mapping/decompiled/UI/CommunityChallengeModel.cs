using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.UI;

[System.Serializable]
public class CommunityChallengeModel : Model
{
	public class ClaimLiveEntry : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_ListingId;

		private static readonly System.IntPtr NativeFieldInfoPtr_EntitlementId;

		private static readonly System.IntPtr NativeFieldInfoPtr_Tier;

		private static readonly System.IntPtr NativeFieldInfoPtr_NumLives;

		private static readonly System.IntPtr NativeFieldInfoPtr_Unlocked;

		private static readonly System.IntPtr NativeFieldInfoPtr_Claimed;

		private static readonly System.IntPtr NativeFieldInfoPtr_IsUnavailable;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string ListingId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ListingId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ListingId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string EntitlementId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntitlementId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EntitlementId)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int Tier
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Tier);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Tier)) = num;
			}
		}

		public unsafe int NumLives
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumLives);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumLives)) = num;
			}
		}

		public unsafe bool Unlocked
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Unlocked);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Unlocked)) = flag;
			}
		}

		public unsafe bool Claimed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Claimed);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Claimed)) = flag;
			}
		}

		public unsafe bool IsUnavailable
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsUnavailable);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_IsUnavailable)) = flag;
			}
		}

		static ClaimLiveEntry()
		{
			Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "ClaimLiveEntry");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr);
			NativeFieldInfoPtr_ListingId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, "ListingId");
			NativeFieldInfoPtr_EntitlementId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, "EntitlementId");
			NativeFieldInfoPtr_Tier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, "Tier");
			NativeFieldInfoPtr_NumLives = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, "NumLives");
			NativeFieldInfoPtr_Unlocked = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, "Unlocked");
			NativeFieldInfoPtr_Claimed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, "Claimed");
			NativeFieldInfoPtr_IsUnavailable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, "IsUnavailable");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr, 100670924);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ClaimLiveEntry()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ClaimLiveEntry>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ClaimLiveEntry(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_PrizePool;

	private static readonly System.IntPtr NativeFieldInfoPtr_NumSignUps;

	private static readonly System.IntPtr NativeFieldInfoPtr_NumSignUpsNeeded;

	private static readonly System.IntPtr NativeFieldInfoPtr_SignUpRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_Deadline;

	private static readonly System.IntPtr NativeFieldInfoPtr_RefCode;

	private static readonly System.IntPtr NativeFieldInfoPtr_TwitchUsername;

	private static readonly System.IntPtr NativeFieldInfoPtr_NumReferrals;

	private static readonly System.IntPtr NativeFieldInfoPtr_NumGames;

	private static readonly System.IntPtr NativeFieldInfoPtr_CurrentLives;

	private static readonly System.IntPtr NativeFieldInfoPtr_EarnReferrals;

	private static readonly System.IntPtr NativeFieldInfoPtr_EarnTwitchDrops;

	private static readonly System.IntPtr NativeFieldInfoPtr_EarnGames;

	private static readonly System.IntPtr NativeFieldInfoPtr_PrizePoolSplit;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int PrizePool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PrizePool);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PrizePool)) = num;
		}
	}

	public unsafe int NumSignUps
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumSignUps);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumSignUps)) = num;
		}
	}

	public unsafe int NumSignUpsNeeded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumSignUpsNeeded);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumSignUpsNeeded)) = num;
		}
	}

	public unsafe int SignUpRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SignUpRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_SignUpRate)) = num;
		}
	}

	public unsafe string Deadline
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Deadline);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Deadline)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string RefCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RefCode);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_RefCode)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string TwitchUsername
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TwitchUsername);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TwitchUsername)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe int NumReferrals
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumReferrals);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumReferrals)) = num;
		}
	}

	public unsafe int NumGames
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumGames);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NumGames)) = num;
		}
	}

	public unsafe int CurrentLives
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CurrentLives);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CurrentLives)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<ClaimLiveEntry> EarnReferrals
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EarnReferrals);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ClaimLiveEntry>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EarnReferrals)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ClaimLiveEntry> EarnTwitchDrops
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EarnTwitchDrops);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ClaimLiveEntry>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EarnTwitchDrops)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ClaimLiveEntry> EarnGames
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EarnGames);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ClaimLiveEntry>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EarnGames)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<float> PrizePoolSplit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PrizePoolSplit);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<float>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PrizePoolSplit)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static CommunityChallengeModel()
	{
		Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "CommunityChallengeModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr);
		NativeFieldInfoPtr_PrizePool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "PrizePool");
		NativeFieldInfoPtr_NumSignUps = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "NumSignUps");
		NativeFieldInfoPtr_NumSignUpsNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "NumSignUpsNeeded");
		NativeFieldInfoPtr_SignUpRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "SignUpRate");
		NativeFieldInfoPtr_Deadline = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "Deadline");
		NativeFieldInfoPtr_RefCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "RefCode");
		NativeFieldInfoPtr_TwitchUsername = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "TwitchUsername");
		NativeFieldInfoPtr_NumReferrals = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "NumReferrals");
		NativeFieldInfoPtr_NumGames = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "NumGames");
		NativeFieldInfoPtr_CurrentLives = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "CurrentLives");
		NativeFieldInfoPtr_EarnReferrals = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "EarnReferrals");
		NativeFieldInfoPtr_EarnTwitchDrops = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "EarnTwitchDrops");
		NativeFieldInfoPtr_EarnGames = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "EarnGames");
		NativeFieldInfoPtr_PrizePoolSplit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, "PrizePoolSplit");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr, 100670923);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106436, XrefRangeEnd = 106441, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CommunityChallengeModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CommunityChallengeModel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CommunityChallengeModel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

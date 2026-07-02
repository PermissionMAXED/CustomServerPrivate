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

public class LobbyDataModel : Model
{
	[System.Serializable]
	public class AccountPass : Il2CppSystem.Object
	{
		[System.Serializable]
		public class PassLevel : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_level;

			private static readonly System.IntPtr NativeFieldInfoPtr_xpNeeded;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

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

			public unsafe int xpNeeded
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpNeeded);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_xpNeeded)) = num;
				}
			}

			static PassLevel()
			{
				Il2CppClassPointerStore<PassLevel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<AccountPass>.NativeClassPtr, "PassLevel");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PassLevel>.NativeClassPtr);
				NativeFieldInfoPtr_level = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassLevel>.NativeClassPtr, "level");
				NativeFieldInfoPtr_xpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassLevel>.NativeClassPtr, "xpNeeded");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassLevel>.NativeClassPtr, 100670933);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe PassLevel()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PassLevel>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public PassLevel(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_passLevels;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Il2CppReferenceArray<PassLevel> passLevels
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passLevels);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<PassLevel>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passLevels)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		static AccountPass()
		{
			Il2CppClassPointerStore<AccountPass>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "AccountPass");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AccountPass>.NativeClassPtr);
			NativeFieldInfoPtr_passLevels = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AccountPass>.NativeClassPtr, "passLevels");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AccountPass>.NativeClassPtr, 100670932);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106448, XrefRangeEnd = 106451, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe AccountPass()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AccountPass>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public AccountPass(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class InviteCode : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Code;

		private static readonly System.IntPtr NativeFieldInfoPtr_UsesLeft;

		private static readonly System.IntPtr NativeFieldInfoPtr_UsesTotal;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string Code
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Code);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Code)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int UsesLeft
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UsesLeft);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UsesLeft)) = num;
			}
		}

		public unsafe int UsesTotal
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UsesTotal);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_UsesTotal)) = num;
			}
		}

		static InviteCode()
		{
			Il2CppClassPointerStore<InviteCode>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "InviteCode");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<InviteCode>.NativeClassPtr);
			NativeFieldInfoPtr_Code = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteCode>.NativeClassPtr, "Code");
			NativeFieldInfoPtr_UsesLeft = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteCode>.NativeClassPtr, "UsesLeft");
			NativeFieldInfoPtr_UsesTotal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InviteCode>.NativeClassPtr, "UsesTotal");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InviteCode>.NativeClassPtr, 100670934);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe InviteCode()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<InviteCode>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public InviteCode(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class DailyReward : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_timestamp;

		private static readonly System.IntPtr NativeFieldInfoPtr_progress;

		private static readonly System.IntPtr NativeFieldInfoPtr_max;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string timestamp
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timestamp);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timestamp)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int progress
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progress);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_progress)) = num;
			}
		}

		public unsafe int max
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_max);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_max)) = num;
			}
		}

		static DailyReward()
		{
			Il2CppClassPointerStore<DailyReward>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "DailyReward");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DailyReward>.NativeClassPtr);
			NativeFieldInfoPtr_timestamp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "timestamp");
			NativeFieldInfoPtr_progress = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "progress");
			NativeFieldInfoPtr_max = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, "max");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DailyReward>.NativeClassPtr, 100670935);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe DailyReward()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DailyReward>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public DailyReward(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class FriendList : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_friends;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe List<Friend> friends
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friends);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Friend>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friends)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		static FriendList()
		{
			Il2CppClassPointerStore<FriendList>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "FriendList");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FriendList>.NativeClassPtr);
			NativeFieldInfoPtr_friends = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendList>.NativeClassPtr, "friends");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FriendList>.NativeClassPtr, 100670936);
		}

		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 106456, RefRangeEnd = 106460, XrefRangeStart = 106451, XrefRangeEnd = 106456, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe FriendList()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FriendList>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public FriendList(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class Friend : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_avatarId;

		private static readonly System.IntPtr NativeFieldInfoPtr_accountId;

		private static readonly System.IntPtr NativeFieldInfoPtr_username;

		private static readonly System.IntPtr NativeFieldInfoPtr_discriminator;

		private static readonly System.IntPtr NativeFieldInfoPtr_isOnline;

		private static readonly System.IntPtr NativeFieldInfoPtr_isLobbyOpen;

		private static readonly System.IntPtr NativeFieldInfoPtr_isInQueue;

		private static readonly System.IntPtr NativeFieldInfoPtr_isInGame;

		private static readonly System.IntPtr NativeFieldInfoPtr_status;

		private static readonly System.IntPtr NativeFieldInfoPtr_timestampStart;

		private static readonly System.IntPtr NativeFieldInfoPtr_lobbyCount;

		private static readonly System.IntPtr NativeFieldInfoPtr_maxLobbyCount;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe int avatarId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_avatarId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_avatarId)) = num;
			}
		}

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

		public unsafe string username
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_username);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_username)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int discriminator
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_discriminator);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_discriminator)) = num;
			}
		}

		public unsafe bool isOnline
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isOnline);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isOnline)) = flag;
			}
		}

		public unsafe bool isLobbyOpen
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLobbyOpen);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLobbyOpen)) = flag;
			}
		}

		public unsafe bool isInQueue
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInQueue);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInQueue)) = flag;
			}
		}

		public unsafe bool isInGame
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInGame);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInGame)) = flag;
			}
		}

		public unsafe PlayerStatus status
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_status);
				return *(PlayerStatus*)num;
			}
			set
			{
				*(PlayerStatus*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_status)) = playerStatus;
			}
		}

		public unsafe int timestampStart
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timestampStart);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timestampStart)) = num;
			}
		}

		public unsafe int lobbyCount
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCount);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyCount)) = num;
			}
		}

		public unsafe int maxLobbyCount
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxLobbyCount);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxLobbyCount)) = num;
			}
		}

		static Friend()
		{
			Il2CppClassPointerStore<Friend>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "Friend");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Friend>.NativeClassPtr);
			NativeFieldInfoPtr_avatarId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "avatarId");
			NativeFieldInfoPtr_accountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "accountId");
			NativeFieldInfoPtr_username = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "username");
			NativeFieldInfoPtr_discriminator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "discriminator");
			NativeFieldInfoPtr_isOnline = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "isOnline");
			NativeFieldInfoPtr_isLobbyOpen = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "isLobbyOpen");
			NativeFieldInfoPtr_isInQueue = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "isInQueue");
			NativeFieldInfoPtr_isInGame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "isInGame");
			NativeFieldInfoPtr_status = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "status");
			NativeFieldInfoPtr_timestampStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "timestampStart");
			NativeFieldInfoPtr_lobbyCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "lobbyCount");
			NativeFieldInfoPtr_maxLobbyCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Friend>.NativeClassPtr, "maxLobbyCount");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Friend>.NativeClassPtr, 100670937);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Friend()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Friend>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Friend(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_lobbyId;

	private static readonly System.IntPtr NativeFieldInfoPtr_isInvited;

	private static readonly System.IntPtr NativeFieldInfoPtr_LocalAccountId;

	private static readonly System.IntPtr NativeFieldInfoPtr_isOpenLobby;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModes;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendsList;

	private static readonly System.IntPtr NativeFieldInfoPtr_friendRequests;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModeId;

	private static readonly System.IntPtr NativeFieldInfoPtr_isAutoFill;

	private static readonly System.IntPtr NativeFieldInfoPtr_regionId;

	private static readonly System.IntPtr NativeFieldInfoPtr_leaderAccountId;

	private static readonly System.IntPtr NativeFieldInfoPtr_player;

	private static readonly System.IntPtr NativeFieldInfoPtr_lobbyTeammates;

	private static readonly System.IntPtr NativeFieldInfoPtr_mmTeammates;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_queuePlayerCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_mmIsCounting;

	private static readonly System.IntPtr NativeFieldInfoPtr_mmStartingTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueIsCounting;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueStartingDelay;

	private static readonly System.IntPtr NativeFieldInfoPtr_queueStartingTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_isMatchmaking;

	private static readonly System.IntPtr NativeFieldInfoPtr_isInQueue;

	private static readonly System.IntPtr NativeFieldInfoPtr_isInGame;

	private static readonly System.IntPtr NativeFieldInfoPtr_isAdmin;

	private static readonly System.IntPtr NativeFieldInfoPtr_isGuest;

	private static readonly System.IntPtr NativeFieldInfoPtr_isCompleted;

	private static readonly System.IntPtr NativeFieldInfoPtr_gold;

	private static readonly System.IntPtr NativeFieldInfoPtr_fractals;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokens;

	private static readonly System.IntPtr NativeFieldInfoPtr_accountPass;

	private static readonly System.IntPtr NativeFieldInfoPtr_accountXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_inviteCode;

	private static readonly System.IntPtr NativeFieldInfoPtr_dailyReward;

	private static readonly System.IntPtr NativeFieldInfoPtr_ownedAssetIdData;

	private static readonly System.IntPtr NativeFieldInfoPtr_iapEnabled;

	private static readonly System.IntPtr NativeFieldInfoPtr_creatorCode;

	private static readonly System.IntPtr NativeFieldInfoPtr_creatorName;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string lobbyId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool isInvited
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInvited);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInvited)) = flag;
		}
	}

	public unsafe string LocalAccountId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LocalAccountId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LocalAccountId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool isOpenLobby
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isOpenLobby);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isOpenLobby)) = flag;
		}
	}

	public unsafe Il2CppReferenceArray<GameModeModel> gameModes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameModeModel>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe FriendList friendsList
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsList);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendList>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendsList)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendList));
		}
	}

	public unsafe FriendList friendRequests
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequests);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FriendList>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequests)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)friendList));
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

	public unsafe bool isAutoFill
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isAutoFill);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isAutoFill)) = flag;
		}
	}

	public unsafe string regionId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_regionId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_regionId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string leaderAccountId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaderAccountId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leaderAccountId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe PlayerModel player
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_player);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PlayerModel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_player)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerModel));
		}
	}

	public unsafe List<PlayerModel> lobbyTeammates
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyTeammates);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<PlayerModel>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lobbyTeammates)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<PlayerModel> mmTeammates
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mmTeammates);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<PlayerModel>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mmTeammates)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe int queueSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueSize)) = num;
		}
	}

	public unsafe int queuePlayerCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queuePlayerCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queuePlayerCount)) = num;
		}
	}

	public unsafe bool mmIsCounting
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mmIsCounting);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mmIsCounting)) = flag;
		}
	}

	public unsafe double mmStartingTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mmStartingTime);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mmStartingTime)) = num;
		}
	}

	public unsafe bool queueIsCounting
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueIsCounting);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueIsCounting)) = flag;
		}
	}

	public unsafe int queueStartingDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueStartingDelay);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueStartingDelay)) = num;
		}
	}

	public unsafe double queueStartingTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueStartingTime);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_queueStartingTime)) = num;
		}
	}

	public unsafe bool isMatchmaking
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isMatchmaking);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isMatchmaking)) = flag;
		}
	}

	public unsafe bool isInQueue
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInQueue);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInQueue)) = flag;
		}
	}

	public unsafe bool isInGame
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInGame);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isInGame)) = flag;
		}
	}

	public unsafe bool isAdmin
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isAdmin);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isAdmin)) = flag;
		}
	}

	public unsafe bool isGuest
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isGuest);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isGuest)) = flag;
		}
	}

	public unsafe bool isCompleted
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCompleted);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCompleted)) = flag;
		}
	}

	public unsafe int gold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gold);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gold)) = num;
		}
	}

	public unsafe int fractals
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractals);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fractals)) = num;
		}
	}

	public unsafe int charTokens
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokens);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokens)) = num;
		}
	}

	public unsafe AccountPass accountPass
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountPass);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AccountPass>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountPass)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)accountPass));
		}
	}

	public unsafe int accountXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountXp)) = num;
		}
	}

	public unsafe InviteCode inviteCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteCode);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<InviteCode>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inviteCode)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inviteCode));
		}
	}

	public unsafe DailyReward dailyReward
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyReward);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DailyReward>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dailyReward)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dailyReward));
		}
	}

	public unsafe HashSet<int> ownedAssetIdData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownedAssetIdData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HashSet<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownedAssetIdData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hashSet));
		}
	}

	public unsafe bool iapEnabled
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iapEnabled);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_iapEnabled)) = flag;
		}
	}

	public unsafe string creatorCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_creatorCode);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_creatorCode)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string creatorName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_creatorName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_creatorName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static LobbyDataModel()
	{
		Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "LobbyDataModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr);
		NativeFieldInfoPtr_lobbyId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "lobbyId");
		NativeFieldInfoPtr_isInvited = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isInvited");
		NativeFieldInfoPtr_LocalAccountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "LocalAccountId");
		NativeFieldInfoPtr_isOpenLobby = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isOpenLobby");
		NativeFieldInfoPtr_gameModes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "gameModes");
		NativeFieldInfoPtr_friendsList = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "friendsList");
		NativeFieldInfoPtr_friendRequests = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "friendRequests");
		NativeFieldInfoPtr_gameModeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "gameModeId");
		NativeFieldInfoPtr_isAutoFill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isAutoFill");
		NativeFieldInfoPtr_regionId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "regionId");
		NativeFieldInfoPtr_leaderAccountId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "leaderAccountId");
		NativeFieldInfoPtr_player = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "player");
		NativeFieldInfoPtr_lobbyTeammates = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "lobbyTeammates");
		NativeFieldInfoPtr_mmTeammates = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "mmTeammates");
		NativeFieldInfoPtr_queueSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "queueSize");
		NativeFieldInfoPtr_queuePlayerCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "queuePlayerCount");
		NativeFieldInfoPtr_mmIsCounting = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "mmIsCounting");
		NativeFieldInfoPtr_mmStartingTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "mmStartingTime");
		NativeFieldInfoPtr_queueIsCounting = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "queueIsCounting");
		NativeFieldInfoPtr_queueStartingDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "queueStartingDelay");
		NativeFieldInfoPtr_queueStartingTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "queueStartingTime");
		NativeFieldInfoPtr_isMatchmaking = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isMatchmaking");
		NativeFieldInfoPtr_isInQueue = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isInQueue");
		NativeFieldInfoPtr_isInGame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isInGame");
		NativeFieldInfoPtr_isAdmin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isAdmin");
		NativeFieldInfoPtr_isGuest = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isGuest");
		NativeFieldInfoPtr_isCompleted = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "isCompleted");
		NativeFieldInfoPtr_gold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "gold");
		NativeFieldInfoPtr_fractals = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "fractals");
		NativeFieldInfoPtr_charTokens = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "charTokens");
		NativeFieldInfoPtr_accountPass = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "accountPass");
		NativeFieldInfoPtr_accountXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "accountXp");
		NativeFieldInfoPtr_inviteCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "inviteCode");
		NativeFieldInfoPtr_dailyReward = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "dailyReward");
		NativeFieldInfoPtr_ownedAssetIdData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "ownedAssetIdData");
		NativeFieldInfoPtr_iapEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "iapEnabled");
		NativeFieldInfoPtr_creatorCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "creatorCode");
		NativeFieldInfoPtr_creatorName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, "creatorName");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr, 100670931);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106460, XrefRangeEnd = 106482, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LobbyDataModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LobbyDataModel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LobbyDataModel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

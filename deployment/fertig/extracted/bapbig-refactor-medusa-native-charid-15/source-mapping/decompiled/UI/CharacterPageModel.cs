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

[System.Serializable]
public class CharacterPageModel : Model
{
	[System.Serializable]
	public class CharListings : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_charListings;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Il2CppReferenceArray<CharListing> charListings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charListings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<CharListing>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charListings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		static CharListings()
		{
			Il2CppClassPointerStore<CharListings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "CharListings");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharListings>.NativeClassPtr);
			NativeFieldInfoPtr_charListings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharListings>.NativeClassPtr, "charListings");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharListings>.NativeClassPtr, 100670917);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CharListings()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharListings>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CharListings(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class CharListing : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_listingId;

		private static readonly System.IntPtr NativeFieldInfoPtr_charId;

		private static readonly System.IntPtr NativeFieldInfoPtr_levelRequirement;

		private static readonly System.IntPtr NativeFieldInfoPtr_costs;

		private static readonly System.IntPtr NativeFieldInfoPtr_purchases;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string listingId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listingId);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listingId)), IL2CPP.ManagedStringToIl2Cpp(text));
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

		public unsafe int levelRequirement
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelRequirement);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelRequirement)) = num;
			}
		}

		public unsafe Il2CppReferenceArray<AssetModel> costs
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_costs);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AssetModel>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_costs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe int purchases
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_purchases);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_purchases)) = num;
			}
		}

		static CharListing()
		{
			Il2CppClassPointerStore<CharListing>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "CharListing");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharListing>.NativeClassPtr);
			NativeFieldInfoPtr_listingId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharListing>.NativeClassPtr, "listingId");
			NativeFieldInfoPtr_charId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharListing>.NativeClassPtr, "charId");
			NativeFieldInfoPtr_levelRequirement = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharListing>.NativeClassPtr, "levelRequirement");
			NativeFieldInfoPtr_costs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharListing>.NativeClassPtr, "costs");
			NativeFieldInfoPtr_purchases = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharListing>.NativeClassPtr, "purchases");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharListing>.NativeClassPtr, 100670918);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CharListing()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharListing>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CharListing(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class CharTokenPass : Il2CppSystem.Object
	{
		[System.Serializable]
		public class PassLevel : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_level;

			private static readonly System.IntPtr NativeFieldInfoPtr_xpNeeded;

			private static readonly System.IntPtr NativeFieldInfoPtr_listings;

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

			public unsafe Il2CppReferenceArray<Listing> listings
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listings);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Listing>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
				}
			}

			static PassLevel()
			{
				Il2CppClassPointerStore<PassLevel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharTokenPass>.NativeClassPtr, "PassLevel");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PassLevel>.NativeClassPtr);
				NativeFieldInfoPtr_level = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassLevel>.NativeClassPtr, "level");
				NativeFieldInfoPtr_xpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassLevel>.NativeClassPtr, "xpNeeded");
				NativeFieldInfoPtr_listings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PassLevel>.NativeClassPtr, "listings");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PassLevel>.NativeClassPtr, 100670920);
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

		[System.Serializable]
		public class Listing : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_listingId;

			private static readonly System.IntPtr NativeFieldInfoPtr_globalStock;

			private static readonly System.IntPtr NativeFieldInfoPtr_accountStock;

			private static readonly System.IntPtr NativeFieldInfoPtr_costs;

			private static readonly System.IntPtr NativeFieldInfoPtr_rewards;

			private static readonly System.IntPtr NativeFieldInfoPtr_expiresAt;

			private static readonly System.IntPtr NativeFieldInfoPtr_purchases;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe string listingId
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listingId);
					return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listingId)), IL2CPP.ManagedStringToIl2Cpp(text));
				}
			}

			public unsafe int globalStock
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_globalStock);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_globalStock)) = num;
				}
			}

			public unsafe int accountStock
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountStock);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_accountStock)) = num;
				}
			}

			public unsafe Il2CppReferenceArray<AssetModel> costs
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_costs);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AssetModel>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_costs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
				}
			}

			public unsafe Il2CppReferenceArray<AssetModel> rewards
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rewards);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AssetModel>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rewards)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
				}
			}

			public unsafe int expiresAt
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expiresAt);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expiresAt)) = num;
				}
			}

			public unsafe int purchases
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_purchases);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_purchases)) = num;
				}
			}

			static Listing()
			{
				Il2CppClassPointerStore<Listing>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharTokenPass>.NativeClassPtr, "Listing");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Listing>.NativeClassPtr);
				NativeFieldInfoPtr_listingId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "listingId");
				NativeFieldInfoPtr_globalStock = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "globalStock");
				NativeFieldInfoPtr_accountStock = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "accountStock");
				NativeFieldInfoPtr_costs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "costs");
				NativeFieldInfoPtr_rewards = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "rewards");
				NativeFieldInfoPtr_expiresAt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "expiresAt");
				NativeFieldInfoPtr_purchases = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "purchases");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Listing>.NativeClassPtr, 100670921);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe Listing()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Listing>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public Listing(System.IntPtr pointer)
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

		static CharTokenPass()
		{
			Il2CppClassPointerStore<CharTokenPass>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "CharTokenPass");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharTokenPass>.NativeClassPtr);
			NativeFieldInfoPtr_passLevels = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharTokenPass>.NativeClassPtr, "passLevels");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharTokenPass>.NativeClassPtr, 100670919);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106425, XrefRangeEnd = 106428, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CharTokenPass()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharTokenPass>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CharTokenPass(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_charListings;

	private static readonly System.IntPtr NativeFieldInfoPtr_availableCharacters;

	private static readonly System.IntPtr NativeFieldInfoPtr_charIdsInRotation;

	private static readonly System.IntPtr NativeFieldInfoPtr_unlockedCharacters;

	private static readonly System.IntPtr NativeFieldInfoPtr_tokenPass;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenCurrentLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenCurrentXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenXpNeeded;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevCharTokenCurrentLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevCharTokenCurrentXp;

	private static readonly System.IntPtr NativeFieldInfoPtr_charTokenMaxLevel;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe CharListings charListings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charListings);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharListings>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charListings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charListings));
		}
	}

	public unsafe Il2CppStructArray<int> availableCharacters
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_availableCharacters);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_availableCharacters)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<int> charIdsInRotation
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charIdsInRotation);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charIdsInRotation)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe HashSet<int> unlockedCharacters
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unlockedCharacters);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<HashSet<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_unlockedCharacters)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hashSet));
		}
	}

	public unsafe CharTokenPass tokenPass
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tokenPass);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharTokenPass>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tokenPass)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charTokenPass));
		}
	}

	public unsafe int charTokenCurrentLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrentLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrentLevel)) = num;
		}
	}

	public unsafe int charTokenXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenXp)) = num;
		}
	}

	public unsafe int charTokenCurrentXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrentXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenCurrentXp)) = num;
		}
	}

	public unsafe int charTokenXpNeeded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenXpNeeded);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenXpNeeded)) = num;
		}
	}

	public unsafe int prevCharTokenCurrentLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCharTokenCurrentLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCharTokenCurrentLevel)) = num;
		}
	}

	public unsafe int prevCharTokenCurrentXp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCharTokenCurrentXp);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevCharTokenCurrentXp)) = num;
		}
	}

	public unsafe int charTokenMaxLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenMaxLevel);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charTokenMaxLevel)) = num;
		}
	}

	static CharacterPageModel()
	{
		Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "CharacterPageModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr);
		NativeFieldInfoPtr_charListings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "charListings");
		NativeFieldInfoPtr_availableCharacters = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "availableCharacters");
		NativeFieldInfoPtr_charIdsInRotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "charIdsInRotation");
		NativeFieldInfoPtr_unlockedCharacters = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "unlockedCharacters");
		NativeFieldInfoPtr_tokenPass = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "tokenPass");
		NativeFieldInfoPtr_charTokenCurrentLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "charTokenCurrentLevel");
		NativeFieldInfoPtr_charTokenXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "charTokenXp");
		NativeFieldInfoPtr_charTokenCurrentXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "charTokenCurrentXp");
		NativeFieldInfoPtr_charTokenXpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "charTokenXpNeeded");
		NativeFieldInfoPtr_prevCharTokenCurrentLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "prevCharTokenCurrentLevel");
		NativeFieldInfoPtr_prevCharTokenCurrentXp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "prevCharTokenCurrentXp");
		NativeFieldInfoPtr_charTokenMaxLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, "charTokenMaxLevel");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr, 100670916);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 106428, XrefRangeEnd = 106436, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CharacterPageModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharacterPageModel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CharacterPageModel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

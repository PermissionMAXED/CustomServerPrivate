using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Entities;
using Il2CppBAPBAP.Items;
using Il2CppBAPBAP.Localisation;
using Il2CppBAPBAP.UI;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class ItemManager : MonoBehaviour
{
	[System.Serializable]
	public class ItemSlotConfiguration : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_nameTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_icon;

		private static readonly System.IntPtr NativeFieldInfoPtr_localizedName;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string nameTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe Sprite icon
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_icon);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_icon)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe string localizedName
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localizedName);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localizedName)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static ItemSlotConfiguration()
		{
			Il2CppClassPointerStore<ItemSlotConfiguration>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "ItemSlotConfiguration");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ItemSlotConfiguration>.NativeClassPtr);
			NativeFieldInfoPtr_nameTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemSlotConfiguration>.NativeClassPtr, "nameTranslationKey");
			NativeFieldInfoPtr_icon = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemSlotConfiguration>.NativeClassPtr, "icon");
			NativeFieldInfoPtr_localizedName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemSlotConfiguration>.NativeClassPtr, "localizedName");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemSlotConfiguration>.NativeClassPtr, 100684344);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ItemSlotConfiguration()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ItemSlotConfiguration>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ItemSlotConfiguration(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ItemTierConfiguration : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_nameTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_itemTheme;

		private static readonly System.IntPtr NativeFieldInfoPtr_localizedName;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string nameTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nameTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe ItemTheme itemTheme
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTheme);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ItemTheme>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTheme)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)itemTheme));
			}
		}

		public unsafe string localizedName
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localizedName);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localizedName)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static ItemTierConfiguration()
		{
			Il2CppClassPointerStore<ItemTierConfiguration>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "ItemTierConfiguration");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ItemTierConfiguration>.NativeClassPtr);
			NativeFieldInfoPtr_nameTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemTierConfiguration>.NativeClassPtr, "nameTranslationKey");
			NativeFieldInfoPtr_itemTheme = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemTierConfiguration>.NativeClassPtr, "itemTheme");
			NativeFieldInfoPtr_localizedName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemTierConfiguration>.NativeClassPtr, "localizedName");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemTierConfiguration>.NativeClassPtr, 100684345);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ItemTierConfiguration()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ItemTierConfiguration>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ItemTierConfiguration(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct ItemEntry
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_itemId;

		private static readonly System.IntPtr NativeFieldInfoPtr_amount;

		[FieldOffset(0)]
		public int itemId;

		[FieldOffset(4)]
		public int amount;

		static ItemEntry()
		{
			Il2CppClassPointerStore<ItemEntry>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "ItemEntry");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ItemEntry>.NativeClassPtr);
			NativeFieldInfoPtr_itemId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemEntry>.NativeClassPtr, "itemId");
			NativeFieldInfoPtr_amount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemEntry>.NativeClassPtr, "amount");
		}

		public unsafe Il2CppSystem.Object BoxIl2CppObject()
		{
			return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<ItemEntry>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
		}
	}

	[ObfuscatedName("BAPBAP.Local.ItemManager+<>c__DisplayClass53_0")]
	public sealed class __c__DisplayClass53_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_type;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Awake_b__0_Internal_Boolean_GearData_0;

		public unsafe GearType type
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_type);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GearType>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_type)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gearType));
			}
		}

		static __c__DisplayClass53_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass53_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "<>c__DisplayClass53_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass53_0>.NativeClassPtr);
			NativeFieldInfoPtr_type = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass53_0>.NativeClassPtr, "type");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass53_0>.NativeClassPtr, 100684346);
			NativeMethodInfoPtr__Awake_b__0_Internal_Boolean_GearData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass53_0>.NativeClassPtr, 100684347);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass53_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass53_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226389, XrefRangeEnd = 226392, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _Awake_b__0(GearData x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)x));
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Awake_b__0_Internal_Boolean_GearData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass53_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Local.ItemManager+<>c__DisplayClass53_1")]
	public sealed class __c__DisplayClass53_1 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_type;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Awake_b__1_Internal_Boolean_GearData_0;

		public unsafe GearType type
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_type);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GearType>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_type)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gearType));
			}
		}

		static __c__DisplayClass53_1()
		{
			Il2CppClassPointerStore<__c__DisplayClass53_1>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "<>c__DisplayClass53_1");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass53_1>.NativeClassPtr);
			NativeFieldInfoPtr_type = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass53_1>.NativeClassPtr, "type");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass53_1>.NativeClassPtr, 100684348);
			NativeMethodInfoPtr__Awake_b__1_Internal_Boolean_GearData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass53_1>.NativeClassPtr, 100684349);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass53_1()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass53_1>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226392, XrefRangeEnd = 226395, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _Awake_b__1(GearData x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)x));
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Awake_b__1_Internal_Boolean_GearData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass53_1(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Local.ItemManager+<>c__DisplayClass53_2")]
	public sealed class __c__DisplayClass53_2 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_type;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__Awake_b__2_Internal_Boolean_GearData_0;

		public unsafe GearType type
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_type);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GearType>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_type)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gearType));
			}
		}

		static __c__DisplayClass53_2()
		{
			Il2CppClassPointerStore<__c__DisplayClass53_2>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "<>c__DisplayClass53_2");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass53_2>.NativeClassPtr);
			NativeFieldInfoPtr_type = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass53_2>.NativeClassPtr, "type");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass53_2>.NativeClassPtr, 100684350);
			NativeMethodInfoPtr__Awake_b__2_Internal_Boolean_GearData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass53_2>.NativeClassPtr, 100684351);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass53_2()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass53_2>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226395, XrefRangeEnd = 226398, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _Awake_b__2(GearData x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)x));
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__Awake_b__2_Internal_Boolean_GearData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass53_2(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_uiManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_gearItems;

	private static readonly System.IntPtr NativeFieldInfoPtr_uniqueGearItems;

	private static readonly System.IntPtr NativeFieldInfoPtr_pinGearItems;

	private static readonly System.IntPtr NativeFieldInfoPtr_consumables;

	private static readonly System.IntPtr NativeFieldInfoPtr_currencies;

	private static readonly System.IntPtr NativeFieldInfoPtr_lootableAbilities;

	private static readonly System.IntPtr NativeFieldInfoPtr_vaultedGearTypes;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxHealthPotionCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_numGearItems;

	private static readonly System.IntPtr NativeFieldInfoPtr_numConsumableItems;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxGold;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxGoldDropAmount;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemTierConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemSlotConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemObjPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultItemObjMats;

	private static readonly System.IntPtr NativeFieldInfoPtr_C_HealthPotion_Item;

	private static readonly System.IntPtr NativeFieldInfoPtr_C_Gold_Item;

	private static readonly System.IntPtr NativeFieldInfoPtr_C_Page_Item;

	private static readonly System.IntPtr NativeFieldInfoPtr_gearTypeTranslationKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemTypeTranslationKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_consumableTypeTranslationKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_lootableAbilityTypeTranslationKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_currencyTypeTranslationKey;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemPickupSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemDropSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_consumablePickupSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_consumableDropSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_currencyPickupSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_currencyDropSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_lootAbilityPickupSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_lootAbilityDropSfxData;

	private static readonly System.IntPtr NativeFieldInfoPtr_potionItemId;

	private static readonly System.IntPtr NativeFieldInfoPtr_goldItemId;

	private static readonly System.IntPtr NativeFieldInfoPtr_pagesItemId;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemsById;

	private static readonly System.IntPtr NativeFieldInfoPtr_gearDataByTypeId;

	private static readonly System.IntPtr NativeFieldInfoPtr_enabledGearTypes;

	private static readonly System.IntPtr NativeFieldInfoPtr_enabledUniqueTypes;

	private static readonly System.IntPtr NativeFieldInfoPtr_enabledPinTypes;

	private static readonly System.IntPtr NativeFieldInfoPtr_numItemTiers;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemTypeName;

	private static readonly System.IntPtr NativeFieldInfoPtr_gearTypeName;

	private static readonly System.IntPtr NativeFieldInfoPtr_consumableTypeName;

	private static readonly System.IntPtr NativeFieldInfoPtr_lootableAbilityTypeName;

	private static readonly System.IntPtr NativeFieldInfoPtr_currencyTypeName;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemNameByItemId;

	private static readonly System.IntPtr NativeFieldInfoPtr_itemDescriptionByItemId;

	private static readonly System.IntPtr NativeFieldInfoPtr_consumableBehaviourInstances;

	private static readonly System.IntPtr NativeFieldInfoPtr_lootableAbilityBehaviours;

	private static readonly System.IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Localise_Public_Void_Translator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentEnabledItems_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLootableAbilityBehaviourId_Public_Int32_PassiveSO_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLootableAbilityBehaviour_Public_AbilityBehaviourSO_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DoLootableAbility_Public_Void_LootableAbility_EntityManager_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetConsumableAbilityBehaviour_Public_AbilityBehaviourSO_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnMultipleItems_Public_Void_Il2CppStructArray_1_Int32_Vector3_Single_CharItems_Action_1_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnMultipleItems_Public_Void_Il2CppStructArray_1_ItemEntry_Vector3_Vector3_Single_CharItems_Action_1_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnItem_Public_GameObject_Int32_Vector3_Vector3_Single_CharItems_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnItem_Public_GameObject_Int32_Int32_Vector3_Vector3_Single_CharItems_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItem_Public_Item_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetGear_Public_Gear_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetConsumable_Public_Item_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrency_Public_Item_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRandomGearType_Public_GearType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRandomUniqueType_Public_GearType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRandomPinType_Public_GearType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRandomGearByTier_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetGearItemIdByTypeAndTier_Public_Int32_GearType_ItemTiers_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetGearItemIdByTypeAndTier_Public_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemId_Public_Int32_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetConsumableItemId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLootableAbilityItemId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetConsumableIdByItemId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetConsumableMaxCount_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetConsumableIsDroppable_Public_Boolean_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLootableAbilityIdByItemId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrencyItemId_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsItemMaxTier_Public_Boolean_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsItemMaxTier_Public_Boolean_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetNextItemTier_Public_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetNextItemTier_Public_Int32_Gear_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemPowerLevelNorm_Public_Single_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemPowerLevelNorm_Public_Single_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemThemeByTier_Public_ItemTheme_ItemTiers_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildStatString_Public_String_ItemStat_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetStatValue_Public_String_ItemStat_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemTypeName_Public_String_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemName_Public_String_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemName_Public_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemDescription_Public_String_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemDescription_Public_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetItemColor_Public_Color_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTierColor_Public_Color_ItemTiers_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTierName_Public_String_ItemTiers_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetGearSlotIcon_Public_Sprite_Gear_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetGearSlotName_Public_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTierAndSlotTypeName_Public_String_Gear_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPickupSfx_Public_AudioClipData_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDropSfx_Public_AudioClipData_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPickupSfx_Public_AudioClipData_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDropSfx_Public_AudioClipData_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe UIManager uiManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIManager));
		}
	}

	public unsafe Il2CppReferenceArray<Gear> gearItems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearItems);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Gear>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearItems)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Gear> uniqueGearItems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uniqueGearItems);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Gear>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uniqueGearItems)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Gear> pinGearItems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pinGearItems);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Gear>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pinGearItems)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Consumable> consumables
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumables);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Consumable>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumables)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Currency> currencies
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencies);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Currency>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencies)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<LootableAbility> lootableAbilities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilities);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<LootableAbility>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilities)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe List<GearType> vaultedGearTypes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vaultedGearTypes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<GearType>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vaultedGearTypes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe int maxHealthPotionCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxHealthPotionCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxHealthPotionCount)) = num;
		}
	}

	public unsafe int numGearItems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numGearItems);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numGearItems)) = num;
		}
	}

	public unsafe int numConsumableItems
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numConsumableItems);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numConsumableItems)) = num;
		}
	}

	public unsafe int maxGold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxGold);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxGold)) = num;
		}
	}

	public unsafe int maxGoldDropAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxGoldDropAmount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxGoldDropAmount)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<ItemTierConfiguration> itemTierConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTierConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ItemTierConfiguration>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTierConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ItemSlotConfiguration> itemSlotConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemSlotConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ItemSlotConfiguration>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemSlotConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe GameObject itemObjPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemObjPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemObjPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Il2CppReferenceArray<Material> defaultItemObjMats
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultItemObjMats);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Material>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultItemObjMats)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Item C_HealthPotion_Item
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_C_HealthPotion_Item);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Item>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_C_HealthPotion_Item)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item));
		}
	}

	public unsafe Item C_Gold_Item
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_C_Gold_Item);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Item>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_C_Gold_Item)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item));
		}
	}

	public unsafe Item C_Page_Item
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_C_Page_Item);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Item>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_C_Page_Item)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item));
		}
	}

	public unsafe string gearTypeTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearTypeTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearTypeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string itemTypeTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTypeTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTypeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string consumableTypeTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableTypeTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableTypeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string lootableAbilityTypeTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilityTypeTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilityTypeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string currencyTypeTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyTypeTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyTypeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe AudioClipData itemPickupSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemPickupSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemPickupSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData itemDropSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemDropSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemDropSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData consumablePickupSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumablePickupSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumablePickupSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData consumableDropSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableDropSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableDropSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData currencyPickupSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyPickupSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyPickupSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData currencyDropSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyDropSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyDropSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData lootAbilityPickupSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootAbilityPickupSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootAbilityPickupSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData lootAbilityDropSfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootAbilityDropSfxData);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootAbilityDropSfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe int potionItemId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_potionItemId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_potionItemId)) = num;
		}
	}

	public unsafe int goldItemId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldItemId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_goldItemId)) = num;
		}
	}

	public unsafe int pagesItemId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pagesItemId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pagesItemId)) = num;
		}
	}

	public unsafe Il2CppReferenceArray<Item> itemsById
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemsById);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Item>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemsById)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<GearData> gearDataByTypeId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearDataByTypeId);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GearData>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearDataByTypeId)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<GearType> enabledGearTypes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledGearTypes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GearType>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledGearTypes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<GearType> enabledUniqueTypes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledUniqueTypes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GearType>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledUniqueTypes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<GearType> enabledPinTypes
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledPinTypes);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GearType>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enabledPinTypes)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe int numItemTiers
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numItemTiers);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numItemTiers)) = num;
		}
	}

	public unsafe string itemTypeName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTypeName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemTypeName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string gearTypeName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearTypeName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gearTypeName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string consumableTypeName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableTypeName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableTypeName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string lootableAbilityTypeName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilityTypeName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilityTypeName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string currencyTypeName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyTypeName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currencyTypeName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe Il2CppStringArray itemNameByItemId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemNameByItemId);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemNameByItemId)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStringArray itemDescriptionByItemId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemDescriptionByItemId);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemDescriptionByItemId)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<AbilityBehaviourSO> consumableBehaviourInstances
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableBehaviourInstances);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AbilityBehaviourSO>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableBehaviourInstances)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<AbilityBehaviourSO> lootableAbilityBehaviours
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilityBehaviours);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AbilityBehaviourSO>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lootableAbilityBehaviours)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static ItemManager()
	{
		Il2CppClassPointerStore<ItemManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "ItemManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ItemManager>.NativeClassPtr);
		NativeFieldInfoPtr_uiManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "uiManager");
		NativeFieldInfoPtr_gearItems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "gearItems");
		NativeFieldInfoPtr_uniqueGearItems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "uniqueGearItems");
		NativeFieldInfoPtr_pinGearItems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "pinGearItems");
		NativeFieldInfoPtr_consumables = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "consumables");
		NativeFieldInfoPtr_currencies = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "currencies");
		NativeFieldInfoPtr_lootableAbilities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "lootableAbilities");
		NativeFieldInfoPtr_vaultedGearTypes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "vaultedGearTypes");
		NativeFieldInfoPtr_maxHealthPotionCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "maxHealthPotionCount");
		NativeFieldInfoPtr_numGearItems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "numGearItems");
		NativeFieldInfoPtr_numConsumableItems = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "numConsumableItems");
		NativeFieldInfoPtr_maxGold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "maxGold");
		NativeFieldInfoPtr_maxGoldDropAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "maxGoldDropAmount");
		NativeFieldInfoPtr_itemTierConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemTierConfig");
		NativeFieldInfoPtr_itemSlotConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemSlotConfig");
		NativeFieldInfoPtr_itemObjPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemObjPrefab");
		NativeFieldInfoPtr_defaultItemObjMats = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "defaultItemObjMats");
		NativeFieldInfoPtr_C_HealthPotion_Item = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "C_HealthPotion_Item");
		NativeFieldInfoPtr_C_Gold_Item = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "C_Gold_Item");
		NativeFieldInfoPtr_C_Page_Item = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "C_Page_Item");
		NativeFieldInfoPtr_gearTypeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "gearTypeTranslationKey");
		NativeFieldInfoPtr_itemTypeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemTypeTranslationKey");
		NativeFieldInfoPtr_consumableTypeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "consumableTypeTranslationKey");
		NativeFieldInfoPtr_lootableAbilityTypeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "lootableAbilityTypeTranslationKey");
		NativeFieldInfoPtr_currencyTypeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "currencyTypeTranslationKey");
		NativeFieldInfoPtr_itemPickupSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemPickupSfxData");
		NativeFieldInfoPtr_itemDropSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemDropSfxData");
		NativeFieldInfoPtr_consumablePickupSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "consumablePickupSfxData");
		NativeFieldInfoPtr_consumableDropSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "consumableDropSfxData");
		NativeFieldInfoPtr_currencyPickupSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "currencyPickupSfxData");
		NativeFieldInfoPtr_currencyDropSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "currencyDropSfxData");
		NativeFieldInfoPtr_lootAbilityPickupSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "lootAbilityPickupSfxData");
		NativeFieldInfoPtr_lootAbilityDropSfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "lootAbilityDropSfxData");
		NativeFieldInfoPtr_potionItemId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "potionItemId");
		NativeFieldInfoPtr_goldItemId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "goldItemId");
		NativeFieldInfoPtr_pagesItemId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "pagesItemId");
		NativeFieldInfoPtr_itemsById = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemsById");
		NativeFieldInfoPtr_gearDataByTypeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "gearDataByTypeId");
		NativeFieldInfoPtr_enabledGearTypes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "enabledGearTypes");
		NativeFieldInfoPtr_enabledUniqueTypes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "enabledUniqueTypes");
		NativeFieldInfoPtr_enabledPinTypes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "enabledPinTypes");
		NativeFieldInfoPtr_numItemTiers = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "numItemTiers");
		NativeFieldInfoPtr_itemTypeName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemTypeName");
		NativeFieldInfoPtr_gearTypeName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "gearTypeName");
		NativeFieldInfoPtr_consumableTypeName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "consumableTypeName");
		NativeFieldInfoPtr_lootableAbilityTypeName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "lootableAbilityTypeName");
		NativeFieldInfoPtr_currencyTypeName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "currencyTypeName");
		NativeFieldInfoPtr_itemNameByItemId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemNameByItemId");
		NativeFieldInfoPtr_itemDescriptionByItemId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "itemDescriptionByItemId");
		NativeFieldInfoPtr_consumableBehaviourInstances = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "consumableBehaviourInstances");
		NativeFieldInfoPtr_lootableAbilityBehaviours = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, "lootableAbilityBehaviours");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684290);
		NativeMethodInfoPtr_Localise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684291);
		NativeMethodInfoPtr_GetCurrentEnabledItems_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684292);
		NativeMethodInfoPtr_GetLootableAbilityBehaviourId_Public_Int32_PassiveSO_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684293);
		NativeMethodInfoPtr_GetLootableAbilityBehaviour_Public_AbilityBehaviourSO_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684294);
		NativeMethodInfoPtr_DoLootableAbility_Public_Void_LootableAbility_EntityManager_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684295);
		NativeMethodInfoPtr_GetConsumableAbilityBehaviour_Public_AbilityBehaviourSO_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684296);
		NativeMethodInfoPtr_SpawnMultipleItems_Public_Void_Il2CppStructArray_1_Int32_Vector3_Single_CharItems_Action_1_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684297);
		NativeMethodInfoPtr_SpawnMultipleItems_Public_Void_Il2CppStructArray_1_ItemEntry_Vector3_Vector3_Single_CharItems_Action_1_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684298);
		NativeMethodInfoPtr_SpawnItem_Public_GameObject_Int32_Vector3_Vector3_Single_CharItems_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684299);
		NativeMethodInfoPtr_SpawnItem_Public_GameObject_Int32_Int32_Vector3_Vector3_Single_CharItems_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684300);
		NativeMethodInfoPtr_GetItem_Public_Item_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684301);
		NativeMethodInfoPtr_GetGear_Public_Gear_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684302);
		NativeMethodInfoPtr_GetConsumable_Public_Item_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684303);
		NativeMethodInfoPtr_GetCurrency_Public_Item_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684304);
		NativeMethodInfoPtr_GetRandomGearType_Public_GearType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684305);
		NativeMethodInfoPtr_GetRandomUniqueType_Public_GearType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684306);
		NativeMethodInfoPtr_GetRandomPinType_Public_GearType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684307);
		NativeMethodInfoPtr_GetRandomGearByTier_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684308);
		NativeMethodInfoPtr_GetGearItemIdByTypeAndTier_Public_Int32_GearType_ItemTiers_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684309);
		NativeMethodInfoPtr_GetGearItemIdByTypeAndTier_Public_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684310);
		NativeMethodInfoPtr_GetItemId_Public_Int32_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684311);
		NativeMethodInfoPtr_GetConsumableItemId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684312);
		NativeMethodInfoPtr_GetLootableAbilityItemId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684313);
		NativeMethodInfoPtr_GetConsumableIdByItemId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684314);
		NativeMethodInfoPtr_GetConsumableMaxCount_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684315);
		NativeMethodInfoPtr_GetConsumableIsDroppable_Public_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684316);
		NativeMethodInfoPtr_GetLootableAbilityIdByItemId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684317);
		NativeMethodInfoPtr_GetCurrencyItemId_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684318);
		NativeMethodInfoPtr_IsItemMaxTier_Public_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684319);
		NativeMethodInfoPtr_IsItemMaxTier_Public_Boolean_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684320);
		NativeMethodInfoPtr_GetNextItemTier_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684321);
		NativeMethodInfoPtr_GetNextItemTier_Public_Int32_Gear_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684322);
		NativeMethodInfoPtr_GetItemPowerLevelNorm_Public_Single_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684323);
		NativeMethodInfoPtr_GetItemPowerLevelNorm_Public_Single_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684324);
		NativeMethodInfoPtr_GetItemThemeByTier_Public_ItemTheme_ItemTiers_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684325);
		NativeMethodInfoPtr_BuildStatString_Public_String_ItemStat_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684326);
		NativeMethodInfoPtr_GetStatValue_Public_String_ItemStat_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684327);
		NativeMethodInfoPtr_GetItemTypeName_Public_String_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684328);
		NativeMethodInfoPtr_GetItemName_Public_String_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684329);
		NativeMethodInfoPtr_GetItemName_Public_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684330);
		NativeMethodInfoPtr_GetItemDescription_Public_String_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684331);
		NativeMethodInfoPtr_GetItemDescription_Public_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684332);
		NativeMethodInfoPtr_GetItemColor_Public_Color_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684333);
		NativeMethodInfoPtr_GetTierColor_Public_Color_ItemTiers_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684334);
		NativeMethodInfoPtr_GetTierName_Public_String_ItemTiers_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684335);
		NativeMethodInfoPtr_GetGearSlotIcon_Public_Sprite_Gear_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684336);
		NativeMethodInfoPtr_GetGearSlotName_Public_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684337);
		NativeMethodInfoPtr_GetTierAndSlotTypeName_Public_String_Gear_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684338);
		NativeMethodInfoPtr_GetPickupSfx_Public_AudioClipData_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684339);
		NativeMethodInfoPtr_GetDropSfx_Public_AudioClipData_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684340);
		NativeMethodInfoPtr_GetPickupSfx_Public_AudioClipData_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684341);
		NativeMethodInfoPtr_GetDropSfx_Public_AudioClipData_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684342);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ItemManager>.NativeClassPtr, 100684343);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226398, XrefRangeEnd = 226520, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226538, RefRangeEnd = 226539, XrefRangeStart = 226520, XrefRangeEnd = 226538, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Localise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226562, RefRangeEnd = 226563, XrefRangeStart = 226539, XrefRangeEnd = 226562, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void GetCurrentEnabledItems()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentEnabledItems_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226563, XrefRangeEnd = 226566, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetLootableAbilityBehaviourId(PassiveSO lootableAbility)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lootableAbility);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLootableAbilityBehaviourId_Public_Int32_PassiveSO_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226569, RefRangeEnd = 226570, XrefRangeStart = 226566, XrefRangeEnd = 226569, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AbilityBehaviourSO GetLootableAbilityBehaviour(int lootableAbilityId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&lootableAbilityId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLootableAbilityBehaviour_Public_AbilityBehaviourSO_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AbilityBehaviourSO>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226570, XrefRangeEnd = 226586, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DoLootableAbility(LootableAbility consumable, EntityManager entityManager, Vector3 landingPoint)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)consumable);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &landingPoint;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DoLootableAbility_Public_Void_LootableAbility_EntityManager_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226589, RefRangeEnd = 226590, XrefRangeStart = 226586, XrefRangeEnd = 226589, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AbilityBehaviourSO GetConsumableAbilityBehaviour(int consumableId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&consumableId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetConsumableAbilityBehaviour_Public_AbilityBehaviourSO_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AbilityBehaviourSO>(intPtr) : null;
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 226594, RefRangeEnd = 226600, XrefRangeStart = 226590, XrefRangeEnd = 226594, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnMultipleItems(Il2CppStructArray<int> itemIds, Vector3 spawnPos, float spawnRadius = 1f, CharItems prevOwner = null, Il2CppSystem.Action<GameObject> onInstanceSpawned = null)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)itemIds);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnPos;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnRadius;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prevOwner);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)onInstanceSpawned);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnMultipleItems_Public_Void_Il2CppStructArray_1_Int32_Vector3_Single_CharItems_Action_1_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226607, RefRangeEnd = 226609, XrefRangeStart = 226600, XrefRangeEnd = 226607, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnMultipleItems(Il2CppStructArray<ItemEntry> items, Vector3 spawnPos, Vector3 initialDir = default(Vector3), float spawnRadius = 1f, CharItems prevOwner = null, Il2CppSystem.Action<GameObject> onInstanceSpawned = null)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[6];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)items);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnPos;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &initialDir;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnRadius;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prevOwner);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)onInstanceSpawned);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnMultipleItems_Public_Void_Il2CppStructArray_1_ItemEntry_Vector3_Vector3_Single_CharItems_Action_1_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226610, RefRangeEnd = 226613, XrefRangeStart = 226609, XrefRangeEnd = 226610, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GameObject SpawnItem(int itemId, Vector3 spawnPos, Vector3 dir = default(Vector3), float spawnRadius = 1f, CharItems prevOwner = null)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = (nint)(&itemId);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnPos;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &dir;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnRadius;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prevOwner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnItem_Public_GameObject_Int32_Vector3_Vector3_Single_CharItems_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 226637, RefRangeEnd = 226646, XrefRangeStart = 226613, XrefRangeEnd = 226637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GameObject SpawnItem(int itemId, int amount, Vector3 spawnPos, Vector3 dir = default(Vector3), float spawnRadius = 1f, CharItems prevOwner = null)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[6];
		*ptr = (nint)(&itemId);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &amount;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnPos;
		*(Vector3**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &dir;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnRadius;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prevOwner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnItem_Public_GameObject_Int32_Int32_Vector3_Vector3_Single_CharItems_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(61)]
	[CachedScanResults(RefRangeStart = 226646, RefRangeEnd = 226707, XrefRangeStart = 226646, XrefRangeEnd = 226646, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Item GetItem(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItem_Public_Item_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Item>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe Gear GetGear(int gearId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&gearId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetGear_Public_Gear_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Gear>(intPtr) : null;
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 226362, RefRangeEnd = 226366, XrefRangeStart = 226362, XrefRangeEnd = 226366, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Item GetConsumable(int consumableId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&consumableId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetConsumable_Public_Item_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Item>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe Item GetCurrency(int currencyId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&currencyId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrency_Public_Item_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Item>(intPtr) : null;
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 226710, RefRangeEnd = 226718, XrefRangeStart = 226707, XrefRangeEnd = 226710, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GearType GetRandomGearType()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomGearType_Public_GearType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GearType>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226721, RefRangeEnd = 226722, XrefRangeStart = 226718, XrefRangeEnd = 226721, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GearType GetRandomUniqueType()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomUniqueType_Public_GearType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GearType>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226725, RefRangeEnd = 226726, XrefRangeStart = 226722, XrefRangeEnd = 226725, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe GearType GetRandomPinType()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomPinType_Public_GearType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GearType>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226736, RefRangeEnd = 226737, XrefRangeStart = 226726, XrefRangeEnd = 226736, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetRandomGearByTier(int tier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&tier);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomGearByTier_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226741, RefRangeEnd = 226744, XrefRangeStart = 226737, XrefRangeEnd = 226741, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetGearItemIdByTypeAndTier(GearType type, ItemTiers tier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)type);
		*(ItemTiers**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tier;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetGearItemIdByTypeAndTier_Public_Int32_GearType_ItemTiers_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(11)]
	[CachedScanResults(RefRangeStart = 226746, RefRangeEnd = 226757, XrefRangeStart = 226744, XrefRangeEnd = 226746, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetGearItemIdByTypeAndTier(int typeId, int tierId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&typeId);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tierId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetGearItemIdByTypeAndTier_Public_Int32_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(26)]
	[CachedScanResults(RefRangeStart = 226761, RefRangeEnd = 226787, XrefRangeStart = 226757, XrefRangeEnd = 226761, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetItemId(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemId_Public_Int32_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226791, RefRangeEnd = 226792, XrefRangeStart = 226787, XrefRangeEnd = 226791, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetConsumableItemId(int consumableId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&consumableId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetConsumableItemId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226796, RefRangeEnd = 226797, XrefRangeStart = 226792, XrefRangeEnd = 226796, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetLootableAbilityItemId(int lootableAbilityId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&lootableAbilityId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLootableAbilityItemId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226799, RefRangeEnd = 226800, XrefRangeStart = 226797, XrefRangeEnd = 226799, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetConsumableIdByItemId(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetConsumableIdByItemId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(11)]
	[CachedScanResults(RefRangeStart = 226809, RefRangeEnd = 226820, XrefRangeStart = 226800, XrefRangeEnd = 226809, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetConsumableMaxCount(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetConsumableMaxCount_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 226829, RefRangeEnd = 226835, XrefRangeStart = 226820, XrefRangeEnd = 226829, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool GetConsumableIsDroppable(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetConsumableIsDroppable_Public_Boolean_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226837, RefRangeEnd = 226838, XrefRangeStart = 226835, XrefRangeEnd = 226837, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetLootableAbilityIdByItemId(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLootableAbilityIdByItemId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226842, RefRangeEnd = 226845, XrefRangeStart = 226838, XrefRangeEnd = 226842, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetCurrencyItemId(int currencyId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&currencyId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrencyItemId_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226849, RefRangeEnd = 226850, XrefRangeStart = 226845, XrefRangeEnd = 226849, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsItemMaxTier(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsItemMaxTier_Public_Boolean_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 226853, RefRangeEnd = 226859, XrefRangeStart = 226850, XrefRangeEnd = 226853, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsItemMaxTier(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsItemMaxTier_Public_Boolean_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226861, RefRangeEnd = 226863, XrefRangeStart = 226859, XrefRangeEnd = 226861, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetNextItemTier(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetNextItemTier_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226866, RefRangeEnd = 226868, XrefRangeStart = 226863, XrefRangeEnd = 226866, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetNextItemTier(Gear gear)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gear);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetNextItemTier_Public_Int32_Gear_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 226872, RefRangeEnd = 226875, XrefRangeStart = 226868, XrefRangeEnd = 226872, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float GetItemPowerLevelNorm(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemPowerLevelNorm_Public_Single_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 226875, XrefRangeEnd = 226878, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float GetItemPowerLevelNorm(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemPowerLevelNorm_Public_Single_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 226881, RefRangeEnd = 226885, XrefRangeStart = 226878, XrefRangeEnd = 226881, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ItemTheme GetItemThemeByTier(ItemTiers tier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&tier);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemThemeByTier_Public_ItemTheme_ItemTiers_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ItemTheme>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226900, RefRangeEnd = 226902, XrefRangeStart = 226885, XrefRangeEnd = 226900, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string BuildStatString(ItemStat itemStat, bool compact = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&itemStat);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &compact;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildStatString_Public_String_ItemStat_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 226908, RefRangeEnd = 226909, XrefRangeStart = 226902, XrefRangeEnd = 226908, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetStatValue(ItemStat itemStat)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemStat);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetStatValue_Public_String_ItemStat_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226927, RefRangeEnd = 226929, XrefRangeStart = 226909, XrefRangeEnd = 226927, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetItemTypeName(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemTypeName_Public_String_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 226934, RefRangeEnd = 226939, XrefRangeStart = 226929, XrefRangeEnd = 226934, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetItemName(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemName_Public_String_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 226943, RefRangeEnd = 226952, XrefRangeStart = 226939, XrefRangeEnd = 226943, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetItemName(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemName_Public_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226957, RefRangeEnd = 226959, XrefRangeStart = 226952, XrefRangeEnd = 226957, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetItemDescription(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemDescription_Public_String_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 226963, RefRangeEnd = 226968, XrefRangeStart = 226959, XrefRangeEnd = 226963, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetItemDescription(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemDescription_Public_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 226971, RefRangeEnd = 226977, XrefRangeStart = 226968, XrefRangeEnd = 226971, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Color GetItemColor(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetItemColor_Public_Color_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Color*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(11)]
	[CachedScanResults(RefRangeStart = 226980, RefRangeEnd = 226991, XrefRangeStart = 226977, XrefRangeEnd = 226980, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Color GetTierColor(ItemTiers tier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&tier);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTierColor_Public_Color_ItemTiers_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Color*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 226995, RefRangeEnd = 226997, XrefRangeStart = 226991, XrefRangeEnd = 226995, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetTierName(ItemTiers tier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&tier);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTierName_Public_String_ItemTiers_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 227005, RefRangeEnd = 227007, XrefRangeStart = 226997, XrefRangeEnd = 227005, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Sprite GetGearSlotIcon(Gear item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetGearSlotIcon_Public_Sprite_Gear_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 227011, RefRangeEnd = 227012, XrefRangeStart = 227007, XrefRangeEnd = 227011, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetGearSlotName(int slotId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&slotId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetGearSlotName_Public_String_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 227012, XrefRangeEnd = 227032, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetTierAndSlotTypeName(Gear item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTierAndSlotTypeName_Public_String_Gear_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 227040, RefRangeEnd = 227043, XrefRangeStart = 227032, XrefRangeEnd = 227040, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AudioClipData GetPickupSfx(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPickupSfx_Public_AudioClipData_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 227051, RefRangeEnd = 227057, XrefRangeStart = 227043, XrefRangeEnd = 227051, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AudioClipData GetDropSfx(int itemId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&itemId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDropSfx_Public_AudioClipData_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 227057, XrefRangeEnd = 227064, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AudioClipData GetPickupSfx(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPickupSfx_Public_AudioClipData_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 227064, XrefRangeEnd = 227071, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AudioClipData GetDropSfx(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDropSfx_Public_AudioClipData_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 227071, XrefRangeEnd = 227072, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ItemManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ItemManager>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ItemManager(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

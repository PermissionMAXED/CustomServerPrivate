using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Items;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class P_BuffX_AtkSpeed_Attack : Passive
{
	[Serializable]
	public class Config : PassiveConfiguration
	{
		private static readonly IntPtr NativeFieldInfoPtr_bonusDmgPerAtkSpeed;

		private static readonly IntPtr NativeFieldInfoPtr_bonusPercentDamagePerAtkSpeed;

		private static readonly IntPtr NativeFieldInfoPtr_flatPercentDamageIncrease;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe float bonusDmgPerAtkSpeed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusDmgPerAtkSpeed);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusDmgPerAtkSpeed)) = num;
			}
		}

		public unsafe float bonusPercentDamagePerAtkSpeed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusPercentDamagePerAtkSpeed);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusPercentDamagePerAtkSpeed)) = num;
			}
		}

		public unsafe float flatPercentDamageIncrease
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flatPercentDamageIncrease);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flatPercentDamageIncrease)) = num;
			}
		}

		static Config()
		{
			Il2CppClassPointerStore<Config>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, "Config");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Config>.NativeClassPtr);
			NativeFieldInfoPtr_bonusDmgPerAtkSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "bonusDmgPerAtkSpeed");
			NativeFieldInfoPtr_bonusPercentDamagePerAtkSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "bonusPercentDamagePerAtkSpeed");
			NativeFieldInfoPtr_flatPercentDamageIncrease = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Config>.NativeClassPtr, "flatPercentDamageIncrease");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Config>.NativeClassPtr, 100676989);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 175685, XrefRangeEnd = 175686, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Config()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Config>.NativeClassPtr))
		{
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Config(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly IntPtr NativeFieldInfoPtr_config;

	private static readonly IntPtr NativeFieldInfoPtr_baseAtkSpeed;

	private static readonly IntPtr NativeFieldInfoPtr_bonusDmg;

	private static readonly IntPtr NativeFieldInfoPtr_bonusPercentDamage;

	private static readonly IntPtr NativeMethodInfoPtr_get_passiveConfig_Public_Virtual_get_PassiveConfiguration_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_EntityManager_Config_0;

	private static readonly IntPtr NativeMethodInfoPtr_ActivatePassive_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnStatsChanged_Public_Virtual_Void_Boolean_ItemStat_0;

	private static readonly IntPtr NativeMethodInfoPtr_DeactivatePassive_Public_Virtual_Void_0;

	public unsafe Config config
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_config);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Config>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_config)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config));
		}
	}

	public unsafe float baseAtkSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseAtkSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseAtkSpeed)) = num;
		}
	}

	public unsafe float bonusDmg
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusDmg);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusDmg)) = num;
		}
	}

	public unsafe float bonusPercentDamage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusPercentDamage);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonusPercentDamage)) = num;
		}
	}

	public unsafe override PassiveConfiguration passiveConfig
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 98450, RefRangeEnd = 98452, XrefRangeStart = 98450, XrefRangeEnd = 98452, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_passiveConfig_Public_Virtual_get_PassiveConfiguration_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PassiveConfiguration>(intPtr) : null;
		}
	}

	static P_BuffX_AtkSpeed_Attack()
	{
		Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "P_BuffX_AtkSpeed_Attack");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr);
		NativeFieldInfoPtr_config = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, "config");
		NativeFieldInfoPtr_baseAtkSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, "baseAtkSpeed");
		NativeFieldInfoPtr_bonusDmg = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, "bonusDmg");
		NativeFieldInfoPtr_bonusPercentDamage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, "bonusPercentDamage");
		NativeMethodInfoPtr_get_passiveConfig_Public_Virtual_get_PassiveConfiguration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, 100676984);
		NativeMethodInfoPtr__ctor_Public_Void_EntityManager_Config_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, 100676985);
		NativeMethodInfoPtr_ActivatePassive_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, 100676986);
		NativeMethodInfoPtr_OnStatsChanged_Public_Virtual_Void_Boolean_ItemStat_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, 100676987);
		NativeMethodInfoPtr_DeactivatePassive_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr, 100676988);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 175686, XrefRangeEnd = 175687, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe P_BuffX_AtkSpeed_Attack(EntityManager entityManager, Config config)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<P_BuffX_AtkSpeed_Attack>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_EntityManager_Config_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 175687, XrefRangeEnd = 175689, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void ActivatePassive()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_ActivatePassive_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 175689, XrefRangeEnd = 175691, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnStatsChanged(bool added, ItemStat stat)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&added);
		*(ItemStat**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &stat;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnStatsChanged_Public_Virtual_Void_Boolean_ItemStat_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 175691, XrefRangeEnd = 175693, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void DeactivatePassive()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_DeactivatePassive_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public P_BuffX_AtkSpeed_Attack(IntPtr pointer)
		: base(pointer)
	{
	}
}

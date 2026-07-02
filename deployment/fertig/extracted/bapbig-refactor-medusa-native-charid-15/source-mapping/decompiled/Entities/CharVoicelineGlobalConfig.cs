using System;
using System.Runtime.CompilerServices;
using Il2CppFMOD.Studio;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class CharVoicelineGlobalConfig : ScriptableObject
{
	[System.Serializable]
	public class CharNameMapping : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_Name;

		private static readonly System.IntPtr NativeFieldInfoPtr_ID;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string Name
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Name);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Name)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe int ID
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ID);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ID)) = num;
			}
		}

		static CharNameMapping()
		{
			Il2CppClassPointerStore<CharNameMapping>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "CharNameMapping");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharNameMapping>.NativeClassPtr);
			NativeFieldInfoPtr_Name = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharNameMapping>.NativeClassPtr, "Name");
			NativeFieldInfoPtr_ID = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharNameMapping>.NativeClassPtr, "ID");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharNameMapping>.NativeClassPtr, 100673062);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CharNameMapping()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharNameMapping>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CharNameMapping(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__nameMapping;

	private static readonly System.IntPtr NativeFieldInfoPtr__kill;

	private static readonly System.IntPtr NativeFieldInfoPtr__ace;

	private static readonly System.IntPtr NativeFieldInfoPtr__damage;

	private static readonly System.IntPtr NativeFieldInfoPtr__death;

	private static readonly System.IntPtr NativeFieldInfoPtr__resurrected;

	private static readonly System.IntPtr NativeFieldInfoPtr__zone;

	private static readonly System.IntPtr NativeFieldInfoPtr__win;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingAttack;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingEnemySpotted;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingHealing;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingHelp;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingOnMyWay;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingRetreat;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingStickTogether;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingWait;

	private static readonly System.IntPtr NativeFieldInfoPtr__pingNeedGold;

	private static readonly System.IntPtr NativeFieldInfoPtr__select;

	private static readonly System.IntPtr NativeFieldInfoPtr__unlock;

	private static readonly System.IntPtr NativeFieldInfoPtr__mastery;

	private static readonly System.IntPtr NativeFieldInfoPtr__mvp;

	private static readonly System.IntPtr NativeFieldInfoPtr__legendaryItem;

	private static readonly System.IntPtr NativeFieldInfoPtr__configs;

	private static readonly System.IntPtr NativeFieldInfoPtr__logMissingVoicelines;

	private static readonly System.IntPtr NativeFieldInfoPtr__nameLookup;

	private static readonly System.IntPtr NativeFieldInfoPtr__configLookup;

	private static readonly System.IntPtr NativeFieldInfoPtr__instance;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Kill_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Ace_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Damage_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Death_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Resurrected_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Zone_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Win_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingAttack_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingEnemySpotted_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingHealing_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingHelp_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingOnMyWay_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingStickTogether_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingRetreat_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingWait_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_PingNeedGold_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Select_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Unlock_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Mastery_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_MVP_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_LegendaryItem_Public_Static_get_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_LogMissingVoicelines_Public_Static_get_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TryGetEvent_Public_Static_Boolean_Int32_CharVoicelineConfig_byref_EventDescription_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TryGetConfig_Public_Static_Boolean_Int32_byref_CharVoicelineConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnEnable_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<CharNameMapping> _nameMapping
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nameMapping);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<CharNameMapping>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nameMapping)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe CharVoicelineConfig _kill
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__kill);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__kill)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _ace
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__ace);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__ace)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _damage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__damage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__damage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _death
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__death);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__death)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _resurrected
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__resurrected);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__resurrected)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _zone
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__zone);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__zone)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _win
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__win);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__win)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingAttack
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingAttack);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingAttack)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingEnemySpotted
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingEnemySpotted);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingEnemySpotted)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingHealing
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingHealing);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingHealing)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingHelp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingHelp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingHelp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingOnMyWay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingOnMyWay);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingOnMyWay)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingRetreat
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingRetreat);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingRetreat)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingStickTogether
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingStickTogether);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingStickTogether)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingWait
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingWait);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingWait)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _pingNeedGold
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingNeedGold);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pingNeedGold)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _select
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__select);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__select)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _unlock
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__unlock);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__unlock)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _mastery
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mastery);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mastery)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _mvp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mvp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mvp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe CharVoicelineConfig _legendaryItem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__legendaryItem);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__legendaryItem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineConfig));
		}
	}

	public unsafe Il2CppReferenceArray<CharVoicelineConfig> _configs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configs);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<CharVoicelineConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe bool _logMissingVoicelines
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__logMissingVoicelines);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__logMissingVoicelines)) = flag;
		}
	}

	public unsafe Dictionary<int, string> _nameLookup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nameLookup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<int, string>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__nameLookup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe Dictionary<int, CharVoicelineConfig> _configLookup
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configLookup);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<int, CharVoicelineConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configLookup)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe static CharVoicelineGlobalConfig _instance
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__instance, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineGlobalConfig>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__instance, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineGlobalConfig));
		}
	}

	public unsafe static CharVoicelineConfig Kill
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 122596, XrefRangeEnd = 122597, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Kill_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Ace
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 122597, XrefRangeEnd = 122598, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Ace_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Damage
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122599, RefRangeEnd = 122600, XrefRangeStart = 122598, XrefRangeEnd = 122599, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Damage_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Death
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122601, RefRangeEnd = 122602, XrefRangeStart = 122600, XrefRangeEnd = 122601, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Death_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Resurrected
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122603, RefRangeEnd = 122604, XrefRangeStart = 122602, XrefRangeEnd = 122603, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Resurrected_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Zone
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 122605, RefRangeEnd = 122607, XrefRangeStart = 122604, XrefRangeEnd = 122605, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Zone_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Win
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122608, RefRangeEnd = 122609, XrefRangeStart = 122607, XrefRangeEnd = 122608, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Win_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingAttack
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122610, RefRangeEnd = 122611, XrefRangeStart = 122609, XrefRangeEnd = 122610, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingAttack_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingEnemySpotted
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122612, RefRangeEnd = 122613, XrefRangeStart = 122611, XrefRangeEnd = 122612, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingEnemySpotted_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingHealing
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122614, RefRangeEnd = 122615, XrefRangeStart = 122613, XrefRangeEnd = 122614, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingHealing_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingHelp
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122616, RefRangeEnd = 122617, XrefRangeStart = 122615, XrefRangeEnd = 122616, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingHelp_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingOnMyWay
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122618, RefRangeEnd = 122619, XrefRangeStart = 122617, XrefRangeEnd = 122618, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingOnMyWay_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingStickTogether
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122620, RefRangeEnd = 122621, XrefRangeStart = 122619, XrefRangeEnd = 122620, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingStickTogether_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingRetreat
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122622, RefRangeEnd = 122623, XrefRangeStart = 122621, XrefRangeEnd = 122622, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingRetreat_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingWait
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122624, RefRangeEnd = 122625, XrefRangeStart = 122623, XrefRangeEnd = 122624, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingWait_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig PingNeedGold
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122626, RefRangeEnd = 122627, XrefRangeStart = 122625, XrefRangeEnd = 122626, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_PingNeedGold_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Select
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122628, RefRangeEnd = 122629, XrefRangeStart = 122627, XrefRangeEnd = 122628, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Select_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Unlock
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122630, RefRangeEnd = 122631, XrefRangeStart = 122629, XrefRangeEnd = 122630, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Unlock_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig Mastery
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122632, RefRangeEnd = 122633, XrefRangeStart = 122631, XrefRangeEnd = 122632, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Mastery_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig MVP
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 122634, RefRangeEnd = 122635, XrefRangeStart = 122633, XrefRangeEnd = 122634, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_MVP_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static CharVoicelineConfig LegendaryItem
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 122635, XrefRangeEnd = 122636, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_LegendaryItem_Public_Static_get_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineConfig>(intPtr) : null;
		}
	}

	public unsafe static bool LogMissingVoicelines
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 122636, XrefRangeEnd = 122637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_LogMissingVoicelines_Public_Static_get_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static CharVoicelineGlobalConfig()
	{
		Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CharVoicelineGlobalConfig");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr);
		NativeFieldInfoPtr__nameMapping = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_nameMapping");
		NativeFieldInfoPtr__kill = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_kill");
		NativeFieldInfoPtr__ace = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_ace");
		NativeFieldInfoPtr__damage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_damage");
		NativeFieldInfoPtr__death = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_death");
		NativeFieldInfoPtr__resurrected = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_resurrected");
		NativeFieldInfoPtr__zone = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_zone");
		NativeFieldInfoPtr__win = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_win");
		NativeFieldInfoPtr__pingAttack = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingAttack");
		NativeFieldInfoPtr__pingEnemySpotted = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingEnemySpotted");
		NativeFieldInfoPtr__pingHealing = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingHealing");
		NativeFieldInfoPtr__pingHelp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingHelp");
		NativeFieldInfoPtr__pingOnMyWay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingOnMyWay");
		NativeFieldInfoPtr__pingRetreat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingRetreat");
		NativeFieldInfoPtr__pingStickTogether = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingStickTogether");
		NativeFieldInfoPtr__pingWait = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingWait");
		NativeFieldInfoPtr__pingNeedGold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_pingNeedGold");
		NativeFieldInfoPtr__select = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_select");
		NativeFieldInfoPtr__unlock = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_unlock");
		NativeFieldInfoPtr__mastery = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_mastery");
		NativeFieldInfoPtr__mvp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_mvp");
		NativeFieldInfoPtr__legendaryItem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_legendaryItem");
		NativeFieldInfoPtr__configs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_configs");
		NativeFieldInfoPtr__logMissingVoicelines = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_logMissingVoicelines");
		NativeFieldInfoPtr__nameLookup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_nameLookup");
		NativeFieldInfoPtr__configLookup = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_configLookup");
		NativeFieldInfoPtr__instance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, "_instance");
		NativeMethodInfoPtr_get_Kill_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673036);
		NativeMethodInfoPtr_get_Ace_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673037);
		NativeMethodInfoPtr_get_Damage_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673038);
		NativeMethodInfoPtr_get_Death_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673039);
		NativeMethodInfoPtr_get_Resurrected_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673040);
		NativeMethodInfoPtr_get_Zone_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673041);
		NativeMethodInfoPtr_get_Win_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673042);
		NativeMethodInfoPtr_get_PingAttack_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673043);
		NativeMethodInfoPtr_get_PingEnemySpotted_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673044);
		NativeMethodInfoPtr_get_PingHealing_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673045);
		NativeMethodInfoPtr_get_PingHelp_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673046);
		NativeMethodInfoPtr_get_PingOnMyWay_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673047);
		NativeMethodInfoPtr_get_PingStickTogether_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673048);
		NativeMethodInfoPtr_get_PingRetreat_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673049);
		NativeMethodInfoPtr_get_PingWait_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673050);
		NativeMethodInfoPtr_get_PingNeedGold_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673051);
		NativeMethodInfoPtr_get_Select_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673052);
		NativeMethodInfoPtr_get_Unlock_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673053);
		NativeMethodInfoPtr_get_Mastery_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673054);
		NativeMethodInfoPtr_get_MVP_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673055);
		NativeMethodInfoPtr_get_LegendaryItem_Public_Static_get_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673056);
		NativeMethodInfoPtr_get_LogMissingVoicelines_Public_Static_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673057);
		NativeMethodInfoPtr_TryGetEvent_Public_Static_Boolean_Int32_CharVoicelineConfig_byref_EventDescription_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673058);
		NativeMethodInfoPtr_TryGetConfig_Public_Static_Boolean_Int32_byref_CharVoicelineConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673059);
		NativeMethodInfoPtr_OnEnable_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673060);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr, 100673061);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 122643, RefRangeEnd = 122648, XrefRangeStart = 122637, XrefRangeEnd = 122643, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool TryGetEvent(int charId, CharVoicelineConfig config, out EventDescription eventDescription)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&charId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config);
		*(void**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref eventDescription);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryGetEvent_Public_Static_Boolean_Int32_CharVoicelineConfig_byref_EventDescription_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 122651, RefRangeEnd = 122654, XrefRangeStart = 122648, XrefRangeEnd = 122651, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool TryGetConfig(int id, out CharVoicelineConfig config)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&id);
		byte* num = (byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)));
		nint num2 = 0;
		*(nint**)num = &num2;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryGetConfig_Public_Static_Boolean_Int32_byref_CharVoicelineConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		nint num3 = num2;
		config = ((num3 == 0) ? null : new CharVoicelineConfig(num3));
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 122654, XrefRangeEnd = 122679, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnEnable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnEnable_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CharVoicelineGlobalConfig()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharVoicelineGlobalConfig>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CharVoicelineGlobalConfig(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

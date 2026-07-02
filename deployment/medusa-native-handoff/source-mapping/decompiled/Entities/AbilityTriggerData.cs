using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Utilities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Entities;

[System.Serializable]
public class AbilityTriggerData : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_ability;

	private static readonly System.IntPtr NativeFieldInfoPtr_updateRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_randomChanceRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_randomChanceNorm;

	private static readonly System.IntPtr NativeFieldInfoPtr_needsLineOfSight;

	private static readonly System.IntPtr NativeFieldInfoPtr_triggerDistRange;

	private static readonly System.IntPtr NativeFieldInfoPtr_minAngleDiff;

	private static readonly System.IntPtr NativeFieldInfoPtr_futurePredictTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_randomSpread;

	private static readonly System.IntPtr NativeFieldInfoPtr_keepDistance;

	private static readonly System.IntPtr NativeFieldInfoPtr_flipDirection;

	private static readonly System.IntPtr NativeFieldInfoPtr_doOnTick;

	private static readonly System.IntPtr NativeFieldInfoPtr_extraCd;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Ability ability
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Ability>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability));
		}
	}

	public unsafe float updateRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateRate)) = num;
		}
	}

	public unsafe float randomChanceRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceRate)) = num;
		}
	}

	public unsafe float randomChanceNorm
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceNorm);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceNorm)) = num;
		}
	}

	public unsafe bool needsLineOfSight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_needsLineOfSight);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_needsLineOfSight)) = flag;
		}
	}

	public unsafe RangeFloat triggerDistRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerDistRange);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RangeFloat>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerDistRange)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rangeFloat));
		}
	}

	public unsafe float minAngleDiff
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minAngleDiff);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minAngleDiff)) = num;
		}
	}

	public unsafe float futurePredictTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictTime)) = num;
		}
	}

	public unsafe float randomSpread
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomSpread);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomSpread)) = num;
		}
	}

	public unsafe float keepDistance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keepDistance);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keepDistance)) = num;
		}
	}

	public unsafe bool flipDirection
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flipDirection);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flipDirection)) = flag;
		}
	}

	public unsafe bool doOnTick
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doOnTick);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doOnTick)) = flag;
		}
	}

	public unsafe float extraCd
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraCd);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraCd)) = num;
		}
	}

	static AbilityTriggerData()
	{
		Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "AbilityTriggerData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr);
		NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "ability");
		NativeFieldInfoPtr_updateRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "updateRate");
		NativeFieldInfoPtr_randomChanceRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "randomChanceRate");
		NativeFieldInfoPtr_randomChanceNorm = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "randomChanceNorm");
		NativeFieldInfoPtr_needsLineOfSight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "needsLineOfSight");
		NativeFieldInfoPtr_triggerDistRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "triggerDistRange");
		NativeFieldInfoPtr_minAngleDiff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "minAngleDiff");
		NativeFieldInfoPtr_futurePredictTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "futurePredictTime");
		NativeFieldInfoPtr_randomSpread = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "randomSpread");
		NativeFieldInfoPtr_keepDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "keepDistance");
		NativeFieldInfoPtr_flipDirection = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "flipDirection");
		NativeFieldInfoPtr_doOnTick = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "doOnTick");
		NativeFieldInfoPtr_extraCd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, "extraCd");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr, 100675711);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AbilityTriggerData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AbilityTriggerData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public AbilityTriggerData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

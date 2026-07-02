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
public class BattlePassLevelModel : Il2CppSystem.Object
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

	public unsafe Il2CppReferenceArray<ShopListingModel> listings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listings);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ShopListingModel>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static BattlePassLevelModel()
	{
		Il2CppClassPointerStore<BattlePassLevelModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "BattlePassLevelModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BattlePassLevelModel>.NativeClassPtr);
		NativeFieldInfoPtr_level = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassLevelModel>.NativeClassPtr, "level");
		NativeFieldInfoPtr_xpNeeded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassLevelModel>.NativeClassPtr, "xpNeeded");
		NativeFieldInfoPtr_listings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BattlePassLevelModel>.NativeClassPtr, "listings");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BattlePassLevelModel>.NativeClassPtr, 100670910);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe BattlePassLevelModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BattlePassLevelModel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public BattlePassLevelModel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

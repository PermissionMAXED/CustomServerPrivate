using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.UI;

public class FractalsPurchaseModel : Model
{
	public class Listing : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_listingId;

		private static readonly System.IntPtr NativeFieldInfoPtr_fractals;

		private static readonly System.IntPtr NativeFieldInfoPtr_cost;

		private static readonly System.IntPtr NativeFieldInfoPtr_bonus;

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

		public unsafe float cost
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cost);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cost)) = num;
			}
		}

		public unsafe float bonus
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonus);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bonus)) = num;
			}
		}

		static Listing()
		{
			Il2CppClassPointerStore<Listing>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FractalsPurchaseModel>.NativeClassPtr, "Listing");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Listing>.NativeClassPtr);
			NativeFieldInfoPtr_listingId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "listingId");
			NativeFieldInfoPtr_fractals = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "fractals");
			NativeFieldInfoPtr_cost = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "cost");
			NativeFieldInfoPtr_bonus = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Listing>.NativeClassPtr, "bonus");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Listing>.NativeClassPtr, 100670927);
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

	private static readonly System.IntPtr NativeFieldInfoPtr_listings;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

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

	static FractalsPurchaseModel()
	{
		Il2CppClassPointerStore<FractalsPurchaseModel>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "FractalsPurchaseModel");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FractalsPurchaseModel>.NativeClassPtr);
		NativeFieldInfoPtr_listings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FractalsPurchaseModel>.NativeClassPtr, "listings");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FractalsPurchaseModel>.NativeClassPtr, 100670926);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 106447, RefRangeEnd = 106448, XrefRangeStart = 106444, XrefRangeEnd = 106447, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FractalsPurchaseModel()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FractalsPurchaseModel>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public FractalsPurchaseModel(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

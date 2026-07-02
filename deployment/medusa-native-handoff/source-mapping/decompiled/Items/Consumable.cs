using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Entities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Items;

public class Consumable : Item
{
	private static readonly IntPtr NativeFieldInfoPtr_consumableBehaviour;

	private static readonly IntPtr NativeFieldInfoPtr_maxCount;

	private static readonly IntPtr NativeFieldInfoPtr_droppable;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe AbilityBehaviourSO consumableBehaviour
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableBehaviour);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AbilityBehaviourSO>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumableBehaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityBehaviourSO));
		}
	}

	public unsafe int maxCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxCount)) = num;
		}
	}

	public unsafe bool droppable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_droppable);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_droppable)) = flag;
		}
	}

	static Consumable()
	{
		Il2CppClassPointerStore<Consumable>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Items", "Consumable");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Consumable>.NativeClassPtr);
		NativeFieldInfoPtr_consumableBehaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Consumable>.NativeClassPtr, "consumableBehaviour");
		NativeFieldInfoPtr_maxCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Consumable>.NativeClassPtr, "maxCount");
		NativeFieldInfoPtr_droppable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Consumable>.NativeClassPtr, "droppable");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Consumable>.NativeClassPtr, 100671962);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 113014, XrefRangeEnd = 113015, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Consumable()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Consumable>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public Consumable(IntPtr pointer)
		: base(pointer)
	{
	}
}

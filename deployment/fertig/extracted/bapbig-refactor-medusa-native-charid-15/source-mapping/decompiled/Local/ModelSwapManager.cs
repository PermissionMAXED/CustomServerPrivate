using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class ModelSwapManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_modelSwaps;

	private static readonly IntPtr NativeMethodInfoPtr_GetModelSwapSize_Public_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetModel_Public_ModelSwaps_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetRandomIdByChance_Public_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<ModelSwaps> modelSwaps
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modelSwaps);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ModelSwaps>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modelSwaps)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static ModelSwapManager()
	{
		Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "ModelSwapManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr);
		NativeFieldInfoPtr_modelSwaps = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr, "modelSwaps");
		NativeMethodInfoPtr_GetModelSwapSize_Public_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr, 100684474);
		NativeMethodInfoPtr_GetModel_Public_ModelSwaps_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr, 100684475);
		NativeMethodInfoPtr_GetRandomIdByChance_Public_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr, 100684476);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr, 100684477);
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 228066, RefRangeEnd = 228075, XrefRangeStart = 228066, XrefRangeEnd = 228066, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetModelSwapSize()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModelSwapSize_Public_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 65166, RefRangeEnd = 65167, XrefRangeStart = 65166, XrefRangeEnd = 65167, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ModelSwaps GetModel(int id)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&id);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModel_Public_ModelSwaps_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ModelSwaps>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 228077, RefRangeEnd = 228079, XrefRangeStart = 228075, XrefRangeEnd = 228077, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetRandomIdByChance(int excludeIndex = -1)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&excludeIndex);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomIdByChance_Public_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ModelSwapManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ModelSwapManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ModelSwapManager(IntPtr pointer)
		: base(pointer)
	{
	}
}

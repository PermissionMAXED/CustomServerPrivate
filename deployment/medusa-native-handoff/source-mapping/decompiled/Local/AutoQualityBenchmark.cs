using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Diagnostics;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class AutoQualityBenchmark : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_renderCamera;

	private static readonly IntPtr NativeFieldInfoPtr_spawnParent;

	private static readonly IntPtr NativeFieldInfoPtr_spawnPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_spawnCount;

	private static readonly IntPtr NativeFieldInfoPtr_cpuTimeUltra;

	private static readonly IntPtr NativeFieldInfoPtr_gpuTimeUltra;

	private static readonly IntPtr NativeFieldInfoPtr_renderTexture;

	private static readonly IntPtr NativeFieldInfoPtr_stopwatch;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RunBenchmark_Public_QualityPresets_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Camera renderCamera
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderCamera);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Camera>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderCamera)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)camera));
		}
	}

	public unsafe Transform spawnParent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnParent);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnParent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe GameObject spawnPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe int spawnCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnCount)) = num;
		}
	}

	public unsafe int cpuTimeUltra
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cpuTimeUltra);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cpuTimeUltra)) = num;
		}
	}

	public unsafe int gpuTimeUltra
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gpuTimeUltra);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gpuTimeUltra)) = num;
		}
	}

	public unsafe RenderTexture renderTexture
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderTexture);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RenderTexture>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_renderTexture)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)renderTexture));
		}
	}

	public unsafe Stopwatch stopwatch
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stopwatch);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Stopwatch>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stopwatch)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stopwatch));
		}
	}

	static AutoQualityBenchmark()
	{
		Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "AutoQualityBenchmark");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr);
		NativeFieldInfoPtr_renderCamera = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "renderCamera");
		NativeFieldInfoPtr_spawnParent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "spawnParent");
		NativeFieldInfoPtr_spawnPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "spawnPrefab");
		NativeFieldInfoPtr_spawnCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "spawnCount");
		NativeFieldInfoPtr_cpuTimeUltra = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "cpuTimeUltra");
		NativeFieldInfoPtr_gpuTimeUltra = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "gpuTimeUltra");
		NativeFieldInfoPtr_renderTexture = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "renderTexture");
		NativeFieldInfoPtr_stopwatch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, "stopwatch");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, 100683745);
		NativeMethodInfoPtr_RunBenchmark_Public_QualityPresets_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, 100683746);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr, 100683747);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 222631, XrefRangeEnd = 222632, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 222691, RefRangeEnd = 222695, XrefRangeStart = 222632, XrefRangeEnd = 222691, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LocalSavedData.QualityPresets RunBenchmark()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RunBenchmark_Public_QualityPresets_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(LocalSavedData.QualityPresets*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AutoQualityBenchmark()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AutoQualityBenchmark>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public AutoQualityBenchmark(IntPtr pointer)
		: base(pointer)
	{
	}
}

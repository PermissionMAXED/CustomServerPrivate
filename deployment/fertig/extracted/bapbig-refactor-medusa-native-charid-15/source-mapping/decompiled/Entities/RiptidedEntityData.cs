using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

[System.Serializable]
public sealed class RiptidedEntityData : Il2CppSystem.ValueType
{
	private static readonly System.IntPtr NativeFieldInfoPtr_entityManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_vfxInitialized;

	private static readonly System.IntPtr NativeFieldInfoPtr_withCurrentVFX;

	private static readonly System.IntPtr NativeFieldInfoPtr_withCurrentEmissionRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_againstCurrentVFX;

	private static readonly System.IntPtr NativeFieldInfoPtr_againstCurrentEmissionRate;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeVfx_Public_Void_ParticleSystem_ParticleSystem_0;

	public unsafe EntityManager entityManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<EntityManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityManager));
		}
	}

	public unsafe bool vfxInitialized
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxInitialized);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxInitialized)) = flag;
		}
	}

	public unsafe ParticleSystem withCurrentVFX
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_withCurrentVFX);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ParticleSystem>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_withCurrentVFX)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)particleSystem));
		}
	}

	public unsafe float withCurrentEmissionRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_withCurrentEmissionRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_withCurrentEmissionRate)) = num;
		}
	}

	public unsafe ParticleSystem againstCurrentVFX
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_againstCurrentVFX);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ParticleSystem>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_againstCurrentVFX)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)particleSystem));
		}
	}

	public unsafe float againstCurrentEmissionRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_againstCurrentEmissionRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_againstCurrentEmissionRate)) = num;
		}
	}

	static RiptidedEntityData()
	{
		Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "RiptidedEntityData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr);
		NativeFieldInfoPtr_entityManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, "entityManager");
		NativeFieldInfoPtr_vfxInitialized = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, "vfxInitialized");
		NativeFieldInfoPtr_withCurrentVFX = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, "withCurrentVFX");
		NativeFieldInfoPtr_withCurrentEmissionRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, "withCurrentEmissionRate");
		NativeFieldInfoPtr_againstCurrentVFX = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, "againstCurrentVFX");
		NativeFieldInfoPtr_againstCurrentEmissionRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, "againstCurrentEmissionRate");
		NativeMethodInfoPtr__ctor_Public_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, 100680517);
		NativeMethodInfoPtr_InitializeVfx_Public_Void_ParticleSystem_ParticleSystem_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr, 100680518);
	}

	[CallerCount(0)]
	public unsafe RiptidedEntityData(EntityManager eM)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)eM);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_EntityManager_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 197192, RefRangeEnd = 197193, XrefRangeStart = 197180, XrefRangeEnd = 197192, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeVfx(ParticleSystem withCurrentVFX, ParticleSystem againstCurrentVFX)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)withCurrentVFX);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)againstCurrentVFX);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeVfx_Public_Void_ParticleSystem_ParticleSystem_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public RiptidedEntityData(System.IntPtr pointer)
		: base(pointer)
	{
	}

	public RiptidedEntityData()
		: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RiptidedEntityData>.NativeClassPtr))
	{
	}
}

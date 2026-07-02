using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Systems;

public class SystemManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_playerSystem;

	private static readonly IntPtr NativeFieldInfoPtr_hpBarSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityNetworkSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityMaterialSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityAnimatorSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityBushInteractSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityFootstepsSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityHiddenSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityInterpolatorSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityMinimapSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityWorldPositionSystem;

	private static readonly IntPtr NativeFieldInfoPtr_entityStatusEffectSystem;

	private static readonly IntPtr NativeFieldInfoPtr_Instance;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe PlayerSystem playerSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PlayerSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)playerSystem));
		}
	}

	public unsafe HpBarSystem hpBarSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hpBarSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<HpBarSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hpBarSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hpBarSystem));
		}
	}

	public unsafe EntityNetworkSystem entityNetworkSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityNetworkSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityNetworkSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityNetworkSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityNetworkSystem));
		}
	}

	public unsafe EntityMaterialSystem entityMaterialSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityMaterialSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityMaterialSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityMaterialSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityMaterialSystem));
		}
	}

	public unsafe EntityAnimatorSystem entityAnimatorSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityAnimatorSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityAnimatorSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityAnimatorSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityAnimatorSystem));
		}
	}

	public unsafe EntityBushInteractSystem entityBushInteractSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityBushInteractSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityBushInteractSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityBushInteractSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityBushInteractSystem));
		}
	}

	public unsafe EntityFootstepsSystem entityFootstepsSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityFootstepsSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityFootstepsSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityFootstepsSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityFootstepsSystem));
		}
	}

	public unsafe EntityHiddenSystem entityHiddenSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityHiddenSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityHiddenSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityHiddenSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityHiddenSystem));
		}
	}

	public unsafe EntityInterpolatorSystem entityInterpolatorSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityInterpolatorSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityInterpolatorSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityInterpolatorSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityInterpolatorSystem));
		}
	}

	public unsafe EntityMinimapSystem entityMinimapSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityMinimapSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityMinimapSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityMinimapSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityMinimapSystem));
		}
	}

	public unsafe EntityWorldPositionSystem entityWorldPositionSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityWorldPositionSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityWorldPositionSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityWorldPositionSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityWorldPositionSystem));
		}
	}

	public unsafe EntityStatusEffectSystem entityStatusEffectSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityStatusEffectSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityStatusEffectSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityStatusEffectSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityStatusEffectSystem));
		}
	}

	public unsafe static SystemManager Instance
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Instance, (void*)(&intPtr));
			IntPtr intPtr2 = intPtr;
			return (intPtr2 != (IntPtr)0) ? Il2CppObjectPool.Get<SystemManager>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Instance, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)systemManager));
		}
	}

	static SystemManager()
	{
		Il2CppClassPointerStore<SystemManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Systems", "SystemManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SystemManager>.NativeClassPtr);
		NativeFieldInfoPtr_playerSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "playerSystem");
		NativeFieldInfoPtr_hpBarSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "hpBarSystem");
		NativeFieldInfoPtr_entityNetworkSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityNetworkSystem");
		NativeFieldInfoPtr_entityMaterialSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityMaterialSystem");
		NativeFieldInfoPtr_entityAnimatorSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityAnimatorSystem");
		NativeFieldInfoPtr_entityBushInteractSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityBushInteractSystem");
		NativeFieldInfoPtr_entityFootstepsSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityFootstepsSystem");
		NativeFieldInfoPtr_entityHiddenSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityHiddenSystem");
		NativeFieldInfoPtr_entityInterpolatorSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityInterpolatorSystem");
		NativeFieldInfoPtr_entityMinimapSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityMinimapSystem");
		NativeFieldInfoPtr_entityWorldPositionSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityWorldPositionSystem");
		NativeFieldInfoPtr_entityStatusEffectSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "entityStatusEffectSystem");
		NativeFieldInfoPtr_Instance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, "Instance");
		NativeMethodInfoPtr_PreAwake_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, 100665368);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SystemManager>.NativeClassPtr, 100665369);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 55640, RefRangeEnd = 55641, XrefRangeStart = 55615, XrefRangeEnd = 55640, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PreAwake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SystemManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SystemManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SystemManager(IntPtr pointer)
		: base(pointer)
	{
	}
}

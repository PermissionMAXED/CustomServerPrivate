using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class FootstepData : ScriptableObject
{
	[System.Serializable]
	public class FootstepType : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_audioClips;

		private static readonly System.IntPtr NativeFieldInfoPtr_vfxPrefab;

		private static readonly System.IntPtr NativeFieldInfoPtr_volumeMultiplier;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Il2CppReferenceArray<AudioClip> audioClips
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioClips);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AudioClip>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioClips)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe GameObject vfxPrefab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxPrefab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe float volumeMultiplier
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_volumeMultiplier);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_volumeMultiplier)) = num;
			}
		}

		static FootstepType()
		{
			Il2CppClassPointerStore<FootstepType>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "FootstepType");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FootstepType>.NativeClassPtr);
			NativeFieldInfoPtr_audioClips = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepType>.NativeClassPtr, "audioClips");
			NativeFieldInfoPtr_vfxPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepType>.NativeClassPtr, "vfxPrefab");
			NativeFieldInfoPtr_volumeMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepType>.NativeClassPtr, "volumeMultiplier");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FootstepType>.NativeClassPtr, 100683989);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224178, XrefRangeEnd = 224179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe FootstepType()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FootstepType>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public FootstepType(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_defaultSlipperyVfx;

	private static readonly System.IntPtr NativeFieldInfoPtr_grassFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_sandFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_snowFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_concreteFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_woodFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_bushFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_bushDesertFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_polishedTileFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_slipperyIceFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_freshCementFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_metalFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_dirtFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_rockFootstep;

	private static readonly System.IntPtr NativeFieldInfoPtr_bloodFootstep;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetFootstepTypeFromSurfaceId_Public_FootstepType_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DefaultFootstep_Public_FootstepType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe FootstepType defaultFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe GameObject defaultSlipperyVfx
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultSlipperyVfx);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultSlipperyVfx)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe FootstepType grassFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_grassFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_grassFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType sandFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sandFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sandFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType snowFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_snowFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_snowFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType concreteFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_concreteFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_concreteFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType woodFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_woodFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_woodFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType bushFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType bushDesertFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushDesertFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushDesertFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType polishedTileFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_polishedTileFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_polishedTileFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType slipperyIceFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slipperyIceFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slipperyIceFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType freshCementFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_freshCementFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_freshCementFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType metalFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_metalFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_metalFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType dirtFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dirtFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dirtFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType rockFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rockFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rockFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	public unsafe FootstepType bloodFootstep
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bloodFootstep);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bloodFootstep)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)footstepType));
		}
	}

	static FootstepData()
	{
		Il2CppClassPointerStore<FootstepData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "FootstepData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FootstepData>.NativeClassPtr);
		NativeFieldInfoPtr_defaultFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "defaultFootstep");
		NativeFieldInfoPtr_defaultSlipperyVfx = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "defaultSlipperyVfx");
		NativeFieldInfoPtr_grassFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "grassFootstep");
		NativeFieldInfoPtr_sandFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "sandFootstep");
		NativeFieldInfoPtr_snowFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "snowFootstep");
		NativeFieldInfoPtr_concreteFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "concreteFootstep");
		NativeFieldInfoPtr_woodFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "woodFootstep");
		NativeFieldInfoPtr_bushFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "bushFootstep");
		NativeFieldInfoPtr_bushDesertFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "bushDesertFootstep");
		NativeFieldInfoPtr_polishedTileFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "polishedTileFootstep");
		NativeFieldInfoPtr_slipperyIceFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "slipperyIceFootstep");
		NativeFieldInfoPtr_freshCementFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "freshCementFootstep");
		NativeFieldInfoPtr_metalFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "metalFootstep");
		NativeFieldInfoPtr_dirtFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "dirtFootstep");
		NativeFieldInfoPtr_rockFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "rockFootstep");
		NativeFieldInfoPtr_bloodFootstep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, "bloodFootstep");
		NativeMethodInfoPtr_GetFootstepTypeFromSurfaceId_Public_FootstepType_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, 100683986);
		NativeMethodInfoPtr_DefaultFootstep_Public_FootstepType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, 100683987);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FootstepData>.NativeClassPtr, 100683988);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 224179, RefRangeEnd = 224180, XrefRangeStart = 224179, XrefRangeEnd = 224179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FootstepType GetFootstepTypeFromSurfaceId(int surfaceId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&surfaceId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFootstepTypeFromSurfaceId_Public_FootstepType_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
	}

	[CallerCount(140)]
	[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FootstepType DefaultFootstep()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DefaultFootstep_Public_FootstepType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<FootstepType>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FootstepData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FootstepData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public FootstepData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Profanity;

public class ProfanityFilterConfiguration : ScriptableObject
{
	[System.Serializable]
	public class Configuration : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_json;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe TextAsset json
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_json);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TextAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_json)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)textAsset));
			}
		}

		static Configuration()
		{
			Il2CppClassPointerStore<Configuration>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "Configuration");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Configuration>.NativeClassPtr);
			NativeFieldInfoPtr_json = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "json");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Configuration>.NativeClassPtr, 100665426);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Configuration()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Configuration>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Configuration(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ProfanityFilterData : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_allowedWords;

		private static readonly System.IntPtr NativeFieldInfoPtr_censorWords;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Il2CppStringArray allowedWords
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowedWords);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowedWords)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe Il2CppStringArray censorWords
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_censorWords);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_censorWords)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		static ProfanityFilterData()
		{
			Il2CppClassPointerStore<ProfanityFilterData>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "ProfanityFilterData");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ProfanityFilterData>.NativeClassPtr);
			NativeFieldInfoPtr_allowedWords = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfanityFilterData>.NativeClassPtr, "allowedWords");
			NativeFieldInfoPtr_censorWords = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfanityFilterData>.NativeClassPtr, "censorWords");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfanityFilterData>.NativeClassPtr, 100665427);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ProfanityFilterData()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ProfanityFilterData>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ProfanityFilterData(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class SerialisationConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_keyPhraseDeliminator;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe string keyPhraseDeliminator
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keyPhraseDeliminator);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keyPhraseDeliminator)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static SerialisationConfig()
		{
			Il2CppClassPointerStore<SerialisationConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "SerialisationConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SerialisationConfig>.NativeClassPtr);
			NativeFieldInfoPtr_keyPhraseDeliminator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerialisationConfig>.NativeClassPtr, "keyPhraseDeliminator");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerialisationConfig>.NativeClassPtr, 100665428);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe SerialisationConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SerialisationConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public SerialisationConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class DebugConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_outputProfanityFilter;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe bool outputProfanityFilter
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outputProfanityFilter);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_outputProfanityFilter)) = flag;
			}
		}

		static DebugConfig()
		{
			Il2CppClassPointerStore<DebugConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "DebugConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DebugConfig>.NativeClassPtr);
			NativeFieldInfoPtr_outputProfanityFilter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugConfig>.NativeClassPtr, "outputProfanityFilter");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugConfig>.NativeClassPtr, 100665429);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe DebugConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DebugConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public DebugConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_c;

	private static readonly System.IntPtr NativeFieldInfoPtr_serialisation;

	private static readonly System.IntPtr NativeFieldInfoPtr_profanityFilter;

	private static readonly System.IntPtr NativeFieldInfoPtr_debug;

	private static readonly System.IntPtr NativeFieldInfoPtr_configuration;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetProfanityFilter_Public_ProfanityFilter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadFromConfig_Private_ProfanityFilter_Configuration_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Configuration c
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_c);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_c)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
		}
	}

	public unsafe SerialisationConfig serialisation
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serialisation);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SerialisationConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serialisation)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serialisationConfig));
		}
	}

	public unsafe ProfanityFilter profanityFilter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profanityFilter);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfanityFilter>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_profanityFilter)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)profanityFilter));
		}
	}

	public unsafe DebugConfig debug
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debug);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DebugConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debug)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugConfig));
		}
	}

	public unsafe ProfanityFilter.Configuration configuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfanityFilter.Configuration>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
		}
	}

	static ProfanityFilterConfiguration()
	{
		Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Profanity", "ProfanityFilterConfiguration");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr);
		NativeFieldInfoPtr_c = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "c");
		NativeFieldInfoPtr_serialisation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "serialisation");
		NativeFieldInfoPtr_profanityFilter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "profanityFilter");
		NativeFieldInfoPtr_debug = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "debug");
		NativeFieldInfoPtr_configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, "configuration");
		NativeMethodInfoPtr_GetProfanityFilter_Public_ProfanityFilter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, 100665423);
		NativeMethodInfoPtr_LoadFromConfig_Private_ProfanityFilter_Configuration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, 100665424);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr, 100665425);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 55997, RefRangeEnd = 55999, XrefRangeStart = 55996, XrefRangeEnd = 55997, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ProfanityFilter GetProfanityFilter()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetProfanityFilter_Public_ProfanityFilter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfanityFilter>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 56033, RefRangeEnd = 56034, XrefRangeStart = 55999, XrefRangeEnd = 56033, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ProfanityFilter LoadFromConfig(Configuration config)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadFromConfig_Private_ProfanityFilter_Configuration_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProfanityFilter>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ProfanityFilterConfiguration()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ProfanityFilterConfiguration>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ProfanityFilterConfiguration(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

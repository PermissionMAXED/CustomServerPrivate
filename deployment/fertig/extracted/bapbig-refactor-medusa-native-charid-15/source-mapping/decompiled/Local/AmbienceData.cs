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

public class AmbienceData : ScriptableObject
{
	[System.Serializable]
	public class AmbienceType : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_audioClip;

		private static readonly System.IntPtr NativeFieldInfoPtr_volumeMultiplier;

		private static readonly System.IntPtr NativeFieldInfoPtr_debugVisualizeColor;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe AudioClip audioClip
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioClip);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AudioClip>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioClip)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClip));
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

		public unsafe Color debugVisualizeColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugVisualizeColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugVisualizeColor)) = color;
			}
		}

		static AmbienceType()
		{
			Il2CppClassPointerStore<AmbienceType>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<AmbienceData>.NativeClassPtr, "AmbienceType");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AmbienceType>.NativeClassPtr);
			NativeFieldInfoPtr_audioClip = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AmbienceType>.NativeClassPtr, "audioClip");
			NativeFieldInfoPtr_volumeMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AmbienceType>.NativeClassPtr, "volumeMultiplier");
			NativeFieldInfoPtr_debugVisualizeColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AmbienceType>.NativeClassPtr, "debugVisualizeColor");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AmbienceType>.NativeClassPtr, 100683985);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224169, XrefRangeEnd = 224170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe AmbienceType()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AmbienceType>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public AmbienceType(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_ambiences;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Ambiences_Public_get_Il2CppReferenceArray_1_AmbienceType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAmbienceTypeById_Public_AmbienceType_AmbienceId_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<AmbienceType> ambiences
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambiences);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AmbienceType>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambiences)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<AmbienceType> Ambiences
	{
		[CallerCount(140)]
		[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Ambiences_Public_get_Il2CppReferenceArray_1_AmbienceType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<AmbienceType>>(intPtr) : null;
		}
	}

	static AmbienceData()
	{
		Il2CppClassPointerStore<AmbienceData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "AmbienceData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AmbienceData>.NativeClassPtr);
		NativeFieldInfoPtr_ambiences = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AmbienceData>.NativeClassPtr, "ambiences");
		NativeMethodInfoPtr_get_Ambiences_Public_get_Il2CppReferenceArray_1_AmbienceType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AmbienceData>.NativeClassPtr, 100683982);
		NativeMethodInfoPtr_GetAmbienceTypeById_Public_AmbienceType_AmbienceId_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AmbienceData>.NativeClassPtr, 100683983);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AmbienceData>.NativeClassPtr, 100683984);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 224170, RefRangeEnd = 224178, XrefRangeStart = 224170, XrefRangeEnd = 224170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AmbienceType GetAmbienceTypeById(AmbienceId ambienceId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&ambienceId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAmbienceTypeById_Public_AmbienceType_AmbienceId_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AmbienceType>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AmbienceData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AmbienceData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public AmbienceData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

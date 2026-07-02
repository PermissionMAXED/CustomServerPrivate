using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UIFadeDelayElement : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_alphaFade;

	private static readonly IntPtr NativeFieldInfoPtr_posLerpFade;

	private static readonly IntPtr NativeFieldInfoPtr_playSfxOnFade;

	private static readonly IntPtr NativeFieldInfoPtr_sfxData;

	private static readonly IntPtr NativeFieldInfoPtr_fadeInDelay;

	private static readonly IntPtr NativeFieldInfoPtr_fadeInDelayTime;

	private static readonly IntPtr NativeFieldInfoPtr_fadeInDelayDuration;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_FadeInDelay_Public_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe UIAlphaFade alphaFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UIAlphaFade>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alphaFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIAlphaFade));
		}
	}

	public unsafe UIPosLerpFade posLerpFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<UIPosLerpFade>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_posLerpFade)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIPosLerpFade));
		}
	}

	public unsafe bool playSfxOnFade
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playSfxOnFade);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playSfxOnFade)) = flag;
		}
	}

	public unsafe SFXData sfxData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxData);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<SFXData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sFXData));
		}
	}

	public unsafe bool fadeInDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fadeInDelay);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fadeInDelay)) = flag;
		}
	}

	public unsafe float fadeInDelayTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fadeInDelayTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fadeInDelayTime)) = num;
		}
	}

	public unsafe float fadeInDelayDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fadeInDelayDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fadeInDelayDuration)) = num;
		}
	}

	static UIFadeDelayElement()
	{
		Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UIFadeDelayElement");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr);
		NativeFieldInfoPtr_alphaFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, "alphaFade");
		NativeFieldInfoPtr_posLerpFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, "posLerpFade");
		NativeFieldInfoPtr_playSfxOnFade = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, "playSfxOnFade");
		NativeFieldInfoPtr_sfxData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, "sfxData");
		NativeFieldInfoPtr_fadeInDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, "fadeInDelay");
		NativeFieldInfoPtr_fadeInDelayTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, "fadeInDelayTime");
		NativeFieldInfoPtr_fadeInDelayDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, "fadeInDelayDuration");
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, 100671285);
		NativeMethodInfoPtr_FadeInDelay_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, 100671286);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr, 100671287);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 108726, XrefRangeEnd = 108732, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 108737, RefRangeEnd = 108747, XrefRangeStart = 108732, XrefRangeEnd = 108737, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FadeInDelay(float delay)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&delay);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FadeInDelay_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UIFadeDelayElement()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UIFadeDelayElement>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UIFadeDelayElement(IntPtr pointer)
		: base(pointer)
	{
	}
}

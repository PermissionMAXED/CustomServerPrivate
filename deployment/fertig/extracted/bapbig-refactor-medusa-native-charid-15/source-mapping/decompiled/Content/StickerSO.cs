using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Content;

public class StickerSO : EmoteSO
{
	private static readonly IntPtr NativeFieldInfoPtr_sticker;

	private static readonly IntPtr NativeMethodInfoPtr_get_content_Public_Virtual_get_Content_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_emote_Public_Virtual_get_Emote_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Sticker sticker
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sticker);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Sticker>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sticker)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sticker));
		}
	}

	public unsafe override Content content
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_content_Public_Virtual_get_Content_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Content>(intPtr) : null;
		}
	}

	public unsafe override Emote emote
	{
		[CallerCount(140)]
		[CachedScanResults(RefRangeStart = 23558, RefRangeEnd = 23698, XrefRangeStart = 23558, XrefRangeEnd = 23698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_emote_Public_Virtual_get_Emote_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Emote>(intPtr) : null;
		}
	}

	static StickerSO()
	{
		Il2CppClassPointerStore<StickerSO>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "StickerSO");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<StickerSO>.NativeClassPtr);
		NativeFieldInfoPtr_sticker = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StickerSO>.NativeClassPtr, "sticker");
		NativeMethodInfoPtr_get_content_Public_Virtual_get_Content_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StickerSO>.NativeClassPtr, 100682928);
		NativeMethodInfoPtr_get_emote_Public_Virtual_get_Emote_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StickerSO>.NativeClassPtr, 100682929);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<StickerSO>.NativeClassPtr, 100682930);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 45124, RefRangeEnd = 45125, XrefRangeStart = 45124, XrefRangeEnd = 45125, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe StickerSO()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<StickerSO>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public StickerSO(IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.AssetContainer;

public class TextureAssetContainer : AssetContainer<Texture2D>
{
	private static readonly IntPtr NativeMethodInfoPtr_OptimizeAsset_Public_Virtual_Texture2D_Texture2D_0;

	private static readonly IntPtr NativeMethodInfoPtr_ValidateAsset_Public_Virtual_Boolean_Texture2D_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	static TextureAssetContainer()
	{
		Il2CppClassPointerStore<TextureAssetContainer>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.AssetContainer", "TextureAssetContainer");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TextureAssetContainer>.NativeClassPtr);
		NativeMethodInfoPtr_OptimizeAsset_Public_Virtual_Texture2D_Texture2D_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TextureAssetContainer>.NativeClassPtr, 100683034);
		NativeMethodInfoPtr_ValidateAsset_Public_Virtual_Boolean_Texture2D_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TextureAssetContainer>.NativeClassPtr, 100683035);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TextureAssetContainer>.NativeClassPtr, 100683036);
	}

	[CallerCount(0)]
	public unsafe override Texture2D OptimizeAsset(Texture2D asset)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)asset);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OptimizeAsset_Public_Virtual_Texture2D_Texture2D_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool ValidateAsset(Texture2D asset)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)asset);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_ValidateAsset_Public_Virtual_Boolean_Texture2D_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 217258, XrefRangeEnd = 217260, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TextureAssetContainer()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TextureAssetContainer>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public TextureAssetContainer(IntPtr pointer)
		: base(pointer)
	{
	}
}

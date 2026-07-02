using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.Entities;

public class WaitForInputOverrideSubroutine : WaitForInputSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_checkForSilenced;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_InputType_CastFlags_InputSource_Byte_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_IsAbleToCast_Protected_Virtual_Boolean_CastFlags_0;

	public unsafe bool checkForSilenced
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForSilenced);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForSilenced)) = flag;
		}
	}

	static WaitForInputOverrideSubroutine()
	{
		Il2CppClassPointerStore<WaitForInputOverrideSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "WaitForInputOverrideSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<WaitForInputOverrideSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_checkForSilenced = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WaitForInputOverrideSubroutine>.NativeClassPtr, "checkForSilenced");
		NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_InputType_CastFlags_InputSource_Byte_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WaitForInputOverrideSubroutine>.NativeClassPtr, 100675145);
		NativeMethodInfoPtr_IsAbleToCast_Protected_Virtual_Boolean_CastFlags_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WaitForInputOverrideSubroutine>.NativeClassPtr, 100675146);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 158377, RefRangeEnd = 158384, XrefRangeStart = 158376, XrefRangeEnd = 158377, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe WaitForInputOverrideSubroutine(Ability ability, byte trigger, InputType inputType, CastFlags blockedCastFlags = CastFlags.Ability1 | CastFlags.Ability2 | CastFlags.Ability3 | CastFlags.Ability4, InputSource inputSource = InputSource.Any, byte buttonUpTrigger = 0, bool checkForSilenced = true)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<WaitForInputOverrideSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[7];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &trigger;
		*(InputType**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &inputType;
		*(CastFlags**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &blockedCastFlags;
		*(InputSource**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &inputSource;
		*(byte**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &buttonUpTrigger;
		*(bool**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = &checkForSilenced;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_InputType_CastFlags_InputSource_Byte_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 158393, RefRangeEnd = 158394, XrefRangeStart = 158384, XrefRangeEnd = 158393, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool IsAbleToCast(CastFlags blockedCastFlags)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&blockedCastFlags);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_IsAbleToCast_Protected_Virtual_Boolean_CastFlags_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public WaitForInputOverrideSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}

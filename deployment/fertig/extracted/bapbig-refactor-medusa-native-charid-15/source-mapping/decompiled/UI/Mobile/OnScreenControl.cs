using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppSystem;
using Il2CppSystem.Reflection;
using UnityEngine.InputSystem.OnScreen;

namespace Il2CppBAPBAP.UI.Mobile;

public class OnScreenControl : UnityEngine.InputSystem.OnScreen.OnScreenControl
{
	private sealed class MethodInfoStoreGeneric_SendValue_Public_Void_TValue_0<TValue>
	{
		internal static System.IntPtr Pointer = IL2CPP.il2cpp_method_get_from_reflection(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)new MethodInfo(IL2CPP.il2cpp_method_get_object(NativeMethodInfoPtr_SendValue_Public_Void_TValue_0, Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr)).MakeGenericMethod(new Il2CppReferenceArray<Il2CppSystem.Type>(new Il2CppSystem.Type[1] { Il2CppSystem.Type.internal_from_handle(IL2CPP.il2cpp_class_get_type(Il2CppClassPointerStore<TValue>.NativeClassPtr)) }))));
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__controlPathInternal_k__BackingField;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_controlPathInternal_Protected_Virtual_get_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_set_controlPathInternal_Protected_Virtual_set_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SendValue_Public_Void_TValue_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string _controlPathInternal_k__BackingField
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controlPathInternal_k__BackingField);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__controlPathInternal_k__BackingField)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe override string controlPathInternal
	{
		[CallerCount(15)]
		[CachedScanResults(RefRangeStart = 33209, RefRangeEnd = 33224, XrefRangeStart = 33209, XrefRangeEnd = 33224, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_controlPathInternal_Protected_Virtual_get_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		[CallerCount(14)]
		[CachedScanResults(RefRangeStart = 33224, RefRangeEnd = 33238, XrefRangeStart = 33224, XrefRangeEnd = 33238, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(value);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_set_controlPathInternal_Protected_Virtual_set_Void_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	static OnScreenControl()
	{
		Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI.Mobile", "OnScreenControl");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr);
		NativeFieldInfoPtr__controlPathInternal_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr, "<controlPathInternal>k__BackingField");
		NativeMethodInfoPtr_get_controlPathInternal_Protected_Virtual_get_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr, 100671748);
		NativeMethodInfoPtr_set_controlPathInternal_Protected_Virtual_set_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr, 100671749);
		NativeMethodInfoPtr_SendValue_Public_Void_TValue_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr, 100671750);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr, 100671751);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 111749, RefRangeEnd = 111756, XrefRangeStart = 111747, XrefRangeEnd = 111749, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SendValue<TValue>(TValue value) where TValue : new()
	{
		//IL_0061->IL0064: Incompatible stack types: I vs Ref
		//IL_0040->IL0064: Incompatible stack types: I vs Ref
		//IL_004d->IL0064: Incompatible stack types: I vs Ref
		//IL_0054->IL0064: Incompatible stack types: I vs Ref
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		ref TValue reference;
		if (!typeof(TValue).IsValueType)
		{
			object obj = value;
			if (obj is string)
			{
				reference = ref *(_003F*)IL2CPP.ManagedStringToIl2Cpp(obj as string);
			}
			else
			{
				System.IntPtr intPtr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)((obj is Il2CppObjectBase) ? obj : null));
				reference = ref *(_003F*)intPtr;
				if (intPtr != (System.IntPtr)0)
				{
					reference = ref *(_003F*)intPtr;
					if (IL2CPP.il2cpp_class_is_valuetype(IL2CPP.il2cpp_object_get_class(intPtr)))
					{
						reference = ref *(_003F*)IL2CPP.il2cpp_object_unbox(intPtr);
					}
				}
			}
		}
		else
		{
			reference = ref value;
		}
		*ptr = (nint)Unsafe.AsPointer(ref reference);
		Unsafe.SkipInit(out System.IntPtr intPtr3);
		System.IntPtr intPtr2 = IL2CPP.il2cpp_runtime_invoke(MethodInfoStoreGeneric_SendValue_Public_Void_TValue_0<TValue>.Pointer, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr3);
		Il2CppException.RaiseExceptionIfNecessary(intPtr3);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 31858, RefRangeEnd = 31860, XrefRangeStart = 31858, XrefRangeEnd = 31860, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe OnScreenControl()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<OnScreenControl>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public OnScreenControl(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

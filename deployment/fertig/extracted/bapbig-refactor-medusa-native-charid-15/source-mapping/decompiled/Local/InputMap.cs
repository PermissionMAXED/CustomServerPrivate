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

[System.Serializable]
public class InputMap : Il2CppSystem.Object
{
	[OriginalName("Assembly-CSharp.dll", "", "RebindInputResult")]
	public enum RebindInputResult
	{
		Available,
		AlreadyInUse,
		Invalid
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_inputs;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetInputByTarget_Public_InputBinding_InputTarget_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetInputByKey_Public_InputBinding_KeyCode_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRebindResult_Public_RebindInputResult_InputBinding_KeyCode_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RebindAction_Public_Void_InputBinding_KeyCode_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveAllBinds_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveBind_Public_Void_InputBinding_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadAllBinds_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadBind_Public_Void_InputBinding_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<InputBinding> inputs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputs);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<InputBinding>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static InputMap()
	{
		Il2CppClassPointerStore<InputMap>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "InputMap");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<InputMap>.NativeClassPtr);
		NativeFieldInfoPtr_inputs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputMap>.NativeClassPtr, "inputs");
		NativeMethodInfoPtr_GetInputByTarget_Public_InputBinding_InputTarget_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684139);
		NativeMethodInfoPtr_GetInputByKey_Public_InputBinding_KeyCode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684140);
		NativeMethodInfoPtr_GetRebindResult_Public_RebindInputResult_InputBinding_KeyCode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684141);
		NativeMethodInfoPtr_RebindAction_Public_Void_InputBinding_KeyCode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684142);
		NativeMethodInfoPtr_SaveAllBinds_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684143);
		NativeMethodInfoPtr_SaveBind_Public_Void_InputBinding_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684144);
		NativeMethodInfoPtr_LoadAllBinds_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684145);
		NativeMethodInfoPtr_LoadBind_Public_Void_InputBinding_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684146);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputMap>.NativeClassPtr, 100684147);
	}

	[CallerCount(39)]
	[CachedScanResults(RefRangeStart = 224999, RefRangeEnd = 225038, XrefRangeStart = 224996, XrefRangeEnd = 224999, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe InputBinding GetInputByTarget(InputTarget target)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&target);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetInputByTarget_Public_InputBinding_InputTarget_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225038, XrefRangeEnd = 225039, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe InputBinding GetInputByKey(KeyCode key)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&key);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetInputByKey_Public_InputBinding_KeyCode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 225040, RefRangeEnd = 225041, XrefRangeStart = 225039, XrefRangeEnd = 225040, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe RebindInputResult GetRebindResult(InputBinding toRebind, KeyCode newKey)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)toRebind);
		*(KeyCode**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &newKey;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRebindResult_Public_RebindInputResult_InputBinding_KeyCode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(RebindInputResult*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 225052, RefRangeEnd = 225053, XrefRangeStart = 225041, XrefRangeEnd = 225052, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RebindAction(InputBinding toRebind, KeyCode newKey)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)toRebind);
		*(KeyCode**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &newKey;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RebindAction_Public_Void_InputBinding_KeyCode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225053, XrefRangeEnd = 225058, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SaveAllBinds()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveAllBinds_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225058, XrefRangeEnd = 225062, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SaveBind(InputBinding inputBind, bool save = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBind);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &save;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveBind_Public_Void_InputBinding_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225062, XrefRangeEnd = 225066, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadAllBinds()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadAllBinds_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 225066, XrefRangeEnd = 225069, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void LoadBind(InputBinding inputBind)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBind);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadBind_Public_Void_InputBinding_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe InputMap()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<InputMap>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public InputMap(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

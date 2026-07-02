using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Local;

public static class GraphicsActionUtility : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_OnShaderKeywordChanged;

	private static readonly System.IntPtr NativeFieldInfoPtr_OnGlobalFloatChanged;

	private static readonly System.IntPtr NativeFieldInfoPtr_OnRenderScaleChanged;

	private static readonly System.IntPtr NativeMethodInfoPtr_add_OnShaderKeywordChanged_Public_Static_add_Void_Action_2_String_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_remove_OnShaderKeywordChanged_Public_Static_rem_Void_Action_2_String_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_add_OnGlobalFloatChanged_Public_Static_add_Void_Action_2_String_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_remove_OnGlobalFloatChanged_Public_Static_rem_Void_Action_2_String_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_add_OnRenderScaleChanged_Public_Static_add_Void_Action_1_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_remove_OnRenderScaleChanged_Public_Static_rem_Void_Action_1_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_EnableKeywordExt_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DisableKeywordExt_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetGlobalFloatExt_Public_Static_Void_String_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetRenderScale_Public_Static_Void_Single_0;

	public unsafe static Il2CppSystem.Action<string, bool> OnShaderKeywordChanged
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OnShaderKeywordChanged, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string, bool>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OnShaderKeywordChanged, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe static Il2CppSystem.Action<string, float> OnGlobalFloatChanged
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OnGlobalFloatChanged, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<string, float>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OnGlobalFloatChanged, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	public unsafe static Il2CppSystem.Action<float> OnRenderScaleChanged
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OnRenderScaleChanged, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<float>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OnRenderScaleChanged, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	static GraphicsActionUtility()
	{
		Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "GraphicsActionUtility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr);
		NativeFieldInfoPtr_OnShaderKeywordChanged = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, "OnShaderKeywordChanged");
		NativeFieldInfoPtr_OnGlobalFloatChanged = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, "OnGlobalFloatChanged");
		NativeFieldInfoPtr_OnRenderScaleChanged = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, "OnRenderScaleChanged");
		NativeMethodInfoPtr_add_OnShaderKeywordChanged_Public_Static_add_Void_Action_2_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685032);
		NativeMethodInfoPtr_remove_OnShaderKeywordChanged_Public_Static_rem_Void_Action_2_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685033);
		NativeMethodInfoPtr_add_OnGlobalFloatChanged_Public_Static_add_Void_Action_2_String_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685034);
		NativeMethodInfoPtr_remove_OnGlobalFloatChanged_Public_Static_rem_Void_Action_2_String_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685035);
		NativeMethodInfoPtr_add_OnRenderScaleChanged_Public_Static_add_Void_Action_1_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685036);
		NativeMethodInfoPtr_remove_OnRenderScaleChanged_Public_Static_rem_Void_Action_1_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685037);
		NativeMethodInfoPtr_EnableKeywordExt_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685038);
		NativeMethodInfoPtr_DisableKeywordExt_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685039);
		NativeMethodInfoPtr_SetGlobalFloatExt_Public_Static_Void_String_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685040);
		NativeMethodInfoPtr_SetRenderScale_Public_Static_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GraphicsActionUtility>.NativeClassPtr, 100685041);
	}

	[SpecialName]
	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 231992, RefRangeEnd = 231993, XrefRangeStart = 231986, XrefRangeEnd = 231992, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void add_OnShaderKeywordChanged(Il2CppSystem.Action<string, bool> value)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)value);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_add_OnShaderKeywordChanged_Public_Static_add_Void_Action_2_String_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[SpecialName]
	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 231999, RefRangeEnd = 232000, XrefRangeStart = 231993, XrefRangeEnd = 231999, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void remove_OnShaderKeywordChanged(Il2CppSystem.Action<string, bool> value)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)value);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_remove_OnShaderKeywordChanged_Public_Static_rem_Void_Action_2_String_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[SpecialName]
	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232000, XrefRangeEnd = 232006, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void add_OnGlobalFloatChanged(Il2CppSystem.Action<string, float> value)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)value);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_add_OnGlobalFloatChanged_Public_Static_add_Void_Action_2_String_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[SpecialName]
	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232006, XrefRangeEnd = 232012, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void remove_OnGlobalFloatChanged(Il2CppSystem.Action<string, float> value)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)value);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_remove_OnGlobalFloatChanged_Public_Static_rem_Void_Action_2_String_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[SpecialName]
	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232012, XrefRangeEnd = 232018, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void add_OnRenderScaleChanged(Il2CppSystem.Action<float> value)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)value);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_add_OnRenderScaleChanged_Public_Static_add_Void_Action_1_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[SpecialName]
	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232018, XrefRangeEnd = 232024, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void remove_OnRenderScaleChanged(Il2CppSystem.Action<float> value)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)value);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_remove_OnRenderScaleChanged_Public_Static_rem_Void_Action_1_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 232026, RefRangeEnd = 232028, XrefRangeStart = 232024, XrefRangeEnd = 232026, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void EnableKeywordExt(string keyword)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(keyword);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_EnableKeywordExt_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 232030, RefRangeEnd = 232031, XrefRangeStart = 232028, XrefRangeEnd = 232030, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void DisableKeywordExt(string keyword)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(keyword);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DisableKeywordExt_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232031, XrefRangeEnd = 232033, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetGlobalFloatExt(string keyword, float value)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(keyword);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &value;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetGlobalFloatExt_Public_Static_Void_String_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 232037, RefRangeEnd = 232038, XrefRangeStart = 232033, XrefRangeEnd = 232037, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetRenderScale(float renderScale)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&renderScale);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetRenderScale_Public_Static_Void_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public GraphicsActionUtility(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Reflection;
using UnityEngine;

namespace Il2CppBAPBAP.AssetContainer;

public static class Utils : Il2CppSystem.Object
{
	private sealed class MethodInfoStoreGeneric_GetContainer_Public_Static_AssetContainer_1_T_T_Owner_String_0<T>
	{
		internal static System.IntPtr Pointer = IL2CPP.il2cpp_method_get_from_reflection(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)new MethodInfo(IL2CPP.il2cpp_method_get_object(NativeMethodInfoPtr_GetContainer_Public_Static_AssetContainer_1_T_T_Owner_String_0, Il2CppClassPointerStore<Utils>.NativeClassPtr)).MakeGenericMethod(new Il2CppReferenceArray<Il2CppSystem.Type>(new Il2CppSystem.Type[1] { Il2CppSystem.Type.internal_from_handle(IL2CPP.il2cpp_class_get_type(Il2CppClassPointerStore<T>.NativeClassPtr)) }))));
	}

	private sealed class MethodInfoStoreGeneric_CreateNewContainer_Private_Static_AssetContainer_1_T_String_Owner_0<T>
	{
		internal static System.IntPtr Pointer = IL2CPP.il2cpp_method_get_from_reflection(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)new MethodInfo(IL2CPP.il2cpp_method_get_object(NativeMethodInfoPtr_CreateNewContainer_Private_Static_AssetContainer_1_T_String_Owner_0, Il2CppClassPointerStore<Utils>.NativeClassPtr)).MakeGenericMethod(new Il2CppReferenceArray<Il2CppSystem.Type>(new Il2CppSystem.Type[1] { Il2CppSystem.Type.internal_from_handle(IL2CPP.il2cpp_class_get_type(Il2CppClassPointerStore<T>.NativeClassPtr)) }))));
	}

	private static readonly System.IntPtr NativeMethodInfoPtr_GetOwner_Public_Static_Owner_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetContainer_Public_Static_AssetContainer_1_T_T_Owner_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateNewContainer_Private_Static_AssetContainer_1_T_String_Owner_0;

	static Utils()
	{
		Il2CppClassPointerStore<Utils>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.AssetContainer", "Utils");
		NativeMethodInfoPtr_GetOwner_Public_Static_Owner_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Utils>.NativeClassPtr, 100683038);
		NativeMethodInfoPtr_GetContainer_Public_Static_AssetContainer_1_T_T_Owner_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Utils>.NativeClassPtr, 100683039);
		NativeMethodInfoPtr_CreateNewContainer_Private_Static_AssetContainer_1_T_String_Owner_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Utils>.NativeClassPtr, 100683040);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 217263, RefRangeEnd = 217264, XrefRangeStart = 217260, XrefRangeEnd = 217263, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Owner GetOwner(GameObject gameObject)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetOwner_Public_Static_Owner_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Owner>(intPtr) : null;
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static AssetContainer<T> GetContainer<T>(T @object, Owner owner, string overridePath = null) where T : UnityEngine.Object
	{
		//IL_005a->IL005d: Incompatible stack types: I vs Ref
		//IL_0039->IL005d: Incompatible stack types: I vs Ref
		//IL_0046->IL005d: Incompatible stack types: I vs Ref
		//IL_004d->IL005d: Incompatible stack types: I vs Ref
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		ref T reference;
		if (!typeof(T).IsValueType)
		{
			T val = @object;
			if (val is string)
			{
				reference = ref *(_003F*)IL2CPP.ManagedStringToIl2Cpp(val as string);
			}
			else
			{
				System.IntPtr intPtr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)((val is Il2CppObjectBase) ? val : null));
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
			reference = ref @object;
		}
		*ptr = (nint)Unsafe.AsPointer(ref reference);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)owner);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(overridePath);
		Unsafe.SkipInit(out System.IntPtr intPtr3);
		System.IntPtr intPtr2 = IL2CPP.il2cpp_runtime_invoke(MethodInfoStoreGeneric_GetContainer_Public_Static_AssetContainer_1_T_T_Owner_String_0<T>.Pointer, (System.IntPtr)0, (void**)ptr, ref intPtr3);
		Il2CppException.RaiseExceptionIfNecessary(intPtr3);
		return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetContainer<T>>(intPtr2) : null;
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static AssetContainer<T> CreateNewContainer<T>(string containerPath, Owner owner) where T : UnityEngine.Object
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(containerPath);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)owner);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(MethodInfoStoreGeneric_CreateNewContainer_Private_Static_AssetContainer_1_T_String_Owner_0<T>.Pointer, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetContainer<T>>(intPtr) : null;
	}

	public Utils(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

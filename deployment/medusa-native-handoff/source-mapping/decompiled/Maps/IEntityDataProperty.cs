using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public class IEntityDataProperty : Il2CppObjectBase
{
	private static readonly IntPtr NativeMethodInfoPtr_PropertyName_Public_Virtual_New_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetPropertyFields_Public_Abstract_Virtual_New_Il2CppReferenceArray_1_Field_0;

	private static readonly IntPtr NativeMethodInfoPtr_CopyProperties_Public_Abstract_Virtual_New_Void_IEntityDataProperty_0;

	private static readonly IntPtr NativeMethodInfoPtr_AssignSpawnedReferences_Public_Virtual_New_Void_Dictionary_2_Int32_GameObject_0;

	static IEntityDataProperty()
	{
		Il2CppClassPointerStore<IEntityDataProperty>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "IEntityDataProperty");
		NativeMethodInfoPtr_PropertyName_Public_Virtual_New_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IEntityDataProperty>.NativeClassPtr, 100685849);
		NativeMethodInfoPtr_GetPropertyFields_Public_Abstract_Virtual_New_Il2CppReferenceArray_1_Field_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IEntityDataProperty>.NativeClassPtr, 100685850);
		NativeMethodInfoPtr_CopyProperties_Public_Abstract_Virtual_New_Void_IEntityDataProperty_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IEntityDataProperty>.NativeClassPtr, 100685851);
		NativeMethodInfoPtr_AssignSpawnedReferences_Public_Virtual_New_Void_Dictionary_2_Int32_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IEntityDataProperty>.NativeClassPtr, 100685852);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242954, XrefRangeEnd = 242955, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual string PropertyName()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_PropertyName_Public_Virtual_New_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	public unsafe virtual Il2CppReferenceArray<MapEntityData.Property.Field> GetPropertyFields()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetPropertyFields_Public_Abstract_Virtual_New_Il2CppReferenceArray_1_Field_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<MapEntityData.Property.Field>>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe virtual void CopyProperties(IEntityDataProperty source)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)source);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_CopyProperties_Public_Abstract_Virtual_New_Void_IEntityDataProperty_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void AssignSpawnedReferences(Dictionary<int, GameObject> spawnedEntitiesByInstanceId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnedEntitiesByInstanceId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_AssignSpawnedReferences_Public_Virtual_New_Void_Dictionary_2_Int32_GameObject_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public IEntityDataProperty(IntPtr pointer)
		: base(pointer)
	{
	}
}

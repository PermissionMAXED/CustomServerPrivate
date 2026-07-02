using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local.Rendering;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.IO;
using UnityEngine;
using UnityEngine.AI;

namespace Il2CppBAPBAP.Maps;

public static class MapIOUtility : Il2CppSystem.Object
{
	[System.Serializable]
	[ObfuscatedName("BAPBAP.Maps.MapIOUtility+<>c")]
	public sealed class __c : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___9;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__16_0;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__16_1;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__16_2;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__16_3;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__16_4;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_0_Internal_DateTime_FileInfo_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_1_Internal_String_FileInfo_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_2_Internal_String_FileInfo_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_3_Internal_DateTime_FileInfo_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_4_Internal_DateTime_FileInfo_0;

		public unsafe static __c __9
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c));
			}
		}

		public unsafe static Il2CppSystem.Func<FileInfo, Il2CppSystem.DateTime> __9__16_0
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__16_0, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<FileInfo, Il2CppSystem.DateTime>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__16_0, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		public unsafe static Il2CppSystem.Func<FileInfo, string> __9__16_1
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__16_1, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<FileInfo, string>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__16_1, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		public unsafe static Il2CppSystem.Func<FileInfo, string> __9__16_2
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__16_2, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<FileInfo, string>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__16_2, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		public unsafe static Il2CppSystem.Func<FileInfo, Il2CppSystem.DateTime> __9__16_3
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__16_3, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<FileInfo, Il2CppSystem.DateTime>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__16_3, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		public unsafe static Il2CppSystem.Func<FileInfo, Il2CppSystem.DateTime> __9__16_4
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__16_4, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Func<FileInfo, Il2CppSystem.DateTime>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__16_4, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)func));
			}
		}

		static __c()
		{
			Il2CppClassPointerStore<__c>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "<>c");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c>.NativeClassPtr);
			NativeFieldInfoPtr___9 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9");
			NativeFieldInfoPtr___9__16_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__16_0");
			NativeFieldInfoPtr___9__16_1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__16_1");
			NativeFieldInfoPtr___9__16_2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__16_2");
			NativeFieldInfoPtr___9__16_3 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__16_3");
			NativeFieldInfoPtr___9__16_4 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__16_4");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685843);
			NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_0_Internal_DateTime_FileInfo_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685844);
			NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_1_Internal_String_FileInfo_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685845);
			NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_2_Internal_String_FileInfo_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685846);
			NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_3_Internal_DateTime_FileInfo_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685847);
			NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_4_Internal_DateTime_FileInfo_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100685848);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242578, XrefRangeEnd = 242579, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Il2CppSystem.DateTime _GetAllMapNamesInPath_b__16_0(FileInfo fileInfo)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)fileInfo);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_0_Internal_DateTime_FileInfo_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Il2CppSystem.DateTime*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242579, XrefRangeEnd = 242582, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe string _GetAllMapNamesInPath_b__16_1(FileInfo s)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)s);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_1_Internal_String_FileInfo_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		[CallerCount(0)]
		public unsafe string _GetAllMapNamesInPath_b__16_2(FileInfo s)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)s);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_2_Internal_String_FileInfo_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Il2CppSystem.DateTime _GetAllMapNamesInPath_b__16_3(FileInfo fileInfo)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)fileInfo);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_3_Internal_DateTime_FileInfo_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Il2CppSystem.DateTime*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242582, XrefRangeEnd = 242583, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Il2CppSystem.DateTime _GetAllMapNamesInPath_b__16_4(FileInfo fileInfo)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)fileInfo);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__GetAllMapNamesInPath_b__16_4_Internal_DateTime_FileInfo_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Il2CppSystem.DateTime*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_PATH_TO_LEVELS;

	private static readonly System.IntPtr NativeFieldInfoPtr_PATH_TO_LEVELS_MAPS;

	private static readonly System.IntPtr NativeFieldInfoPtr_PATH_TO_LEVELS_MODULES;

	private static readonly System.IntPtr NativeFieldInfoPtr_RELATIVE_PATH_TO_POI;

	private static readonly System.IntPtr NativeFieldInfoPtr_RELATIVE_PATH_TO_LANDMARK;

	private static readonly System.IntPtr NativeFieldInfoPtr_RELATIVE_PATH_TO_REVIVE;

	private static readonly System.IntPtr NativeFieldInfoPtr_RELATIVE_PATH_TO_GENERIC;

	private static readonly System.IntPtr NativeFieldInfoPtr__Char;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetModulePathByModuleType_Public_Static_String_ModuleCategory_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllModulesInAllBiomes_Public_Static_Il2CppReferenceArray_1_ModuleTypeList_BiomeData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllModulesInBiomes_Public_Static_Il2CppReferenceArray_1_ModuleTypeList_Il2CppStringArray_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllModuleTypesInBiome_Public_Static_ModuleTypeList_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetModuleNameFromModuleFilename_Public_Static_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildModuleFilenameString_Public_Static_String_Vector2Int_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildMapFilenameString_Public_Static_String_Vector2Int_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllModulesInPath_Private_Static_Il2CppStringArray_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllMapNamesInPath_Private_Static_Il2CppStringArray_String_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllPrefabLevelPathsInPath_Public_Static_Il2CppStringArray_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllPrebakedLevelNamesInPath_Public_Static_Il2CppStringArray_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllModulesByPathInAllBiomes_Public_Static_Il2CppReferenceArray_1_Dictionary_2_String_List_1_String_BiomeData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllModuleNamesByPathInAllBiomesCombined_Public_Static_List_1_Il2CppStringArray_BiomeData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllModulesByPathInBiome_Public_Static_Dictionary_2_String_List_1_String_String_ModuleTypeList_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DeleteLevelFile_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadLevelSvDataPrefab_Public_Static_GameObject_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveLevelSvDataPrefab_Public_Static_Void_GameObject_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadLevelClDataPrefab_Public_Static_GameObject_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveLevelClDataPrefab_Public_Static_Void_GameObject_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadLevelMMCache_Public_Static_LevelMMCacheData_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveLevelMMCache_Public_Static_Void_LevelMMCache_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadNavData_Public_Static_NavMeshData_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveNavData_Public_Static_Void_NavMeshData_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadInstanceData_Public_Static_MeshInstanceData_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveInstanceData_Public_Static_MeshInstanceData_List_1_DefinitionPositions_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveInstanceData_Public_Static_MeshInstanceData_MeshInstanceData_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadSplatMapData_Public_Static_SplatMapData_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveSplatMapData_Public_Static_SplatMapData_Texture2D_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadMapScreenshot_Public_Static_Sprite_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SaveMapScreenshot_Public_Static_Void_Texture2D_String_0;

	public unsafe static string PATH_TO_LEVELS
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PATH_TO_LEVELS, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PATH_TO_LEVELS, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string PATH_TO_LEVELS_MAPS
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PATH_TO_LEVELS_MAPS, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PATH_TO_LEVELS_MAPS, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string PATH_TO_LEVELS_MODULES
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PATH_TO_LEVELS_MODULES, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PATH_TO_LEVELS_MODULES, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string RELATIVE_PATH_TO_POI
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_POI, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_POI, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string RELATIVE_PATH_TO_LANDMARK
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_LANDMARK, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_LANDMARK, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string RELATIVE_PATH_TO_REVIVE
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_REVIVE, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_REVIVE, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string RELATIVE_PATH_TO_GENERIC
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_GENERIC, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RELATIVE_PATH_TO_GENERIC, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static char _Char
	{
		get
		{
			Unsafe.SkipInit(out char result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__Char, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__Char, (void*)(&c));
		}
	}

	static MapIOUtility()
	{
		Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "MapIOUtility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr);
		NativeFieldInfoPtr_PATH_TO_LEVELS = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "PATH_TO_LEVELS");
		NativeFieldInfoPtr_PATH_TO_LEVELS_MAPS = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "PATH_TO_LEVELS_MAPS");
		NativeFieldInfoPtr_PATH_TO_LEVELS_MODULES = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "PATH_TO_LEVELS_MODULES");
		NativeFieldInfoPtr_RELATIVE_PATH_TO_POI = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "RELATIVE_PATH_TO_POI");
		NativeFieldInfoPtr_RELATIVE_PATH_TO_LANDMARK = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "RELATIVE_PATH_TO_LANDMARK");
		NativeFieldInfoPtr_RELATIVE_PATH_TO_REVIVE = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "RELATIVE_PATH_TO_REVIVE");
		NativeFieldInfoPtr_RELATIVE_PATH_TO_GENERIC = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "RELATIVE_PATH_TO_GENERIC");
		NativeFieldInfoPtr__Char = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, "_Char");
		NativeMethodInfoPtr_GetModulePathByModuleType_Public_Static_String_ModuleCategory_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685811);
		NativeMethodInfoPtr_GetAllModulesInAllBiomes_Public_Static_Il2CppReferenceArray_1_ModuleTypeList_BiomeData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685812);
		NativeMethodInfoPtr_GetAllModulesInBiomes_Public_Static_Il2CppReferenceArray_1_ModuleTypeList_Il2CppStringArray_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685813);
		NativeMethodInfoPtr_GetAllModuleTypesInBiome_Public_Static_ModuleTypeList_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685814);
		NativeMethodInfoPtr_GetModuleNameFromModuleFilename_Public_Static_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685815);
		NativeMethodInfoPtr_BuildModuleFilenameString_Public_Static_String_Vector2Int_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685816);
		NativeMethodInfoPtr_BuildMapFilenameString_Public_Static_String_Vector2Int_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685817);
		NativeMethodInfoPtr_GetAllModulesInPath_Private_Static_Il2CppStringArray_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685818);
		NativeMethodInfoPtr_GetAllMapNamesInPath_Private_Static_Il2CppStringArray_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685819);
		NativeMethodInfoPtr_GetAllPrefabLevelPathsInPath_Public_Static_Il2CppStringArray_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685820);
		NativeMethodInfoPtr_GetAllPrebakedLevelNamesInPath_Public_Static_Il2CppStringArray_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685821);
		NativeMethodInfoPtr_GetAllModulesByPathInAllBiomes_Public_Static_Il2CppReferenceArray_1_Dictionary_2_String_List_1_String_BiomeData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685822);
		NativeMethodInfoPtr_GetAllModuleNamesByPathInAllBiomesCombined_Public_Static_List_1_Il2CppStringArray_BiomeData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685823);
		NativeMethodInfoPtr_GetAllModulesByPathInBiome_Public_Static_Dictionary_2_String_List_1_String_String_ModuleTypeList_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685824);
		NativeMethodInfoPtr_DeleteLevelFile_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685825);
		NativeMethodInfoPtr_LoadLevelSvDataPrefab_Public_Static_GameObject_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685826);
		NativeMethodInfoPtr_SaveLevelSvDataPrefab_Public_Static_Void_GameObject_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685827);
		NativeMethodInfoPtr_LoadLevelClDataPrefab_Public_Static_GameObject_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685828);
		NativeMethodInfoPtr_SaveLevelClDataPrefab_Public_Static_Void_GameObject_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685829);
		NativeMethodInfoPtr_LoadLevelMMCache_Public_Static_LevelMMCacheData_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685830);
		NativeMethodInfoPtr_SaveLevelMMCache_Public_Static_Void_LevelMMCache_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685831);
		NativeMethodInfoPtr_LoadNavData_Public_Static_NavMeshData_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685832);
		NativeMethodInfoPtr_SaveNavData_Public_Static_Void_NavMeshData_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685833);
		NativeMethodInfoPtr_LoadInstanceData_Public_Static_MeshInstanceData_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685834);
		NativeMethodInfoPtr_SaveInstanceData_Public_Static_MeshInstanceData_List_1_DefinitionPositions_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685835);
		NativeMethodInfoPtr_SaveInstanceData_Public_Static_MeshInstanceData_MeshInstanceData_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685836);
		NativeMethodInfoPtr_LoadSplatMapData_Public_Static_SplatMapData_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685837);
		NativeMethodInfoPtr_SaveSplatMapData_Public_Static_SplatMapData_Texture2D_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685838);
		NativeMethodInfoPtr_LoadMapScreenshot_Public_Static_Sprite_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685839);
		NativeMethodInfoPtr_SaveMapScreenshot_Public_Static_Void_Texture2D_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapIOUtility>.NativeClassPtr, 100685840);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242588, RefRangeEnd = 242590, XrefRangeStart = 242583, XrefRangeEnd = 242588, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string GetModulePathByModuleType(ModuleCategory moduleCategory)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&moduleCategory);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModulePathByModuleType_Public_Static_String_ModuleCategory_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242590, XrefRangeEnd = 242596, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<ModuleTypeList> GetAllModulesInAllBiomes(BiomeData biomeData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllModulesInAllBiomes_Public_Static_Il2CppReferenceArray_1_ModuleTypeList_BiomeData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ModuleTypeList>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242596, XrefRangeEnd = 242602, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<ModuleTypeList> GetAllModulesInBiomes(Il2CppStringArray biomeNames)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeNames);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllModulesInBiomes_Public_Static_Il2CppReferenceArray_1_ModuleTypeList_Il2CppStringArray_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ModuleTypeList>>(intPtr) : null;
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 242655, RefRangeEnd = 242660, XrefRangeStart = 242602, XrefRangeEnd = 242655, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static ModuleTypeList GetAllModuleTypesInBiome(string biomeName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(biomeName);
		Unsafe.SkipInit(out System.IntPtr intPtr);
		System.IntPtr pointer = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllModuleTypesInBiome_Public_Static_ModuleTypeList_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr);
		Il2CppException.RaiseExceptionIfNecessary(intPtr);
		return new ModuleTypeList(pointer);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 242668, RefRangeEnd = 242671, XrefRangeStart = 242660, XrefRangeEnd = 242668, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string GetModuleNameFromModuleFilename(string filename)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(filename);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModuleNameFromModuleFilename_Public_Static_String_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242682, RefRangeEnd = 242683, XrefRangeStart = 242671, XrefRangeEnd = 242682, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string BuildModuleFilenameString(Vector2Int size, string selectedBiome, string modName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&size);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(selectedBiome);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(modName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildModuleFilenameString_Public_Static_String_Vector2Int_String_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242683, XrefRangeEnd = 242688, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string BuildMapFilenameString(Vector2Int size, string mapName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&size);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(mapName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildMapFilenameString_Public_Static_String_Vector2Int_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 242698, RefRangeEnd = 242703, XrefRangeStart = 242688, XrefRangeEnd = 242698, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStringArray GetAllModulesInPath(string path)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(path);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllModulesInPath_Private_Static_Il2CppStringArray_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242703, XrefRangeEnd = 242761, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStringArray GetAllMapNamesInPath(string path, bool isModulePath = false)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(path);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isModulePath;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllMapNamesInPath_Private_Static_Il2CppStringArray_String_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242761, XrefRangeEnd = 242784, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStringArray GetAllPrefabLevelPathsInPath(string path, string extension)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(path);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(extension);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllPrefabLevelPathsInPath_Public_Static_Il2CppStringArray_String_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242784, XrefRangeEnd = 242795, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStringArray GetAllPrebakedLevelNamesInPath(string path)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(path);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllPrebakedLevelNamesInPath_Public_Static_Il2CppStringArray_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242795, XrefRangeEnd = 242803, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<Dictionary<string, List<string>>> GetAllModulesByPathInAllBiomes(BiomeData biomeData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllModulesByPathInAllBiomes_Public_Static_Il2CppReferenceArray_1_Dictionary_2_String_List_1_String_BiomeData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Dictionary<string, List<string>>>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242803, XrefRangeEnd = 242835, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<Il2CppStringArray> GetAllModuleNamesByPathInAllBiomesCombined(BiomeData biomeData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllModuleNamesByPathInAllBiomesCombined_Public_Static_List_1_Il2CppStringArray_BiomeData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Il2CppStringArray>>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 242873, RefRangeEnd = 242876, XrefRangeStart = 242835, XrefRangeEnd = 242873, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Dictionary<string, List<string>> GetAllModulesByPathInBiome(string biomeName, ModuleTypeList moduleList)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(biomeName);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)moduleList));
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllModulesByPathInBiome_Public_Static_Dictionary_2_String_List_1_String_String_ModuleTypeList_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<string, List<string>>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242876, XrefRangeEnd = 242888, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void DeleteLevelFile(string path)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(path);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DeleteLevelFile_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242888, XrefRangeEnd = 242896, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject LoadLevelSvDataPrefab(string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadLevelSvDataPrefab_Public_Static_GameObject_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SaveLevelSvDataPrefab(GameObject gameObject, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveLevelSvDataPrefab_Public_Static_Void_GameObject_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242896, XrefRangeEnd = 242904, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject LoadLevelClDataPrefab(string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadLevelClDataPrefab_Public_Static_GameObject_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SaveLevelClDataPrefab(GameObject gameObject, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveLevelClDataPrefab_Public_Static_Void_GameObject_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242912, RefRangeEnd = 242913, XrefRangeStart = 242904, XrefRangeEnd = 242912, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static LevelMMCacheData LoadLevelMMCache(string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadLevelMMCache_Public_Static_LevelMMCacheData_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelMMCacheData>(intPtr) : null;
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SaveLevelMMCache(LevelMMCache levelMMCache, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelMMCache);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveLevelMMCache_Public_Static_Void_LevelMMCache_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 242921, RefRangeEnd = 242924, XrefRangeStart = 242913, XrefRangeEnd = 242921, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static NavMeshData LoadNavData(string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadNavData_Public_Static_NavMeshData_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NavMeshData>(intPtr) : null;
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SaveNavData(NavMeshData navData, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)navData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveNavData_Public_Static_Void_NavMeshData_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242932, RefRangeEnd = 242934, XrefRangeStart = 242924, XrefRangeEnd = 242932, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static MeshInstanceData LoadInstanceData(string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadInstanceData_Public_Static_MeshInstanceData_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshInstanceData>(intPtr) : null;
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static MeshInstanceData SaveInstanceData(List<MeshInstanceRenderer.DefinitionPositions> definitionDatas, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)definitionDatas);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveInstanceData_Public_Static_MeshInstanceData_List_1_DefinitionPositions_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshInstanceData>(intPtr) : null;
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static MeshInstanceData SaveInstanceData(MeshInstanceData instanceData, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instanceData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveInstanceData_Public_Static_MeshInstanceData_MeshInstanceData_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MeshInstanceData>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242934, XrefRangeEnd = 242942, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static SplatMapData LoadSplatMapData(string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadSplatMapData_Public_Static_SplatMapData_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SplatMapData>(intPtr) : null;
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static SplatMapData SaveSplatMapData(Texture2D splatMap, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)splatMap);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveSplatMapData_Public_Static_SplatMapData_Texture2D_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SplatMapData>(intPtr) : null;
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 242950, RefRangeEnd = 242954, XrefRangeStart = 242942, XrefRangeEnd = 242950, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Sprite LoadMapScreenshot(string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadMapScreenshot_Public_Static_Sprite_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SaveMapScreenshot(Texture2D screenshot, string levelFileName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)screenshot);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(levelFileName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SaveMapScreenshot_Public_Static_Void_Texture2D_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MapIOUtility(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

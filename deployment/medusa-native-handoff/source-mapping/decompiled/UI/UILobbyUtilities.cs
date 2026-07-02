using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Content;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Localisation;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Il2CppBAPBAP.UI;

public static class UILobbyUtilities : Il2CppSystem.Object
{
	[System.Serializable]
	[ObfuscatedName("BAPBAP.UI.UILobbyUtilities+<>c")]
	public sealed class __c : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr___9;

		private static readonly System.IntPtr NativeFieldInfoPtr___9__1_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__GetOwnedGroupContentAssetIds_b__1_0_Internal_Int32_ContentSO_ContentSO_0;

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

		public unsafe static Il2CppSystem.Comparison<ContentSO> __9__1_0
		{
			get
			{
				Unsafe.SkipInit(out System.IntPtr intPtr);
				IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr___9__1_0, (void*)(&intPtr));
				System.IntPtr intPtr2 = intPtr;
				return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Comparison<ContentSO>>(intPtr2) : null;
			}
			set
			{
				IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr___9__1_0, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)comparison));
			}
		}

		static __c()
		{
			Il2CppClassPointerStore<__c>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, "<>c");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c>.NativeClassPtr);
			NativeFieldInfoPtr___9 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9");
			NativeFieldInfoPtr___9__1_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c>.NativeClassPtr, "<>9__1_0");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100670362);
			NativeMethodInfoPtr__GetOwnedGroupContentAssetIds_b__1_0_Internal_Int32_ContentSO_ContentSO_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c>.NativeClassPtr, 100670363);
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
		public unsafe int _GetOwnedGroupContentAssetIds_b__1_0(ContentSO x, ContentSO y)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)y);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__GetOwnedGroupContentAssetIds_b__1_0_Internal_Int32_ContentSO_ContentSO_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_notifSeparator;

	private static readonly System.IntPtr NativeMethodInfoPtr_OpenEquipContentPage_Public_Static_Void_Content_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetOwnedGroupContentAssetIds_Public_Static_List_1_Int32_Content_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_FillContentData_Public_Static_Void_ContentConfiguration_Translator_Content_TMP_Text_TMP_Text_TMP_Text_TMP_Text_UIContentRarityStars_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetContentTitle_Public_Static_String_Translator_Content_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisualizeContentInPanel_Public_Static_Void_Content_Image_Single_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnImageContentVisualizer_Private_Static_Void_Content_RectTransform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DestroySpawnedVisualizers_Public_Static_Void_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Set3DVisualizerContent_Private_Static_Void_Content_Transform_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SerializeAndSaveAllNotifications_Public_Static_Void_String_Il2CppStructArray_1_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UnserializeAllSavedNotifications_Public_Static_Il2CppStructArray_1_Int32_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddSaveSerializeNotification_Public_Static_Void_String_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DeleteSavedSerializeNotification_Public_Static_Void_String_Int32_0;

	public unsafe static string notifSeparator
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_notifSeparator, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_notifSeparator, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static UILobbyUtilities()
	{
		Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UILobbyUtilities");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr);
		NativeFieldInfoPtr_notifSeparator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, "notifSeparator");
		NativeMethodInfoPtr_OpenEquipContentPage_Public_Static_Void_Content_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670349);
		NativeMethodInfoPtr_GetOwnedGroupContentAssetIds_Public_Static_List_1_Int32_Content_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670350);
		NativeMethodInfoPtr_FillContentData_Public_Static_Void_ContentConfiguration_Translator_Content_TMP_Text_TMP_Text_TMP_Text_TMP_Text_UIContentRarityStars_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670351);
		NativeMethodInfoPtr_GetContentTitle_Public_Static_String_Translator_Content_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670352);
		NativeMethodInfoPtr_VisualizeContentInPanel_Public_Static_Void_Content_Image_Single_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670353);
		NativeMethodInfoPtr_SpawnImageContentVisualizer_Private_Static_Void_Content_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670354);
		NativeMethodInfoPtr_DestroySpawnedVisualizers_Public_Static_Void_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670355);
		NativeMethodInfoPtr_Set3DVisualizerContent_Private_Static_Void_Content_Transform_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670356);
		NativeMethodInfoPtr_SerializeAndSaveAllNotifications_Public_Static_Void_String_Il2CppStructArray_1_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670357);
		NativeMethodInfoPtr_UnserializeAllSavedNotifications_Public_Static_Il2CppStructArray_1_Int32_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670358);
		NativeMethodInfoPtr_AddSaveSerializeNotification_Public_Static_Void_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670359);
		NativeMethodInfoPtr_DeleteSavedSerializeNotification_Public_Static_Void_String_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyUtilities>.NativeClassPtr, 100670360);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 101023, RefRangeEnd = 101027, XrefRangeStart = 101006, XrefRangeEnd = 101023, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void OpenEquipContentPage(Il2CppBAPBAP.Content.Content content)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OpenEquipContentPage_Public_Static_Void_Content_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 101081, RefRangeEnd = 101082, XrefRangeStart = 101027, XrefRangeEnd = 101081, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<int> GetOwnedGroupContentAssetIds(Il2CppBAPBAP.Content.Content content)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetOwnedGroupContentAssetIds_Public_Static_List_1_Int32_Content_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<int>>(intPtr) : null;
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 101106, RefRangeEnd = 101114, XrefRangeStart = 101082, XrefRangeEnd = 101106, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void FillContentData(ContentConfiguration contentConfig, Translator translator, Il2CppBAPBAP.Content.Content content, TMP_Text collectionText, TMP_Text titleText, TMP_Text descText, TMP_Text tierRarityText, UIContentRarityStars rarityStars, int balance = 1)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[9];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)contentConfig);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)collectionText);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)titleText);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)descText);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tierRarityText);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rarityStars);
		*(int**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(System.IntPtr)))) = &balance;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FillContentData_Public_Static_Void_ContentConfiguration_Translator_Content_TMP_Text_TMP_Text_TMP_Text_TMP_Text_UIContentRarityStars_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 101130, RefRangeEnd = 101134, XrefRangeStart = 101114, XrefRangeEnd = 101130, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string GetContentTitle(Translator translator, Il2CppBAPBAP.Content.Content content, int balance = 1)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &balance;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetContentTitle_Public_Static_String_Translator_Content_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(13)]
	[CachedScanResults(RefRangeStart = 101160, RefRangeEnd = 101173, XrefRangeStart = 101134, XrefRangeEnd = 101160, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisualizeContentInPanel(Il2CppBAPBAP.Content.Content content, Image panelDisplay, float initializeDelay = 0f, bool allowSpawn3DVis = true)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)panelDisplay);
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &initializeDelay;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &allowSpawn3DVis;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisualizeContentInPanel_Public_Static_Void_Content_Image_Single_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 101173, XrefRangeEnd = 101190, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SpawnImageContentVisualizer(Il2CppBAPBAP.Content.Content content, RectTransform panel)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)panel);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnImageContentVisualizer_Private_Static_Void_Content_RectTransform_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(13)]
	[CachedScanResults(RefRangeStart = 101212, RefRangeEnd = 101225, XrefRangeStart = 101190, XrefRangeEnd = 101212, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void DestroySpawnedVisualizers(Transform panel)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)panel);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DestroySpawnedVisualizers_Public_Static_Void_Transform_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 101225, XrefRangeEnd = 101246, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void Set3DVisualizerContent(Il2CppBAPBAP.Content.Content content, Transform panelDisplay, float initializeDelay = 0f)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)content);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)panelDisplay);
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &initializeDelay;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Set3DVisualizerContent_Private_Static_Void_Content_Transform_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 101246, XrefRangeEnd = 101255, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SerializeAndSaveAllNotifications(string prefKey, Il2CppStructArray<int> ids)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(prefKey);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ids);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SerializeAndSaveAllNotifications_Public_Static_Void_String_Il2CppStructArray_1_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 101267, RefRangeEnd = 101269, XrefRangeStart = 101255, XrefRangeEnd = 101267, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<int> UnserializeAllSavedNotifications(string prefKey)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(prefKey);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UnserializeAllSavedNotifications_Public_Static_Il2CppStructArray_1_Int32_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 101276, RefRangeEnd = 101278, XrefRangeStart = 101269, XrefRangeEnd = 101276, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void AddSaveSerializeNotification(string prefKey, int id)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(prefKey);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &id;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddSaveSerializeNotification_Public_Static_Void_String_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 101289, RefRangeEnd = 101290, XrefRangeStart = 101278, XrefRangeEnd = 101289, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void DeleteSavedSerializeNotification(string prefKey, int id)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(prefKey);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &id;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DeleteSavedSerializeNotification_Public_Static_Void_String_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UILobbyUtilities(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Localisation;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppTMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Il2CppBAPBAP.UI;

public class UILobbyHistoryEntry : MonoBehaviour
{
	[System.Serializable]
	public class Configuration : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_CharacterConfig;

		private static readonly System.IntPtr NativeFieldInfoPtr_Prefab;

		private static readonly System.IntPtr NativeFieldInfoPtr_PoolSize;

		private static readonly System.IntPtr NativeFieldInfoPtr_minPlacementToWin;

		private static readonly System.IntPtr NativeFieldInfoPtr_WinColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_LossColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_WinAccentColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_LossAccentColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_NeutralAccentColour;

		private static readonly System.IntPtr NativeFieldInfoPtr_OutOfTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_KDATranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_DmgDealtTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_DmgTakenTranslationKey;

		private static readonly System.IntPtr NativeFieldInfoPtr_EmptyItemSprite;

		private static readonly System.IntPtr NativeFieldInfoPtr_EmptyItemBgColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_EmptyItemColor;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe UICharactersConfiguration CharacterConfig
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterConfig);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UICharactersConfiguration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_CharacterConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uICharactersConfiguration));
			}
		}

		public unsafe UILobbyHistoryEntry Prefab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Prefab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyHistoryEntry>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_Prefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uILobbyHistoryEntry));
			}
		}

		public unsafe int PoolSize
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PoolSize);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_PoolSize)) = num;
			}
		}

		public unsafe float minPlacementToWin
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minPlacementToWin);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minPlacementToWin)) = num;
			}
		}

		public unsafe Color WinColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_WinColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_WinColour)) = color;
			}
		}

		public unsafe Color LossColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LossColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LossColour)) = color;
			}
		}

		public unsafe Color WinAccentColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_WinAccentColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_WinAccentColour)) = color;
			}
		}

		public unsafe Color LossAccentColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LossAccentColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LossAccentColour)) = color;
			}
		}

		public unsafe Color NeutralAccentColour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NeutralAccentColour);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_NeutralAccentColour)) = color;
			}
		}

		public unsafe string OutOfTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OutOfTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OutOfTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string KDATranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_KDATranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_KDATranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string DmgDealtTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DmgDealtTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DmgDealtTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string DmgTakenTranslationKey
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DmgTakenTranslationKey);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_DmgTakenTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe Sprite EmptyItemSprite
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EmptyItemSprite);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Sprite>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EmptyItemSprite)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sprite));
			}
		}

		public unsafe Color EmptyItemBgColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EmptyItemBgColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EmptyItemBgColor)) = color;
			}
		}

		public unsafe Color EmptyItemColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EmptyItemColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EmptyItemColor)) = color;
			}
		}

		static Configuration()
		{
			Il2CppClassPointerStore<Configuration>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "Configuration");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Configuration>.NativeClassPtr);
			NativeFieldInfoPtr_CharacterConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "CharacterConfig");
			NativeFieldInfoPtr_Prefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "Prefab");
			NativeFieldInfoPtr_PoolSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "PoolSize");
			NativeFieldInfoPtr_minPlacementToWin = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "minPlacementToWin");
			NativeFieldInfoPtr_WinColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "WinColour");
			NativeFieldInfoPtr_LossColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "LossColour");
			NativeFieldInfoPtr_WinAccentColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "WinAccentColour");
			NativeFieldInfoPtr_LossAccentColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "LossAccentColour");
			NativeFieldInfoPtr_NeutralAccentColour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "NeutralAccentColour");
			NativeFieldInfoPtr_OutOfTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "OutOfTranslationKey");
			NativeFieldInfoPtr_KDATranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "KDATranslationKey");
			NativeFieldInfoPtr_DmgDealtTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "DmgDealtTranslationKey");
			NativeFieldInfoPtr_DmgTakenTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "DmgTakenTranslationKey");
			NativeFieldInfoPtr_EmptyItemSprite = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "EmptyItemSprite");
			NativeFieldInfoPtr_EmptyItemBgColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "EmptyItemBgColor");
			NativeFieldInfoPtr_EmptyItemColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Configuration>.NativeClassPtr, "EmptyItemColor");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Configuration>.NativeClassPtr, 100668491);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Configuration()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Configuration>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Configuration(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class Pool : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr__configuration;

		private static readonly System.IntPtr NativeFieldInfoPtr__inactiveQueue;

		private static readonly System.IntPtr NativeFieldInfoPtr__parentTransform;

		private static readonly System.IntPtr NativeFieldInfoPtr__viewportTransform;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Configuration_Transform_RectTransform_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Spawn_Public_UILobbyHistoryEntry_Translator_String_Int32_Boolean_Int32_Int32_DateTime_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_UnityAction_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Despawn_Public_Void_UILobbyHistoryEntry_0;

		public unsafe Configuration _configuration
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
			}
		}

		public unsafe Queue<UILobbyHistoryEntry> _inactiveQueue
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__inactiveQueue);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Queue<UILobbyHistoryEntry>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__inactiveQueue)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)queue));
			}
		}

		public unsafe Transform _parentTransform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__parentTransform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__parentTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
			}
		}

		public unsafe RectTransform _viewportTransform
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__viewportTransform);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__viewportTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
			}
		}

		static Pool()
		{
			Il2CppClassPointerStore<Pool>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "Pool");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Pool>.NativeClassPtr);
			NativeFieldInfoPtr__configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Pool>.NativeClassPtr, "_configuration");
			NativeFieldInfoPtr__inactiveQueue = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Pool>.NativeClassPtr, "_inactiveQueue");
			NativeFieldInfoPtr__parentTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Pool>.NativeClassPtr, "_parentTransform");
			NativeFieldInfoPtr__viewportTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Pool>.NativeClassPtr, "_viewportTransform");
			NativeMethodInfoPtr__ctor_Public_Void_Configuration_Transform_RectTransform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Pool>.NativeClassPtr, 100668492);
			NativeMethodInfoPtr_Spawn_Public_UILobbyHistoryEntry_Translator_String_Int32_Boolean_Int32_Int32_DateTime_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_UnityAction_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Pool>.NativeClassPtr, 100668493);
			NativeMethodInfoPtr_Despawn_Public_Void_UILobbyHistoryEntry_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Pool>.NativeClassPtr, 100668494);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 88674, RefRangeEnd = 88675, XrefRangeStart = 88660, XrefRangeEnd = 88674, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Pool(Configuration configuration, Transform parentTransform, RectTransform viewportTransform)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Pool>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parentTransform);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)viewportTransform);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Configuration_Transform_RectTransform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 88675, XrefRangeEnd = 88687, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe UILobbyHistoryEntry Spawn(Translator translator, string gameModeTranslationKey, int placement, bool isMvp, int teamCount, int rankedPointsDelta, Il2CppSystem.DateTime date, int kills, int deaths, int assists, int itemId1, int itemId2, int itemId3, int itemId4, int dmgDealt, int dmgTaken, int characterId, UnityAction onClickAction)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[18];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(gameModeTranslationKey);
			*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &placement;
			*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &isMvp;
			*(int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &teamCount;
			*(int**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &rankedPointsDelta;
			*(Il2CppSystem.DateTime**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &date;
			*(int**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &kills;
			*(int**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(System.IntPtr)))) = &deaths;
			*(int**)((byte*)ptr + checked((nuint)9u * unchecked((nuint)sizeof(System.IntPtr)))) = &assists;
			*(int**)((byte*)ptr + checked((nuint)10u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId1;
			*(int**)((byte*)ptr + checked((nuint)11u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId2;
			*(int**)((byte*)ptr + checked((nuint)12u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId3;
			*(int**)((byte*)ptr + checked((nuint)13u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId4;
			*(int**)((byte*)ptr + checked((nuint)14u * unchecked((nuint)sizeof(System.IntPtr)))) = &dmgDealt;
			*(int**)((byte*)ptr + checked((nuint)15u * unchecked((nuint)sizeof(System.IntPtr)))) = &dmgTaken;
			*(int**)((byte*)ptr + checked((nuint)16u * unchecked((nuint)sizeof(System.IntPtr)))) = &characterId;
			*(System.IntPtr*)((byte*)ptr + checked((nuint)17u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)onClickAction);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Spawn_Public_UILobbyHistoryEntry_Translator_String_Int32_Boolean_Int32_Int32_DateTime_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_UnityAction_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UILobbyHistoryEntry>(intPtr) : null;
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 88687, XrefRangeEnd = 88691, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void Despawn(UILobbyHistoryEntry instance)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instance);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Despawn_Public_Void_UILobbyHistoryEntry_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Pool(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__layoutElement;

	private static readonly System.IntPtr NativeFieldInfoPtr__button;

	private static readonly System.IntPtr NativeFieldInfoPtr__selectBarObject;

	private static readonly System.IntPtr NativeFieldInfoPtr__placementColorImage;

	private static readonly System.IntPtr NativeFieldInfoPtr__characterImage;

	private static readonly System.IntPtr NativeFieldInfoPtr__placementText;

	private static readonly System.IntPtr NativeFieldInfoPtr__outOfText;

	private static readonly System.IntPtr NativeFieldInfoPtr__characterText;

	private static readonly System.IntPtr NativeFieldInfoPtr__mvpText;

	private static readonly System.IntPtr NativeFieldInfoPtr__rankedPointsText;

	private static readonly System.IntPtr NativeFieldInfoPtr__gameModeText;

	private static readonly System.IntPtr NativeFieldInfoPtr__dateText;

	private static readonly System.IntPtr NativeFieldInfoPtr__kdaLabelText;

	private static readonly System.IntPtr NativeFieldInfoPtr__kdaValueText;

	private static readonly System.IntPtr NativeFieldInfoPtr__item1Image;

	private static readonly System.IntPtr NativeFieldInfoPtr__item1ImageBg;

	private static readonly System.IntPtr NativeFieldInfoPtr__item2Image;

	private static readonly System.IntPtr NativeFieldInfoPtr__item2ImageBg;

	private static readonly System.IntPtr NativeFieldInfoPtr__item3Image;

	private static readonly System.IntPtr NativeFieldInfoPtr__item3ImageBg;

	private static readonly System.IntPtr NativeFieldInfoPtr__item4Image;

	private static readonly System.IntPtr NativeFieldInfoPtr__item4ImageBg;

	private static readonly System.IntPtr NativeFieldInfoPtr__dmgDealtLabelText;

	private static readonly System.IntPtr NativeFieldInfoPtr__dmgDealtValueText;

	private static readonly System.IntPtr NativeFieldInfoPtr__dmgTakenLabelText;

	private static readonly System.IntPtr NativeFieldInfoPtr__dmgTakenValueText;

	private static readonly System.IntPtr NativeFieldInfoPtr__configuration;

	private static readonly System.IntPtr NativeFieldInfoPtr__gameModeTranslationKey;

	private static readonly System.IntPtr NativeFieldInfoPtr__isSelected;

	private static readonly System.IntPtr NativeFieldInfoPtr__onClickAction;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameTeamCount;

	private static readonly System.IntPtr NativeFieldInfoPtr__pool;

	private static readonly System.IntPtr NativeFieldInfoPtr__viewportTransform;

	private static readonly System.IntPtr NativeMethodInfoPtr_Initialise_Private_Void_Pool_Configuration_RectTransform_String_Int32_Boolean_Int32_Int32_DateTime_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_UnityAction_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Localise_Public_Void_Translator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Dispose_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetSelected_Public_Void_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Select_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Deselect_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe LayoutElement _layoutElement
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__layoutElement);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LayoutElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__layoutElement)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layoutElement));
		}
	}

	public unsafe Button _button
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__button);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Button>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__button)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)button));
		}
	}

	public unsafe GameObject _selectBarObject
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__selectBarObject);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__selectBarObject)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Image _placementColorImage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__placementColorImage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__placementColorImage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _characterImage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__characterImage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__characterImage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe TMP_Text _placementText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__placementText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__placementText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _outOfText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__outOfText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__outOfText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _characterText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__characterText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__characterText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _mvpText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mvpText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__mvpText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _rankedPointsText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__rankedPointsText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__rankedPointsText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _gameModeText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameModeText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameModeText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _dateText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dateText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dateText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _kdaLabelText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__kdaLabelText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__kdaLabelText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _kdaValueText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__kdaValueText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__kdaValueText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe Image _item1Image
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item1Image);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item1Image)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _item1ImageBg
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item1ImageBg);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item1ImageBg)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _item2Image
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item2Image);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item2Image)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _item2ImageBg
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item2ImageBg);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item2ImageBg)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _item3Image
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item3Image);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item3Image)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _item3ImageBg
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item3ImageBg);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item3ImageBg)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _item4Image
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item4Image);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item4Image)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe Image _item4ImageBg
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item4ImageBg);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Image>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__item4ImageBg)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)image));
		}
	}

	public unsafe TMP_Text _dmgDealtLabelText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgDealtLabelText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgDealtLabelText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _dmgDealtValueText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgDealtValueText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgDealtValueText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _dmgTakenLabelText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgTakenLabelText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgTakenLabelText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe TMP_Text _dmgTakenValueText
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgTakenValueText);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TMP_Text>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__dmgTakenValueText)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tMP_Text));
		}
	}

	public unsafe Configuration _configuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__configuration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration));
		}
	}

	public unsafe string _gameModeTranslationKey
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameModeTranslationKey);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__gameModeTranslationKey)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool _isSelected
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isSelected);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__isSelected)) = flag;
		}
	}

	public unsafe UnityAction _onClickAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__onClickAction);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UnityAction>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__onClickAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)unityAction));
		}
	}

	public unsafe int gameTeamCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameTeamCount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameTeamCount)) = num;
		}
	}

	public unsafe Pool _pool
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pool);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Pool>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__pool)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pool));
		}
	}

	public unsafe RectTransform _viewportTransform
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__viewportTransform);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<RectTransform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__viewportTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rectTransform));
		}
	}

	static UILobbyHistoryEntry()
	{
		Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UILobbyHistoryEntry");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr);
		NativeFieldInfoPtr__layoutElement = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_layoutElement");
		NativeFieldInfoPtr__button = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_button");
		NativeFieldInfoPtr__selectBarObject = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_selectBarObject");
		NativeFieldInfoPtr__placementColorImage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_placementColorImage");
		NativeFieldInfoPtr__characterImage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_characterImage");
		NativeFieldInfoPtr__placementText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_placementText");
		NativeFieldInfoPtr__outOfText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_outOfText");
		NativeFieldInfoPtr__characterText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_characterText");
		NativeFieldInfoPtr__mvpText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_mvpText");
		NativeFieldInfoPtr__rankedPointsText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_rankedPointsText");
		NativeFieldInfoPtr__gameModeText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_gameModeText");
		NativeFieldInfoPtr__dateText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_dateText");
		NativeFieldInfoPtr__kdaLabelText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_kdaLabelText");
		NativeFieldInfoPtr__kdaValueText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_kdaValueText");
		NativeFieldInfoPtr__item1Image = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item1Image");
		NativeFieldInfoPtr__item1ImageBg = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item1ImageBg");
		NativeFieldInfoPtr__item2Image = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item2Image");
		NativeFieldInfoPtr__item2ImageBg = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item2ImageBg");
		NativeFieldInfoPtr__item3Image = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item3Image");
		NativeFieldInfoPtr__item3ImageBg = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item3ImageBg");
		NativeFieldInfoPtr__item4Image = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item4Image");
		NativeFieldInfoPtr__item4ImageBg = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_item4ImageBg");
		NativeFieldInfoPtr__dmgDealtLabelText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_dmgDealtLabelText");
		NativeFieldInfoPtr__dmgDealtValueText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_dmgDealtValueText");
		NativeFieldInfoPtr__dmgTakenLabelText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_dmgTakenLabelText");
		NativeFieldInfoPtr__dmgTakenValueText = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_dmgTakenValueText");
		NativeFieldInfoPtr__configuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_configuration");
		NativeFieldInfoPtr__gameModeTranslationKey = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_gameModeTranslationKey");
		NativeFieldInfoPtr__isSelected = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_isSelected");
		NativeFieldInfoPtr__onClickAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_onClickAction");
		NativeFieldInfoPtr_gameTeamCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "gameTeamCount");
		NativeFieldInfoPtr__pool = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_pool");
		NativeFieldInfoPtr__viewportTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, "_viewportTransform");
		NativeMethodInfoPtr_Initialise_Private_Void_Pool_Configuration_RectTransform_String_Int32_Boolean_Int32_Int32_DateTime_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_UnityAction_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, 100668484);
		NativeMethodInfoPtr_Localise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, 100668485);
		NativeMethodInfoPtr_Dispose_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, 100668486);
		NativeMethodInfoPtr_SetSelected_Public_Void_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, 100668487);
		NativeMethodInfoPtr_Select_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, 100668488);
		NativeMethodInfoPtr_Deselect_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, 100668489);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr, 100668490);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 88796, RefRangeEnd = 88797, XrefRangeStart = 88691, XrefRangeEnd = 88796, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Initialise(Pool pool, Configuration configuration, RectTransform viewportTransform, string gameModeTranslationKey, int placement, bool isMvp, int teamCount, int rankedPointsDelta, Il2CppSystem.DateTime date, int kills, int deaths, int assists, int itemId1, int itemId2, int itemId3, int itemId4, int dmgDealt, int dmgTaken, int charId, UnityAction onClickAction)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[20];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pool);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)configuration);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)viewportTransform);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(gameModeTranslationKey);
		*(int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &placement;
		*(bool**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &isMvp;
		*(int**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &teamCount;
		*(int**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &rankedPointsDelta;
		*(Il2CppSystem.DateTime**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(System.IntPtr)))) = &date;
		*(int**)((byte*)ptr + checked((nuint)9u * unchecked((nuint)sizeof(System.IntPtr)))) = &kills;
		*(int**)((byte*)ptr + checked((nuint)10u * unchecked((nuint)sizeof(System.IntPtr)))) = &deaths;
		*(int**)((byte*)ptr + checked((nuint)11u * unchecked((nuint)sizeof(System.IntPtr)))) = &assists;
		*(int**)((byte*)ptr + checked((nuint)12u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId1;
		*(int**)((byte*)ptr + checked((nuint)13u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId2;
		*(int**)((byte*)ptr + checked((nuint)14u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId3;
		*(int**)((byte*)ptr + checked((nuint)15u * unchecked((nuint)sizeof(System.IntPtr)))) = &itemId4;
		*(int**)((byte*)ptr + checked((nuint)16u * unchecked((nuint)sizeof(System.IntPtr)))) = &dmgDealt;
		*(int**)((byte*)ptr + checked((nuint)17u * unchecked((nuint)sizeof(System.IntPtr)))) = &dmgTaken;
		*(int**)((byte*)ptr + checked((nuint)18u * unchecked((nuint)sizeof(System.IntPtr)))) = &charId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)19u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)onClickAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialise_Private_Void_Pool_Configuration_RectTransform_String_Int32_Boolean_Int32_Int32_DateTime_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_Int32_UnityAction_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 88806, RefRangeEnd = 88808, XrefRangeStart = 88797, XrefRangeEnd = 88806, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Localise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 88812, RefRangeEnd = 88813, XrefRangeStart = 88808, XrefRangeEnd = 88812, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Dispose()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Dispose_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 88814, RefRangeEnd = 88816, XrefRangeStart = 88813, XrefRangeEnd = 88814, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetSelected(bool selected, bool forceAction = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&selected);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &forceAction;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetSelected_Public_Void_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 88816, XrefRangeEnd = 88817, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Select()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Select_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 88817, XrefRangeEnd = 88818, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Deselect()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Deselect_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UILobbyHistoryEntry()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UILobbyHistoryEntry>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UILobbyHistoryEntry(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

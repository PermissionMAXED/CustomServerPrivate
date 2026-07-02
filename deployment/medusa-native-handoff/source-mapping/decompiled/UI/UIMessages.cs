using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.UI;

public class UIMessages : MonoBehaviour
{
	public sealed class KillMessageInfo : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_killedName;

		private static readonly System.IntPtr NativeFieldInfoPtr_totalKills;

		private static readonly System.IntPtr NativeFieldInfoPtr_squadEliminated;

		private static readonly System.IntPtr NativeFieldInfoPtr_downed;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_String_String_Boolean_Boolean_0;

		public unsafe string killedName
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killedName);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killedName)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe string totalKills
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalKills);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_totalKills)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe bool squadEliminated
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_squadEliminated);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_squadEliminated)) = flag;
			}
		}

		public unsafe bool downed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_downed);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_downed)) = flag;
			}
		}

		static KillMessageInfo()
		{
			Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "KillMessageInfo");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr);
			NativeFieldInfoPtr_killedName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr, "killedName");
			NativeFieldInfoPtr_totalKills = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr, "totalKills");
			NativeFieldInfoPtr_squadEliminated = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr, "squadEliminated");
			NativeFieldInfoPtr_downed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr, "downed");
			NativeMethodInfoPtr__ctor_Public_Void_String_String_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr, 100667936);
		}

		[CallerCount(11)]
		[CachedScanResults(RefRangeStart = 85271, RefRangeEnd = 85282, XrefRangeStart = 85271, XrefRangeEnd = 85271, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe KillMessageInfo(string _killedName, string _totalKills, bool _squadEliminated, bool _downed)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[4];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(_killedName);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(_totalKills);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &_squadEliminated;
			*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &_downed;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_String_String_Boolean_Boolean_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public KillMessageInfo(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public KillMessageInfo()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<KillMessageInfo>.NativeClassPtr))
		{
		}
	}

	public sealed class GameMessage : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_messageStr;

		private static readonly System.IntPtr NativeFieldInfoPtr_messageType;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_String_GameMessageType_0;

		public unsafe string messageStr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageStr);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageStr)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		public unsafe GameMessageType messageType
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageType);
				return *(GameMessageType*)num;
			}
			set
			{
				*(GameMessageType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageType)) = gameMessageType;
			}
		}

		static GameMessage()
		{
			Il2CppClassPointerStore<GameMessage>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "GameMessage");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GameMessage>.NativeClassPtr);
			NativeFieldInfoPtr_messageStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameMessage>.NativeClassPtr, "messageStr");
			NativeFieldInfoPtr_messageType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GameMessage>.NativeClassPtr, "messageType");
			NativeMethodInfoPtr__ctor_Public_Void_String_GameMessageType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GameMessage>.NativeClassPtr, 100667937);
		}

		[CallerCount(2853)]
		[CachedScanResults(RefRangeStart = 51511, RefRangeEnd = 54364, XrefRangeStart = 51511, XrefRangeEnd = 54364, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GameMessage(string messageStr, GameMessageType messageType)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GameMessage>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.ManagedStringToIl2Cpp(messageStr);
			*(GameMessageType**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &messageType;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_String_GameMessageType_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public GameMessage(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public GameMessage()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GameMessage>.NativeClassPtr))
		{
		}
	}

	[OriginalName("Assembly-CSharp.dll", "", "GameMessageType")]
	public enum GameMessageType
	{
		Alert,
		Neutral,
		Epic
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_uiManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_messagesCanvas;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModeMessage;

	private static readonly System.IntPtr NativeFieldInfoPtr_killMessageElement;

	private static readonly System.IntPtr NativeFieldInfoPtr_augmentMessage;

	private static readonly System.IntPtr NativeFieldInfoPtr_killFeedElementPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_messageDuration;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameMessageColors;

	private static readonly System.IntPtr NativeFieldInfoPtr_killMessages;

	private static readonly System.IntPtr NativeFieldInfoPtr_gameModeMessages;

	private static readonly System.IntPtr NativeMethodInfoPtr_Start_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnKillPopUpMessage_Public_Void_String_String_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnGameModeMessage_Public_Void_String_GameMessageType_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateKillMessage_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateGameModeMessage_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ShowAugmentMessage_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnGameModeMessageEnded_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe UIManager uiManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_uiManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIManager));
		}
	}

	public unsafe Canvas messagesCanvas
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messagesCanvas);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Canvas>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messagesCanvas)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)canvas));
		}
	}

	public unsafe UIGameMessageElement gameModeMessage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeMessage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIGameMessageElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeMessage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIGameMessageElement));
		}
	}

	public unsafe UIKillMessageElement killMessageElement
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killMessageElement);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIKillMessageElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killMessageElement)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIKillMessageElement));
		}
	}

	public unsafe UIGameMessageElement augmentMessage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_augmentMessage);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<UIGameMessageElement>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_augmentMessage)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uIGameMessageElement));
		}
	}

	public unsafe GameObject killFeedElementPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killFeedElementPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killFeedElementPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe float messageDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_messageDuration)) = num;
		}
	}

	public unsafe Il2CppStructArray<Color> gameMessageColors
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameMessageColors);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameMessageColors)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe List<KillMessageInfo> killMessages
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killMessages);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<KillMessageInfo>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_killMessages)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<GameMessage> gameModeMessages
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeMessages);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<GameMessage>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModeMessages)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static UIMessages()
	{
		Il2CppClassPointerStore<UIMessages>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UIMessages");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UIMessages>.NativeClassPtr);
		NativeFieldInfoPtr_uiManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "uiManager");
		NativeFieldInfoPtr_messagesCanvas = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "messagesCanvas");
		NativeFieldInfoPtr_gameModeMessage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "gameModeMessage");
		NativeFieldInfoPtr_killMessageElement = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "killMessageElement");
		NativeFieldInfoPtr_augmentMessage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "augmentMessage");
		NativeFieldInfoPtr_killFeedElementPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "killFeedElementPrefab");
		NativeFieldInfoPtr_messageDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "messageDuration");
		NativeFieldInfoPtr_gameMessageColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "gameMessageColors");
		NativeFieldInfoPtr_killMessages = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "killMessages");
		NativeFieldInfoPtr_gameModeMessages = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, "gameModeMessages");
		NativeMethodInfoPtr_Start_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667928);
		NativeMethodInfoPtr_SpawnKillPopUpMessage_Public_Void_String_String_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667929);
		NativeMethodInfoPtr_SpawnGameModeMessage_Public_Void_String_GameMessageType_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667930);
		NativeMethodInfoPtr_UpdateKillMessage_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667931);
		NativeMethodInfoPtr_UpdateGameModeMessage_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667932);
		NativeMethodInfoPtr_ShowAugmentMessage_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667933);
		NativeMethodInfoPtr_OnGameModeMessageEnded_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667934);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UIMessages>.NativeClassPtr, 100667935);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85282, XrefRangeEnd = 85287, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Start()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Start_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85292, RefRangeEnd = 85293, XrefRangeStart = 85287, XrefRangeEnd = 85292, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnKillPopUpMessage(string str, string totalKills, bool squadEliminated = false, bool downed = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(str);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(totalKills);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &squadEliminated;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &downed;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnKillPopUpMessage_Public_Void_String_String_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 85296, RefRangeEnd = 85306, XrefRangeStart = 85293, XrefRangeEnd = 85296, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnGameModeMessage(string str, GameMessageType messageType)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(str);
		*(GameMessageType**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &messageType;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnGameModeMessage_Public_Void_String_GameMessageType_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85308, RefRangeEnd = 85309, XrefRangeStart = 85306, XrefRangeEnd = 85308, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateKillMessage()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateKillMessage_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 85314, RefRangeEnd = 85317, XrefRangeStart = 85309, XrefRangeEnd = 85314, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateGameModeMessage()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateGameModeMessage_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 85319, RefRangeEnd = 85320, XrefRangeStart = 85317, XrefRangeEnd = 85319, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShowAugmentMessage()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShowAugmentMessage_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85320, XrefRangeEnd = 85326, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnGameModeMessageEnded()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnGameModeMessageEnded_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 85326, XrefRangeEnd = 85335, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UIMessages()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UIMessages>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UIMessages(System.IntPtr pointer)
		: base(pointer)
	{
	}
}

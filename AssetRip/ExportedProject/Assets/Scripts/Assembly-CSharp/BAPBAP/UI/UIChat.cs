using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Profanity;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIChat : MonoBehaviour
	{
		public enum ChatType
		{
			System = 0,
			Lobby = 1,
			Whisper = 2
		}

		[Serializable]
		public class ChatPanel
		{
			public GameObject root;

			public RectTransform rootRectTransform;

			public UIAlphaFade uiAlphaFade;

			public CanvasGroup panelCanvasGroup;

			public CanvasGroup messagesCanvasGroup;

			public TMP_InputField InputField;

			public CanvasGroup InputFieldCanvasGroup;

			public EventTrigger HoverEventTrigger;

			public UIAlphaFade bgAlphaFade;

			public TMP_Text PlaceholderText;

			public TMP_Text InputText;

			public ScrollRect ScrollRect;

			public Transform EntryParentTransform;

			public CanvasGroup VoiceChatGroup;

			public EventTrigger VoiceChatEventTrigger;
		}

		[Serializable]
		public class Configuration
		{
			public UILobbyChatEntry.Configuration ChatEntryConfiguration;

			public int ChatCharacterLimit;

			public string ChatPlaceholderTranslationKey;

			public string SystemChatTypeString;

			public string LobbyChatTypeString;

			public string WhisperChatTypeString;

			public Color SystemChatTypeColor;

			public Color LobbyChatTypeColor;

			public Color WhisperChatTypeColor;

			public Color SelfUsernameColor;

			public Color playerUsernameColor;

			public Color allyChatColor;

			public Color enemyChatColor;

			public Color npcChatColor;

			public string whisperSentPrefix;

			public string whisperReceivedPrefix;

			public AudioManager.SFX chatMsgSfx;

			public float chatMsgSfxVolume;
		}

		[NonSerialized]
		public UITeammates uiTeammatesStats;

		[NonSerialized]
		public UILobbyPlayTabPage lobbyPlayTabPage;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public ProfanityFilter profanityFilter;

		[SerializeField]
		[Header("UI References")]
		public Canvas chatMainCanvas;

		[SerializeField]
		public ChatPanel _chatPanel;

		[SerializeField]
		public RectTransform lobbyTransformHolder;

		[SerializeField]
		public RectTransform gameTransformHolder;

		[SerializeField]
		[Space(5f)]
		public Configuration _configuration;

		[NonSerialized]
		public string playerUsernameColorHex;

		[NonSerialized]
		public string sentWhisperColorHex;

		[NonSerialized]
		public string receivedWhisperColorHex;

		[NonSerialized]
		public UILobbyChatEntry.Pool _chatEntryPool;

		[NonSerialized]
		public int _dirtyChatLogFrame;

		[NonSerialized]
		public InputBinding chatEnterInputBinding;

		[NonSerialized]
		public bool chatIsFocused;

		[NonSerialized]
		public bool voiceIsFocused;

		[NonSerialized]
		public bool fadeOutMessages;

		[NonSerialized]
		public bool unfocusOnSubmit;

		[NonSerialized]
		public bool isGameChat;

		[NonSerialized]
		public UILobbyChatEntry[] chatEntries;

		[NonSerialized]
		public LobbyDataModel.FriendList _friendsList;

		[NonSerialized]
		public string _prevWhisperUsername;

		public const string WHISPER_COMMAND_PREFIX = "/w";

		public const string REPLY_COMMAND_PREFIX = "/r";

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void SetFriendsList(LobbyDataModel.FriendList friendsList)
		{
		}

		public void Update()
		{
		}

		public void FocusChat(bool focused)
		{
		}

		public void OnInputFieldFocused(string s)
		{
		}

		public void OnInputFieldUnfocused(string s)
		{
		}

		public void UpdateChat(ChatType chatType, string username, string message, bool system, bool msgPreventRichText = true, bool msgCheckProfanity = true, string usernameColorHex = "", bool fromLocalPlayer = false)
		{
		}

		public void SetInputFieldText(string message)
		{
		}

		public void SendChatMessage(string message)
		{
		}

		public void TrySendWhisper(string user, string message)
		{
		}

		public void UpdateChatSentWhisper(string user, string message, bool system, string friendFullUsername)
		{
		}

		public void UpdateChatReceivedWhisper(string user, string message, bool system, string friendFullUsername)
		{
		}

		public void ClearChat()
		{
		}

		public void ClearChatInput()
		{
		}

		public void EnableChat(bool fadeIn = false)
		{
		}

		public void DisableChat()
		{
		}

		public void ToggleLobbyChat()
		{
		}

		public void ToggleGameChat()
		{
		}

		public void AttachChatToParent(Transform parent)
		{
		}

		public void SetChatShowMessagesPanelHidden(bool hideMessages)
		{
		}

		public string GetChatTypeString(ChatType chatType)
		{
			return null;
		}

		public string GetChatTypeColorHex(ChatType chatType)
		{
			return null;
		}

		public void CheckForCommand(string message)
		{
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Profanity;
using BAPBAP.UI.Mobile;
using BAPBAP.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI;

public class UIManager : MonoBehaviour
{
	[Serializable]
	public struct InfoStatus
	{
		[Tooltip("Show this status if the given value is below this threshold. From less to more threshold for each InfoStatus")]
		public float threshold;

		public Color color;
	}

	[Serializable]
	public class StatConfig
	{
		public string nameTranslationKey;

		public string nameShort;

		public string spriteToId;

		public Color statColor;

		[NonSerialized]
		public string localizedName;
	}

	public enum HpBarType
	{
		Character,
		Small,
		Invurnerable,
		Boss,
		Elite
	}

	public enum EmotionState
	{
		Aggrod,
		Huh
	}

	[Serializable]
	public class EmotionStateConfig
	{
		public Sprite icon;

		public Color color;
	}

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	public struct <Awake>d__111 : IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncVoidMethodBuilder <>t__builder;

		public UIManager <>4__this;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[CompilerGenerated]
	public sealed class <ShowCanvasGroupCoroutine>d__174 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int <>1__state;

		[NonSerialized]
		public object <>2__current;

		public Canvas canvas;

		public bool open;

		public float duration;

		public CanvasGroup canvasGroup;

		public Action OnFinished;

		[NonSerialized]
		public float <time>5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public <ShowCanvasGroupCoroutine>d__174(int <>1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[NonSerialized]
	public UISettingsMenu uiSettings;

	[NonSerialized]
	public UIDeveloperLobby uiDeveloperLobby;

	[NonSerialized]
	public UIChat uiChat;

	[NonSerialized]
	public UIVoiceChat uiVoiceChat;

	[NonSerialized]
	public UIAbilities uiAbilities;

	[NonSerialized]
	public UIPassives uiPassives;

	[NonSerialized]
	public UIGameModifiers uiGameModifiers;

	[NonSerialized]
	public UIItems uiItems;

	[NonSerialized]
	public UIItemsWorldTooltip uiItemsWorldTooltip;

	[NonSerialized]
	public UIWorldLabel uiWorldLabel;

	[NonSerialized]
	public UITooltip uiTooltip;

	[NonSerialized]
	public UITeammates uiTeammates;

	[NonSerialized]
	public UIPopUp uiPopUp;

	[NonSerialized]
	public UICanvasEffect uiCanvasEffect;

	[NonSerialized]
	public UIGameMode uiGameMode;

	[NonSerialized]
	public UIKillFeed uiKillFeed;

	[NonSerialized]
	public UIMessages uiMessages;

	[NonSerialized]
	public UIMinimap uiMinimap;

	[NonSerialized]
	public UINetwork uiNetwork;

	[NonSerialized]
	public UISelectionWheelPings pingSelectionWheel;

	[NonSerialized]
	public UISelectionWheelEmotes emoteSelectionWheel;

	[NonSerialized]
	public UISelectionWheelItemSwap uiItemSwapWheel;

	[NonSerialized]
	public UIInteractableWindows uiInteractableWindows;

	[NonSerialized]
	public UIMobileControls uiMobileControls;

	[NonSerialized]
	public Translator translator;

	[NonSerialized]
	public UIAugments uiAugments;

	[NonSerialized]
	public UIPreMatch uiPreMatch;

	[NonSerialized]
	public UIZoneTitle uiZoneTitle;

	[NonSerialized]
	public UISpeechBubble uiSpeechBubble;

	[Header("General")]
	public Camera cam;

	public Transform mainCanvas;

	public EventSystem eventSystem;

	public UIModalWindowController modalWindowGeneric;

	[Header("Stats Info")]
	public GameObject statsInfo;

	[Header("Ping Info")]
	public GameObject pingDisplay;

	public TMP_Text pingText;

	public Image pingIcon;

	public InfoStatus[] pingStatus;

	[Header("Fps Info")]
	public GameObject fpsDisplay;

	public TMP_Text fpsText;

	public TMP_Text fpsCountText;

	public InfoStatus[] fpsStatus;

	[Header("Build Info")]
	public GameObject buildInfo;

	public TMP_Text buildVersionText;

	[Header("Canvas Scaling")]
	[SerializeField]
	public CanvasScaler canvasScaler;

	[Tooltip("The ui scale multiplier based on resolution")]
	[SerializeField]
	public float scaleResMultiplier;

	[SerializeField]
	public RangeFloat uiScaleRange;

	[NonSerialized]
	public float uiScale;

	[NonSerialized]
	public Vector2 prevScreenSize;

	[NonSerialized]
	public Vector2 targetRes;

	[Header("Hp Bars Config")]
	[SerializeField]
	public Transform HPBarCanvas;

	[SerializeField]
	public Transform HPBarBossCanvas;

	[SerializeField]
	public Material hpBarMaterialLocalPlayer;

	[SerializeField]
	public Material hpBarMaterialAlly;

	[SerializeField]
	public Material hpBarMaterialEnemy;

	[SerializeField]
	public UIHpBar.Configuration hpBarConfig;

	[SerializeField]
	public UIHpBar.Configuration hpBarSmallConfig;

	[SerializeField]
	public UIHpBar.Configuration hpBarInvulnerableConfig;

	[SerializeField]
	public UIHpBar.Configuration hpBarBossConfig;

	[SerializeField]
	public UIHpBar.Configuration hpBarEliteConfig;

	[Header("Emotion State Config")]
	[NamedArray(typeof(EmotionState), 0)]
	[SerializeField]
	public EmotionStateConfig[] emotionStateConfigs;

	[NonSerialized]
	public Dictionary<uint, UIHpBar> hpBarsByNetId;

	[NonSerialized]
	public UIHpBar.Pool hpBarPool;

	[NonSerialized]
	public UIHpBar.Pool hpBarSmallPool;

	[NonSerialized]
	public UIHpBar.Pool hpBarInvulnerablePool;

	[NonSerialized]
	public UIHpBar.Pool hpBarBossPool;

	[NonSerialized]
	public UIHpBar.Pool hpBarElitePool;

	[Header("Characters")]
	public UICharactersConfiguration characterConfig;

	[Header("Names")]
	[SerializeField]
	public string[] anonymousNames;

	[SerializeField]
	public string[] randomNames;

	[SerializeField]
	public string[] guestNames;

	[SerializeField]
	[NamedArray(typeof(TextSprite), 0)]
	[Header("Configs")]
	public string[] textSpriteToId;

	[NamedArray(typeof(Stats), 0)]
	[SerializeField]
	public StatConfig[] statConfigs;

	[SerializeField]
	public Color visibleIndicatorAlly;

	[SerializeField]
	public Color visibleIndicatorEnemy;

	[SerializeField]
	public string notifHasBeenDisconectedTranslationKey;

	[SerializeField]
	public string notifAlreadyLoggedInTranslationKey;

	[SerializeField]
	public string hasJoinedTheGameTranslationKey;

	[SerializeField]
	[Header("Prefabs")]
	public UIProgressBarElement uiProgressBarElementPrefab;

	[Header("Warning Messages")]
	[SerializeField]
	public UIModalWindowController disconnectedWindow;

	[Header("Cursor")]
	[SerializeField]
	public Texture2D uiCursor;

	[SerializeField]
	public Texture2D gameCursor;

	[SerializeField]
	public Texture2D buttonHoveringCursor;

	[NamedArray(typeof(LocalSavedData.CursorOptions), 0)]
	[SerializeField]
	public Texture2D[] cursorTypes;

	[NamedArray(typeof(LocalSavedData.CursorColor), 0)]
	[SerializeField]
	public Color[] cursorColors;

	[Header("Content Visualizer 3D")]
	[SerializeField]
	public ContentVisualizer3D contentVisualizer3DPrefab;

	[SerializeField]
	public RawImage contentVisualizerRawImagePrefab;

	[NonSerialized]
	public List<ContentVisualizer3D> spawnedContentVisualizers3D;

	[Header("UI Lobby")]
	[SerializeField]
	public UILobby uiLobby;

	[SerializeField]
	public GameObject lobbyRoot;

	[SerializeField]
	public LocalisationConfiguration localisationConfig;

	[SerializeField]
	public ProfanityFilterConfiguration profanityConfig;

	[NonSerialized]
	public bool computedMouseOverUI;

	[NonSerialized]
	public bool isMouseOverUI;

	[NonSerialized]
	public bool waitingToFocusSelectable;

	[NonSerialized]
	public Selectable focusSelectable;

	[NonSerialized]
	public Texture2D currentCursor;

	public Action<InputMode> onInputModeChanged;

	[NonSerialized]
	public string hasJoinedTheGameStr;

	[NonSerialized]
	public bool endGameMusicScheduled;

	[NonSerialized]
	public bool isDeveloperLobby;

	[NonSerialized]
	public bool isAdmin;

	public static UIManager Instance;

	public void OnIsAdminChanged()
	{
	}

	public void UpdateEmoteView()
	{
	}

	public void PreAwake()
	{
	}

	[AsyncStateMachine(typeof(<Awake>d__111))]
	public void Awake()
	{
	}

	public void OpenLobbyUI()
	{
	}

	public void CloseLobbyUI()
	{
	}

	public void ShowLoadingScreenSimple()
	{
	}

	public void HideLoadingScreenSimple(float delay = 0f)
	{
	}

	public void PlayMatchFoundSequence(Action onSequenceEndAction)
	{
	}

	public void SetHoveringCursor()
	{
	}

	public void SetCurrentDefaultCursor()
	{
	}

	public void OnApplicationFocus(bool focusStatus)
	{
	}

	public void SetCursorFromId(int value)
	{
	}

	public void SetCursorColorId(int value)
	{
	}

	public void RenderGameCursor()
	{
	}

	public void ShowDisconnectedWindow()
	{
	}

	public void HideDisconnectedWindow()
	{
	}

	public void Start()
	{
	}

	public void LocaliseAll()
	{
	}

	public void Localise(Translator translator)
	{
	}

	public void FixedUpdate()
	{
	}

	public void Update()
	{
	}

	public void LateUpdate()
	{
	}

	public void OnInputModeChanged(InputMode inputMode)
	{
	}

	public void FocusSelectable(Selectable selectable)
	{
	}

	public Selectable GetCurrentFocusedSelectable()
	{
		return null;
	}

	public void UpdateKeybind(InputBinding inputBinding, bool isGamepad)
	{
	}

	public void InitialiseHpBars()
	{
	}

	public UIHpBar SpawnHpBar(HpBarType type, Transform followTransform, float worldHeight, bool isAlly, bool isLocalPlayer, string name)
	{
		return null;
	}

	public void DespawnHpBar(HpBarType type, UIHpBar hpBar)
	{
	}

	public void AddHpBar(uint entityNetId, UIHpBar hpBar)
	{
	}

	public void RemoveHpBar(uint entityNetId)
	{
	}

	public UIHpBar GetHpBar(uint entityNetId)
	{
		return null;
	}

	public bool TryGetHpBar(uint entityNetId, out UIHpBar hpBar)
	{
		hpBar = null;
		return false;
	}

	public void ClClearAllHpBars()
	{
	}

	public void UpdateScreenResolution()
	{
	}

	public void SetScreenResolution()
	{
	}

	public void SetCanvasScaleFactor()
	{
	}

	public float GetAutoUIScale()
	{
		return 0f;
	}

	public void RandomizeRandomNames()
	{
	}

	public string GetRandomName(int index)
	{
		return null;
	}

	public string GetGuestName(int index)
	{
		return null;
	}

	public string GetEntityName(int entityPrefabId)
	{
		return null;
	}

	public string GetTextSpriteId(TextSprite textSprite)
	{
		return null;
	}

	public string GetCurrencyTextSpriteFromAssetId(int assetId)
	{
		return null;
	}

	public string GetStatName(Stats stat)
	{
		return null;
	}

	public string GetStatNameShort(Stats stat)
	{
		return null;
	}

	public string GetStatSpriteId(Stats stat)
	{
		return null;
	}

	public Color GetStatColor(Stats stat)
	{
		return default(Color);
	}

	public UICharactersConfiguration.CharacterConfiguration GetCharacterConfiguration(int charId)
	{
		return null;
	}

	public string GetCharacterName(int charId)
	{
		return null;
	}

	public bool IsMouseOverUI()
	{
		return false;
	}

	public bool IsMousePressedOverUI()
	{
		return false;
	}

	public void SetMouseOverUI()
	{
	}

	public int GetCurrentCharBadgeAssetId(int charId)
	{
		return 0;
	}

	public void InitializeModalWindowGeneric(Action onConfirmAction, string headerTranslationKey, string titleTranslationKey, string confirmTranslationKey, string closeTranslationKey, string descTranslationKey = null, string desc2TranslationKey = null, Action onCancelAction = null, bool allowCancel = true)
	{
	}

	public UIProgressBarElement SpawnProgressBarElement()
	{
		return null;
	}

	public void EnableInterfacePing(bool isEnabled)
	{
	}

	public void EnableInterfaceFps(bool isEnabled)
	{
	}

	public void UpdatePing(float ping)
	{
	}

	public void UpdateFps(float fps)
	{
	}

	public static Color GetStatusColor(InfoStatus[] status, float value)
	{
		return default(Color);
	}

	public void UpdateBuildVersion(string version)
	{
	}

	public void UpdateServerBuildVersion(string version)
	{
	}

	public void OpenInteractableWindow(CanvasGroup canvasGroup, Canvas canvas, float duration = 0.5f, Action OnFinished = null)
	{
	}

	public void CloseInteractableWindow(CanvasGroup canvasGroup, Canvas canvas, float duration = 0.5f, Action OnFinished = null)
	{
	}

	[IteratorStateMachine(typeof(<ShowCanvasGroupCoroutine>d__174))]
	public IEnumerator ShowCanvasGroupCoroutine(CanvasGroup canvasGroup, Canvas canvas, bool open, float duration = 0.5f, Action OnFinished = null)
	{
		return null;
	}

	public ContentVisualizer3D SpawnVisualizer3D()
	{
		return null;
	}

	public void DestroyVisualizer3D(ContentVisualizer3D vis)
	{
	}

	public void ClearUnusedVisualizers3D()
	{
	}

	public void RemoveVis3dRawImageReferences(RawImage rawImage)
	{
	}
}

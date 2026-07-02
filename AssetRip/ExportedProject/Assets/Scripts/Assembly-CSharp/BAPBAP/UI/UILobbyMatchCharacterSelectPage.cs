using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Content;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyMatchCharacterSelectPage : UILobbyTabPage
	{
		public enum PreMatchState
		{
			MatchFound = 0,
			CharSelect = 1,
			SpawnSelect = 2,
			SpawnFinalize = 3,
			MatchFoundStartup = 4
		}

		[Serializable]
		public class Configuration
		{
			public UICharactersConfiguration CharacterConfiguration;

			public UILobbyContentEntry.Configuration SkinsEntryConfiguration;

			public SkinData SkinsData;

			public string CharLockInTranslationKey;

			public string SpawnLockInTranslationKey;

			public string GameStartingInTranslationKey;

			public string SpawnLeaderPickingTranslationKey;

			public string SpawnLeaderPromptTranslationKey;

			public string SpawnsLockedTranslationKey;

			public PlayerBannerData PlayerBannerData;

			public UILobbyCharacterSelectIcon.Configuration MatchStartCharacterSelectIconConfiguration;

			public MatchStartPanel.CharacterSelectPanelAnimation MatchStartCharacterSelectAnimation;

			public MatchStartPanel.FinalizeSpawnAnimation FinalizeSpawnAnimation;

			public UILobbyCharacterSelectAbility.Configuration CharacterSelectAbilityConfiguration;

			public UILobbyGameModifierIcon.Configuration GameModifierConfiguration;

			public UILobbyDimensionIcon.Configuration DimensionIconConfiguration;

			public SFXData matchCountdownTickSfx;

			public SFXData matchCountdownLastTickSfx;

			public Color matchStartCountdownTextColor;

			public Color matchStartCountdownTextLastTicksColor;

			public Material GreyscaleMaterial;

			public Color PlayerIdentityColor;

			public Color Teammate01IdentityColor;

			public Color Teammate02IdentityColor;

			public Color LockedTextColor;

			public Color PickingTextColor;

			public Sprite SpawnDeselectedSprite;

			public Sprite SpawnSelectedSprite;

			public string LockedTextString;

			public string PickingTextString;

			public bool DisableCharacterButtonWhenLocked;

			[Tooltip("Start Playing last tick fx from X seconds")]
			public int matchCountdownTickStartSeconds;

			public int matchCountdownLastTickStartSeconds;

			public float MatchFoundScreenUptime;

			public float PreMatchFoundWarmupUptime;

			public float SpawnTransitionDelayTime;

			public float SkinSelectOpenDelay;

			public float SpawnLockSFXDelayTime;

			public SFXData SpawnTransitionSFX;

			public SFXData SpawnLockSFX;

			public UISpawnSelection.Configuration SpawnSelectConfig;

			public float loadingTimeoutFailDuration;
		}

		[Serializable]
		public class MatchStartPanel
		{
			[Serializable]
			public class MatchPlayer
			{
				public GameObject GameObject;

				public RectTransform nameTextRect;

				public TMP_Text playerNameText;

				public TMP_Text charNameText;

				public TMP_Text charDescText;

				public Image charImage;

				public RectTransform charRectTransform;

				public GameObject ChangeAnimObj;

				public UIAlphaAnim ChangeAnimAlphaFade;

				public TransformScaleAnimation ChangeAnimTransformScale;

				public PlayerDisplay PlayerDisplay;

				[HideInInspector]
				public Color IdentityColor;
			}

			[Serializable]
			public class CharacterSelectPanelAnimation
			{
				public float Duration;

				public AnimationCurve CharacterPositionCurve;

				public AnimationCurve CharacterAlphaCurve;

				public float CharNameYPosOffset;

				public AnimationCurve CharNameTextYPosCurve;

				public AnimationCurve CharNameTextAlphaCurve;

				public AnimationCurve NameShadowScaleCurve;

				public AnimationCurve NameShadowAlphaCurve;

				public AnimationCurve CharPortraitScaleCurve;

				public Vector2 NameShadowScaleOffset;

				public Vector2 CharacterPositionOffset;

				public float CharPortraitScaleOffset;
			}

			[Serializable]
			public class FinalizeSpawnAnimation
			{
				public float Duration;

				public AnimationCurve FlashAlphaCurve;

				public AnimationCurve MapScaleCurve;

				public float MapScaleOffset;
			}

			public CanvasGroup canvasGroup;

			public UIAlphaFade uiAlphaFade;

			public Transform _chatParent;

			public MatchPlayer localPlayer;

			public MatchPlayer[] teammatePlayers;

			public TMP_Text matchStartingInText;

			public TMP_Text matchCountdownText;

			public TransformScaleSimpleAnimation matchCountdownTextTickAnim;
		}

		[Serializable]
		public class CharacterSelectPanel
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade UiAlphaFade;

			public Transform CharacterBackgroundParent;

			public Transform ModifierPreviewIconParent;

			public UIAlphaFade CharacterBackgroundUIAlphaFade;

			public CanvasGroup CharacterBGHiddenParent;

			public Button LockInButton;

			public Button SkinToggleButton;

			public Button SkinEquipButton;

			public TMP_Text MapPreviewNameText;

			public Image MapPreviewImage;

			public TMP_Text NameShadowText;

			public UIAlphaFade SpawnSelectAlphaFade;

			public UIAlphaFade CharSelectionObject;

			public Transform CharButtonsParent;

			public UIAlphaFade SkinSelectionObject;

			public Transform SkinButtonsParent;

			public RectTransform SkinButtonsParentRect;
		}

		[Serializable]
		public class SpawnSelectPanel
		{
			[Serializable]
			public class ModifierPanel
			{
				public CanvasGroup CanvasGroup;

				public UIAlphaFade InfoAlphaFade;

				public UIPosLerpFade PosLerpFade;

				public Transform IconParent;

				public TMP_Text HeaderText;

				public TMP_Text ModifierNameText;

				public TMP_Text DescriptionText;
			}

			public CanvasGroup CanvasGroup;

			public UIAlphaFade UiAlphaFade;

			public CanvasGroup FinalizeSpawnFlashAlpha;

			public Transform MapAnimScaleTransform;

			public UISpawnSelection SpawnSelection;

			public TextMeshProUGUI MapNameText;

			public TextMeshProUGUI HeaderText;

			public ModifierPanel ModifierInfo;
		}

		[Serializable]
		public class CharacterAbilityPanel
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade AlphaFade;

			public UIPosLerpFade PosLerpFade;

			public RectTransform AbilityParentRectTransform;

			public UIAlphaFade InfoAlphaFade;

			public UIPosLerpFade InfoPosLerpFade;

			public Transform AbilityIconsContentParent;

			public TMP_Text TitleText;

			public TMP_Text KeyText;

			public TMP_Text DescriptionText;
		}

		[Serializable]
		public class PlayerDisplay
		{
			public UILobbyPlayerContainer PlayerContainer;

			public GameObject PlayerDisplayObj;

			public CanvasGroup CanvasGroup;

			public TMP_Text LockText;

			public Image CharacterPortrait;

			public Image CharacterBorder;

			public Image SpawnIcon;

			public Animator LockInPortraitEffect;
		}

		public class Actions
		{
			public Action<int> SelectCharAction;

			public Action LockCharAction;

			public Action<Vector2> SpawnSelectAction;

			public Action<int, int> EquipSkinAction;
		}

		[CompilerGenerated]
		public sealed class _003CForceSkinSelectDelay_003Ed__118 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UILobbyMatchCharacterSelectPage _003C_003E4__this;

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
			public _003CForceSkinSelectDelay_003Ed__118(int _003C_003E1__state)
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

		[CompilerGenerated]
		public sealed class _003CStartWaitTimeoutFailCoroutine_003Ed__134 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float initialDelay;

			public UILobbyMatchCharacterSelectPage _003C_003E4__this;

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
			public _003CStartWaitTimeoutFailCoroutine_003Ed__134(int _003C_003E1__state)
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

		[SerializeField]
		public bool _enableSkinSelect;

		[SerializeField]
		[Header("Tab Page")]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade _uiLerpFade;

		[SerializeField]
		public UIAlphaFade _uiAlphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[SerializeField]
		public UIAlphaFade _matchFoundUIFade;

		[Header("Match Start")]
		[SerializeField]
		public MatchStartPanel _matchStartPanel;

		[SerializeField]
		public CharacterSelectPanel _charSelectPanel;

		[SerializeField]
		public SpawnSelectPanel _spawnSelectPanel;

		[SerializeField]
		public CharacterAbilityPanel _characterAbilityPanel;

		[NonSerialized]
		public UILobbyCharacterSelectIcon.Factory _charSelectIconFactory;

		[NonSerialized]
		public UILobbyCharacterSelectIcon[] _charSelectButtons;

		[NonSerialized]
		public UILobbyCharacterSelectAbility.Factory _charSelectAbilityFactory;

		[NonSerialized]
		public List<UILobbyCharacterSelectAbility> _charAbilityEntries;

		[NonSerialized]
		public UILobbyGameModifierIcon.Factory _modifierIconFactory;

		[NonSerialized]
		public UILobbyGameModifierIcon.Factory _modifierPreviewIconFactory;

		[NonSerialized]
		public List<UILobbyGameModifierIcon> _modifierButtons;

		[NonSerialized]
		public UILobbyDimensionIcon.Factory _dimensionIconFactory;

		[NonSerialized]
		public UILobbyDimensionIcon.Factory _dimensionPreviewIconFactory;

		[NonSerialized]
		public List<UILobbyDimensionIcon> _dimensionButtons;

		[NonSerialized]
		public UILobbyCharacterSelectIcon _selectedCharacterIcon;

		[NonSerialized]
		public UILobbyCharacterSelectAbility _selectedAbilityIcon;

		[NonSerialized]
		public UILobbyGameModifierIcon _selectedModifierIcon;

		[NonSerialized]
		public UILobbyDimensionIcon _selectedDimensionIcon;

		[NonSerialized]
		public List<UIAlphaFade> _characterBackgrounds;

		[NonSerialized]
		public int[] _gameModifierIds;

		[NonSerialized]
		public List<int> _dimensionIds;

		[NonSerialized]
		public CharacterSelectModel _data;

		[NonSerialized]
		public LobbyDataModel _lobbyDataModel;

		[NonSerialized]
		public LockerModel _lockerTabData;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobby _uiLobby;

		[NonSerialized]
		public UILobbyContentEntry.Pool _skinsPool;

		[NonSerialized]
		public List<UILobbyContentEntry> _skinsEntries;

		[NonSerialized]
		public UILobbyContentEntry _selectedContentEntry;

		[NonSerialized]
		public int _selectedCharIndex;

		[NonSerialized]
		public bool _matchStartAnimateCharSelect;

		[NonSerialized]
		public bool _matchStartAnimateCharLock;

		[NonSerialized]
		public bool _animateFinalizeSpawn;

		[NonSerialized]
		public float _matchStartAnimTime;

		[NonSerialized]
		public float _lockCharAnimTime;

		[NonSerialized]
		public float _finalizeSpawnAnimTime;

		[NonSerialized]
		public string _charLockInString;

		[NonSerialized]
		public string _spawnLockInString;

		[NonSerialized]
		public string _gameStartingInString;

		[NonSerialized]
		public string _spawnPickingString;

		[NonSerialized]
		public string _spawnPromptString;

		[NonSerialized]
		public string _spawnsLockedString;

		[NonSerialized]
		public PreMatchState _currentState;

		[NonSerialized]
		public Coroutine timeoutCoroutine;

		[NonSerialized]
		[NonSerialized]
		public Actions _actions;

		public override CanvasGroup CanvasGroup => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void Update()
		{
		}

		public void Initialise(CharacterSelectModel data)
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void SetActions(Actions actions)
		{
		}

		public void UpdateData(CharacterSelectModel data)
		{
		}

		public void SetPlayTabData(LobbyDataModel playTabData)
		{
		}

		public void SetLockerTabData(LockerModel lockerTabData)
		{
		}

		public void UpdateAvailableCharactersData()
		{
		}

		public void PopulateTeammates(List<PlayerModel> teammates)
		{
		}

		public void UpdateLocalPlayer(PlayerModel player)
		{
		}

		public void UpdateCharacterIconButtonsState()
		{
		}

		public void UpdateLockButtonState()
		{
		}

		public void UpdateEquipButtonState()
		{
		}

		public void UpdateGameModifiers()
		{
		}

		public void UpdateDimensions(DimensionData[] dimensionData)
		{
		}

		public void SetCharacterDisplay(MatchStartPanel.MatchPlayer display, PlayerModel player)
		{
		}

		public void SetSkinDisplay(UILobbyContentEntry skinContent)
		{
		}

		public void SetCountdownSeconds(int seconds)
		{
		}

		public void UpdateDataUnlockCharacter(int charId)
		{
		}

		public void UpdateMatchStartData()
		{
		}

		public void UpdateMapInfo(int unityGameModeId, int mapId)
		{
		}

		public int GetCharIndexByID(int charID)
		{
			return 0;
		}

		public void UpdateMatchmakingCharacter(string accountId, int characterId)
		{
		}

		public void UpdateMatchmakingLockedStatus(string accountId, bool isLocked)
		{
		}

		public void UpdateMatchmakingSpawnSelected(string accountId, Vector2 spawnLocation)
		{
		}

		public void UpdateMatchmakingFinalSpawnPoints(string[] accountIds, int[] spawnPositions)
		{
		}

		public void UpdateMatchmakingTransitionToSpawnSelect(int spawnSelectSeconds)
		{
		}

		public void OnCharacterButtonSelect(UILobbyCharacterSelectIcon icon, int lobbyCharIndex)
		{
		}

		public void OnCharacterLockButtonSelect()
		{
		}

		public void OnSpawnSelected(Vector2 spawnLocation)
		{
		}

		public void OnSkinEquipSelected()
		{
		}

		public void OnSkinSelect(UILobbyContentEntry content)
		{
		}

		public void OnCharacterAbilitySelected(int abilityIndex)
		{
		}

		public void OnModifierSelected(int modifierIndex)
		{
		}

		public void OnDimensionSelected(int dimensionButtonIndex, int dimensionId)
		{
		}

		public void OnSkinToggleButtonSelect()
		{
		}

		public void PlayPlayerCharChangeAnim(string playerAccountId)
		{
		}

		public void PlayCharDisplayChangeAnim(MatchStartPanel.MatchPlayer display)
		{
		}

		public void PlayLocalPlayerCharLockAnim()
		{
		}

		public void PlayCharLockEffects(PlayerDisplay display, PlayerModel player)
		{
		}

		public void AnimateCharacterLock(float t)
		{
		}

		public void AnimateCharacterSelect(float t)
		{
		}

		public void AnimateFinalizeSpawn(float t)
		{
		}

		public void SetPreMatchState(PreMatchState targetState)
		{
		}

		public void OpenMatchFoundPanel()
		{
		}

		public void CloseMatchFoundPanel()
		{
		}

		public void OpenPreMatchInterface()
		{
		}

		public void ClosePreMatchInterface()
		{
		}

		public void OpenSpawnSelect()
		{
		}

		public void CloseSpawnSelect()
		{
		}

		public void OpenCharacterSelect()
		{
		}

		public void CloseCharacterSelect()
		{
		}

		public void OpenSkinSelect()
		{
		}

		public void CloseSkinSelect()
		{
		}

		[IteratorStateMachine(typeof(_003CForceSkinSelectDelay_003Ed__118))]
		public IEnumerator ForceSkinSelectDelay()
		{
			return null;
		}

		public void OpenCharacterAbilityPanel()
		{
		}

		public void OpenModifiersPanel()
		{
		}

		public void InitializeCharacterAbilities(int charIndex)
		{
		}

		public void InitializeGameModifiers()
		{
		}

		public void InitializeDimensions()
		{
		}

		public float GetMatchFoundDisplayTime()
		{
			return 0f;
		}

		public float GetSpawnTransitionDelayTime()
		{
			return 0f;
		}

		public float GetCurrentTimerOffset()
		{
			return 0f;
		}

		public void SetChatParent()
		{
		}

		public void HideCharacterDisplay(PlayerDisplay display)
		{
		}

		public void ShowCharacterDisplay(PlayerDisplay display)
		{
		}

		public void UpdatePlayerDisplay(MatchStartPanel.MatchPlayer display, PlayerModel player)
		{
		}

		public void PopulateSkinButtons(int charId)
		{
		}

		public void UpdateSkinButtons()
		{
		}

		public void StartWaitTimeoutFail(float initialDelay = 0f)
		{
		}

		[IteratorStateMachine(typeof(_003CStartWaitTimeoutFailCoroutine_003Ed__134))]
		public IEnumerator StartWaitTimeoutFailCoroutine(float initialDelay = 0f)
		{
			return null;
		}

		public Configuration GetConfig()
		{
			return null;
		}
	}
}

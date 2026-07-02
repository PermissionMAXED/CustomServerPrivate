using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIGameMode : MonoBehaviour
	{
		[Serializable]
		public class InteractableInputInfo
		{
			public InputTarget target;

			public string strTranslationKey;
		}

		[CompilerGenerated]
		public sealed class _003CLoseWindowsCoroutine_003Ed__89 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIGameMode _003C_003E4__this;

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
			public _003CLoseWindowsCoroutine_003Ed__89(int _003C_003E1__state)
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
		public sealed class _003CRespawnWindowsCoroutine_003Ed__94 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIGameMode _003C_003E4__this;

			public float respawnTime;

			[NonSerialized]
			public int _003Ci_003E5__2;

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
			public _003CRespawnWindowsCoroutine_003Ed__94(int _003C_003E1__state)
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
		public sealed class _003CWinWindowCoroutine_003Ed__86 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UIGameMode _003C_003E4__this;

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
			public _003CWinWindowCoroutine_003Ed__86(int _003C_003E1__state)
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
		public UIManager uiManager;

		[SerializeField]
		[Header("Gamemode UIs")]
		public Transform gameModeUI;

		[SerializeField]
		public GameObject playerUI;

		[SerializeField]
		public GameObject minimapSection;

		[SerializeField]
		public GameObject minimapModeUIContainer;

		[SerializeField]
		public UIBattleRoyale battleRoyaleUI;

		[SerializeField]
		public UIFFA ffaUI;

		[SerializeField]
		public UIDevUtilities devUtilitiesUI;

		[SerializeField]
		public Canvas pingCanvas;

		[SerializeField]
		public Transform stickerHolder;

		[SerializeField]
		public UIAlphaFade gameStartingTextFade;

		[SerializeField]
		public TMP_Text gameStartingText;

		[Header("Interactable Info UI")]
		[SerializeField]
		public CanvasGroup interactableInfoCanvasGroup;

		[SerializeField]
		public Transform interactableInfoContainer;

		[SerializeField]
		public UIInteractableInputElement.Configuration interactableInputElementConfig;

		[SerializeField]
		[Header("Dev Lobby References")]
		public Canvas devLobbyCanvas;

		[SerializeField]
		public CanvasGroup devLobbyCanvasGroup;

		[Header("Countdown References")]
		[SerializeField]
		public GameObject countdownWindow;

		[SerializeField]
		public Animator countdownAnimator;

		[SerializeField]
		[Header("Match Win References")]
		public GameObject matchWinWindow;

		[SerializeField]
		public TMP_Text matchWinVictoryText;

		[SerializeField]
		public TMP_Text matchWinVictoryGlitchText;

		[SerializeField]
		public CountdownAnimationEvents winCountdownAnimEvents;

		[SerializeField]
		[Header("Match Lose References")]
		public Canvas matchLoseCanvas;

		[SerializeField]
		public CanvasGroup matchLoseCanvasGroup;

		[SerializeField]
		public GraphicRaycaster matchLoseGraphicRaycaster;

		[SerializeField]
		public TMP_Text matchLoseTitleText;

		[SerializeField]
		public Button spectateMatchLoseButton;

		[SerializeField]
		public TMP_Text spectateMatchLoseButtonText;

		[SerializeField]
		public Button exitToLobbyMatchLoseButton;

		[SerializeField]
		public TMP_Text exitToLobbyMatchLoseButtonText;

		[SerializeField]
		public float matchLostSfxVolume;

		[SerializeField]
		[Header("Respawn References")]
		public Canvas respawnCanvas;

		[SerializeField]
		public CanvasGroup respawnCanvasGroup;

		[SerializeField]
		public TMP_Text respawnCountText;

		[Header("Spectating References")]
		[SerializeField]
		public Canvas spectatingCanvas;

		[SerializeField]
		public CanvasGroup spectatingCanvasGroup;

		[SerializeField]
		public GraphicRaycaster spectatingGraphicRaycaster;

		[SerializeField]
		public TMP_Text spectatingText;

		[SerializeField]
		public TMP_Text spectatedPlayerText;

		[SerializeField]
		public Button prevPlayerButton;

		[SerializeField]
		public UISelectSfxElement prevPlayerButtonSfx;

		[SerializeField]
		public UIOnClickYPosLerp prevPlayerButtonClickLerp;

		[SerializeField]
		public Button nextPlayerButton;

		[SerializeField]
		public UISelectSfxElement nextPlayerButtonSfx;

		[SerializeField]
		public UIOnClickYPosLerp nextPlayerButtonClickLerp;

		[SerializeField]
		public Button exitToLobbySpectatorButton;

		[SerializeField]
		public TMP_Text exitToLobbySpectatorButtonText;

		[SerializeField]
		public GameObject spectatorCount;

		[SerializeField]
		public TMP_Text spectatorCountText;

		[Header("Other References")]
		[SerializeField]
		public Canvas fillBGCanvas;

		[SerializeField]
		public CanvasGroup fillBGCanvasGroup;

		[SerializeField]
		public Transform inGameMinigameHolder;

		[Header("Settings")]
		[SerializeField]
		public string gameStartingTranslationKey;

		[SerializeField]
		public string victoryTranslationKey;

		[SerializeField]
		public string defeatTranslationKey;

		[SerializeField]
		public string endMatchPlaceTranslationKey;

		[SerializeField]
		public string spectatingTranslationKey;

		[SerializeField]
		public string exitToLobbyTranslationKey;

		[SerializeField]
		public string spectateTranslationKey;

		[NonSerialized]
		public string endMatchPlaceStr;

		[NonSerialized]
		public InteractableInputInfo[] currentInteractableInputs;

		[NonSerialized]
		public UIInteractableInputElement.Pool interactableInputInfoPool;

		public void FixedUpdate()
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void TryUpdateIconKey(InputBinding inputBinding, bool isGamepad)
		{
		}

		public void UpdateTimer(float matchRemainingTime, Text text)
		{
		}

		public void TryLeaveGame()
		{
		}

		public void ClearWorldUI()
		{
		}

		public void OpenDevLobbyWindow()
		{
		}

		public void CloseDevLobbyWindow()
		{
		}

		public void InitializeInteractableInfo(InteractableInputInfo[] inputs)
		{
		}

		public void ShowInteractableInfo(InteractableInputInfo[] inputs)
		{
		}

		public void ShowInteractableInfo()
		{
		}

		public void HideInteractableInfo()
		{
		}

		public void InitializeGameStartingUI()
		{
		}

		public void StartUIMatchCountdown()
		{
		}

		public void SetUIMatchCountdown_2()
		{
		}

		public void SetUIMatchCountdown_1()
		{
		}

		public void SetUIMatchCountdown_GO()
		{
		}

		public void ShowGameStartingText(bool instant = false)
		{
		}

		public void HideGameStartingText(bool instant = false)
		{
		}

		public void OpenWinWindow()
		{
		}

		[IteratorStateMachine(typeof(_003CWinWindowCoroutine_003Ed__86))]
		public IEnumerator WinWindowCoroutine()
		{
			return null;
		}

		public void CloseWinWindow()
		{
		}

		public void OpenLoseWindow(int placementPosition)
		{
		}

		[IteratorStateMachine(typeof(_003CLoseWindowsCoroutine_003Ed__89))]
		public IEnumerator LoseWindowsCoroutine()
		{
			return null;
		}

		public void CloseLoseWindow(bool instant = false)
		{
		}

		public void OnCloseLoseWindowButton()
		{
		}

		public void InitializeLoseWindow(int placementPosition)
		{
		}

		public void OpenRespawnWindow(float respawnTime)
		{
		}

		[IteratorStateMachine(typeof(_003CRespawnWindowsCoroutine_003Ed__94))]
		public IEnumerator RespawnWindowsCoroutine(float respawnTime)
		{
			return null;
		}

		public void CloseRespawnWindow(bool instant = false)
		{
		}

		public void UpdateRespawnCounter(float respawnTime)
		{
		}

		public void OpenSpectatorUI()
		{
		}

		public void CloseSpectatorUI()
		{
		}

		public void SetSpectatorCount(int count)
		{
		}

		public void TriggerSpectatorPrevButtonPress()
		{
		}

		public void TriggerSpectatorNextButtonPress()
		{
		}

		public void HideGameplayHUD()
		{
		}

		public void ShowGameplayHUD()
		{
		}
	}
}

using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyGameModeButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyGameModeButton Prefab;

			public int PoolSize;

			public float highlightBannerScrollSpeed;

			public string defaultHighlightBannerSymbol;

			public string unavailableTranslationKey;

			public string eventInXTranslationKey;

			public string passwordTranslationKey;

			public string eventColorHex;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyGameModeButton> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public UILobbyGameModeButton Spawn(Translator translator, int gameModeId, Sprite illustration, Sprite illustrationBg, string nameTranslationKey, string typeTranslationKey, string highlightBannerSymbol, UnityAction selectAction, UnityAction hoverAction)
			{
				return null;
			}

			public void Despawn(UILobbyGameModeButton instance)
			{
			}
		}

		[SerializeField]
		public RectTransform rectTransform;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public Button button;

		[SerializeField]
		public EventTrigger eventTrigger;

		[SerializeField]
		public Image bgEdgeImage;

		[SerializeField]
		public Image illustrationImage;

		[SerializeField]
		public Image illustrationBgImage;

		[SerializeField]
		public AspectRatioFitter illustrationAspectRatio;

		[SerializeField]
		public Image highlightSelected;

		[SerializeField]
		public UIAlphaFade pressedFlashAlphaFade;

		[SerializeField]
		public RectTransform highlightBanner;

		[SerializeField]
		public UIPosLerpFade highlightBannerFade;

		[SerializeField]
		public TMP_Text highlightBannerText;

		[SerializeField]
		public bool scrollText;

		[SerializeField]
		public TMP_Text nameText;

		[SerializeField]
		public TMP_Text typeText;

		[SerializeField]
		public Image inactiveOverlayImage;

		[SerializeField]
		public TMP_Text inactiveBgText;

		[SerializeField]
		public GameObject eventStateHeaderObj;

		[SerializeField]
		public TMP_Text msgText;

		[SerializeField]
		public TMP_Text eventStateText;

		[SerializeField]
		public TMP_Text eventStateTimeText;

		[SerializeField]
		public TMP_Text comingSoonText;

		[SerializeField]
		public TMP_Text comingSoonText2;

		[SerializeField]
		public GameObject passwordObject;

		[SerializeField]
		public TMP_Text passwordPromptText;

		[NonSerialized]
		public UnityAction _selectAction;

		[NonSerialized]
		public UnityAction _hoverAction;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public int gameModeId;

		[NonSerialized]
		public DateTime? eventStartDate;

		[NonSerialized]
		public DateTime? eventEndDate;

		[NonSerialized]
		public bool eventEnabled;

		[NonSerialized]
		public bool eventCountdownEnabled;

		[NonSerialized]
		public DateTime eventCountdownUtcDate;

		[NonSerialized]
		public float eventCountdownTimer;

		[NonSerialized]
		public Action eventCountdownEndAction;

		[NonSerialized]
		public bool _highlighted;

		[NonSerialized]
		public float loopCyclePos;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		[NonSerialized]
		public string nameTranslationKey;

		[NonSerialized]
		public string typeTranslationKey;

		[NonSerialized]
		public string highlightBannerSymbol;

		public Button Button => null;

		public void Update()
		{
		}

		public void Build(Pool pool, Configuration configuration)
		{
		}

		public void Initialise(int gameModeId, Sprite illustration, Sprite illustrationBg, string nameTranslationKey, string typeTranslationKey, string highlightBannerSymbol, UnityAction selectAction, UnityAction hoverAction)
		{
		}

		public void FadeInDelay(float delay)
		{
		}

		public void SelectUIButton()
		{
		}

		public void DeselectUIButton()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void SetActive()
		{
		}

		public void SetInactive()
		{
		}

		public void SetInactiveTextDisabled()
		{
		}

		public void SetInactiveTextEnabled()
		{
		}

		public void SetComingSoonEnabled()
		{
		}

		public void SetComingSoonDisabled()
		{
		}

		public void SetEventEnabled()
		{
		}

		public void SetEventDisabled()
		{
		}

		public void SetEventDates(DateTime? startDate, DateTime? endDate)
		{
		}

		public void SetMessage(string msg)
		{
		}

		public void Reset()
		{
		}

		public void OnClick()
		{
		}

		public void Dispose()
		{
		}

		public void OnHover()
		{
		}

		public void OnUnhover()
		{
		}

		public void BeginStartEventCountdown()
		{
		}

		public void BeginEndEventCountdown()
		{
		}

		public void OnEventStarted()
		{
		}

		public void OnEventEnded()
		{
		}

		public void TogglePasswordUI(bool needsPassword)
		{
		}

		public bool GetCurrentEventState(out string eventStr, out string timeStr)
		{
			eventStr = null;
			timeStr = null;
			return false;
		}

		public bool IsCurrentEventEnabled()
		{
			return false;
		}

		public void StartCountdown(DateTime countdownDate, Action onCountdownEndAction)
		{
		}

		public void StopCountdown()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void OnDisable()
		{
		}
	}
}

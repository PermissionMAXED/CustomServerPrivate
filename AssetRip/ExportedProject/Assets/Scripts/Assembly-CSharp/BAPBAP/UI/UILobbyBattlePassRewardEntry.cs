using System;
using BAPBAP.Content;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyBattlePassRewardEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyBattlePassRewardEntry Prefab;

			public float unselectedWidth;

			public float selectedWidth;

			public float unselectedHeight;

			public float selectedHeight;

			public float selectAnimDuration;

			public AnimationCurve selectHeightCurve;

			public Color rewardImageLockedColor;

			public Color lockedBgPanelColor;

			public Color unlockedBgPanelColor;

			public Color selectedBgPanelColor;

			public Color selectedTextColor;

			public Color unselectedTextColor;
		}

		public class Factory
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public RectTransform _viewportTransform;

			public Factory(Configuration configuration, Transform parentTransform, RectTransform viewportTransform)
			{
			}

			public UILobbyBattlePassRewardEntry Create()
			{
				return null;
			}

			public UILobbyBattlePassRewardEntry Create(Color rarityColor, BAPBAP.Content.Content content, UnityAction selectAction, bool isUnlocked, bool isClaimed, int level)
			{
				return null;
			}
		}

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public UIPosLerpFade _posLerpFade;

		[SerializeField]
		public UIAlphaFade _alphaFade;

		[SerializeField]
		public RectTransform _rectTransform;

		[SerializeField]
		public RectTransform _panelRectTransform;

		[SerializeField]
		public LayoutElement _layoutElement;

		[SerializeField]
		public UISelectSfxElement _selectSfx;

		[SerializeField]
		public Button _rewardButton;

		[SerializeField]
		public Image _panelImage;

		[SerializeField]
		public Image _rarityColorBg;

		[SerializeField]
		public Image _lockedOverlayFill;

		[SerializeField]
		public Image _lockIcon;

		[SerializeField]
		public TMP_Text _levelText;

		[SerializeField]
		public Image _displayImage;

		[SerializeField]
		public Image _selectedHighlight;

		[SerializeField]
		public GameObject _claimHighlight;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public UnityAction _selectAction;

		[NonSerialized]
		public bool isSelected;

		[NonSerialized]
		public bool isUnlocked;

		[NonSerialized]
		public bool isClaimed;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		[NonSerialized]
		public bool animateSelect;

		[NonSerialized]
		public float selectTime;

		public void Update()
		{
		}

		public static UILobbyBattlePassRewardEntry Build(UILobbyBattlePassRewardEntry prefab, Transform parent)
		{
			return null;
		}

		public void Initialise(Color rarityColor, BAPBAP.Content.Content content, UnityAction selectAction, bool isUnlocked, bool isClaimed, int level)
		{
		}

		public void Dispose()
		{
		}

		public void FadeInDelay(float delay)
		{
		}

		public void OnSelectButton()
		{
		}

		public void Select()
		{
		}

		public void Deselect()
		{
		}

		public void Unlock()
		{
		}

		public void Lock()
		{
		}

		public void SetClaimed()
		{
		}

		public void SetUnclaimed()
		{
		}

		public void SetLevel(int level)
		{
		}
	}
}

using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyChallengeLivesEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public string panelTitleTranslationKey;

			public UILobbyChallengeLivesEntry prefab;

			public int poolSize;

			public string titleTranslationKey;

			public string claimTranslationKey;

			public string claimedTranslationKey;

			public string upNextTranslationKey;

			public string unavailableTranslationKey;

			public string progressTranslationKey;

			public string rewardIncompleteTranslationKey;

			public float claimAnimDuration;

			public float claimedHighlightAlpha;

			public float bgClaimedAlpha;

			public AnimationCurve ClaimHighlightAlphaCurve;

			public AnimationCurve ClaimedIconSizeCurve;

			public AnimationCurve ClaimSizeCurve;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyChallengeLivesEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public void Create()
			{
			}

			public UILobbyChallengeLivesEntry Spawn(Translator translator, string listingId, int numLives, int tierProgress, int tierId, bool isEnabled, bool isClaimed, bool isUnavailable, Action action)
			{
				return null;
			}

			public void Despawn(UILobbyChallengeLivesEntry instance)
			{
			}
		}

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public RectTransform rectTransform;

		[SerializeField]
		public Transform transformScale;

		[SerializeField]
		public Button rewardDisabledButton;

		[SerializeField]
		public GameObject rewardIncompleteObj;

		[SerializeField]
		public TMP_Text rewardIncompleteText;

		[SerializeField]
		public Button claimButton;

		[SerializeField]
		public GameObject claimedBg;

		[SerializeField]
		public TMP_Text claimedText;

		[SerializeField]
		public TMP_Text statusText;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public Image enabledImage;

		[SerializeField]
		public Image inactiveFillImage;

		[SerializeField]
		public GameObject claimObj;

		[SerializeField]
		public TMP_Text claimText;

		[SerializeField]
		public Image claimedHighlightImage;

		[SerializeField]
		public GameObject livesObj;

		[SerializeField]
		public GameObject[] livesIcons;

		[SerializeField]
		public Image claimedIcon;

		[SerializeField]
		public GameObject notificationIcon;

		[NonSerialized]
		public Action onClaimAction;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public string listingId;

		[NonSerialized]
		public bool isEnabled;

		[NonSerialized]
		public bool isClaimed;

		[NonSerialized]
		public bool isUnavailable;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		[NonSerialized]
		public bool _animateClaim;

		[NonSerialized]
		public float _claimAnimTime;

		[NonSerialized]
		public int numLives;

		[NonSerialized]
		public int tierProgress;

		[NonSerialized]
		public int tierId;

		[NonSerialized]
		public string titleStr;

		[NonSerialized]
		public string progressStr;

		[NonSerialized]
		public string upNextStr;

		[NonSerialized]
		public string unavailableStr;

		public void Update()
		{
		}

		public void AnimateClaim(float tn)
		{
		}

		public void Build(Pool pool)
		{
		}

		public void Initialise(Configuration configuration, string _listingId, int _numLives, int _tierProgress, int _tierId, bool _isEnabled, bool _isClaimed, bool _isUnavailable, Action action)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OnButtonSelect()
		{
		}

		public void SetClaimed(bool _isClaimed, bool playAnim = true)
		{
		}

		public void SetUnavailable(bool _isUnavailable)
		{
		}

		public void SetEnabled(bool _isEnabled)
		{
		}

		public void UpdateCurrentState()
		{
		}

		public void SetNotificationIcon(bool isEnabled)
		{
		}

		public bool NotificationIsEnabled()
		{
			return false;
		}

		public void FadeInDelay(float delay)
		{
		}

		public void Dispose()
		{
		}
	}
}

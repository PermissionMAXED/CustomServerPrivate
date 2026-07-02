using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyFriendEntry : MonoBehaviour, ISelectHandler, IEventSystemHandler, IDeselectHandler, ISubmitHandler
	{
		[Serializable]
		public class Configuration
		{
			[Serializable]
			public class StatusConfig
			{
				public string translationKey;

				public Color color;
			}

			public UILobbyFriendEntry Prefab;

			public int PoolSize;

			public float preferedHeight;

			public float cooldownDuration;

			public string gameTimeFormat;

			public float fadeAnimDuration;

			public AnimationCurve fadePosCurve;

			public AnimationCurve fadeLayoutHeightCurve;

			[NamedArray(typeof(PlayerStatus), 0)]
			public StatusConfig[] statusConfig;

			public Color InGameTimerColor;

			public Color OpenLobbyColor;

			public Color ClosedLobbyColor;

			public Color FullLobbyColor;

			public string OpenLobbyTranslationKey;

			public string CloseLobbyTranslationKey;

			public string FullLobbyTranslationKey;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyFriendEntry> _activeQueue;

			[NonSerialized]
			public Queue<UILobbyFriendEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public void Create()
			{
			}

			public UILobbyFriendEntry Spawn(Translator translator, Action<UILobbyFriendEntry> inviteAction, Action<RectTransform> openOptionsAction, Action<UILobbyFriendEntry> onSelectedAction, string accountId, string name, Texture2D avatar, Vector2 avatarUvOffset, Vector2 avatarUvSize, bool flipAvatar, bool isOnline, bool isLobbyOpen, int lobbyCount, int maxLobbyCount, PlayerStatus status)
			{
				return null;
			}

			public void Despawn(UILobbyFriendEntry instance)
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		public OnPointerListener _hoverButtonPointer;

		[SerializeField]
		public Button _inviteButton;

		[SerializeField]
		public RectTransform _fadeAnimPivot;

		[SerializeField]
		public LayoutElement _layoutElement;

		[SerializeField]
		public TMP_Text _nameText;

		[SerializeField]
		public Image _stateTextOnlineIcon;

		[SerializeField]
		public TMP_Text _stateText;

		[SerializeField]
		public GameObject _lobbyCountObject;

		[SerializeField]
		public TMP_Text _lobbyCountText;

		[SerializeField]
		public RawImage _avatarImage;

		[SerializeField]
		public AspectRatioFitter _avatarAspectRatio;

		[NonSerialized]
		public Action<UILobbyFriendEntry> _onInviteButtonAction;

		[NonSerialized]
		public Action<RectTransform> _onOpenOptionsAction;

		[NonSerialized]
		public Action<UILobbyFriendEntry> _onSelectedAction;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public float cooldownTimer;

		[NonSerialized]
		public int _gameStartedTime;

		[NonSerialized]
		public int _currentGameTime;

		[NonSerialized]
		public int _lobbyCount;

		[NonSerialized]
		public int _maxLobbyCount;

		[NonSerialized]
		public bool _openStatus;

		[NonSerialized]
		public string _openLobbyStr;

		[NonSerialized]
		public string _closedLobbyStr;

		[NonSerialized]
		public string _fullLobbyStr;

		[NonSerialized]
		public string _accountId;

		[NonSerialized]
		public int _statusId;

		[NonSerialized]
		public bool isSelected;

		[NonSerialized]
		public bool doFadeIn;

		[NonSerialized]
		public bool playFadeAnim;

		[NonSerialized]
		public float fadeAnimTime;

		public bool isOnCooldown => false;

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public static UILobbyFriendEntry Build(Configuration configuration, Pool pool, Transform parent)
		{
			return null;
		}

		public void Build(Configuration configuration, Pool pool)
		{
		}

		public void Initialise(Translator translator, Action<UILobbyFriendEntry> inviteAction, Action<RectTransform> openOptionsAction, Action<UILobbyFriendEntry> onSelectedAction, string accountId, string name, Texture2D avatar, Vector2 avatarOffset, Vector2 avatarSize, bool flipAvatar, bool isOnline, bool isLobbyOpen, int lobbyCount, int maxLobbyCount, PlayerStatus status)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OnSubmit(BaseEventData eventData)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public void UpdateState(bool isOnline, PlayerStatus status)
		{
		}

		public void UpdateAvatar(Texture2D avatar, bool flipAvatar, Vector2 avatarOffset, Vector2 avatarScale)
		{
		}

		public void SetInGameTimeActive(int gameStartTime)
		{
		}

		public void SetLobbyCount(int count, int maxCount)
		{
		}

		public void SetLobbyOpen(bool isOpen)
		{
		}

		public void UpdateLobbyInfo()
		{
		}

		public void AddInviteCooldown()
		{
		}

		public void OnInviteButtonPressed()
		{
		}

		public void OnOpenOptionsPressed()
		{
		}

		public void DoFadeIn()
		{
		}

		public void DoFadeOut()
		{
		}

		public void AnimateFadeOut(float nt)
		{
		}

		public void Dispose()
		{
		}
	}
}

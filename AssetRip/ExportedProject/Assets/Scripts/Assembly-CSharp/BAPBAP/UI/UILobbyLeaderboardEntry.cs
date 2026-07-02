using System;
using System.Collections.Generic;
using BAPBAP.Content;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyLeaderboardEntry : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyLeaderboardEntry Prefab;

			public PlayerBannerData PlayerBannerData;

			public int PoolSize;

			public int topPlayerPositionHighlight;

			public Gradient SpecialColorGradient;

			public float SpecialColorLerpDuration;

			public float bgAlpha;

			public Color playerNameColor;

			public Color selfPlayerNameColor;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyLeaderboardEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public RectTransform _viewportTransform;

			public Pool(Configuration configuration, Transform parentTransform, RectTransform viewportTransform)
			{
			}

			public UILobbyLeaderboardEntry Spawn(string titleTranslationKey, int position, string username, int bannerId, int kills, int wins, Sprite rankIcon, string rankTier, int points, bool isSelf, Color backgroundColor, Action clickAction, bool showPoints, bool showRanks, bool playTopPlayerAnim)
			{
				return null;
			}

			public void Despawn(UILobbyLeaderboardEntry instance)
			{
			}
		}

		[SerializeField]
		public LayoutElement _layoutElement;

		[SerializeField]
		public Image _backgroundImage;

		[SerializeField]
		public Image _selectHighlightImage;

		[SerializeField]
		public Button _button;

		[SerializeField]
		public TMP_Text _positionText;

		[SerializeField]
		public TMP_Text _usernameText;

		[SerializeField]
		public TMP_Text _killsText;

		[SerializeField]
		public TMP_Text _winsText;

		[SerializeField]
		public Image _rankIcon;

		[SerializeField]
		public Image _bannerImage;

		[SerializeField]
		public TMP_Text _rankTierText;

		[SerializeField]
		public TMP_Text _pointsText;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Action _clickAction;

		[NonSerialized]
		public RectTransform _viewportTransform;

		[NonSerialized]
		public bool _animate;

		[NonSerialized]
		public int _position;

		[NonSerialized]
		public float _time;

		[NonSerialized]
		public string _titleTranslationKey;

		public void Update()
		{
		}

		public void Build(Pool pool, Configuration configuration, RectTransform viewportTransform)
		{
		}

		public void Initialise(string titleTranslationKey, int position, string username, int bannerId, int kills, int wins, Sprite rankIcon, string rankTier, int points, bool isSelf, Color backgroundColor, Action clickAction, bool showPoints, bool showRanks, bool playTopPlayerAnim)
		{
		}

		public void InitializeFromData(Configuration configuration, string titleTranslationKey, int position, string username, int bannerId, int kills, int wins, Sprite rankIcon, string rankTier, int points, bool isSelf, Color backgroundColor, Action clickAction, bool showPoints, bool showRanks, bool playTopPlayerAnim)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void Select()
		{
		}

		public void SelectUI()
		{
		}

		public void DeselectUI()
		{
		}

		public void Dispose()
		{
		}
	}
}

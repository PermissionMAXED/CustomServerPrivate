using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UILobbyLiveWinnerFeedEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyLiveWinnerFeedEntry Prefab;

			public int PoolSize;

			public Color playersColor;

			public Color killsColor;

			public string playersWonWithXKillsTranslationKey;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UILobbyLiveWinnerFeedEntry> _activeQueue;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyLiveWinnerFeedEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public string _killsHex;

			[NonSerialized]
			public string _playersHex;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public void Spawn(Translator translator, string usernames, int squadKills, DateTime time)
			{
			}

			public void Despawn(UILobbyLiveWinnerFeedEntry instance)
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		public RectTransform anchorRectTransform;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public TMP_Text _msgText;

		[SerializeField]
		public TMP_Text _timeText;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public DateTime time;

		[NonSerialized]
		public float timeElapsed;

		[NonSerialized]
		public string wonWithXKillsStr;

		public void Update()
		{
		}

		public static UILobbyLiveWinnerFeedEntry Build(UILobbyLiveWinnerFeedEntry prefab, Transform parent)
		{
			return null;
		}

		public void Initialise(Pool pool, Configuration configuration, string usernames, int squadKills, DateTime time, string playersHex, string killsHex)
		{
		}

		public void Localise(Translator translator, Configuration configuration)
		{
		}

		public void Dispose()
		{
		}
	}
}

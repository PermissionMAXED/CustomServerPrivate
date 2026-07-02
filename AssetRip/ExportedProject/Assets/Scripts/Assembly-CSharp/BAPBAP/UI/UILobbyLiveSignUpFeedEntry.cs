using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UILobbyLiveSignUpFeedEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyLiveSignUpFeedEntry Prefab;

			public int PoolSize;

			public string usernameColorHex;

			public string playerSignedUpTranslationKey;

			public string playerRedeemedLiveTranslationKey;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UILobbyLiveSignUpFeedEntry> _activeQueue;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyLiveSignUpFeedEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public void Spawn(Translator translator, string username, int discriminator, int actionId, int value, DateTime time)
			{
			}

			public void Despawn(UILobbyLiveSignUpFeedEntry instance)
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
		public TMP_Text _usernameText;

		[SerializeField]
		public TMP_Text _signedUpText;

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
		public string playerRedeemedLiveStr;

		[NonSerialized]
		public string playerSignedUpStr;

		public void Update()
		{
		}

		public static UILobbyLiveSignUpFeedEntry Build(UILobbyLiveSignUpFeedEntry prefab, Transform parent)
		{
			return null;
		}

		public void Initialise(Pool pool, Configuration configuration, string username, int discriminator, int actionId, int value, DateTime _time)
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

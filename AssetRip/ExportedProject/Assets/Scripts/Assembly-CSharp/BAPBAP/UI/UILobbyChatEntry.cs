using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UILobbyChatEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyChatEntry Prefab;

			public int PoolSize;

			public Color UsernameColor;

			public Color SystemColor;

			public float duration;

			public float fadeDuration;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UILobbyChatEntry> _activeQueue;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public float _fontSize;

			[NonSerialized]
			public Queue<UILobbyChatEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public string _systemColor;

			[NonSerialized]
			public string _usernameColor;

			[NonSerialized]
			public string _messageColor;

			public Pool(Configuration configuration, Transform parentTransform, float fontSize)
			{
			}

			public void Spawn(string chatTypeString, string chatTypeColorHex, string username, string usernameColorHex, string message, bool system, bool startFadeOut)
			{
			}

			public void Despawn(UILobbyChatEntry instance)
			{
			}

			public void Dispose()
			{
			}

			public UILobbyChatEntry[] GetAllInactiveQueueEntriesInArray()
			{
				return null;
			}
		}

		[SerializeField]
		public TMP_Text _text;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _config;

		[NonSerialized]
		public bool allowFade;

		[NonSerialized]
		public float fadeTime;

		public void Update()
		{
		}

		public void Initialise(Configuration config, Pool pool, float fontSize, string chatTypeColor, string usernameColor, string systemColor, string chatType, string username, string message, bool isSystemMsg)
		{
		}

		public void StartFadeOut()
		{
		}

		public void AllowAlphaFadeOut(bool allow)
		{
		}

		public void ForceVisible()
		{
		}

		public void Dispose()
		{
		}
	}
}

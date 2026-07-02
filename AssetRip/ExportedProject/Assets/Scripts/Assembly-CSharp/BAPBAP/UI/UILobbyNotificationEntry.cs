using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyNotificationEntry : MonoBehaviour
	{
		public enum MessageType
		{
			Error = 0,
			Success = 1
		}

		[Serializable]
		public class Configuration
		{
			public UILobbyNotificationEntry Prefab;

			public int PoolSize;

			public Sprite typeSuccessIcon;

			public Sprite typeErrorIcon;

			public Color typeSuccessIconColor;

			public Color typeErrorIconColor;

			public float offscreenPos;

			public float notificationTtl;

			public float inAnimDuration;

			public float outAnimDuration;

			public AnimationCurve inAnimPosCurve;

			public AnimationCurve outAnimPosCurve;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UILobbyNotificationEntry> _activeQueue;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyNotificationEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public Sprite _typeErrorIcon;

			[NonSerialized]
			public Color _typeErrorIconColor;

			[NonSerialized]
			public Sprite _typeSuccessIcon;

			[NonSerialized]
			public Color _typeSuccessIconColor;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public void Spawn(string message, MessageType messageType)
			{
			}

			public void Despawn(UILobbyNotificationEntry instance)
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
		public TMP_Text _text;

		[SerializeField]
		public Image _typeIcon;

		[SerializeField]
		public Button _closeButton;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public float ttl;

		[NonSerialized]
		public bool _animate;

		[NonSerialized]
		public bool _openOrClosing;

		[NonSerialized]
		public float _time;

		[NonSerialized]
		public float basePos;

		public void Update()
		{
		}

		public static UILobbyNotificationEntry Build(UILobbyNotificationEntry prefab, Transform parent)
		{
			return null;
		}

		public void Initialise(Pool pool, Configuration configuration, Sprite typeIcon, Color typeIconColor, string message)
		{
		}

		public void OpenNotification()
		{
		}

		public void CloseNotification()
		{
		}

		public void Dispose()
		{
		}
	}
}

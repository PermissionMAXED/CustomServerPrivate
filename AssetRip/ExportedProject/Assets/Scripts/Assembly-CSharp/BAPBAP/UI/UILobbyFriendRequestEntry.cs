using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyFriendRequestEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyFriendRequestEntry Prefab;

			public int PoolSize;

			public string incomingFriendRequestTranslationKey;

			public float preferedHeight;

			public float fadeAnimDuration;

			public AnimationCurve fadePosCurve;

			public AnimationCurve fadeLayoutHeightCurve;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyFriendRequestEntry> _activeQueue;

			[NonSerialized]
			public Queue<UILobbyFriendRequestEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public void Create()
			{
			}

			public UILobbyFriendRequestEntry Spawn(Translator translator, string accountId, Action acceptAction, Action rejectAction, string name, Color color, Texture2D avatar, Vector2 avatarUvOffset, Vector2 avatarUvScale, bool flipAvatar, bool isOnline)
			{
				return null;
			}

			public void Despawn(UILobbyFriendRequestEntry instance)
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		public Button _hoverButton;

		[SerializeField]
		public Button _acceptButton;

		[SerializeField]
		public Button _rejectButton;

		[SerializeField]
		public RectTransform _fadeAnimPivot;

		[SerializeField]
		public LayoutElement _layoutElement;

		[SerializeField]
		public TMP_Text _nameText;

		[SerializeField]
		public TMP_Text _incomingFriendRequestText;

		[SerializeField]
		public RawImage _avatarImage;

		[SerializeField]
		public AspectRatioFitter _avatarAspectRatio;

		[NonSerialized]
		public Action onAcceptButtonAction;

		[NonSerialized]
		public Action onRejectButtonAction;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public string _accountId;

		[NonSerialized]
		public bool doFadeIn;

		[NonSerialized]
		public bool playFadeAnim;

		[NonSerialized]
		public float fadeAnimTime;

		public void Update()
		{
		}

		public static UILobbyFriendRequestEntry Build(Configuration configuration, Pool pool, Transform parent)
		{
			return null;
		}

		public void Build(Configuration configuration, Pool pool)
		{
		}

		public void Initialise(string accountId, Action acceptAction, Action rejectAction, string name, Color color, Texture2D avatar, Vector2 avatarUvOffset, Vector2 avatarUvScale, bool isOnline, bool flipAvatar)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OnInviteButtonPressed()
		{
		}

		public void OnRejectButtonPressed()
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

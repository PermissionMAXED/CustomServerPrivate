using System;
using System.Collections.Generic;
using BAPBAP.Pooling;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIKillFeedEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UIKillFeedEntry Prefab;

			public int PoolSize;

			public LocalPrefabPool.ResizeStrategy ResizeStrategy;

			public float duration;

			public float spacing;

			public float spawnYOffset;

			public int elementHeight;

			public Color localPlayerColor;

			public Color allyColor;

			public Color enemyColor;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UIKillFeedEntry> _activeQueue;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UIKillFeedEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public UIKillFeedEntry Spawn(Color killerColor, Color killedColor, string killerName, string killedName, Sprite killerIcon, Sprite killedIcon, int actionId)
			{
				return null;
			}

			public void Despawn(UIKillFeedEntry instance)
			{
			}

			public void Dispose()
			{
			}

			public Queue<UIKillFeedEntry> GetAllActiveQueueEntries()
			{
				return null;
			}
		}

		[Header("References")]
		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public RectTransform elementTransform;

		[Header("Content References")]
		[SerializeField]
		public RectTransform contentRect;

		[SerializeField]
		public RectTransform bgArrowRect;

		[SerializeField]
		public RectTransform bgArrowPosRect;

		[SerializeField]
		public CanvasGroup contentCanvasGroup;

		[SerializeField]
		public TMP_Text killerText;

		[SerializeField]
		public TMP_Text killedText;

		[SerializeField]
		public Image killerCharIcon;

		[SerializeField]
		public LayoutElement killerCharIconLayout;

		[SerializeField]
		public Image killedCharIcon;

		[SerializeField]
		public Image actionIcon;

		[SerializeField]
		public Sprite killSprite;

		[SerializeField]
		public Sprite downSprite;

		[Header("Anim References")]
		[SerializeField]
		public Image colorAnimImage;

		[SerializeField]
		public Image killerAccentColor;

		[SerializeField]
		public Image killedAccentColor;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float yPosition;

		[NonSerialized]
		public int dirtyFrames;

		[NonSerialized]
		public Configuration _config;

		[NonSerialized]
		public Pool _pool;

		public void Start()
		{
		}

		public void Build(Pool _pool, Configuration _config)
		{
		}

		public void Initialise(Color killerColor, Color killedColor, string killerName, string killedName, Sprite killerIcon, Sprite killedIcon, int actionId)
		{
		}

		public void PushFeedDown(float amount)
		{
		}

		public void LateUpdate()
		{
		}

		public void DoMessageAnimation()
		{
		}

		public void Dispose()
		{
		}
	}
}

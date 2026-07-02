using System;
using System.Collections.Generic;
using BAPBAP.Local;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIPopUpEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UIPopUpEntry Prefab;

			public int PoolSize;
		}

		public class Pool
		{
			[NonSerialized]
			public Queue<UIPopUpEntry> _activeQueue;

			public List<UIPopUpEntry> currentEntries;

			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UIPopUpEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public UIPopUpEntry Spawn(Vector3 targetPos, string text, UIPopUp.PointType type, float duration, float randomRadOffset, float scale = 1f, int points = 0, Transform target = null)
			{
				return null;
			}

			public void Despawn(UIPopUpEntry instance)
			{
			}

			public void Dispose()
			{
			}
		}

		[SerializeField]
		[Header("References")]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public TMP_Text displayText;

		[SerializeField]
		public ScaleTimer scaleTimer;

		[Header("Settings")]
		[SerializeField]
		public float duration;

		[SerializeField]
		public float fadeOutStart;

		[SerializeField]
		public float yHeight;

		[SerializeField]
		public float xDirSpeed;

		[SerializeField]
		public Vector2 screenOffset;

		[SerializeField]
		public Vector3 worldOffset;

		[SerializeField]
		public bool isWorldSpace;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public Camera cam;

		[NonSerialized]
		public float UIScale;

		[NonSerialized]
		public Vector2 screenPos;

		[NonSerialized]
		public Vector3 worldPos;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float ySpeed;

		[NonSerialized]
		public float randomXDir;

		[NonSerialized]
		public Vector2 originalScreenOffset;

		[NonSerialized]
		public float originalScale;

		[NonSerialized]
		public float originalTimerStartingScale;

		[NonSerialized]
		public int points;

		[NonSerialized]
		public Transform target;

		[NonSerialized]
		public UIPopUp.PointType pointType;

		[NonSerialized]
		public Configuration _config;

		[NonSerialized]
		public Pool _pool;

		public void Build(Pool _pool, Configuration _config)
		{
		}

		public void Initialise(Vector3 targetPos, string text, UIPopUp.PointType type, float duration, float randomRadOffset, float scale = 1f, int points = 0, Transform target = null)
		{
		}

		public bool IsSameType(Transform target, UIPopUp.PointType type)
		{
			return false;
		}

		public void LateUpdate()
		{
		}

		public void UpdatePosition()
		{
		}

		public void Dispose()
		{
		}
	}
}

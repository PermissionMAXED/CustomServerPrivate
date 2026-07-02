using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAlphaFadeTimed : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public CanvasGroup canvasGroup;

		[Header("Settings")]
		[Tooltip("Should it fade in or fade out? Default to false (fade out)")]
		[SerializeField]
		public bool doFadeIn;

		[Tooltip("When the current time gets below this start duration, the fade will start and lerp with normalized time")]
		[SerializeField]
		public float fadeOutStart;

		[SerializeField]
		public float duration;

		[Tooltip("If enabled, alpha value will be multiplied by the fade out duration. Used for when we want to modify the original alpha value, not override it with a 1-0 lerp. If this is set to false, the latter will happen")]
		[SerializeField]
		public bool doAlphaPercent;

		[SerializeField]
		public bool isTimeScaled;

		[Tooltip("When completing the fade out, should this gameObject get disabled?")]
		[SerializeField]
		public bool disableGameObjectOnEnd;

		[NonSerialized]
		public float timer;

		public Action onFinishedFadeAction;

		public void SetDuration(float duration)
		{
		}

		public void OnEnable()
		{
		}

		public void Play()
		{
		}

		public void Update()
		{
		}
	}
}

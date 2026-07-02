using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace BAPBAP.UI
{
	public class UIAlphaFade : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		[Header("Settings")]
		public bool doFadeIn;

		[SerializeField]
		public float duration;

		[SerializeField]
		[FormerlySerializedAs("disableGameObjectOnEnd")]
		public bool disableGameObjectOnFadeOutEnd;

		[SerializeField]
		public bool setAlphaOnAwake;

		public Action onFinishedFadeAction;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void DoFadeIn(bool forceIn = false)
		{
		}

		public void DoFadeOut(bool forceOut = false)
		{
		}

		public void FadeInInstant()
		{
		}

		public void FadeOutInstant()
		{
		}

		public void Update()
		{
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAlphaFadeOnEnable : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public CanvasGroup canvasGroup;

		[Header("Settings")]
		[SerializeField]
		public bool doFadeIn;

		[SerializeField]
		public float duration;

		[NonSerialized]
		public bool animate;

		[NonSerialized]
		public float timer;

		public void OnEnable()
		{
		}

		public void Update()
		{
		}
	}
}

using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIGameMessageElement : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public Image colorImage;

		[SerializeField]
		public Transform colorImageTransform;

		[SerializeField]
		public TMP_Text text;

		[Header("Settings")]
		[SerializeField]
		public AnimationCurve widthCurve;

		[SerializeField]
		public AnimationCurve alphaCurve;

		[NonSerialized]
		public float duration;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool initialized;

		[NonSerialized]
		public Action onMessageEnded;

		public void Initialize(Action onMessageEndedAction)
		{
		}

		public void ActivateMessage(string textString, float _duration, Color color)
		{
		}

		public void Update()
		{
		}

		public void Animate(float nt)
		{
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAlphaAnim : MonoBehaviour
	{
		[Header("References")]
		public CanvasGroup canvasGroup;

		[Header("Settings")]
		public AnimationCurve alphaCurve;

		public float duration;

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

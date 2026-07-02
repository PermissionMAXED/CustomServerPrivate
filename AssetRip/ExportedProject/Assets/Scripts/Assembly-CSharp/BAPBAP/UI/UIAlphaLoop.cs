using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAlphaLoop : MonoBehaviour
	{
		[Header("References")]
		public CanvasGroup canvasGroup;

		[Header("Settings")]
		public AnimationCurve alphaCurve;

		public float loopDuration;

		[NonSerialized]
		public float timer;

		public void Update()
		{
		}
	}
}

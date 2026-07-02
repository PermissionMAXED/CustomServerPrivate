using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAnchorWidthLerp : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public RectTransform rectTransform;

		[SerializeField]
		[Range(0f, 1f)]
		public float startWidthPerc;

		[SerializeField]
		[Range(0f, 1f)]
		public float targetWidthPerc;

		[SerializeField]
		[Header("Settings")]
		public bool doFadeIn;

		[SerializeField]
		public bool disableOnCompleted;

		[SerializeField]
		public float duration;

		[SerializeField]
		public AnimationCurve lerpCurve;

		[NonSerialized]
		public float timer;

		public void SetStartWidth(float width)
		{
		}

		public void SetTargetWidth(float width)
		{
		}

		public void DoFadeIn(bool forceIn = false)
		{
		}

		public void DoFadeOut()
		{
		}

		public void Update()
		{
		}

		public void SetWidthPerc(float percValue)
		{
		}
	}
}

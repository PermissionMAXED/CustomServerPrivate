using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIPosLerpFade : MonoBehaviour
	{
		public enum Axis
		{
			Vertical = 0,
			Horizontal = 1
		}

		[SerializeField]
		[Header("References")]
		public RectTransform rectTransform;

		[SerializeField]
		public float startPosition;

		[SerializeField]
		public float endPosition;

		[Tooltip("Which axis should this position lerp be performed on")]
		[SerializeField]
		[Header("Settings")]
		public Axis lerpAxis;

		[SerializeField]
		public bool doFadeIn;

		[SerializeField]
		public bool loop;

		[SerializeField]
		public bool disableOnCompleted;

		[SerializeField]
		public float duration;

		[SerializeField]
		public AnimationCurve lerpCurve;

		[SerializeField]
		public bool setPosOnAwake;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void DoFadeIn(bool forceIn = false)
		{
		}

		public void DoFadeOut()
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

		public void Animate(float nt)
		{
		}
	}
}

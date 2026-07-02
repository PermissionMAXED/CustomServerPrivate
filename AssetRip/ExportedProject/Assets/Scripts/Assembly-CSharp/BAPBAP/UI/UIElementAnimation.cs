using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIElementAnimation : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public Image image;

		[SerializeField]
		public RectTransform rectTransform;

		[Header("Settings")]
		[SerializeField]
		public float duration;

		[SerializeField]
		public bool disableOnCompleted;

		[Header("Anim Config")]
		[SerializeField]
		public bool animateColor;

		[ConditionalHide("animateColor", true)]
		[SerializeField]
		public AnimationCurve colorCurve;

		[ConditionalHide("animateColor", true)]
		[SerializeField]
		public Color startColor;

		[ConditionalHide("animateColor", true)]
		[SerializeField]
		public Color endColor;

		[SerializeField]
		public bool animateAlpha;

		[ConditionalHide("animateAlpha", true)]
		[SerializeField]
		public AnimationCurve alphaCurve;

		[SerializeField]
		public bool animateYPos;

		[ConditionalHide("animateYPos", true)]
		[SerializeField]
		public AnimationCurve yPosCurve;

		[ConditionalHide("animateYPos", true)]
		[SerializeField]
		public float yPosOffset;

		[SerializeField]
		public bool animateXPos;

		[ConditionalHide("animateXPos", true)]
		[SerializeField]
		public AnimationCurve xPosCurve;

		[ConditionalHide("animateXPos", true)]
		[SerializeField]
		public float xPosOffset;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void Play()
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

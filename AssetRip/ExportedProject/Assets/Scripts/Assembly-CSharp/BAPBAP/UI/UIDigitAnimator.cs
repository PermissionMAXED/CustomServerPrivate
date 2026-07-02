using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIDigitAnimator : MonoBehaviour
	{
		public class Digit
		{
			public GameObject gameObject;

			public Transform transform;

			public TMP_Text text;

			public float timer;

			public string digit;
		}

		[SerializeField]
		public float duration;

		[SerializeField]
		public AnimationCurve lerpCurve;

		[Tooltip("The direction of the of the position anim. False = down, true = up")]
		[SerializeField]
		public bool posDirection;

		[SerializeField]
		public AnimationCurve colorCurve;

		[SerializeField]
		public Color baseColor;

		[SerializeField]
		public Color animColor;

		[SerializeField]
		public Transform digitParent;

		[SerializeField]
		public GameObject digitPrefab;

		[NonSerialized]
		public List<Digit> digits;

		[NonSerialized]
		public RectTransform rectTransform;

		public void Awake()
		{
		}

		public void Initialize(int initialDigitCount)
		{
		}

		public void CreateDigit()
		{
		}

		public void UpdateNumber(int numberValue, bool instant = false)
		{
		}

		public void UpdateNumber(string numberStr, bool instant = false)
		{
		}

		public void Update()
		{
		}

		public void AnimateDigit(Digit digit, float nt)
		{
		}
	}
}

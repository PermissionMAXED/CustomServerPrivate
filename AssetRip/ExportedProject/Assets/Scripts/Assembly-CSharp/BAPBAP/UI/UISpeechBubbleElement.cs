using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UISpeechBubbleElement : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public UIFollowWorldPosition worldFollowPos;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIAlphaFadeTimed alphaFadeOutTimed;

		[SerializeField]
		public TMP_Text text;

		[SerializeField]
		public LayoutElement layoutElement;

		[SerializeField]
		[Header("Config")]
		public float revealSpeedPerChar;

		[SerializeField]
		public float maxTextWidth;

		[NonSerialized]
		public Transform target;

		[NonSerialized]
		public string textStr;

		[NonSerialized]
		public float revealProgress;

		[NonSerialized]
		public int totalLength;

		[NonSerialized]
		public int prevStrLength;

		public void Awake()
		{
		}

		public void Initialize(string textStr, Transform target, float duration = 3f)
		{
		}

		public void Update()
		{
		}

		public void SetText(string textStr)
		{
		}

		public void UpdateTextWrapLayout(float textWidth)
		{
		}
	}
}

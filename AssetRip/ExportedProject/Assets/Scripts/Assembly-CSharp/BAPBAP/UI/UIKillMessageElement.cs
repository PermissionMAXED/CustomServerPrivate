using System;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIKillMessageElement : MonoBehaviour
	{
		public TMP_Text killedText;

		public TMP_Text totalKillsText;

		public TMP_Text squadEliminatedText;

		public UISpriteAnimator skullAnimation;

		public UIAlphaFadeTimed skullAnimationAlpha;

		[NonSerialized]
		public CanvasGroup canvasGroup;

		public UIMessages UIMessages;

		[HideInInspector]
		public float timer;

		[NonSerialized]
		public float startTimer;

		[NonSerialized]
		public float startTimerDuration;

		public bool isTimeScaled;

		[HideInInspector]
		public bool initialized;

		public void Awake()
		{
		}

		public void Initialize(string killedName, string totalKills, bool squadEliminated, float timer_, bool downed = false)
		{
		}

		public void LateUpdate()
		{
		}
	}
}

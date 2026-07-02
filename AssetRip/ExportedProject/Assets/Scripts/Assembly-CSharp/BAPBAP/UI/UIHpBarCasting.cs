using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIHpBarCasting : MonoBehaviour
	{
		[Header("UI")]
		[SerializeField]
		public Image castingBarFill;

		[SerializeField]
		public Image castingResultBarFill;

		[SerializeField]
		public CanvasGroup castingBarGroup;

		[SerializeField]
		public CanvasGroup castingResultBarGroup;

		[SerializeField]
		public Color castingColor;

		[SerializeField]
		public Color channelingColor;

		[SerializeField]
		public Color ultimateColor;

		[SerializeField]
		public Color successColor;

		[SerializeField]
		public Color failColor;

		[SerializeField]
		[Header("Configs")]
		public float castResultDuration;

		[SerializeField]
		[Tooltip("When casting succeeded/failed we want to linearly fade the bar to a solid color, how long should the fade be?")]
		public float castResultFadeDuration;

		[SerializeField]
		public AnimationCurve castResultFadeCurve;

		[SerializeField]
		[Tooltip("How long to wait before fading the bar when inactive?")]
		public float inactiveFadeDuration;

		[SerializeField]
		public AnimationCurve inactiveFadeCurve;

		[NonSerialized]
		public float castResultTimeElapsed;

		[NonSerialized]
		public bool isCastResultDone;

		[NonSerialized]
		public int prevTickNum;

		[NonSerialized]
		public float barTimeElapsed;

		[NonSerialized]
		public bool isLerpingDone;

		[NonSerialized]
		public float barTimeCache;

		[NonSerialized]
		public float barDurationCache;

		[NonSerialized]
		public bool isChannelingCache;

		[NonSerialized]
		public bool doCastingFadeOut;

		[NonSerialized]
		public float castingFadeStartTime;

		[NonSerialized]
		public float castResultFadeStartTime;

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Reset()
		{
		}

		public void TriggerCastingSuccess()
		{
		}

		public void TriggerCastingFail()
		{
		}

		public void ToggleCastingTime(bool shown)
		{
		}

		public void UpdateCastingBar(int tickNum, float progress, float duration, bool isChanneling, bool isUltimate)
		{
		}

		public void ManagedLateUpdate()
		{
		}
	}
}

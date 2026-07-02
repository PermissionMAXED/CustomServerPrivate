using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class FroggyTonguePosition : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public TongueJumpAbility tongueAbility;

		[SerializeField]
		public Transform tongueStart;

		[SerializeField]
		public Transform tongueTip;

		[Tooltip("The y position for the tongue when sticking to a target")]
		[Header("Settings")]
		[SerializeField]
		public float tongueYPosHeight;

		[SerializeField]
		public float hitPosLerpSpd;

		[SerializeField]
		public float throwDuration;

		[SerializeField]
		public float retractingDuration;

		[Header("Anim Settings")]
		[SerializeField]
		public Vector3 startTipRotation;

		[SerializeField]
		public Vector3 tipRotation;

		[SerializeField]
		public AnimationCurve xScaleCurve;

		[SerializeField]
		public AnimationCurve yScaleCurve;

		[SerializeField]
		public AnimationCurve zScaleCurve;

		[SerializeField]
		public AnimationCurve retractXScaleCurve;

		[SerializeField]
		public AnimationCurve retractYScaleCurve;

		[SerializeField]
		public AnimationCurve retractZScaleCurve;

		[NonSerialized]
		public float maxThrowDistance;

		[NonSerialized]
		public Vector2 lerpedHitPos;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool retracting;

		[NonSerialized]
		public bool retractFirstFrame;

		public void Awake()
		{
		}

		public void SetRetracting()
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void LateUpdate()
		{
		}
	}
}

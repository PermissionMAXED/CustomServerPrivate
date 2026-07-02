using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class TombstoneObjectView : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public GameObject meshPivot;

		[SerializeField]
		public Transform meshRotation;

		[SerializeField]
		public AudioSource landingAudioSource;

		[SerializeField]
		public Animation landingAnimation;

		[SerializeField]
		[Tooltip("The root landing vfx/sfx object. It starts disabled and get enabled when starting the landing animation")]
		public GameObject landingFxRoot;

		[SerializeField]
		[Tooltip("The root looping vfx/sfx object. It starts enabled, but gets disabled during the landing animation")]
		public GameObject loopFxRoot;

		[SerializeField]
		public SpriteRenderer blobShadowAlpha;

		[SerializeField]
		public LabelElement labelElement;

		[Header("Settings")]
		[Tooltip("How much to wait to start the landing animation when initialized")]
		[SerializeField]
		public float landDelayDuration;

		[Tooltip("How much delay to play the landing sfx, in order to line up the audio landing impact with the anim hitting the ground")]
		[SerializeField]
		public float sfxPlayDelay;

		[SerializeField]
		[Tooltip("Normalized random rotation factor")]
		[Range(0f, 0.25f)]
		public float randomRotationAmount;

		[NonSerialized]
		public float startTimer;

		[NonSerialized]
		public bool startTimerEnabled;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void Update()
		{
		}

		public void PlayLandingAnim()
		{
		}

		public void InitializeLandingAnim()
		{
		}

		public void SetRandomRotation(Vector3 newRotation)
		{
		}

		public void SetLabelStr(string labelStr)
		{
		}
	}
}

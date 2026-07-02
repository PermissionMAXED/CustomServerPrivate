using System;
using System.Collections.Generic;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	[RequireComponent(typeof(BoxCollider))]
	public class SlidingDoor : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public AudioSource doorAudioSource;

		[SerializeField]
		public AudioSource jingleAudioSource;

		[SerializeField]
		public GameObject doorLeft;

		[SerializeField]
		public GameObject doorRight;

		[Header("Settings")]
		[SerializeField]
		public Vector3 doorLeftOpenPosition;

		[SerializeField]
		public Vector3 doorRightOpenPosition;

		[SerializeField]
		public float animDuration;

		[SerializeField]
		public float audioJingleCd;

		[SerializeField]
		public float immediateSpeedMultiplier;

		[SerializeField]
		public string[] openForTags;

		[SerializeField]
		public string[] openForImmediateTags;

		[SerializeField]
		public AnimationCurve lerpCurve;

		[Header("Audio")]
		[SerializeField]
		public AudioClipData openAudioData;

		[SerializeField]
		public AudioClipData closeAudioData;

		[NonSerialized]
		public List<Collider> knownColliders;

		[NonSerialized]
		public Vector3 doorLeftClosedPosition;

		[NonSerialized]
		public Vector3 doorRightClosedPosition;

		[NonSerialized]
		public bool open;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float speedMultiplier;

		[NonSerialized]
		public float audioJingleTimer;

		[NonSerialized]
		public Dictionary<string, bool> openers;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public bool HasValidTag(string tag)
		{
			return false;
		}

		public void Update()
		{
		}

		public void AnimateDoors(float factor)
		{
		}
	}
}

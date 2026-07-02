using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.UI
{
	public class BapLogoClickController : MonoBehaviour
	{
		[Serializable]
		public class ClickEvent
		{
			[SerializeField]
			public string name;

			[Range(0f, 1f)]
			public float normProbability;

			[Min(0.5f)]
			public float duration;

			public AudioClipData[] audioData;

			public GameObject clickAnimObj;

			public UnityEvent animObjAction;
		}

		[NonSerialized]
		public AudioSource _audioSource;

		[SerializeField]
		public ClickEvent[] clickEvents;

		[NonSerialized]
		public float time;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void Play()
		{
		}
	}
}

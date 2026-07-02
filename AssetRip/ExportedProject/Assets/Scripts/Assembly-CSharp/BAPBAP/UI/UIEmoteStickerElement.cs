using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIEmoteStickerElement : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public UIFollowWorldPosition worldFollow;

		[SerializeField]
		public MonoBehaviour[] fadeInAnimations;

		[SerializeField]
		public MonoBehaviour[] fadeOutAnimations;

		[Header("Settings")]
		[SerializeField]
		public float fadeOutDuration;

		[NonSerialized]
		public float timer;

		public void Play()
		{
		}

		public void Update()
		{
		}

		public void DoDestroy()
		{
		}
	}
}

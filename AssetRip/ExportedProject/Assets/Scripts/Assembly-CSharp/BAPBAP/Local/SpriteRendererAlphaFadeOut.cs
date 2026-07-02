using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class SpriteRendererAlphaFadeOut : MonoBehaviour
	{
		public SpriteRenderer spriteRenderer;

		public float fadeOutStart;

		public float duration;

		[NonSerialized]
		public float timer;

		public bool isTimeScaled;

		[SerializeField]
		public bool disableGameObjectOnEnd;

		public void SetDuration(float duration)
		{
		}

		public void OnEnable()
		{
		}

		public void Update()
		{
		}

		public void SetAlpha(float a)
		{
		}
	}
}

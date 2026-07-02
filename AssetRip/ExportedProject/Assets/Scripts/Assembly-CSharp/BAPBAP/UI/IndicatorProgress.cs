using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class IndicatorProgress : MonoBehaviour
	{
		[SerializeField]
		public SpriteRenderer spriteRenderer;

		[NonSerialized]
		public float ttl;

		[NonSerialized]
		public bool doTtlAlpha;

		[NonSerialized]
		public float initialAlpha;

		[NonSerialized]
		public float startWidth;

		[NonSerialized]
		public float ttlTimer;

		public void Initialize(float ttl, bool doTtlAlpha = true, float initialAlpha = 0.25f, float startWidth = 0f)
		{
		}

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}

		public void SetColor(Color color)
		{
		}
	}
}

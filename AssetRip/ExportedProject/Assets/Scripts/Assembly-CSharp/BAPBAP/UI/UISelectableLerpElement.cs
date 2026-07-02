using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UISelectableLerpElement : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public Image elementImage;

		[SerializeField]
		[Header("Settings")]
		public float hoverScale;

		[SerializeField]
		public float hoverLerpSpeed;

		[SerializeField]
		public Color baseColor;

		[SerializeField]
		public Color hoverColor;

		[NonSerialized]
		public float targetScale;

		[NonSerialized]
		public Color targetColor;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void OnBeginHover(bool forceIn = false)
		{
		}

		public void OnStopHover()
		{
		}

		public void SetHover()
		{
		}

		public void SetUnHover()
		{
		}
	}
}

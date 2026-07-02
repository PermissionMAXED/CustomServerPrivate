using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIAbilityReady : MonoBehaviour
	{
		public CanvasGroup canvasGroup;

		public RectTransform rectTransform;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public Vector2 startingPos;

		[NonSerialized]
		public Vector3 originalPos;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void Update()
		{
		}
	}
}

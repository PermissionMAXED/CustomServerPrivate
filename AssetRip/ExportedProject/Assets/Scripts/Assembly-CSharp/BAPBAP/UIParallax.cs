using System;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP
{
	public class UIParallax : MonoBehaviour
	{
		[SerializeField]
		public RectTransform parentTransform;

		[SerializeField]
		public float parallaxFactor;

		[SerializeField]
		public bool horizontal;

		[SerializeField]
		public bool vertical;

		[NonSerialized]
		public UIManager uiManager;

		public void Awake()
		{
		}

		public void Update()
		{
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIElementWiggle : MonoBehaviour
	{
		public RectTransform element;

		public float randomAmount;

		public float wiggleSpeed;

		[NonSerialized]
		public Vector2 startPos;

		[NonSerialized]
		public float timer;

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}
	}
}

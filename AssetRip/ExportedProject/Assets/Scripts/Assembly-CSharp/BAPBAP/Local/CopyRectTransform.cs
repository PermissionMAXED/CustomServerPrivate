using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CopyRectTransform : MonoBehaviour
	{
		[SerializeField]
		public RectTransform followRectTransform;

		[NonSerialized]
		public RectTransform rectTransform;

		[NonSerialized]
		public Vector2 offsetAnchoredPos;

		[NonSerialized]
		public float offsetZRot;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void LateUpdate()
		{
		}
	}
}

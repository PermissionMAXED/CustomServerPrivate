using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class CircleConeShapeSprite : MonoBehaviour, IShape
	{
		[SerializeField]
		public SpriteRenderer spriteRenderer;

		[SerializeField]
		public float border;

		[NonSerialized]
		public float edgeSize;

		[NonSerialized]
		public bool initialized;

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void SetSize(Vector2 halfScale, float halfAngle)
		{
		}
	}
}

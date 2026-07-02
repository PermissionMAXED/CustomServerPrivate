using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class CircleShapeSprite : MonoBehaviour, IShape
	{
		[SerializeField]
		public SpriteRenderer spriteRenderer;

		[NonSerialized]
		public Transform spriteTransform;

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

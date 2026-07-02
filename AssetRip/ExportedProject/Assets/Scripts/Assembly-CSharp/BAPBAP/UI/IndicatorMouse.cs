using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class IndicatorMouse : MonoBehaviour
	{
		[NonSerialized]
		public PostCameraMouse postCamMouse;

		[SerializeField]
		public Transform mouseIndicator;

		[SerializeField]
		public Transform mouseOffsetPivot;

		[SerializeField]
		public Transform rectOffsetPivot;

		[SerializeField]
		public Transform baseIndicator;

		[SerializeField]
		public bool setMouseToMaxDistance;

		[NonSerialized]
		public IShape mouseShape;

		[NonSerialized]
		public IShape baseShape;

		[NonSerialized]
		public float maxDistance;

		[NonSerialized]
		public bool pointTowardsDirection;

		[NonSerialized]
		public bool collidesWithObstacles;

		[NonSerialized]
		public LayerMask obstaclesMask;

		[NonSerialized]
		public RaycastHit hit;

		public void Awake()
		{
		}

		public void Setup(Vector2 mouseHalfScale, Vector2 baseHalfScale, Vector2 offset, float _maxDistance, float angleSpread, bool _rotateWithDirection, bool _collidesWithObstacles = false)
		{
		}

		public void SetBaseSize(Vector2 baseHalfScale)
		{
		}

		public void SetMaxDistance(float d)
		{
		}

		public void LateUpdate()
		{
		}
	}
}

using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class IndicatorDirectional : MonoBehaviour
	{
		[NonSerialized]
		public PostCameraMouse postCamMouse;

		[SerializeField]
		public Transform indicator;

		[NonSerialized]
		public IShape shape;

		[NonSerialized]
		public bool isExpanding;

		[NonSerialized]
		public bool doCollision;

		[NonSerialized]
		public bool clampToMouse;

		[NonSerialized]
		public bool followMouse;

		[NonSerialized]
		public Vector2 halfScale;

		[NonSerialized]
		public Vector3 offset;

		[NonSerialized]
		public LayerMask obstaclesMask;

		[NonSerialized]
		public RaycastHit hit;

		public void Awake()
		{
		}

		public void LateUpdate()
		{
		}

		public void Setup(Vector2 _halfScale, Vector2 _offset, bool _doCollision, bool _isExpanding, bool _clampToMouse, bool _followMouse)
		{
		}
	}
}

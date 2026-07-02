using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIHpBarFollow : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public Camera mainCamera;

		[NonSerialized]
		public Transform followTarget;

		[NonSerialized]
		public Vector3 worldPos;

		[SerializeField]
		public Vector3 worldOffset;

		[SerializeField]
		public Vector2 screenOffset;

		[SerializeField]
		public bool disableObjOnLostTarget;

		[SerializeField]
		public GameObject gameObjectAttached;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnEnable()
		{
		}

		public void SetFollowTarget(Transform target)
		{
		}

		public void SetFollowPosition(Vector3 worldPosition)
		{
		}

		public void SetWorldHeight(float height)
		{
		}

		public void ManagedLateUpdate()
		{
		}

		public void UpdatePosition()
		{
		}
	}
}

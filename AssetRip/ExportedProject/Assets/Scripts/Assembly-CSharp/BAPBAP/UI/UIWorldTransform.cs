using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIWorldTransform : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[SerializeField]
		public Vector3 worldOffset;

		[SerializeField]
		public Vector3 screenOffset;

		public void Awake()
		{
		}

		public void UpdatePosition(Transform worldTransform)
		{
		}

		public void UpdateWorldPosition(Vector3 worldPosition)
		{
		}
	}
}

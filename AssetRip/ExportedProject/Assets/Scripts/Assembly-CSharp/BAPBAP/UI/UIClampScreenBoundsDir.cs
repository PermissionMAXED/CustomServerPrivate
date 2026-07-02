using System;
using UnityEngine;
using UnityEngine.Events;

namespace BAPBAP.UI
{
	public class UIClampScreenBoundsDir : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public RectTransform rectTransform;

		[Header("Settings")]
		[SerializeField]
		public Vector2 viewportMargin;

		[SerializeField]
		public bool aimTowardsOffscreenTarget;

		[SerializeField]
		public bool hideIfTargetInScreen;

		[SerializeField]
		public GameObject hideRootObj;

		[Header("Begin/End Directional Events")]
		[SerializeField]
		public UnityEvent onDirEnabled;

		[SerializeField]
		public UnityEvent onDirDisabled;

		[NonSerialized]
		public RectTransform viewportRect;

		public void Awake()
		{
		}

		public void LateUpdate()
		{
		}

		public void UpdateScreenBounds()
		{
		}

		public void SetDirectionIconEnabled(bool isEnabled)
		{
		}
	}
}

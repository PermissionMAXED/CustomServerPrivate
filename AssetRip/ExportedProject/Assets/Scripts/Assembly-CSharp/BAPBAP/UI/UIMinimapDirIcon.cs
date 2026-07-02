using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIMinimapDirIcon : UIMinimapIcon
	{
		[NonSerialized]
		public UIMinimap uiMinimap;

		[Header("Directional References")]
		[Tooltip("Sets this icon rect parented to the attached transform, and keeps it oriented straight")]
		[SerializeField]
		public RectTransform iconRect;

		[SerializeField]
		[Tooltip("Transform to rotate in direction")]
		public RectTransform dirTransform;

		[SerializeField]
		[Tooltip("Toggles this transform active/deactive")]
		public RectTransform followDirParent;

		[Header("Settings")]
		public bool autoUpdateIconDirection;

		public bool autoResetDirectionRotation;

		public override void Awake()
		{
		}

		public void LateUpdate()
		{
		}

		public void ToggleDirectionIcon(bool isEnabled)
		{
		}

		public void OnItemPingDirEnabled()
		{
		}

		public void OnItemPingDirDisabled()
		{
		}

		public void SetDirectionAlongMinimapEdge(Vector2 posAlongMinimapRadius)
		{
		}
	}
}

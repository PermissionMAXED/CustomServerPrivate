using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UITooltip : MonoBehaviour
	{
		public enum TooltipAnchor
		{
			Top = 0,
			Bottom = 1,
			Left = 2,
			Right = 3
		}

		[SerializeField]
		[Header("UI References")]
		public Transform tooltipParent;

		[SerializeField]
		[Header("References")]
		public GameObject tooltipPrefab;

		[SerializeField]
		[Header("Settings")]
		public Vector2 tooltipOffset;

		[SerializeField]
		public float horScreenMargin;

		[SerializeField]
		public float verScreenMargin;

		[NonSerialized]
		public RectTransform currentTooltipTr;

		[NonSerialized]
		public UITooltipElement currentTooltipElement;

		[NonSerialized]
		public InputBinding expandInputBinding;

		public void CreateTooltipObj()
		{
		}

		public void Update()
		{
		}

		public void ShowTooltip(Color titleColor, string title, string desc, Vector3 screenPos, bool fadeIn = true)
		{
		}

		public void ShowTooltip(Color titleColor, string title, string desc, RectTransform rectTr, bool fadeIn = true)
		{
		}

		public void ShowTooltip(Color titleColor, string title, string subTitle, string desc, string bottomText, RectTransform rectTr, bool fadeIn = true)
		{
		}

		public void ShowTooltip(Color titleColor, string title, string subTitle, string desc, string extraDesc, string expandDesc, string bottomText, RectTransform rectTr, bool fadeIn = true, bool bgColorEnabled = false, Color bgColor = default(Color), bool isHeaderEnabled = false, string headerStr = "", Color headerColor = default(Color), Sprite headerIcon = null, int rarityStars = 0, TooltipAnchor anchor = TooltipAnchor.Bottom, Vector3 screenPos = default(Vector3))
		{
		}

		public static void DoScreenBoundsClamp(RectTransform tooltipRect, float horScreenMargin, float verScreenMargin)
		{
		}

		public Vector2 GetAnchorPivot(TooltipAnchor anchor)
		{
			return default(Vector2);
		}

		public Vector2 GetAnchorVector(TooltipAnchor anchor)
		{
			return default(Vector2);
		}

		public void HideTooltip()
		{
		}
	}
}

using System;
using UnityEngine;

namespace BAPBAP.Items
{
	public class ItemObjectHighlight : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public Transform itemScaleTransform;

		[SerializeField]
		public ItemObjectVisualizer itemVisualizer;

		[Header("Highlight Settings")]
		[SerializeField]
		public float highlightScale;

		[SerializeField]
		public Color outlineColor;

		[SerializeField]
		public float outlineSize;

		[SerializeField]
		public float lerpSpeed;

		[NonSerialized]
		public bool isHighlighted;

		[NonSerialized]
		public Color originalOutlineColor;

		[NonSerialized]
		public float originalOutlineSize;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float targetScale;

		public void Awake()
		{
		}

		public void Reset()
		{
		}

		public void SetTierColor(Color tierColor)
		{
		}

		public void SetHighlight(bool _isHighlighted, bool applyColor = true)
		{
		}

		public void LateUpdate()
		{
		}
	}
}

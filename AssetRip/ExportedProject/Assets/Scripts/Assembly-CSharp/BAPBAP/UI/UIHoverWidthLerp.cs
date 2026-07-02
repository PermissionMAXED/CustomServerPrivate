using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	[RequireComponent(typeof(EventTrigger))]
	public class UIHoverWidthLerp : MonoBehaviour
	{
		[NonSerialized]
		public Button uiButton;

		[NonSerialized]
		public EventTrigger eventTrigger;

		[SerializeField]
		[Header("References")]
		[Tooltip("The rect transform that will be width lerped. If null, will default to this component's rect transform")]
		public RectTransform elementRect;

		[Header("Settings")]
		[SerializeField]
		public float duration;

		[SerializeField]
		public float hoverWidthAmount;

		[SerializeField]
		public float hoverLerpSpeed;

		[SerializeField]
		public bool onlyIfInteractable;

		[NonSerialized]
		public float originalWidth;

		[NonSerialized]
		public float hoverWidth;

		[NonSerialized]
		public bool isHovering;

		[NonSerialized]
		public bool animateEnabled;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void OnDisable()
		{
		}

		public void Update()
		{
		}

		public void OnBeginHover()
		{
		}

		public void OnStopHover()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}

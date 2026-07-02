using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIHoverScale : MonoBehaviour
	{
		[NonSerialized]
		public Selectable selectable;

		[NonSerialized]
		public EventTrigger eventTrigger;

		[Header("References")]
		[Tooltip("The rect transform that will be scale lerped. If null, will default to this component's rect transform")]
		[SerializeField]
		public RectTransform elementRect;

		[Header("Settings")]
		[SerializeField]
		public float duration;

		[SerializeField]
		public float hoverSizeAmount;

		[SerializeField]
		public float hoverLerpSpeed;

		[SerializeField]
		public bool onlyIfInteractable;

		[SerializeField]
		public bool unhoverOnClick;

		[NonSerialized]
		public float originalSize;

		[NonSerialized]
		public float hoverSize;

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

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}
	}
}

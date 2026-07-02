using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIHoverYPosLerp : MonoBehaviour
	{
		[NonSerialized]
		public Button uiButton;

		[NonSerialized]
		public EventTrigger eventTrigger;

		[Header("References")]
		[Tooltip("The rect transform that will be position lerped. If null, will default to this component's rect transform")]
		[SerializeField]
		public RectTransform elementRect;

		[Header("Settings")]
		[SerializeField]
		public float duration;

		[SerializeField]
		public float hoverYPosAmount;

		[SerializeField]
		public float hoverLerpSpeed;

		[SerializeField]
		public bool onlyIfInteractable;

		[SerializeField]
		public bool unhoverOnClick;

		[NonSerialized]
		public float originalYPos;

		[NonSerialized]
		public float hoverYPos;

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

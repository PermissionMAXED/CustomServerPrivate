using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	[RequireComponent(typeof(EventTrigger))]
	public class UIOnClickYPosLerp : MonoBehaviour
	{
		[NonSerialized]
		public Button uiButton;

		[NonSerialized]
		public EventTrigger eventTrigger;

		[SerializeField]
		[Header("References")]
		[Tooltip("The transform pivot that will be position lerped. If null, will default to this component's transform")]
		public RectTransform animRectTransform;

		[Header("Settings")]
		[SerializeField]
		public float duration;

		[SerializeField]
		public float clickedYPosAmount;

		[SerializeField]
		public float clickDownLerpSpeed;

		[SerializeField]
		public float clickUpLerpSpeed;

		[SerializeField]
		public bool forceClickedPosOnRelease;

		[SerializeField]
		public bool onlyIfInteractable;

		[Tooltip("If true, provide an serialized original y position. If false, original Y Pos will be get from Start.")]
		[SerializeField]
		public bool serializeOriginalYPos;

		[ConditionalHide("serializeOriginalYPos", true)]
		[SerializeField]
		public float originalYPos;

		[NonSerialized]
		public float clickedYPos;

		[NonSerialized]
		public bool isClicked;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void OnDisable()
		{
		}

		public void Update()
		{
		}

		public void OnClickPressed()
		{
		}

		public void OnClickReleased()
		{
		}

		public void ForceReleaseClick()
		{
		}

		public void OnApplicationFocus(bool focusStatus)
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

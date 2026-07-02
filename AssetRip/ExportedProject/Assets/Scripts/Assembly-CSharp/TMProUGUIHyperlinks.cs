using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
[RequireComponent(typeof(EventTrigger))]
[DisallowMultipleComponent]
public class TMProUGUIHyperlinks : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
{
	[SerializeField]
	public Color32 hoveredColor;

	[SerializeField]
	public Color32 pressedColor;

	[SerializeField]
	public Color32 usedColor;

	[SerializeField]
	public Color32 usedHoveredColor;

	[SerializeField]
	public Color32 usedPressedColor;

	[NonSerialized]
	public List<Color32[]> startColors;

	[NonSerialized]
	public TextMeshProUGUI textMeshPro;

	[NonSerialized]
	public Dictionary<int, bool> usedLinks;

	[NonSerialized]
	public int hoveredLinkIndex;

	[NonSerialized]
	public int pressedLinkIndex;

	[NonSerialized]
	public Camera mainCamera;

	[NonSerialized]
	public EventTrigger eventTrigger;

	[NonSerialized]
	public CanvasGroup canvasGroup;

	[NonSerialized]
	public bool interactable;

	public bool openWebsite;

	public bool callAction;

	public UnityEvent<int> onClickAction;

	public void Awake()
	{
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnDisable()
	{
	}

	public void LateUpdate()
	{
	}

	public void HoverLink(int linkIndex)
	{
	}

	public void UnhoverLink()
	{
	}

	public int GetLinkIndex()
	{
		return 0;
	}

	public List<Color32[]> SetLinkColor(int linkIndex, Color32 color)
	{
		return null;
	}

	public void ResetLinkColor(int linkIndex, List<Color32[]> startColors)
	{
	}
}

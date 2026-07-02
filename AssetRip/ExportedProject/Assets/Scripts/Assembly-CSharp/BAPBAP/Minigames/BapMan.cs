using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.Minigames
{
	public class BapMan : MonoBehaviour
	{
		[NonSerialized]
		public EventTrigger eventTrigger;

		[Header("References")]
		[SerializeField]
		public BapManController bapManGamePrefab;

		[Header("Settings")]
		[SerializeField]
		public KeyCode startKey;

		[NonSerialized]
		public BapManController bapManGame;

		[NonSerialized]
		public bool mouseIsHovering;

		public void Awake()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void Update()
		{
		}
	}
}

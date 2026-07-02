using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BAPBAP.Minigames
{
	public class DuckyRun : MonoBehaviour
	{
		[NonSerialized]
		public EventTrigger eventTrigger;

		[SerializeField]
		[Header("References")]
		public DuckyRunController duckyRunGamePrefab;

		[SerializeField]
		[Header("Settings")]
		public KeyCode startKey;

		[NonSerialized]
		public DuckyRunController duckyRunGame;

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

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UISpeechBubble : MonoBehaviour
	{
		[SerializeField]
		[Header("UI References")]
		public Transform canvasParent;

		[Header("Settings")]
		[SerializeField]
		public int poolSize;

		[Header("References")]
		[SerializeField]
		public GameObject uiSpeechBubblePrefab;

		[NonSerialized]
		public List<UISpeechBubbleElement> elementPool;

		[NonSerialized]
		public List<UISpeechBubbleElement> activeEntries;

		public void Awake()
		{
		}

		public UISpeechBubbleElement InstantiateUIElement()
		{
			return null;
		}

		public UISpeechBubbleElement SpawnPooledElement()
		{
			return null;
		}

		public void DespawnPooledLabel(UISpeechBubbleElement element)
		{
		}

		public void ShowSpeechBubble(Transform target, string textStr)
		{
		}

		public void ShowSpeechBubble(Transform target, string[] textStrOptions, int rngSeed = 0)
		{
		}
	}
}

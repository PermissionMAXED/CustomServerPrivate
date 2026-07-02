using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIWorldLabel : MonoBehaviour
	{
		[Header("UI References")]
		[SerializeField]
		public Transform labelCanvasParent;

		[Header("Settings")]
		[SerializeField]
		public int labelPoolSize;

		[SerializeField]
		[Header("References")]
		public GameObject uiWorldLabelPrefab;

		[NonSerialized]
		public List<UIWorldLabelElement> labelPool;

		public void Awake()
		{
		}

		public UIWorldLabelElement InstantiateLabelUIElement()
		{
			return null;
		}

		public UIWorldLabelElement SpawnPooledLabel()
		{
			return null;
		}

		public void DespawnPooledLabel(UIWorldLabelElement labelElement)
		{
		}

		public void ShowLabelUI(LabelElement element, bool fadeIn = true)
		{
		}

		public void HideLabelUI(LabelElement element, bool fadeOut = true)
		{
		}
	}
}

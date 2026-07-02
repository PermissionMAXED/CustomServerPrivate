using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIInteractableWindows : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public Transform interactableWindowParent;

		[Header("Upgrade Window References")]
		[SerializeField]
		public GameObject interactablePopUpWindowPrefab;

		[Header("General Settings")]
		[SerializeField]
		public Color successColor;

		[SerializeField]
		public Color errorColor;

		[NonSerialized]
		public UIInteractableTooltip interactableTooltip;

		public void Awake()
		{
		}
	}
}

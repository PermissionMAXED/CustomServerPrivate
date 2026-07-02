using System;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Local
{
	public class SelectableController : MonoBehaviour
	{
		public SelectableTracker selectableTracker;

		public LayerMask selectableMask;

		public ISelectable hoveredSelectable;

		public Camera camera;

		public bool shouldSelect;

		[NonSerialized]
		public UIManager _uiManager;

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void OnDisable()
		{
		}
	}
}

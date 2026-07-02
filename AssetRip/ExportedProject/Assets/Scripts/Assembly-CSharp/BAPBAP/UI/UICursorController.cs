using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UICursorController : MonoBehaviour
	{
		[NonSerialized]
		public InputSystem inputSystem;

		[SerializeField]
		public int cursorSize;

		[SerializeField]
		public int targetRes;

		[NonSerialized]
		public bool debugBothCursors;

		[NonSerialized]
		public RectTransform cursor;

		[NonSerialized]
		public GameObject cursorCanvas;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}

		public void LateUpdate()
		{
		}
	}
}

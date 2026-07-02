using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UISelectionWheelOptionElement : MonoBehaviour
	{
		[NonSerialized]
		public UISelectableLerpElement selectableElement;

		[Header("References")]
		[SerializeField]
		public Image radialBgImage;

		[SerializeField]
		public Image iconImage;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public bool rotate;

		[Header("Settings")]
		[SerializeField]
		public float radialImageQuadSize;

		[NonSerialized]
		public RectTransform radialBgRect;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Initialize(string title, Sprite icon, Color color, Material iconMaterial = null)
		{
		}

		public void SetRadiusSize(float radius, int optionId, Material matInstance)
		{
		}
	}
}

using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIToggleSprite : MonoBehaviour
	{
		[SerializeField]
		public Toggle toggle;

		[SerializeField]
		public Sprite toggleOnSprite;

		[SerializeField]
		public Sprite toggleOffSprite;

		[SerializeField]
		public Color toggleOnColor;

		[SerializeField]
		public Color toggleOffColor;

		public void Awake()
		{
		}

		public void OnTargetToggleValueChanged(bool on)
		{
		}
	}
}

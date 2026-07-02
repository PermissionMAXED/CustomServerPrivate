using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIToggleSpriteSwapColor : MonoBehaviour
	{
		[SerializeField]
		public Toggle toggle;

		[SerializeField]
		public Image image;

		[SerializeField]
		public Sprite onSprite;

		[SerializeField]
		public Sprite offSprite;

		[SerializeField]
		public Color onColor;

		[SerializeField]
		public Color offColor;

		public void Awake()
		{
		}

		public void SwapSprite(bool isOn)
		{
		}
	}
}

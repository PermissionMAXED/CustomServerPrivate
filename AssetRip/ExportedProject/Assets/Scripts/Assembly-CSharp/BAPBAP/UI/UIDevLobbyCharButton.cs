using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIDevLobbyCharButton : MonoBehaviour
	{
		[SerializeField]
		public Image illustrationImage;

		[SerializeField]
		public Image bgImage;

		[SerializeField]
		public TMP_Text nameText;

		public void Initialize(Sprite charSprite, string charName, Color charColor)
		{
		}
	}
}

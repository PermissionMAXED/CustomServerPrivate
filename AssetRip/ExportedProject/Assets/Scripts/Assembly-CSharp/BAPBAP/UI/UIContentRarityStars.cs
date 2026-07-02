using BAPBAP.Content;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIContentRarityStars : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public Image[] starImages;

		[SerializeField]
		public HorizontalLayoutGroup hLayoutGroup;

		[SerializeField]
		public Sprite starImage;

		[SerializeField]
		public Sprite starImageOutlined;

		[Header("Configs")]
		[SerializeField]
		public bool setRarityColor;

		public void OnValidate()
		{
		}

		public void SetStarRarity(Rarity rarity, Color rarityColor)
		{
		}
	}
}

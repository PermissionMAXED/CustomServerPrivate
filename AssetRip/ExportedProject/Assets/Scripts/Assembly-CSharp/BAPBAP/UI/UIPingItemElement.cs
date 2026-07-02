using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIPingItemElement : UIPingElement
	{
		[Header("Item References")]
		[SerializeField]
		public Image tierBgImage;

		public void Awake()
		{
		}

		public void SetUpItemPing(Color tierColor, Sprite icon)
		{
		}
	}
}

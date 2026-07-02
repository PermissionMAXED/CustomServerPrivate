using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIThemeElementSprite : UIThemeElement
	{
		[SerializeField]
		[NamedArray(typeof(ThemeMode), 0)]
		public Sprite[] themeSprites;

		[SerializeField]
		public Image graphic;

		public override void SetThemeMode(ThemeMode mode, bool doFade)
		{
		}

		public void OnValidate()
		{
		}
	}
}

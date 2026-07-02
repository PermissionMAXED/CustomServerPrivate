using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UITooltipElement : MonoBehaviour
	{
		[Header("Text References")]
		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public TMP_Text subTitleText;

		[SerializeField]
		public TMP_Text descriptionText;

		[SerializeField]
		public TMP_Text descExpandText;

		[SerializeField]
		public TMP_Text bottomTextText;

		[SerializeField]
		public Image bgColorImage;

		[SerializeField]
		public GameObject headerObj;

		[SerializeField]
		public TMP_Text headerText;

		[SerializeField]
		public Image headerIcon;

		[SerializeField]
		public Image headerDivider;

		[SerializeField]
		public Image[] rarityStars;

		[SerializeField]
		[Header("Other References")]
		public LayoutElement layoutElement;

		[SerializeField]
		public UIAlphaFade tooltipFade;

		[SerializeField]
		public RectTransform contents;

		[SerializeField]
		[Header("Settings")]
		public float preferedWidth;

		[Tooltip("Should the tooltip always keep the same width, even if the contents are smaller than the prefered width?")]
		[SerializeField]
		public bool keepConstantWidth;

		[SerializeField]
		public float bgColorAlpha;

		[NonSerialized]
		public string originalDescStr;

		[NonSerialized]
		public string extraDescStr;

		public void Awake()
		{
		}

		public void SetUpTooltip(Color titleColor, string titleStr, string subTitleStr = null, string descStr = null, string _extraDescStr = null, string expandDescStr = null, string botStr = null, bool bgColorEnabled = false, Color bgColor = default(Color), bool isHeaderEnabled = false, string headerStr = "", Color headerColor = default(Color), Sprite headerIcon = null, int headerStars = 0)
		{
		}

		public void InitializeHeader(bool isEnabled, string str = "", Color color = default(Color), Sprite icon = null, int rarityStars = 0)
		{
		}

		public void SetHeaderEnabled(bool isEnabled)
		{
		}

		public void SetHeaderRarityColor(Color color)
		{
		}

		public void SetHeaderText(string str)
		{
		}

		public void SetHeaderIcon(Sprite icon)
		{
		}

		public void SetHeaderRarity(int stars)
		{
		}

		public void SetTitleText(string str)
		{
		}

		public void SetSubTitleText(string str)
		{
		}

		public void SetDescriptionText(string str)
		{
		}

		public void TrySetOriginalDescription()
		{
		}

		public void TrySetExtraDescription()
		{
		}

		public void SetDescExpandText(string str)
		{
		}

		public void SetBottomText(string str)
		{
		}

		public void SetTitleColor(Color color)
		{
		}

		public void SetSubTitleColor(Color color)
		{
		}

		public void SetBackgroundColor(Color newColor)
		{
		}

		public void SetBackgroundColorEnabled(bool isEnabled)
		{
		}

		public void UpdateTextWrapLayout(float textWidth)
		{
		}
	}
}

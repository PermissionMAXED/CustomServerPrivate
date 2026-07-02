using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIMinimapDimension : MonoBehaviour
	{
		[SerializeField]
		public RectTransform areaRectTransform;

		[Tooltip("Is this dimension an overlay of the map texture? If enabled, need to set up a masking hierarchy of a copy of the map texture by the area rect.")]
		[SerializeField]
		public bool mapOverlay;

		[SerializeField]
		[ConditionalHide("mapOverlay", true)]
		public RawImage overlayMapCopyImage;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[NonSerialized]
		public RectTransform _rectTransform;

		public void Awake()
		{
		}

		public void SetMapImageTexture(Texture texture)
		{
		}

		public void SetPosition(Vector2 position)
		{
		}

		public void SetSize(float worldSize)
		{
		}

		public void RelocateMapCopyOverlay()
		{
		}

		public void DoFadeIn(bool instant = false)
		{
		}

		public void DoFadeOut(bool instant = false)
		{
		}
	}
}

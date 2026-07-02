using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIMinimapIcon : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Header("General References")]
		public RectTransform rectTransform;

		public Image baseImage;

		public Image colorImage;

		[NonSerialized]
		public int entityPrefabId;

		public virtual void Awake()
		{
		}

		public virtual void SetAccentColor(Color color)
		{
		}

		public virtual void SetBaseColor(Color color)
		{
		}

		public virtual void SetIconSprite(Sprite sprite)
		{
		}

		public virtual void SetPosition(Vector2 pixelPos)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}
	}
}

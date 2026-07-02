using UnityEngine;

namespace BAPBAP.UI
{
	public class RectShapeSprite : MonoBehaviour, IShape
	{
		[SerializeField]
		public SpriteRenderer rectSprite;

		[SerializeField]
		public Vector2 spriteBorder;

		public void SetSize(Vector2 halfScale, float halfAngle)
		{
		}
	}
}

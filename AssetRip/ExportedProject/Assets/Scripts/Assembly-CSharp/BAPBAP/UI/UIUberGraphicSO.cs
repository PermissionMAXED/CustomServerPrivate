using UnityEngine;

namespace BAPBAP.UI
{
	[CreateAssetMenu(fileName = "UIUberGraphicScriptableObject", menuName = "BAPBAP/UI/UIUberGraphic/UIUberGraphicSO")]
	public class UIUberGraphicSO : ScriptableObject
	{
		[SerializeField]
		public float outlineSize;

		[SerializeField]
		public Color color1;

		[SerializeField]
		public Color color2;

		[SerializeField]
		public float gradientAngle;
	}
}

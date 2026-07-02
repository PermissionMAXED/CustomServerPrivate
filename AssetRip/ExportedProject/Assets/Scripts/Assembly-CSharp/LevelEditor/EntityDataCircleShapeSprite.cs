using BAPBAP.Maps;
using BAPBAP.UI;
using UnityEngine;

namespace LevelEditor
{
	public class EntityDataCircleShapeSprite : CircleShapeSprite, IEditorEntityDataPropertyVisualizer
	{
		[SerializeField]
		public RectShapeSprite rectSprite;

		[SerializeField]
		public string distanceFloatFieldName;

		public void DoRefresh(MapEntityData.Property property)
		{
		}
	}
}

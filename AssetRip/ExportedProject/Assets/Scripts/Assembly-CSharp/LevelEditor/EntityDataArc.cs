using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public class EntityDataArc : MonoBehaviour, IEditorEntityDataPropertyVisualizer
	{
		[SerializeField]
		public string distanceFloatFieldName;

		public float maxHeight;

		public int numOfPoints;

		public LineRenderer lineRenderer;

		public GameObject targetObj;

		public AnimationCurve arcCurve;

		public void DoRefresh(MapEntityData.Property property)
		{
		}

		public void SetArc(float distance)
		{
		}

		public void SetArc(Vector3 endPoint)
		{
		}

		public Vector3[] GenerateArcPositions(Vector3 endPoint)
		{
			return null;
		}
	}
}

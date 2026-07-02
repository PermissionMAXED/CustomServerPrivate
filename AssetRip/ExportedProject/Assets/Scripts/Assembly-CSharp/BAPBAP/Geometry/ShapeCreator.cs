using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Geometry
{
	[SelectionBase]
	[ExecuteInEditMode]
	public class ShapeCreator : MonoBehaviour
	{
		public class Edge
		{
			public int v1;

			public int v2;

			public Edge(int aV1, int aV2)
			{
			}
		}

		[HideInInspector]
		public List<Shape> shapes;

		[HideInInspector]
		public ShapeCreator sourceShapeCreator;

		[HideInInspector]
		[SerializeField]
		public bool sampleShapesAsSplines;

		[HideInInspector]
		[SerializeField]
		[Range(1f, 20f)]
		public int sampleShapeDetail;

		[HideInInspector]
		[SerializeField]
		public bool isDirty;

		[HideInInspector]
		[SerializeField]
		public bool autoUpdateIfDirty;

		[SerializeField]
		[HideInInspector]
		public bool autoFillWithColliders;

		[HideInInspector]
		[SerializeField]
		public int autoFillLayer;

		[HideInInspector]
		[SerializeField]
		public bool autoCollidersAsTriggers;

		[HideInInspector]
		[SerializeField]
		public bool autoCollidersStatic;

		[HideInInspector]
		[SerializeField]
		public bool autoAlignClips;

		public List<Shape> Shapes => null;

		public bool SampleShapesAsSplines
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int SampleShapeDetail
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void SetDirty()
		{
		}

		public void UpdateIfDirty()
		{
		}

		public virtual void Awake()
		{
		}

		public virtual void OnDestroy()
		{
		}

		public virtual void OnEnable()
		{
		}

		public virtual void Start()
		{
		}

		public virtual void OnDisable()
		{
		}

		public virtual void UpdateShapeDisplay(bool fullRefresh = true)
		{
		}

		public virtual void Update()
		{
		}

		public Shape GetShapeById(string id)
		{
			return null;
		}

		public void CreateNewShape(Shape source)
		{
		}

		public void FlattenAllShapes()
		{
		}

		public void ClearShapes()
		{
		}

		public void RebuildAllEdges()
		{
		}

		public void MakeCircle(int shapeIndex)
		{
		}

		public void RemoveShape(int shapeIndex)
		{
		}

		public void CreateNewShape(bool setDirty = true)
		{
		}

		public List<(Vector3, Vector3, float, bool)> Get90DegreeCorners()
		{
			return null;
		}

		public void CreateDefaultShape(Vector3 offset, float yRotation = 0f, bool circle = false, float size = 1f)
		{
		}

		public virtual Dictionary<GUIContent, string> GetEdgeCustomDataOptions()
		{
			return null;
		}

		public virtual Dictionary<GUIContent, string> GetPointCustomDataOptions()
		{
			return null;
		}

		public void FillWithBoxColliders()
		{
		}

		public void ClearBoxColliders()
		{
		}

		public void CenterTransformToShapes()
		{
		}

		public void ApplyTransformRotation()
		{
		}

		public void GridSnapAllPoints()
		{
		}

		public void AutoConnectWithinRadius(float radius)
		{
		}
	}
}

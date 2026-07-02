using System;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

namespace BAPBAP.Geometry
{
	[Serializable]
	public class Shape
	{
		public enum GraphType
		{
			Asphalt = 0,
			Dirt = 1,
			Sand = 2
		}

		public class CachedCustomEdgeInfo
		{
			public Vector3 position1;

			public Vector3 position2;

			public string customData;

			public Vector3 customDataVector;
		}

		[Serializable]
		public class PointData
		{
			public enum ClipState
			{
				None = 0,
				Start = 1,
				End = 2
			}

			[SerializeField]
			public Vector3 Position;

			[SerializeField]
			public float Size;

			[SerializeField]
			public Color Color;

			[SerializeField]
			public float Offset;

			[SerializeField]
			public ClipState Clip;

			public string customData;

			public Vector3 customDataVector;
		}

		[Serializable]
		public class EdgeData
		{
			public int v1;

			public int v2;

			public int id;

			public string customData;

			public Vector3 customDataVector;

			public EdgeData(int aV1, int aV2)
			{
			}
		}

		public class ColliderData
		{
			public Vector3 center;

			public Vector3 direction;

			public Vector3 normal;

			public Vector3 position;

			public Quaternion rotation;

			public Vector3 size;
		}

		public class Intersection
		{
			public float distance;

			public int intersectedEdgeIndex;

			public Vector3 position;
		}

		[Serializable]
		public class Connection
		{
			public string shapeId;

			public int c;
		}

		[SerializeField]
		[HideInInspector]
		public List<PointData> Points;

		[SerializeField]
		[HideInInspector]
		public List<EdgeData> Edges;

		public string shapeId;

		public bool isHole;

		public bool isUnconstrained;

		public float rotation;

		public bool flipFaces;

		public Vector3 minPos;

		public Vector3 maxPos;

		public Spline.Type splineType;

		public bool isConnection;

		public bool isGraph;

		public List<Connection> connections;

		public float width;

		public float overrideVertexColorAlpha;

		public GraphType startType;

		public GraphType endType;

		public float extrudeHeight;

		public GameObject[] sourceSplines;

		public SplineComputer[] splines;

		public SplineComputer[] clippedSplines;

		public bool reverse;

		public bool closed;

		public bool transferSettings;

		public bool[] applyClips;

		public float[] addSize;

		public float[] addOffset;

		[NonSerialized]
		public Vector3[] drawPositions;

		[NonSerialized]
		public Spline shapeSpline;

		[NonSerialized]
		public HashSet<Vector3> uniquePoints;

		public int PointCount => 0;

		public int EdgeCount => 0;

		public Vector3 this[int index]
		{
			get
			{
				return default(Vector3);
			}
			set
			{
			}
		}

		public List<Vector3> PointsList => null;

		public List<PointData> PointDataList => null;

		public Vector3 Center => default(Vector3);

		public float Area { get; set; }

		public float Perimeter { get; set; }

		public float X { get; set; }

		public float Z { get; set; }

		public Spline ShapeSpline => null;

		public void CalculateMeasurements()
		{
		}

		public Bounds GetWorldBounds(Transform transform)
		{
			return default(Bounds);
		}

		public Bounds CalculateBounds()
		{
			return default(Bounds);
		}

		public Vector3 ClampToBounds(Vector3 point, float padding)
		{
			return default(Vector3);
		}

		public void Get90DegreeCorners(ref List<(Vector3 cornerPosition, Vector3 cornerForward, float angle, bool inner)> corners)
		{
		}

		public float GetCornerAngle(int i, Transform transform = null)
		{
			return 0f;
		}

		public PointData AddPointData(Vector3 position)
		{
			return null;
		}

		public void AddPointData(PointData pointData)
		{
		}

		public PointData InsertPointDataAt(int index, Vector3 position)
		{
			return null;
		}

		public void UpdatePointDataAt(int index, Vector3 newPosition)
		{
		}

		public void UpdatePointDataAt(int index, float newSize)
		{
		}

		public bool ContainsPointData(PointData point)
		{
			return false;
		}

		public int IndexOfPointData(PointData point)
		{
			return 0;
		}

		public void RemovePointData(PointData point)
		{
		}

		public void RemovePointDataAt(int index)
		{
		}

		public PointData GetPointDataAt(int index)
		{
			return null;
		}

		public EdgeData GetEdgeDataAt(int index)
		{
			return null;
		}

		public void ReverseShape()
		{
		}

		public void ValidateShape()
		{
		}

		public void CheckSignedArea()
		{
		}

		public void RebuildEdges()
		{
		}

		public void ApplyCachedCustomData(List<CachedCustomEdgeInfo> customData)
		{
		}

		public List<CachedCustomEdgeInfo> CacheCustomData()
		{
			return null;
		}

		public float SignedArea(List<PointData> pointData)
		{
			return 0f;
		}

		public void MergeWith(Shape other)
		{
		}

		public bool ConcaveContains(Vector3 point, Transform transform = null)
		{
			return false;
		}

		public float IsLeft(Vector3 p1, Vector3 p2, Vector3 point)
		{
			return 0f;
		}

		public int ClosestPointIndex(Vector3 point)
		{
			return 0;
		}

		public (Shape, Shape) SplitAtEdge(EdgeData edge)
		{
			return default((Shape, Shape));
		}

		public void FlipEdge(EdgeData edge)
		{
		}

		public List<Vector3> GetCompositePointAt(int vertexIndex, bool useShapeSpline = false)
		{
			return null;
		}

		public void Flatten()
		{
		}

		public void StraightenPoints(int start, int end)
		{
		}

		public void CopyShape(Shape other, bool copyPoints = true)
		{
		}

		public void Transform(Transform source, Transform newParent)
		{
		}

		public void MakeCircle()
		{
		}

		public void ValidateSpline(bool force = false)
		{
		}

		public void DrawSpline(Texture2D outlineTexture, Color color, Transform transform)
		{
		}

		public void DrawSpline(Spline spline, Color color, Texture2D outlineTexture, Transform transform, double from = 0.0, double to = 1.0)
		{
		}

		public void DrawFillWithBoxColliders(Transform transform, float height)
		{
		}

		public List<Collider> FillWithBoxColliders(Transform parentTransform, int layer, float height, bool triggers = false, bool staticColliders = true, bool addFowBuilder = false)
		{
			return null;
		}

		public void CalculateColliderData(Transform parentTransform, float height, List<ColliderData> colliderData, bool reverse = true)
		{
		}

		public List<Vector3> GetConnectionsConvexHull(ShapeCreator shapeCreator, out List<GraphType> sortedTypes, out List<float> sortedWidths)
		{
			sortedTypes = null;
			sortedWidths = null;
			return null;
		}

		public void Simplify(float tolerance = 5f)
		{
		}

		public List<Vector3> RamerDouglasPeucker(List<Vector3> points, float tolerance)
		{
			return null;
		}

		public float PerpendicularDistance(Vector3 point, Vector3 lineStart, Vector3 lineEnd)
		{
			return 0f;
		}

		public PointData ClosestPoint(Vector3 point, out float distance, float maxDistance = 0f)
		{
			distance = default(float);
			return null;
		}

		public EdgeData ClosestEdge(Vector3 point, out float distance, float maxDistance = 0f)
		{
			distance = default(float);
			return null;
		}
	}
}

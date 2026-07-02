using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Geometry
{
	public class WallShapeCreator : ShapeCreator
	{
		public enum PlacementMode
		{
			Stretch = 0,
			Repeat = 1
		}

		public bool generate;

		public bool hideChildrenInHierarchy;

		[SerializeField]
		public MeshShapeCreator floorShapeCreator;

		[SerializeField]
		public float floorHeight;

		[SerializeField]
		public bool generateFloor;

		[SerializeField]
		public MeshShapeCreator ceilingShapeCreator;

		[SerializeField]
		public float ceilingHeight;

		[SerializeField]
		public bool generateCeiling;

		[SerializeField]
		public Vector2Int levelRange;

		[SerializeField]
		public WallPartCollection[] wallParts;

		public bool autoConvert;

		[Range(0f, 1f)]
		public float chanceToSkip;

		[SerializeField]
		public PlacementMode placementMode;

		[Min(0f)]
		[SerializeField]
		public float slack;

		[SerializeField]
		[Min(1f)]
		public int slackDensity;

		public float lookDirectionOffset;

		public bool lookAtPivot;

		[SerializeField]
		public Vector3 cornerScaleMultiplier;

		[SerializeField]
		public float cornerAngleThreshold;

		[SerializeField]
		public float cornerSize;

		[SerializeField]
		public bool clipsAsCorners;

		[SerializeField]
		[Min(0.1f)]
		public float segmentWidth;

		[SerializeField]
		[Min(0.1f)]
		public float segmentHeightMultiplier;

		[SerializeField]
		[Min(0.1f)]
		public float segmentDepthMultiplier;

		[SerializeField]
		public GameObject[] wallPrefabs;

		[SerializeField]
		public GameObject[] edgeCustomDataPrefabs;

		[SerializeField]
		public GameObject wallEndPrefab1;

		[SerializeField]
		public GameObject wallEndPrefab2;

		[SerializeField]
		public GameObject cornerPrefab;

		[SerializeField]
		public GameObject innerCornerPrefab;

		[SerializeField]
		public GameObject[] pointCustomDataPrefabs;

		[NonSerialized]
		public List<Texture2D> edgeCustomDataTextures;

		[NonSerialized]
		public List<Texture2D> pointCustomDataTextures;

		[NonSerialized]
		public List<Vector3> linePoints;

		public void ConvertLegacyParts()
		{
		}

		public void DestroyAllChildren()
		{
		}

		public override void UpdateShapeDisplay(bool fullRefresh = true)
		{
		}

		public void SpawnLevel(int level)
		{
		}

		public void SpawnOnConnection(int level, Shape shape, WallPartCollection wpc)
		{
		}

		public void SpawnOnPoints(int level, WallPartCollection wpc, Shape shape)
		{
		}

		public void SpawnOnEdges(int level, Shape shape, WallPartCollection wpc)
		{
		}

		public Vector3 GetLevelOffset(int level)
		{
			return default(Vector3);
		}

		public WallPartCollection GetWallPartCollection(int level)
		{
			return null;
		}

		public void PlaceStretched(WallPartCollection wpc, Vector3 startPosition, Vector3 edgeDirection, int k, int max, float width)
		{
		}

		public static Vector3 CalculateScale(Vector3 scale, WallPartCollection wpc, float adjustedWallWidth, Vector3 forward, float widthMultiplier)
		{
			return default(Vector3);
		}

		public void UpdateCatenary(Vector3 endPosition, Vector3 startPosition, int segments, float slack)
		{
		}

		public float Cosh(float f)
		{
			return 0f;
		}

		public float Sinh(float f)
		{
			return 0f;
		}

		public float Coth(float f)
		{
			return 0f;
		}

		public void CreateCatenary(List<Vector3> points, in Vector3 p1, in Vector3 p2, int segments, float targetLength)
		{
		}

		public override Dictionary<GUIContent, string> GetEdgeCustomDataOptions()
		{
			return null;
		}

		public override Dictionary<GUIContent, string> GetPointCustomDataOptions()
		{
			return null;
		}
	}
}

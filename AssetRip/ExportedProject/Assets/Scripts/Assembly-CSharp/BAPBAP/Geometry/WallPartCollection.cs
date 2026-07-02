using System;
using UnityEngine;

namespace BAPBAP.Geometry
{
	[Serializable]
	[CreateAssetMenu(fileName = "WallPartCollection", menuName = "LevelEditor/WallPartCollection", order = 1)]
	public class WallPartCollection : ScriptableObject
	{
		public float levelHeight;

		public Vector3 pivotOffset;

		[Min(0.1f)]
		public float segmentWidth;

		public bool scaleByWidthMultiplier;

		[Min(0.1f)]
		public float segmentHeightMultiplier;

		[Min(0.1f)]
		public float segmentDepthMultiplier;

		public Vector3 randomPositionOffset;

		public Vector3 cornerScaleMultiplier;

		public float cornerAngleThreshold;

		public float cornerSize;

		public bool clipsAsCorners;

		public bool averageDirection;

		public float lookDirectionOffset;

		public bool lookAtPivot;

		[Range(0f, 1f)]
		public float chanceToSkip;

		public WallShapeCreator.PlacementMode placementMode;

		public bool autoValidateColliders;

		[Min(0f)]
		public float slack;

		[Min(1f)]
		public int slackDensity;

		public GameObject[] wallPrefabs;

		public GameObject[] edgeCustomDataPrefabs;

		public GameObject wallEndPrefab1;

		public GameObject wallEndPrefab2;

		public GameObject cornerPrefab;

		public GameObject innerCornerPrefab;

		public GameObject[] pointCustomDataPrefabs;
	}
}

using System;
using BAPBAP.Maps;
using UnityEngine;

namespace BAPBAP.Local
{
	public class DynamicChunkLoader : MonoBehaviour
	{
		[Serializable]
		public class AreaConfig
		{
			[Tooltip("How large the search area is, in world units")]
			public Vector2 viewUnitDistance;

			[Tooltip("The world position offset for the camera center point to check the area")]
			public Vector2 worldPosOffset;
		}

		[NonSerialized]
		public LevelRuntimeManager levelRuntime;

		[Header("Settings")]
		[SerializeField]
		public AreaConfig defaultAreaConfig;

		[Tooltip("Update the dynamic chunk loading when the camera has moved past this threshold, in world units")]
		[SerializeField]
		public float moveDistThreshold;

		[Tooltip("Forces an immediate chunk load when the given distance threshold has been surpassed, in world units. Used for cases like teleporting")]
		[SerializeField]
		public float immediateChunkLoadDistThreshold;

		[Header("Debug")]
		[SerializeField]
		public bool showDebugGizmos;

		[NonSerialized]
		public float moveDistThresholdSqr;

		[NonSerialized]
		public float immediateChunkLoadDistThresholdSqr;

		[NonSerialized]
		public Vector2 prevWorldPos;

		[NonSerialized]
		public bool doInstantUpdate;

		[NonSerialized]
		public AreaConfig areaConfig;

		public void OnValidate()
		{
		}

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void UpdateChunkLoad(bool loadImmediate = false)
		{
		}

		public void SetAreaConfig(AreaConfig areaConfig)
		{
		}

		public void SetDefaultAreaConfig()
		{
		}

		public void OnDrawGizmos()
		{
		}
	}
}

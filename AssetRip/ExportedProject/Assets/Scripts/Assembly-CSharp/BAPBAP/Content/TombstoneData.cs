using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "TombstoneData", menuName = "BAPBAP/Content/Tombstones/TombstoneData", order = 1)]
	public class TombstoneData : ScriptableObject
	{
		[Header("Config")]
		[SerializeField]
		public float defaultDisplayScale;

		[SerializeField]
		[Header("3D Visualizer Settings")]
		public ContentVisualizer3D contentVisualizer3DPrefab;

		public ContentVisualizer3D.VisualizerSettings vis3DSettings;

		public ContentVisualizer3D.VisualizerSettings thumbVis3DSettings;

		[Space(10f)]
		[InspectorButton("OnTriggerRebuild")]
		[SerializeField]
		public bool TriggerRebuild;

		[BeginReadOnlyGroup]
		[SerializeField]
		public TombstoneSO[] tombstones;

		public const int assetTombstoneOffset = 700000;

		public Tombstone GetTombstoneByTombstoneId(int tombstoneId)
		{
			return null;
		}

		public int GetTombstoneIdByTombstone(Tombstone tombstone)
		{
			return 0;
		}

		public Tombstone GetTombstoneByAssetId(int assetId)
		{
			return null;
		}

		public static int GetTombstoneAssetIdByTombstone(Tombstone tombstone)
		{
			return 0;
		}
	}
}

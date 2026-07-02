using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "SkinData", menuName = "BAPBAP/Content/Skins/SkinData", order = 1)]
	public class SkinData : ScriptableObject
	{
		[Header("Config")]
		[SerializeField]
		public float defaultSkinDisplayScale;

		[Header("3D Visualizer Settings")]
		[SerializeField]
		public ContentVisualizer3D contentVisualizer3DPrefab;

		public ContentVisualizer3D.VisualizerSettings vis3DSettings;

		public ContentVisualizer3D.VisualizerSettings thumbVis3DSettings;

		[SerializeField]
		[Space(10f)]
		[InspectorButton("OnTriggerRebuild")]
		public bool TriggerRebuild;

		[SerializeField]
		[BeginReadOnlyGroup]
		public SkinSO[] skins;

		public const int assetSkinOffset = 300000;

		public Skin GetSkinBySkinId(int skinId)
		{
			return null;
		}

		public int GetSkinIdBySkin(Skin skin)
		{
			return 0;
		}

		public Skin GetSkinByAssetId(int assetId)
		{
			return null;
		}

		public static int GetSkinIdBySkinAssetId(int skinAssetId)
		{
			return 0;
		}

		public static int GetSkinAssetIdBySkin(Skin skin)
		{
			return 0;
		}
	}
}

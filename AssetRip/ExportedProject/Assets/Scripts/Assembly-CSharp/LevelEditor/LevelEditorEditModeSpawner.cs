using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public class LevelEditorEditModeSpawner : MonoBehaviour
	{
		[SerializeField]
		public string _levelName;

		[SerializeField]
		public LevelRuntimeManager _runtimeManager;

		[SerializeField]
		public LightProbeGroup _lightProbeGroup;

		[SerializeField]
		[InspectorButton("SpawnLevel")]
		public bool _spawnLevel;

		[SerializeField]
		[InspectorButton("ForceRebuildBiomeAndSplat")]
		public bool _forceRebuildBiomeAndSplat;

		public void SpawnLevel()
		{
		}

		public void ForceRebuildBiomeAndSplat()
		{
		}
	}
}

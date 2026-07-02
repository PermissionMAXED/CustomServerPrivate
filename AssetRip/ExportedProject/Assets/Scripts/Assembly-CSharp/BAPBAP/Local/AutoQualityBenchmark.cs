using System;
using System.Diagnostics;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AutoQualityBenchmark : MonoBehaviour
	{
		[SerializeField]
		public Camera renderCamera;

		[SerializeField]
		public Transform spawnParent;

		[SerializeField]
		public GameObject spawnPrefab;

		[SerializeField]
		public int spawnCount;

		[SerializeField]
		public int cpuTimeUltra;

		[SerializeField]
		public int gpuTimeUltra;

		[NonSerialized]
		public RenderTexture renderTexture;

		[NonSerialized]
		public Stopwatch stopwatch;

		public void Awake()
		{
		}

		public LocalSavedData.QualityPresets RunBenchmark()
		{
			return default(LocalSavedData.QualityPresets);
		}
	}
}

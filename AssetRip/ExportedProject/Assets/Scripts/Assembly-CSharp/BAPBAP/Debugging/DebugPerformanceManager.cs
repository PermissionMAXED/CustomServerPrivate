using System;
using BAPBAP.Utilities;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace BAPBAP.Debugging
{
	public class DebugPerformanceManager : MonoBehaviour
	{
		[SerializeField]
		public GameObject fpsBlockObj;

		[SerializeField]
		public DebugGraph graph;

		[SerializeField]
		public int fpsEMAWindow;

		[SerializeField]
		public Text valueText;

		[SerializeField]
		public Text stdevText;

		[SerializeField]
		public int decimalPrecision;

		[SerializeField]
		public int stdevDecimalPrecision;

		[SerializeField]
		public Text renderStatsText;

		[NonSerialized]
		public Volume postProcessingVolume;

		[NonSerialized]
		public ProfilerRecorder drawCallsRecorder;

		[NonSerialized]
		public ProfilerRecorder trisRecorder;

		[NonSerialized]
		public ProfilerRecorder vertsRecorder;

		public ExpMovingAverage fpsEMA;

		[NonSerialized]
		public bool addedCmds;

		[NonSerialized]
		public bool gatherFpsStats;

		[NonSerialized]
		public bool renderStatsEnabled;

		[NonSerialized]
		public float renderStatsUpdateTimer;

		[NonSerialized]
		public string decimalPrecisionString;

		[NonSerialized]
		public string stdevDecimalPrecisionString;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void OnDebugWindowOpen()
		{
		}

		public void OnDebugWindowClosed()
		{
		}

		public void OnDisable()
		{
		}

		public void DebugShadowmap()
		{
		}

		public void ToggleDirLightShadows()
		{
		}

		public void ToggleRenderMapBakedShadows()
		{
		}

		public void ToggleRenderStats()
		{
		}

		public void TogglePostProcessing()
		{
		}
	}
}

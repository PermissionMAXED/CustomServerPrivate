using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Network;
using BAPBAP.Systems;
using BAPBAP.Utilities;
using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Debugging
{
	public class DebugNetcodeManager : MonoBehaviour
	{
		[NonSerialized]
		public DebugManager debugManager;

		[NonSerialized]
		public SystemManager systemManager;

		[SerializeField]
		public DebugGraph pingGraph;

		[SerializeField]
		public DebugGraph perceivedPingGraph;

		[SerializeField]
		public DebugGraph lerpGraph;

		[SerializeField]
		public DebugGraph predGraph;

		[SerializeField]
		public DebugGraph bandwidthGraph;

		[SerializeField]
		public Text pingText;

		[SerializeField]
		public Text jitterText;

		[SerializeField]
		public GameObject netcodeBlock;

		[NonSerialized]
		public ExpMovingAverage perceivedPingEMA;

		[NonSerialized]
		public ExpMovingAverage packetSizeEMA;

		[NonSerialized]
		public CustomSpatialHashInterestManagement cshim;

		[NonSerialized]
		public CustomGrid2D<NetworkConnectionToClient> cgrid;

		[NonSerialized]
		public string pingDecimalPrecisionString;

		[NonSerialized]
		public string jitterDecimalPrecisionString;

		[NonSerialized]
		public bool addedCmds;

		[NonSerialized]
		public bool gatherPacketSize;

		[NonSerialized]
		public bool gatherNetStats;

		[NonSerialized]
		public bool debugNetSync;

		[NonSerialized]
		public bool debugNetSyncServer;

		[NonSerialized]
		public bool debugNetErrorCorrection;

		[NonSerialized]
		public bool debugDeltaCompression;

		[NonSerialized]
		public bool debugAoI;

		[NonSerialized]
		public bool debugPrintNetSyncsPerFrame;

		[NonSerialized]
		public int lastUpdateRecvFrame;

		[NonSerialized]
		public float printNetSyncsCounter;

		[NonSerialized]
		public float printNetSyncsInterval;

		[NonSerialized]
		public Dictionary<int, int> netStateSyncsPerFrame;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void ManagedUpdate()
		{
		}

		public void ManagedLateUpdate()
		{
		}

		public void AddPingData(float rtt, float rttEMA)
		{
		}

		public void AddPerceivedPing(float percPing)
		{
		}

		public void AddLerpData(float lerpDelay, float lerpDelayEMA)
		{
		}

		public void AddPredData(float predTickAhead, float resim)
		{
		}

		public void AddBufferData(float offset, float calcServerBuffer)
		{
		}

		public void UpdatePing(float rttEMA)
		{
		}

		public void UpdateJitter(float data)
		{
		}

		public void AddSyncData(int num)
		{
		}

		public void ToggleTimeDilation()
		{
		}

		public void ToggleNetSyncServer()
		{
		}

		public void ToggleNetSyncClients()
		{
		}

		public void ToggleNetPredictionClients()
		{
		}

		public void ToggleNetPredictionPhysicsResimClients()
		{
		}

		public void ToggleNetErrorSmoothing()
		{
		}

		public void ToggleNetDeltaCompression()
		{
		}

		public void TogglePrintNetSyncs()
		{
		}

		public void ToggleAoI()
		{
		}

		public Vector3 TransformIntoAoIGrid(Vector3 vec3, bool passThruCenter = false, bool isLog = false)
		{
			return default(Vector3);
		}

		public void SpawnAoIFill()
		{
		}

		public void PrintNetWriters()
		{
		}

		public void OnDebugWindowOpen()
		{
		}

		public void OnDebugWindowClosed()
		{
		}

		public string FormatNetWriters()
		{
			return null;
		}

		public void FormatNetWriterSizes(StringBuilder sb, NetworkWriter[] writers)
		{
		}
	}
}

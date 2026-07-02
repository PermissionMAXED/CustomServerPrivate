using System;
using System.Collections.Generic;
using BAPBAP.Debugging;
using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Network;
using BAPBAP.Systems;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CharNetwork : NetworkBehaviour
	{
		[NonSerialized]
		public EntityManager entityManager;

		[NonSerialized]
		public CharEvents charEvents;

		[NonSerialized]
		public CharSimulation charSim;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public DebugNetcodeManager debugNetcodeManager;

		[NonSerialized]
		public SystemManager systemManager;

		[Header("Configs")]
		[SerializeField]
		public GameObject serverViewPrefab;

		[SerializeField]
		public bool enableServerView;

		[SerializeField]
		[Tooltip("Allow prediction to run on this entity (only if locally owned)")]
		public bool isPredicted;

		[SerializeField]
		public bool predictionPhysicsResim;

		[NonSerialized]
		public bool clReceivedStateSyncThisFrame;

		[NonSerialized]
		public int clLatestProcessedSvPredTickNum;

		[NonSerialized]
		public int clLatestReceivedSvPredTickNum;

		[NonSerialized]
		public GameObject clServerViewObj;

		[NonSerialized]
		public ClientDeltaCompressor clDeltaCompressor;

		[NonSerialized]
		public ServerDeltaCompressor svDeltaCompressor;

		[NonSerialized]
		public NetworkWriter svEventsWriter;

		[NonSerialized]
		public Command svNullNpcCmd;

		[NonSerialized]
		public bool svShouldDoNetStateSync;

		public void PreAwake(EntityManager e)
		{
		}

		public void ManagedFixedUpdate()
		{
		}

		public void ManagedUpdate()
		{
		}

		public override void OnStartClient()
		{
		}

		public override void OnStopClient()
		{
		}

		public void ClTick()
		{
		}

		public void DoClientSidePrediction()
		{
		}

		public void OnTargetStateSync(NetworkReader reader)
		{
		}

		public void OnTargetEventsSync(NetworkReader reader)
		{
		}

		public void NetworkEarlyUpdate()
		{
		}

		public void ReconciliatePredicted(int svPredTickNum, ArraySegment<byte> svState)
		{
		}

		public void Reconciliate(int svPredTickNum, ArraySegment<byte> svState)
		{
		}

		public void TogglePrediction()
		{
		}

		public void TogglePredictionPhysicsResim()
		{
		}

		public override void OnStartServer()
		{
		}

		public override void OnStopServer()
		{
		}

		public void SvTick()
		{
		}

		public void ManagedSvUpdate(Dictionary<int, NetworkWriter> stateWriters, Dictionary<int, NetworkWriter> eventWriters)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}

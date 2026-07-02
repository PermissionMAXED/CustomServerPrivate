using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class NpcAgentOffMeshLinkSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public NavMeshAgent agent;

		[NonSerialized]
		public float maxDistanceFromLinkPos;

		[NonSerialized]
		public float maxWaitTime;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public bool isOnOffMeshLinkCache;

		public NpcAgentOffMeshLinkSubroutine(NpcBehaviour _npcBehaviour)
		{
		}

		public override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			return 0;
		}

		public override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}

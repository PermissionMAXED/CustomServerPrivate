using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine.AI;

namespace BAPBAP.Entities
{
	public class NpcReturnSubroutine : SimulationSubroutine
	{
		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public byte trigger;

		[NonSerialized]
		public NavMeshAgent agent;

		[NonSerialized]
		public float originalStoppingDistance;

		[NonSerialized]
		public bool destinationPendingSet;

		public NpcReturnSubroutine(NpcBehaviour _npcBehaviour, byte _trigger)
		{
		}

		public override void OnEnter(float fixedDt, Command cmd, bool isResim)
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
